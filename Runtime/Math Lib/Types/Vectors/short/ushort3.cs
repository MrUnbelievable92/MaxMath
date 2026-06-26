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
    internal sealed class ushort3DebuggerProxy
    {
        public ushort x;
        public ushort y;
        public ushort z;
        
        public ushort3DebuggerProxy(ushort3 v)
        {
            x = v.x;
            y = v.y;
            z = v.z;
        }
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(ushort3DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public struct ushort3 : IEquatable<ushort3>, IFormattable
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal uint __x0;
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal ushort __x2;
        
        public ref ushort x { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(ushort3* ptr = &this) { return ref *((ushort*)ptr +  0); } } }
        public ref ushort y { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(ushort3* ptr = &this) { return ref *((ushort*)ptr +  1); } } }
        public ref ushort z { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(ushort3* ptr = &this) { return ref *((ushort*)ptr +  2); } } }


        public static ushort3 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(ushort x, ushort y, ushort z)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                this = Xse.set_epi16(0, 0, 0, 0, 0, (short)z, (short)y, (short)x);
            }
            else
            {
                __x0 = Uninitialized<uint>.Create();
                __x2 = Uninitialized<ushort>.Create();

                this.x = x;
                this.y = y;
                this.z = z;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(ushort xyz)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                this = Xse.shufflelo_epi16(Xse.cvtsi32_si128(xyz), Sse.SHUFFLE(0, 0, 0, 0));
            }
            else
            {
                __x0 = Uninitialized<uint>.Create();
                __x2 = Uninitialized<ushort>.Create();

                this.x = this.y = this.z = xyz;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(ushort2 xy, ushort z)
        {
            if (BurstArchitecture.IsInsertExtractSupported)
            {
                this = Xse.insert_epi16(xy, z, 2);
            }
            else
            {
                __x0 = Uninitialized<uint>.Create();
                __x2 = Uninitialized<ushort>.Create();

                this.x = xy.x;
                this.y = xy.y;
                this.z = z;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(ushort x, ushort2 yz)
        {
            if (BurstArchitecture.IsInsertExtractSupported)
            {
                this = Xse.insert_epi16(Xse.bslli_si128(yz, sizeof(ushort)), x, 0);
            }
            else
            {
                __x0 = Uninitialized<uint>.Create();
                __x2 = Uninitialized<ushort>.Create();

                this.x = x;
                this.y = yz.x;
                this.z = yz.y;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(bool v)
        {
            this = (ushort3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(bool3 v)
        {
            this = (ushort3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(mask8x3 v)
        {
            this = (ushort3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(mask16x3 v)
        {
            this = (ushort3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(mask32x3 v)
        {
            this = (ushort3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(mask64x3 v)
        {
            this = (ushort3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(byte v)
        {
            this = (ushort3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(byte3 v)
        {
            this = (ushort3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(sbyte v)
        {
            this = (ushort3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(sbyte3 v)
        {
            this = (ushort3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(ushort3 v)
        {
            this = (ushort3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(short v)
        {
            this = (ushort3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(short3 v)
        {
            this = (ushort3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(uint v)
        {
            this = (ushort3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(uint3 v)
        {
            this = (ushort3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(int v)
        {
            this = (ushort3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(int3 v)
        {
            this = (ushort3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(ulong v)
        {
            this = (ushort3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(ulong3 v)
        {
            this = (ushort3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(long v)
        {
            this = (ushort3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(long3 v)
        {
            this = (ushort3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(UInt128 v)
        {
            this = (ushort3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(Int128 v)
        {
            this = (ushort3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(quarter v)
        {
            this = (ushort3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(quarter3 v)
        {
            this = (ushort3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(half v)
        {
            this = (ushort3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(half3 v)
        {
            this = (ushort3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(float v)
        {
            this = (ushort3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(float3 v)
        {
            this = (ushort3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(double v)
        {
            this = (ushort3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(double3 v)
        {
            this = (ushort3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(quadruple v)
        {
            this = (ushort3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(Unity.Mathematics.bool3 v)
        {
            this = (ushort3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(Unity.Mathematics.uint3 v)
        {
            this = (ushort3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(Unity.Mathematics.int3 v)
        {
            this = (ushort3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(Unity.Mathematics.half v)
        {
            this = (ushort3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(Unity.Mathematics.half3 v)
        {
            this = (ushort3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(Unity.Mathematics.float3 v)
        {
            this = (ushort3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(Unity.Mathematics.double3 v)
        {
            this = (ushort3)v;
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
                    return new ushort4(x, x, y,z);
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
                    return new ushort4(y, x, x,  x);
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
            readonly get
            {
                return this;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this = value;
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
                this = value.xzy;
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
                this = value.yxz;
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
                this = value.zxy;
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
                this = value.yzx;
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
                this = value.zyx;
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
                    this = Xse.blend_epi16(this, value.yxyx, 0b0011);
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
                    this = Xse.blend_epi16(this, Xse.bslli_si128(value, sizeof(ushort)), 0b0110);
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
        #endregion

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(ushort3 input)
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

            result.UInt0 = input.__x0;
            result.UShort2 = input.__x2;
            return result;
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort3(v128 input) => new ushort3 { __x0 = input.UInt0, __x2 = input.UShort2 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(bool x) => math.tobyte(x);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(bool3 x) => (ushort3)(mask16x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(Unity.Mathematics.bool3 x) => (ushort3)(mask16x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(mask8x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (ushort3)(mask16x3)x;
            }
            else
            {
                return *(byte3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(mask16x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi16(x);
            }
            else
            {
                return *(byte3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(mask32x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (ushort3)(mask16x3)x;
            }
            else
            {
                return *(byte3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(mask64x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (ushort3)(mask16x3)x;
            }
            else
            {
                return *(byte3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3(ushort3 x) => (mask16x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool3(ushort3 x) => (mask16x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3(ushort3 x) => (mask16x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x3(ushort3 x) => x != 0;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x3(ushort3 x) => (mask16x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x3(ushort3 x) => (mask16x3)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator ushort3(byte x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(sbyte x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(short x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(uint x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(int x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(ulong x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(long x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(UInt128 x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(Int128 x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(quarter x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(half x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(float x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(double x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(quadruple x) => (ushort)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(Unity.Mathematics.half x) => (ushort3)(half)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(Unity.Mathematics.half3 x) => (ushort3)(half3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(Unity.Mathematics.float3 x) => (ushort3)(float3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(Unity.Mathematics.double3 x) => (ushort3)(double3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(Unity.Mathematics.uint3 x) => (ushort3)(uint3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(Unity.Mathematics.int3 x) => (ushort3)(int3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.half3(ushort3 x) => (half3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float3(ushort3 x) => (float3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double3(ushort3 x) => (double3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.uint3(ushort3 x) => (uint3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.int3(ushort3 x) => (int3)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort3(ushort input) => new ushort3(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(short3 input) => *(ushort3*)&input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(int3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi32_epi16(input, 3);
            }
            else
            {
                return new ushort3((ushort)input.x, (ushort)input.y, (ushort)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(uint3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi32_epi16(input, 3);
            }
            else
            {
                return new ushort3((ushort)input.x, (ushort)input.y, (ushort)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(long3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepi64_epi16(input);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new ushort3(Xse.cvtepi64_epi16(input.__x0), (ushort)input.z);
            }
            else
            {
                return new ushort3((ushort)input.x, (ushort)input.y, (ushort)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(ulong3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepi64_epi16(input);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new ushort3(Xse.cvtepi64_epi16(input.__x0), (ushort)input.z);
            }
            else
            {
                return new ushort3((ushort)input.x, (ushort)input.y, (ushort)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(float3 input) => (ushort3)(int3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(double3 input) => (ushort3)(int3)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3(ushort3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu16_epi32(input);
            }
            else
            {
                return new int3((int)input.x, (int)input.y, (int)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint3(ushort3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu16_epi32(input);
            }
            else
            {
                return new uint3((uint)input.x, (uint)input.y, (uint)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3(ushort3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepu16_epi64(input);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new long3((long2)input.xy, (long)input.z);
            }
            else
            {
                return new long3((long)input.x, (long)input.y, (long)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong3(ushort3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepu16_epi64(input);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new ulong3((ulong2)input.xy, (ulong)input.z);
            }
            else
            {
                return new ulong3((ulong)input.x, (ulong)input.y, (ulong)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(ushort3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu16_ps(input);
            }
            else
            {
                return (float3)(int3)input;
            }
        }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(ushort3 input) => (double3)(int3)input;


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
                    fixed (ushort3* ptr = &this)
                    {
                        return ((ushort*)ptr)[index];
                    }
                }
                else
                {
				    return this.GetField<ushort3, ushort>(index);
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
                    fixed (ushort3* ptr = &this)
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
        public static ushort3 operator + (ushort3 left, ushort3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.add_epi16(left, right);
            }
            else
            {
                return new ushort3((ushort)(left.x + right.x), (ushort)(left.y +right.y), (ushort)(left.z +right.z));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator + (ushort left, ushort3 right) => (ushort3)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator + (ushort3 left, ushort right) => left + (ushort3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator - (ushort3 left, ushort3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.sub_epi16(left, right);
            }
            else
            {
                return new ushort3((ushort)(left.x - right.x), (ushort)(left.y -right.y), (ushort)(left.z -right.z));
            }
        }
		
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator - (ushort left, ushort3 right) => (ushort3)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator - (ushort3 left, ushort right) => left - (ushort3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator * (ushort3 left, ushort3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.mullo_epi16(left, right);
            }
            else
            {
                return new ushort3((ushort)(left.x * right.x), (ushort)(left.y *right.y), (ushort)(left.z *right.z));
            }
        }
		
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator * (ushort left, ushort3 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator * (ushort3 left, ushort right)
        {
			if (BurstArchitecture.IsSIMDSupported)
			{
				if (constexpr.IS_CONST(right))
				{
					return (v128)((ushort8)((v128)left) * right);
				}
			}

			return left * (ushort3)right;
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator / (ushort3 left, ushort3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.div_epu16(left, right, 3);
            }
            else
            {
                return new ushort3((ushort)(left.x / right.x), (ushort)(left.y /right.y), (ushort)(left.z /right.z));
            }
        }
		
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator / (ushort left, ushort3 right) => (ushort3)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator / (ushort3 left, ushort right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epu16(left, right, 3);
                }
            }

            return left / (ushort3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator % (ushort3 left, ushort3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rem_epu16(left, right, 3);
            }
            else
            {
                return new ushort3((ushort)(left.x % right.x), (ushort)(left.y %right.y), (ushort)(left.z %right.z));
            }
        }
		
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator % (ushort left, ushort3 right) => (ushort3)left % right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator % (ushort3 left, ushort right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epu16(left, right, 3);
                }
            }

            return left % (ushort3)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator + (ushort3 left, byte3 right) => left + (ushort3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator + (byte3 left, ushort3 right) => (ushort3)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator - (ushort3 left, byte3 right) => left - (ushort3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator - (byte3 left, ushort3 right) => (ushort3)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator * (ushort3 left, byte3 right) => left * (ushort3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator * (byte3 left, ushort3 right) => (ushort3)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator / (ushort3 left, byte3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epu16(left, Xse.cvtepu8_epi16(right), 3);
                }

                v128 left33 = Xse.cvtepu16_ps(left);
                v128 right33 = Xse.cvtepu8_ps(right);
                v128 quotient = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left33, right33);

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
                return new ushort3((ushort)(left.x / right.x), (ushort)(left.y /right.y), (ushort)(left.z /right.z));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator / (byte3 left, ushort3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epu16(Xse.cvtepu8_epi16(left), right, 3);
                }

                v128 left33 = Xse.cvtepu8_ps(left);
                v128 right33 = Xse.cvtepu16_ps(right);
                v128 quotient = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left33, right33);

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
                return new ushort3((ushort)(left.x / right.x), (ushort)(left.y /right.y), (ushort)(left.z /right.z));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator % (ushort3 left, byte3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epu16(left, Xse.cvtepu8_epi16(right), 3);
                }

                v128 left33 = Xse.cvtepu16_ps(left);
                v128 right33 = Xse.cvtepu8_ps(right);
                v128 quotient = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left33, right33);

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
                return new ushort3((ushort)(left.x % right.x), (ushort)(left.y %right.y), (ushort)(left.z %right.z));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator % (byte3 left, ushort3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epu16(Xse.cvtepu8_epi16(left), right, 3);
                }

                v128 left33 = Xse.cvtepu8_ps(left);
                v128 right33 = Xse.cvtepu16_ps(right);
                v128 quotient = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left33, right33);

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
                return new ushort3((ushort)(left.x % right.x), (ushort)(left.y %right.y), (ushort)(left.z %right.z));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator + (ushort3 left, byte right) => left + (ushort)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator + (byte left, ushort3 right) => (ushort)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator - (ushort3 left, byte right) => left - (ushort)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator - (byte left, ushort3 right) => (ushort)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator * (ushort3 left, byte right) => left * (ushort)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator * (byte left, ushort3 right) => (ushort)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator / (ushort3 left, byte right) => left / (ushort)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator / (byte left, ushort3 right) => (ushort)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator % (ushort3 left, byte right) => left % (ushort)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator % (byte left, ushort3 right) => (ushort)left % right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator + (ushort3 left, Unity.Mathematics.int3 right) => left + (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator + (Unity.Mathematics.int3 left, ushort3 right) => (int3)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator - (ushort3 left, Unity.Mathematics.int3 right) => left - (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator - (Unity.Mathematics.int3 left, ushort3 right) => (int3)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator * (ushort3 left, Unity.Mathematics.int3 right) => left * (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator * (Unity.Mathematics.int3 left, ushort3 right) => (int3)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator / (ushort3 left, Unity.Mathematics.int3 right) => left / (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator / (Unity.Mathematics.int3 left, ushort3 right) => (int3)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator % (ushort3 left, Unity.Mathematics.int3 right) => left % (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator % (Unity.Mathematics.int3 left, ushort3 right) => (int3)left % right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator + (ushort3 left, Unity.Mathematics.uint3 right) => left + (uint3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator + (Unity.Mathematics.uint3 left, ushort3 right) => (uint3)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator - (ushort3 left, Unity.Mathematics.uint3 right) => left - (uint3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator - (Unity.Mathematics.uint3 left, ushort3 right) => (uint3)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator * (ushort3 left, Unity.Mathematics.uint3 right) => left * (uint3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator * (Unity.Mathematics.uint3 left, ushort3 right) => (uint3)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator / (ushort3 left, Unity.Mathematics.uint3 right) => left / (uint3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator / (Unity.Mathematics.uint3 left, ushort3 right) => (uint3)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator % (ushort3 left, Unity.Mathematics.uint3 right) => left % (uint3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator % (Unity.Mathematics.uint3 left, ushort3 right) => (uint3)left % right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (ushort3 left, Unity.Mathematics.float3 right) => left + (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (Unity.Mathematics.float3 left, ushort3 right) => (float3)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (ushort3 left, Unity.Mathematics.float3 right) => left - (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (Unity.Mathematics.float3 left, ushort3 right) => (float3)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (ushort3 left, Unity.Mathematics.float3 right) => left * (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (Unity.Mathematics.float3 left, ushort3 right) => (float3)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (ushort3 left, Unity.Mathematics.float3 right) => left / (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (Unity.Mathematics.float3 left, ushort3 right) => (float3)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (ushort3 left, Unity.Mathematics.float3 right) => left % (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (Unity.Mathematics.float3 left, ushort3 right) => (float3)left % right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (ushort3 left, Unity.Mathematics.double3 right) => left + (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (Unity.Mathematics.double3 left, ushort3 right) => (double3)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (ushort3 left, Unity.Mathematics.double3 right) => left - (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (Unity.Mathematics.double3 left, ushort3 right) => (double3)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (ushort3 left, Unity.Mathematics.double3 right) => left * (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (Unity.Mathematics.double3 left, ushort3 right) => (double3)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (ushort3 left, Unity.Mathematics.double3 right) => left / (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (Unity.Mathematics.double3 left, ushort3 right) => (double3)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (ushort3 left, Unity.Mathematics.double3 right) => left % (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (Unity.Mathematics.double3 left, ushort3 right) => (double3)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator & (ushort3 left, ushort3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.and_si128(left, right);
            }
            else
            {
                return new ushort3((ushort)(left.x & right.x), (ushort)(left.y &right.y), (ushort)(left.z &right.z));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator | (ushort3 left, ushort3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.or_si128(left, right);
            }
            else
            {
                return new ushort3((ushort)(left.x | right.x), (ushort)(left.y |right.y), (ushort)(left.z |right.z));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator ^ (ushort3 left, ushort3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.xor_si128(left, right);
            }
            else
            {
                return new ushort3((ushort)(left.x ^ right.x), (ushort)(left.y ^right.y), (ushort)(left.z ^right.z));
            }
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator & (ushort3 left, byte right) => left & (ushort)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator & (byte left, ushort3 right) => (ushort)left & right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator | (ushort3 left, byte right) => left | (ushort)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator | (byte left, ushort3 right) => (ushort)left | right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator ^ (ushort3 left, byte right) => left ^ (ushort)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator ^ (byte left, ushort3 right) => (ushort)left ^ right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator & (ushort3 left, ushort right) => left & (ushort3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator & (ushort left, ushort3 right) => (ushort3)left & right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator | (ushort3 left, ushort right) => left | (ushort3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator | (ushort left, ushort3 right) => (ushort3)left | right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator ^ (ushort3 left, ushort right) => left ^ (ushort3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator ^ (ushort left, ushort3 right) => (ushort3)left ^ right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator & (ushort3 left, byte3 right) => left & (ushort3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator & (byte3 left, ushort3 right) => (ushort3)left & right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator | (ushort3 left, byte3 right) => left | (ushort3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator | (byte3 left, ushort3 right) => (ushort3)left | right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator ^ (ushort3 left, byte3 right) => left ^ (ushort3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator ^ (byte3 left, ushort3 right) => (ushort3)left ^ right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator & (ushort3 left, Unity.Mathematics.int3 right) => left & (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator & (Unity.Mathematics.int3 left, ushort3 right) => (int3)left & right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator | (ushort3 left, Unity.Mathematics.int3 right) => left | (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator | (Unity.Mathematics.int3 left, ushort3 right) => (int3)left | right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ^ (ushort3 left, Unity.Mathematics.int3 right) => left ^ (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ^ (Unity.Mathematics.int3 left, ushort3 right) => (int3)left ^ right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator & (ushort3 left, Unity.Mathematics.uint3 right) => left & (uint3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator & (Unity.Mathematics.uint3 left, ushort3 right) => (uint3)left & right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator | (ushort3 left, Unity.Mathematics.uint3 right) => left | (uint3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator | (Unity.Mathematics.uint3 left, ushort3 right) => (uint3)left | right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator ^ (ushort3 left, Unity.Mathematics.uint3 right) => left ^ (uint3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator ^ (Unity.Mathematics.uint3 left, ushort3 right) => (uint3)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator ++ (ushort3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.inc_epi16(x);
            }
            else
            {
                return new ushort3((ushort)(x.x + 1), (ushort)(x.y + 1), (ushort)(x.z + 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator -- (ushort3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.dec_epi16(x);
            }
            else
            {
                return new ushort3((ushort)(x.x - 1), (ushort)(x.y - 1), (ushort)(x.z - 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator ~ (ushort3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.not_si128(x);
            }
            else
            {
                return new ushort3((ushort)~x.x, (ushort)~x.y, (ushort)~x.z);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator << (ushort3 x, int n)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.slli_epi16(x, n, inRange: true);
            }
            else
            {
                return new ushort3((ushort)(x.x << n), (ushort)(x.y << n), (ushort)(x.z << n));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator >> (ushort3 x, int n)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.srli_epi16(x, n, inRange: true);
            }
            else
            {
                return new ushort3((ushort)(x.x >> n), (ushort)(x.y >> n), (ushort)(x.z >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (ushort3 left, ushort3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
				return Xse.cmpeq_epi16(left, right);
            }
            else
            {
                return new mask16x3(left.x == right.x, left.y == right.y, left.z == right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (ushort3 left, ushort3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
				return Xse.cmplt_epu16(left, right, 3);
            }
            else
            {
                return new mask16x3(left.x < right.x, left.y < right.y, left.z < right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (ushort3 left, ushort3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
				return Xse.cmpgt_epu16(left, right, 3);
            }
            else
            {
                return new mask16x3(left.x > right.x, left.y > right.y, left.z > right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (ushort3 left, ushort3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
				return Xse.not_si128(Xse.cmpeq_epi16(left, right));
            }
            else
            {
                return new mask16x3(left.x != right.x, left.y != right.y, left.z != right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (ushort3 left, ushort3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
				return Xse.cmple_epu16(left, right, 3);
            }
            else
            {
                return new mask16x3(left.x <= right.x, left.y <= right.y, left.z <= right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (ushort3 left, ushort3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
				return Xse.cmpge_epu16(left, right, 3);
            }
            else
            {
                return new mask16x3(left.x >= right.x, left.y >= right.y, left.z >= right.z);
            }
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (ushort3 left, byte right) => left == (ushort)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (byte left, ushort3 right) => (ushort)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (ushort3 left, byte right) => left != (ushort)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (byte left, ushort3 right) => (ushort)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (ushort3 left, byte right) => left < (ushort)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (byte left, ushort3 right) => (ushort)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (ushort3 left, byte right) => left > (ushort)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (byte left, ushort3 right) => (ushort)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (ushort3 left, byte right) => left <= (ushort)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (byte left, ushort3 right) => (ushort)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (ushort3 left, byte right) => left >= (ushort)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (byte left, ushort3 right) => (ushort)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (ushort3 left, ushort right) => left == (ushort3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (ushort left, ushort3 right) => (ushort3)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (ushort3 left, ushort right) => left != (ushort3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (ushort left, ushort3 right) => (ushort3)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (ushort3 left, ushort right) => left < (ushort3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (ushort left, ushort3 right) => (ushort3)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (ushort3 left, ushort right) => left > (ushort3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (ushort left, ushort3 right) => (ushort3)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (ushort3 left, ushort right) => left <= (ushort3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (ushort left, ushort3 right) => (ushort3)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (ushort3 left, ushort right) => left >= (ushort3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (ushort left, ushort3 right) => (ushort3)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (ushort3 left, byte3 right) => left == (ushort3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (byte3 left, ushort3 right) => (ushort3)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (ushort3 left, byte3 right) => left != (ushort3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (byte3 left, ushort3 right) => (ushort3)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (ushort3 left, byte3 right) => left < (ushort3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (byte3 left, ushort3 right) => (ushort3)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (ushort3 left, byte3 right) => left > (ushort3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (byte3 left, ushort3 right) => (ushort3)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (ushort3 left, byte3 right) => left <= (ushort3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (byte3 left, ushort3 right) => (ushort3)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (ushort3 left, byte3 right) => left >= (ushort3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (byte3 left, ushort3 right) => (ushort3)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (ushort3 left, Unity.Mathematics.int3 right) => left == (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (Unity.Mathematics.int3 left, ushort3 right) => (int3)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (ushort3 left, Unity.Mathematics.int3 right) => left != (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (Unity.Mathematics.int3 left, ushort3 right) => (int3)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (ushort3 left, Unity.Mathematics.int3 right) => left < (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (Unity.Mathematics.int3 left, ushort3 right) => (int3)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (ushort3 left, Unity.Mathematics.int3 right) => left > (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (Unity.Mathematics.int3 left, ushort3 right) => (int3)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (ushort3 left, Unity.Mathematics.int3 right) => left <= (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (Unity.Mathematics.int3 left, ushort3 right) => (int3)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (ushort3 left, Unity.Mathematics.int3 right) => left >= (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (Unity.Mathematics.int3 left, ushort3 right) => (int3)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (ushort3 left, Unity.Mathematics.uint3 right) => left == (uint3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (Unity.Mathematics.uint3 left, ushort3 right) => (uint3)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (ushort3 left, Unity.Mathematics.uint3 right) => left != (uint3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (Unity.Mathematics.uint3 left, ushort3 right) => (uint3)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (ushort3 left, Unity.Mathematics.uint3 right) => left < (uint3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (Unity.Mathematics.uint3 left, ushort3 right) => (uint3)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (ushort3 left, Unity.Mathematics.uint3 right) => left > (uint3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (Unity.Mathematics.uint3 left, ushort3 right) => (uint3)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (ushort3 left, Unity.Mathematics.uint3 right) => left <= (uint3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (Unity.Mathematics.uint3 left, ushort3 right) => (uint3)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (ushort3 left, Unity.Mathematics.uint3 right) => left >= (uint3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (Unity.Mathematics.uint3 left, ushort3 right) => (uint3)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (ushort3 left, Unity.Mathematics.float3 right) => left == (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (Unity.Mathematics.float3 left, ushort3 right) => (float3)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (ushort3 left, Unity.Mathematics.float3 right) => left != (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (Unity.Mathematics.float3 left, ushort3 right) => (float3)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (ushort3 left, Unity.Mathematics.float3 right) => left < (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (Unity.Mathematics.float3 left, ushort3 right) => (float3)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (ushort3 left, Unity.Mathematics.float3 right) => left > (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (Unity.Mathematics.float3 left, ushort3 right) => (float3)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (ushort3 left, Unity.Mathematics.float3 right) => left <= (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (Unity.Mathematics.float3 left, ushort3 right) => (float3)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (ushort3 left, Unity.Mathematics.float3 right) => left >= (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (Unity.Mathematics.float3 left, ushort3 right) => (float3)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (ushort3 left, Unity.Mathematics.double3 right) => left == (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (Unity.Mathematics.double3 left, ushort3 right) => (double3)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (ushort3 left, Unity.Mathematics.double3 right) => left != (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (Unity.Mathematics.double3 left, ushort3 right) => (double3)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (ushort3 left, Unity.Mathematics.double3 right) => left < (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (Unity.Mathematics.double3 left, ushort3 right) => (double3)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (ushort3 left, Unity.Mathematics.double3 right) => left > (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (Unity.Mathematics.double3 left, ushort3 right) => (double3)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (ushort3 left, Unity.Mathematics.double3 right) => left <= (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (Unity.Mathematics.double3 left, ushort3 right) => (double3)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (ushort3 left, Unity.Mathematics.double3 right) => left >= (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (Unity.Mathematics.double3 left, ushort3 right) => (double3)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ushort3 other)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return bitmask64(48ul) == (bitmask64(48ul) & Xse.cmpeq_epi16(this, other).ULong0);
            }
            else
            {
                return this.x == other.x & this.y == other.y & this.z == other.z;
            }
        }

        public override bool Equals(object obj) => obj is ushort3 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        public override string ToString() => $"ushort3({x}, {y}, {z})";
        public string ToString(string format, IFormatProvider formatProvider) => $"ushort3({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)})";
    }
}