using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MaxMath
{
    /// <summary>   A plane represented by a normal vector and a distance along the normal from the origin.     </summary>
    [DebuggerDisplay("{Normal}, {Distance}")]
    [Serializable]
    public struct Plane : IEquatable<Plane>, IEquatable<Unity.Mathematics.Geometry.Plane>
    {
        /// <summary>   A plane in the form Ax + By + Cz + Dw = 0.  </summary>
        public float4 NormalAndDistance;


        /// <summary>   Constructs a Plane from arbitrary coefficients A, B, C, D of the plane equation Ax + By + Cz + Dw = 0.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Plane(float coefficientA, float coefficientB, float coefficientC, float coefficientD)
        {
            this = new Unity.Mathematics.Geometry.Plane(coefficientA, coefficientB, coefficientC, coefficientD);
        }

        /// <summary>   Constructs a plane with a normal vector and distance from the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Plane(float3 normal, float distance)
        {
            this = new Unity.Mathematics.Geometry.Plane(normal, distance);
        }

        /// <summary>   Constructs a plane with a normal vector and distance from the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Plane(Unity.Mathematics.float3 normal, float distance)
        {
            this = new Unity.Mathematics.Geometry.Plane(normal, distance);
        }

        /// <summary>   Constructs a plane with a normal vector and a point that lies in the plane.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Plane(float3 normal, float3 pointInPlane)
        {
            this = new Unity.Mathematics.Geometry.Plane(normal, pointInPlane);
        }

        /// <summary>   Constructs a plane with a normal vector and a point that lies in the plane.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Plane(Unity.Mathematics.float3 normal, float3 pointInPlane)
        {
            this = new Unity.Mathematics.Geometry.Plane(normal, pointInPlane);
        }

        /// <summary>   Constructs a plane with a normal vector and a point that lies in the plane.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Plane(float3 normal, Unity.Mathematics.float3 pointInPlane)
        {
            this = new Unity.Mathematics.Geometry.Plane(normal, pointInPlane);
        }

        /// <summary>   Constructs a plane with a normal vector and a point that lies in the plane.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Plane(Unity.Mathematics.float3 normal, Unity.Mathematics.float3 pointInPlane)
        {
            this = new Unity.Mathematics.Geometry.Plane(normal, pointInPlane);
        }

        /// <summary>   Constructs a plane with two vectors and a point that all lie in the plane.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Plane(float3 vector1InPlane, float3 vector2InPlane, float3 pointInPlane)
        {
            this = new Unity.Mathematics.Geometry.Plane(vector1InPlane, vector2InPlane, pointInPlane);
        }

        /// <summary>   Constructs a plane with two vectors and a point that all lie in the plane.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Plane(Unity.Mathematics.float3 vector1InPlane, float3 vector2InPlane, float3 pointInPlane)
        {
            this = new Unity.Mathematics.Geometry.Plane(vector1InPlane, vector2InPlane, pointInPlane);
        }

        /// <summary>   Constructs a plane with two vectors and a point that all lie in the plane.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Plane(float3 vector1InPlane, Unity.Mathematics.float3 vector2InPlane, float3 pointInPlane)
        {
            this = new Unity.Mathematics.Geometry.Plane(vector1InPlane, vector2InPlane, pointInPlane);
        }

        /// <summary>   Constructs a plane with two vectors and a point that all lie in the plane.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Plane(float3 vector1InPlane, float3 vector2InPlane, Unity.Mathematics.float3 pointInPlane)
        {
            this = new Unity.Mathematics.Geometry.Plane(vector1InPlane, vector2InPlane, pointInPlane);
        }

        /// <summary>   Constructs a plane with two vectors and a point that all lie in the plane.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Plane(Unity.Mathematics.float3 vector1InPlane, Unity.Mathematics.float3 vector2InPlane, float3 pointInPlane)
        {
            this = new Unity.Mathematics.Geometry.Plane(vector1InPlane, vector2InPlane, pointInPlane);
        }

        /// <summary>   Constructs a plane with two vectors and a point that all lie in the plane.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Plane(Unity.Mathematics.float3 vector1InPlane, float3 vector2InPlane, Unity.Mathematics.float3 pointInPlane)
        {
            this = new Unity.Mathematics.Geometry.Plane(vector1InPlane, vector2InPlane, pointInPlane);
        }

        /// <summary>   Constructs a plane with two vectors and a point that all lie in the plane.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Plane(float3 vector1InPlane, Unity.Mathematics.float3 vector2InPlane, Unity.Mathematics.float3 pointInPlane)
        {
            this = new Unity.Mathematics.Geometry.Plane(vector1InPlane, vector2InPlane, pointInPlane);
        }

        /// <summary>   Constructs a plane with two vectors and a point that all lie in the plane.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Plane(Unity.Mathematics.float3 vector1InPlane, Unity.Mathematics.float3 vector2InPlane, Unity.Mathematics.float3 pointInPlane)
        {
            this = new Unity.Mathematics.Geometry.Plane(vector1InPlane, vector2InPlane, pointInPlane);
        }
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(Plane plane) => plane.NormalAndDistance;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float4(Plane plane) => plane.NormalAndDistance;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.Geometry.Plane(Plane plane) => new Unity.Mathematics.Geometry.Plane { NormalAndDistance = plane.NormalAndDistance };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Plane(Unity.Mathematics.Geometry.Plane plane) => new Plane { NormalAndDistance = plane.NormalAndDistance };


        /// <summary>   Creates a normalized Plane directly without normalization cost.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Plane CreateFromUnitNormalAndDistance(float3 unitNormal, float distance) => Unity.Mathematics.Geometry.Plane.CreateFromUnitNormalAndDistance(unitNormal, distance);

        /// <summary>   Creates a normalized Plane directly without normalization cost.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Plane CreateFromUnitNormalAndDistance(Unity.Mathematics.float3 unitNormal, float distance) => Unity.Mathematics.Geometry.Plane.CreateFromUnitNormalAndDistance(unitNormal, distance);

        /// <summary>   Creates a normalized Plane without normalization cost.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Plane CreateFromUnitNormalAndPointInPlane(float3 unitNormal, float3 pointInPlane) => Unity.Mathematics.Geometry.Plane.CreateFromUnitNormalAndPointInPlane(unitNormal, pointInPlane);
        
        /// <summary>   Creates a normalized Plane without normalization cost.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Plane CreateFromUnitNormalAndPointInPlane(Unity.Mathematics.float3 unitNormal, float3 pointInPlane) => Unity.Mathematics.Geometry.Plane.CreateFromUnitNormalAndPointInPlane(unitNormal, pointInPlane);
        
        /// <summary>   Creates a normalized Plane without normalization cost.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Plane CreateFromUnitNormalAndPointInPlane(float3 unitNormal, Unity.Mathematics.float3 pointInPlane) => Unity.Mathematics.Geometry.Plane.CreateFromUnitNormalAndPointInPlane(unitNormal, pointInPlane);
        
        /// <summary>   Creates a normalized Plane without normalization cost.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Plane CreateFromUnitNormalAndPointInPlane(Unity.Mathematics.float3 unitNormal, Unity.Mathematics.float3 pointInPlane) => Unity.Mathematics.Geometry.Plane.CreateFromUnitNormalAndPointInPlane(unitNormal, pointInPlane);

        /// <summary>   Get/set the normal vector of the plane.     </summary>
        public float3 Normal
        {
            readonly get => NormalAndDistance.xyz;
            set => NormalAndDistance.xyz = value;
        }

        /// <summary>   Get/set the distance of the plane from the origin. May be a negative value.    </summary>
        public float Distance
        {
            readonly get => NormalAndDistance.w;
            set => NormalAndDistance.w = value;
        }

        /// <summary>   Normalizes the given Plane.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Plane Normalize(Plane plane) => Unity.Mathematics.Geometry.Plane.Normalize(plane);

        /// <summary>   Normalizes the given Plane.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Plane Normalize(Unity.Mathematics.Geometry.Plane plane) => Unity.Mathematics.Geometry.Plane.Normalize(plane);

        /// <summary>   Normalizes the plane represented by the given plane coefficients.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 Normalize(float4 planeCoefficients) => Unity.Mathematics.Geometry.Plane.Normalize(planeCoefficients);

        /// <summary>   Normalizes the plane represented by the given plane coefficients.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 Normalize(Unity.Mathematics.float4 planeCoefficients) => Unity.Mathematics.Geometry.Plane.Normalize(planeCoefficients);

        /// <summary>   Get the signed distance from the point to the plane.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly float SignedDistanceToPoint(float3 point) => ((Unity.Mathematics.Geometry.Plane)this).SignedDistanceToPoint(point);

        /// <summary>   Get the signed distance from the point to the plane.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly float SignedDistanceToPoint(Unity.Mathematics.float3 point) => ((Unity.Mathematics.Geometry.Plane)this).SignedDistanceToPoint(point);

        /// <summary>   Projects the given point onto the plane.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly float3 Projection(float3 point) => ((Unity.Mathematics.Geometry.Plane)this).Projection(point);

        /// <summary>   Projects the given point onto the plane.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly float3 Projection(Unity.Mathematics.float3 point) => ((Unity.Mathematics.Geometry.Plane)this).Projection(point);

        /// <summary>   Flips the plane so the normal points in the opposite direction.     </summary>
        public readonly Plane Flipped => ((Unity.Mathematics.Geometry.Plane)this).Flipped;
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Plane other) => math.all(this.NormalAndDistance == other.NormalAndDistance);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.Geometry.Plane other) => this.Equals((Plane)other); 
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly bool Equals(object other) => other is Plane && Equals((Plane)other);
    }
}
