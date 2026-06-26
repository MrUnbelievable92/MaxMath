using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
#if DEBUG
    internal sealed class ulong4DebuggerProxy
    {
	    public ulong x;
	    public ulong y;
	    public ulong z;
	    public ulong w;
        
	    public ulong4DebuggerProxy(ulong4 v)
	    {
	    	x = v.x;
	    	y = v.y;
	    	z = v.z;
	    	w = v.w;
	    }
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(ulong4DebuggerProxy))]
#endif
    [Serializable]
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public struct ulong4 : IEquatable<ulong4>, IFormattable
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal ulong2 __x0;
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal ulong2 __x2;
		
        public ref ulong x { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(ulong4* ptr = &this) { return ref *((ulong*)ptr + 0); } } }
        public ref ulong y { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(ulong4* ptr = &this) { return ref *((ulong*)ptr + 1); } } }
        public ref ulong z { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(ulong4* ptr = &this) { return ref *((ulong*)ptr + 2); } } }
        public ref ulong w { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(ulong4* ptr = &this) { return ref *((ulong*)ptr + 3); } } }


        public static ulong4 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(ulong x, ulong y, ulong z, ulong w)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_set_epi64x((long)w, (long)z, (long)y, (long)x);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                this = new ulong4
                {
                    __x0 = new ulong2(x, y),
                    __x2 = new ulong2(z, w)
                };
            }
            else
            {
                this = new ulong4
                {
                    x = x,
                    y = y,
                    z = z,
                    w = w
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(ulong xyzw)
        {
            if (Avx.IsAvxSupported)
            {
                this = Xse.mm256_set1_epi64x(xyzw);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                this = new ulong4
                {
                    __x0 = new ulong2(xyzw),
                    __x2 = new ulong2(xyzw)
                };
            }
            else
            {
                this = new ulong4
                {
                    x = xyzw,
                    y = xyzw,
                    z = xyzw,
                    w = xyzw
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(ulong2 xy, ulong z, ulong w)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_set_m128i(new ulong2(z, w), xy);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                this = new ulong4
                {
                    __x0 = xy,
                    __x2 = new ulong2(z, w)
                };
            }
            else
            {
                this = new ulong4
                {
                    x = xy.x,
                    y = xy.y,
                    z = z,
                    w = w
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(ulong x, ulong2 yz, ulong w)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 shuf = yz.xxyy;
                shuf.ULong0 = x;
                shuf.ULong3 = w;

                this = shuf;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 lo = Xse.shuffle_epi32(yz, Sse.SHUFFLE(1, 0, 1, 0));
                lo.ULong0 = x;

                v128 hi = Xse.shuffle_epi32(yz, Sse.SHUFFLE(3, 2, 3, 2));
                hi.ULong1 = w;

                this = new ulong4
                {
                    __x0 = lo,
                    __x2 = hi
                };
            }
            else
            {
                this = new ulong4
                {
                    x = x,
                    y = yz.x,
                    z = yz.y,
                    w = w
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(ulong x, ulong y, ulong2 zw)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_set_m128i(zw, new ulong2(x, y));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                this = new ulong4
                {
                    __x0 = new ulong2(x, y),
                    __x2 = zw
                };
            }
            else
            {
                this = new ulong4
                {
                    x = x,
                    y = y,
                    z = zw.x,
                    w = zw.y,
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(ulong2 xy, ulong2 zw)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_set_m128i(zw, xy);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                this = new ulong4
                {
                    __x0 = xy,
                    __x2 = zw
                };
            }
            else
            {
                this = new ulong4
                {
                    x = xy.x,
                    y = xy.y,
                    z = zw.x,
                    w = zw.y
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(ulong3 xyz, ulong w)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_insert_epi64(xyz, (long)w, 3);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                this = new ulong4
                {
                    __x0 = xyz.__x0,
                    __x2 = new ulong2(xyz.z, w)
                };
            }
            else
            {
                this = new ulong4
                {
                    x = xyz.x,
                    y = xyz.y,
                    z = xyz.z,
                    w = w
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(ulong x, ulong3 yzw)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_insert_epi64(yzw.xxyz, (long)x, 0);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 lo = Xse.shuffle_epi32(yzw.__x0, Sse.SHUFFLE(1, 0, 1, 0));
                lo.ULong0 = x;
                ulong2 hi = yzw.yz;

                this = new ulong4
                {
                    __x0 = lo,
                    __x2 = hi
                };
            }
            else
            {
                this = new ulong4
                {
                    x = x,
                    y = yzw.x,
                    z = yzw.y,
                    w = yzw.z
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(bool v)
        {
            this = (ulong4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(bool4 v)
        {
            this = (ulong4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(mask8x4 v)
        {
            this = (ulong4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(mask16x4 v)
        {
            this = (ulong4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(mask32x4 v)
        {
            this = (ulong4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(mask64x4 v)
        {
            this = (ulong4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(byte v)
        {
            this = (ulong4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(byte4 v)
        {
            this = (ulong4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(sbyte v)
        {
            this = (ulong4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(sbyte4 v)
        {
            this = (ulong4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(ushort v)
        {
            this = (ulong4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(ushort4 v)
        {
            this = (ulong4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(short v)
        {
            this = (ulong4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(short4 v)
        {
            this = (ulong4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(uint v)
        {
            this = (ulong4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(uint4 v)
        {
            this = (ulong4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(int v)
        {
            this = (ulong4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(int4 v)
        {
            this = (ulong4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(ulong4 v)
        {
            this = (ulong4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(long v)
        {
            this = (ulong4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(long4 v)
        {
            this = (ulong4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(UInt128 v)
        {
            this = (ulong4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(Int128 v)
        {
            this = (ulong4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(quarter v)
        {
            this = (ulong4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(quarter4 v)
        {
            this = (ulong4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(half v)
        {
            this = (ulong4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(half4 v)
        {
            this = (ulong4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(float v)
        {
            this = (ulong4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(float4 v)
        {
            this = (ulong4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(double v)
        {
            this = (ulong4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(double4 v)
        {
            this = (ulong4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(quadruple v)
        {
            this = (ulong4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(Unity.Mathematics.bool4 v)
        {
            this = (ulong4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(Unity.Mathematics.uint4 v)
        {
            this = (ulong4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(Unity.Mathematics.int4 v)
        {
            this = (ulong4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(Unity.Mathematics.half v)
        {
            this = (ulong4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(Unity.Mathematics.half4 v)
        {
            this = (ulong4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(Unity.Mathematics.float4 v)
        {
            this = (ulong4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(Unity.Mathematics.double4 v)
        {
            this = (ulong4)v;
        }

        #region Shuffle
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xxxx
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
					return new ulong4(xx, xx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xxxy
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
					return new ulong4(xx, xy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xxxz
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
					return new ulong4(xx, xz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xxxw
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
					return new ulong4(xx, xw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xxyx
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
					return new ulong4(xx, yx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xxyy
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
					return new ulong4(xx, yy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xxyz
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
					return new ulong4(xx, yz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xxyw
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
					return new ulong4(xx, yw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xxzx
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
					return new ulong4(xx, zx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xxzy
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
					return new ulong4(xx, zy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_unpacklo_epi64(this, this);
				}
				else
				{
					return new ulong4(xx, zz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xxzw
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
					return new ulong4(xx, zw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xxwx
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
					return new ulong4(xx, wx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xxwy
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
					return new ulong4(xx, wy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xxwz
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
					return new ulong4(xx, wz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xxww
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
					return new ulong4(xx, ww);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xyxx
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
					return new ulong4(xy, xx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xyxy
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
					return new ulong4(xy, xy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xyxz
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
					return new ulong4(xy, xz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xyxw
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
					return new ulong4(xy, xw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xyyx
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
					return new ulong4(xy, yx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xyyy
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
					return new ulong4(xy, yy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xyyz
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
					return new ulong4(xy, yz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xyyw
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
					return new ulong4(xy, yw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xyzx
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
					return new ulong4(xy, zx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xyzy
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
					return new ulong4(xy, zy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xyzz
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
					return new ulong4(xy, zz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xyzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                return this;
            }

            set
            {
                this = value;
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xywx
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
					return new ulong4(xy, wx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xywy
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
					return new ulong4(xy, wy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			ulong4 xywz
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
					return new ulong4(xy, wz);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xywz;
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xyww
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
					return new ulong4(xy, ww);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xzxx
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
					return new ulong4(xz, xx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xzxy
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
					return new ulong4(xz, xy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xzxz
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
					return new ulong4(xz, xz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xzxw
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
					return new ulong4(xz, xw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xzyx
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
					return new ulong4(xz, yx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xzyy
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
					return new ulong4(xz, yy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xzyz
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
					return new ulong4(xz, yz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			ulong4 xzyw
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
					return new ulong4(xz, yw);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xzyw;
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xzzx
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
					return new ulong4(xz, zx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xzzy
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
					return new ulong4(xz, zy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xzzz
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
					return new ulong4(xz, zz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xzzw
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
					return new ulong4(xz, zw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xzwx
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
					return new ulong4(xz, wx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			ulong4 xzwy
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
					return new ulong4(xz, wy);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xwyz;
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xzwz
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
					return new ulong4(xz, wz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xzww
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
					return new ulong4(xz, ww);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xwxx
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
					return new ulong4(xw, xx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xwxy
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
					return new ulong4(xw, xy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xwxz
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
					return new ulong4(xw, xz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xwxw
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
					return new ulong4(xw, xw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xwyx
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
					return new ulong4(xw, yx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xwyy
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
					return new ulong4(xw, yy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			ulong4 xwyz
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
					return new ulong4(xw, yz);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xzwy;
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xwyw
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
					return new ulong4(xw, yw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xwzx
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
					return new ulong4(xw, zx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			ulong4 xwzy
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
					return new ulong4(xw, zy);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xwzy;
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xwzz
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
					return new ulong4(xw, zz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xwzw
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
					return new ulong4(xw, zw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xwwx
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
					return new ulong4(xw, wx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xwwy
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
					return new ulong4(xw, wy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xwwz
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
					return new ulong4(xw, wz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xwww
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
					return new ulong4(xw, ww);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yxxx
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
					return new ulong4(yx, xx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yxxy
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
					return new ulong4(yx, xy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yxxz
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
					return new ulong4(yx, xz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yxxw
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
					return new ulong4(yx, xw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yxyx
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
					return new ulong4(yx, yx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yxyy
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
					return new ulong4(yx, yy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yxyz
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
					return new ulong4(yx, yz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yxyw
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
					return new ulong4(yx, yw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yxzx
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
					return new ulong4(yx, zx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yxzy
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
					return new ulong4(yx, zy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yxzz
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
					return new ulong4(yx, zz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			ulong4 yxzw
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
					return new ulong4(yx, zw);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.yxzw;
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yxwx
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
					return new ulong4(yx, wx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yxwy
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
					return new ulong4(yx, wy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			ulong4 yxwz
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
					return new ulong4(yx, wz);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.yxwz;
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yxww
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
					return new ulong4(yx, ww);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yyxx
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
					return new ulong4(yy, xx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yyxy
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
					return new ulong4(yy, xy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yyxz
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
					return new ulong4(yy, xz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yyxw
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
					return new ulong4(yy, xw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yyyx
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
					return new ulong4(yy, yx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yyyy
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
					return new ulong4(yy, yy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yyyz
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
					return new ulong4(yy, yz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yyyw
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
					return new ulong4(yy, yw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yyzx
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
					return new ulong4(yy, zx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yyzy
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
					return new ulong4(yy, zy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yyzz
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
					return new ulong4(yy, zz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yyzw
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
					return new ulong4(yy, zw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yywx
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
					return new ulong4(yy, wx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yywy
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
					return new ulong4(yy, wy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yywz
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
					return new ulong4(yy, wz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yyww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_unpackhi_epi64(this, this);
				}
				else
				{
					return new ulong4(yy, ww);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yzxx
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
					return new ulong4(yz, xx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yzxy
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
					return new ulong4(yz, xy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yzxz
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
					return new ulong4(yz, xz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			ulong4 yzxw
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
					return new ulong4(yz, xw);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zxyw;
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yzyx
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
					return new ulong4(yz, yx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yzyy
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
					return new ulong4(yz, yy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yzyz
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
					return new ulong4(yz, yz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yzyw
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
					return new ulong4(yz, yw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yzzx
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
					return new ulong4(yz, zx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yzzy
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
					return new ulong4(yz, zy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yzzz
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
					return new ulong4(yz, zz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yzzw
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
					return new ulong4(yz, zw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			ulong4 yzwx
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
					return new ulong4(yz, wx);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wxyz;
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yzwy
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
					return new ulong4(yz, wy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yzwz
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
					return new ulong4(yz, wz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yzww
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
					return new ulong4(yz, ww);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 ywxx
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
					return new ulong4(yw, xx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 ywxy
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
					return new ulong4(yw, xy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			ulong4 ywxz
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
					return new ulong4(yw, xz);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zxwy;
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 ywxw
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
					return new ulong4(yw, xw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 ywyx
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
					return new ulong4(yw, yx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 ywyy
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
					return new ulong4(yw, yy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 ywyz
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
					return new ulong4(yw, yz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 ywyw
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
					return new ulong4(yw, yw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			ulong4 ywzx
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
					return new ulong4(yw, zx);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wxzy;
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 ywzy
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
					return new ulong4(yw, zy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 ywzz
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
					return new ulong4(yw, zz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 ywzw
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
					return new ulong4(yw, zw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 ywwx
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
					return new ulong4(yw, wx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 ywwy
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
					return new ulong4(yw, wy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 ywwz
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
					return new ulong4(yw, wz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 ywww
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
					return new ulong4(yw, ww);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zxxx
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
					return new ulong4(zx, xx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zxxy
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
					return new ulong4(zx, xy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zxxz
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
					return new ulong4(zx, xz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zxxw
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
					return new ulong4(zx, xw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zxyx
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
					return new ulong4(zx, yx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zxyy
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
					return new ulong4(zx, yy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zxyz
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
					return new ulong4(zx, yz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			ulong4 zxyw
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
					return new ulong4(zx, yw);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.yzxw;
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zxzx
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
					return new ulong4(zx, zx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zxzy
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
					return new ulong4(zx, zy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zxzz
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
					return new ulong4(zx, zz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zxzw
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
					return new ulong4(zx, zw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zxwx
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
					return new ulong4(zx, wx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			ulong4 zxwy
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
					return new ulong4(zx, wy);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.ywxz;
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zxwz
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
					return new ulong4(zx, wz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zxww
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
					return new ulong4(zx, ww);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zyxx
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
					return new ulong4(zy, xx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zyxy
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
					return new ulong4(zy, xy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zyxz
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
					return new ulong4(zy, xz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			ulong4 zyxw
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
					return new ulong4(zy, xw);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zyxw;
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zyyx
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
					return new ulong4(zy, yx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zyyy
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
					return new ulong4(zy, yy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zyyz
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
					return new ulong4(zy, yz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zyyw
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
					return new ulong4(zy, yw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zyzx
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
					return new ulong4(zy, zx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zyzy
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
					return new ulong4(zy, zy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zyzz
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
					return new ulong4(zy, zz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zyzw
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
					return new ulong4(zy, zw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			ulong4 zywx
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
					return new ulong4(zy, wx);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wyxz;
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zywy
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
					return new ulong4(zy, wy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zywz
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
					return new ulong4(zy, wz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zyww
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
					return new ulong4(zy, ww);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zzxx
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
					return new ulong4(zz, xx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zzxy
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
					return new ulong4(zz, xy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zzxz
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
					return new ulong4(zz, xz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zzxw
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
					return new ulong4(zz, xw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zzyx
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
					return new ulong4(zz, yx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zzyy
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
					return new ulong4(zz, yy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zzyz
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
					return new ulong4(zz, yz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zzyw
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
					return new ulong4(zz, yw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zzzx
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
					return new ulong4(zz, zx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zzzy
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
					return new ulong4(zz, zy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zzzz
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
					return new ulong4(zz, zz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zzzw
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
					return new ulong4(zz, zw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zzwx
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
					return new ulong4(zz, wx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zzwy
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
					return new ulong4(zz, wy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zzwz
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
					return new ulong4(zz, wz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zzww
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
					return new ulong4(zz, ww);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zwxx
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
					return new ulong4(zw, xx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			ulong4 zwxy
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
					return new ulong4(zw, xy);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zwxy;
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zwxz
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
					return new ulong4(zw, xz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zwxw
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
					return new ulong4(zw, xw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			ulong4 zwyx
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
					return new ulong4(zw, yx);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wzxy;
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zwyy
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
					return new ulong4(zw, yy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zwyz
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
					return new ulong4(zw, yz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zwyw
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
					return new ulong4(zw, yw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zwzx
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
					return new ulong4(zw, zx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zwzy
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
					return new ulong4(zw, zy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zwzz
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
					return new ulong4(zw, zz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zwzw
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
					return new ulong4(zw, zw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zwwx
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
					return new ulong4(zw, wx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zwwy
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
					return new ulong4(zw, wy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zwwz
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
					return new ulong4(zw, wz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 zwww
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
					return new ulong4(zw, ww);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wxxx
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
					return new ulong4(wx, xx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wxxy
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
					return new ulong4(wx, xy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wxxz
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
					return new ulong4(wx, xz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wxxw
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
					return new ulong4(wx, xw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wxyx
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
					return new ulong4(wx, yx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wxyy
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
					return new ulong4(wx, yy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wxyz
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
					return new ulong4(wx, yz);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.yzwx;
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wxyw
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
					return new ulong4(wx, yw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wxzx
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
					return new ulong4(wx, zx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wxzy
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
					return new ulong4(wx, zy);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.ywzx;
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wxzz
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
					return new ulong4(wx, zz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wxzw
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
					return new ulong4(wx, zw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wxwx
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
					return new ulong4(wx, wx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wxwy
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
					return new ulong4(wx, wy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wxwz
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
					return new ulong4(wx, wz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wxww
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
					return new ulong4(wx, ww);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wyxx
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
					return new ulong4(wy, xx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wyxy
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
					return new ulong4(wy, xy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wyxz
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
					return new ulong4(wy, xz);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zywx;
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wyxw
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
					return new ulong4(wy, xw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wyyx
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
					return new ulong4(wy, yx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wyyy
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
					return new ulong4(wy, yy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wyyz
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
					return new ulong4(wy, yz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wyyw
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
					return new ulong4(wy, yw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wyzx
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
					return new ulong4(wy, zx);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wyzx;
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wyzy
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
					return new ulong4(wy, zy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wyzz
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
					return new ulong4(wy, zz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wyzw
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
					return new ulong4(wy, zw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wywx
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
					return new ulong4(wy, wx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wywy
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
					return new ulong4(wy, wy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wywz
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
					return new ulong4(wy, wz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wyww
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
					return new ulong4(wy, ww);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wzxx
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
					return new ulong4(wz, xx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wzxy
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
					return new ulong4(wz, xy);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zwyx;
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wzxz
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
					return new ulong4(wz, xz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wzxw
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
					return new ulong4(wz, xw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wzyx
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
					return new ulong4(wz, yx);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wzyx;
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wzyy
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
					return new ulong4(wz, yy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wzyz
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
					return new ulong4(wz, yz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wzyw
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
					return new ulong4(wz, yw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wzzx
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
					return new ulong4(wz, zx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wzzy
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
					return new ulong4(wz, zy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wzzz
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
					return new ulong4(wz, zz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wzzw
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
					return new ulong4(wz, zw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wzwx
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
					return new ulong4(wz, wx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wzwy
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
					return new ulong4(wz, wy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wzwz
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
					return new ulong4(wz, wz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wzww
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
					return new ulong4(wz, ww);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wwxx
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
					return new ulong4(ww, xx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wwxy
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
					return new ulong4(ww, xy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wwxz
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
					return new ulong4(ww, xz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wwxw
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
					return new ulong4(ww, xw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wwyx
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
					return new ulong4(ww, yx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wwyy
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
					return new ulong4(ww, yy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wwyz
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
					return new ulong4(ww, yz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wwyw
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
					return new ulong4(ww, yw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wwzx
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
					return new ulong4(ww, zx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wwzy
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
					return new ulong4(ww, zy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wwzz
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
					return new ulong4(ww, zz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wwzw
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
					return new ulong4(ww, zw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wwwx
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
					return new ulong4(ww, wx);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wwwy
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
					return new ulong4(ww, wy);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wwwz
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
					return new ulong4(ww, wz);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 wwww
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
					return new ulong4(ww, ww);
				}
			}
		}


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 xxx
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
					return new ulong3(xx, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 xxy
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
					return new ulong3(xx, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 xxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_unpacklo_epi64(this, this);
				}
				else
				{
					return new ulong3(xx, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 xxw
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
					return new ulong3(xx, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 xyx
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
					return new ulong3(xy, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 xyy
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
					return new ulong3(xy, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 xyz
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
					return new ulong3(xy, z);
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 xyw
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
					return new ulong3(xy, w);
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 xzx
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
					return new ulong3(xz, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 xzy
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
					return new ulong3(xz, y);
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 xzz
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
					return new ulong3(xz, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 xzw
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
					return new ulong3(xz, w);
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 xwx
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
					return new ulong3(xw, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 xwy
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
					return new ulong3(xw, y);
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 xwz
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
					return new ulong3(xw, z);
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 xww
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
					return new ulong3(xw, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 yxx
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
					return new ulong3(yx, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 yxy
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
					return new ulong3(yx, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 yxz
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
					return new ulong3(yx, z);
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 yxw
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
					return new ulong3(yx, w);
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 yyx
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
					return new ulong3(yy, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 yyy
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
					return new ulong3(yy, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 yyz
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
					return new ulong3(yy, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 yyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_unpackhi_epi64(this, this);
				}
				else
				{
					return new ulong3(yy, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 yzx
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
					return new ulong3(yz, x);
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 yzy
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
					return new ulong3(yz, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 yzz
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
					return new ulong3(yz, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 yzw
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
					return new ulong3(yz, w);
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 ywx
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
					return new ulong3(yw, x);
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 ywy
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
					return new ulong3(yw, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 ywz
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
					return new ulong3(yw, z);
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 yww
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
					return new ulong3(yw, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 zxx
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
					return new ulong3(zx, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 zxy
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
					return new ulong3(zx, y);
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 zxz
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
					return new ulong3(zx, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 zxw
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
					return new ulong3(zx, w);
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 zyx
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
					return new ulong3(zy, x);
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 zyy
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
					return new ulong3(zy, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 zyz
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
					return new ulong3(zy, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 zyw
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
					return new ulong3(zy, w);
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 zzx
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
					return new ulong3(zz, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 zzy
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
					return new ulong3(zz, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 zzz
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
					return new ulong3(zz, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 zzw
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
					return new ulong3(zz, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 zwx
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
					return new ulong3(zw, x);
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 zwy
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
					return new ulong3(zw, y);
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 zwz
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
					return new ulong3(zw, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 zww
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
					return new ulong3(zw, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 wxx
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
					return new ulong3(wx, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 wxy
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
					return new ulong3(wx, y);
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 wxz
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
					return new ulong3(wx, z);
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 wxw
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
					return new ulong3(wx, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 wyx
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
					return new ulong3(wy, x);
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 wyy
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
					return new ulong3(wy, y);
				}
			}
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 wyz
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
					return new ulong3(wy, z);
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 wyw
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
					return new ulong3(wy, w);
				}
			}
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 wzx
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
					return new ulong3(wz, x);
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 wzy
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
					return new ulong3(wz, y);
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 wzz
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
					return new ulong3(wz, z);
				}
			}
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 wzw
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
					return new ulong3(wz, w);
				}
			}
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 wwx
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
					return new ulong3(ww, x);
				}
			}
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 wwy
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
					return new ulong3(ww, y);
				}
			}
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 wwz
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
					return new ulong3(ww, z);
				}
			}
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 www
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
					return new ulong3(ww, w);
				}
			}
        }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong2 xx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx.IsAvxSupported)
				{
					return Xse.unpacklo_epi64(Avx.mm256_castsi256_si128(this), Avx.mm256_castsi256_si128(this));
				}
				else if (BurstArchitecture.IsSIMDSupported)
				{
					return this.__x0.xx;
				}
				else
				{
					return new ulong2(x, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong2 xy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx.IsAvxSupported)
				{
					return Avx.mm256_castsi256_si128(this);
				}
				else if (BurstArchitecture.IsSIMDSupported)
				{
					return this.__x0;
				}
				else
				{
					return new ulong2(x, y);
				}
            }

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_inserti128_si256(this, value, 0);
				}
				else if (BurstArchitecture.IsSIMDSupported)
				{
					this.__x0 = value;
				}
				else
				{
					this.x = value.x;
					this.y = value.y;
				}
			}
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong2 xz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 0)));
				}
				else if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.unpacklo_epi64(this.__x0, this.__x2);
				}
				else
				{
					return new ulong2(x, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.xxyy, 0b0011_0011);
				}
				else if (BurstArchitecture.IsSIMDSupported)
				{
                    this.__x0 = Xse.blend_epi16(this.__x0, value, 0b0000_1111);
					this.__x2 = Xse.unpackhi_epi64(value, this.__x2);
				}
				else
				{
					this.x = value.x;
					this.z = value.y;
				}
			}
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong2 xw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 0)));
				}
				else if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.blend_epi16(this.__x0, this.__x2, 0b1111_0000);
				}
				else
				{
					return new ulong2(x, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.xxyy, 0b1100_0011);
				}
				else if (BurstArchitecture.IsSIMDSupported)
				{
					this.__x0 = Xse.blend_epi16(this.__x0, value, 0b0000_1111);
					this.__x2 = Xse.blend_epi16(this.__x2, value, 0b1111_0000);
				}
				else
				{
					this.x = value.x;
					this.w = value.y;
				}
			}
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong2 yx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx.IsAvxSupported)
				{
					return Xse.shuffle_epi32(Avx.mm256_castsi256_si128(this), Sse.SHUFFLE(1, 0, 3, 2));
				}
				else if (BurstArchitecture.IsSIMDSupported)
				{
					return this.__x0.yx;
				}
				else
				{
					return new ulong2(y, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_inserti128_si256(this, value.yx, 0);
				}
				else if (BurstArchitecture.IsSIMDSupported)
				{
					this.__x0 = value.yx;
				}
				else
				{
					this.y = value.x;
					this.x = value.y;
				}
			}
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong2 yy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx.IsAvxSupported)
				{
					return Xse.unpackhi_epi64(Avx.mm256_castsi256_si128(this), Avx.mm256_castsi256_si128(this) );
				}
				else if (BurstArchitecture.IsSIMDSupported)
				{
					return this.__x0.yy;
				}
				else
				{
					return new ulong2(y, y);
				}
			}
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong2 yz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 1)));
				}
				else if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shuffle_epi32(Xse.blend_epi16(this.__x0, this.__x2, 0b0000_1111), Sse.SHUFFLE(1, 0, 3, 2));
				}
				else
				{
					return new ulong2(y, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.xxyy, 0b0011_1100);
				}
				else if (BurstArchitecture.IsSIMDSupported)
				{
					this.__x0 = Xse.unpacklo_epi64(this.__x0, value);
					this.__x2 = Xse.unpackhi_epi64(value, this.__x2);
				}
				else
				{
					this.y = value.x;
					this.z = value.y;
				}
			}
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong2 yw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 1)));
				}
				else if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.unpackhi_epi64(this.__x0, this.__x2);
				}
				else
				{
					return new ulong2(y, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_unpacklo_epi64(this, value.xxyy);
				}
				else if (BurstArchitecture.IsSIMDSupported)
				{
					this.__x0 = Xse.unpacklo_epi64(this.__x0, value);
					this.__x2 = Xse.blend_epi16(this.__x2, value, 0b1111_0000);
				}
				else
				{
					this.y = value.x;
					this.w = value.y;
				}
			}
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong2 zx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 2)));
				}
				else if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.unpacklo_epi64(this.__x2, this.__x0);
				}
				else
				{
					return new ulong2(z, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.yyxx, 0b0011_0011);
				}
				else if (BurstArchitecture.IsSIMDSupported)
				{
					this.__x0 = Xse.unpackhi_epi64(value, this.__x0);
					this.__x2 = Xse.blend_epi16(this.__x2, value, 0b0000_1111);
				}
				else
				{
					this.z = value.x;
					this.x = value.y;
				}
			}
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong2 zy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 1, 2)));
				}
				else if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.blend_epi16(this.__x0, this.__x2, 0b0000_1111);
				}
				else
				{
					return new ulong2(z, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.yyxx, 0b0011_1100);
				}
				else if (BurstArchitecture.IsSIMDSupported)
				{
					this.__x0 = Xse.blend_epi16(this.__x0, value, 0b1111_0000);
					this.__x2 = Xse.blend_epi16(this.__x2, value, 0b0000_1111);
				}
				else
				{
					this.z = value.x;
					this.y = value.y;
				}
			}
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong2 zz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 2)));
				}
				else if (BurstArchitecture.IsSIMDSupported)
				{
					return this.__x2.xx;
				}
				else
				{
					return new ulong2(z, z);
				}
			}
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong2 zw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_extracti128_si256(this, 1);
				}
				else if (BurstArchitecture.IsSIMDSupported)
				{
					return this.__x2;
				}
				else
				{
					return new ulong2(z, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_inserti128_si256(this, value, 1);
				}
				else if (BurstArchitecture.IsSIMDSupported)
				{
					this.__x2 = value;
				}
				else
				{
					this.z = value.x;
					this.w = value.y;
				}
			}
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong2 wx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 3)));
				}
				else if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shuffle_epi32(Xse.blend_epi16(this.__x0, this.__x2, 0b1111_0000), Sse.SHUFFLE(1, 0, 3, 2));
				}
				else
				{
					return new ulong2(w, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.yyxx, 0b1100_0011);
				}
				else if (BurstArchitecture.IsSIMDSupported)
				{
					this.__x0 = Xse.unpackhi_epi64(value, this.__x0);
					this.__x2 = Xse.unpacklo_epi64(this.__x2, value);
				}
				else
				{
					this.w = value.x;
					this.x = value.y;
				}
			}
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong2 wy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 1, 3)));
				}
				else if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.unpackhi_epi64(this.__x2, this.__x0);
				}
				else
				{
					return new ulong2(w, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.yyxx, 0b1100_1100);
				}
				else if (BurstArchitecture.IsSIMDSupported)
				{
					this.__x0 = Xse.blend_epi16(this.__x0, value, 0b1111_0000);
					this.__x2 = Xse.unpacklo_epi64(this.__x2, value);
				}
				else
				{
					this.w = value.x;
					this.y = value.y;
				}
			}
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong2 wz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 3)));
				}
				else if (BurstArchitecture.IsSIMDSupported)
				{
					return __x2.yx;
				}
				else
				{
					return new ulong2(w, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_inserti128_si256(this, value.yx, 1);
				}
				else if (BurstArchitecture.IsSIMDSupported)
				{
					this.__x2 = value.yx;
				}
				else
				{
					this.w = value.x;
					this.z = value.y;
				}
			}
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong2 ww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Avx2.IsAvx2Supported)
				{
					return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 3)));
				}
				else if (BurstArchitecture.IsSIMDSupported)
                {
					return __x2.yy;
                }
				else
                {
					return new ulong2(w, w);
                }
			}
        }
        #endregion

		
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v256(ulong4 input)
        {
			v256 result;
            if (Avx.IsAvxSupported)
            {
                result = Avx.mm256_undefined_si256();
            }
            else
            {
                result = Uninitialized<v256>.Create();
            }
            
			result.ULong0 = input.__x0.__x0;
			result.ULong1 = input.__x0.__x1;
			result.ULong2 = input.__x2.__x0;
			result.ULong3 = input.__x2.__x1;
            
			return result;
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong4(v256 input) => new ulong4 { __x0 = new ulong2 { __x0 = input.ULong0, __x1 = input.ULong1 }, __x2 = new ulong2 { __x0 = input.ULong2, __x1 = input.ULong3 } };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(bool x) => math.tobyte(x);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(bool4 x) => (ulong4)(mask64x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(Unity.Mathematics.bool4 x) => (ulong4)(mask64x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(mask8x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (ulong4)(mask64x4)x;
            }
            else
            {
                return *(byte4*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(mask16x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (ulong4)(mask64x4)x;
            }
            else
            {
                return *(byte4*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(mask32x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (ulong4)(mask64x4)x;
            }
            else
            {
                return *(byte4*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(mask64x4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_neg_epi64(x);
            }
            else
            {
                return new ulong4((ulong2)x.xy, (ulong2)x.zw);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4(ulong4 x) => (mask64x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool4(ulong4 x) => (mask64x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x4(ulong4 x) => (mask64x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x4(ulong4 x) => (mask64x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4(ulong4 x) => (mask64x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x4(ulong4 x) => x != 0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator ulong4(byte x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(sbyte x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator ulong4(ushort x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(short x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator ulong4(uint x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(int x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(long x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(UInt128 x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(Int128 x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(quarter x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(half x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(float x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(double x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(quadruple x) => (ulong)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(Unity.Mathematics.half x) => (ulong4)(half)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(Unity.Mathematics.half4 x) => (ulong4)(half4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(Unity.Mathematics.float4 x) => (ulong4)(float4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(Unity.Mathematics.double4 x) => (ulong4)(double4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong4(Unity.Mathematics.uint4 x) => (ulong4)(uint4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(Unity.Mathematics.int4 x) => (ulong4)(int4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.half4(ulong4 x) => (half4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float4(ulong4 x) => (float4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double4(ulong4 x) => (double4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint4(ulong4 x) => (uint4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int4(ulong4 x) => (int4)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong4(ulong input) => new ulong4(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(long4 input) => *(ulong4*)&input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong4(uint4 input)
        {
			if (Avx2.IsAvx2Supported)
            {
				return Avx2.mm256_cvtepu32_epi64(input);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return (ulong4)Cast.UInt4ToLong4(input);
            }
            else
            {
                return new ulong4((ulong)input.x, (ulong)input.y, (ulong)input.z, (ulong)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(int4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
				return Avx2.mm256_cvtepi32_epi64(input);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return (ulong4)Cast.Int4ToLong4(input);
            }
            else
            {
                return new ulong4((ulong)input.x, (ulong)input.y, (ulong)input.z, (ulong)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(float4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttps_epu64(input, 4);
            }
            else
            {
                return new ulong4((ulong2)input.xy, (ulong2)input.zw);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(double4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttpd_epu64(input, 4);
            }
            else
            {
                return new ulong4((ulong2)input.xy, (ulong2)input.zw);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint4(ulong4 input)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_cvtepi64_epi32(input);
			}
			else
			{
				return new uint4((uint2)input.__x0, (uint2)input.__x2);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4(ulong4 input)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_cvtepi64_epi32(input);
			}
			else
			{
				return new int4((int2)input.__x0, (int2)input.__x2);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(ulong4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepu64_ps(input, 4);
            }
            else
            {
                return new float4((float2)input.__x0, (float2)input.__x2);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4(ulong4 input)
		{
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepu64_pd(input, 4);
            }
			else
			{
				return new double4((double2)input.__x0, (double2)input.__x2);
			}
		}


        public ulong this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 4);

                if (constexpr.IS_CONST(index))
                {
					if (Avx2.IsAvx2Supported)
					{
					    return Xse.mm256_extract_epi64(this, (byte)index);
					}
					else if (BurstArchitecture.IsSIMDSupported)
					{
                        if (index < 2)
                        {
                            return Xse.extract_epi64(__x0, (byte)index);
                        }
                        else
                        {
                            return Xse.extract_epi64(__x2, (byte)(index - 2));
                        }
                    }
                }

				if (BurstArchitecture.IsBurstCompiled)
				{
					fixed (ulong4* ptr = &this)
					{
						return ((ulong*)ptr)[index];
					}
				}
				else
				{
					return this.GetField<ulong4, ulong>(index);
				}
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 4);

                if (constexpr.IS_CONST(index))
                {
					if (Avx2.IsAvx2Supported)
					{
					    this = Xse.mm256_insert_epi64(this, value, (byte)index);

					    return;
					}
					else if (BurstArchitecture.IsSIMDSupported)
					{
                        if (index < 2)
                        {
                            __x0 = Xse.insert_epi64(__x0, value, (byte)index);
                        }
                        else
                        {
                            __x2 = Xse.insert_epi64(__x2, value, (byte)(index - 2));
                        }

                        return;
                    }
                }

				if (BurstArchitecture.IsBurstCompiled)
				{
					fixed (ulong4* ptr = &this)
					{
						((ulong*)ptr)[index] = value;
					}
				}
				else
				{
					this.SetField(value, index);
				}
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator + (ulong4 left, ulong4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Avx2.mm256_add_epi64(left, right);
			}
			else
			{
				return new ulong4(left.__x0 + right.__x0, left.__x2 + right.__x2);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator - (ulong4 left, ulong4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Avx2.mm256_sub_epi64(left, right);
			}
			else
			{
				return new ulong4(left.__x0 - right.__x0, left.__x2 - right.__x2);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator * (ulong4 left, ulong4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_mullo_epi64(left, right);
			}
			else
			{
				return new ulong4(left.__x0 * right.__x0, left.__x2 * right.__x2);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator / (ulong4 left, ulong4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epu64(left, right, elements: 4);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new ulong4(Xse.div_epu64(left.xy, right.xy, useFPU: true), Xse.div_epu64(left.zw, right.zw, useFPU: false));
			}
			else
			{
				return new ulong4(left.__x0 / right.__x0, left.__x2 / right.__x2);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator % (ulong4 left, ulong4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epu64(left, right, elements: 4);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new ulong4(Xse.rem_epu64(left.xy, right.xy, useFPU: true), Xse.rem_epu64(left.zw, right.zw, useFPU: false));
			}
			else
			{
				return new ulong4(left.__x0 % right.__x0, left.__x2 % right.__x2);
			}
		}

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator + (ulong4 left, byte right) => left + (byte4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator + (ulong4 left, ushort right) => left + (ushort4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator + (ulong4 left, uint right) => left + (uint4)right;
        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong4 operator + (ulong4 left, ulong right) => left + (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator - (ulong4 left, byte right) => left - (byte4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator - (ulong4 left, ushort right) => left - (ushort4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator - (ulong4 left, uint right) => left - (uint4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator - (ulong4 left, ulong right) => left - (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator * (ulong4 left, byte right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator * (ulong4 left, ushort right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator * (ulong4 left, uint right) => right * left;
        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator * (ulong4 left, ulong right)
		{
			if (Avx2.IsAvx2Supported)
			{
				if (constexpr.IS_CONST(right))
				{
					return new ulong4(left.x * right, left.y * right, left.z * right, left.w * right);
				}
			}

            return new ulong4(left.xy * right, left.zw * right);
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator / (ulong4 left, byte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left / (ulong)right;
                }
            }

            return left / (byte4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator / (ulong4 left, ushort right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left / (ulong)right;
                }
            }

            return left / (ushort4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator / (ulong4 left, uint right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left / (ulong)right;
                }
            }

            return left / (uint4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator / (ulong4 left, ulong right)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.mm256_constdiv_epu64(left, right, 4);
                }
            }

            return new ulong4(left.xy / right, left.zw / right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator % (ulong4 left, byte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left % (ulong)right;
                }
            }

            return left % (byte4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator % (ulong4 left, ushort right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left % (ulong)right;
                }
            }

            return left % (ushort4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator % (ulong4 left, uint right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left % (ulong)right;
                }
            }

            return left % (uint4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator % (ulong4 left, ulong right)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.mm256_constrem_epu64(left, right, 4);
                }
            }

            return new ulong4(left.xy % right, left.zw % right);
        }
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator + (byte left, ulong4 right) => (byte4)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator + (ushort left, ulong4 right) => (ushort4)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator + (uint left, ulong4 right) => (uint4)left + right;
        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong4 operator + (ulong left, ulong4 right) => (ulong4)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator - (byte left, ulong4 right) => (byte4)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator - (ushort left, ulong4 right) => (ushort4)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator - (uint left, ulong4 right) => (uint4)left - right;
        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong4 operator - (ulong left, ulong4 right) => (ulong4)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator * (byte left, ulong4 right) => (ulong)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator * (ushort left, ulong4 right) => (ulong)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator * (uint left, ulong4 right) => (ulong)left * right;
        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong4 operator * (ulong left, ulong4 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator / (byte left, ulong4 right) => (byte4)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator / (ushort left, ulong4 right) => (ushort4)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator / (uint left, ulong4 right) => (uint4)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator / (ulong left, ulong4 right) => (ulong4)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator % (byte left, ulong4 right) => (byte4)left % right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator % (ushort left, ulong4 right) => (ushort4)left % right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator % (uint left, ulong4 right) => (uint4)left % right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator % (ulong left, ulong4 right) => (ulong4)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator + (ulong4 left, byte4 right) => left + (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator + (byte4 left, ulong4 right) => (ulong4)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator - (ulong4 left, byte4 right) => left - (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator - (byte4 left, ulong4 right) => (ulong4)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator * (ulong4 left, byte4 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_mullo_epi64(left, (ulong4)right, 4, unsigned_B_lessequalU32Max: true);
            }
            else
            {
                return new ulong4(left.xy * right.xy, left.zw * right.zw);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator * (byte4 left, ulong4 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator / (byte4 left, ulong4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epu64(Xse.mm256_cvtepu8_pd(left), right, elements: 4, aIsDbl: true, aLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new ulong4(Xse.div_epu64(Xse.cvtepu8_pd(left), right.xy, useFPU: true, aIsDbl: true, aLEu32max: true), Xse.div_epu64(Xse.cvtepu8_epi64(left.zw), right.zw, useFPU: false, aIsDbl: false));
			}
			else
			{
				return new ulong4(left.xy / right.__x0, left.zw / right.__x2);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator / (ulong4 left, byte4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epu64(left, Xse.mm256_cvtepu8_pd(right), elements: 4, bIsDbl: true, bLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new ulong4(Xse.div_epu64(left.xy, Xse.cvtepu8_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true), Xse.div_epu64(left.zw, Xse.cvtepu8_epi64(right.zw), useFPU: false, bIsDbl: false));
			}
			else
			{
				return new ulong4(left.__x0 / right.xy, left.__x2 / right.zw);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator % (byte4 left, ulong4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epu64(Xse.mm256_cvtepu8_pd(left), right, elements: 4, aIsDbl: true, aLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new ulong4(Xse.rem_epu64(Xse.cvtepu8_pd(left), right.xy, useFPU: true, aIsDbl: true, aLEu32max: true), Xse.rem_epu64(Xse.cvtepu8_epi64(left.zw), right.zw, useFPU: false, aIsDbl: false));
			}
			else
			{
				return new ulong4(left.xy % right.__x0, left.zw % right.__x2);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator % (ulong4 left, byte4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epu64(left, Xse.mm256_cvtepu8_pd(right), elements: 4, bIsDbl: true, bLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new ulong4(Xse.rem_epu64(left.xy, Xse.cvtepu8_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true), Xse.rem_epu64(left.zw, Xse.cvtepu8_epi64(right.zw), useFPU: false, bIsDbl: false));
			}
			else
			{
				return new ulong4(left.__x0 % right.xy, left.__x2 % right.zw);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator + (ulong4 left, ushort4 right) => left + (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator + (ushort4 left, ulong4 right) => (ulong4)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator - (ulong4 left, ushort4 right) => left - (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator - (ushort4 left, ulong4 right) => (ulong4)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator * (ulong4 left, ushort4 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_mullo_epi64(left, (ulong4)right, 4, unsigned_B_lessequalU32Max: true);
            }
            else
            {
                return new ulong4(left.xy * right.xy, left.zw * right.zw);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator * (ushort4 left, ulong4 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator / (ushort4 left, ulong4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epu64(Xse.mm256_cvtepu16_pd(left), right, elements: 4, aIsDbl: true, aLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new ulong4(Xse.div_epu64(Xse.cvtepu16_pd(left), right.xy, useFPU: true, aIsDbl: true, aLEu32max: true), Xse.div_epu64(Xse.cvtepu16_epi64(left.zw), right.zw, useFPU: false, aIsDbl: false));
			}
			else
			{
				return new ulong4(left.xy / right.__x0, left.zw / right.__x2);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator / (ulong4 left, ushort4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epu64(left, Xse.mm256_cvtepu16_pd(right), elements: 4, bIsDbl: true, bLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new ulong4(Xse.div_epu64(left.xy, Xse.cvtepu16_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true), Xse.div_epu64(left.zw, Xse.cvtepu16_epi64(right.zw), useFPU: false, bIsDbl: false));
			}
			else
			{
				return new ulong4(left.__x0 / right.xy, left.__x2 / right.zw);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator % (ushort4 left, ulong4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epu64(Xse.mm256_cvtepu16_pd(left), right, elements: 4, aIsDbl: true, aLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new ulong4(Xse.rem_epu64(Xse.cvtepu16_pd(left), right.xy, useFPU: true, aIsDbl: true, aLEu32max: true), Xse.rem_epu64(Xse.cvtepu16_epi64(left.zw), right.zw, useFPU: false, aIsDbl: false));
			}
			else
			{
				return new ulong4(left.xy % right.__x0, left.zw % right.__x2);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator % (ulong4 left, ushort4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epu64(left, Xse.mm256_cvtepu16_pd(right), elements: 4, bIsDbl: true, bLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new ulong4(Xse.rem_epu64(left.xy, Xse.cvtepu16_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true), Xse.rem_epu64(left.zw, Xse.cvtepu16_epi64(right.zw), useFPU: false, bIsDbl: false));
			}
			else
			{
				return new ulong4(left.__x0 % right.xy, left.__x2 % right.zw);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator + (ulong4 left, uint4 right) => left + (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator + (uint4 left, ulong4 right) => (ulong4)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator - (ulong4 left, uint4 right) => left - (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator - (uint4 left, ulong4 right) => (ulong4)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator * (ulong4 left, uint4 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_mullo_epi64(left, (ulong4)right, 4, unsigned_B_lessequalU32Max: true);
            }
            else
            {
                return new ulong4(left.xy * right.xy, left.zw * right.zw);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator * (uint4 left, ulong4 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator / (uint4 left, ulong4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epu64(Xse.mm256_cvtepu32_pd(left), right, elements: 4, aIsDbl: true, aLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new ulong4(Xse.div_epu64(Xse.cvtepu32_pd(left), right.xy, useFPU: true, aIsDbl: true, aLEu32max: true), Xse.div_epu64(Xse.cvtepu32_epi64(left.zw), right.zw, useFPU: false, aIsDbl: false));
			}
			else
			{
				return new ulong4(left.xy / right.__x0, left.zw / right.__x2);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator / (ulong4 left, uint4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epu64(left, Xse.mm256_cvtepu32_pd(right), elements: 4, bIsDbl: true, bLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new ulong4(Xse.div_epu64(left.xy, Xse.cvtepu32_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true), Xse.div_epu64(left.zw, Xse.cvtepu32_epi64(right.zw), useFPU: false, bIsDbl: false));
			}
			else
			{
				return new ulong4(left.__x0 / right.xy, left.__x2 / right.zw);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator % (uint4 left, ulong4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epu64(Xse.mm256_cvtepu32_pd(left), right, elements: 4, aIsDbl: true, aLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new ulong4(Xse.rem_epu64(Xse.cvtepu32_pd(left), right.xy, useFPU: true, aIsDbl: true, aLEu32max: true), Xse.rem_epu64(Xse.cvtepu32_epi64(left.zw), right.zw, useFPU: false, aIsDbl: false));
			}
			else
			{
				return new ulong4(left.xy % right.__x0, left.zw % right.__x2);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator % (ulong4 left, uint4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epu64(left, Xse.mm256_cvtepu32_pd(right), elements: 4, bIsDbl: true, bLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new ulong4(Xse.rem_epu64(left.xy, Xse.cvtepu32_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true), Xse.rem_epu64(left.zw, Xse.cvtepu32_epi64(right.zw), useFPU: false, bIsDbl: false));
			}
			else
			{
				return new ulong4(left.__x0 % right.xy, left.__x2 % right.zw);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator + (ulong4 left, Unity.Mathematics.uint4 right) => left + (uint4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator - (ulong4 left, Unity.Mathematics.uint4 right) => left - (uint4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator * (ulong4 left, Unity.Mathematics.uint4 right) => left * (uint4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator / (ulong4 left, Unity.Mathematics.uint4 right) => left / (uint4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator % (ulong4 left, Unity.Mathematics.uint4 right) => left % (uint4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator + (Unity.Mathematics.uint4 left, ulong4 right) => (uint4)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator - (Unity.Mathematics.uint4 left, ulong4 right) => (uint4)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator * (Unity.Mathematics.uint4 left, ulong4 right) => (uint4)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator / (Unity.Mathematics.uint4 left, ulong4 right) => (uint4)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator % (Unity.Mathematics.uint4 left, ulong4 right) => (uint4)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (ulong4 left, Unity.Mathematics.float4 right) => left + (float4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (ulong4 left, Unity.Mathematics.float4 right) => left - (float4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (ulong4 left, Unity.Mathematics.float4 right) => left * (float4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (ulong4 left, Unity.Mathematics.float4 right) => left / (float4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (ulong4 left, Unity.Mathematics.float4 right) => left % (float4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (Unity.Mathematics.float4 left, ulong4 right) => (float4)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (Unity.Mathematics.float4 left, ulong4 right) => (float4)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (Unity.Mathematics.float4 left, ulong4 right) => (float4)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (Unity.Mathematics.float4 left, ulong4 right) => (float4)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (Unity.Mathematics.float4 left, ulong4 right) => (float4)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator + (ulong4 left, Unity.Mathematics.double4 right) => left + (double4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator - (ulong4 left, Unity.Mathematics.double4 right) => left - (double4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator * (ulong4 left, Unity.Mathematics.double4 right) => left * (double4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator / (ulong4 left, Unity.Mathematics.double4 right) => left / (double4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator % (ulong4 left, Unity.Mathematics.double4 right) => left % (double4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator + (Unity.Mathematics.double4 left, ulong4 right) => (double4)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator - (Unity.Mathematics.double4 left, ulong4 right) => (double4)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator * (Unity.Mathematics.double4 left, ulong4 right) => (double4)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator / (Unity.Mathematics.double4 left, ulong4 right) => (double4)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator % (Unity.Mathematics.double4 left, ulong4 right) => (double4)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator & (ulong4 left, ulong4 right)
		{
			if (Avx.IsAvxSupported)
			{
				return Avx.mm256_and_ps(left, right);
			}
			else
			{
				return new ulong4(left.xy & right.xy, left.zw & right.zw);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator | (ulong4 left, ulong4 right)
		{
			if (Avx.IsAvxSupported)
			{
				return Avx.mm256_or_ps(left, right);
			}
			else
			{
				return new ulong4(left.xy | right.xy, left.zw | right.zw);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator ^ (ulong4 left, ulong4 right)
		{
			if (Avx.IsAvxSupported)
			{
				return Avx.mm256_xor_ps(left, right);
			}
			else
			{
				return new ulong4(left.xy ^ right.xy, left.zw ^ right.zw);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator & (ulong4 left, byte4 right) => left & (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator | (ulong4 left, byte4 right) => left | (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator ^ (ulong4 left, byte4 right) => left ^ (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator & (byte4 left, ulong4 right) => (ulong4)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator | (byte4 left, ulong4 right) => (ulong4)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator ^ (byte4 left, ulong4 right) => (ulong4)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator & (ulong4 left, ushort4 right) => left & (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator | (ulong4 left, ushort4 right) => left | (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator ^ (ulong4 left, ushort4 right) => left ^ (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator & (ushort4 left, ulong4 right) => (ulong4)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator | (ushort4 left, ulong4 right) => (ulong4)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator ^ (ushort4 left, ulong4 right) => (ulong4)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator & (ulong4 left, uint4 right) => left & (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator | (ulong4 left, uint4 right) => left | (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator ^ (ulong4 left, uint4 right) => left ^ (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator & (uint4 left, ulong4 right) => (ulong4)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator | (uint4 left, ulong4 right) => (ulong4)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator ^ (uint4 left, ulong4 right) => (ulong4)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator & (ulong4 left, Unity.Mathematics.uint4 right) => left & (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator | (ulong4 left, Unity.Mathematics.uint4 right) => left | (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator ^ (ulong4 left, Unity.Mathematics.uint4 right) => left ^ (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator & (Unity.Mathematics.uint4 left, ulong4 right) => (ulong4)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator | (Unity.Mathematics.uint4 left, ulong4 right) => (ulong4)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator ^ (Unity.Mathematics.uint4 left, ulong4 right) => (ulong4)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator & (ulong4 left, byte right) => left & (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator | (ulong4 left, byte right) => left | (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator ^ (ulong4 left, byte right) => left ^ (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator & (byte left, ulong4 right) => (ulong4)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator | (byte left, ulong4 right) => (ulong4)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator ^ (byte left, ulong4 right) => (ulong4)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator & (ulong4 left, ushort right) => left & (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator | (ulong4 left, ushort right) => left | (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator ^ (ulong4 left, ushort right) => left ^ (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator & (ushort left, ulong4 right) => (ulong4)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator | (ushort left, ulong4 right) => (ulong4)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator ^ (ushort left, ulong4 right) => (ulong4)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator & (ulong4 left, uint right) => left & (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator | (ulong4 left, uint right) => left | (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator ^ (ulong4 left, uint right) => left ^ (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator & (uint left, ulong4 right) => (ulong4)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator | (uint left, ulong4 right) => (ulong4)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator ^ (uint left, ulong4 right) => (ulong4)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator & (ulong4 left, ulong right) => left & (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator | (ulong4 left, ulong right) => left | (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator ^ (ulong4 left, ulong right) => left ^ (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator & (ulong left, ulong4 right) => (ulong4)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator | (ulong left, ulong4 right) => (ulong4)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator ^ (ulong left, ulong4 right) => (ulong4)left ^ right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator ++ (ulong4 x)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_inc_epi64(x);
			}
			else
			{
				return new ulong4(x.__x0 + 1, x.__x2 + 1);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator -- (ulong4 x)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_dec_epi64(x);
			}
			else
			{
				return new ulong4(x.__x0 - 1, x.__x2 - 1);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator ~ (ulong4 x)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_not_si256(x);
			}
			else
			{
				return new ulong4(~x.__x0, ~x.__x2);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator << (ulong4 x, int n)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_slli_epi64(x, n);
			}
			else
			{
				return new ulong4(x.__x0 << n, x.__x2 << n);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator >> (ulong4 x, int n)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_srli_epi64(x, n);
			}
			else
			{
				return new ulong4(x.__x0 >> n, x.__x2 >> n);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (ulong4 left, ulong4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Avx2.mm256_cmpeq_epi64(left, right);
			}
			else
			{
				return new mask64x4(left.__x0 == right.__x0, left.__x2 == right.__x2);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (ulong4 left, ulong4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_cmplt_epu64(left, right);
			}
			else
			{
				return new mask64x4(left.__x0 < right.__x0, left.__x2 < right.__x2);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (ulong4 left, ulong4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_cmpgt_epu64(left, right);
			}
			else
			{
				return new mask64x4(left.__x0 > right.__x0, left.__x2 > right.__x2);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (ulong4 left, ulong4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_not_si256(Avx2.mm256_cmpeq_epi64(left, right));
			}
			else
			{
				return new mask64x4(left.__x0 != right.__x0, left.__x2 != right.__x2);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (ulong4 left, ulong4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_not_si256(Xse.mm256_cmpgt_epu64(left, right));
			}
			else
			{
				return new mask64x4(left.__x0 <= right.__x0, left.__x2 <= right.__x2);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (ulong4 left, ulong4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_not_si256(Xse.mm256_cmplt_epu64(left, right));
			}
			else
			{
				return new mask64x4(left.__x0 >= right.__x0, left.__x2 >= right.__x2);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (ulong4 left, byte right) => left == (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (byte left, ulong4 right) => (ulong4)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (ulong4 left, byte right) => left != (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (byte left, ulong4 right) => (ulong4)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (ulong4 left, byte right) => left < (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (byte left, ulong4 right) => (ulong4)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (ulong4 left, byte right) => left > (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (byte left, ulong4 right) => (ulong4)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (ulong4 left, byte right) => left <= (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (byte left, ulong4 right) => (ulong4)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (ulong4 left, byte right) => left >= (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (byte left, ulong4 right) => (ulong4)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (ulong4 left, ushort right) => left == (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (ushort left, ulong4 right) => (ulong4)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (ulong4 left, ushort right) => left != (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (ushort left, ulong4 right) => (ulong4)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (ulong4 left, ushort right) => left < (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (ushort left, ulong4 right) => (ulong4)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (ulong4 left, ushort right) => left > (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (ushort left, ulong4 right) => (ulong4)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (ulong4 left, ushort right) => left <= (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (ushort left, ulong4 right) => (ulong4)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (ulong4 left, ushort right) => left >= (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (ushort left, ulong4 right) => (ulong4)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (ulong4 left, uint right) => left == (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (uint left, ulong4 right) => (ulong4)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (ulong4 left, uint right) => left != (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (uint left, ulong4 right) => (ulong4)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (ulong4 left, uint right) => left < (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (uint left, ulong4 right) => (ulong4)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (ulong4 left, uint right) => left > (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (uint left, ulong4 right) => (ulong4)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (ulong4 left, uint right) => left <= (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (uint left, ulong4 right) => (ulong4)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (ulong4 left, uint right) => left >= (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (uint left, ulong4 right) => (ulong4)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (ulong4 left, ulong right) => left == (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (ulong left, ulong4 right) => (ulong4)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (ulong4 left, ulong right) => left != (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (ulong left, ulong4 right) => (ulong4)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (ulong4 left, ulong right) => left < (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (ulong left, ulong4 right) => (ulong4)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (ulong4 left, ulong right) => left > (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (ulong left, ulong4 right) => (ulong4)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (ulong4 left, ulong right) => left <= (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (ulong left, ulong4 right) => (ulong4)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (ulong4 left, ulong right) => left >= (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (ulong left, ulong4 right) => (ulong4)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (ulong4 left, byte4 right) => left == (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (byte4 left, ulong4 right) => (ulong4)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (ulong4 left, byte4 right) => left != (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (byte4 left, ulong4 right) => (ulong4)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (ulong4 left, byte4 right) => left < (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (byte4 left, ulong4 right) => (ulong4)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (ulong4 left, byte4 right) => left > (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (byte4 left, ulong4 right) => (ulong4)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (ulong4 left, byte4 right) => left <= (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (byte4 left, ulong4 right) => (ulong4)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (ulong4 left, byte4 right) => left >= (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (byte4 left, ulong4 right) => (ulong4)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (ulong4 left, ushort4 right) => left == (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (ushort4 left, ulong4 right) => (ulong4)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (ulong4 left, ushort4 right) => left != (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (ushort4 left, ulong4 right) => (ulong4)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (ulong4 left, ushort4 right) => left < (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (ushort4 left, ulong4 right) => (ulong4)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (ulong4 left, ushort4 right) => left > (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (ushort4 left, ulong4 right) => (ulong4)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (ulong4 left, ushort4 right) => left <= (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (ushort4 left, ulong4 right) => (ulong4)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (ulong4 left, ushort4 right) => left >= (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (ushort4 left, ulong4 right) => (ulong4)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (ulong4 left, uint4 right) => left == (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (uint4 left, ulong4 right) => (ulong4)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (ulong4 left, uint4 right) => left != (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (uint4 left, ulong4 right) => (ulong4)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (ulong4 left, uint4 right) => left < (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (uint4 left, ulong4 right) => (ulong4)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (ulong4 left, uint4 right) => left > (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (uint4 left, ulong4 right) => (ulong4)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (ulong4 left, uint4 right) => left <= (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (uint4 left, ulong4 right) => (ulong4)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (ulong4 left, uint4 right) => left >= (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (uint4 left, ulong4 right) => (ulong4)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (ulong4 left, Unity.Mathematics.uint4 right) => left == (uint4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (Unity.Mathematics.uint4 left, ulong4 right) => (uint4)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (ulong4 left, Unity.Mathematics.uint4 right) => left != (uint4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (Unity.Mathematics.uint4 left, ulong4 right) => (uint4)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (ulong4 left, Unity.Mathematics.uint4 right) => left < (uint4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (Unity.Mathematics.uint4 left, ulong4 right) => (uint4)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (ulong4 left, Unity.Mathematics.uint4 right) => left > (uint4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (Unity.Mathematics.uint4 left, ulong4 right) => (uint4)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (ulong4 left, Unity.Mathematics.uint4 right) => left <= (uint4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (Unity.Mathematics.uint4 left, ulong4 right) => (uint4)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (ulong4 left, Unity.Mathematics.uint4 right) => left >= (uint4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (Unity.Mathematics.uint4 left, ulong4 right) => (uint4)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (ulong4 left, Unity.Mathematics.float4 right) => left == (float4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (Unity.Mathematics.float4 left, ulong4 right) => (float4)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (ulong4 left, Unity.Mathematics.float4 right) => left != (float4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (Unity.Mathematics.float4 left, ulong4 right) => (float4)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (ulong4 left, Unity.Mathematics.float4 right) => left < (float4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (Unity.Mathematics.float4 left, ulong4 right) => (float4)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (ulong4 left, Unity.Mathematics.float4 right) => left > (float4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (Unity.Mathematics.float4 left, ulong4 right) => (float4)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (ulong4 left, Unity.Mathematics.float4 right) => left <= (float4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (Unity.Mathematics.float4 left, ulong4 right) => (float4)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (ulong4 left, Unity.Mathematics.float4 right) => left >= (float4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (Unity.Mathematics.float4 left, ulong4 right) => (float4)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (ulong4 left, Unity.Mathematics.double4 right) => left == (double4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (Unity.Mathematics.double4 left, ulong4 right) => (double4)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (ulong4 left, Unity.Mathematics.double4 right) => left != (double4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (Unity.Mathematics.double4 left, ulong4 right) => (double4)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (ulong4 left, Unity.Mathematics.double4 right) => left < (double4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (Unity.Mathematics.double4 left, ulong4 right) => (double4)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (ulong4 left, Unity.Mathematics.double4 right) => left > (double4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (Unity.Mathematics.double4 left, ulong4 right) => (double4)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (ulong4 left, Unity.Mathematics.double4 right) => left <= (double4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (Unity.Mathematics.double4 left, ulong4 right) => (double4)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (ulong4 left, Unity.Mathematics.double4 right) => left >= (double4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (Unity.Mathematics.double4 left, ulong4 right) => (double4)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(ulong4 other)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_alltrue_epi256<ulong>(Avx2.mm256_cmpeq_epi64(this, other));
			}
			else
			{
				return this.__x0.Equals(other.__x0) & this.__x2.Equals(other.__x2);
			}
		}

        public override bool Equals(object obj) => obj is ulong4 converted && this.Equals(converted);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        public override string ToString() => $"ulong4({x}, {y}, {z}, {w})";
        public string ToString(string format, IFormatProvider formatProvider) => $"ulong4({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)}, {w.ToString(format, formatProvider)})";
    }
}