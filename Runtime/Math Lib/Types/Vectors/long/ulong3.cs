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
    internal sealed class ulong3DebuggerProxy
    {
        public ulong x;
        public ulong y;
        public ulong z;
        
        public ulong3DebuggerProxy(ulong3 v)
        {
            x = v.x;
            y = v.y;
            z = v.z;
        }
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(ulong3DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public struct ulong3 : IEquatable<ulong3>, IFormattable
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal ulong2 __x0;
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal ulong __x2;
        
        public ref ulong x { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(ulong3* ptr = &this) { return ref *((ulong*)ptr +  0); } } }
        public ref ulong y { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(ulong3* ptr = &this) { return ref *((ulong*)ptr +  1); } } }
        public ref ulong z { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(ulong3* ptr = &this) { return ref *((ulong*)ptr +  2); } } }


        public static ulong3 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(ulong x, ulong y, ulong z)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_set_epi64x(0L, (long)z, (long)y, (long)x);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                this = new ulong3 { __x0 = new ulong2(x, y), z = z };
            }
            else
            {
                this = new ulong3 { x = x, y = y, z = z };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(ulong xyz)
        {
            if (Avx.IsAvxSupported)
            {
                this = Xse.mm256_set1_epi64x(xyz);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                this = new ulong3 { __x0 = new ulong2(xyz), z = xyz };
            }
            else
            {
                this = new ulong3 { x = xyz, y = xyz, z = xyz };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(ulong2 xy, ulong z)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_insert_epi64(Avx.mm256_castsi128_si256(xy), (long)z, 2);
            }
            else
            {
                this = new ulong3 { __x0 = xy, z = z };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(ulong x, ulong2 yz)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_insert_epi64(yz.xxy, (long)x, 0);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                yz = yz.yx;
                ulong z = yz.x;
                yz.x = x;

                this = new ulong3 { __x0 = yz, z = z };
            }
            else
            {
                this = new ulong3 { x = x, y = yz.x, z = yz.y };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(bool v)
        {
            this = (ulong3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(bool3 v)
        {
            this = (ulong3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(mask8x3 v)
        {
            this = (ulong3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(mask16x3 v)
        {
            this = (ulong3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(mask32x3 v)
        {
            this = (ulong3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(mask64x3 v)
        {
            this = (ulong3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(byte v)
        {
            this = (ulong3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(byte3 v)
        {
            this = (ulong3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(sbyte v)
        {
            this = (ulong3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(sbyte3 v)
        {
            this = (ulong3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(ushort v)
        {
            this = (ulong3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(ushort3 v)
        {
            this = (ulong3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(short v)
        {
            this = (ulong3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(short3 v)
        {
            this = (ulong3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(uint v)
        {
            this = (ulong3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(uint3 v)
        {
            this = (ulong3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(int v)
        {
            this = (ulong3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(int3 v)
        {
            this = (ulong3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(ulong3 v)
        {
            this = (ulong3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(long v)
        {
            this = (ulong3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(long3 v)
        {
            this = (ulong3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(UInt128 v)
        {
            this = (ulong3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(Int128 v)
        {
            this = (ulong3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(quarter v)
        {
            this = (ulong3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(quarter3 v)
        {
            this = (ulong3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(half v)
        {
            this = (ulong3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(half3 v)
        {
            this = (ulong3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(float v)
        {
            this = (ulong3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(float3 v)
        {
            this = (ulong3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(double v)
        {
            this = (ulong3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(double3 v)
        {
            this = (ulong3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(quadruple v)
        {
            this = (ulong3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(Unity.Mathematics.bool3 v)
        {
            this = (ulong3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(Unity.Mathematics.uint3 v)
        {
            this = (ulong3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(Unity.Mathematics.int3 v)
        {
            this = (ulong3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(Unity.Mathematics.half v)
        {
            this = (ulong3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(Unity.Mathematics.half3 v)
        {
            this = (ulong3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(Unity.Mathematics.float3 v)
        {
            this = (ulong3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(Unity.Mathematics.double3 v)
        {
            this = (ulong3)v;
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
                    return new ulong4(xx, __x0);
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
                    return Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(1, 0, 1, 0));
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
                    return new ulong4(__x0, xx);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly ulong4 xyxy
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
                    return new ulong4(__x0, __x0);
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
                    return new ulong4(__x0, xz);
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
                    return new ulong4(__x0, yx);
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
                    return new ulong4(__x0, yy);
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
                    return new ulong4(__x0, yz);
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
                    return new ulong4(__x0, zx);
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
                    return new ulong4(__x0, zy);
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
                    return new ulong4(__x0, zz);
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
                    return new ulong4(xz, __x0);
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
                    return new ulong4(yx, __x0);
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
                    return new ulong4(yy, __x0);
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
                    return new ulong4(yz, __x0);
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
                    return new ulong4(zx, __x0);
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
                    return new ulong4(zy, __x0);
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
                    return new ulong4(zz, __x0);
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
                    return Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(1, 0, 1, 0));
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
        public ulong3 xyx
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
                    return new ulong3(__x0, x);
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
                    return new ulong3(__x0, y);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 xyz
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
                this = value.xzy;
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
                this = value.yxz;
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
                this = value.zxy;
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
                this = value.yzx;
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
                this = value.zyx;
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
        public ulong2 xx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.shuffle_epi32(Avx.mm256_castsi256_si128(this), Sse.SHUFFLE(1, 0, 1, 0));
                }
                else
                {
                    return __x0.xx;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong2 xy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx.mm256_castsi256_si128(this);
                }
                else
                {
                    return __x0;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx2.mm256_inserti128_si256(this, value, 0);
                }
                else
                {
                    this.__x0 = value;
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
                else
                {
                    ulong2 _xz = __x0;
                    _xz.y = z;
                    return _xz;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx2.mm256_blend_epi32(this, value.xxyy, 0b0011_0011);
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
        public ulong2 yx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.shuffle_epi32(Avx.mm256_castsi256_si128(this), Sse.SHUFFLE(1, 0, 3, 2));
                }
                else
                {
                    return __x0.yx;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx2.mm256_inserti128_si256(this, value.yx, 0);
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
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.shuffle_epi32(Avx.mm256_castsi256_si128(this), Sse.SHUFFLE(3, 2, 3, 2));
                }
                else
                {
                    return __x0.yy;
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
                    this = Avx2.mm256_blend_epi32(this, value.yxyx, 0b0011_1100);
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
        public ulong2 zx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 2)));
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
                else
                {
                    ulong2 _zy = __x0;
                    _zy.x = z;
                    return _zy;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx2.mm256_blend_epi32(this, value.yyxx, 0b0011_1100);
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
                else
                {
                    return new ulong2(z, z);
                }
            }
        }
        #endregion

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v256(ulong3 input)
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
            result.ULong2 = input.__x2;
            
            return result;
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong3(v256 input) => new ulong3 { __x0 = new ulong2 { __x0 = input.ULong0, __x1 = input.ULong1 }, __x2 = input.ULong2 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(bool x) => math.tobyte(x);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(bool3 x) => (ulong3)(mask64x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(Unity.Mathematics.bool3 x) => (ulong3)(mask64x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(mask8x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (ulong3)(mask64x3)x;
            }
            else
            {
                return *(byte3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(mask16x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (ulong3)(mask64x3)x;
            }
            else
            {
                return *(byte3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(mask32x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (ulong3)(mask64x3)x;
            }
            else
            {
                return *(byte3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(mask64x3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_neg_epi64(x);
            }
            else
            {
                return new ulong3((ulong2)x.xy, math.tobyte(x.z));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3(ulong3 x) => (mask64x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool3(ulong3 x) => (mask64x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3(ulong3 x) => (mask64x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x3(ulong3 x) => (mask64x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x3(ulong3 x) => (mask64x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x3(ulong3 x) => x != 0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator ulong3(byte x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(sbyte x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator ulong3(ushort x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(short x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator ulong3(uint x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(int x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(long x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(UInt128 x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(Int128 x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(quarter x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(half x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(float x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(double x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(quadruple x) => (ulong)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(Unity.Mathematics.half x) => (ulong3)(half)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(Unity.Mathematics.half3 x) => (ulong3)(half3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(Unity.Mathematics.float3 x) => (ulong3)(float3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(Unity.Mathematics.double3 x) => (ulong3)(double3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong3(Unity.Mathematics.uint3 x) => (ulong3)(uint3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(Unity.Mathematics.int3 x) => (ulong3)(int3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.half3(ulong3 x) => (half3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float3(ulong3 x) => (float3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double3(ulong3 x) => (double3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint3(ulong3 x) => (uint3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int3(ulong3 x) => (int3)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong3(ulong input) => new ulong3(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(long3 input) => *(ulong3*)&input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong3(uint3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepu32_epi64(input);
            }
            else
            {
                return new ulong3
                {
                    __x0 = (ulong2)input.xy,
                    z = (ulong)input.z
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(int3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepi32_epi64(input);
            }
            else
            {
                return new ulong3
                {
                    __x0 = (ulong2)input.xy,
                    z = (ulong)input.z
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(float3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttps_epu64(input, 3);
            }
            else
            {
                return new ulong3((ulong2)input.xy, (ulong)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(double3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttpd_epu64(input, 3);
            }
            else
            {
                return new ulong3((ulong2)input.xy, (ulong)input.z);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(ulong3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepi64_epi32(input);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 temp = Xse.cvtepi64_epi32(input.__x0);

                return Xse.unpacklo_epi64(temp, Xse.cvtsi32_si128((int)input.z));
            }
            else
            {
                return new uint3((uint2)input.xy, (uint)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(ulong3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepi64_epi32(input);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 temp = Xse.cvtepi64_epi32(input.__x0);

                return Xse.unpacklo_epi64(temp, Xse.cvtsi32_si128((int)input.z));
            }
            else
            {
                return new int3((int2)input.xy, (int)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(ulong3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepu64_ps(input, 3);
            }
            else
            {
                return new float3((float2)input.__x0, (float)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(ulong3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepu64_pd(input, 3);
            }
            else
            {
                return new double3((double2)input.__x0, (double)input.z);
            }
        }


        public ulong this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 3);

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
                            return z;
                        }
                    }
                }

                if (BurstArchitecture.IsBurstCompiled)
                {
                    fixed (ulong3* ptr = &this)
                    {
                        return ((ulong*)ptr)[index];
                    }
                }
                else
                {
                    return this.GetField<ulong3, ulong>(index);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 3);

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
                            z = value;
                        }

                        return;
                    }
                }

                if (BurstArchitecture.IsBurstCompiled)
                {
                    fixed (ulong3* ptr = &this)
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
        public static ulong3 operator + (ulong3 left, ulong3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Avx2.mm256_add_epi64(left, right);
			}
			else
			{
				return new ulong3(left.__x0 + right.__x0, left.z + right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator - (ulong3 left, ulong3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Avx2.mm256_sub_epi64(left, right);
			}
			else
			{
				return new ulong3(left.__x0 - right.__x0, left.z - right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator * (ulong3 left, ulong3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_mullo_epi64(left, right);
			}
			else
			{
				return new ulong3(left.__x0 * right.__x0, left.z * right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator / (ulong3 left, ulong3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epu64(left, right, elements: 3);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new ulong3(Xse.div_epu64(left.xy, right.xy, useFPU: true), left.z / right.z);
			}
			else
			{
				return new ulong3(left.__x0 / right.__x0, left.z / right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator % (ulong3 left, ulong3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epu64(left, right, elements: 3);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new ulong3(Xse.rem_epu64(left.xy, right.xy, useFPU: true), left.z % right.z);
			}
			else
			{
				return new ulong3(left.__x0 % right.__x0, left.z % right.z);
			}
		}

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator + (ulong3 left, byte right) => left + (byte3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator + (ulong3 left, ushort right) => left + (ushort3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator + (ulong3 left, uint right) => left + (uint3)right;
        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong3 operator + (ulong3 left, ulong right) => left + (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator - (ulong3 left, byte right) => left - (byte3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator - (ulong3 left, ushort right) => left - (ushort3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator - (ulong3 left, uint right) => left - (uint3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator - (ulong3 left, ulong right) => left - (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator * (ulong3 left, byte right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator * (ulong3 left, ushort right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator * (ulong3 left, uint right) => right * left;
        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator * (ulong3 left, ulong right)
		{
			if (Avx2.IsAvx2Supported)
			{
				if (constexpr.IS_CONST(right))
				{
					return new ulong3(left.x * right, left.y * right, left.z * right);
				}
			}

            return new ulong3(left.xy * right, left.z * right);
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator / (ulong3 left, byte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left / (ulong)right;
                }
            }

            return left / (byte3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator / (ulong3 left, ushort right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left / (ulong)right;
                }
            }

            return left / (ushort3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator / (ulong3 left, uint right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left / (ulong)right;
                }
            }

            return left / (uint3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator / (ulong3 left, ulong right)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.mm256_constdiv_epu64(left, right, 3);
                }
            }

            return new ulong3(left.xy / right, left.z / right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator % (ulong3 left, byte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left % (ulong)right;
                }
            }

            return left % (byte3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator % (ulong3 left, ushort right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left % (ulong)right;
                }
            }

            return left % (ushort3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator % (ulong3 left, uint right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left % (ulong)right;
                }
            }

            return left % (uint3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator % (ulong3 left, ulong right)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.mm256_constrem_epu64(left, right, 3);
                }
            }

            return new ulong3(left.xy % right, left.z % right);
        }
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator + (byte left, ulong3 right) => (byte3)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator + (ushort left, ulong3 right) => (ushort3)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator + (uint left, ulong3 right) => (uint3)left + right;
        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong3 operator + (ulong left, ulong3 right) => (ulong3)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator - (byte left, ulong3 right) => (byte3)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator - (ushort left, ulong3 right) => (ushort3)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator - (uint left, ulong3 right) => (uint3)left - right;
        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong3 operator - (ulong left, ulong3 right) => (ulong3)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator * (byte left, ulong3 right) => (ulong)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator * (ushort left, ulong3 right) => (ulong)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator * (uint left, ulong3 right) => (ulong)left * right;
        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong3 operator * (ulong left, ulong3 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator / (byte left, ulong3 right) => (byte3)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator / (ushort left, ulong3 right) => (ushort3)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator / (uint left, ulong3 right) => (uint3)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator / (ulong left, ulong3 right) => (ulong3)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator % (byte left, ulong3 right) => (byte3)left % right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator % (ushort left, ulong3 right) => (ushort3)left % right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator % (uint left, ulong3 right) => (uint3)left % right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator % (ulong left, ulong3 right) => (ulong3)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator + (ulong3 left, byte3 right) => left + (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator + (byte3 left, ulong3 right) => (ulong3)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator - (ulong3 left, byte3 right) => left - (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator - (byte3 left, ulong3 right) => (ulong3)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator * (ulong3 left, byte3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_mullo_epi64(left, (ulong3)right, 3, unsigned_B_lessequalU32Max: true);
            }
            else
            {
                return new ulong3(left.xy * right.xy, left.z * right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator * (byte3 left, ulong3 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator / (byte3 left, ulong3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epu64(Xse.mm256_cvtepu8_pd(left), right, elements: 3, aIsDbl: true, aLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new ulong3(Xse.div_epu64(Xse.cvtepu8_pd(left), right.xy, useFPU: true, aIsDbl: true, aLEu32max: true), left.z / right.z);
			}
			else
			{
				return new ulong3(left.xy / right.__x0, left.z / right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator / (ulong3 left, byte3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epu64(left, Xse.mm256_cvtepu8_pd(right), elements: 3, bIsDbl: true, bLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new ulong3(Xse.div_epu64(left.xy, Xse.cvtepu8_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true), left.z / right.z);
			}
			else
			{
				return new ulong3(left.__x0 / right.xy, left.z / right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator % (byte3 left, ulong3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epu64(Xse.mm256_cvtepu8_pd(left), right, elements: 3, aIsDbl: true, aLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new ulong3(Xse.rem_epu64(Xse.cvtepu8_pd(left), right.xy, useFPU: true, aIsDbl: true, aLEu32max: true), left.z % right.z);
			}
			else
			{
				return new ulong3(left.xy % right.__x0, left.z % right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator % (ulong3 left, byte3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epu64(left, Xse.mm256_cvtepu8_pd(right), elements: 3, bIsDbl: true, bLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new ulong3(Xse.rem_epu64(left.xy, Xse.cvtepu8_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true), left.z % right.z);
			}
			else
			{
				return new ulong3(left.__x0 % right.xy, left.z % right.z);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator + (ulong3 left, ushort3 right) => left + (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator + (ushort3 left, ulong3 right) => (ulong3)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator - (ulong3 left, ushort3 right) => left - (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator - (ushort3 left, ulong3 right) => (ulong3)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator * (ulong3 left, ushort3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_mullo_epi64(left, (ulong3)right, 3, unsigned_B_lessequalU32Max: true);
            }
            else
            {
                return new ulong3(left.xy * right.xy, left.z * right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator * (ushort3 left, ulong3 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator / (ushort3 left, ulong3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epu64(Xse.mm256_cvtepu16_pd(left), right, elements: 3, aIsDbl: true, aLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new ulong3(Xse.div_epu64(Xse.cvtepu16_pd(left), right.xy, useFPU: true, aIsDbl: true, aLEu32max: true), left.z / right.z);
			}
			else
			{
				return new ulong3(left.xy / right.__x0, left.z / right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator / (ulong3 left, ushort3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epu64(left, Xse.mm256_cvtepu16_pd(right), elements: 3, bIsDbl: true, bLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new ulong3(Xse.div_epu64(left.xy, Xse.cvtepu16_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true), left.z / right.z);
			}
			else
			{
				return new ulong3(left.__x0 / right.xy, left.z / right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator % (ushort3 left, ulong3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epu64(Xse.mm256_cvtepu16_pd(left), right, elements: 3, aIsDbl: true, aLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new ulong3(Xse.rem_epu64(Xse.cvtepu16_pd(left), right.xy, useFPU: true, aIsDbl: true, aLEu32max: true), left.z % right.z);
			}
			else
			{
				return new ulong3(left.xy % right.__x0, left.z % right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator % (ulong3 left, ushort3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epu64(left, Xse.mm256_cvtepu16_pd(right), elements: 3, bIsDbl: true, bLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new ulong3(Xse.rem_epu64(left.xy, Xse.cvtepu16_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true), left.z % right.z);
			}
			else
			{
				return new ulong3(left.__x0 % right.xy, left.z % right.z);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator + (ulong3 left, uint3 right) => left + (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator + (uint3 left, ulong3 right) => (ulong3)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator - (ulong3 left, uint3 right) => left - (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator - (uint3 left, ulong3 right) => (ulong3)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator * (ulong3 left, uint3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_mullo_epi64(left, (ulong3)right, 3, unsigned_B_lessequalU32Max: true);
            }
            else
            {
                return new ulong3(left.xy * right.xy, left.z * right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator * (uint3 left, ulong3 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator / (uint3 left, ulong3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epu64(Xse.mm256_cvtepu32_pd(left), right, elements: 3, aIsDbl: true, aLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new ulong3(Xse.div_epu64(Xse.cvtepu32_pd(left), right.xy, useFPU: true, aIsDbl: true, aLEu32max: true), left.z / right.z);
			}
			else
			{
				return new ulong3(left.xy / right.__x0, left.z / right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator / (ulong3 left, uint3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epu64(left, Xse.mm256_cvtepu32_pd(right), elements: 3, bIsDbl: true, bLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new ulong3(Xse.div_epu64(left.xy, Xse.cvtepu32_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true), left.z / right.z);
			}
			else
			{
				return new ulong3(left.__x0 / right.xy, left.z / right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator % (uint3 left, ulong3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epu64(Xse.mm256_cvtepu32_pd(left), right, elements: 3, aIsDbl: true, aLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new ulong3(Xse.rem_epu64(Xse.cvtepu32_pd(left), right.xy, useFPU: true, aIsDbl: true, aLEu32max: true), left.z % right.z);
			}
			else
			{
				return new ulong3(left.xy % right.__x0, left.z % right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator % (ulong3 left, uint3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epu64(left, Xse.mm256_cvtepu32_pd(right), elements: 3, bIsDbl: true, bLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new ulong3(Xse.rem_epu64(left.xy, Xse.cvtepu32_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true), left.z % right.z);
			}
			else
			{
				return new ulong3(left.__x0 % right.xy, left.z % right.z);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator + (ulong3 left, Unity.Mathematics.uint3 right) => left + (uint3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator - (ulong3 left, Unity.Mathematics.uint3 right) => left - (uint3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator * (ulong3 left, Unity.Mathematics.uint3 right) => left * (uint3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator / (ulong3 left, Unity.Mathematics.uint3 right) => left / (uint3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator % (ulong3 left, Unity.Mathematics.uint3 right) => left % (uint3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator + (Unity.Mathematics.uint3 left, ulong3 right) => (uint3)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator - (Unity.Mathematics.uint3 left, ulong3 right) => (uint3)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator * (Unity.Mathematics.uint3 left, ulong3 right) => (uint3)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator / (Unity.Mathematics.uint3 left, ulong3 right) => (uint3)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator % (Unity.Mathematics.uint3 left, ulong3 right) => (uint3)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (ulong3 left, Unity.Mathematics.float3 right) => left + (float3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (ulong3 left, Unity.Mathematics.float3 right) => left - (float3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (ulong3 left, Unity.Mathematics.float3 right) => left * (float3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (ulong3 left, Unity.Mathematics.float3 right) => left / (float3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (ulong3 left, Unity.Mathematics.float3 right) => left % (float3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (Unity.Mathematics.float3 left, ulong3 right) => (float3)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (Unity.Mathematics.float3 left, ulong3 right) => (float3)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (Unity.Mathematics.float3 left, ulong3 right) => (float3)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (Unity.Mathematics.float3 left, ulong3 right) => (float3)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (Unity.Mathematics.float3 left, ulong3 right) => (float3)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (ulong3 left, Unity.Mathematics.double3 right) => left + (double3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (ulong3 left, Unity.Mathematics.double3 right) => left - (double3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (ulong3 left, Unity.Mathematics.double3 right) => left * (double3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (ulong3 left, Unity.Mathematics.double3 right) => left / (double3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (ulong3 left, Unity.Mathematics.double3 right) => left % (double3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (Unity.Mathematics.double3 left, ulong3 right) => (double3)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (Unity.Mathematics.double3 left, ulong3 right) => (double3)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (Unity.Mathematics.double3 left, ulong3 right) => (double3)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (Unity.Mathematics.double3 left, ulong3 right) => (double3)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (Unity.Mathematics.double3 left, ulong3 right) => (double3)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator & (ulong3 left, ulong3 right)
		{
			if (Avx.IsAvxSupported)
			{
				return Avx.mm256_and_ps(left, right);
			}
			else
			{
				return new ulong3(left.xy & right.xy, left.z & right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator | (ulong3 left, ulong3 right)
		{
			if (Avx.IsAvxSupported)
			{
				return Avx.mm256_or_ps(left, right);
			}
			else
			{
				return new ulong3(left.xy | right.xy, left.z | right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator ^ (ulong3 left, ulong3 right)
		{
			if (Avx.IsAvxSupported)
			{
				return Avx.mm256_xor_ps(left, right);
			}
			else
			{
				return new ulong3(left.xy ^ right.xy, left.z ^ right.z);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator & (ulong3 left, byte3 right) => left & (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator | (ulong3 left, byte3 right) => left | (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator ^ (ulong3 left, byte3 right) => left ^ (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator & (byte3 left, ulong3 right) => (ulong3)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator | (byte3 left, ulong3 right) => (ulong3)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator ^ (byte3 left, ulong3 right) => (ulong3)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator & (ulong3 left, ushort3 right) => left & (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator | (ulong3 left, ushort3 right) => left | (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator ^ (ulong3 left, ushort3 right) => left ^ (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator & (ushort3 left, ulong3 right) => (ulong3)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator | (ushort3 left, ulong3 right) => (ulong3)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator ^ (ushort3 left, ulong3 right) => (ulong3)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator & (ulong3 left, uint3 right) => left & (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator | (ulong3 left, uint3 right) => left | (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator ^ (ulong3 left, uint3 right) => left ^ (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator & (uint3 left, ulong3 right) => (ulong3)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator | (uint3 left, ulong3 right) => (ulong3)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator ^ (uint3 left, ulong3 right) => (ulong3)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator & (ulong3 left, Unity.Mathematics.uint3 right) => left & (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator | (ulong3 left, Unity.Mathematics.uint3 right) => left | (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator ^ (ulong3 left, Unity.Mathematics.uint3 right) => left ^ (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator & (Unity.Mathematics.uint3 left, ulong3 right) => (ulong3)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator | (Unity.Mathematics.uint3 left, ulong3 right) => (ulong3)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator ^ (Unity.Mathematics.uint3 left, ulong3 right) => (ulong3)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator & (ulong3 left, byte right) => left & (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator | (ulong3 left, byte right) => left | (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator ^ (ulong3 left, byte right) => left ^ (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator & (byte left, ulong3 right) => (ulong3)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator | (byte left, ulong3 right) => (ulong3)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator ^ (byte left, ulong3 right) => (ulong3)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator & (ulong3 left, ushort right) => left & (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator | (ulong3 left, ushort right) => left | (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator ^ (ulong3 left, ushort right) => left ^ (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator & (ushort left, ulong3 right) => (ulong3)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator | (ushort left, ulong3 right) => (ulong3)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator ^ (ushort left, ulong3 right) => (ulong3)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator & (ulong3 left, uint right) => left & (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator | (ulong3 left, uint right) => left | (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator ^ (ulong3 left, uint right) => left ^ (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator & (uint left, ulong3 right) => (ulong3)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator | (uint left, ulong3 right) => (ulong3)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator ^ (uint left, ulong3 right) => (ulong3)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator & (ulong3 left, ulong right) => left & (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator | (ulong3 left, ulong right) => left | (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator ^ (ulong3 left, ulong right) => left ^ (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator & (ulong left, ulong3 right) => (ulong3)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator | (ulong left, ulong3 right) => (ulong3)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator ^ (ulong left, ulong3 right) => (ulong3)left ^ right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator ++ (ulong3 x)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_inc_epi64(x);
			}
			else
			{
				return new ulong3(x.__x0 + 1, x.z + 1);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator -- (ulong3 x)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_dec_epi64(x);
			}
			else
			{
				return new ulong3(x.__x0 - 1, x.z - 1);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator ~ (ulong3 x)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_not_si256(x);
			}
			else
			{
				return new ulong3(~x.__x0, ~x.z);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator << (ulong3 x, int n)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_slli_epi64(x, n);
			}
			else
			{
				return new ulong3(x.__x0 << n, x.z << n);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator >> (ulong3 x, int n)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_srli_epi64(x, n);
			}
			else
			{
				return new ulong3(x.__x0 >> n, x.z >> n);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (ulong3 left, ulong3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Avx2.mm256_cmpeq_epi64(left, right);
			}
			else
			{
				return new mask64x3(left.__x0 == right.__x0, left.z == right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (ulong3 left, ulong3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_cmplt_epu64(left, right, 3);
			}
			else
			{
				return new mask64x3(left.__x0 < right.__x0, left.z < right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (ulong3 left, ulong3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_cmpgt_epu64(left, right, 3);
			}
			else
			{
				return new mask64x3(left.__x0 > right.__x0, left.z > right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (ulong3 left, ulong3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_not_si256(Avx2.mm256_cmpeq_epi64(left, right));
			}
			else
			{
				return new mask64x3(left.__x0 != right.__x0, left.z != right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (ulong3 left, ulong3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_not_si256(Xse.mm256_cmpgt_epu64(left, right, 3));
			}
			else
			{
				return new mask64x3(left.__x0 <= right.__x0, left.z <= right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (ulong3 left, ulong3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_not_si256(Xse.mm256_cmplt_epu64(left, right, 3));
			}
			else
			{
				return new mask64x3(left.__x0 >= right.__x0, left.z >= right.z);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (ulong3 left, byte right) => left == (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (byte left, ulong3 right) => (ulong3)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (ulong3 left, byte right) => left != (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (byte left, ulong3 right) => (ulong3)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (ulong3 left, byte right) => left < (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (byte left, ulong3 right) => (ulong3)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (ulong3 left, byte right) => left > (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (byte left, ulong3 right) => (ulong3)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (ulong3 left, byte right) => left <= (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (byte left, ulong3 right) => (ulong3)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (ulong3 left, byte right) => left >= (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (byte left, ulong3 right) => (ulong3)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (ulong3 left, ushort right) => left == (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (ushort left, ulong3 right) => (ulong3)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (ulong3 left, ushort right) => left != (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (ushort left, ulong3 right) => (ulong3)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (ulong3 left, ushort right) => left < (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (ushort left, ulong3 right) => (ulong3)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (ulong3 left, ushort right) => left > (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (ushort left, ulong3 right) => (ulong3)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (ulong3 left, ushort right) => left <= (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (ushort left, ulong3 right) => (ulong3)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (ulong3 left, ushort right) => left >= (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (ushort left, ulong3 right) => (ulong3)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (ulong3 left, uint right) => left == (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (uint left, ulong3 right) => (ulong3)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (ulong3 left, uint right) => left != (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (uint left, ulong3 right) => (ulong3)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (ulong3 left, uint right) => left < (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (uint left, ulong3 right) => (ulong3)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (ulong3 left, uint right) => left > (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (uint left, ulong3 right) => (ulong3)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (ulong3 left, uint right) => left <= (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (uint left, ulong3 right) => (ulong3)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (ulong3 left, uint right) => left >= (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (uint left, ulong3 right) => (ulong3)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (ulong3 left, ulong right) => left == (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (ulong left, ulong3 right) => (ulong3)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (ulong3 left, ulong right) => left != (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (ulong left, ulong3 right) => (ulong3)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (ulong3 left, ulong right) => left < (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (ulong left, ulong3 right) => (ulong3)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (ulong3 left, ulong right) => left > (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (ulong left, ulong3 right) => (ulong3)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (ulong3 left, ulong right) => left <= (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (ulong left, ulong3 right) => (ulong3)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (ulong3 left, ulong right) => left >= (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (ulong left, ulong3 right) => (ulong3)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (ulong3 left, byte3 right) => left == (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (byte3 left, ulong3 right) => (ulong3)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (ulong3 left, byte3 right) => left != (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (byte3 left, ulong3 right) => (ulong3)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (ulong3 left, byte3 right) => left < (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (byte3 left, ulong3 right) => (ulong3)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (ulong3 left, byte3 right) => left > (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (byte3 left, ulong3 right) => (ulong3)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (ulong3 left, byte3 right) => left <= (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (byte3 left, ulong3 right) => (ulong3)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (ulong3 left, byte3 right) => left >= (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (byte3 left, ulong3 right) => (ulong3)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (ulong3 left, ushort3 right) => left == (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (ushort3 left, ulong3 right) => (ulong3)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (ulong3 left, ushort3 right) => left != (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (ushort3 left, ulong3 right) => (ulong3)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (ulong3 left, ushort3 right) => left < (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (ushort3 left, ulong3 right) => (ulong3)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (ulong3 left, ushort3 right) => left > (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (ushort3 left, ulong3 right) => (ulong3)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (ulong3 left, ushort3 right) => left <= (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (ushort3 left, ulong3 right) => (ulong3)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (ulong3 left, ushort3 right) => left >= (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (ushort3 left, ulong3 right) => (ulong3)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (ulong3 left, uint3 right) => left == (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (uint3 left, ulong3 right) => (ulong3)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (ulong3 left, uint3 right) => left != (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (uint3 left, ulong3 right) => (ulong3)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (ulong3 left, uint3 right) => left < (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (uint3 left, ulong3 right) => (ulong3)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (ulong3 left, uint3 right) => left > (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (uint3 left, ulong3 right) => (ulong3)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (ulong3 left, uint3 right) => left <= (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (uint3 left, ulong3 right) => (ulong3)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (ulong3 left, uint3 right) => left >= (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (uint3 left, ulong3 right) => (ulong3)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (ulong3 left, Unity.Mathematics.uint3 right) => left == (uint3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (Unity.Mathematics.uint3 left, ulong3 right) => (uint3)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (ulong3 left, Unity.Mathematics.uint3 right) => left != (uint3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (Unity.Mathematics.uint3 left, ulong3 right) => (uint3)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (ulong3 left, Unity.Mathematics.uint3 right) => left < (uint3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (Unity.Mathematics.uint3 left, ulong3 right) => (uint3)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (ulong3 left, Unity.Mathematics.uint3 right) => left > (uint3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (Unity.Mathematics.uint3 left, ulong3 right) => (uint3)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (ulong3 left, Unity.Mathematics.uint3 right) => left <= (uint3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (Unity.Mathematics.uint3 left, ulong3 right) => (uint3)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (ulong3 left, Unity.Mathematics.uint3 right) => left >= (uint3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (Unity.Mathematics.uint3 left, ulong3 right) => (uint3)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (ulong3 left, Unity.Mathematics.float3 right) => left == (float3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (Unity.Mathematics.float3 left, ulong3 right) => (float3)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (ulong3 left, Unity.Mathematics.float3 right) => left != (float3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (Unity.Mathematics.float3 left, ulong3 right) => (float3)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (ulong3 left, Unity.Mathematics.float3 right) => left < (float3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (Unity.Mathematics.float3 left, ulong3 right) => (float3)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (ulong3 left, Unity.Mathematics.float3 right) => left > (float3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (Unity.Mathematics.float3 left, ulong3 right) => (float3)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (ulong3 left, Unity.Mathematics.float3 right) => left <= (float3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (Unity.Mathematics.float3 left, ulong3 right) => (float3)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (ulong3 left, Unity.Mathematics.float3 right) => left >= (float3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (Unity.Mathematics.float3 left, ulong3 right) => (float3)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (ulong3 left, Unity.Mathematics.double3 right) => left == (double3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (Unity.Mathematics.double3 left, ulong3 right) => (double3)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (ulong3 left, Unity.Mathematics.double3 right) => left != (double3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (Unity.Mathematics.double3 left, ulong3 right) => (double3)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (ulong3 left, Unity.Mathematics.double3 right) => left < (double3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (Unity.Mathematics.double3 left, ulong3 right) => (double3)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (ulong3 left, Unity.Mathematics.double3 right) => left > (double3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (Unity.Mathematics.double3 left, ulong3 right) => (double3)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (ulong3 left, Unity.Mathematics.double3 right) => left <= (double3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (Unity.Mathematics.double3 left, ulong3 right) => (double3)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (ulong3 left, Unity.Mathematics.double3 right) => left >= (double3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (Unity.Mathematics.double3 left, ulong3 right) => (double3)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ulong3 other)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_alltrue_epi256<ulong>(Avx2.mm256_cmpeq_epi64(this, other), 3);
            }
            else
            {
                return this.__x0.Equals(other.__x0) & this.z == other.z;
            }
        }

        public override bool Equals(object obj) => obj is ulong3 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        public override string ToString() => $"ulong3({x}, {y}, {z})";
        public string ToString(string format, IFormatProvider formatProvider) => $"ulong3({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)})";
    }
}