using System;
using System.Runtime.CompilerServices;

namespace MaxMath
{
    /// <summary>   An affine transformation type.  </summary>
    [Serializable]
    public struct AffineTransform : IEquatable<AffineTransform>, IEquatable<Unity.Mathematics.AffineTransform>, IFormattable
    {
        /// <summary>   The rotation and scale part of the affine transformation.   </summary>
        public float3x3 rs;

        /// <summary>   The translation part of the affine transformation.  </summary>
        public float3 t;


        /// <summary>   An <see cref="AffineTransform"/> representing the identity transform. </summary>
        public static AffineTransform identity => new AffineTransform(float3.zero, float3x3.identity);

        /// <summary>   An <see cref="AffineTransform"/> zero value.    </summary>
        public static AffineTransform zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AffineTransform(float3 translation, quaternion rotation) => this = new Unity.Mathematics.AffineTransform(translation, rotation);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AffineTransform(float3 translation, quaternion rotation, float3 scale) => this = new Unity.Mathematics.AffineTransform(translation, rotation, scale);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AffineTransform(float3 translation, float3x3 rotationScale) => this = new Unity.Mathematics.AffineTransform(translation, rotationScale);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AffineTransform(float3x3 rotationScale) => this = new Unity.Mathematics.AffineTransform(rotationScale);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AffineTransform(RigidTransform rigid) => this = new Unity.Mathematics.AffineTransform(rigid);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AffineTransform(float3x4 m) => this = new Unity.Mathematics.AffineTransform(m);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AffineTransform(float4x4 m) => this = new Unity.Mathematics.AffineTransform(m);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AffineTransform(Unity.Mathematics.AffineTransform a) => new AffineTransform { rs = a.rs, t = a.t };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.AffineTransform(AffineTransform a) => new Unity.Mathematics.AffineTransform { rs = a.rs, t = a.t };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3x4(AffineTransform m) => (Unity.Mathematics.float3x4)(Unity.Mathematics.AffineTransform)m;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4x4(AffineTransform m) => (Unity.Mathematics.float4x4)(Unity.Mathematics.AffineTransform)m;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(AffineTransform other) => math.all(this.rs.c0 == other.rs.c0 & this.rs.c1 == other.rs.c1 & this.rs.c2 == other.rs.c2 & this.t == other.t);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.AffineTransform other) => this.Equals((AffineTransform)other);

        public override readonly bool Equals(object o) => o is AffineTransform converted && Equals(converted);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);

        public override readonly string ToString() => ((Unity.Mathematics.AffineTransform)this).ToString();

        public readonly string ToString(string format, IFormatProvider formatProvider) => ((Unity.Mathematics.AffineTransform)this).ToString(format, formatProvider);
    }
}
