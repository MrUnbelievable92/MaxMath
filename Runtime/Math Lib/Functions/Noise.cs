using System.Runtime.CompilerServices;

namespace MaxMath
{
    public static class noise
    {
        /// <summary>   2D Cellular noise ("Worley noise") with standard 3x3 search window for good feature point values.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 cellular(float2 P) => Unity.Mathematics.noise.cellular(P);

        /// <summary>   2D Cellular noise ("Worley noise") with a 2x2 search window. Faster than using 3x3, at the expense of some strong pattern artifacts. F2 is often wrong and has sharp discontinuities. If you need a smooth F2, use the slower 3x3 version. F1 is sometimes wrong, too, but OK for most purposes.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 cellular2x2(float2 P) => Unity.Mathematics.noise.cellular2x2(P);
        
        /// <summary>   3D Cellular noise ("Worley noise") with a 2x2x2 search window. Faster than using 3x3x3, at the expense of some pattern artifacts. F2 is often wrong and has sharp discontinuities. If you need a smooth F2, use the slower 3x3x3 version.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 cellular2x2x2(float3 P) => Unity.Mathematics.noise.cellular2x2x2(P);
        
        /// <summary>   3D Cellular noise ("Worley noise") with 3x3x3 search region for good F2 everywhere, but a lot slower than the 2x2x2 version.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 cellular(float3 P) => Unity.Mathematics.noise.cellular(P);
        
        /// <summary>   Classic Perlin noise    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cnoise(float2 P) => Unity.Mathematics.noise.cnoise(P);
        
        /// <summary>   Classic Perlin noise    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cnoise(float3 P) => Unity.Mathematics.noise.cnoise(P);
        
        /// <summary>   Classic Perlin noise    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cnoise(float4 P) => Unity.Mathematics.noise.cnoise(P);

        /// <summary>   Classic Perlin noise, periodic variant  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float pnoise(float2 P, float2 rep) => Unity.Mathematics.noise.pnoise(P, rep);

        /// <summary>   Classic Perlin noise, periodic variant  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float pnoise(float3 P, float3 rep) => Unity.Mathematics.noise.pnoise(P, rep);

        /// <summary>   Classic Perlin noise, periodic variant  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float pnoise(float4 P, float4 rep) => Unity.Mathematics.noise.pnoise(P, rep);

        /// <summary>   Simplex noise.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float snoise(float2 v) => Unity.Mathematics.noise.snoise(v);

        /// <summary>   Simplex noise.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float snoise(float3 v) => Unity.Mathematics.noise.snoise(v);

        /// <summary>   Simplex noise.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float snoise(float4 v) => Unity.Mathematics.noise.snoise(v);

        /// <summary>   Simplex noise.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float snoise(float3 v, out float3 grad) { float r = Unity.Mathematics.noise.snoise(v, out Unity.Mathematics.float3 __grad); grad = __grad; return r; }

        /// <summary>   2-D tiling simplex noise with rotating gradients and analytical derivative.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 psrdnoise(float2 pos, float2 per, float rot) => Unity.Mathematics.noise.psrdnoise(pos, per, rot);

        /// <summary>   2-D tiling simplex noise with fixed gradients and analytical derivative.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 psrdnoise(float2 pos, float2 per) => Unity.Mathematics.noise.psrdnoise(pos, per);

        /// <summary>   2-D tiling simplex noise with rotating gradients, but without the analytical derivative.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float psrnoise(float2 pos, float2 per, float rot) => Unity.Mathematics.noise.psrnoise(pos, per, rot);

        /// <summary>   2-D tiling simplex noise with fixed gradients, without the analytical derivative.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float psrnoise(float2 pos, float2 per) => Unity.Mathematics.noise.psrnoise(pos, per);

        /// <summary>   2-D non-tiling simplex noise with rotating gradients and analytical derivative.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 srdnoise(float2 pos, float rot) => Unity.Mathematics.noise.srdnoise(pos, rot);

        /// <summary>   2-D non-tiling simplex noise with fixed gradients and analytical derivative.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 srdnoise(float2 pos) => Unity.Mathematics.noise.srdnoise(pos);

        /// <summary>   2-D non-tiling simplex noise with rotating gradients, without the analytical derivative.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float srnoise(float2 pos, float rot) => Unity.Mathematics.noise.srnoise(pos, rot);

        /// <summary>   2-D non-tiling simplex noise with fixed gradients, without the analytical derivative.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float srnoise(float2 pos) => Unity.Mathematics.noise.srnoise(pos);
    }
}
