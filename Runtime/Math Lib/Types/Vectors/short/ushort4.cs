using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.math;

namespace MaxMath
{
#if DEBUG
    internal sealed class ushort4DebuggerProxy
    {
	    public ushort x;
	    public ushort y;
	    public ushort z;
	    public ushort w;
        
	    public ushort4DebuggerProxy(ushort4 v)
	    {
	    	x = v.x;
	    	y = v.y;
	    	z = v.z;
	    	w = v.w;
	    }
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(ushort4DebuggerProxy))]
#endif
    [Serializable]
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public struct ushort4 : IEquatable<ushort4>, IFormattable
	{
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal ulong __x0;
		
        public ref ushort x { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(ushort4* ptr = &this) { return ref *((ushort*)ptr + 0); } } }
        public ref ushort y { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(ushort4* ptr = &this) { return ref *((ushort*)ptr + 1); } } }
        public ref ushort z { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(ushort4* ptr = &this) { return ref *((ushort*)ptr + 2); } } }
        public ref ushort w { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(ushort4* ptr = &this) { return ref *((ushort*)ptr + 3); } } }


        public static ushort4 zero => default;


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(ushort x, ushort y, ushort z, ushort w)
        {
            if (BurstArchitecture.IsSIMDSupported)
			{
				this = Xse.set_epi16(0, 0, 0, 0, (short)w, (short)z, (short)y, (short)x);
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
			if (BurstArchitecture.IsSIMDSupported)
			{
				this = Xse.shufflelo_epi16(Xse.cvtsi32_si128(xyzw), Sse.SHUFFLE(0, 0, 0, 0));
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
            if (BurstArchitecture.IsSIMDSupported)
			{
				this = Xse.insert_epi16(Xse.insert_epi16(xy, z, 2), w, 3);
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
			if (BurstArchitecture.IsSIMDSupported)
			{
				this = Xse.insert_epi16(Xse.insert_epi16(Xse.bslli_si128(yz, sizeof(ushort)), x, 0), w, 3);
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
			if (BurstArchitecture.IsSIMDSupported)
			{
				this = Xse.unpacklo_epi32(new ushort2(x, y), zw);
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
			if (BurstArchitecture.IsSIMDSupported)
			{
				this = Xse.unpacklo_epi32(xy, zw);
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
			if (BurstArchitecture.IsSIMDSupported)
			{
				this = Xse.insert_epi16(xyz, w, 3);
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
			if (BurstArchitecture.IsSIMDSupported)
			{
				this = Xse.insert_epi16(Xse.bslli_si128(yzw, sizeof(ushort)), x, 0);
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(bool v)
        {
            this = (ushort4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(bool4 v)
        {
            this = (ushort4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(mask8x4 v)
        {
            this = (ushort4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(mask16x4 v)
        {
            this = (ushort4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(mask32x4 v)
        {
            this = (ushort4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(mask64x4 v)
        {
            this = (ushort4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(byte v)
        {
            this = (ushort4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(byte4 v)
        {
            this = (ushort4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(sbyte v)
        {
            this = (ushort4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(sbyte4 v)
        {
            this = (ushort4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(ushort4 v)
        {
            this = (ushort4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(short v)
        {
            this = (ushort4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(short4 v)
        {
            this = (ushort4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(uint v)
        {
            this = (ushort4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(uint4 v)
        {
            this = (ushort4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(int v)
        {
            this = (ushort4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(int4 v)
        {
            this = (ushort4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(ulong v)
        {
            this = (ushort4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(ulong4 v)
        {
            this = (ushort4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(long v)
        {
            this = (ushort4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(long4 v)
        {
            this = (ushort4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(UInt128 v)
        {
            this = (ushort4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(Int128 v)
        {
            this = (ushort4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(quarter v)
        {
            this = (ushort4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(quarter4 v)
        {
            this = (ushort4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(half v)
        {
            this = (ushort4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(half4 v)
        {
            this = (ushort4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(float v)
        {
            this = (ushort4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(float4 v)
        {
            this = (ushort4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(double v)
        {
            this = (ushort4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(double4 v)
        {
            this = (ushort4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(quadruple v)
        {
            this = (ushort4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(Unity.Mathematics.bool4 v)
        {
            this = (ushort4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(Unity.Mathematics.uint4 v)
        {
            this = (ushort4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(Unity.Mathematics.int4 v)
        {
            this = (ushort4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(Unity.Mathematics.half v)
        {
            this = (ushort4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(Unity.Mathematics.half4 v)
        {
            this = (ushort4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(Unity.Mathematics.float4 v)
        {
            this = (ushort4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(Unity.Mathematics.double4 v)
        {
            this = (ushort4)v;
        }

        #region Shuffle
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 0));
				}
				else
				{
					return new ushort4(x, x, x, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 0, 0));
				}
				else
				{
					return new ushort4(x, x, x, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 0, 0));
				}
				else
				{
					return new ushort4(x, x, x, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xxxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 0, 0));
				}
				else
				{
					return new ushort4(x, x, x, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 0, 0));
				}
				else
				{
					return new ushort4(x, x, y, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 0, 0));
				}
				else
				{
					return new ushort4(x, x, y, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 0, 0));
				}
				else
				{
					return new ushort4(x, x, y, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xxyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 0));
				}
				else
				{
					return new ushort4(x, x, y, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 0, 0));
				}
				else
				{
					return new ushort4(x, x, z, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 0, 0));
				}
				else
				{
					return new ushort4(x, x, z, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 0, 0));
				}
				else
				{
					return new ushort4(x, x, z, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xxzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 0));
				}
				else
				{
					return new ushort4(x, x, z, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xxwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 0, 0));
				}
				else
				{
					return new ushort4(x, x, w, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xxwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 0, 0));
				}
				else
				{
					return new ushort4(x, x, w, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xxwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 0, 0));
				}
				else
				{
					return new ushort4(x, x, w, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xxww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 0));
				}
				else
				{
					return new ushort4(x, x, w, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 1, 0));
				}
				else
				{
					return new ushort4(x, y, x, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 1, 0));
				}
				else
				{
					return new ushort4(x, y, x, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 1, 0));
				}
				else
				{
					return new ushort4(x, y, x, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 0));
				}
				else
				{
					return new ushort4(x, y, x, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 1, 0));
				}
				else
				{
					return new ushort4(x, y, y, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 1, 0));
				}
				else
				{
					return new ushort4(x, y, y, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 1, 0));
				}
				else
				{
					return new ushort4(x, y, y, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 0));
				}
				else
				{
					return new ushort4(x, y, y, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 1, 0));
				}
				else
				{
					return new ushort4(x, y, z, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 1, 0));
				}
				else
				{
					return new ushort4(x, y, z, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 1, 0));
				}
				else
				{
					return new ushort4(x, y, z, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xyzw
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
        public ushort4 xywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 1, 0));
				}
				else
				{
					return new ushort4(x, y, w, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 1, 0));
				}
				else
				{
					return new ushort4(x, y, w, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			ushort4 xywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 1, 0));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 0));
				}
				else
				{
					return new ushort4(x, y, w, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 2, 0));
				}
				else
				{
					return new ushort4(x, z, x, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 2, 0));
				}
				else
				{
					return new ushort4(x, z, x, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 2, 0));
				}
				else
				{
					return new ushort4(x, z, x, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 0));
				}
				else
				{
					return new ushort4(x, z, x, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 2, 0));
				}
				else
				{
					return new ushort4(x, z, y, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 2, 0));
				}
				else
				{
					return new ushort4(x, z, y, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 2, 0));
				}
				else
				{
					return new ushort4(x, z, y, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			ushort4 xzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 0));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 2, 0));
				}
				else
				{
					return new ushort4(x, z, z, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 2, 0));
				}
				else
				{
					return new ushort4(x, z, z, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 2, 0));
				}
				else
				{
					return new ushort4(x, z, z, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 0));
				}
				else
				{
					return new ushort4(x, z, z, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 2, 0)); ;
				}
				else
				{
					return new ushort4(x, z, w, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			ushort4 xzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 2, 0));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 2, 0));
				}
				else
				{
					return new ushort4(x, z, w, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 0));
				}
				else
				{
					return new ushort4(x, z, w, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xwxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 3, 0));
				}
				else
				{
					return new ushort4(x, w, x, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xwxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 3, 0));
				}
				else
				{
					return new ushort4(x, w, x, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xwxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 3, 0));
				}
				else
				{
					return new ushort4(x, w, x, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xwxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 3, 0));
				}
				else
				{
					return new ushort4(x, w, x, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xwyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 3, 0));
				}
				else
				{
					return new ushort4(x, w, y, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xwyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 3, 0));
				}
				else
				{
					return new ushort4(x, w, y, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			ushort4 xwyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 3, 0));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xwyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 3, 0));
				}
				else
				{
					return new ushort4(x, w, y, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xwzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 3, 0));
				}
				else
				{
					return new ushort4(x, w, z, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			ushort4 xwzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 3, 0));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xwzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 3, 0));
				}
				else
				{
					return new ushort4(x, w, z, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xwzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 3, 0));
				}
				else
				{
					return new ushort4(x, w, z, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xwwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 3, 0));
				}
				else
				{
					return new ushort4(x, w, w, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xwwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 3, 0));
				}
				else
				{
					return new ushort4(x, w, w, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xwwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 3, 0));
				}
				else
				{
					return new ushort4(x, w, w, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xwww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 0));
				}
				else
				{
					return new ushort4(x, w, w, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yxxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 1));
				}
				else
				{
					return new ushort4(y, x, x, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yxxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 0, 1));
				}
				else
				{
					return new ushort4(y, x, x, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yxxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 0, 1));
				}
				else
				{
					return new ushort4(y, x, x, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yxxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 0, 1));
				}
				else
				{
					return new ushort4(y, x, x, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yxyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 0, 1));
				}
				else
				{
					return new ushort4(y, x, y, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yxyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 0, 1));
				}
				else
				{
					return new ushort4(y, x, y, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yxyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 0, 1));
				}
				else
				{
					return new ushort4(y, x, y, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yxyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 1));
				}
				else
				{
					return new ushort4(y, x, y, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yxzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 0, 1));
				}
				else
				{
					return new ushort4(y, x, z, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yxzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 0, 1));
				}
				else
				{
					return new ushort4(y, x, z, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yxzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 0, 1));
				}
				else
				{
					return new ushort4(y, x, z, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			ushort4 yxzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 1));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yxwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 0, 1));
				}
				else
				{
					return new ushort4(y, x, w, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yxwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 0, 1));
				}
				else
				{
					return new ushort4(y, x, w, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			ushort4 yxwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 0, 1));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yxww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 1));
				}
				else
				{
					return new ushort4(y, x, w, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yyxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 1, 1));
				}
				else
				{
					return new ushort4(y, y, x, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yyxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 1, 1));
				}
				else
				{
					return new ushort4(y, y, x, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yyxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 1, 1));
				}
				else
				{
					return new ushort4(y, y, x, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yyxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 1));
				}
				else
				{
					return new ushort4(y, y, x, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yyyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 1, 1));
				}
				else
				{
					return new ushort4(y, y, y, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yyyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 1, 1));
				}
				else
				{
					return new ushort4(y, y, y, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yyyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 1, 1));
				}
				else
				{
					return new ushort4(y, y, y, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yyyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 1));
				}
				else
				{
					return new ushort4(y, y, y, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yyzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 1, 1));
				}
				else
				{
					return new ushort4(y, y, z, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yyzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 1, 1));
				}
				else
				{
					return new ushort4(y, y, z, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yyzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 1, 1));
				}
				else
				{
					return new ushort4(y, y, z, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yyzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 1, 1));
				}
				else
				{
					return new ushort4(y, y, z, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yywx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 1, 1));
				}
				else
				{
					return new ushort4(y, y, w, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yywy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 1, 1));
				}
				else
				{
					return new ushort4(y, y, w, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yywz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 1, 1));
				}
				else
				{
					return new ushort4(y, y, w, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yyww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 1));
				}
				else
				{
					return new ushort4(y, y, w, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yzxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 2, 1));
				}
				else
				{
					return new ushort4(y, z, x, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yzxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 2, 1));
				}
				else
				{
					return new ushort4(y, z, x, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yzxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 2, 1));
				}
				else
				{
					return new ushort4(y, z, x, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			ushort4 yzxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 1));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yzyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 2, 1));
				}
				else
				{
					return new ushort4(y, z, y, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yzyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 2, 1));
				}
				else
				{
					return new ushort4(y, z, y, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yzyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 2, 1));
				}
				else
				{
					return new ushort4(y, z, y, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yzyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 1));
				}
				else
				{
					return new ushort4(y, z, y, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yzzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 2, 1));
				}
				else
				{
					return new ushort4(y, z, z, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yzzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 2, 1));
				}
				else
				{
					return new ushort4(y, z, z, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yzzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 2, 1));
				}
				else
				{
					return new ushort4(y, z, z, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yzzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 1));
				}
				else
				{
					return new ushort4(y, z, z, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			ushort4 yzwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 2, 1)); ;
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yzwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 2, 1));
				}
				else
				{
					return new ushort4(y, z, w, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yzwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 2, 1));
				}
				else
				{
					return new ushort4(y, z, w, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yzww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 1));
				}
				else
				{
					return new ushort4(y, z, w, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 ywxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 3, 1));
				}
				else
				{
					return new ushort4(y, w, x, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 ywxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 3, 1));
				}
				else
				{
					return new ushort4(y, w, x, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			ushort4 ywxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 3, 1));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 ywxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 3, 1));
				}
				else
				{
					return new ushort4(y, w, x, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 ywyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 3, 1));
				}
				else
				{
					return new ushort4(y, w, y, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 ywyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 3, 1));
				}
				else
				{
					return new ushort4(y, w, y, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 ywyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 3, 1));
				}
				else
				{
					return new ushort4(y, w, y, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 ywyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 3, 1));
				}
				else
				{
					return new ushort4(y, w, y, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			ushort4 ywzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 3, 1));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 ywzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 3, 1));
				}
				else
				{
					return new ushort4(y, w, z, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 ywzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 3, 1));
				}
				else
				{
					return new ushort4(y, w, z, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 ywzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 3, 1));
				}
				else
				{
					return new ushort4(y, w, z, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 ywwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 3, 1));
				}
				else
				{
					return new ushort4(y, w, w, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 ywwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 3, 1));
				}
				else
				{
					return new ushort4(y, w, w, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 ywwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 3, 1));
				}
				else
				{
					return new ushort4(y, w, w, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 ywww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 1));
				}
				else
				{
					return new ushort4(y, w, w, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zxxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 2));
				}
				else
				{
					return new ushort4(z, x, x, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zxxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 0, 2));
				}
				else
				{
					return new ushort4(z, x, x, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zxxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 0, 2));
				}
				else
				{
					return new ushort4(z, x, x, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zxxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 0, 2));
				}
				else
				{
					return new ushort4(z, x, x, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zxyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 0, 2));
				}
				else
				{
					return new ushort4(z, x, y, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zxyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 0, 2));
				}
				else
				{
					return new ushort4(z, x, y, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zxyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 0, 2));
				}
				else
				{
					return new ushort4(z, x, y, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			ushort4 zxyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 2));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zxzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 0, 2));
				}
				else
				{
					return new ushort4(z, x, z, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zxzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 0, 2));
				}
				else
				{
					return new ushort4(z, x, z, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zxzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 0, 2));
				}
				else
				{
					return new ushort4(z, x, z, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zxzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 2));
				}
				else
				{
					return new ushort4(z, x, z, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zxwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 0, 2));
				}
				else
				{
					return new ushort4(z, x, w, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			ushort4 zxwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 0, 2));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zxwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 0, 2));
				}
				else
				{
					return new ushort4(z, x, w, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zxww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 2));
				}
				else
				{
					return new ushort4(z, x, w, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zyxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 1, 2));
				}
				else
				{
					return new ushort4(z, y, x, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zyxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 1, 2));
				}
				else
				{
					return new ushort4(z, y, x, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zyxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 1, 2));
				}
				else
				{
					return new ushort4(z, y, x, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			ushort4 zyxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 2));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zyyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 1, 2));
				}
				else
				{
					return new ushort4(z, y, y, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zyyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 1, 2));
				}
				else
				{
					return new ushort4(z, y, y, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zyyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 1, 2));
				}
				else
				{
					return new ushort4(z, y, y, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zyyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 2));
				}
				else
				{
					return new ushort4(z, y, y, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zyzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 1, 2));
				}
				else
				{
					return new ushort4(z, y, z, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zyzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 1, 2));
				}
				else
				{
					return new ushort4(z, y, z, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zyzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 1, 2));
				}
				else
				{
					return new ushort4(z, y, z, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zyzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 1, 2));
				}
				else
				{
					return new ushort4(z, y, z, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			ushort4 zywx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 1, 2));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zywy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 1, 2));
				}
				else
				{
					return new ushort4(z, y, w, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zywz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 1, 2));
				}
				else
				{
					return new ushort4(z, y, w, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zyww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 2));
				}
				else
				{
					return new ushort4(z, y, w, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zzxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 2, 2));
				}
				else
				{
					return new ushort4(z, z, x, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zzxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 2, 2));
				}
				else
				{
					return new ushort4(z, z, x, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zzxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 2, 2));
				}
				else
				{
					return new ushort4(z, z, x, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zzxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 2));
				}
				else
				{
					return new ushort4(z, z, x, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zzyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 2, 2));
				}
				else
				{
					return new ushort4(z, z, y, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zzyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 2, 2));
				}
				else
				{
					return new ushort4(z, z, y, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zzyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 2, 2));
				}
				else
				{
					return new ushort4(z, z, y, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zzyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 2));
				}
				else
				{
					return new ushort4(z, z, y, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zzzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 2, 2));
				}
				else
				{
					return new ushort4(z, z, z, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zzzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 2, 2));
				}
				else
				{
					return new ushort4(z, z, z, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zzzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 2, 2));
				}
				else
				{
					return new ushort4(z, z, z, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zzzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 2));
				}
				else
				{
					return new ushort4(z, z, z, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zzwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 2, 2)); ;
				}
				else
				{
					return new ushort4(z, z, w, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zzwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 2, 2));
				}
				else
				{
					return new ushort4(z, z, w, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zzwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 2, 2));
				}
				else
				{
					return new ushort4(z, z, w, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zzww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 2));
				}
				else
				{
					return new ushort4(z, z, w, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zwxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 3, 2));
				}
				else
				{
					return new ushort4(z, w, x, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			ushort4 zwxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 3, 2));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zwxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 3, 2));
				}
				else
				{
					return new ushort4(z, w, x, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zwxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 3, 2));
				}
				else
				{
					return new ushort4(z, w, x, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			ushort4 zwyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 3, 2));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zwyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 3, 2));
				}
				else
				{
					return new ushort4(z, w, y, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zwyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 3, 2));
				}
				else
				{
					return new ushort4(z, w, y, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zwyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 3, 2));
				}
				else
				{
					return new ushort4(z, w, y, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zwzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 3, 2));
				}
				else
				{
					return new ushort4(z, w, z, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zwzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 3, 2));
				}
				else
				{
					return new ushort4(z, w, z, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zwzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 3, 2));
				}
				else
				{
					return new ushort4(z, w, z, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zwzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 3, 2));
				}
				else
				{
					return new ushort4(z, w, z, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zwwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 3, 2));
				}
				else
				{
					return new ushort4(z, w, w, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zwwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 3, 2));
				}
				else
				{
					return new ushort4(z, w, w, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zwwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 3, 2));
				}
				else
				{
					return new ushort4(z, w, w, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 zwww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 2));
				}
				else
				{
					return new ushort4(z, w, w, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wxxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 3));
				}
				else
				{
					return new ushort4(w, x, x, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wxxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 0, 3));
				}
				else
				{
					return new ushort4(w, x, x, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wxxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 0, 3));
				}
				else
				{
					return new ushort4(w, x, x, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wxxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 0, 3));
				}
				else
				{
					return new ushort4(w, x, x, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wxyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 0, 3));
				}
				else
				{
					return new ushort4(w, x, y, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wxyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 0, 3));
				}
				else
				{
					return new ushort4(w, x, y, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wxyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 0, 3));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wxyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 3));
				}
				else
				{
					return new ushort4(w, x, y, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wxzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 0, 3));
				}
				else
				{
					return new ushort4(w, x, z, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wxzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 0, 3));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wxzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 0, 3));
				}
				else
				{
					return new ushort4(w, x, z, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wxzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 3));
				}
				else
				{
					return new ushort4(w, x, z, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wxwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 0, 3));
				}
				else
				{
					return new ushort4(w, x, w, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wxwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 0, 3));
				}
				else
				{
					return new ushort4(w, x, w, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wxwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 0, 3));
				}
				else
				{
					return new ushort4(w, x, w, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wxww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 3));
				}
				else
				{
					return new ushort4(w, x, w, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wyxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 1, 3));
				}
				else
				{
					return new ushort4(w, y, x, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wyxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 1, 3));
				}
				else
				{
					return new ushort4(w, y, x, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wyxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 1, 3));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wyxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 3));
				}
				else
				{
					return new ushort4(w, y, x, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wyyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 1, 3));
				}
				else
				{
					return new ushort4(w, y, y, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wyyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 1, 3));
				}
				else
				{
					return new ushort4(w, y, y, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wyyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 1, 3));
				}
				else
				{
					return new ushort4(w, y, y, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wyyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 3));
				}
				else
				{
					return new ushort4(w, y, y, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wyzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 1, 3));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wyzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 1, 3));
				}
				else
				{
					return new ushort4(w, y, z, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wyzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 1, 3));
				}
				else
				{
					return new ushort4(w, y, z, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wyzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 1, 3));
				}
				else
				{
					return new ushort4(w, y, z, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wywx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 1, 3));
				}
				else
				{
					return new ushort4(w, y, w, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wywy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 1, 3));
				}
				else
				{
					return new ushort4(w, y, w, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wywz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 1, 3));
				}
				else
				{
					return new ushort4(w, y, w, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wyww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 3));
				}
				else
				{
					return new ushort4(w, y, w, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wzxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 2, 3));
				}
				else
				{
					return new ushort4(w, z, x, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wzxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 2, 3));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wzxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 2, 3));
				}
				else
				{
					return new ushort4(w, z, x, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wzxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 3));
				}
				else
				{
					return new ushort4(w, z, x, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wzyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 2, 3));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wzyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 2, 3));
				}
				else
				{
					return new ushort4(w, z, y, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wzyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 2, 3));
				}
				else
				{
					return new ushort4(w, z, y, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wzyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 3));
				}
				else
				{
					return new ushort4(w, z, y, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wzzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 2, 3));
				}
				else
				{
					return new ushort4(w, z, z, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wzzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 2, 3));
				}
				else
				{
					return new ushort4(w, z, z, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wzzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 2, 3));
				}
				else
				{
					return new ushort4(w, z, z, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wzzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 3));
				}
				else
				{
					return new ushort4(w, z, z, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wzwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 2, 3)); ;
				}
				else
				{
					return new ushort4(w, z, w, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wzwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 2, 3));
				}
				else
				{
					return new ushort4(w, z, w, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wzwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 2, 3));
				}
				else
				{
					return new ushort4(w, z, w, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wzww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 3));
				}
				else
				{
					return new ushort4(w, z, w, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wwxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 3, 3));
				}
				else
				{
					return new ushort4(w, w, x, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wwxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 3, 3));
				}
				else
				{
					return new ushort4(w, w, x, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wwxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 3, 3));
				}
				else
				{
					return new ushort4(w, w, x, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wwxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 3, 3));
				}
				else
				{
					return new ushort4(w, w, x, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wwyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 3, 3));
				}
				else
				{
					return new ushort4(w, w, y, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wwyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 3, 3));
				}
				else
				{
					return new ushort4(w, w, y, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wwyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 3, 3));
				}
				else
				{
					return new ushort4(w, w, y, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wwyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 3, 3));
				}
				else
				{
					return new ushort4(w, w, y, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wwzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 3, 3));
				}
				else
				{
					return new ushort4(w, w, z, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wwzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 3, 3));
				}
				else
				{
					return new ushort4(w, w, z, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wwzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 3, 3));
				}
				else
				{
					return new ushort4(w, w, z, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wwzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 3, 3));
				}
				else
				{
					return new ushort4(w, w, z, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wwwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 3, 3));
				}
				else
				{
					return new ushort4(w, w, w, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wwwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 3, 3));
				}
				else
				{
					return new ushort4(w, w, w, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wwwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 3, 3));
				}
				else
				{
					return new ushort4(w, w, w, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 wwww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 3));
				}
				else
				{
					return new ushort4(w, w, w, w);
				}
			}
		}


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 xxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 0));
				}
				else
				{
					return new ushort3(x, x, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 xxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 0));
				}
				else
				{
					return new ushort3(x, x, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 xxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 0));
				}
				else
				{
					return new ushort3(x, x, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 xxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 0));
				}
				else
				{
					return new ushort3(x, x, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 xyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 0));
				}
				else
				{
					return new ushort3(x, y, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 xyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 0));
				}
				else
				{
					return new ushort3(x, y, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 xyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
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
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 xyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 0));
				}
				else
				{
					return new ushort3(x, y, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 xzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 0));
				}
				else
				{
					return new ushort3(x, z, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 xzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 0));
				}
				else
				{
					return new ushort3(x, z, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 xzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 0));
				}
				else
				{
					return new ushort3(x, z, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 xzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 0));
				}
				else
				{
					return new ushort3(x, z, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 xwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 3, 0));
				}
				else
				{
					return new ushort3(x, w, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 xwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 3, 0));
				}
				else
				{
					return new ushort3(x, w, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 xwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 3, 0));
				}
				else
				{
					return new ushort3(x, w, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 xww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 0));
				}
				else
				{
					return new ushort3(x, w, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 yxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 0, 1));
				}
				else
				{
					return new ushort3(y, x, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 yxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 1));
				}
				else
				{
					return new ushort3(y, x, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 yxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 1));
				}
				else
				{
					return new ushort3(y, x, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 yxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 1));
				}
				else
				{
					return new ushort3(y, x, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 yyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 1));
				}
				else
				{
					return new ushort3(y, y, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 yyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 1));
				}
				else
				{
					return new ushort3(y, y, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 yyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 1, 1));
				}
				else
				{
					return new ushort3(y, y, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 yyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 1));
				}
				else
				{
					return new ushort3(y, y, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 yzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 1));
				}
				else
				{
					return new ushort3(y, z, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 yzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 1));
				}
				else
				{
					return new ushort3(y, z, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 yzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 1));
				}
				else
				{
					return new ushort3(y, z, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 yzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 1));
				}
				else
				{
					return new ushort3(y, z, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 ywx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 3, 1));
				}
				else
				{
					return new ushort3(y, w, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 ywy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 3, 1));
				}
				else
				{
					return new ushort3(y, w, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 ywz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 3, 1));
				}
				else
				{
					return new ushort3(y, w, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 yww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 1));
				}
				else
				{
					return new ushort3(y, w, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 zxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 0, 2));
				}
				else
				{
					return new ushort3(z, x, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 zxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 2));
				}
				else
				{
					return new ushort3(z, x, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 zxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 2));
				}
				else
				{
					return new ushort3(z, x, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 zxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 2));
				}
				else
				{
					return new ushort3(z, x, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 zyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 2));
				}
				else
				{
					return new ushort3(z, y, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 zyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 2));
				}
				else
				{
					return new ushort3(z, y, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 zyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 1, 2));
				}
				else
				{
					return new ushort3(z, y, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 zyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 2));
				}
				else
				{
					return new ushort3(z, y, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 zzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 2));
				}
				else
				{
					return new ushort3(z, z, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 zzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 2));
				}
				else
				{
					return new ushort3(z, z, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 zzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 2));
				}
				else
				{
					return new ushort3(z, z, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 zzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 2));
				}
				else
				{
					return new ushort3(z, z, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 zwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 3, 2));
				}
				else
				{
					return new ushort3(z, w, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 zwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 3, 2));
				}
				else
				{
					return new ushort3(z, w, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 zwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 3, 2));
				}
				else
				{
					return new ushort3(z, w, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 zww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 2));
				}
				else
				{
					return new ushort3(z, w, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 wxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 0, 3));
				}
				else
				{
					return new ushort3(w, x, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 wxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 3));
				}
				else
				{
					return new ushort3(w, x, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 wxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 3));
				}
				else
				{
					return new ushort3(w, x, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 wxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 3));
				}
				else
				{
					return new ushort3(w, x, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 wyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 3));
				}
				else
				{
					return new ushort3(w, y, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 wyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 3));
				}
				else
				{
					return new ushort3(w, y, y);
				}
			}
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 wyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 1, 3));
				}
				else
				{
					return new ushort3(w, y, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 wyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 3));
				}
				else
				{
					return new ushort3(w, y, w);
				}
			}
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 wzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 3));
				}
				else
				{
					return new ushort3(w, z, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 wzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 3));
				}
				else
				{
					return new ushort3(w, z, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 wzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 3));
				}
				else
				{
					return new ushort3(w, z, z);
				}
			}
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 wzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 3));
				}
				else
				{
					return new ushort3(w, z, w);
				}
			}
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 wwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 3, 3));
				}
				else
				{
					return new ushort3(w, w, x);
				}
			}
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 wwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 3, 3));
				}
				else
				{
					return new ushort3(w, w, y);
				}
			}
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 wwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 3, 3));
				}
				else
				{
					return new ushort3(w, w, z);
				}
			}
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 www
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 3));
				}
				else
				{
					return new ushort3(w, w, w);
				}
			}
        }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort2 xx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 0));
				}
				else
				{
					return new ushort2(x, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort2 xy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
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
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort2 xz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 0));
				}
				else
				{
					return new ushort2(x, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort2 xw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 0));
				}
				else
				{
					return new ushort2(x, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort2 yx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 1));
				}
				else
				{
					return new ushort2(y, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort2 yy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 1));
				}
				else
				{
					return new ushort2(y, y);
				}
			}
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort2 yz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.bsrli_si128(this, sizeof(ushort));
				}
				else
				{
					return new ushort2(y, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort2 yw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 1));
				}
				else
				{
					return new ushort2(y, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort2 zx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 2));
				}
				else
				{
					return new ushort2(z, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort2 zy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 2));
				}
				else
				{
					return new ushort2(z, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort2 zz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 2));
				}
				else
				{
					return new ushort2(z, z);
				}
			}
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort2 zw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.bsrli_si128(this, 2 * sizeof(ushort));
				}
				else
				{
					return new ushort2(z, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					this = Xse.unpacklo_epi32(this, value);
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
        public ushort2 wx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 3));
				}
				else
				{
					return new ushort2(w, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort2 wy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 3));
				}
				else
				{
					return new ushort2(w, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort2 wz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 3));
				}
				else
				{
					return new ushort2(w, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort2 ww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
				{
					return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 3));
				}
				else
                {
					return new ushort2(w, w);
                }
			}
        }
        #endregion

		
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(ushort4 input)
        {
            v128 result;
            if (Avx.IsAvxSupported)
            {
                result = Avx.undefined_si128();
            }
            else
            {
                result = Uninitialized<v128>.Create();
            }

            result.ULong0 = input.__x0;
            return result;
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort4(v128 input) => new ushort4 { __x0 = input.ULong0 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(bool x) => math.tobyte(x);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(bool4 x) => (ushort4)(mask16x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(Unity.Mathematics.bool4 x) => (ushort4)(mask16x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(mask8x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (ushort4)(mask16x4)x;
            }
            else
            {
                return *(byte4*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(mask16x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi16(x);
            }
            else
            {
                return *(byte4*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(mask32x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (ushort4)(mask16x4)x;
            }
            else
            {
                return *(byte4*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(mask64x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (ushort4)(mask16x4)x;
            }
            else
            {
                return *(byte4*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4(ushort4 x) => (mask16x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool4(ushort4 x) => (mask16x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x4(ushort4 x) => (mask16x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x4(ushort4 x) => x != 0;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4(ushort4 x) => (mask16x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x4(ushort4 x) => (mask16x4)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator ushort4(byte x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(sbyte x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(short x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(uint x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(int x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(ulong x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(long x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(UInt128 x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(Int128 x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(quarter x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(half x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(float x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(double x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(quadruple x) => (ushort)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(Unity.Mathematics.half x) => (ushort4)(half)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(Unity.Mathematics.half4 x) => (ushort4)(half4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(Unity.Mathematics.float4 x) => (ushort4)(float4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(Unity.Mathematics.double4 x) => (ushort4)(double4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(Unity.Mathematics.uint4 x) => (ushort4)(uint4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(Unity.Mathematics.int4 x) => (ushort4)(int4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.half4(ushort4 x) => (half4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float4(ushort4 x) => (float4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double4(ushort4 x) => (double4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.uint4(ushort4 x) => (uint4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.int4(ushort4 x) => (int4)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort4(ushort input) => new ushort4(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(short4 input) => *(ushort4*)&input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(int4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi32_epi16(input, 4);
			}
			else
            {
                return new ushort4((ushort)input.x, (ushort)input.y, (ushort)input.z, (ushort)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(uint4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi32_epi16(input, 4);
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
                return Xse.mm256_cvtepi64_epi16(input);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new ushort4(Xse.cvtepi64_epi16(input.__x0), Xse.cvtepi64_epi16(input.__x2));
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
                return Xse.mm256_cvtepi64_epi16(input);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new ushort4(Xse.cvtepi64_epi16(input.__x0), Xse.cvtepi64_epi16(input.__x2));
            }
            else
            {
                return new ushort4((ushort)input.x, (ushort)input.y, (ushort)input.z, (ushort)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(float4 input) => (ushort4)(int4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(double4 input) => (ushort4)(int4)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int4(ushort4 input)
        {
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.cvtepu16_epi32(input);
            }
            else
            {
                return new int4((int)input.x, (int)input.y, (int)input.z, (int)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint4(ushort4 input)
        {
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.cvtepu16_epi32(input);
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
            else if (BurstArchitecture.IsSIMDSupported)
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
            else if (BurstArchitecture.IsSIMDSupported)
			{
                return new ulong4((ulong2)input.xy, (ulong2)input.zw);
            }
            else
            {
                return new ulong4((ulong)input.x, (ulong)input.y, (ulong)input.z, (ulong)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(ushort4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu16_ps(input);
            }
            else
            {
                return (float4)(int4)input;
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

				if (constexpr.IS_CONST(index))
				{
					if (BurstArchitecture.IsSIMDSupported)
					{
					    return Xse.extract_epi16(this, (byte)index);
					}
				}

                if (BurstArchitecture.IsBurstCompiled)
                {
                    fixed (ushort4* ptr = &this)
                    {
                        return ((ushort*)ptr)[index];
                    }
                }
                else
                {
                    return this.GetField<ushort4, ushort>(index);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 4);

				if (constexpr.IS_CONST(index))
				{
					if (BurstArchitecture.IsSIMDSupported)
					{
						this = Xse.insert_epi16(this, value, (byte)index);
					}
				}

                if (BurstArchitecture.IsBurstCompiled)
                {
                    fixed (ushort4* ptr = &this)
                    {
                        ((ushort*)ptr)[index] = value;
                    }
                }
                else
                {
                    this.SetField(value, index);
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator + (ushort4 left, ushort4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.add_epi16(left, right);
            }
            else
            {
                return new ushort4((ushort)(left.x + right.x), (ushort)(left.y + right.y), (ushort)(left.z + right.z), (ushort)(left.w + right.w));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator + (ushort left, ushort4 right) => (ushort4)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator + (ushort4 left, ushort right) => left + (ushort4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator - (ushort4 left, ushort4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.sub_epi16(left, right);
            }
            else
            {
                return new ushort4((ushort)(left.x - right.x), (ushort)(left.y - right.y), (ushort)(left.z - right.z), (ushort)(left.w - right.w));
            }
        }
		
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator - (ushort left, ushort4 right) => (ushort4)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator - (ushort4 left, ushort right) => left - (ushort4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator * (ushort4 left, ushort4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.mullo_epi16(left, right);
            }
            else
            {
                return new ushort4((ushort)(left.x * right.x), (ushort)(left.y * right.y), (ushort)(left.z * right.z), (ushort)(left.w * right.w));
            }
        }
		
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator * (ushort left, ushort4 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator * (ushort4 left, ushort right)
        {
			if (BurstArchitecture.IsSIMDSupported)
			{
				if (constexpr.IS_CONST(right))
				{
					return (v128)((ushort8)((v128)left) * right);
				}
			}

			return left * (ushort4)right;
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator / (ushort4 left, ushort4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.div_epu16(left, right, 4);
            }
            else
            {
                return new ushort4((ushort)(left.x / right.x), (ushort)(left.y / right.y), (ushort)(left.z / right.z), (ushort)(left.w / right.w));
            }
        }
		
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator / (ushort left, ushort4 right) => (ushort4)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator / (ushort4 left, ushort right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epu16(left, right, 4);
                }
            }

            return left / (ushort4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator % (ushort4 left, ushort4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rem_epu16(left, right, 4);
            }
            else
            {
                return new ushort4((ushort)(left.x % right.x), (ushort)(left.y % right.y), (ushort)(left.z % right.z), (ushort)(left.w % right.w));
            }
        }
		
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator % (ushort left, ushort4 right) => (ushort4)left % right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator % (ushort4 left, ushort right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epu16(left, right, 4);
                }
            }

            return left % (ushort4)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator + (ushort4 left, byte4 right) => left + (ushort4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator + (byte4 left, ushort4 right) => (ushort4)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator - (ushort4 left, byte4 right) => left - (ushort4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator - (byte4 left, ushort4 right) => (ushort4)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator * (ushort4 left, byte4 right) => left * (ushort4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator * (byte4 left, ushort4 right) => (ushort4)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator / (ushort4 left, byte4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epu16(left, Xse.cvtepu8_epi16(right), 4);
                }

                v128 left32 = Xse.cvtepu16_ps(left);
                v128 right32 = Xse.cvtepu8_ps(right);
                v128 quotient = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left32, right32);

                if (Sse4_1.IsSse41Supported)
                {
                    v128 toInt = Xse.cvttps_epi32(quotient);
                    return Xse.packus_epi32(toInt, toInt);
                }
                else
                {
                    return Xse.cvttps_epu16(quotient);
                }
            }
            else
            {
                return new ushort4((ushort)(left.x / right.x), (ushort)(left.y / right.y), (ushort)(left.z / right.z), (ushort)(left.w / right.w));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator / (byte4 left, ushort4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epu16(Xse.cvtepu8_epi16(left), right, 4);
                }

                v128 left32 = Xse.cvtepu8_ps(left);
                v128 right32 = Xse.cvtepu16_ps(right);
                v128 quotient = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left32, right32);

                if (Sse4_1.IsSse41Supported)
                {
                    v128 toInt = Xse.cvttps_epi32(quotient);
                    return Xse.packus_epi32(toInt, toInt);
                }
                else
                {
                    return Xse.cvttps_epu16(quotient);
                }
            }
            else
            {
                return new ushort4((ushort)(left.x / right.x), (ushort)(left.y / right.y), (ushort)(left.z / right.z), (ushort)(left.w / right.w));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator % (ushort4 left, byte4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epu16(left, Xse.cvtepu8_epi16(right), 4);
                }

                v128 left32 = Xse.cvtepu16_ps(left);
                v128 right32 = Xse.cvtepu8_ps(right);
                v128 quotient = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left32, right32);

                if (Sse4_1.IsSse41Supported)
                {
                    v128 toInt = Xse.cvttps_epi32(quotient);
                    quotient = Xse.packus_epi32(toInt, toInt);
                }
                else
                {
                    quotient = Xse.cvttps_epu16(quotient);
                }

                return Xse.sub_epi16(left, Xse.mullo_epi16(quotient, Xse.cvtepu8_epi16(right)));
            }
            else
            {
                return new ushort4((ushort)(left.x % right.x), (ushort)(left.y % right.y), (ushort)(left.z % right.z), (ushort)(left.w % right.w));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator % (byte4 left, ushort4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epu16(Xse.cvtepu8_epi16(left), right, 4);
                }

                v128 left32 = Xse.cvtepu8_ps(left);
                v128 right32 = Xse.cvtepu16_ps(right);
                v128 quotient = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left32, right32);

                if (Sse4_1.IsSse41Supported)
                {
                    v128 toInt = Xse.cvttps_epi32(quotient);
                    quotient = Xse.packus_epi32(toInt, toInt);
                }
                else
                {
                    quotient = Xse.cvttps_epu16(quotient);
                }

                return Xse.sub_epi16(Xse.cvtepu8_epi16(left), Xse.mullo_epi16(quotient, right));
            }
            else
            {
                return new ushort4((ushort)(left.x % right.x), (ushort)(left.y % right.y), (ushort)(left.z % right.z), (ushort)(left.w % right.w));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator + (ushort4 left, byte right) => left + (ushort)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator + (byte left, ushort4 right) => (ushort)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator - (ushort4 left, byte right) => left - (ushort)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator - (byte left, ushort4 right) => (ushort)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator * (ushort4 left, byte right) => left * (ushort)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator * (byte left, ushort4 right) => (ushort)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator / (ushort4 left, byte right) => left / (ushort)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator / (byte left, ushort4 right) => (ushort)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator % (ushort4 left, byte right) => left % (ushort)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator % (byte left, ushort4 right) => (ushort)left % right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator + (ushort4 left, Unity.Mathematics.int4 right) => left + (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator + (Unity.Mathematics.int4 left, ushort4 right) => (int4)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator - (ushort4 left, Unity.Mathematics.int4 right) => left - (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator - (Unity.Mathematics.int4 left, ushort4 right) => (int4)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator * (ushort4 left, Unity.Mathematics.int4 right) => left * (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator * (Unity.Mathematics.int4 left, ushort4 right) => (int4)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator / (ushort4 left, Unity.Mathematics.int4 right) => left / (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator / (Unity.Mathematics.int4 left, ushort4 right) => (int4)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator % (ushort4 left, Unity.Mathematics.int4 right) => left % (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator % (Unity.Mathematics.int4 left, ushort4 right) => (int4)left % right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator + (ushort4 left, Unity.Mathematics.uint4 right) => left + (uint4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator + (Unity.Mathematics.uint4 left, ushort4 right) => (uint4)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator - (ushort4 left, Unity.Mathematics.uint4 right) => left - (uint4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator - (Unity.Mathematics.uint4 left, ushort4 right) => (uint4)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator * (ushort4 left, Unity.Mathematics.uint4 right) => left * (uint4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator * (Unity.Mathematics.uint4 left, ushort4 right) => (uint4)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator / (ushort4 left, Unity.Mathematics.uint4 right) => left / (uint4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator / (Unity.Mathematics.uint4 left, ushort4 right) => (uint4)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator % (ushort4 left, Unity.Mathematics.uint4 right) => left % (uint4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator % (Unity.Mathematics.uint4 left, ushort4 right) => (uint4)left % right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (ushort4 left, Unity.Mathematics.float4 right) => left + (float4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (Unity.Mathematics.float4 left, ushort4 right) => (float4)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (ushort4 left, Unity.Mathematics.float4 right) => left - (float4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (Unity.Mathematics.float4 left, ushort4 right) => (float4)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (ushort4 left, Unity.Mathematics.float4 right) => left * (float4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (Unity.Mathematics.float4 left, ushort4 right) => (float4)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (ushort4 left, Unity.Mathematics.float4 right) => left / (float4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (Unity.Mathematics.float4 left, ushort4 right) => (float4)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (ushort4 left, Unity.Mathematics.float4 right) => left % (float4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (Unity.Mathematics.float4 left, ushort4 right) => (float4)left % right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator + (ushort4 left, Unity.Mathematics.double4 right) => left + (double4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator + (Unity.Mathematics.double4 left, ushort4 right) => (double4)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator - (ushort4 left, Unity.Mathematics.double4 right) => left - (double4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator - (Unity.Mathematics.double4 left, ushort4 right) => (double4)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator * (ushort4 left, Unity.Mathematics.double4 right) => left * (double4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator * (Unity.Mathematics.double4 left, ushort4 right) => (double4)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator / (ushort4 left, Unity.Mathematics.double4 right) => left / (double4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator / (Unity.Mathematics.double4 left, ushort4 right) => (double4)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator % (ushort4 left, Unity.Mathematics.double4 right) => left % (double4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator % (Unity.Mathematics.double4 left, ushort4 right) => (double4)left % right;
		

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator & (ushort4 left, ushort4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.and_si128(left, right);
            }
            else
            {
                return new ushort4((ushort)(left.x & right.x), (ushort)(left.y & right.y), (ushort)(left.z & right.z), (ushort)(left.w & right.w));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator | (ushort4 left, ushort4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.or_si128(left, right);
            }
            else
            {
                return new ushort4((ushort)(left.x | right.x), (ushort)(left.y | right.y), (ushort)(left.z | right.z), (ushort)(left.w | right.w));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator ^ (ushort4 left, ushort4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.xor_si128(left, right);
            }
            else
            {
                return new ushort4((ushort)(left.x ^ right.x), (ushort)(left.y ^ right.y), (ushort)(left.z ^ right.z), (ushort)(left.w ^ right.w));
            }
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator & (ushort4 left, byte right) => left & (ushort)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator & (byte left, ushort4 right) => (ushort)left & right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator | (ushort4 left, byte right) => left | (ushort)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator | (byte left, ushort4 right) => (ushort)left | right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator ^ (ushort4 left, byte right) => left ^ (ushort)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator ^ (byte left, ushort4 right) => (ushort)left ^ right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator & (ushort4 left, ushort right) => left & (ushort4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator & (ushort left, ushort4 right) => (ushort4)left & right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator | (ushort4 left, ushort right) => left | (ushort4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator | (ushort left, ushort4 right) => (ushort4)left | right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator ^ (ushort4 left, ushort right) => left ^ (ushort4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator ^ (ushort left, ushort4 right) => (ushort4)left ^ right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator & (ushort4 left, byte4 right) => left & (ushort4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator & (byte4 left, ushort4 right) => (ushort4)left & right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator | (ushort4 left, byte4 right) => left | (ushort4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator | (byte4 left, ushort4 right) => (ushort4)left | right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator ^ (ushort4 left, byte4 right) => left ^ (ushort4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator ^ (byte4 left, ushort4 right) => (ushort4)left ^ right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator & (ushort4 left, Unity.Mathematics.int4 right) => left & (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator & (Unity.Mathematics.int4 left, ushort4 right) => (int4)left & right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator | (ushort4 left, Unity.Mathematics.int4 right) => left | (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator | (Unity.Mathematics.int4 left, ushort4 right) => (int4)left | right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator ^ (ushort4 left, Unity.Mathematics.int4 right) => left ^ (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator ^ (Unity.Mathematics.int4 left, ushort4 right) => (int4)left ^ right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator & (ushort4 left, Unity.Mathematics.uint4 right) => left & (uint4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator & (Unity.Mathematics.uint4 left, ushort4 right) => (uint4)left & right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator | (ushort4 left, Unity.Mathematics.uint4 right) => left | (uint4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator | (Unity.Mathematics.uint4 left, ushort4 right) => (uint4)left | right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator ^ (ushort4 left, Unity.Mathematics.uint4 right) => left ^ (uint4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator ^ (Unity.Mathematics.uint4 left, ushort4 right) => (uint4)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator ++ (ushort4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.inc_epi16(x);
			}
            else
            {
                return new ushort4((ushort)(x.x + 1), (ushort)(x.y + 1), (ushort)(x.z + 1), (ushort)(x.w + 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator -- (ushort4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.dec_epi16(x);
			}
            else
            {
                return new ushort4((ushort)(x.x - 1), (ushort)(x.y - 1), (ushort)(x.z - 1), (ushort)(x.w - 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator ~ (ushort4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.not_si128(x);
			}
            else
            {
                return new ushort4((ushort)(~x.x), (ushort)(~x.y), (ushort)(~x.z), (ushort)(~x.w));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator << (ushort4 x, int n)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.slli_epi16(x, n, inRange: true);
            }
            else
            {
                return new ushort4((ushort)(x.x << n), (ushort)(x.y << n), (ushort)(x.z << n), (ushort)(x.w << n));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator >> (ushort4 x, int n)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.srli_epi16(x, n, inRange: true);
            }
            else
            {
                return new ushort4((ushort)(x.x >> n), (ushort)(x.y >> n), (ushort)(x.z >> n), (ushort)(x.w >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (ushort4 left, ushort4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
				return Xse.cmpeq_epi16(left, right);
            }
            else
            {
                return new mask16x4(left.x == right.x, left.y == right.y, left.z == right.z, left.w == right.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (ushort4 left, ushort4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
				return Xse.cmplt_epu16(left, right, 4);
            }
            else
            {
                return new mask16x4(left.x < right.x, left.y < right.y, left.z < right.z, left.w < right.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (ushort4 left, ushort4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
				return Xse.cmpgt_epu16(left, right, 4);
            }
            else
            {
                return new mask16x4(left.x > right.x, left.y > right.y, left.z > right.z, left.w > right.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (ushort4 left, ushort4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
				return Xse.not_si128(Xse.cmpeq_epi16(left, right));
            }
            else
            {
                return new mask16x4(left.x != right.x, left.y != right.y, left.z != right.z, left.w != right.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (ushort4 left, ushort4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
				return Xse.cmple_epu16(left, right, 4);
            }
            else
            {
                return new mask16x4(left.x <= right.x, left.y <= right.y, left.z <= right.z, left.w <= right.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (ushort4 left, ushort4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
				return Xse.cmpge_epu16(left, right, 4);
            }
            else
            {
                return new mask16x4(left.x >= right.x, left.y >= right.y, left.z >= right.z, left.w >= right.w);
            }
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (ushort4 left, byte right) => left == (ushort)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (byte left, ushort4 right) => (ushort)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (ushort4 left, byte right) => left != (ushort)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (byte left, ushort4 right) => (ushort)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (ushort4 left, byte right) => left < (ushort)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (byte left, ushort4 right) => (ushort)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (ushort4 left, byte right) => left > (ushort)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (byte left, ushort4 right) => (ushort)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (ushort4 left, byte right) => left <= (ushort)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (byte left, ushort4 right) => (ushort)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (ushort4 left, byte right) => left >= (ushort)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (byte left, ushort4 right) => (ushort)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (ushort4 left, ushort right) => left == (ushort4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (ushort left, ushort4 right) => (ushort4)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (ushort4 left, ushort right) => left != (ushort4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (ushort left, ushort4 right) => (ushort4)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (ushort4 left, ushort right) => left < (ushort4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (ushort left, ushort4 right) => (ushort4)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (ushort4 left, ushort right) => left > (ushort4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (ushort left, ushort4 right) => (ushort4)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (ushort4 left, ushort right) => left <= (ushort4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (ushort left, ushort4 right) => (ushort4)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (ushort4 left, ushort right) => left >= (ushort4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (ushort left, ushort4 right) => (ushort4)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (ushort4 left, byte4 right) => left == (ushort4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (byte4 left, ushort4 right) => (ushort4)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (ushort4 left, byte4 right) => left != (ushort4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (byte4 left, ushort4 right) => (ushort4)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (ushort4 left, byte4 right) => left < (ushort4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (byte4 left, ushort4 right) => (ushort4)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (ushort4 left, byte4 right) => left > (ushort4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (byte4 left, ushort4 right) => (ushort4)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (ushort4 left, byte4 right) => left <= (ushort4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (byte4 left, ushort4 right) => (ushort4)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (ushort4 left, byte4 right) => left >= (ushort4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (byte4 left, ushort4 right) => (ushort4)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (ushort4 left, Unity.Mathematics.int4 right) => left == (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (Unity.Mathematics.int4 left, ushort4 right) => (int4)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (ushort4 left, Unity.Mathematics.int4 right) => left != (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (Unity.Mathematics.int4 left, ushort4 right) => (int4)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (ushort4 left, Unity.Mathematics.int4 right) => left < (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (Unity.Mathematics.int4 left, ushort4 right) => (int4)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (ushort4 left, Unity.Mathematics.int4 right) => left > (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (Unity.Mathematics.int4 left, ushort4 right) => (int4)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (ushort4 left, Unity.Mathematics.int4 right) => left <= (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (Unity.Mathematics.int4 left, ushort4 right) => (int4)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (ushort4 left, Unity.Mathematics.int4 right) => left >= (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (Unity.Mathematics.int4 left, ushort4 right) => (int4)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (ushort4 left, Unity.Mathematics.uint4 right) => left == (uint4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (Unity.Mathematics.uint4 left, ushort4 right) => (uint4)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (ushort4 left, Unity.Mathematics.uint4 right) => left != (uint4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (Unity.Mathematics.uint4 left, ushort4 right) => (uint4)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (ushort4 left, Unity.Mathematics.uint4 right) => left < (uint4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (Unity.Mathematics.uint4 left, ushort4 right) => (uint4)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (ushort4 left, Unity.Mathematics.uint4 right) => left > (uint4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (Unity.Mathematics.uint4 left, ushort4 right) => (uint4)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (ushort4 left, Unity.Mathematics.uint4 right) => left <= (uint4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (Unity.Mathematics.uint4 left, ushort4 right) => (uint4)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (ushort4 left, Unity.Mathematics.uint4 right) => left >= (uint4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (Unity.Mathematics.uint4 left, ushort4 right) => (uint4)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (ushort4 left, Unity.Mathematics.float4 right) => left == (float4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (Unity.Mathematics.float4 left, ushort4 right) => (float4)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (ushort4 left, Unity.Mathematics.float4 right) => left != (float4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (Unity.Mathematics.float4 left, ushort4 right) => (float4)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (ushort4 left, Unity.Mathematics.float4 right) => left < (float4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (Unity.Mathematics.float4 left, ushort4 right) => (float4)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (ushort4 left, Unity.Mathematics.float4 right) => left > (float4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (Unity.Mathematics.float4 left, ushort4 right) => (float4)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (ushort4 left, Unity.Mathematics.float4 right) => left <= (float4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (Unity.Mathematics.float4 left, ushort4 right) => (float4)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (ushort4 left, Unity.Mathematics.float4 right) => left >= (float4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (Unity.Mathematics.float4 left, ushort4 right) => (float4)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (ushort4 left, Unity.Mathematics.double4 right) => left == (double4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (Unity.Mathematics.double4 left, ushort4 right) => (double4)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (ushort4 left, Unity.Mathematics.double4 right) => left != (double4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (Unity.Mathematics.double4 left, ushort4 right) => (double4)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (ushort4 left, Unity.Mathematics.double4 right) => left < (double4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (Unity.Mathematics.double4 left, ushort4 right) => (double4)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (ushort4 left, Unity.Mathematics.double4 right) => left > (double4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (Unity.Mathematics.double4 left, ushort4 right) => (double4)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (ushort4 left, Unity.Mathematics.double4 right) => left <= (double4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (Unity.Mathematics.double4 left, ushort4 right) => (double4)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (ushort4 left, Unity.Mathematics.double4 right) => left >= (double4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (Unity.Mathematics.double4 left, ushort4 right) => (double4)left >= right;


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(ushort4 other)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return ulong.MaxValue == Xse.cmpeq_epi16(this, other).ULong0;
			}
			else
			{
				return (this.x == other.x & this.y == other.y) & (this.z == other.z & this.w == other.w);
			}
		}

		public override bool Equals(object obj) => obj is ushort4 converted && this.Equals(converted);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


		public override string ToString() => $"ushort4({x}, {y}, {z}, {w})";
        public string ToString(string format, IFormatProvider formatProvider) => $"ushort4({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)}, {w.ToString(format, formatProvider)})";
    }
}