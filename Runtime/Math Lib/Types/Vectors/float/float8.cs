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
    internal sealed class float8DebuggerProxy
    {
        public float x0;
        public float x1;
        public float x2;
        public float x3;
        public float x4;
        public float x5;
        public float x6;
        public float x7;
        
        public float8DebuggerProxy(float8 v)
        {
            x0 = v.x0;
            x1 = v.x1;
            x2 = v.x2;
            x3 = v.x3;
            x4 = v.x4;
            x5 = v.x5;
            x6 = v.x6;
            x7 = v.x7;
        }
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(float8DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public struct float8 : IEquatable<float8>, IFormattable
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal float4 __x0;
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal float4 __x4;
        
        public ref float x0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(float8* ptr = &this) { return ref *((float*)ptr + 0); } } }
        public ref float x1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(float8* ptr = &this) { return ref *((float*)ptr + 1); } } }
        public ref float x2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(float8* ptr = &this) { return ref *((float*)ptr + 2); } } }
        public ref float x3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(float8* ptr = &this) { return ref *((float*)ptr + 3); } } }
        public ref float x4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(float8* ptr = &this) { return ref *((float*)ptr + 4); } } }
        public ref float x5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(float8* ptr = &this) { return ref *((float*)ptr + 5); } } }
        public ref float x6 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(float8* ptr = &this) { return ref *((float*)ptr + 6); } } }
        public ref float x7 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(float8* ptr = &this) { return ref *((float*)ptr + 7); } } }


        public static float8 zero => default;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(float x0, float x1, float x2, float x3, float x4, float x5, float x6, float x7)
        {
            this = math.asfloat(new uint8(asuint(x0), asuint(x1), asuint(x2), asuint(x3), asuint(x4), asuint(x5), asuint(x6), asuint(x7)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(float x0x8)
        {
            this = math.asfloat(new uint8(asuint(x0x8)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(float2 x01, float2 x23, float2 x45, float2 x67)
        {
            this = math.asfloat(new uint8(asuint(x01), asuint(x23), asuint(x45), asuint(x67)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(float2 x01, float3 x234, float3 x567)
        {
            this = math.asfloat(new uint8(asuint(x01), asuint(x234), asuint(x567)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(float3 x012, float2 x34, float3 x567)
        {
            this = math.asfloat(new uint8(asuint(x012), asuint(x34), asuint(x567)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(float3 x012, float3 x345, float2 x67)
        {
            this = math.asfloat(new uint8(asuint(x012), asuint(x345), asuint(x67)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(float4 x0123, float2 x45, float2 x67)
        {
            this = math.asfloat(new uint8(asuint(x0123), asuint(x45), asuint(x67)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(float2 x01, float4 x2345, float2 x67)
        {
            this = math.asfloat(new uint8(asuint(x01), asuint(x2345), asuint(x67)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(float2 x01, float2 x23, float4 x4567)
        {
            this = math.asfloat(new uint8(asuint(x01), asuint(x23), asuint(x4567)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(float4 x0123, float4 x4567)
        {
            this = math.asfloat(new uint8(asuint(x0123), asuint(x4567)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(bool v)
        {
            this = (float8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(bool8 v)
        {
            this = (float8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(mask8x8 v)
        {
            this = (float8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(mask16x8 v)
        {
            this = (float8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(mask32x8 v)
        {
            this = (float8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(byte v)
        {
            this = (float8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(byte8 v)
        {
            this = (float8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(sbyte v)
        {
            this = (float8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(sbyte8 v)
        {
            this = (float8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(ushort v)
        {
            this = (float8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(ushort8 v)
        {
            this = (float8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(short v)
        {
            this = (float8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(short8 v)
        {
            this = (float8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(uint v)
        {
            this = (float8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(uint8 v)
        {
            this = (float8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(int v)
        {
            this = (float8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(int8 v)
        {
            this = (float8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(ulong v)
        {
            this = (float8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(long v)
        {
            this = (float8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(UInt128 v)
        {
            this = (float8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(Int128 v)
        {
            this = (float8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(quarter v)
        {
            this = (float8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(quarter8 v)
        {
            this = (float8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(half v)
        {
            this = (float8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(half8 v)
        {
            this = (float8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(double v)
        {
            this = (float8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(quadruple v)
        {
            this = (float8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(Unity.Mathematics.half v)
        {
            this = (float8)v;
        }


        #region Shuffle
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float4 v4_0
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_castps256_ps128(this);
                }
                else
                {
                    return __x0;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_blend_ps(this, Avx.mm256_castps128_ps256(value), 0b0000_1111);
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
        public float4 v4_1
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx.IsAvxSupported)
                {
                    return Xse.alignr_epi8(Avx.mm256_castps256_ps128(this), Avx.mm256_extractf128_ps(this, 1), 1 * sizeof(float));
                }
                else
                {
                    return shuffle(__x0, __x4, ShuffleComponent.LeftY,
                                                      ShuffleComponent.LeftZ,
                                                      ShuffleComponent.LeftW,
                                                      ShuffleComponent.RightX);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx.mm256_blend_ps(this, vrol((float8)Avx.mm256_castps128_ps256(value), 1), 0b0001_1110);
                }
                else
                {
                    this.__x0 = shuffle(__x0, value, ShuffleComponent.LeftX,
                                                            ShuffleComponent.RightX,
                                                            ShuffleComponent.RightY,
                                                            ShuffleComponent.RightZ);

                    this.__x4 = shuffle(__x4, value, ShuffleComponent.RightW,
                                                            ShuffleComponent.LeftY,
                                                            ShuffleComponent.LeftZ,
                                                            ShuffleComponent.LeftW);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float4 v4_2
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx.mm256_castps256_ps128(Avx2.mm256_permute4x64_pd(this, Sse.SHUFFLE(0, 0, 2, 1)));
                }
                else
                {
                    return shuffle(__x0, __x4, ShuffleComponent.LeftZ,
                                                      ShuffleComponent.LeftW,
                                                      ShuffleComponent.RightX,
                                                      ShuffleComponent.RightY);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx.mm256_blend_ps(this, Avx2.mm256_permute4x64_pd(Avx.mm256_castps128_ps256(value), Sse.SHUFFLE(0, 1, 0, 0)), 0b0011_1100);
                }
                else
                {
                    this.__x0 = shuffle(__x0, value, ShuffleComponent.LeftX,
                                                            ShuffleComponent.LeftY,
                                                            ShuffleComponent.RightX,
                                                            ShuffleComponent.RightY);

                    this.__x4 = shuffle(__x4, value, ShuffleComponent.RightZ,
                                                            ShuffleComponent.RightW,
                                                            ShuffleComponent.LeftZ,
                                                            ShuffleComponent.LeftW);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float4 v4_3
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx.IsAvxSupported)
                {
                    return Xse.alignr_epi8(Avx.mm256_castps256_ps128(this), Avx.mm256_extractf128_ps(this, 1), 3 * sizeof(float));
                }
                else
                {
                    return shuffle(__x0, __x4, ShuffleComponent.LeftW,
                                                      ShuffleComponent.RightX,
                                                      ShuffleComponent.RightY,
                                                      ShuffleComponent.RightZ);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx.mm256_blend_ps(this, vrol((float8)Avx.mm256_castps128_ps256(value), 3), 0b0111_1000);
                }
                else
                {
                    this.__x0 = shuffle(__x0, value, ShuffleComponent.LeftX,
                                                            ShuffleComponent.LeftY,
                                                            ShuffleComponent.LeftZ,
                                                            ShuffleComponent.RightX);

                    this.__x4 = shuffle(__x4, value, ShuffleComponent.RightY,
                                                            ShuffleComponent.RightZ,
                                                            ShuffleComponent.RightW,
                                                            ShuffleComponent.LeftW);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float4 v4_4
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_extractf128_ps(this, 1);
                }
                else
                {
                    return __x4;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx.mm256_insertf128_ps(this, value, 1);
                }
                else
                {
                    this.__x4 = value;
                }
            }
        }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float3 v3_0
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_castps256_ps128(this);
                }
                else
                {
                    return __x0.xyz;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_blend_ps(this, Avx.mm256_castps128_ps256(value), 0b0000_0111);
                }
                else
                {
                    this.__x0.xyz = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float3 v3_1
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx.IsAvxSupported)
                {
                    return Xse.bsrli_si128(Avx.mm256_castps256_ps128(this), sizeof(float));
                }
                else
                {
                    return __x0.yzw;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_blend_ps(this, Avx.mm256_castps128_ps256(Xse.shuffle_epi32(value, Sse.SHUFFLE(2, 1, 0, 0))), 0b0000_1110);
                }
                else
                {
                    this.__x0.yzw = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float3 v3_2
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx.mm256_castps256_ps128(Avx2.mm256_permute4x64_pd(this, Sse.SHUFFLE(0, 0, 2, 1)));
                }
                else
                {
                    return new float3(__x0.zw, __x4.x);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx.mm256_blend_ps(this, Avx2.mm256_permute4x64_pd(Avx.mm256_castps128_ps256(value), Sse.SHUFFLE(0, 1, 0, 0)), 0b0001_1100);
                }
                else
                {
                    this.__x0.zw = value.xy;
                    this.__x4.x  = value.z;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float3 v3_3
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx.IsAvxSupported)
                {
                    return Xse.alignr_epi8(Avx.mm256_castps256_ps128(this), Avx.mm256_extractf128_ps(this, 1), 3 * sizeof(float));
                }
                else
                {
                    return new float3(__x0.w, __x4.xy);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx.mm256_blend_ps(this, vrol((float8)Avx.mm256_castps128_ps256(value), 3), 0b0011_1000);
                }
                else
                {
                    this.__x0.w  = value.x;
                    this.__x4.xy = value.yz;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float3 v3_4
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_extractf128_ps(this, 1);
                }
                else
                {
                    return __x4.xyz;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx.mm256_blend_ps(this, Avx2.mm256_permute4x64_pd(Avx.mm256_castps128_ps256(value), Sse.SHUFFLE(1, 0, 0, 0)), 0b0111_0000);
                }
                else
                {
                    this.__x4.xyz = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float3 v3_5
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx.IsAvxSupported)
                {
                    return Xse.bsrli_si128(Avx.mm256_extractf128_ps(this, 1), 1 * sizeof(float));
                }
                else
                {
                    return __x4.yzw;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx.mm256_blend_ps(this, vrol((float8)Avx.mm256_castps128_ps256(value), 5), 0b1110_0000);
                }
                else
                {
                    this.__x4.yzw = value;
                }
            }
        }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float2 v2_0
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_castps256_ps128(this);
                }
                else
                {
                    return __x0.xy;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi64(this, *(long*)&value, 0);
                }
                else
                {
                    this.__x0.xy = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float2 v2_1
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx.IsAvxSupported)
                {
                    return Xse.bsrli_si128(Avx.mm256_castps256_ps128(this), sizeof(float));
                }
                else
                {
                    return __x0.yz;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_blend_ps(this, Avx.mm256_castps128_ps256(Xse.shuffle_epi32(value, Sse.SHUFFLE(0, 1, 0, 0))), 0b0000_0110);
                }
                else
                {
                    this.__x0.yz = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float2 v2_2
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx.IsAvxSupported)
                {
                    return Xse.bsrli_si128(Avx.mm256_castps256_ps128(this), 2 * sizeof(float));
                }
                else
                {
                    return __x0.zw;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi64(this, *(long*)&value, 1);
                }
                else
                {
                    this.__x0.zw = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float2 v2_3
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx.IsAvxSupported)
                {
                    return Xse.alignr_epi8(Avx.mm256_castps256_ps128(this), Avx.mm256_extractf128_ps(this, 1), 3 * sizeof(float));
                }
                else
                {
                    return new float2(__x0.w, __x4.x);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx.mm256_blend_ps(this, vrol((float8)Avx.mm256_castps128_ps256(value), 3), 0b0001_1000);
                }
                else
                {
                    this.__x0.w = value.x;
                    this.__x4.x = value.y;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float2 v2_4
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_extractf128_ps(this, 1);
                }
                else
                {
                    return __x4.xy;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi64(this, *(long*)&value, 2);
                }
                else
                {
                    this.__x4.xy = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float2 v2_5
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx.IsAvxSupported)
                {
                    return Xse.bsrli_si128(Avx.mm256_extractf128_ps(this, 1), 1 * sizeof(float));
                }
                else
                {
                    return __x4.yz;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx.mm256_blend_ps(this, vrol((float8)Avx.mm256_castps128_ps256(value), 5), 0b0110_0000);
                }
                else
                {
                    this.__x4.yz = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float2 v2_6
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx.mm256_castps256_ps128(Avx2.mm256_permute4x64_pd(this, Sse.SHUFFLE(0, 0, 0, 3)));
                }
                else
                {
                    return __x4.zw;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi64(this, *(long*)&value, 3);
                }
                else
                {
                    this.__x4.zw = value;
                }
            }
        }
        #endregion

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v256(float8 input) => asuint(input);
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(v256 input) => asfloat((uint8)input);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float8(bool x) => (float8)(mask32x8)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float8(bool8 x) => (float8)(mask32x8)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float8(mask8x8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (float8)(mask32x8)x;
            }
            else
            {
                return *(byte8*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float8(mask16x8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (float8)(mask32x8)x;
            }
            else
            {
                return *(byte8*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float8(mask32x8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx.mm256_and_ps(x, Xse.mm256_set1_ps(1));
            }
            else
            {
                return new float8((float4)x.v4_0, (float4)x.v4_4);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool8(float8 x) => math.andnot(x != 0, math.isnan(x));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x8(float8 x) => (mask32x8)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x8(float8 x) => (mask32x8)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x8(float8 x) => math.andnot(x != 0, math.isnan(x));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator float8(byte x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator float8(sbyte x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator float8(ushort x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator float8(short x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(uint x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(int x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(ulong x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(long x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(UInt128 x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(Int128 x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float8(double x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float8(quadruple x) => (float)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(Unity.Mathematics.half x) => (float8)(half)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(half input) => new float8((float)input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(float input) => new float8(input);


        public float this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
Assert.IsWithinArrayBounds(index, 8);

                return asfloat(asuint(this)[index]);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 8);

                uint8 cpy = asuint(this);
                cpy[index] = asuint(value);
                this = asfloat(cpy);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator + (float8 left, float8 right)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_add_ps(left, right);
            }
            else
            {
                return new float8(left.__x0 + right.__x0, left.__x4 + right.__x4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (float8 left, float8 right)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_sub_ps(left, right);
            }
            else
            {
                return new float8(left.__x0 - right.__x0, left.__x4 - right.__x4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator * (float8 left, float8 right)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_mul_ps(left, right);
            }
            else
            {
                return new float8(left.__x0 * right.__x0, left.__x4 * right.__x4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator / (float8 left, float8 right)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_div_ps(left, right);
            }
            else
            {
                return new float8(left.__x0 / right.__x0, left.__x4 / right.__x4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator % (float8 left, float8 right)
        {
            return fmod(left, right);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator + (float8 lhs, byte8 rhs) => lhs + (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (float8 lhs, byte8 rhs) => lhs - (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator * (float8 lhs, byte8 rhs) => lhs * (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator / (float8 lhs, byte8 rhs) => lhs / (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator % (float8 lhs, byte8 rhs) => lhs % (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator + (byte8 lhs, float8 rhs) => (float8)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (byte8 lhs, float8 rhs) => (float8)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator * (byte8 lhs, float8 rhs) => (float8)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator / (byte8 lhs, float8 rhs) => (float8)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator % (byte8 lhs, float8 rhs) => (float8)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator + (float8 lhs, sbyte8 rhs) => lhs + (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (float8 lhs, sbyte8 rhs) => lhs - (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator * (float8 lhs, sbyte8 rhs) => lhs * (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator / (float8 lhs, sbyte8 rhs) => lhs / (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator % (float8 lhs, sbyte8 rhs) => lhs % (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator + (sbyte8 lhs, float8 rhs) => (float8)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (sbyte8 lhs, float8 rhs) => (float8)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator * (sbyte8 lhs, float8 rhs) => (float8)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator / (sbyte8 lhs, float8 rhs) => (float8)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator % (sbyte8 lhs, float8 rhs) => (float8)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator + (float8 lhs, short8 rhs) => lhs + (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (float8 lhs, short8 rhs) => lhs - (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator * (float8 lhs, short8 rhs) => lhs * (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator / (float8 lhs, short8 rhs) => lhs / (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator % (float8 lhs, short8 rhs) => lhs % (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator + (short8 lhs, float8 rhs) => (float8)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (short8 lhs, float8 rhs) => (float8)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator * (short8 lhs, float8 rhs) => (float8)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator / (short8 lhs, float8 rhs) => (float8)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator % (short8 lhs, float8 rhs) => (float8)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator + (float8 lhs, ushort8 rhs) => lhs + (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (float8 lhs, ushort8 rhs) => lhs - (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator * (float8 lhs, ushort8 rhs) => lhs * (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator / (float8 lhs, ushort8 rhs) => lhs / (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator % (float8 lhs, ushort8 rhs) => lhs % (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator + (ushort8 lhs, float8 rhs) => (float8)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (ushort8 lhs, float8 rhs) => (float8)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator * (ushort8 lhs, float8 rhs) => (float8)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator / (ushort8 lhs, float8 rhs) => (float8)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator % (ushort8 lhs, float8 rhs) => (float8)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator + (float8 lhs, int8 rhs) => lhs + (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (float8 lhs, int8 rhs) => lhs - (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator * (float8 lhs, int8 rhs) => lhs * (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator / (float8 lhs, int8 rhs) => lhs / (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator % (float8 lhs, int8 rhs) => lhs % (float8)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator + (int8 lhs, float8 rhs) => (float8)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (int8 lhs, float8 rhs) => (float8)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator * (int8 lhs, float8 rhs) => (float8)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator / (int8 lhs, float8 rhs) => (float8)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator % (int8 lhs, float8 rhs) => (float8)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator + (float8 lhs, uint8 rhs) => lhs + (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (float8 lhs, uint8 rhs) => lhs - (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator * (float8 lhs, uint8 rhs) => lhs * (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator / (float8 lhs, uint8 rhs) => lhs / (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator % (float8 lhs, uint8 rhs) => lhs % (float8)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator + (uint8 lhs, float8 rhs) => (float8)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (uint8 lhs, float8 rhs) => (float8)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator * (uint8 lhs, float8 rhs) => (float8)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator / (uint8 lhs, float8 rhs) => (float8)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator % (uint8 lhs, float8 rhs) => (float8)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator + (float8 lhs, byte rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator + (byte lhs, float8 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (float8 lhs, byte rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (byte lhs, float8 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator * (float8 lhs, byte rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator * (byte lhs, float8 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator / (float8 lhs, byte rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator / (byte lhs, float8 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator % (float8 lhs, byte rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator % (byte lhs, float8 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator + (float8 lhs, sbyte rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator + (sbyte lhs, float8 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (float8 lhs, sbyte rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (sbyte lhs, float8 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator * (float8 lhs, sbyte rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator * (sbyte lhs, float8 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator / (float8 lhs, sbyte rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator / (sbyte lhs, float8 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator % (float8 lhs, sbyte rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator % (sbyte lhs, float8 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator + (float8 lhs, short rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator + (short lhs, float8 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (float8 lhs, short rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (short lhs, float8 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator * (float8 lhs, short rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator * (short lhs, float8 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator / (float8 lhs, short rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator / (short lhs, float8 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator % (float8 lhs, short rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator % (short lhs, float8 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator + (float8 lhs, ushort rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator + (ushort lhs, float8 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (float8 lhs, ushort rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (ushort lhs, float8 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator * (float8 lhs, ushort rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator * (ushort lhs, float8 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator / (float8 lhs, ushort rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator / (ushort lhs, float8 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator % (float8 lhs, ushort rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator % (ushort lhs, float8 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator + (float8 lhs, int rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator + (int lhs, float8 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (float8 lhs, int rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (int lhs, float8 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator * (float8 lhs, int rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator * (int lhs, float8 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator / (float8 lhs, int rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator / (int lhs, float8 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator % (float8 lhs, int rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator % (int lhs, float8 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator + (float8 lhs, uint rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator + (uint lhs, float8 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (float8 lhs, uint rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (uint lhs, float8 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator * (float8 lhs, uint rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator * (uint lhs, float8 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator / (float8 lhs, uint rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator / (uint lhs, float8 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator % (float8 lhs, uint rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator % (uint lhs, float8 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator + (float8 lhs, long rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator + (long lhs, float8 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (float8 lhs, long rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (long lhs, float8 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator * (float8 lhs, long rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator * (long lhs, float8 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator / (float8 lhs, long rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator / (long lhs, float8 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator % (float8 lhs, long rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator % (long lhs, float8 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator + (float8 lhs, ulong rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator + (ulong lhs, float8 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (float8 lhs, ulong rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (ulong lhs, float8 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator * (float8 lhs, ulong rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator * (ulong lhs, float8 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator / (float8 lhs, ulong rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator / (ulong lhs, float8 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator % (float8 lhs, ulong rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator % (ulong lhs, float8 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator + (float8 lhs, Int128 rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator + (Int128 lhs, float8 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (float8 lhs, Int128 rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (Int128 lhs, float8 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator * (float8 lhs, Int128 rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator * (Int128 lhs, float8 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator / (float8 lhs, Int128 rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator / (Int128 lhs, float8 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator % (float8 lhs, Int128 rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator % (Int128 lhs, float8 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator + (float8 lhs, UInt128 rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator + (UInt128 lhs, float8 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (float8 lhs, UInt128 rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (UInt128 lhs, float8 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator * (float8 lhs, UInt128 rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator * (UInt128 lhs, float8 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator / (float8 lhs, UInt128 rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator / (UInt128 lhs, float8 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator % (float8 lhs, UInt128 rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator % (UInt128 lhs, float8 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_neg_ps(x);
            }
            else
            {
                return new float8(-x.__x0, -x.__x4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator ++ (float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_add_ps(x, new float8(1f));
            }
            else
            {
                return new float8(x.__x0 + 1f, x.__x4 + 1f);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator -- (float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_sub_ps(x, new float8(1f));
            }
            else
            {
                return new float8(x.__x0 - 1f, x.__x4 - 1f);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator == (float8 left, float8 right)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_cmpeq_ps(left, right);
            }
            else
            {
                return new mask32x8(left.__x0 == right.__x0, left.__x4 == right.__x4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator < (float8 left, float8 right)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_cmplt_ps(left, right);
            }
            else
            {
                return new mask32x8(left.__x0 < right.__x0, left.__x4 < right.__x4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator > (float8 left, float8 right)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_cmpgt_ps(left, right);
            }
            else
            {
                return new mask32x8(left.__x0 > right.__x0, left.__x4 > right.__x4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator != (float8 left, float8 right)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_cmpneq_ps(left, right);
            }
            else
            {
                return new mask32x8(left.__x0 != right.__x0, left.__x4 != right.__x4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator <= (float8 left, float8 right)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_cmple_ps(left, right);
            }
            else
            {
                return new mask32x8(left.__x0 <= right.__x0, left.__x4 <= right.__x4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator >= (float8 left, float8 right)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_cmpge_ps(left, right);
            }
            else
            {
                return new mask32x8(left.__x0 >= right.__x0, left.__x4 >= right.__x4);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator == (float8 lhs, byte8 rhs) => lhs == (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator != (float8 lhs, byte8 rhs) => lhs != (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator < (float8 lhs, byte8 rhs) => lhs < (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator > (float8 lhs, byte8 rhs) => lhs > (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator <= (float8 lhs, byte8 rhs) => lhs <= (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator >= (float8 lhs, byte8 rhs) => lhs >= (float8)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator == (byte8 lhs, float8 rhs) => (float8)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator != (byte8 lhs, float8 rhs) => (float8)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator < (byte8 lhs, float8 rhs) => (float8)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator > (byte8 lhs, float8 rhs) => (float8)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator <= (byte8 lhs, float8 rhs) => (float8)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator >= (byte8 lhs, float8 rhs) => (float8)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator == (float8 lhs, sbyte8 rhs) => lhs == (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator != (float8 lhs, sbyte8 rhs) => lhs != (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator < (float8 lhs, sbyte8 rhs) => lhs < (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator > (float8 lhs, sbyte8 rhs) => lhs > (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator <= (float8 lhs, sbyte8 rhs) => lhs <= (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator >= (float8 lhs, sbyte8 rhs) => lhs >= (float8)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator == (sbyte8 lhs, float8 rhs) => (float8)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator != (sbyte8 lhs, float8 rhs) => (float8)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator < (sbyte8 lhs, float8 rhs) => (float8)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator > (sbyte8 lhs, float8 rhs) => (float8)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator <= (sbyte8 lhs, float8 rhs) => (float8)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator >= (sbyte8 lhs, float8 rhs) => (float8)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator == (float8 lhs, ushort8 rhs) => lhs == (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator != (float8 lhs, ushort8 rhs) => lhs != (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator < (float8 lhs, ushort8 rhs) => lhs < (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator > (float8 lhs, ushort8 rhs) => lhs > (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator <= (float8 lhs, ushort8 rhs) => lhs <= (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator >= (float8 lhs, ushort8 rhs) => lhs >= (float8)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator == (ushort8 lhs, float8 rhs) => (float8)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator != (ushort8 lhs, float8 rhs) => (float8)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator < (ushort8 lhs, float8 rhs) => (float8)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator > (ushort8 lhs, float8 rhs) => (float8)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator <= (ushort8 lhs, float8 rhs) => (float8)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator >= (ushort8 lhs, float8 rhs) => (float8)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator == (float8 lhs, short8 rhs) => lhs == (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator != (float8 lhs, short8 rhs) => lhs != (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator < (float8 lhs, short8 rhs) => lhs < (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator > (float8 lhs, short8 rhs) => lhs > (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator <= (float8 lhs, short8 rhs) => lhs <= (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator >= (float8 lhs, short8 rhs) => lhs >= (float8)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator == (short8 lhs, float8 rhs) => (float8)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator != (short8 lhs, float8 rhs) => (float8)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator < (short8 lhs, float8 rhs) => (float8)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator > (short8 lhs, float8 rhs) => (float8)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator <= (short8 lhs, float8 rhs) => (float8)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator >= (short8 lhs, float8 rhs) => (float8)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator == (float8 lhs, int8 rhs) => lhs == (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator != (float8 lhs, int8 rhs) => lhs != (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator < (float8 lhs, int8 rhs) => lhs < (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator > (float8 lhs, int8 rhs) => lhs > (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator <= (float8 lhs, int8 rhs) => lhs <= (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator >= (float8 lhs, int8 rhs) => lhs >= (float8)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator == (int8 lhs, float8 rhs) => (float8)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator != (int8 lhs, float8 rhs) => (float8)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator < (int8 lhs, float8 rhs) => (float8)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator > (int8 lhs, float8 rhs) => (float8)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator <= (int8 lhs, float8 rhs) => (float8)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator >= (int8 lhs, float8 rhs) => (float8)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator == (float8 lhs, uint8 rhs) => lhs == (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator != (float8 lhs, uint8 rhs) => lhs != (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator < (float8 lhs, uint8 rhs) => lhs < (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator > (float8 lhs, uint8 rhs) => lhs > (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator <= (float8 lhs, uint8 rhs) => lhs <= (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator >= (float8 lhs, uint8 rhs) => lhs >= (float8)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator == (uint8 lhs, float8 rhs) => (float8)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator != (uint8 lhs, float8 rhs) => (float8)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator < (uint8 lhs, float8 rhs) => (float8)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator > (uint8 lhs, float8 rhs) => (float8)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator <= (uint8 lhs, float8 rhs) => (float8)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator >= (uint8 lhs, float8 rhs) => (float8)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator == (float8 lhs, byte rhs) => lhs == (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator != (float8 lhs, byte rhs) => lhs != (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator < (float8 lhs, byte rhs) => lhs < (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator > (float8 lhs, byte rhs) => lhs > (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator <= (float8 lhs, byte rhs) => lhs <= (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator >= (float8 lhs, byte rhs) => lhs >= (float8)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator == (byte lhs, float8 rhs) => (float8)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator != (byte lhs, float8 rhs) => (float8)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator < (byte lhs, float8 rhs) => (float8)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator > (byte lhs, float8 rhs) => (float8)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator <= (byte lhs, float8 rhs) => (float8)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator >= (byte lhs, float8 rhs) => (float8)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator == (float8 lhs, sbyte rhs) => lhs == (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator != (float8 lhs, sbyte rhs) => lhs != (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator < (float8 lhs, sbyte rhs) => lhs < (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator > (float8 lhs, sbyte rhs) => lhs > (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator <= (float8 lhs, sbyte rhs) => lhs <= (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator >= (float8 lhs, sbyte rhs) => lhs >= (float8)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator == (sbyte lhs, float8 rhs) => (float8)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator != (sbyte lhs, float8 rhs) => (float8)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator < (sbyte lhs, float8 rhs) => (float8)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator > (sbyte lhs, float8 rhs) => (float8)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator <= (sbyte lhs, float8 rhs) => (float8)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator >= (sbyte lhs, float8 rhs) => (float8)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator == (float8 lhs, ushort rhs) => lhs == (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator != (float8 lhs, ushort rhs) => lhs != (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator < (float8 lhs, ushort rhs) => lhs < (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator > (float8 lhs, ushort rhs) => lhs > (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator <= (float8 lhs, ushort rhs) => lhs <= (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator >= (float8 lhs, ushort rhs) => lhs >= (float8)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator == (ushort lhs, float8 rhs) => (float8)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator != (ushort lhs, float8 rhs) => (float8)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator < (ushort lhs, float8 rhs) => (float8)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator > (ushort lhs, float8 rhs) => (float8)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator <= (ushort lhs, float8 rhs) => (float8)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator >= (ushort lhs, float8 rhs) => (float8)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator == (float8 lhs, short rhs) => lhs == (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator != (float8 lhs, short rhs) => lhs != (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator < (float8 lhs, short rhs) => lhs < (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator > (float8 lhs, short rhs) => lhs > (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator <= (float8 lhs, short rhs) => lhs <= (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator >= (float8 lhs, short rhs) => lhs >= (float8)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator == (short lhs, float8 rhs) => (float8)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator != (short lhs, float8 rhs) => (float8)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator < (short lhs, float8 rhs) => (float8)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator > (short lhs, float8 rhs) => (float8)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator <= (short lhs, float8 rhs) => (float8)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator >= (short lhs, float8 rhs) => (float8)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator == (float8 lhs, int rhs) => lhs == (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator != (float8 lhs, int rhs) => lhs != (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator < (float8 lhs, int rhs) => lhs < (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator > (float8 lhs, int rhs) => lhs > (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator <= (float8 lhs, int rhs) => lhs <= (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator >= (float8 lhs, int rhs) => lhs >= (float8)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator == (int lhs, float8 rhs) => (float8)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator != (int lhs, float8 rhs) => (float8)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator < (int lhs, float8 rhs) => (float8)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator > (int lhs, float8 rhs) => (float8)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator <= (int lhs, float8 rhs) => (float8)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator >= (int lhs, float8 rhs) => (float8)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator == (float8 lhs, uint rhs) => lhs == (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator != (float8 lhs, uint rhs) => lhs != (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator < (float8 lhs, uint rhs) => lhs < (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator > (float8 lhs, uint rhs) => lhs > (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator <= (float8 lhs, uint rhs) => lhs <= (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator >= (float8 lhs, uint rhs) => lhs >= (float8)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator == (uint lhs, float8 rhs) => (float8)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator != (uint lhs, float8 rhs) => (float8)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator < (uint lhs, float8 rhs) => (float8)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator > (uint lhs, float8 rhs) => (float8)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator <= (uint lhs, float8 rhs) => (float8)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator >= (uint lhs, float8 rhs) => (float8)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator == (float8 lhs, long rhs) => lhs == (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator != (float8 lhs, long rhs) => lhs != (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator < (float8 lhs, long rhs) => lhs < (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator > (float8 lhs, long rhs) => lhs > (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator <= (float8 lhs, long rhs) => lhs <= (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator >= (float8 lhs, long rhs) => lhs >= (float8)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator == (long lhs, float8 rhs) => (float8)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator != (long lhs, float8 rhs) => (float8)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator < (long lhs, float8 rhs) => (float8)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator > (long lhs, float8 rhs) => (float8)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator <= (long lhs, float8 rhs) => (float8)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator >= (long lhs, float8 rhs) => (float8)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator == (float8 lhs, ulong rhs) => lhs == (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator != (float8 lhs, ulong rhs) => lhs != (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator < (float8 lhs, ulong rhs) => lhs < (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator > (float8 lhs, ulong rhs) => lhs > (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator <= (float8 lhs, ulong rhs) => lhs <= (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator >= (float8 lhs, ulong rhs) => lhs >= (float8)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator == (ulong lhs, float8 rhs) => (float8)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator != (ulong lhs, float8 rhs) => (float8)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator < (ulong lhs, float8 rhs) => (float8)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator > (ulong lhs, float8 rhs) => (float8)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator <= (ulong lhs, float8 rhs) => (float8)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator >= (ulong lhs, float8 rhs) => (float8)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator == (float8 lhs, Int128 rhs) => lhs == (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator != (float8 lhs, Int128 rhs) => lhs != (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator < (float8 lhs, Int128 rhs) => lhs < (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator > (float8 lhs, Int128 rhs) => lhs > (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator <= (float8 lhs, Int128 rhs) => lhs <= (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator >= (float8 lhs, Int128 rhs) => lhs >= (float8)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator == (Int128 lhs, float8 rhs) => (float8)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator != (Int128 lhs, float8 rhs) => (float8)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator < (Int128 lhs, float8 rhs) => (float8)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator > (Int128 lhs, float8 rhs) => (float8)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator <= (Int128 lhs, float8 rhs) => (float8)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator >= (Int128 lhs, float8 rhs) => (float8)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator == (float8 lhs, UInt128 rhs) => lhs == (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator != (float8 lhs, UInt128 rhs) => lhs != (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator < (float8 lhs, UInt128 rhs) => lhs < (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator > (float8 lhs, UInt128 rhs) => lhs > (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator <= (float8 lhs, UInt128 rhs) => lhs <= (float8)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator >= (float8 lhs, UInt128 rhs) => lhs >= (float8)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator == (UInt128 lhs, float8 rhs) => (float8)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator != (UInt128 lhs, float8 rhs) => (float8)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator < (UInt128 lhs, float8 rhs) => (float8)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator > (UInt128 lhs, float8 rhs) => (float8)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator <= (UInt128 lhs, float8 rhs) => (float8)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator >= (UInt128 lhs, float8 rhs) => (float8)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(float8 other)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_alltrue_f256<float>(Xse.mm256_cmpeq_ps(this, other));
            }
            else
            {
                return this.__x0.Equals(other.__x0) & this.__x4.Equals(other.__x4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly bool Equals(object obj) => obj is float8 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);

        public override string ToString() => $"float8({x0}f, {x1}f, {x2}f, {x3}f,    {x4}f, {x5}f, {x6}f, {x7}f)";
        public string ToString(string format, IFormatProvider formatProvider) => $"float8({x0.ToString(format, formatProvider)}f, {x1.ToString(format, formatProvider)}f, {x2.ToString(format, formatProvider)}f, {x3.ToString(format, formatProvider)}f,    {x4.ToString(format, formatProvider)}f, {x5.ToString(format, formatProvider)}f, {x6.ToString(format, formatProvider)}f, {x7.ToString(format, formatProvider)}f)";
    }
}