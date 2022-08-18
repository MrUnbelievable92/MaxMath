using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.maxmath;

namespace MaxMath
{
    [Serializable] 
	[StructLayout(LayoutKind.Explicit, Size = 4 * sizeof(sbyte))]  
	[DebuggerTypeProxy(typeof(sbyte4.DebuggerProxy))]
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
                if (Constant.IsConstantExpression(x) && Constant.IsConstantExpression(y) && Constant.IsConstantExpression(z) && Constant.IsConstantExpression(w))
                {
                    this = Sse2.cvtsi32_si128((int)bitfield(x, y, z, w));
                }
                else
                {
					this = Sse2.set_epi8(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, w, z, y, x);
                }
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
                if (Constant.IsConstantExpression(xyzw))
                {
					this = Sse2.cvtsi32_si128((int)bitfield(xyzw, xyzw, xyzw, xyzw));
                }
				else
				{
					this = Sse2.set1_epi8(xyzw);
				}
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
				this = Sse2.or_si128(xyz, Sse2.bslli_si128(Sse2.cvtsi32_si128((byte)w), 3 * sizeof(sbyte)));
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
				this = Sse2.or_si128(Sse2.bslli_si128(yzw, sizeof(sbyte)), Sse2.cvtsi32_si128((byte)x));
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
		public readonly sbyte4 xxxx
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xxxx(this);
                }
                else
                {
                    return new sbyte4(x, x, x, x);
                }
            }
        }
        public readonly sbyte4 xxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xxxy(this);
                }
                else
                {
                    return new sbyte4(x, x, x, y);
                }
            }
        }
        public readonly sbyte4 xxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xxxz(this);
                }
                else
                {
                    return new sbyte4(x, x, x, z);
                }
            }
        }
        public readonly sbyte4 xxxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xxxw(this);
                }
				else
				{
					return new sbyte4(x, x, x, w);
				}
			}
		}
        public readonly sbyte4 xxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xxyx(this);
                }
                else
                {
                    return new sbyte4(x, x, y, x);
                }
            }
        }
        public readonly sbyte4 xxyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xxyy(this);
                }
				else
				{
					return new sbyte4(x, x, y, y);
				}
			}
		}
        public readonly sbyte4 xxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xxyz(this);
                }
                else
                {
                    return new sbyte4(x, x, y,z);
                }
            }
        }
        public readonly sbyte4 xxyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xxyw(this);
                }
				else
				{
					return new sbyte4(x, x, y, w);
				}
			}
		}
        public readonly sbyte4 xxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xxzx(this);
                }
                else
                {
                    return new sbyte4(x, x, z, x);
                }
            }
        }
        public readonly sbyte4 xxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xxzy(this);
                }
                else
                {
                    return new sbyte4(x, x, z, y);
                }
            }
        }
        public readonly sbyte4 xxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xxzz(this);
                }
                else
                {
                    return new sbyte4(x, x, z, z);
                }
            }
        }
        public readonly sbyte4 xxzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xxzw(this);
                }
				else
				{
					return new sbyte4(x, x, z, w);
				}
			}
		}
        public readonly sbyte4 xxwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xxwx(this);
                }
				else
				{
					return new sbyte4(x, x, w, x);
				}
			}
		}
        public readonly sbyte4 xxwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xxwy(this);
                }
				else
				{
					return new sbyte4(x, x, w, y);
				}
			}
		}
        public readonly sbyte4 xxwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xxwz(this);
                }
				else
				{
					return new sbyte4(x, x, w, z);
				}
			}
		}
        public readonly sbyte4 xxww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xxww(this);
                }
				else
				{
					return new sbyte4(x, x, w, w);
				}
			}
		}
        public readonly sbyte4 xyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xyxx(this);
                }
                else
                {
                    return new sbyte4(x, y, x, x);
                }
            }
        }
		public readonly sbyte4 xyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xyxy(this);
                }
				else
				{
					return new sbyte4(x, y, x, y);
				}
			}
		}
        public readonly sbyte4 xyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xyxz(this);
                }
                else
                {
                    return new sbyte4(x, y, x, z);
                }
            }
        }
		public readonly sbyte4 xyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xyxw(this);
                }
				else
				{
					return new sbyte4(x, y, x, w);
				}
			}
		}
		public readonly sbyte4 xyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xyyx(this);
                }
                else
                {
                    return new sbyte4(x, y, y, x);
                }
            }
        }
		public readonly sbyte4 xyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xyyy(this);
                }
                else
                {
                    return new sbyte4(x, y, y, y);
                }
            }
        }
		public readonly sbyte4 xyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xyyz(this);
                }
                else
                {
                    return new sbyte4(x, y, y, z);
                }
            }
        }
		public readonly sbyte4 xyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xyyw(this);
                }
				else
				{
					return new sbyte4(x, y, y, w);
				}
			}
		}
		public readonly sbyte4 xyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xyzx(this);
                }
                else
                {
                    return new sbyte4(x, y, z, x);
                }
            }
        }
        public readonly sbyte4 xyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xyzy(this);
                }
                else
                {
                    return new sbyte4(x, y, z, y);
                }
            }
        }
        public readonly sbyte4 xyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xyzz(this);
                }
                else
                {
                    return new sbyte4(x, y, z, z);
                }
            }
        }
		public readonly sbyte4 xywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xywx(this);
                }
				else
				{
					return new sbyte4(x, y, w, x);
				}
			}
		}
		public readonly sbyte4 xywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xywy(this);
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xywz(this);
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
		public readonly sbyte4 xyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xyww(this);
                }
				else
				{
					return new sbyte4(x, y, w, w);
				}
			}
		}
		public readonly sbyte4 xzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xzxx(this);
                }
                else
                {
                    return new sbyte4(x, z, x, x);
                }
            }
        }
        public readonly sbyte4 xzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xzxy(this);
                }
                else
                {
                    return new sbyte4(x, z, x, y);
                }
            }
        }
        public readonly sbyte4 xzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xzxz(this);
                }
                else
                {
                    return new sbyte4(x, z, x, z);
                }
            }
        }
		public readonly sbyte4 xzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xzxw(this);
                }
				else
				{
					return new sbyte4(x, z, x, w);
				}
			}
		}
		public readonly sbyte4 xzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xzyx(this);
                }
                else
                {
                    return new sbyte4(x, z, y, x);
                }
            }
        }
        public readonly sbyte4 xzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xzyy(this);
                }
                else
                {
                    return new sbyte4(x, z, y, y);
                }
            }
        }
        public readonly sbyte4 xzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xzyz(this);
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xzyw(this);
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
		public readonly sbyte4 xzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xzzx(this);
                }
                else
                {
                    return new sbyte4(x, z, z, x);
                }
            }
        }
        public readonly sbyte4 xzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xzzy(this);
                }
                else
                {
                    return new sbyte4(x, z, z, y);
                }
            }
        }
        public readonly sbyte4 xzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xzzz(this);
                }
                else
                {
                    return new sbyte4(x, z, z, z);
                }
            }
        }
		public readonly sbyte4 xzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xzzw(this);
                }
				else
				{
					return new sbyte4(x, z, z, w);
				}
			}
		}
		public readonly sbyte4 xzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xzwx(this);
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xzwy(this);
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
		public readonly sbyte4 xzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xzwz(this);
                }
				else
				{
					return new sbyte4(x, z, w, z);
				}
			}
		}
		public readonly sbyte4 xzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xzww(this);
                }
				else 
				{
					return new sbyte4(x, z, w, w);
				}
			}
		}
		public readonly sbyte4 xwxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xwxx(this);
                }
				else
				{
					return new sbyte4(x, w, x, x);
				}
			}
		}
		public readonly sbyte4 xwxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xwxy(this);
                }
				else
				{
					return new sbyte4(x, w, x, y);
				}
			}
		}
		public readonly sbyte4 xwxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xwxz(this);
                }
				else
				{
					return new sbyte4(x, w, x, z);
				}
			}
		}
		public readonly sbyte4 xwxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xwxw(this);
                }
				else
				{
					return new sbyte4(x, w, x, w);
				}
			}
		}
		public readonly sbyte4 xwyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xwyx(this);
                }
				else
				{
					return new sbyte4(x, w, y, x);
				}
			}
		}
		public readonly sbyte4 xwyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xwyy(this);
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xwyz(this);
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
		public readonly sbyte4 xwyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xwyw(this);
                }
				else
				{
					return new sbyte4(x, w, y, w);
				}
			}
		}
		public readonly sbyte4 xwzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xwzx(this);
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xwzy(this);
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
		public readonly sbyte4 xwzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xwzz(this);
                }
				else
				{
					return new sbyte4(x, w, z, z);
				}
			}
		}
		public readonly sbyte4 xwzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xwzw(this);
                }
				else
				{
					return new sbyte4(x, w, z, w);
				}
			}
		}
		public readonly sbyte4 xwwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xwwx(this);
                }
				else
				{
					return new sbyte4(x, w, w, x);
				}
			}
		}
		public readonly sbyte4 xwwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xwwy(this);
                }
				else
				{
					return new sbyte4(x, w, w, y);
				}
			}
		}
		public readonly sbyte4 xwwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xwwz(this);
                }
				else
				{
					return new sbyte4(x, w, w, z);
				}
			}
		}
		public readonly sbyte4 xwww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xwww(this);
                }
				else
				{
					return new sbyte4(x, w, w, w);
				}
			}
		}
		public readonly sbyte4 yxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yxxx(this);
                }
                else
                {
                    return new sbyte4(y, x, x, x);
                }
            }
        }
        public readonly sbyte4 yxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yxxy(this);
                }
                else
                {
                    return new sbyte4(y, x, x, y);
                }
            }
        }
        public readonly sbyte4 yxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yxxz(this);
                }
                else
                {
                    return new sbyte4(y, x, x, z);
                }
            }
        }
		public readonly sbyte4 yxxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yxxw(this);
                }
				else
				{
					return new sbyte4(y, x, x, w);
				}
			}
		}
		public readonly sbyte4 yxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yxyx(this);
                }
                else
                {
                    return new sbyte4(y, x, y, x);
                }
            }
        }
        public readonly sbyte4 yxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yxyy(this);
                }
                else
                {
                    return new sbyte4(y, x, y, y);
                }
            }
        }
        public readonly sbyte4 yxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yxyz(this);
                }
                else
                {
                    return new sbyte4(y, x, y, z);
                }
            }
        }
		public readonly sbyte4 yxyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yxyw(this);
                }
				else
				{
					return new sbyte4(y, x, y, w);
				}
			}
		}
		public readonly sbyte4 yxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yxzx(this);
                }
                else
                {
                    return new sbyte4(y, x, z, x);
                }
            }
        }
        public readonly sbyte4 yxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yxzy(this);
                }
                else
                {
                    return new sbyte4(y, x, z, y);
                }
            }
        }
        public readonly sbyte4 yxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yxzz(this);
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yxzw(this);
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
		public readonly sbyte4 yxwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yxwx(this);
                }
				else
				{
					return new sbyte4(y, x, w, x);
				}
			}
		}
		public readonly sbyte4 yxwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yxwy(this);
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yxwz(this);
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
		public readonly sbyte4 yxww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yxww(this);
                }
				else
				{
					return new sbyte4(y, x, w, w);
				}
			}
		}
		public readonly sbyte4 yyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yyxx(this);
                }
                else
                {
                    return new sbyte4(y, y, x, x);
                }
            }
        }
        public readonly sbyte4 yyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yyxy(this);
                }
                else
                {
                    return new sbyte4(y, y, x, y);
                }
            }
        }
        public readonly sbyte4 yyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yyxz(this);
                }
                else
                {
                    return new sbyte4(y, y, x, z);
                }
            }
        }
		public readonly sbyte4 yyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yyxw(this);
                }
				else
				{
					return new sbyte4(y, y, x, w);
				}
			}
		}
		public readonly sbyte4 yyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yyyx(this);
                }
                else
                {
                    return new sbyte4(y, y, y, x);
                }
            }
        }
        public readonly sbyte4 yyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yyyy(this);
                }
                else
                {
                    return new sbyte4(y, y, y, y);
                }
            }
        }
        public readonly sbyte4 yyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yyyz(this);
                }
                else
                {
                    return new sbyte4(y, y, y, z);
                }
            }
        }
		public readonly sbyte4 yyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yyyw(this);
                }
				else
				{
					return new sbyte4(y, y, y, w);
				}
			}
		}
		public readonly sbyte4 yyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yyzx(this);
                }
                else
                {
                    return new sbyte4(y, y, z, x);
                }
            }
        }
        public readonly sbyte4 yyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yyzy(this);
                }
                else
                {
                    return new sbyte4(y, y, z, y);
                }
            }
        }
        public readonly sbyte4 yyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yyzz(this);
                }
                else
                {
                    return new sbyte4(y, y, z, z);
                }
            }
        }
		public readonly sbyte4 yyzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yyzw(this);
                }
				else
				{
					return new sbyte4(y, y, z, w);
				}
			}
		}
		public readonly sbyte4 yywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yywx(this);
                }
				else
				{
					return new sbyte4(y, y, w, x);
				}
			}
		}
		public readonly sbyte4 yywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yywy(this);
                }
				else
				{
					return new sbyte4(y, y, w, y);
				}
			}
		}
		public readonly sbyte4 yywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yywz(this);
                }
				else
				{
					return new sbyte4(y, y, w, z);
				}
			}
		}
		public readonly sbyte4 yyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yyww(this);
                }
				else
				{
					return new sbyte4(y, y, w, w);
				}
			}
		}
		public readonly sbyte4 yzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yzxx(this);
                }
                else
                {
                    return new sbyte4(y, z, x, x);
                }
            }
        }
        public readonly sbyte4 yzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yzxy(this);
                }
                else
                {
                    return new sbyte4(y, z, x, y);
                }
            }
        }
        public readonly sbyte4 yzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yzxz(this);
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yzxw(this);
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
		public readonly sbyte4 yzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yzyx(this);
                }
                else
                {
                    return new sbyte4(y, z, y, x);
                }
            }
        }
        public readonly sbyte4 yzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yzyy(this);
                }
                else
                {
                    return new sbyte4(y, z, y, y);
                }
            }
        }
        public readonly sbyte4 yzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yzyz(this);
                }
                else
                {
                    return new sbyte4(y, z, y, z);
                }
            }
        }
		public readonly sbyte4 yzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yzyw(this);
                }
				else
				{
					return new sbyte4(y, z, y, w);
				}
			}
		}
		public readonly sbyte4 yzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yzzx(this);
                }
                else
                {
                    return new sbyte4(y, z, z, x);
                }
            }
        }
        public readonly sbyte4 yzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yzzy(this);
                }
                else
                {
                    return new sbyte4(y, z, z, y);
                }
            }
        }
        public readonly sbyte4 yzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yzzz(this);
                }
                else
                {
                    return new sbyte4(y, z, z, z);
                }
            }
        }
		public readonly sbyte4 yzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yzzw(this);
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yzwx(this);
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
		public readonly sbyte4 yzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yzwy(this);
                }
				else
				{
					return new sbyte4(y, z, w, y);
				}
			}
		}
		public readonly sbyte4 yzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yzwz(this);
                }
				else
				{
					return new sbyte4(y, z, w, z);
				}
			}
		}
		public readonly sbyte4 yzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yzww(this);
                }
				else
				{
					return new sbyte4(y, z, w, w);
				}
			}
		}
		public readonly sbyte4 ywxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ywxx(this);
                }
				else
				{
					return new sbyte4(y, w, x, x);
				}
			}
		}
		public readonly sbyte4 ywxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ywxy(this);
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ywxz(this);
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
		public readonly sbyte4 ywxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ywxw(this);
                }
				else
				{
					return new sbyte4(y, w, x, w);
				}
			}
		}
		public readonly sbyte4 ywyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ywyx(this);
                }
				else
				{
					return new sbyte4(y, w, y, x);
				}
			}
		}
		public readonly sbyte4 ywyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ywyy(this);
                }
				else
				{
					return new sbyte4(y, w, y, y);
				}
			}
		}
		public readonly sbyte4 ywyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ywyz(this);
                }
				else
				{
					return new sbyte4(y, w, y, z);
				}
			}
		}
		public readonly sbyte4 ywyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ywyw(this);
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ywzx(this);
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
		public readonly sbyte4 ywzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ywzy(this);
                }
				else
				{
					return new sbyte4(y, w, z, y);
				}
			}
		}
		public readonly sbyte4 ywzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ywzz(this);
                }
				else
				{
					return new sbyte4(y, w, z, z);
				}
			}
		}
		public readonly sbyte4 ywzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ywzw(this);
                }
				else
				{
					return new sbyte4(y, w, z, w);
				}
			}
		}
		public readonly sbyte4 ywwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ywwx(this);
                }
				else
				{
					return new sbyte4(y, w, w, x);
				}
			}
		}
		public readonly sbyte4 ywwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ywwy(this);
                }
				else
				{
					return new sbyte4(y, w, w, y);
				}
			}
		}
		public readonly sbyte4 ywwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ywwz(this);
                }
				else
				{
					return new sbyte4(y, w, w, z);
				}
			}
		}
		public readonly sbyte4 ywww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ywww(this);
                }
				else
				{
					return new sbyte4(y, w, w, w);
				}
			}
		}
		public readonly sbyte4 zxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zxxx(this);
                }
                else
                {
                    return new sbyte4(z, x, x, x);
                }
            }
        }
        public readonly sbyte4 zxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zxxy(this);
                }
                else
                {
                    return new sbyte4(z, x, x, y);
                }
            }
        }
        public readonly sbyte4 zxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zxxz(this);
                }
                else
                {
                    return new sbyte4(z, x, x, z);
                }
            }
        }
		public readonly sbyte4 zxxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zxxw(this);
                }
				else
				{
					return new sbyte4(z, x, x, w);
				}
			}
		}
		public readonly sbyte4 zxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zxyx(this);
                }
                else
                {
                    return new sbyte4(z, x, y, x);
                }
            }
        }
        public readonly sbyte4 zxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zxyy(this);
                }
                else
                {
                    return new sbyte4(z, x, y, y);
                }
            }
        }
        public readonly sbyte4 zxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zxyz(this);
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zxyw(this);
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
		public readonly sbyte4 zxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zxzx(this);
                }
                else
                {
                    return new sbyte4(z, x, z, x);
                }
            }
        }
        public readonly sbyte4 zxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zxzy(this);
                }
                else
                {
                    return new sbyte4(z, x, z, y);
                }
            }
        }
        public readonly sbyte4 zxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zxzz(this);
                }
                else
                {
                    return new sbyte4(z, x, z, z);
                }
            }
        }
		public readonly sbyte4 zxzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zxzw(this);
                }
				else
				{
					return new sbyte4(z, x, z, w);
				}
			}
		}
		public readonly sbyte4 zxwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zxwx(this);
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zxwy(this);
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
		public readonly sbyte4 zxwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zxwz(this);
                }
				else
				{
					return new sbyte4(z, x, w, z);
				}
			}
		}
		public readonly sbyte4 zxww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zxww(this);
                }
				else
				{
					return new sbyte4(z, x, w, w);
				}
			}
		}
		public readonly sbyte4 zyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zyxx(this);
                }
                else
                {
                    return new sbyte4(z, y, x, x);
                }
            }
        }
        public readonly sbyte4 zyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zyxy(this);
                }
                else
                {
                    return new sbyte4(z, y, x, y);
                }
            }
        }
        public readonly sbyte4 zyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zyxz(this);
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zyxw(this);
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
		public readonly sbyte4 zyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zyyx(this);
                }
                else
                {
                    return new sbyte4(z, y, y, x);
                }
            }
        }
        public readonly sbyte4 zyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zyyy(this);
                }
                else
                {
                    return new sbyte4(z, y, y, y);
                }
            }
        }
        public readonly sbyte4 zyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zyyz(this);
                }
                else
                {
                    return new sbyte4(z, y, y, z);
                }
            }
        }
		public readonly sbyte4 zyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zyyw(this);
                }
				else
				{
					return new sbyte4(z, y, y, w);
				}
			}
		}
		public readonly sbyte4 zyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zyzx(this);
                }
                else
                {
                    return new sbyte4(z, y, z, x);
                }
            }
        }
        public readonly sbyte4 zyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zyzy(this);
                }
                else
                {
                    return new sbyte4(z, y, z, y);
                }
            }
        }
        public readonly sbyte4 zyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zyzz(this);
                }
                else
                {
                    return new sbyte4(z, y, z, z);
                }
            }
        }
		public readonly sbyte4 zyzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zyzw(this);
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zywx(this);
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
		public readonly sbyte4 zywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zywy(this);
                }
				else
				{
					return new sbyte4(z, y, w, y);
				}
			}
		}
		public readonly sbyte4 zywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zywz(this);
                }
				else
				{
					return new sbyte4(z, y, w, z);
				}
			}
		}
		public readonly sbyte4 zyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zyww(this);
                }
				else
				{
					return new sbyte4(z, y, w, w);
				}
			}
		}
		public readonly sbyte4 zzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zzxx(this);
                }
                else
                {
                    return new sbyte4(z, z, x, x);
                }
            }
        }
        public readonly sbyte4 zzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zzxy(this);
                }
                else
                {
                    return new sbyte4(z, z, x, y);
                }
            }
        }
        public readonly sbyte4 zzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zzxz(this);
                }
                else
                {
                    return new sbyte4(z, z, x, z);
                }
            }
        }
		public readonly sbyte4 zzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zzxw(this);
                }
				else
				{
					return new sbyte4(z, z, x, w);
				}
			}
		}
		public readonly sbyte4 zzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zzyx(this);
                }
                else
                {
                    return new sbyte4(z, z, y, x);
                }
            }
        }
        public readonly sbyte4 zzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zzyy(this);
                }
                else
                {
                    return new sbyte4(z, z, y, y);
                }
            }
        }
        public readonly sbyte4 zzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zzyz(this);
                }
                else
                {
                    return new sbyte4(z, z, y, z);
                }
            }
        }
		public readonly sbyte4 zzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zzyw(this);
                }
				else
				{
					return new sbyte4(z, z, y, w);
				}
			}
		}
		public readonly sbyte4 zzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zzzx(this);
                }
                else
                {
                    return new sbyte4(z, z, z, x);
                }
            }
        }
        public readonly sbyte4 zzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zzzy(this);
                }
                else
                {
                    return new sbyte4(z, z, z, y);
                }
            }
        }
        public readonly sbyte4 zzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zzzz(this);
                }
                else
                {
                    return new sbyte4(z, z, z, z);
                }
            }
        }
		public readonly sbyte4 zzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zzzw(this);
                }
				else
				{
					return new sbyte4(z, z, z, w);
				}
			}
		}
		public readonly sbyte4 zzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zzwx(this);
                }
				else
				{
					return new sbyte4(z, z, w, x);
				}
			}
		}
		public readonly sbyte4 zzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zzwy(this);
                }
				else
				{
					return new sbyte4(z, z, w, y);
				}
			}
		}
		public readonly sbyte4 zzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zzwz(this);
                }
				else
				{
					return new sbyte4(z, z, w, z);
				}
			}
		}
		public readonly sbyte4 zzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zzww(this);
                }
				else
				{
					return new sbyte4(z, z, w, w);
				}
			}
		}
		public readonly sbyte4 zwxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zwxx(this);
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zwxy(this);
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
		public readonly sbyte4 zwxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zwxz(this);
                }
				else
				{
					return new sbyte4(z, w, x, z);
				}
			}
		}
		public readonly sbyte4 zwxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zwxw(this);
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zwyx(this);
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
		public readonly sbyte4 zwyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zwyy(this);
                }
				else
				{
					return new sbyte4(z, w, y, y);
				}
			}
		}
		public readonly sbyte4 zwyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zwyz(this);
                }
				else
				{
					return new sbyte4(z, w, y, z);
				}
			}
		}
		public readonly sbyte4 zwyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zwyw(this);
                }
				else
				{
					return new sbyte4(z, w, y, w);
				}
			}
		}
		public readonly sbyte4 zwzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zwzx(this);
                }
				else
				{
					return new sbyte4(z, w, z, x);
				}
			}
		}
		public readonly sbyte4 zwzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zwzy(this);
                }
				else
				{
					return new sbyte4(z, w, z, y);
				}
			}
		}
		public readonly sbyte4 zwzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zwzz(this);
                }
				else
				{
					return new sbyte4(z, w, z, z);
				}
			}
		}
		public readonly sbyte4 zwzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zwzw(this);
                }
				else
				{
					return new sbyte4(z, w, z, w);
				}
			}
		}
		public readonly sbyte4 zwwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zwwx(this);
                }
				else
				{
					return new sbyte4(z, w, w, x);
				}
			}
		}
		public readonly sbyte4 zwwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zwwy(this);
                }
				else
				{
					return new sbyte4(z, w, w, y);
				}
			}
		}
		public readonly sbyte4 zwwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zwwz(this);
                }
				else
				{
					return new sbyte4(z, w, w, z);
				}
			}
		}
		public readonly sbyte4 zwww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zwww(this);
                }
				else
				{
					return new sbyte4(z, w, ww);
				}
			}
		}
		public readonly sbyte4 wxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxxx(this);
                }
				else
				{
					return new sbyte4(w, x, x, x);
				}
			}
		}
		public readonly sbyte4 wxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxxy(this);
                }
				else
				{
					return new sbyte4(w, x, x, y);
				}
			}
		}
		public readonly sbyte4 wxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxxz(this);
                }
				else
				{
					return new sbyte4(w, x, x, z);
				}
			}
		}
		public readonly sbyte4 wxxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxxw(this);
                }
				else
				{
					return new sbyte4(w, x, x, w);
				}
			}
		}
		public readonly sbyte4 wxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxyx(this);
                }
				else
				{
					return new sbyte4(w, x, y, x);
				}
			}
		}
		public readonly sbyte4 wxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxyy(this);
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxyz(this);
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
		public readonly sbyte4 wxyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxyw(this);
                }
				else
				{
					return new sbyte4(w, x, y, w);
				}
			}
		}
		public readonly sbyte4 wxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxzx(this);
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxzy(this);
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
		public readonly sbyte4 wxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxzz(this);
                }
				else
				{
					return new sbyte4(w, x, z, z);
				}
			}
		}
		public readonly sbyte4 wxzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxzw(this);
                }
				else
				{
					return new sbyte4(w, x, z, w);
				}
			}
		}
		public readonly sbyte4 wxwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxwx(this);
                }
				else
				{
					return new sbyte4(w, x, w, x);
				}
			}
		}
		public readonly sbyte4 wxwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxwy(this);
                }
				else
				{
					return new sbyte4(w, x, w, y);
				}
			}
		}
		public readonly sbyte4 wxwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxwz(this);
                }
				else
				{
					return new sbyte4(w, x, w, z);
				}
			}
		}
		public readonly sbyte4 wxww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxww(this);
                }
				else
				{
					return new sbyte4(w, x, w, w);
				}
			}
		}
		public readonly sbyte4 wyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wyxx(this);
                }
				else
				{
					return new sbyte4(w, y, x, x);
				}
			}
		}
		public readonly sbyte4 wyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wyxy(this);
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wyxz(this);
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
		public readonly sbyte4 wyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wyxw(this);
                }
				else
				{
					return new sbyte4(w, y, x, w);
				}
			}
		}
		public readonly sbyte4 wyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wyyx(this);
                }
				else
				{
					return new sbyte4(w, y, y, x);
				}
			}
		}
		public readonly sbyte4 wyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wyyy(this);
                }
				else
				{
					return new sbyte4(w, y, y, y);
				}
			}
		}
		public readonly sbyte4 wyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wyyz(this);
                }
				else
				{
					return new sbyte4(w, y, y, z);
				}
			}
		}
		public readonly sbyte4 wyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wyyw(this);
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wyzx(this);
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
		public readonly sbyte4 wyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wyzy(this);
                }
				else
				{
					return new sbyte4(w, y, z, y);
				}
			}
		}
		public readonly sbyte4 wyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wyzz(this);
                }
				else
				{
					return new sbyte4(w, y, z, z);
				}
			}
		}
		public readonly sbyte4 wyzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wyzw(this);
                }
				else
				{
					return new sbyte4(w, y, z, w);
				}
			}
		}
		public readonly sbyte4 wywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wywx(this);
                }
				else
				{
					return new sbyte4(w, y, w, x);
				}
			}
		}
		public readonly sbyte4 wywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wywy(this);
                }
				else
				{
					return new sbyte4(w, y, w, y);
				}
			}
		}
		public readonly sbyte4 wywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wywz(this);
                }
				else
				{
					return new sbyte4(w, y, w, z);
				}
			}
		}
		public readonly sbyte4 wyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wyww(this);
                }
				else
				{
					return new sbyte4(w, y, w, w);
				}
			}
		}
		public readonly sbyte4 wzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzxx(this);
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzxy(this);
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
		public readonly sbyte4 wzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzxz(this);
                }
				else
				{
					return new sbyte4(w, z, x, z);
				}
			}
		}
		public readonly sbyte4 wzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzxw(this);
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzyx(this);
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
		public readonly sbyte4 wzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzyy(this);
                }
				else
				{
					return new sbyte4(w, z, y, y);
				}
			}
		}
		public readonly sbyte4 wzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzyz(this);
                }
				else
				{
					return new sbyte4(w, z, y, z);
				}
			}
		}
		public readonly sbyte4 wzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzyw(this);
                }
				else
				{
					return new sbyte4(w, z, y, w);
				}
			}
		}
		public readonly sbyte4 wzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzzx(this);
                }
				else
				{
					return new sbyte4(w, z, z, x);
				}
			}
		}
		public readonly sbyte4 wzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzzy(this);
                }
				else
				{
					return new sbyte4(w, z, z, y);
				}
			}
		}
		public readonly sbyte4 wzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzzz(this);
                }
				else
				{
					return new sbyte4(w, z, z, z);
				}
			}
		}
		public readonly sbyte4 wzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzzw(this);
                }
				else
				{
					return new sbyte4(w, z, z, w);
				}
			}
		}
		public readonly sbyte4 wzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzwx(this);
                }
				else
				{
					return new sbyte4(w, z, w, x);
				}
			}
		}
		public readonly sbyte4 wzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzwy(this);
                }
				else
				{
					return new sbyte4(w, z, w, y);
				}
			}
		}
		public readonly sbyte4 wzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzwz(this);
                }
				else
				{
					return new sbyte4(w, z, w, z);
				}
			}
		}
		public readonly sbyte4 wzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzww(this);
                }
				else
				{
					return new sbyte4(w, z, w, w);
				}
			}
		}
		public readonly sbyte4 wwxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wwxx(this);
                }
				else
				{
					return new sbyte4(w, w, x, x);
				}
			}
		}
		public readonly sbyte4 wwxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wwxy(this);
                }
				else
				{
					return new sbyte4(w, w, x, y);
				}
			}
		}
		public readonly sbyte4 wwxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wwxz(this);
                }
				else
				{
					return new sbyte4(w, w, x, z);
				}
			}
		}
		public readonly sbyte4 wwxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wwxw(this);
                }
				else
				{
					return new sbyte4(w, w, x, w);
				}
			}
		}
		public readonly sbyte4 wwyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wwyx(this);
                }
				else
				{
					return new sbyte4(w, w, y, x);
				}
			}
		}
		public readonly sbyte4 wwyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wwyy(this);
                }
				else
				{
					return new sbyte4(w, w, y, y);
				}
			}
		}
		public readonly sbyte4 wwyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wwyz(this);
                }
				else
				{
					return new sbyte4(w, w, y, z);
				}
			}
		}
		public readonly sbyte4 wwyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wwyw(this);
                }
				else
				{
					return new sbyte4(w, w, y, w);
				}
			}
		}
		public readonly sbyte4 wwzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wwzx(this);
                }
				else
				{
					return new sbyte4(w, w, z, x);
				}
			}
		}
		public readonly sbyte4 wwzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wwzy(this);
                }
				else
				{
					return new sbyte4(w, w, z, y);
				}
			}
		}
		public readonly sbyte4 wwzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wwzz(this);
                }
				else
				{
					return new sbyte4(w, w, z, z);
				}
			}
		}
		public readonly sbyte4 wwzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wwzw(this);
                }
				else
				{
					return new sbyte4(w, w, z, w);
				}
			}
		}
		public readonly sbyte4 wwwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wwwx(this);
                }
				else
				{
					return new sbyte4(w, w, w, x);
				}
			}
		}
		public readonly sbyte4 wwwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wwwy(this);
                }
				else
				{
					return new sbyte4(w, w, w, y);
				}
			}
		}
		public readonly sbyte4 wwwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wwwz(this);
                }
				else
				{
					return new sbyte4(w, w, w, z);
				}
			}
		}
		public readonly sbyte4 wwww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wwww(this);
                }
				else
				{
					return new sbyte4(w, w, w, w);
				}
			}
		}

		public readonly sbyte3 xxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xxx(this);
                }
                else
                {
                    return new sbyte3(x, x, x);
                }
            }
        }
        public readonly sbyte3 xxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xxy(this);
                }
                else
                {
                    return new sbyte3(x, x, y);
                }
            }
        }
        public readonly sbyte3 xxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xxz(this);
                }
                else
                {
                    return new sbyte3(x, x, z);
                }
            }
        }
		public readonly sbyte3 xxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xxw(this);
                }
				else
				{
					return new sbyte3(x, x, w);
				}
			}
		}
		public readonly sbyte3 xyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xyx(this);
                }
                else
                {
                    return new sbyte3(x, y, x);
                }
            }
        }
        public readonly sbyte3 xyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xyy(this);
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xyz(this);
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
					this = Xse.blendv_si128(this, value, new sbyte4(-1, -1, -1, 0));
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xyw(this);
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
					this = Xse.blendv_si128(this, value.xyzz, new sbyte4(-1, -1, 0, -1));
				}
				else
				{
					this.x = value.x;
					this.y = value.y;
					this.w = value.z;
				}
			}
		}
		public readonly sbyte3 xzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xzx(this);
                }
                else
                {
                    return new sbyte3(x, z, x);
                }
            }
        }
        public          sbyte3 xzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xzy(this);
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
					this = Xse.blendv_si128(this, value.xzyy, new sbyte4(-1, -1, -1, 0));
				}
				else
				{
					this.x = value.x;
					this.z = value.y;
					this.y = value.z;
				}
			}
        }
        public readonly sbyte3 xzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xzz(this);
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xzw(this);
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
					this = Xse.blendv_si128(this, value.xxyz, new sbyte4(-1, 0, -1, -1));
				}
				else
				{
					this.x = value.x;
					this.z = value.y;
					this.w = value.z;
				}
			}
		}
		public readonly sbyte3 xwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xwx(this);
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xwy(this);
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
					this = Xse.blendv_si128(this, value.xzzy, new sbyte4(-1, -1, 0, -1));
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xwz(this);
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
					this = Xse.blendv_si128(this, value.xxzy, new sbyte4(-1, 0, -1, -1));
				}
				else
				{
					this.x = value.x;
					this.w = value.y;
					this.z = value.z;
				}
			}
		}
		public readonly sbyte3 xww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xww(this);
                }
				else
				{
					return new sbyte3(x, w, w);
				}
			}
		}
		public readonly sbyte3 yxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yxx(this);
                }
                else
                {
                    return new sbyte3(y, x, x);
                }
            }
        }
        public readonly sbyte3 yxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yxy(this);
                }
                else
                {
                    return new sbyte3(y, x, y);
                }
            }
        }
        public          sbyte3 yxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yxz(this);
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
					this = Xse.blendv_si128(this, value.yxzz, new sbyte4(-1, -1, -1, 0));
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yxw(this);
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
					this = Xse.blendv_si128(this, value.yxzz, new sbyte4(-1, -1, 0, -1));
				}
				else
				{
					this.y = value.x;
					this.x = value.y;
					this.w = value.z;
				}
			}
		}
		public readonly sbyte3 yyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yyx(this);
                }
                else
                {
                    return new sbyte3(y, y, x);
                }
            }
        }
        public readonly sbyte3 yyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yyy(this);
                }
                else
                {
                    return new sbyte3(y, y, y);
                }
            }
        }
        public readonly sbyte3 yyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yyz(this);
                }
                else
                {
                    return new sbyte3(y, y, z);
                }
            }
        }
		public readonly sbyte3 yyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yyw(this);
                }
				else
				{
					return new sbyte3(y, y, w);
				}
			}
		}
		public          sbyte3 yzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yzx(this);
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
					this = Xse.blendv_si128(this, value.zxyy, new sbyte4(-1, -1, -1, 0));
				}
				else
				{
					this.y = value.x;
					this.z = value.y;
					this.x = value.z;
				}
			}
        }
        public readonly sbyte3 yzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yzy(this);
                }
                else
                {
                    return new sbyte3(y, z, y);
                }
            }
        }
        public readonly sbyte3 yzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yzz(this);
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yzw(this);
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
					this = Xse.blendv_si128(this, value.xxyz, new sbyte4(0, -1, -1, -1));
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ywx(this);
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
					this = Xse.blendv_si128(this, value.zxxy, new sbyte4(-1, -1, 0, -1));
				}
				else
				{
					this.y = value.x;
					this.w = value.y;
					this.x = value.z;
				}
			}
		}
		public readonly sbyte3 ywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ywy(this);
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ywz(this);
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
					this = Xse.blendv_si128(this, value.xxzy, new sbyte4(0, -1, -1, -1));
				}
				else
				{
					this.y = value.x;
					this.w = value.y;
					this.z = value.z;
				}
			}
		}
		public readonly sbyte3 yww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yww(this);
                }
				else
				{
					return new sbyte3(y, w, w);
				}
			}
		}
		public readonly sbyte3 zxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zxx(this);
                }
                else
                {
                    return new sbyte3(z, x, x);
                }
            }
        }
        public          sbyte3 zxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zxy(this);
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
					this = Xse.blendv_si128(this, value.yzxx, new sbyte4(-1, -1, -1, 0));
				}
				else
				{
					this.z = value.x;
					this.x = value.y;
					this.y = value.z;
				}
			}
        }
        public readonly sbyte3 zxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zxz(this);
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zxw(this);
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
					this = Xse.blendv_si128(this, value.yyxz, new sbyte4(-1, 0, -1, -1));
				}
				else
				{
					this.z = value.x;
					this.x = value.y;
					this.w = value.z;
				}
			}
		}
		public          sbyte3 zyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zyx(this);
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
					this = Xse.blendv_si128(this, value.zyxx, new sbyte4(-1, -1, -1, 0));
				}
				else
				{
					this.z = value.x;
					this.y = value.y;
					this.x = value.z;
				}
			}
        }
        public readonly sbyte3 zyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zyy(this);
                }
                else
                {
                    return new sbyte3(z, y, y);
                }
            }
        }
        public readonly sbyte3 zyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zyz(this);
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zyw(this);
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
					this = Xse.blendv_si128(this, value.yyxz, new sbyte4(0, -1, -1, -1));
				}
				else
				{
					this.z = value.x;
					this.y = value.y;
					this.w = value.z;
				}
			}
		}
		public readonly sbyte3 zzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zzx(this);
                }
                else
                {
                    return new sbyte3(z, z, x);
                }
            }
        }
        public readonly sbyte3 zzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zzy(this);
                }
                else
                {
                    return new sbyte3(z, z, y);
                }
            }
        }
        public readonly sbyte3 zzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zzz(this);
                }
                else
                {
                    return new sbyte3(z, z, z);
                }
            }
        }
		public readonly sbyte3 zzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zzw(this);
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zwx(this);
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
					this = Xse.blendv_si128(this, value.zzxy, new sbyte4(-1, 0, -1, -1));
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zwy(this);
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
					this = Xse.blendv_si128(this, value.zzxy, new sbyte4(0, -1, -1, -1));
				}
				else
				{
					this.z = value.x;
					this.w = value.y;
					this.y = value.z;
				}
			}
		}
		public readonly sbyte3 zwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zwz(this);
                }
				else
				{
					return new sbyte3(z, w, z);
				}
			}
		}
		public readonly sbyte3 zww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zww(this);
                }
				else
				{
					return new sbyte3(z, w, w);
				}
			}
		}
		public readonly sbyte3 wxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxx(this);
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxy(this);
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
					this = Xse.blendv_si128(this, value.yzzx, new sbyte4(-1, -1, 0, -1));
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxz(this);
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
					this = Xse.blendv_si128(this, value.yyzx, new sbyte4(-1, 0, -1, -1));
				}
				else
				{
					this.w = value.x;
					this.x = value.y;
					this.z = value.z;
				}
			}
		}
		public readonly sbyte3 wxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxw(this);
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wyx(this);
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
					this = Xse.blendv_si128(this, value.zyyx, new sbyte4(-1, -1, 0, -1));
				}
				else
				{
					this.w = value.x;
					this.y = value.y;
					this.x = value.z;
				}
			}
		}
		public readonly sbyte3 wyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wyy(this);
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wyz(this);
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
					this = Xse.blendv_si128(this, value.yyzx, new sbyte4(0, -1, -1, -1));
				}
				else
				{
					this.w = value.x;
					this.y = value.y;
					this.z = value.z;
				}
			}
		}
		public readonly sbyte3 wyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wyw(this);
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzx(this);
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
					this = Xse.blendv_si128(this, value.zzyx, new sbyte4(-1, 0, -1, -1));
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzy(this);
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
					this = Xse.blendv_si128(this, value.zzyx, new sbyte4(0, -1, -1, -1));
				}
				else
				{
					this.w = value.x;
					this.z = value.y;
					this.y = value.z;
				}
			}
		}
		public readonly sbyte3 wzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzz(this);
                }
				else
				{
					return new sbyte3(w, z, z);
				}
			}
		}
		public readonly sbyte3 wzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzw(this);
                }
				else
				{
					return new sbyte3(w, z, w);
				}
			}
		}
		public readonly sbyte3 wwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wwx(this);
                }
				else
				{
					return new sbyte3(w, w, x);
				}
			}
		}
		public readonly sbyte3 wwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wwy(this);
                }
				else
				{
					return new sbyte3(w, w, y);
				}
			}
		}
		public readonly sbyte3 wwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wwz(this);
                }
				else
				{
					return new sbyte3(w, w, z);
				}
			}
		}
		public readonly sbyte3 www
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.www(this);
                }
				else
				{
					return new sbyte3(w, w, w);
				}
			}
		}

		public readonly sbyte2 xx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xx(this);
                }
                else
                {
                    return new sbyte2(x, x);
                }
            }
        }
        public          sbyte2 xy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xy(this);
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
					this = Xse.blend_epi16(this, value, 0b01);
				}
				else
				{
					this.x = value.x;
					this.y = value.y;
				}
			}
        }
        public          sbyte2 xz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xz(this);
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
					this = Xse.blendv_si128(this, value.xxyy, new sbyte4(-1, 0, -1, 0));
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xw(this);
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
					this = Xse.blendv_si128(this, value.xxyy, new sbyte4(-1, 0, 0, -1));
				}
				else
				{
					this.x = value.x;
					this.w = value.y;
				}
			}
		}
		public          sbyte2 yx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yx(this);
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
					this = Xse.blend_epi16(this, value.yx, 0b01);
				}
				else
				{
					this.y = value.x;
					this.x = value.y;
				}
			}
        }
        
        public readonly sbyte2 yy
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            get 
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yy(this);
                }
                else
                {
                    return new sbyte2(y, y);
                }
            }
        }
        public          sbyte2 yz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yz(this);
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
					this = Xse.blendv_si128(this, value.xxyy, new sbyte4(0, -1, -1, 0));
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yw(this);
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
					this = Xse.blendv_si128(this, value.xxyy, new sbyte4(0, -1, 0, -1));
				}
				else
				{
					this.y = value.x;
					this.w = value.y;
				}
			}
		}
		public          sbyte2 zx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zx(this);
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
					this = Xse.blendv_si128(this, value.yyxx, new sbyte4(-1, 0, -1, 0));
				}
				else
				{
					this.z = value.x;
					this.x = value.y;
				}
			}
        }
        public          sbyte2 zy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zy(this);
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
					this = Xse.blendv_si128(this, value.yyxx, new sbyte4(0, -1, -1, 0));
				}
				else
				{
					this.z = value.x;
					this.y = value.y;
				}
			}
        }
        public readonly sbyte2 zz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zz(this);
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zw(this);
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wx(this);
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
					this = Xse.blendv_si128(this, value.yyxx, new sbyte4(-1, 0, 0, -1));
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wy(this);
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
					this = Xse.blendv_si128(this, value.yyxx, new sbyte4(0, -1, 0, -1));
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
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wz(this);
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
					this = Xse.blend_epi16(this, value.yxyx, 0b10);
				}
				else
				{
					this.w = value.x;
					this.z = value.y;
				}
			}
		}
		public readonly sbyte2 ww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ww(this);
                }
				else
				{
					return new sbyte2(w, w);
				}
			}
		}
		#endregion

		
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(sbyte4 input) => RegisterConversion.ToV128(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte4(v128 input) => RegisterConversion.ToType<sbyte4>(input);

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
            if (Sse2.IsSse2Supported)
            {
                return Xse.cvtepi16_epi8(input, 4);
            }
			else
            {
                return new sbyte4((sbyte)input.x, (sbyte)input.y, (sbyte)input.z, (sbyte)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(ushort4 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cvtepi16_epi8(input, 4);
            }
			else
			{
				return new sbyte4((sbyte)input.x, (sbyte)input.y, (sbyte)input.z, (sbyte)input.w);
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(int4 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cvtepi32_epi8(RegisterConversion.ToV128(input), 4);
            }
			else
			{
				return new sbyte4((sbyte)input.x, (sbyte)input.y, (sbyte)input.z, (sbyte)input.w);
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(uint4 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cvtepi32_epi8(RegisterConversion.ToV128(input), 4);
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
                return Xse.mm256_cvtepi64_epi8(input);
            }
            else if (Ssse3.IsSsse3Supported)
            {
                return new sbyte4(Xse.cvtepi64_epi8(input._xy), Xse.cvtepi64_epi8(input._zw));
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
                return Xse.mm256_cvtepi64_epi8(input);
            }
            else if (Ssse3.IsSsse3Supported)
            {
                return new sbyte4(Xse.cvtepi64_epi8(input._xy), Xse.cvtepi64_epi8(input._zw));
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
				return Xse.cvtepi8_epi16(input);
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
				return Xse.cvtepi8_epi16(input);
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
				return RegisterConversion.ToType<int4>(Xse.cvtepi8_epi32(input));
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
				return RegisterConversion.ToType<uint4>(Xse.cvtepi8_epi32(input));
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
        public static implicit operator float4(sbyte4 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<float4>(Xse.cvtepi8_ps(input));
            }
            else
            {
                return (float4)(int4)input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4(sbyte4 input) => (double4)(int4)input;


        public sbyte this[int index]
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
                return Xse.mullo_epi8(left, right, 4);
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
                return Xse.div_epi8(left, right, false, 4);
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
                return Xse.rem_epi8(left, right, 4);
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
                    return Xse.constexpr.mullo_epi8(left, right, 4);
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
                    return Xse.constexpr.div_epi8(left, right, 4);
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
                    return Xse.constexpr.rem_epi8(left, right, 4);
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
                return Xse.neg_epi8(x);
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
                return Xse.inc_epi8(x);
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
                return Xse.dec_epi8(x);
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
                return Xse.not_si128(x);
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
                return Xse.slli_epi8(x, n);
            }
            else
            {
                return new sbyte4((sbyte)(x.x << n), (sbyte)(x.y << n), (sbyte)(x.z << n), (sbyte)(x.w << n));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator >> (sbyte4 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(n) && n == 7)
                {
                    return Sse2.cmpgt_epi8(Sse2.setzero_si128(), x);
                }
                else
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        return (sbyte4)((short4)x >> n);
                    }
                    else
                    {
                        return Xse.srai_epi8(x, n);
                    }
                }
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
                return RegisterConversion.IsTrue8<bool4>(Sse2.cmpeq_epi8(left, right));
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
                return RegisterConversion.IsTrue8<bool4>(Xse.cmplt_epi8(left, right));
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
                return RegisterConversion.IsTrue8<bool4>(Sse2.cmpgt_epi8(left, right));
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
                return RegisterConversion.IsFalse8<bool4>(Sse2.cmpeq_epi8(left, right));
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
                return RegisterConversion.IsFalse8<bool4>(Sse2.cmpgt_epi8(left, right));
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
                return RegisterConversion.IsFalse8<bool4>(Xse.cmplt_epi8(left, right));
            }
            else
            {
                return new bool4(left.x >= right.x, left.y >= right.y, left.z >= right.z, left.w >= right.w);
            }
        }


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly bool Equals(sbyte4 other)
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

        public override readonly bool Equals(object obj) => obj is sbyte4 converted && this.Equals(converted);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override readonly int GetHashCode()
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


        public override readonly string ToString() => $"sbyte4({x}, {y}, {z}, {w})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"sbyte4({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)}, {w.ToString(format, formatProvider)})";
    }
}