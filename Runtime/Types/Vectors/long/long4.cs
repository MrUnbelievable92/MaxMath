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
    [Serializable]  [StructLayout(LayoutKind.Explicit, Size = 4 * sizeof(long))]  [DebuggerTypeProxy(typeof(long4.DebuggerProxy))]
    unsafe public struct long4 : IEquatable<long4>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public long x;
            public long y;
            public long z;
            public long w;

            public DebuggerProxy(long4 v)
            {
                x = v.x;
                y = v.y;
                z = v.z;
                w = v.w;
            }
        }


        [FieldOffset(0)]  private fixed long asArray[4];

        [FieldOffset(0)]  internal long2 _xy;
        [FieldOffset(16)] internal long2 _zw;

        [FieldOffset(0)]  public long x;
        [FieldOffset(8)]  public long y;
        [FieldOffset(16)] public long z;
        [FieldOffset(24)] public long w;


        public static long4 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(long x, long y, long z, long w)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_set_epi64x(w, z, y, x);
            }
            else if (Sse2.IsSse2Supported)
            {
                this = new long4
                {
                    _xy = new long2(x, y),
                    _zw = new long2(z, w)
                };
            }
            else
            {
                this = new long4
                {
                    x = x,
                    y = y,
                    z = z,
                    w = w
                };
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(long xyzw)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_set1_epi64x(xyzw);
            }
            else if (Sse2.IsSse2Supported)
            {
                this = new long4
                {
                    _xy = new long2(xyzw),
                    _zw = new long2(xyzw)
                };
            }
            else
            {
                this = new long4
                {
                    x = xyzw,
                    y = xyzw,
                    z = xyzw,
                    w = xyzw
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(long2 xy, long z, long w)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_set_m128i(new long2(z, w), xy);
            }
            else if (Sse2.IsSse2Supported)
            {
                this = new long4
                {
                    _xy = xy,
                    _zw = new long2(z, w)
                };
            }
            else
            {
                this = new long4
                {
                    x = xy.x,
                    y = xy.y,
                    z = z,
                    w = w
                };
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(long x, long2 yz, long w)
        {
            if (Avx.IsAvxSupported)
            {
                v256 shuf = yz.xxyy;
                shuf.SLong0 = x;
                shuf.SLong3 = w;

                this = shuf;
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 lo = Sse2.shuffle_epi32(yz, Sse.SHUFFLE(1, 0, 1, 0));
                lo.SLong0 = x;

                v128 hi = Sse2.shuffle_epi32(yz, Sse.SHUFFLE(3, 2, 3, 2));
                hi.SLong1 = w;

                this = new long4
                {
                    _xy = lo,
                    _zw = hi
                };
            }
            else
            {
                this = new long4
                {
                    x = x,
                    y = yz.x,
                    z = yz.y,
                    w = w
                };
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(long x, long y, long2 zw)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_set_m128i(zw, new long2(x, y));
            }
            else if (Sse2.IsSse2Supported)
            {
                this = new long4
                {
                    _xy = new long2(x, y),
                    _zw = zw
                };
            }
            else
            {
                this = new long4
                {
                    x = x,
                    y = y,
                    z = zw.x,
                    w = zw.y,
                };
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(long2 xy, long2 zw)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_set_m128i(zw, xy);
            }
            else if (Sse2.IsSse2Supported)
            {
                this = new long4
                {
                    _xy = xy,
                    _zw = zw
                };
            }
            else
            {
                this = new long4
                {
                    x = xy.x,
                    y = xy.y,
                    z = zw.x,
                    w = zw.y
                };
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(long3 xyz, long w)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_insert_epi64(xyz, w, 3);
            }
            else if (Sse2.IsSse2Supported)
            {
                this = new long4
                {
                    _xy = xyz._xy,
                    _zw = new long2(xyz.z, w)
                };
            }
            else
            {
                this = new long4
                {
                    x = xyz.x,
                    y = xyz.y,
                    z = xyz.z,
                    w = w
                };
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(long x, long3 yzw)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_insert_epi64(yzw.xxyz, x, 0);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 lo = Sse2.shuffle_epi32(yzw._xy, Sse.SHUFFLE(1, 0, 1, 0));
                lo.SLong0 = x;
                long2 hi = yzw.yz;

                this = new long4
                {
                    _xy = lo,
                    _zw = hi
                };
            }
            else
            {
                this = new long4
                {
                    x = x,
                    y = yzw.x,
                    z = yzw.y,
                    w = yzw.z
                };
            }
        }


        #region Shuffle
        public  long4 xxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_broadcastq_epi64(Avx.mm256_castsi256_si128(this));
				}
				else
				{
					return new long4(xx, xx);
				}
			}
		}
		public  long4 xxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 0, 0));
				}
				else
				{
					return new long4(xx, xy);
				}
			}
		}
		public  long4 xxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 0, 0));
				}
				else
				{
					return new long4(xx, xz);
				}
			}
		}
		public  long4 xxxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 0, 0));
				}
				else
				{
					return new long4(xx, xw);
				}
			}
		}
		public  long4 xxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 0, 0));
				}
				else
				{
					return new long4(xx, yx);
				}
			}
		}
		public  long4 xxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 0, 0));
				}
				else
				{
					return new long4(xx, yy);
				}
			}
		}
		public  long4 xxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 0, 0));
				}
				else
				{
					return new long4(xx, yz);
				}
			}
		}
		public  long4 xxyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 0));
				}
				else
				{
					return new long4(xx, yw);
				}
			}
		}
		public  long4 xxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 0, 0));
				}
				else
				{
					return new long4(xx, zx);
				}
			}
		}
		public  long4 xxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 0, 0));
				}
				else
				{
					return new long4(xx, zy);
				}
			}
		}
		public  long4 xxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(1, 0, 1, 0));
				}
				else
				{
					return new long4(xx, zz);
				}
			}
		}
		public  long4 xxzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 0, 0));
				}
				else
				{
					return new long4(xx, zw);
				}
			}
		}
		public  long4 xxwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 0, 0));
				}
				else
				{
					return new long4(xx, wx);
				}
			}
		}
		public  long4 xxwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 0, 0));
				}
				else
				{
					return new long4(xx, wy);
				}
			}
		}
		public  long4 xxwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 0, 0));
				}
				else
				{
					return new long4(xx, wz);
				}
			}
		}
		public  long4 xxww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 0));
				}
				else
				{
					return new long4(xx, ww);
				}
			}
		}
		public  long4 xyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 1, 0));
				}
				else
				{
					return new long4(xy, xx);
				}
			}
		}
		public  long4 xyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 1, 0));
				}
				else
				{
					return new long4(xy, xy);
				}
			}
		}
		public  long4 xyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 1, 0));
				}
				else
				{
					return new long4(xy, xz);
				}
			}
		}
		public  long4 xyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 1, 0));
				}
				else
				{
					return new long4(xy, xw);
				}
			}
		}
		public  long4 xyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 1, 0));
				}
				else
				{
					return new long4(xy, yx);
				}
			}
		}
		public  long4 xyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 1, 0));
				}
				else
				{
					return new long4(xy, yy);
				}
			}
		}
		public  long4 xyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 1, 0));
				}
				else
				{
					return new long4(xy, yz);
				}
			}
		}
		public  long4 xyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 0));
				}
				else
				{
					return new long4(xy, yw);
				}
			}
		}
		public  long4 xyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 1, 0));
				}
				else
				{
					return new long4(xy, zx);
				}
			}
		}
		public  long4 xyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 1, 0));
				}
				else
				{
					return new long4(xy, zy);
				}
			}
		}
		public  long4 xyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 1, 0));
				}
				else
				{
					return new long4(xy, zz);
				}
			}
		}
		public  long4 xywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 1, 0));
				}
				else
				{
					return new long4(xy, wx);
				}
			}
		}
		public  long4 xywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 1, 0));
				}
				else
				{
					return new long4(xy, wy);
				}
			}
		}
		public			long4 xywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 1, 0));
				}
				else
				{
					return new long4(xy, wz);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xywz;
			}
		}
		public  long4 xyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 1, 0));
				}
				else
				{
					return new long4(xy, ww);
				}
			}
		}
		public  long4 xzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 0));
				}
				else
				{
					return new long4(xz, xx);
				}
			}
		}
		public  long4 xzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 2, 0));
				}
				else
				{
					return new long4(xz, xy);
				}
			}
		}
		public  long4 xzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 2, 0));
				}
				else
				{
					return new long4(xz, xz);
				}
			}
		}
		public  long4 xzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 0));
				}
				else
				{
					return new long4(xz, xw);
				}
			}
		}
		public  long4 xzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 2, 0));
				}
				else
				{
					return new long4(xz, yx);
				}
			}
		}
		public  long4 xzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 2, 0));
				}
				else
				{
					return new long4(xz, yy);
				}
			}
		}
		public  long4 xzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 2, 0));
				}
				else
				{
					return new long4(xz, yz);
				}
			}
		}
		public			long4 xzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 0));
				}
				else
				{
					return new long4(xz, yw);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xzyw;
			}
		}
		public  long4 xzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 2, 0));
				}
				else
				{
					return new long4(xz, zx);
				}
			}
		}
		public  long4 xzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 2, 0));
				}
				else
				{
					return new long4(xz, zy);
				}
			}
		}
		public  long4 xzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 2, 0));
				}
				else
				{
					return new long4(xz, zz);
				}
			}
		}
		public  long4 xzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 0));
				}
				else
				{
					return new long4(xz, zw);
				}
			}
		}
		public  long4 xzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 2, 0)); ;
				}
				else
				{
					return new long4(xz, wx);
				}
			}
		}
		public			long4 xzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 2, 0));
				}
				else
				{
					return new long4(xz, wy);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xwyz;
			}
		}
		public  long4 xzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 2, 0));
				}
				else
				{
					return new long4(xz, wz);
				}
			}
		}
		public  long4 xzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 0));
				}
				else
				{
					return new long4(xz, ww);
				}
			}
		}
		public  long4 xwxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 3, 0));
				}
				else
				{
					return new long4(xw, xx);
				}
			}
		}
		public  long4 xwxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 3, 0));
				}
				else
				{
					return new long4(xw, xy);
				}
			}
		}
		public  long4 xwxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 3, 0));
				}
				else
				{
					return new long4(xw, xz);
				}
			}
		}
		public  long4 xwxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 3, 0));
				}
				else
				{
					return new long4(xw, xw);
				}
			}
		}
		public  long4 xwyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 3, 0));
				}
				else
				{
					return new long4(xw, yx);
				}
			}
		}
		public  long4 xwyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 3, 0));
				}
				else
				{
					return new long4(xw, yy);
				}
			}
		}
		public			long4 xwyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 3, 0));
				}
				else
				{
					return new long4(xw, yz);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xzwy;
			}
		}
		public  long4 xwyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 3, 0));
				}
				else
				{
					return new long4(xw, yw);
				}
			}
		}
		public  long4 xwzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 3, 0));
				}
				else
				{
					return new long4(xw, zx);
				}
			}
		}
		public			long4 xwzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 3, 0));
				}
				else
				{
					return new long4(xw, zy);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xwzy;
			}
		}
		public  long4 xwzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 3, 0));
				}
				else
				{
					return new long4(xw, zz);
				}
			}
		}
		public  long4 xwzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 3, 0));
				}
				else
				{
					return new long4(xw, zw);
				}
			}
		}
		public  long4 xwwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 3, 0));
				}
				else
				{
					return new long4(xw, wx);
				}
			}
		}
		public  long4 xwwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 3, 0));
				}
				else
				{
					return new long4(xw, wy);
				}
			}
		}
		public  long4 xwwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 3, 0));
				}
				else
				{
					return new long4(xw, wz);
				}
			}
		}
		public  long4 xwww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 0));
				}
				else
				{
					return new long4(xw, ww);
				}
			}
		}
		public  long4 yxxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 0, 1));
				}
				else
				{
					return new long4(yx, xx);
				}
			}
		}
        public  long4 yxxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 0, 1));
				}
				else
				{
					return new long4(yx, xy);
				}
			}
		}
        public  long4 yxxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 0, 1));
				}
				else
				{
					return new long4(yx, xz);
				}
			}
		}
        public  long4 yxxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 0, 1));
				}
				else
				{
					return new long4(yx, xw);
				}
			}
		}
        public  long4 yxyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 0, 1));
				}
				else
				{
					return new long4(yx, yx);
				}
			}
		}
        public  long4 yxyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 0, 1));
				}
				else
				{
					return new long4(yx, yy);
				}
			}
		}
        public  long4 yxyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 0, 1));
				}
				else
				{
					return new long4(yx, yz);
				}
			}
		}
        public  long4 yxyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 1));
				}
				else
				{
					return new long4(yx, yw);
				}
			}
		}
        public  long4 yxzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 0, 1));
				}
				else
				{
					return new long4(yx, zx);
				}
			}
		}
        public  long4 yxzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 0, 1));
				}
				else
				{
					return new long4(yx, zy);
				}
			}
		}
        public  long4 yxzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 0, 1));
				}
				else
				{
					return new long4(yx, zz);
				}
			}
		}
        public			long4 yxzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 0, 1));
				}
				else
				{
					return new long4(yx, zw);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.yxzw;
			}
		}
        public  long4 yxwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 0, 1));
				}
				else
				{
					return new long4(yx, wx);
				}
			}
		}
        public  long4 yxwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 0, 1));
				}
				else
				{
					return new long4(yx, wy);
				}
			}
		}
        public			long4 yxwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(1, 0, 3, 2));
				}
				else
				{
					return new long4(yx, wz);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.yxwz;
			}
		}
        public  long4 yxww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 1));
				}
				else
				{
					return new long4(yx, ww);
				}
			}
		}
        public  long4 yyxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 1, 1));
				}
				else
				{
					return new long4(yy, xx);
				}
			}
		}
        public  long4 yyxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 1, 1));
				}
				else
				{
					return new long4(yy, xy);
				}
			}
		}
        public  long4 yyxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 1, 1));
				}
				else
				{
					return new long4(yy, xz);
				}
			}
		}
        public  long4 yyxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 1, 1));
				}
				else
				{
					return new long4(yy, xw);
				}
			}
		}
        public  long4 yyyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 1, 1));
				}
				else
				{
					return new long4(yy, yx);
				}
			}
		}
        public  long4 yyyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 1, 1));
				}
				else
				{
					return new long4(yy, yy);
				}
			}
		}
        public  long4 yyyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 1, 1));
				}
				else
				{
					return new long4(yy, yz);
				}
			}
		}
        public  long4 yyyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 1));
				}
				else
				{
					return new long4(yy, yw);
				}
			}
		}
        public  long4 yyzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 1, 1));
				}
				else
				{
					return new long4(yy, zx);
				}
			}
		}
        public  long4 yyzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 1, 1));
				}
				else
				{
					return new long4(yy, zy);
				}
			}
		}
        public  long4 yyzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 1, 1));
				}
				else
				{
					return new long4(yy, zz);
				}
			}
		}
        public  long4 yyzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 1, 1));
				}
				else
				{
					return new long4(yy, zw);
				}
			}
		}
        public  long4 yywx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 1, 1));
				}
				else
				{
					return new long4(yy, wx);
				}
			}
		}
        public  long4 yywy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 1, 1));
				}
				else
				{
					return new long4(yy, wy);
				}
			}
		}
        public  long4 yywz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 1, 1));
				}
				else
				{
					return new long4(yy, wz);
				}
			}
		}
        public  long4 yyww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(3, 2, 3, 2));
				}
				else
				{
					return new long4(yy, ww);
				}
			}
		}
        public  long4 yzxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 1));
				}
				else
				{
					return new long4(yz, xx);
				}
			}
		}
        public  long4 yzxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 2, 1));
				}
				else
				{
					return new long4(yz, xy);
				}
			}
		}
        public  long4 yzxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 2, 1));
				}
				else
				{
					return new long4(yz, xz);
				}
			}
		}
        public			long4 yzxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 1));
				}
				else
				{
					return new long4(yz, xw);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zxyw;
			}
		}
        public  long4 yzyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 2, 1));
				}
				else
				{
					return new long4(yz, yx);
				}
			}
		}
        public  long4 yzyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 2, 1));
				}
				else
				{
					return new long4(yz, yy);
				}
			}
		}
        public  long4 yzyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 2, 1));
				}
				else
				{
					return new long4(yz, yz);
				}
			}
		}
        public  long4 yzyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 1));
				}
				else
				{
					return new long4(yz, yw);
				}
			}
		}
        public  long4 yzzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 2, 1));
				}
				else
				{
					return new long4(yz, zx);
				}
			}
		}
        public  long4 yzzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 2, 1));
				}
				else
				{
					return new long4(yz, zy);
				}
			}
		}
        public  long4 yzzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 2, 1));
				}
				else
				{
					return new long4(yz, zz);
				}
			}
		}
        public  long4 yzzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 1));
				}
				else
				{
					return new long4(yz, zw);
				}
			}
		}
        public			long4 yzwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 2, 1)); ;
				}
				else
				{
					return new long4(yz, wx);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wxyz;
			}
		}
        public  long4 yzwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 2, 1));
				}
				else
				{
					return new long4(yz, wy);
				}
			}
		}
        public  long4 yzwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 2, 1));
				}
				else
				{
					return new long4(yz, wz);
				}
			}
		}
        public  long4 yzww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 1));
				}
				else
				{
					return new long4(yz, ww);
				}
			}
		}
        public  long4 ywxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 3, 1));
				}
				else
				{
					return new long4(yw, xx);
				}
			}
		}
        public  long4 ywxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 3, 1));
				}
				else
				{
					return new long4(yw, xy);
				}
			}
		}
        public			long4 ywxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 3, 1));
				}
				else
				{
					return new long4(yw, xz);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zxwy;
			}
		}
        public  long4 ywxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 3, 1));
				}
				else
				{
					return new long4(yw, xw);
				}
			}
		}
        public  long4 ywyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 3, 1));
				}
				else
				{
					return new long4(yw, yx);
				}
			}
		}
        public  long4 ywyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 3, 1));
				}
				else
				{
					return new long4(yw, yy);
				}
			}
		}
        public  long4 ywyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 3, 1));
				}
				else
				{
					return new long4(yw, yz);
				}
			}
		}
        public  long4 ywyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 3, 1));
				}
				else
				{
					return new long4(yw, yw);
				}
			}
		}
        public			long4 ywzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 3, 1));
				}
				else
				{
					return new long4(yw, zx);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wxzy;
			}
		}
        public  long4 ywzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 3, 1));
				}
				else
				{
					return new long4(yw, zy);
				}
			}
		}
        public  long4 ywzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 3, 1));
				}
				else
				{
					return new long4(yw, zz);
				}
			}
		}
        public  long4 ywzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 3, 1));
				}
				else
				{
					return new long4(yw, zw);
				}
			}
		}
        public  long4 ywwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 3, 1));
				}
				else
				{
					return new long4(yw, wx);
				}
			}
		}
        public  long4 ywwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 3, 1));
				}
				else
				{
					return new long4(yw, wy);
				}
			}
		}
        public  long4 ywwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 3, 1));
				}
				else
				{
					return new long4(yw, wz);
				}
			}
		}
        public  long4 ywww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 1));
				}
				else
				{
					return new long4(yw, ww);
				}
			}
		}
        public  long4 zxxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 0, 2));
				}
				else
				{
					return new long4(zx, xx);
				}
			}
		}
        public  long4 zxxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 0, 2));
				}
				else
				{
					return new long4(zx, xy);
				}
			}
		}
        public  long4 zxxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 0, 2));
				}
				else
				{
					return new long4(zx, xz);
				}
			}
		}
        public  long4 zxxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 0, 2));
				}
				else
				{
					return new long4(zx, xw);
				}
			}
		}
        public  long4 zxyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 0, 2));
				}
				else
				{
					return new long4(zx, yx);
				}
			}
		}
        public  long4 zxyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 0, 2));
				}
				else
				{
					return new long4(zx, yy);
				}
			}
		}
		public  long4 zxyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 0, 2));
				}
				else
				{
					return new long4(zx, yz);
				}
			}
		}
        public			long4 zxyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 2));
				}
				else
				{
					return new long4(zx, yw);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.yzxw;
			}
		}
        public  long4 zxzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 0, 2));
				}
				else
				{
					return new long4(zx, zx);
				}
			}
		}
        public  long4 zxzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 0, 2));
				}
				else
				{
					return new long4(zx, zy);
				}
			}
		}
        public  long4 zxzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 0, 2));
				}
				else
				{
					return new long4(zx, zz);
				}
			}
		}
        public  long4 zxzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 0, 2));
				}
				else
				{
					return new long4(zx, zw);
				}
			}
		}
        public  long4 zxwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 0, 2));
				}
				else
				{
					return new long4(zx, wx);
				}
			}
		}
        public			long4 zxwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 0, 2));
				}
				else
				{
					return new long4(zx, wy);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.ywxz;
			}
		}
        public  long4 zxwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 0, 2));
				}
				else
				{
					return new long4(zx, wz);
				}
			}
		}
        public  long4 zxww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 2));
				}
				else
				{
					return new long4(zx, ww);
				}
			}
		}
        public  long4 zyxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 1, 2));
				}
				else
				{
					return new long4(zy, xx);
				}
			}
		}
        public  long4 zyxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 1, 2));
				}
				else
				{
					return new long4(zy, xy);
				}
			}
		}
        public  long4 zyxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 1, 2));
				}
				else
				{
					return new long4(zy, xz);
				}
			}
		}
        public			long4 zyxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 1, 2));
				}
				else
				{
					return new long4(zy, xw);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zyxw;
			}
		}
        public  long4 zyyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 1, 2));
				}
				else
				{
					return new long4(zy, yx);
				}
			}
		}
        public  long4 zyyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 1, 2));
				}
				else
				{
					return new long4(zy, yy);
				}
			}
		}
        public  long4 zyyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 1, 2));
				}
				else
				{
					return new long4(zy, yz);
				}
			}
		}
        public  long4 zyyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 2));
				}
				else
				{
					return new long4(zy, yw);
				}
			}
		}
        public  long4 zyzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 1, 2));
				}
				else
				{
					return new long4(zy, zx);
				}
			}
		}
        public  long4 zyzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 1, 2));
				}
				else
				{
					return new long4(zy, zy);
				}
			}
		}
        public  long4 zyzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 1, 2));
				}
				else
				{
					return new long4(zy, zz);
				}
			}
		}
        public  long4 zyzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 1, 2));
				}
				else
				{
					return new long4(zy, zw);
				}
			}
		}
        public			long4 zywx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 1, 2));
				}
				else
				{
					return new long4(zy, wx);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wyxz;
			}
		}
        public  long4 zywy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 1, 2));
				}
				else
				{
					return new long4(zy, wy);
				}
			}
		}
        public  long4 zywz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 1, 2));
				}
				else
				{
					return new long4(zy, wz);
				}
			}
		}
        public  long4 zyww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 1, 2));
				}
				else
				{
					return new long4(zy, ww);
				}
			}
		}
        public  long4 zzxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 2));
				}
				else
				{
					return new long4(zz, xx);
				}
			}
		}
        public  long4 zzxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 2, 2));
				}
				else
				{
					return new long4(zz, xy);
				}
			}
		}
        public  long4 zzxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 2, 2));
				}
				else
				{
					return new long4(zz, xz);
				}
			}
		}
        public  long4 zzxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 2));
				}
				else
				{
					return new long4(zz, xw);
				}
			}
		}
        public  long4 zzyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 2, 2));
				}
				else
				{
					return new long4(zz, yx);
				}
			}
		}
        public  long4 zzyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 2, 2));
				}
				else
				{
					return new long4(zz, yy);
				}
			}
		}
        public  long4 zzyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 2, 2));
				}
				else
				{
					return new long4(zz, yz);
				}
			}
		}
        public  long4 zzyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 2));
				}
				else
				{
					return new long4(zz, yw);
				}
			}
		}
        public  long4 zzzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 2, 2));
				}
				else
				{
					return new long4(zz, zx);
				}
			}
		}
        public  long4 zzzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 2, 2));
				}
				else
				{
					return new long4(zz, zy);
				}
			}
		}
        public  long4 zzzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 2, 2));
				}
				else
				{
					return new long4(zz, zz);
				}
			}
		}
        public  long4 zzzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 2));
				}
				else
				{
					return new long4(zz, zw);
				}
			}
		}
        public  long4 zzwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 2, 2)); ;
				}
				else
				{
					return new long4(zz, wx);
				}
			}
		}
        public  long4 zzwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 2, 2));
				}
				else
				{
					return new long4(zz, wy);
				}
			}
		}
        public  long4 zzwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 2, 2));
				}
				else
				{
					return new long4(zz, wz);
				}
			}
		}
        public  long4 zzww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 2));
				}
				else
				{
					return new long4(zz, ww);
				}
			}
		}
        public  long4 zwxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 3, 2));
				}
				else
				{
					return new long4(zw, xx);
				}
			}
		}
        public			long4 zwxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 3, 2));
				}
				else
				{
					return new long4(zw, xy);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zwxy;
			}
		}
        public  long4 zwxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 3, 2));
				}
				else
				{
					return new long4(zw, xz);
				}
			}
		}
        public  long4 zwxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 3, 2));
				}
				else
				{
					return new long4(zw, xw);
				}
			}
		}
        public			long4 zwyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 3, 2));
				}
				else
				{
					return new long4(zw, yx);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wzxy;
			}
		}
        public  long4 zwyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 3, 2));
				}
				else
				{
					return new long4(zw, yy);
				}
			}
		}
        public  long4 zwyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 3, 2));
				}
				else
				{
					return new long4(zw, yz);
				}
			}
		}
        public  long4 zwyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 3, 2));
				}
				else
				{
					return new long4(zw, yw);
				}
			}
		}
        public  long4 zwzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 3, 2));
				}
				else
				{
					return new long4(zw, zx);
				}
			}
		}
        public  long4 zwzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 3, 2));
				}
				else
				{
					return new long4(zw, zy);
				}
			}
		}
        public  long4 zwzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 3, 2));
				}
				else
				{
					return new long4(zw, zz);
				}
			}
		}
        public  long4 zwzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 3, 2));
				}
				else
				{
					return new long4(zw, zw);
				}
			}
		}
        public  long4 zwwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 3, 2));
				}
				else
				{
					return new long4(zw, wx);
				}
			}
		}
        public  long4 zwwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 3, 2));
				}
				else
				{
					return new long4(zw, wy);
				}
			}
		}
        public  long4 zwwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 3, 2));
				}
				else
				{
					return new long4(zw, wz);
				}
			}
		}
        public  long4 zwww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 2));
				}
				else
				{
					return new long4(zw, ww);
				}
			}
		}
        public  long4 wxxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 0, 3));
				}
				else
				{
					return new long4(wx, xx);
				}
			}
		}
        public  long4 wxxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 0, 3));
				}
				else
				{
					return new long4(wx, xy);
				}
			}
		}
        public  long4 wxxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 0, 3));
				}
				else
				{
					return new long4(wx, xz);
				}
			}
		}
        public  long4 wxxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 0, 3));
				}
				else
				{
					return new long4(wx, xw);
				}
			}
		}
        public  long4 wxyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 0, 3));
				}
				else
				{
					return new long4(wx, yx);
				}
			}
		}
        public  long4 wxyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 0, 3));
				}
				else
				{
					return new long4(wx, yy);
				}
			}
		}
        public          long4 wxyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 0, 3));
				}
				else
				{
					return new long4(wx, yz);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.yzwx;
			}
		}
        public  long4 wxyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 3));
				}
				else
				{
					return new long4(wx, yw);
				}
			}
		}
        public  long4 wxzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 0, 3));
				}
				else
				{
					return new long4(wx, zx);
				}
			}
		}
        public          long4 wxzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 0, 3));
				}
				else
				{
					return new long4(wx, zy);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.ywzx;
			}
		}
        public  long4 wxzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 0, 3));
				}
				else
				{
					return new long4(wx, zz);
				}
			}
		}
        public  long4 wxzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 0, 3));
				}
				else
				{
					return new long4(wx, zw);
				}
			}
		}
        public  long4 wxwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 0, 3));
				}
				else
				{
					return new long4(wx, wx);
				}
			}
		}
        public  long4 wxwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 0, 3));
				}
				else
				{
					return new long4(wx, wy);
				}
			}
		}
        public  long4 wxwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 0, 3));
				}
				else
				{
					return new long4(wx, wz);
				}
			}
		}
        public  long4 wxww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 3));
				}
				else
				{
					return new long4(wx, ww);
				}
			}
		}
        public  long4 wyxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 1, 3));
				}
				else
				{
					return new long4(wy, xx);
				}
			}
		}
        public  long4 wyxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 1, 3));
				}
				else
				{
					return new long4(wy, xy);
				}
			}
		}
        public          long4 wyxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 1, 3));
				}
				else
				{
					return new long4(wy, xz);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zywx;
			}
		}
        public  long4 wyxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 1, 3));
				}
				else
				{
					return new long4(wy, xw);
				}
			}
		}
        public  long4 wyyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 1, 3));
				}
				else
				{
					return new long4(wy, yx);
				}
			}
		}
        public  long4 wyyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 1, 3));
				}
				else
				{
					return new long4(wy, yy);
				}
			}
		}
        public  long4 wyyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 1, 3));
				}
				else
				{
					return new long4(wy, yz);
				}
			}
		}
        public  long4 wyyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 3));
				}
				else
				{
					return new long4(wy, yw);
				}
			}
		}
        public          long4 wyzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 1, 3));
				}
				else
				{
					return new long4(wy, zx);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wyzx;
			}
		}
        public  long4 wyzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 1, 3));
				}
				else
				{
					return new long4(wy, zy);
				}
			}
		}
        public  long4 wyzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 1, 3));
				}
				else
				{
					return new long4(wy, zz);
				}
			}
		}
        public  long4 wyzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 1, 3));
				}
				else
				{
					return new long4(wy, zw);
				}
			}
		}
        public  long4 wywx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 1, 3));
				}
				else
				{
					return new long4(wy, wx);
				}
			}
		}
        public  long4 wywy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 1, 3));
				}
				else
				{
					return new long4(wy, wy);
				}
			}
		}
        public  long4 wywz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 1, 3));
				}
				else
				{
					return new long4(wy, wz);
				}
			}
		}
        public  long4 wyww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 1, 3));
				}
				else
				{
					return new long4(wy, ww);
				}
			}
		}
        public  long4 wzxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 3));
				}
				else
				{
					return new long4(wz, xx);
				}
			}
		}
        public          long4 wzxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 2, 3));
				}
				else
				{
					return new long4(wz, xy);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zwyx;
			}
		}
        public  long4 wzxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 2, 3));
				}
				else
				{
					return new long4(wz, xz);
				}
			}
		}
        public  long4 wzxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 3));
				}
				else
				{
					return new long4(wz, xw);
				}
			}
		}
        public          long4 wzyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 2, 3));
				}
				else
				{
					return new long4(wz, yx);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wzyx;
			}
		}
        public  long4 wzyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 2, 3));
				}
				else
				{
					return new long4(wz, yy);
				}
			}
		}
        public  long4 wzyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 2, 3));
				}
				else
				{
					return new long4(wz, yz);
				}
			}
		}
        public  long4 wzyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 3));
				}
				else
				{
					return new long4(wz, yw);
				}
			}
		}
        public  long4 wzzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 2, 3));
				}
				else
				{
					return new long4(wz, zx);
				}
			}
		}
        public  long4 wzzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 2, 3));
				}
				else
				{
					return new long4(wz, zy);
				}
			}
		}
        public  long4 wzzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 2, 3));
				}
				else
				{
					return new long4(wz, zz);
				}
			}
		}
        public  long4 wzzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 3));
				}
				else
				{
					return new long4(wz, zw);
				}
			}
		}
        public  long4 wzwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 2, 3)); ;
				}
				else
				{
					return new long4(wz, wx);
				}
			}
		}
        public  long4 wzwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 2, 3));
				}
				else
				{
					return new long4(wz, wy);
				}
			}
		}
        public  long4 wzwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 2, 3));
				}
				else
				{
					return new long4(wz, wz);
				}
			}
		}
        public  long4 wzww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 3));
				}
				else
				{
					return new long4(wz, ww);
				}
			}
		}
        public  long4 wwxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 3, 3));
				}
				else
				{
					return new long4(ww, xx);
				}
			}
		}
        public  long4 wwxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 3, 3));
				}
				else
				{
					return new long4(ww, xy);
				}
			}
		}
        public  long4 wwxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 3, 3));
				}
				else
				{
					return new long4(ww, xz);
				}
			}
		}
        public  long4 wwxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 3, 3));
				}
				else
				{
					return new long4(ww, xw);
				}
			}
		}
        public  long4 wwyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 3, 3));
				}
				else
				{
					return new long4(ww, yx);
				}
			}
		}
        public  long4 wwyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 3, 3));
				}
				else
				{
					return new long4(ww, yy);
				}
			}
		}
        public  long4 wwyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 3, 3));
				}
				else
				{
					return new long4(ww, yz);
				}
			}
		}
        public  long4 wwyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 3, 3));
				}
				else
				{
					return new long4(ww, yw);
				}
			}
		}
        public  long4 wwzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 3, 3));
				}
				else
				{
					return new long4(ww, zx);
				}
			}
		}
        public  long4 wwzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 3, 3));
				}
				else
				{
					return new long4(ww, zy);
				}
			}
		}
        public  long4 wwzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 3, 3));
				}
				else
				{
					return new long4(ww, zz);
				}
			}
		}
        public  long4 wwzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 3, 3));
				}
				else
				{
					return new long4(ww, zw);
				}
			}
		}
        public  long4 wwwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 3, 3));
				}
				else
				{
					return new long4(ww, wx);
				}
			}
		}
        public  long4 wwwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 3, 3));
				}
				else
				{
					return new long4(ww, wy);
				}
			}
		}
        public  long4 wwwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 3, 3));
				}
				else
				{
					return new long4(ww, wz);
				}
			}
		}
        public  long4 wwww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 3));
				}
				else
				{
					return new long4(ww, ww);
				}
			}
		}

        public  long3 xxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_broadcastq_epi64(Avx.mm256_castsi256_si128(this));
				}
				else
				{
					return new long3(xx, x);
				}
			}
		}
        public  long3 xxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 0));
				}
				else
				{
					return new long3(xx, y);
				}
			}
		}
        public  long3 xxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(1, 0, 1, 0));
				}
				else
				{
					return new long3(xx, z);
				}
			}
		}
        public  long3 xxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 0));
				}
				else
				{
					return new long3(xx, w);
				}
			}
		}
        public  long3 xyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 1, 0));
				}
				else
				{
					return new long3(xy, x);
				}
			}
		}
        public  long3 xyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 0));
				}
				else
				{
					return new long3(xy, y);
				}
			}
		}
        public          long3 xyz
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return (v256)this;
				}
				else
				{
					return new long3(xy, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value, 0b0011_1111);
				}
				else
				{
					this.x = value.x;
					this.y = value.y;
					this.z = value.z;
				}
			}
		}
        public          long3 xyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 1, 0));
				}
				else
				{
					return new long3(xy, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.xyzz, 0b1100_1111);
				}
				else
				{
					this.x = value.x;
					this.y = value.y;
					this.w = value.z;
				}
			}
		}
        public  long3 xzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 0));
				}
				else
				{
					return new long3(xz, x);
				}
			}
		}
        public          long3 xzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 0));
				}
				else
				{
					return new long3(xz, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.xzyy, 0b0011_1111);
				}
				else
				{
					this.x = value.x;
					this.z = value.y;
					this.y = value.z;
				}
			}
		}
        public  long3 xzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 0));
				}
				else
				{
					return new long3(xz, z);
				}
			}
		}
        public          long3 xzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 0));
				}
				else
				{
					return new long3(xz, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.xxyz, 0b1111_0011);
				}
				else
				{
					this.x = value.x;
					this.z = value.y;
					this.w = value.z;
				}
			}
		}
        public  long3 xwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 3, 0));
				}
				else
				{
					return new long3(xw, x);
				}
			}
		}
        public          long3 xwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 3, 0));
				}
				else
				{
					return new long3(xw, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.xzzy, 0b1100_1111);
				}
				else
				{
					this.x = value.x;
					this.w = value.y;
					this.y = value.z;
				}
			}
		}
        public          long3 xwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 3, 0));
				}
				else
				{
					return new long3(xw, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.xxzy, 0b1111_0011);
				}
				else
				{
					this.x = value.x;
					this.w = value.y;
					this.z = value.z;
				}
			}
		}
        public  long3 xww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 0));
				}
				else
				{
					return new long3(xw, w);
				}
			}
		}
        public  long3 yxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 0, 1));
				}
				else
				{
					return new long3(yx, x);
				}
			}
		}
        public  long3 yxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 1));
				}
				else
				{
					return new long3(yx, y);
				}
			}
		}
        public          long3 yxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 0, 1));
				}
				else
				{
					return new long3(yx, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.yxzz, 0b0011_1111);
				}
				else
				{
					this.y = value.x;
					this.x = value.y;
					this.z = value.z;
				}
			}
		}
        public          long3 yxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(1, 0, 3, 2));
				}
				else
				{
					return new long3(yx, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.yxzz, 0b1100_1111);
				}
				else
				{
					this.y = value.x;
					this.x = value.y;
					this.w = value.z;
				}
			}
		}
        public  long3 yyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 1, 1));
				}
				else
				{
					return new long3(yy, x);
				}
			}
		}
        public  long3 yyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 1));
				}
				else
				{
					return new long3(yy, y);
				}
			}
		}
        public  long3 yyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 1, 1));
				}
				else
				{
					return new long3(yy, z);
				}
			}
		}
        public  long3 yyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(3, 2, 3, 2));
				}
				else
				{
					return new long3(yy, w);
				}
			}
		}
        public          long3 yzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 1));
				}
				else
				{
					return new long3(yz, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.zxyy, 0b0011_1111);
				}
				else
				{
					this.y = value.x;
					this.z = value.y;
					this.x = value.z;
				}
			}
		}
        public  long3 yzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 1));
				}
				else
				{
					return new long3(yz, y);
				}
			}
		}
        public  long3 yzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 1));
				}
				else
				{
					return new long3(yz, z);
				}
			}
		}
        public          long3 yzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 1));
				}
				else
				{
					return new long3(yz, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.xxyz, 0b1111_1100);
				}
				else
				{
					this.y = value.x;
					this.z = value.y;
					this.w = value.z;
				}
			}
		}
        public          long3 ywx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 3, 1));
				}
				else
				{
					return new long3(yw, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.zxxy, 0b1100_1111);
				}
				else
				{
					this.y = value.x;
					this.w = value.y;
					this.x = value.z;
				}
			}
		}
        public  long3 ywy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 3, 1));
				}
				else
				{
					return new long3(yw, y);
				}
			}
		}
        public          long3 ywz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 3, 1));
				}
				else
				{
					return new long3(yw, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.xxzy, 0b1111_1100);
				}
				else
				{
					this.y = value.x;
					this.w = value.y;
					this.z = value.z;
				}
			}
		}
        public  long3 yww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 1));
				}
				else
				{
					return new long3(yw, w);
				}
			}
		}
        public  long3 zxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 0, 2));
				}
				else
				{
					return new long3(zx, x);
				}
			}
		}
        public          long3 zxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 2));
				}
				else
				{
					return new long3(zx, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.yzxx, 0b0011_1111);
				}
				else
				{
					this.z = value.x;
					this.x = value.y;
					this.y = value.z;
				}
			}
		}
        public  long3 zxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 0, 2));
				}
				else
				{
					return new long3(zx, z);
				}
			}
		}
        public          long3 zxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 2));
				}
				else
				{
					return new long3(zx, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.yyxz, 0b1111_0011);
				}
				else
				{
					this.z = value.x;
					this.x = value.y;
					this.w = value.z;
				}
			}
		}
        public          long3 zyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 1, 2));
				}
				else
				{
					return new long3(zy, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.zyxx, 0b0011_1111);
				}
				else
				{
					this.z = value.x;
					this.y = value.y;
					this.x = value.z;
				}
			}
		}
        public  long3 zyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 2));
				}
				else
				{
					return new long3(zy, y);
				}
			}
		}
        public  long3 zyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 1, 2));
				}
				else
				{
					return new long3(zy, z);
				}
			}
		}
        public          long3 zyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 1, 2));
				}
				else
				{
					return new long3(zy, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.yyxz, 0b1111_1100);
				}
				else
				{
					this.z = value.x;
					this.y = value.y;
					this.w = value.z;
				}
			}
		}
        public  long3 zzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 2));
				}
				else
				{
					return new long3(zz, x);
				}
			}
		}
        public  long3 zzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 2));
				}
				else
				{
					return new long3(zz, y);
				}
			}
		}
        public  long3 zzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 2));
				}
				else
				{
					return new long3(zz, z);
				}
			}
		}
        public  long3 zzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 2));
				}
				else
				{
					return new long3(zz, w);
				}
			}
		}
        public          long3 zwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 3, 2));
				}
				else
				{
					return new long3(zw, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.zzxy, 0b1111_0011);
				}
				else
				{
					this.z = value.x;
					this.w = value.y;
					this.x = value.z;
				}
			}
		}
        public          long3 zwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 3, 2));
				}
				else
				{
					return new long3(zw, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.zzxy, 0b1111_1100);
				}
				else
				{
					this.z = value.x;
					this.w = value.y;
					this.y = value.z;
				}
			}
		}
        public  long3 zwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 3, 2));
				}
				else
				{
					return new long3(zw, z);
				}
			}
		}
        public  long3 zww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 2));
				}
				else
				{
					return new long3(zw, w);
				}
			}
		}
        public  long3 wxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 0, 3));
				}
				else
				{
					return new long3(wx, x);
				}
			}
		}
        public          long3 wxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 3));
				}
				else
				{
					return new long3(wx, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.yzzx, 0b1100_1111);
				}
				else
				{
					this.w = value.x;
					this.x = value.y;
					this.y = value.z;
				}
			}
		}
        public          long3 wxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 0, 3));
				}
				else
				{
					return new long3(wx, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.yyzx, 0b1111_0011);
				}
				else
				{
					this.w = value.x;
					this.x = value.y;
					this.z = value.z;
				}
			}
		}
        public  long3 wxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 3));
				}
				else
				{
					return new long3(wx, w);
				}
			}
		}
        public          long3 wyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 1, 3));
				}
				else
				{
					return new long3(wy, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.zyyx, 0b1100_1111);
				}
				else
				{
					this.w = value.x;
					this.y = value.y;
					this.x = value.z;
				}
			}
		}
        public  long3 wyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 3));
				}
				else
				{
					return new long3(wy, y);
				}
			}
        }
        public          long3 wyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 1, 3));
				}
				else
				{
					return new long3(wy, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.yyzx, 0b1111_1100);
				}
				else
				{
					this.w = value.x;
					this.y = value.y;
					this.z = value.z;
				}
			}
        }
        public  long3 wyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 1, 3));
				}
				else
				{
					return new long3(wy, w);
				}
			}
        }
        public          long3 wzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 3));
				}
				else
				{
					return new long3(wz, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.zzyx, 0b1111_0011);
				}
				else
				{
					this.w = value.x;
					this.z = value.y;
					this.x = value.z;
				}
			}
        }
        public          long3 wzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 3));
				}
				else
				{
					return new long3(wz, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.zzyx, 0b1111_1100);
				}
				else
				{
					this.w = value.x;
					this.z = value.y;
					this.y = value.z;
				}
			}
        }
        public  long3 wzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 3));
				}
				else
				{
					return new long3(wz, z);
				}
			}
        }
        public  long3 wzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 3));
				}
				else
				{
					return new long3(wz, w);
				}
			}
        }
        public  long3 wwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 3, 3));
				}
				else
				{
					return new long3(ww, x);
				}
			}
        }
        public  long3 wwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 3, 3));
				}
				else
				{
					return new long3(ww, y);
				}
			}
        }
        public  long3 wwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 3, 3));
				}
				else
				{
					return new long3(ww, z);
				}
			}
        }
        public  long3 www
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 3));
				}
				else
				{
					return new long3(ww, w);
				}
			}
        }

        public  long2 xx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx.IsAvxSupported)
				{
					return Sse2.shuffle_epi32(Avx.mm256_castsi256_si128(this), Sse.SHUFFLE(1, 0, 1, 0));
				}
				else if (Sse2.IsSse2Supported)
				{
					return this._xy.xx;
				}
				else
				{
					return new long2(x, x);
				}
			}
		}
        public          long2 xy
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get
			{
				if (Avx.IsAvxSupported)
				{
					return Avx.mm256_castsi256_si128(this);
				}
				else if (Sse2.IsSse2Supported)
				{
					return this._xy;
				}
				else
				{
					return new long2(x, y);
				}
            }

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_inserti128_si256(this, value, 0);
				}
				else if (Sse2.IsSse2Supported)
				{
					this._xy = value;
				}
				else
				{
					this.x = value.x;
					this.y = value.y;
				}
			}
        }
        public          long2 xz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 0)));
				}
				else if (Sse2.IsSse2Supported)
				{
					return Sse2.unpacklo_epi64(this._xy, this._zw);
				}
				else
				{
					return new long2(x, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.xxyy, 0b0011_0011);
				}
				else if (Sse2.IsSse2Supported)
				{
                    if (Sse4_1.IsSse41Supported)
					{
						this._xy = Sse4_1.blend_epi16(this._xy, value, 0b0000_1111);
					}
					else
					{
						this._xy = Mask.BlendEpi16_SSE2(this._xy, value, 0b0000_1111);
					}

					this._zw = Sse2.unpackhi_epi64(value, this._zw);
				}
				else
				{
					this.x = value.x;
					this.z = value.y;
				}
			}
        }
        public          long2 xw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 0)));
				}
				else if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						return Sse4_1.blend_epi16(this._xy, this._zw, 0b1111_0000);
					}
					else
					{
						return Mask.BlendEpi16_SSE2(this._xy, this._zw, 0b1111_0000);
					}
				}
				else
				{
					return new long2(x, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.xxyy, 0b1100_0011);
				}
				else if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this._xy = Sse4_1.blend_epi16(this._xy, value, 0b0000_1111);
						this._zw = Sse4_1.blend_epi16(this._zw, value, 0b1111_0000);
					}
					else
					{
						this._xy = Mask.BlendEpi16_SSE2(this._xy, value, 0b0000_1111);
						this._zw = Mask.BlendEpi16_SSE2(this._zw, value, 0b1111_0000);
					}
				}
				else
				{
					this.x = value.x;
					this.w = value.y;
				}
			}
        }
        public          long2 yx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx.IsAvxSupported)
				{
					return Sse2.shuffle_epi32(Avx.mm256_castsi256_si128(this), Sse.SHUFFLE(1, 0, 3, 2));
				}
				else if (Sse2.IsSse2Supported)
				{
					return this._xy.yx;
				}
				else
				{
					return new long2(y, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_inserti128_si256(this, value.yx, 0);
				}
				else if (Sse2.IsSse2Supported)
				{
					this._xy = value.yx;
				}
				else
				{
					this.y = value.x;
					this.x = value.y;
				}
			}
        }
        public  long2 yy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx.IsAvxSupported)
				{
					return Sse2.shuffle_epi32(Avx.mm256_castsi256_si128(this), Sse.SHUFFLE(3, 2, 3, 2));
				}
				else if (Sse2.IsSse2Supported)
				{
					return this._xy.yy;
				}
				else
				{
					return new long2(y, y);
				}
			}
        }
        public          long2 yz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 1)));
				}
				else if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						return Sse2.shuffle_epi32(Sse4_1.blend_epi16(this._xy, this._zw, 0b0000_1111), Sse.SHUFFLE(1, 0, 3, 2));
					}
					else
					{
						return Sse2.shuffle_epi32(Mask.BlendEpi16_SSE2(this._xy, this._zw, 0b0000_1111), Sse.SHUFFLE(1, 0, 3, 2));
					}
				}
				else
				{
					return new long2(y, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.xxyy, 0b0011_1100);
				}
				else if (Sse2.IsSse2Supported)
				{
					this._xy = Sse2.unpacklo_epi64(this._xy, value);
					this._zw = Sse2.unpackhi_epi64(value, this._zw);
				}
				else
				{
					this.y = value.x;
					this.z = value.y;
				}
			}
        }
        public          long2 yw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 1)));
				}
				else if (Sse2.IsSse2Supported)
				{
					return Sse2.unpackhi_epi64(this._xy, this._zw);
				}
				else
				{
					return new long2(y, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_unpacklo_epi64(this, value.xxyy);
				}
				else if (Sse2.IsSse2Supported)
				{
					this._xy = Sse2.unpacklo_epi64(this._xy, value);

					if (Sse4_1.IsSse41Supported)
					{
						this._zw = Sse4_1.blend_epi16(this._zw, value, 0b1111_0000);
					}
					else
					{
						this._zw = Mask.BlendEpi16_SSE2(this._zw, value, 0b1111_0000);
					}
				}
				else
				{
					this.y = value.x;
					this.w = value.y;
				}
			}
        }
        public          long2 zx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 2)));
				}
				else if (Sse2.IsSse2Supported)
				{
					return Sse2.unpacklo_epi64(this._zw, this._xy);
				}
				else
				{
					return new long2(z, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.yyxx, 0b0011_0011);
				}
				else if (Sse2.IsSse2Supported)
				{
					this._xy = Sse2.unpackhi_epi64(value, this._xy);

					if (Sse4_1.IsSse41Supported)
					{
						this._zw = Sse4_1.blend_epi16(this._zw, value, 0b0000_1111);
					}
					else
					{
						this._zw = Mask.BlendEpi16_SSE2(this._zw, value, 0b0000_1111);
					}
				}
				else
				{
					this.z = value.x;
					this.x = value.y;
				}
			}
        }
        public          long2 zy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 1, 2)));
				}
				else if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						return Sse4_1.blend_epi16(this._xy, this._zw, 0b0000_1111);
					}
					else
					{
						return Mask.BlendEpi16_SSE2(this._xy, this._zw, 0b0000_1111);
					}
				}
				else
				{
					return new long2(z, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.yyxx, 0b0011_1100);
				}
				else if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this._xy = Sse4_1.blend_epi16(this._xy, value, 0b1111_0000);
						this._zw = Sse4_1.blend_epi16(this._zw, value, 0b0000_1111);
					}
					else
					{
						this._xy = Mask.BlendEpi16_SSE2(this._xy, value, 0b1111_0000);
						this._zw = Mask.BlendEpi16_SSE2(this._zw, value, 0b0000_1111);
					}
				}
				else
				{
					this.z = value.x;
					this.y = value.y;
				}
			}
        }
        public  long2 zz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 2)));
				}
				else if (Sse2.IsSse2Supported)
				{
					return this._zw.xx;
				}
				else
				{
					return new long2(z, z);
				}
			}
        }
        public          long2 zw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_extracti128_si256(this, 1);
				}
				else if (Sse2.IsSse2Supported)
				{
					return this._zw;
				}
				else
				{
					return new long2(z, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_inserti128_si256(this, value, 1);
				}
				else if (Sse2.IsSse2Supported)
				{
					this._zw = value;
				}
				else
				{
					this.z = value.x;
					this.w = value.y;
				}
			}
        }
        public          long2 wx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 3)));
				}
				else if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						return Sse2.shuffle_epi32(Sse4_1.blend_epi16(this._xy, this._zw, 0b1111_0000), Sse.SHUFFLE(1, 0, 3, 2));
					}
					else
					{
						return Sse2.shuffle_epi32(Mask.BlendEpi16_SSE2(this._xy, this._zw, 0b1111_0000), Sse.SHUFFLE(1, 0, 3, 2));
					}
				}
				else
				{
					return new long2(w, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.yyxx, 0b1100_0011);
				}
				else if (Sse2.IsSse2Supported)
				{
					this._xy = Sse2.unpackhi_epi64(value, this._xy);
					this._zw = Sse2.unpacklo_epi64(this._zw, value);
				}
				else
				{
					this.w = value.x;
					this.x = value.y;
				}
			}
        }
        public          long2 wy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 1, 3)));
				}
				else if (Sse2.IsSse2Supported)
				{
					return Sse2.unpackhi_epi64(this._zw, this._xy);
				}
				else
				{
					return new long2(w, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.yyxx, 0b1100_1100);
				}
				else if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this._xy = Sse4_1.blend_epi16(this._xy, value, 0b1111_0000);
					}
					else
					{
						this._xy = Mask.BlendEpi16_SSE2(this._xy, value, 0b1111_0000);
					}

					this._zw = Sse2.unpacklo_epi64(this._zw, value);
				}
				else
				{
					this.w = value.x;
					this.y = value.y;
				}
			}
        }
        public          long2 wz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 3)));
				}
				else if (Sse2.IsSse2Supported)
				{
					return _zw.yx;
				}
				else
				{
					return new long2(w, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_inserti128_si256(this, value.yx, 1);
				}
				else if (Sse2.IsSse2Supported)
				{
					this._zw = value.yx;
				}
				else
				{
					this.w = value.x;
					this.z = value.y;
				}
			}
        }
        public  long2 ww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Avx2.IsAvx2Supported)
				{
					return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 3)));
				}
				else if (Sse2.IsSse2Supported)
                {
					return _zw.yy;
                }
				else
                {
					return new long2(w, w);
                }
			}
        }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Avx2.mm256_stream_load_si256(void* ptr)   Avx.mm256_load_si256(void* ptr)
        public static implicit operator v256(long4 input) => new v256(input.x, input.y, input.z, input.w);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Avx.mm256_storeu_si256(void* ptr, v128 x)
        public static implicit operator long4(v256 input) => new long4 { x = input.SLong0, y = input.SLong1, z = input.SLong2, w = input.SLong3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4(long input) => new long4(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4(ulong4 input)
        {
            if (Avx.IsAvxSupported)
            {
                return (v256)input;
            }
            else if (Sse2.IsSse2Supported)
            {
                return new long4((long2)input._xy, (long2)input._zw);
            }
            else
            {
                return *(long4*)&input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4(uint4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepu32_epi64(*(v128*)&input);
            }
            else if (Sse2.IsSse2Supported)
            {
				return new long4
				{
					_xy = (long2)input.xy,
					_zw = (long2)input.zw
				};
            }
            else
            {
                return new long4((long)input.x, (long)input.y, (long)input.z, (long)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4(int4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepi32_epi64(*(v128*)&input);
            }
            else if (Sse2.IsSse2Supported)
            {
				return new long4
				{
					_xy = (long2)input.xy,
					_zw = (long2)input.zw
				};
			}
            else
            {
                return new long4((long)input.x, (long)input.y, (long)input.z, (long)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4(half4 input) => (long4)(int4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4(float4 input) => new long4((long2)input.xy, (long2)input.zw);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4(double4 input) => new long4((long2)input.xy, (long2)input.zw);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint4(long4 input)
		{
			if (Avx2.IsAvx2Supported)
			{
				v128 temp = Cast.Long4ToInt4(input); 
				
				return *(uint4*)&temp;
			}
			else
			{
				return new uint4((uint2)input._xy, (uint2)input._zw);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4(long4 input)
		{
			if (Avx2.IsAvx2Supported)
			{
				v128 temp = Cast.Long4ToInt4(input); 
				
				return *(int4*)&temp;
			}
			else
			{
				return new int4((int2)input._xy, (int2)input._zw);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half4(long4 input) => (half4)(float4)(int4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(long4 input) => new float4((float2)input._xy, (float2)input._zw);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4(long4 input)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Cast.Long4ToDouble4(input);
			}
			else
			{
				return new double4((double2)input._xy, (double2)input._zw);
			}
		}


        public long this[int index]
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
		public static long4 operator + (long4 left, long4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Avx2.mm256_add_epi64(left, right);
			}
			else
			{
				return new long4(left._xy + right._xy, left._zw + right._zw);
			}
		}
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator - (long4 left, long4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Avx2.mm256_sub_epi64(left, right);
			}
			else
			{
				return new long4(left._xy - right._xy, left._zw - right._zw);
			}
		}
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator * (long4 left, long4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Operator.mul_long(left, right);
			}
			else
			{
				return new long4(left._xy * right._xy, left._zw * right._zw);
			}
		}
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator / (long4 left, long4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return new long4(left.x / right.x, left.y / right.y, left.z / right.z, left.w / right.w);
			}
			else
			{
				return new long4(left._xy / right._xy, left._zw / right._zw);
			}
		}
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator % (long4 left, long4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return new long4(left.x % right.x, left.y % right.y, left.z % right.z, left.w % right.w);
			}
			else
			{
				return new long4(left._xy % right._xy, left._zw % right._zw);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long4 operator * (long left, long4 right) => right * left;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator * (long4 left, long right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return new long4(left.x * right, left.y * right, left.z * right, left.w * right);
			}
			else
			{
				return new long4(left._xy * right, left._zw * right);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator / (long4 left, long right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return new long4(left.x / right, left.y / right, left.z / right, left.w / right);
			}
			else
			{
				return new long4(left._xy / right, left._zw / right);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator % (long4 left, long right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return new long4(left.x % right, left.y % right, left.z % right, left.w % right);
			}
			else
			{
				return new long4(left._xy % right, left._zw % right);
			}
		}
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator & (long4 left, long4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Avx2.mm256_and_si256(left, right);
			}
			else
			{
				return new long4(left._xy & right._xy, left._zw & right._zw);
			}
		}
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator | (long4 left, long4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Avx2.mm256_or_si256(left, right);
			}
			else
			{
				return new long4(left._xy | right._xy, left._zw | right._zw);
			}
		}
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ^ (long4 left, long4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Avx2.mm256_xor_si256(left, right);
			}
			else
			{
				return new long4(left._xy ^ right._xy, left._zw ^ right._zw);
			}
		}
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator - (long4 x)
		{
            if (Avx2.IsAvx2Supported)
            {
				return Avx2.mm256_sub_epi64(default(v256), x);
			}
			else
            {
				return new long4(-x._xy, -x._zw);
            }
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ++ (long4 x)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Avx2.mm256_sub_epi64(x, Avx2.mm256_cmpeq_epi32(default(v256), default(v256)));
			}
			else
			{
				return new long4(x._xy + 1, x._zw + 1);
			}
		}
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator -- (long4 x)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Avx2.mm256_add_epi64(x, Avx2.mm256_cmpeq_epi32(default(v256), default(v256)));
			}
			else
			{
				return new long4(x._xy - 1, x._zw - 1);
			}
		}
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ~ (long4 x)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Avx2.mm256_xor_si256(x, Avx2.mm256_cmpeq_epi32(default(v256), default(v256)));
			}
			else
			{
				return new long4(~x._xy, ~x._zw);
			}
		}
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator << (long4 x, int n)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Operator.shl_long(x, n);
			}
			else
			{
				return new long4(x._xy << n, x._zw << n);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator >> (long4 x, int n)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Operator.shra_long(x, n);
			}
			else
			{
				return new long4(x._xy >> n, x._zw >> n);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator == (long4 left, long4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return TestIsTrue(Avx2.mm256_cmpeq_epi64(left, right));
			}
			else
			{
				return new bool4(left._xy == right._xy, left._zw == right._zw);
			}
		}
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (long4 left, long4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return TestIsTrue(Avx2.mm256_cmpgt_epi64(right, left));
			}
			else
			{
				return new bool4(left._xy < right._xy, left._zw < right._zw);
			}
		}
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (long4 left, long4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return TestIsTrue(Avx2.mm256_cmpgt_epi64(left, right));
			}
			else
			{
				return new bool4(left._xy > right._xy, left._zw > right._zw);
			}
		}
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (long4 left, long4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return TestIsFalse(Avx2.mm256_cmpeq_epi64(left, right));
			}
			else
			{
				return new bool4(left._xy != right._xy, left._zw != right._zw);
			}
		}
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (long4 left, long4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return TestIsFalse(Avx2.mm256_cmpgt_epi64(left, right));
			}
			else
			{
				return new bool4(left._xy <= right._xy, left._zw <= right._zw);
			}
		}
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (long4 left, long4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return TestIsFalse(Avx2.mm256_cmpgt_epi64(right, left));
			}
			else
			{
				return new bool4(left._xy >= right._xy, left._zw >= right._zw);
			}
		}
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool4 TestIsTrue(v256 input)
        {
			if (Avx2.IsAvx2Supported)
			{
				int cast = 0x0101_0101 & Avx2.mm256_movemask_epi8(input);

				return *(bool4*)&cast;
			}
			else throw new CPUFeatureCheckException();
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool4 TestIsFalse(v256 input)
        {
			if (Avx2.IsAvx2Supported)
			{
				int cast = maxmath.andnot(0x0101_0101, Avx2.mm256_movemask_epi8(input));

				return *(bool4*)&cast;
			}
			else throw new CPUFeatureCheckException();
        }


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public  bool Equals(long4 other)
		{
			if (Avx2.IsAvx2Supported)
			{
				return uint.MaxValue == (uint)Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi64(this, other));
			}
			else
			{
				return this._xy.Equals(other._xy) & this._zw.Equals(other._zw);
			}
		}

        public override  bool Equals(object obj) => Equals((long4)obj);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override  int GetHashCode()
		{
			if (Avx2.IsAvx2Supported)
			{
				return Hash.v256(this);
			}
			else
			{
				return (this._xy ^ this._zw).GetHashCode();
			}
		}


        public override  string ToString() => $"long4({x}, {y}, {z}, {w})";
        public  string ToString(string format, IFormatProvider formatProvider) => $"long4({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)}, {w.ToString(format, formatProvider)})";
    }
}