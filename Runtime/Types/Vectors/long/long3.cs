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
    [Serializable]  [StructLayout(LayoutKind.Explicit, Size = 3 * sizeof(long))]  [DebuggerTypeProxy(typeof(long3.DebuggerProxy))]
    unsafe public struct long3 : IEquatable<long3>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public long x;
            public long y;
            public long z;

            public DebuggerProxy(long3 v)
            {
                x = v.x;
                y = v.y;
                z = v.z;
            }
        }


        [FieldOffset(0)]  private fixed long asArray[3];

        [FieldOffset(0)]  internal long2 _xy;

        [FieldOffset(0)]  public long x;
        [FieldOffset(8)]  public long y;
        [FieldOffset(16)] public long z;


        public static long3 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(long x, long y, long z)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_set_epi64x(0L, z, y, x);
            }
            else if (Sse2.IsSse2Supported)
            {
                this = new long3 { _xy = new long2(x, y), z = z };
            }
            else
            {
                this = new long3 { x = x, y = y, z = z };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(long xyz)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_set1_epi64x(xyz);
            }
            else if (Sse2.IsSse2Supported)
            {
                this = new long3 { _xy = new long2(xyz), z = xyz };
            }
            else
            {
                this = new long3 { x = xyz, y = xyz, z = xyz };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(long2 xy, long z)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_insert_epi64(Avx.mm256_castsi128_si256(xy), z, 2);
            }
            else
            {
                this = new long3 { _xy = xy, z = z };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(long x, long2 yz)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_insert_epi64(yz.xxy, x, 0);
            }
            else if (Sse2.IsSse2Supported)
            {
                yz = yz.yx;
                long z = yz.x;
                yz.x = x;

                this = new long3 { _xy = yz, z = z };
            }
            else
            {
                this = new long3 { x = x, y = yz.x, z = yz.y };
            }
        }


        #region Shuffle
        public readonly long4 xxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_broadcastq_epi64(Avx.mm256_castsi256_si128(this));
                }
                else if (Sse2.IsSse2Supported)
                {
                    long2 _xx = xx;

                    return new long4(_xx, _xx);
                }
                else
                {
                    return new long4(x, x, x, x);
                }
            }
        }
        public readonly long4 xxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 0, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(xx, _xy);
                }
                else
                {
                    return new long4(x, x, x, y);
                }
            }
        }
        public readonly long4 xxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 0, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(xx, xz);
                }
                else
                {
                    return new long4(x, x, x, z);
                }
            }
        }
        public readonly long4 xxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 0, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(xx, yx);
                }
                else
                {
                    return new long4(x, x, y, x);
                }
            }
        }
        public readonly long4 xxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 0, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(xx, yy);
                }
                else
                {
                    return new long4(x, x, y, y);
                }
            }
        }
        public readonly long4 xxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 0, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(xx, yz);
                }
                else
                {
                    return new long4(x, x, y,z);
                }
            }
        }
        public readonly long4 xxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 0, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(xx, zx);
                }
                else
                {
                    return new long4(x, x, z, x);
                }
            }
        }
        public readonly long4 xxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 0, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(xx, zy);
                }
                else
                {
                    return new long4(x, x, z, y);
                }
            }
        }
        public readonly long4 xxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(1, 0, 1, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(xx, zz);
                }
                else
                {
                    return new long4(x, x, z, z);
                }
            }
        }
        public readonly long4 xyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 1, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(_xy, xx);
                }
                else
                {
                    return new long4(x, y, x, x);
                }
            }
        }
        public readonly long4 xyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_broadcastsi128_si256(Avx.mm256_castsi256_si128(this));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(_xy, _xy);
                }
                else
                {
                    return new long4(x, y, x, y);
                }
            }
        }
        public readonly long4 xyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 1, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(_xy, xz);
                }
                else
                {
                    return new long4(x, y, x, z);
                }
            }
        }
        public readonly long4 xyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 1, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(_xy, yx);
                }
                else
                {
                    return new long4(x, y, y, x);
                }
            }
        }
        public readonly long4 xyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 1, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(_xy, yy);
                }
                else
                {
                    return new long4(x, y, y, y);
                }
            }
        }
        public readonly long4 xyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 1, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(_xy, yz);
                }
                else
                {
                    return new long4(x, y, y, z);
                }
            }
        }
        public readonly long4 xyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 1, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(_xy, zx);
                }
                else
                {
                    return new long4(x, y, z, x);
                }
            }
        }
        public readonly long4 xyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 1, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(_xy, zy);
                }
                else
                {
                    return new long4(x, y, z, y);
                }
            }
        }
        public readonly long4 xyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 1, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(_xy, zz);
                }
                else
                {
                    return new long4(x, y, z, z);
                }
            }
        }
        public readonly long4 xzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(xz, xx);
                }
                else
                {
                    return new long4(x, z, x, x);
                }
            }
        }
        public readonly long4 xzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 2, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(xz, _xy);
                }
                else
                {
                    return new long4(x, z, x, y);
                }
            }
        }
        public readonly long4 xzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 2, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    long2 _xz = xz;

                    return new long4(_xz, _xz);
                }
                else
                {
                    return new long4(x, z, x, z);
                }
            }
        }
        public readonly long4 xzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 2, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(xz, yx);
                }
                else
                {
                    return new long4(x, z, y, x);
                }
            }
        }
        public readonly long4 xzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 2, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(xz, yy);
                }
                else
                {
                    return new long4(x, z, y, y);
                }
            }
        }
        public readonly long4 xzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 2, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(xz, yz);
                }
                else
                {
                    return new long4(x, z, y, z);
                }
            }
        }
        public readonly long4 xzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 2, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(xz, zx);
                }
                else
                {
                    return new long4(x, z, z, x);
                }
            }
        }
        public readonly long4 xzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 2, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(xz, zy);
                }
                else
                {
                    return new long4(x, z, z, y);
                }
            }
        }
        public readonly long4 xzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 2, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(xz, zz);
                }
                else
                {
                    return new long4(x, z, z, z);
                }
            }
        }
        public readonly long4 yxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 0, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(yx, xx);
                }
                else
                {
                    return new long4(y, x, x,  x);
                }
            }
        }
        public readonly long4 yxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 0, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(yx, _xy);
                }
                else
                {
                    return new long4(y, x, x, y);
                }
            }
        }
        public readonly long4 yxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 0, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(yx, xz);
                }
                else
                {
                    return new long4(y, x, x, z);
                }
            }
        }
        public readonly long4 yxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 0, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    long2 _yx = yx;

                    return new long4(_yx, _yx);
                }
                else
                {
                    return new long4(y, x, y, x);
                }
            }
        }
        public readonly long4 yxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 0, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(yx, yy);
                }
                else
                {
                    return new long4(y, x, y, y);
                }
            }
        }
        public readonly long4 yxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 0, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(yx, yz);
                }
                else
                {
                    return new long4(y, x, y, z);
                }
            }
        }
        public readonly long4 yxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 0, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(yx, zx);
                }
                else
                {
                    return new long4(y, x, z, x);
                }
            }
        }
        public readonly long4 yxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 0, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(yx, zy);
                }
                else
                {
                    return new long4(y, x, z, y);
                }
            }
        }
        public readonly long4 yxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 0, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(yx, zz);
                }
                else
                {
                    return new long4(y, x, z, z);
                }
            }
        }
        public readonly long4 yyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 1, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(yy, xx);
                }
                else
                {
                    return new long4(y, y, x, x);
                }
            }
        }
        public readonly long4 yyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 1, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(yy, _xy);
                }
                else
                {
                    return new long4(y, y, x, y);
                }
            }
        }
        public readonly long4 yyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 1, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(yy, xz);
                }
                else
                {
                    return new long4(y, y, x, z);
                }
            }
        }
        public readonly long4 yyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 1, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(yy, yx);
                }
                else
                {
                    return new long4(y, y, y, x);
                }
            }
        }
        public readonly long4 yyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 1, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    long2 _yy = yy;

                    return new long4(_yy, _yy);
                }
                else
                {
                    return new long4(y, y, y, y);
                }
            }
        }
        public readonly long4 yyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 1, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(yy, yz);
                }
                else
                {
                    return new long4(y, y, y, z);
                }
            }
        }
        public readonly long4 yyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 1, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(yy, zx);
                }
                else
                {
                    return new long4(y, y, z, x);
                }
            }
        }
        public readonly long4 yyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 1, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(yy, zy);
                }
                else
                {
                    return new long4(y, y, z, y);
                }
            }
        }
        public readonly long4 yyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 1, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(yy, zz);
                }
                else
                {
                    return new long4(y, y, z, z);
                }
            }
        }
        public readonly long4 yzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(yz, xx);
                }
                else
                {
                    return new long4(y, z, x, x);
                }
            }
        }
        public readonly long4 yzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 2, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(yz, _xy);
                }
                else
                {
                    return new long4(y, z, x, y);
                }
            }
        }
        public readonly long4 yzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 2, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(yz, xz);
                }
                else
                {
                    return new long4(y, z, x, z);
                }
            }
        }
        public readonly long4 yzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 2, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(yz, yx);
                }
                else
                {
                    return new long4(y, z, y, x);
                }
            }
        }
        public readonly long4 yzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 2, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(yz, yy);
                }
                else
                {
                    return new long4(y, z, y, y);
                }
            }
        }
        public readonly long4 yzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 2, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    long2 _yz = yz;

                    return new long4(_yz, _yz);
                }
                else
                {
                    return new long4(y, z, y, z);
                }
            }
        }
        public readonly long4 yzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 2, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(yz, zx);
                }
                else
                {
                    return new long4(y, z, z, x);
                }
            }
        }
        public readonly long4 yzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                { 
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 2, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(yz, zy);
                }
                else
                {
                    return new long4(y, z, z, y);
                }
            }
        }
        public readonly long4 yzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 2, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(yz, zz);
                }
                else
                {
                    return new long4(y, z, z, z);
                }
            }
        }
        public readonly long4 zxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 0, 2));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(zx, xx);
                }
                else
                {
                    return new long4(z, x, x, x);
                }
            }
        }
        public readonly long4 zxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 0, 2));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(zx, _xy);
                }
                else
                {
                    return new long4(z, x, x, y);
                }
            }
        }
        public readonly long4 zxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 0, 2));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(zx, xz);
                }
                else
                {
                    return new long4(z, x, x, z);
                }
            }
        }
        public readonly long4 zxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 0, 2));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(zx, yx);
                }
                else
                {
                    return new long4(z, x, y, x);
                }
            }
        }
        public readonly long4 zxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 0, 2));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(zx, yy);
                }
                else
                {
                    return new long4(z, x, y, y);
                }
            }
        }
        public readonly long4 zxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 0, 2));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(zx, yz);
                }
                else
                {
                    return new long4(z, x, y, z);
                }
            }
        }
        public readonly long4 zxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 0, 2));
                }
                else if (Sse2.IsSse2Supported)
                {
                    long2 _zx = zx;

                    return new long4(_zx, _zx);
                }
                else
                {
                    return new long4(z, x, z, x);
                }
            }
        }
        public readonly long4 zxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 0, 2));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(zx, zy);
                }
                else
                {
                    return new long4(z, x, z, y);
                }
            }
        }
        public readonly long4 zxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 0, 2));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(zx, zz);
                }
                else
                {
                    return new long4(z, x, z, z);
                }
            }
        }
        public readonly long4 zyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 1, 2));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(zy, xx);
                }
                else
                {
                    return new long4(z, y, x, x);
                }
            }
        }
        public readonly long4 zyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 1, 2));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(zy, _xy);
                }
                else
                {
                    return new long4(z, y, x, y);
                }
            }
        }
        public readonly long4 zyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 1, 2));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(zy, xz);
                }
                else
                {
                    return new long4(z, y, x, z);
                }
            }
        }
        public readonly long4 zyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 1, 2));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(zy, yx);
                }
                else
                {
                    return new long4(z, y, y, x);
                }
            }
        }
        public readonly long4 zyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 1, 2));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(zy, yy);
                }
                else
                {
                    return new long4(z, y, y, y);
                }
            }
        }
        public readonly long4 zyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 1, 2));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(zy, yz);
                }
                else
                {
                    return new long4(z, y, y, z);
                }
            }
        }
        public readonly long4 zyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 1, 2));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(zy, zx);
                }
                else
                {
                    return new long4(z, y, z, x);
                }
            }
        }
        public readonly long4 zyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 1, 2));
                }
                else if (Sse2.IsSse2Supported)
                {
                    long2 _zy = zy;

                    return new long4(_zy, _zy);
                }
                else
                {
                    return new long4(z, y, z, y);
                }
            }
        }
        public readonly long4 zyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 1, 2));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(zy, zz);
                }
                else
                {
                    return new long4(z, y, z, z);
                }
            }
        }
        public readonly long4 zzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 2));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(zz, xx);
                }
                else
                {
                    return new long4(z, z, x, x);
                }
            }
        }
        public readonly long4 zzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 2, 2));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(zz, _xy);
                }
                else
                {
                    return new long4(z, z, x, y);
                }
            }
        }
        public readonly long4 zzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 2, 2));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(zz, xz);
                }
                else
                {
                    return new long4(z, z, x, z);
                }
            }
        }
        public readonly long4 zzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 2, 2));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(zz, yx);
                }
                else
                {
                    return new long4(z, z, y, x);
                }
            }
        }
        public readonly long4 zzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 2, 2));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(zz, yy);
                }
                else
                {
                    return new long4(z, z, y, y);
                }
            }
        }
        public readonly long4 zzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 2, 2));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(zz, yz);
                }
                else
                {
                    return new long4(z, z, y, z);
                }
            }
        }
        public readonly long4 zzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 2, 2));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(zz, zx);
                }
                else
                {
                    return new long4(z, z, z, x);
                }
            }
        }
        public readonly long4 zzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 2, 2));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long4(zz, zy);
                }
                else
                {
                    return new long4(z, z, z, y);
                }
            }
        }
        public readonly long4 zzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 2, 2));
                }
                else if (Sse2.IsSse2Supported)
                {
                    long2 _zz = zz;

                    return new long4(_zz, _zz);
                }
                else
                {
                    return new long4(z, z, z, z);
                }
            }
        }

        public readonly long3 xxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_broadcastq_epi64(Avx.mm256_castsi256_si128(this));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long3(xx, x);
                }
                else
                {
                    return new long3(x, x, x);
                }
            }
        }
        public readonly long3 xxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long3(xx, y);
                }
                else
                {
                    return new long3(x, x, y);
                }
            }
        }
        public readonly long3 xxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(1, 0, 1, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long3(xx, z);
                }
                else
                {
                    return new long3(x, x, z);
                }
            }
        }
        public readonly long3 xyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_broadcastsi128_si256(Avx.mm256_castsi256_si128(this));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long3(_xy, x);
                }
                else
                {
                    return new long3(x, y, x);
                }
            }
        }
        public readonly long3 xyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long3(_xy, y);
                }
                else
                {
                    return new long3(x, y, y);
                }
            }
        }
        public readonly long3 xzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long3(xz, x);
                }
                else
                {
                    return new long3(x, z, x);
                }
            }
        }
        public          long3 xzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long3(xz, y);
                }
                else
                {
                    return new long3(x, z, y);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this = value.xzy;
            }
        }
        public readonly long3 xzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long3(xz, z);
                }
                else
                {
                    return new long3(x, z, z);
                }
            }
        }
        public readonly long3 yxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 0, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long3(yx, x);
                }
                else
                {
                    return new long3(y, x, x);
                }
            }
        }
        public readonly long3 yxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long3(yx, y);
                }
                else
                {
                    return new long3(y, x, y);
                }
            }
        }
        public          long3 yxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 0, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long3(yx, z);
                }
                else
                {
                    return new long3(y, x, z);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this = value.yxz;
            }
        }
        public readonly long3 yyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 1, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long3(yy, x);
                }
                else
                {
                    return new long3(y, y, x);
                }
            }
        }
        public readonly long3 yyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long3(yy, y);
                }
                else
                {
                    return new long3(y, y, y);
                }
            }
        }
        public readonly long3 yyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 1, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long3(yy, z);
                }
                else
                {
                    return new long3(y, y, z);
                }
            }
        }
        public          long3 yzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long3(yz, x);
                }
                else
                {
                    return new long3(y, z, x);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this = value.zxy;
            }
        }
        public readonly long3 yzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long3(yz, y);
                }
                else
                {
                    return new long3(y, z, y);
                }
            }
        }
        public readonly long3 yzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long3(yz, z);
                }
                else
                {
                    return new long3(y, z, z);
                }
            }
        }
        public readonly long3 zxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 0, 2));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long3(zx, x);
                }
                else
                {
                    return new long3(z, x, x);
                }
            }
        }
        public          long3 zxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 2));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long3(zx, y);
                }
                else
                {
                    return new long3(z, x, y);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this = value.yzx;
            }
        }
        public readonly long3 zxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 0, 2));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long3(zx, z);
                }
                else
                {
                    return new long3(z, x, z);
                }
            }
        }
        public          long3 zyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 1, 2));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long3(zy, x);
                }
                else
                {
                    return new long3(z, y, x);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this = value.zyx;
            }
        }
        public readonly long3 zyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 2));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long3(zy, y);
                }
                else
                {
                    return new long3(z, y, y);
                }
            }
        }
        public readonly long3 zyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 1, 2));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long3(zy, z);
                }
                else
                {
                    return new long3(z, y, z);
                }
            }
        }
        public readonly long3 zzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 2));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long3(zz, x);
                }
                else
                {
                    return new long3(z, z, x);
                }
            }
        }
        public readonly long3 zzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 2));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long3(zz, y);
                }
                else
                {
                    return new long3(z, z, y);
                }
            }
        }
        public readonly long3 zzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 2));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return new long3(zz, z);
                }
                else
                {
                    return new long3(z, z, z);
                }
            }
        }

        public readonly long2 xx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Sse2.shuffle_epi32(Avx.mm256_castsi256_si128(this), Sse.SHUFFLE(1, 0, 1, 0));
                }
                else
                {
                    return _xy.xx;
                }
            }
        }
        public          long2 xy
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
                    return _xy;
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
                    this._xy = value;
                }
            }
        }
        public          long2 xz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 0)));
                }
                else if (Sse2.IsSse2Supported)
                {
                    long2 _xz = _xy;
                    _xz.y = z;
                    return _xz;
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
                else
                {
                    this.x = value.x;
                    this.z = value.y;
                }
            }
        }
        public          long2 yx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Sse2.shuffle_epi32(Avx.mm256_castsi256_si128(this), Sse.SHUFFLE(1, 0, 3, 2));
                }
                else
                {
                    return _xy.yx;
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
        public readonly long2 yy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Sse2.shuffle_epi32(Avx.mm256_castsi256_si128(this), Sse.SHUFFLE(3, 2, 3, 2));
                }
                else
                {
                    return _xy.yy;
                }
            }
        }
        public          long2 yz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 1)));
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
                    this = Avx2.mm256_blend_epi32(this, value.yxyx, 0b0011_1100);
                }
                else
                {
                    this.y = value.x;
                    this.z = value.y;
                } 
            }
        }
        public          long2 zx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 2)));
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
            readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 1, 2)));
                }
                else if (Sse2.IsSse2Supported)
                {
                    long2 _zy = _xy;
                    _zy.x = z;
                    return _zy;
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
                else
                {
                    this.z = value.x;
                    this.y = value.y;
                }
            }
        }
        public readonly long2 zz
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
                    return new long2(z, z);
                }
            }
        }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Avx2.mm256_stream_load_si256(void* ptr)   Avx.mm256_load_si256(void* ptr)
        public static implicit operator v256(long3 input) => new v256(input._xy, new v128(input.z, 0));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Avx.mm256_storeu_si256(void* ptr, v128 x)
        public static implicit operator long3(v256 input) => new long3 { _xy = input.Lo128, z = input.SLong2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3(long input) => new long3(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3(ulong3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return (v256)input;
            }
            else if (Sse2.IsSse2Supported)
            {
                return new long3((long2)input._xy, (long)input.z);
            }
            else
            {
                return *(long3*)&input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3(uint3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepu32_epi64(*(v128*)&input);
            }
            else if (Sse2.IsSse2Supported)
            {
                return new long3
                {
                    _xy = (long2)input.xy,
                    z   = (long)input.z
                };
            }
            else
            {
                return new long3((long)input.x, (long)input.y, (long)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3(int3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepi32_epi64(*(v128*)&input);
            }
            else if (Sse2.IsSse2Supported)
            {
                return new long3
                {
                    _xy = (long2)input.xy,
                    z   = (long)input.z
                };
            }
            else
            {
                return new long3((long)input.x, (long)input.y, (long)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3(half3 input) => (long3)(int3)(float3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3(float3 input) => new long3((long2)input.xy, (long)input.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3(double3 input) => new long3((long2)input.xy, (long)input.z);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(long3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 temp = Cast.Long4ToInt4(input); 
                
                return *(uint3*)&temp;
            }
            else if (Sse4_1.IsSse41Supported)
            {
                v128 temp = Cast.Long2ToInt2(input._xy);

                temp = Sse4_1.insert_epi32(temp, (int)(uint)input.z, 2);

                return *(uint3*)&temp;
            }
            else
            {
                return new uint3((uint)input.x, (uint)input.y, (uint)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(long3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 temp = Cast.Long4ToInt4(input);

                return *(int3*)&temp;
            }
            else if (Sse4_1.IsSse41Supported)
            {
                v128 temp = Cast.Long2ToInt2(input._xy);

                temp = Sse4_1.insert_epi32(temp, (int)input.z, 2);

                return *(int3*)&temp;
            }
            else
            {
                return new int3((int)input.x, (int)input.y, (int)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half3(long3 input) => (half3)(float3)(int3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(long3 input) => new float3((float2)input._xy, (float)input.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(long3 input) => new double3((double2)input._xy, (double)input.z);
    

        public long this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
Assert.IsWithinArrayBounds(index, 3);

                return asArray[index];
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 3);

                asArray[index] = value;
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator + (long3 left, long3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_add_epi64(left, right);
            }
            else
            {
                return new long3(left._xy + right._xy, left.z + right.z);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator - (long3 left, long3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi64(left, right);
            }
            else
            {
                return new long3(left._xy - right._xy, left.z - right.z);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (long3 left, long3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Operator.mul_long(left, right);
            }
            else if (Sse4_1.IsSse41Supported)
            {
                return new long3(Operator.mul_long(left._xy, right._xy), left.z * right.z);
            }
            else
            {
                return new long3(left.x * right.x, left.y * right.y, left.z * right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (long3 left, long3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return new long3(left.x / right.x, left.y / right.y, left.z / right.z);
            }
            else
            {
                return new long3(left._xy / right._xy, left.z / right.z);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (long3 left, long3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return new long3(left.x % right.x, left.y % right.y, left.z % right.z);
            }
            else
            {
                return new long3(left._xy % right._xy, left.z % right.z);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator *(long left, long3 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (long3 left, long right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return (v256)((long4)((v256)left) * right);
            }
            else
            {
                return new long3(left._xy * right, left.z * right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (long3 left, long right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return (v256)((long4)((v256)left) / right);
            }
            else
            {
                return new long3(left._xy / right, left.z / right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (long3 left, long right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return (v256)((long4)((v256)left) % right);
            }
            else
            {
                return new long3(left._xy % right, left.z % right);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator & (long3 left, long3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_and_si256(left, right);
            }
            else
            {
                return new long3(left._xy & right._xy, left.z & right.z);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator | (long3 left, long3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_or_si256(left, right);
            }
            else
            {
                return new long3(left._xy | right._xy, left.z | right.z);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ^ (long3 left, long3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_xor_si256(left, right);
            }
            else
            {
                return new long3(left._xy ^ right._xy, left.z ^ right.z);
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator - (long3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi64(default(v256), x);
            }
            else
            {
                return new long3(-x._xy, -x.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ++ (long3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_add_epi64(x, new v256(1L));
            }
            else
            {
                return new long3(x._xy + 1, x.z + 1);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator -- (long3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi64(x, new v256(1L));
            }
            else
            {
                return new long3(x._xy - 1, x.z - 1);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ~ (long3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_andnot_si256(x, new v256(-1L));
            }
            else
            {
                return new long3(~x._xy, ~x.z);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator << (long3 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Operator.shl_long(x, n);
            }
            else
            {
                return new long3(x._xy << n, x.z << n);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator >> (long3 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Operator.shra_long(x, n);
            }
            else
            {
                return new long3(x._xy >> n, x.z >> n);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (long3 left, long3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return TestIsTrue(Avx2.mm256_cmpeq_epi64(left, right));
            }
            else
            {
                return new bool3(left._xy == right._xy, left.z == right.z);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator < (long3 left, long3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return TestIsTrue(Avx2.mm256_cmpgt_epi64(right, left));
            }
            else
            {
                return new bool3(left._xy < right._xy, left.z < right.z);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator > (long3 left, long3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return TestIsTrue(Avx2.mm256_cmpgt_epi64(left, right));
            }
            else
            {
                return new bool3(left._xy > right._xy, left.z > right.z);
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (long3 left, long3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return TestIsFalse(Avx2.mm256_cmpeq_epi64(left, right));
            }
            else
            {
                return new bool3(left._xy != right._xy, left.z != right.z);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator <= (long3 left, long3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return TestIsFalse(Avx2.mm256_cmpgt_epi64(left, right));
            }
            else
            {
                return new bool3(left._xy <= right._xy, left.z <= right.z);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator >= (long3 left, long3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return TestIsFalse(Avx2.mm256_cmpgt_epi64(right, left));
            }
            else
            {
                return new bool3(left._xy >= right._xy, left.z >= right.z);
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool3 TestIsTrue(v256 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                int cast = 0x0001_0101 & Avx2.mm256_movemask_epi8(input);

                return *(bool3*)&cast;
            }
            else throw new BurstCompilerException();
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool3 TestIsFalse(v256 input) 
        {
            if (Avx2.IsAvx2Supported)
            {
                int cast = maxmath.andnot(0x0001_0101, Avx2.mm256_movemask_epi8(input));

                return *(bool3*)&cast;
            }
            else throw new BurstCompilerException();
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(long3 other)
        {
            if (Avx2.IsAvx2Supported)
            {
                return maxmath.bitmask32(24) == (maxmath.bitmask32(24) & Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi64(this, other)));
            }
            else
            {
                return this._xy.Equals(other._xy) & this.z == other.z;
            }
        }

        public override readonly bool Equals(object obj) => Equals((long3)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode()
        {
            if (Avx2.IsAvx2Supported)
            {
                return Hash.v192(this);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Hash.v128(_xy ^ new long2(z));
            }
            else
            {
                return ((x ^ z) ^ (y ^ z)).GetHashCode();
            }
        }


        public override readonly string ToString() => $"long3({x}, {y}, {z})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"long3({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)})";
    }
}