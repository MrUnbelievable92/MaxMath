using System;
using System.Runtime.CompilerServices;

using static MaxMath.math;

namespace MaxMath
{
    /// <summary>   A rigid transformation type.    </summary>
    [Serializable]
    public struct RigidTransform : IEquatable<RigidTransform>, IEquatable<Unity.Mathematics.RigidTransform>
    {
        /// <summary>   The rotation part of the rigid transformation.  </summary>
        public quaternion rot;

        /// <summary>   The translation part of the rigid transformation.   </summary>
        public float3 pos;

        /// <summary>   A <see cref="MaxMath.RigidTransform"/> representing the identity transform.   </summary>
        public static RigidTransform identity => new RigidTransform(new quaternion(0f, 0f, 0f, 1f), new float3(0f, 0f, 0f));

        /// <summary>   Constructs a <see cref="MaxMath.RigidTransform"/> from a rotation represented by a unit <see cref="MaxMath.quaternion"/> and a translation represented by a <see cref="MaxMath.float3"/> vector.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RigidTransform(quaternion rotation, float3 translation)
        {
            this.rot = rotation;
            this.pos = translation;
        }

        /// <summary>   Constructs a <see cref="MaxMath.RigidTransform"/> from a rotation represented by a unit <see cref="MaxMath.quaternion"/> and a translation represented by a <see cref="MaxMath.float3"/> vector.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RigidTransform(quaternion rotation, Unity.Mathematics.float3 translation)
        {
            this.rot = rotation;
            this.pos = translation;
        }

        /// <summary>   Constructs a <see cref="MaxMath.RigidTransform"/> from a rotation represented by a unit <see cref="MaxMath.quaternion"/> and a translation represented by a <see cref="MaxMath.float3"/> vector.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RigidTransform(Unity.Mathematics.quaternion rotation, float3 translation)
        {
            this.rot = rotation;
            this.pos = translation;
        }

        /// <summary>   Constructs a <see cref="MaxMath.RigidTransform"/> from a rotation represented by a unit <see cref="MaxMath.quaternion"/> and a translation represented by a <see cref="MaxMath.float3"/> vector.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RigidTransform(Unity.Mathematics.quaternion rotation, Unity.Mathematics.float3 translation)
        {
            this.rot = rotation;
            this.pos = translation;
        }

        /// <summary>   Constructs a <see cref="MaxMath.RigidTransform"/> from a rotation represented by a <see cref="MaxMath.float3x3"/> matrix and a translation represented by a <see cref="MaxMath.float3"/> vector.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RigidTransform(float3x3 rotation, float3 translation)
        {
            this.rot = new quaternion(rotation);
            this.pos = translation;
        }

        /// <summary>   Constructs a <see cref="MaxMath.RigidTransform"/> from a rotation represented by a <see cref="MaxMath.float3x3"/> matrix and a translation represented by a <see cref="MaxMath.float3"/> vector.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RigidTransform(float3x3 rotation, Unity.Mathematics.float3 translation)
        {
            this.rot = new quaternion(rotation);
            this.pos = translation;
        }

        /// <summary>   Constructs a <see cref="MaxMath.RigidTransform"/> from a rotation represented by a <see cref="MaxMath.float3x3"/> matrix and a translation represented by a <see cref="MaxMath.float3"/> vector.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RigidTransform(Unity.Mathematics.float3x3 rotation, float3 translation)
        {
            this.rot = new quaternion(rotation);
            this.pos = translation;
        }

        /// <summary>   Constructs a <see cref="MaxMath.RigidTransform"/> from a rotation represented by a <see cref="MaxMath.float3x3"/> matrix and a translation represented by a <see cref="MaxMath.float3"/> vector.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RigidTransform(Unity.Mathematics.float3x3 rotation, Unity.Mathematics.float3 translation)
        {
            this.rot = new quaternion(rotation);
            this.pos = translation;
        }

        /// <summary>   Constructs a <see cref="MaxMath.RigidTransform"/> from a <see cref="MaxMath.float4x4"/>. Assumes the matrix is orthonormal.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RigidTransform(float4x4 transform)
        {
            this.rot = new quaternion(transform);
            this.pos = transform.c3.xyz;
        }

        /// <summary>   Constructs a <see cref="MaxMath.RigidTransform"/> from a <see cref="MaxMath.float4x4"/>. Assumes the matrix is orthonormal.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RigidTransform(Unity.Mathematics.float4x4 transform)
        {
            this.rot = new quaternion(transform);
            this.pos = transform.c3.xyz;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator RigidTransform(Unity.Mathematics.RigidTransform x) => new RigidTransform { rot = x.rot, pos = x.pos };
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.RigidTransform(RigidTransform x) => new Unity.Mathematics.RigidTransform { rot = x.rot, pos = x.pos };


        /// <summary>   Returns a <see cref="MaxMath.RigidTransform"/> representing a rotation around a unit axis by an angle in radians. The rotation direction is clockwise when looking along the rotation axis towards the origin.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RigidTransform AxisAngle(float3 axis, float angle) => Unity.Mathematics.RigidTransform.AxisAngle(axis, angle);

        /// <summary>   Returns a <see cref="MaxMath.RigidTransform"/> representing a rotation around a unit axis by an angle in radians. The rotation direction is clockwise when looking along the rotation axis towards the origin.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RigidTransform AxisAngle(Unity.Mathematics.float3 axis, float angle) => Unity.Mathematics.RigidTransform.AxisAngle(axis, angle);


        /// <summary>   Returns a <see cref="MaxMath.RigidTransform"/> constructed by first performing a rotation around the x-axis, then the y-axis and finally the z-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RigidTransform EulerXYZ(float3 xyz) => Unity.Mathematics.RigidTransform.EulerXYZ(xyz);

        /// <summary>   Returns a <see cref="MaxMath.RigidTransform"/> constructed by first performing a rotation around the x-axis, then the z-axis and finally the y-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RigidTransform EulerXZY(float3 xyz) => Unity.Mathematics.RigidTransform.EulerXZY(xyz);

        /// <summary>   Returns a <see cref="MaxMath.RigidTransform"/> constructed by first performing a rotation around the y-axis, then the x-axis and finally the z-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RigidTransform EulerYXZ(float3 xyz) => Unity.Mathematics.RigidTransform.EulerYXZ(xyz);

        /// <summary>   Returns a <see cref="MaxMath.RigidTransform"/> constructed by first performing a rotation around the y-axis, then the z-axis and finally the x-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RigidTransform EulerYZX(float3 xyz) => Unity.Mathematics.RigidTransform.EulerYZX(xyz);

        /// <summary>   Returns a <see cref="MaxMath.RigidTransform"/> constructed by first performing a rotation around the z-axis, then the x-axis and finally the y-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin. This is the default order rotation order in Unity.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RigidTransform EulerZXY(float3 xyz) => Unity.Mathematics.RigidTransform.EulerZXY(xyz);

        /// <summary>   Returns a <see cref="MaxMath.RigidTransform"/> constructed by first performing a rotation around the z-axis, then the y-axis and finally the x-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RigidTransform EulerZYX(float3 xyz) => Unity.Mathematics.RigidTransform.EulerZYX(xyz);


        /// <summary>   Returns a <see cref="MaxMath.RigidTransform"/> constructed by first performing a rotation around the x-axis, then the y-axis and finally the z-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RigidTransform EulerXYZ(Unity.Mathematics.float3 xyz) => Unity.Mathematics.RigidTransform.EulerXYZ(xyz);

        /// <summary>   Returns a <see cref="MaxMath.RigidTransform"/> constructed by first performing a rotation around the x-axis, then the z-axis and finally the y-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RigidTransform EulerXZY(Unity.Mathematics.float3 xyz) => Unity.Mathematics.RigidTransform.EulerXZY(xyz);

        /// <summary>   Returns a <see cref="MaxMath.RigidTransform"/> constructed by first performing a rotation around the y-axis, then the x-axis and finally the z-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RigidTransform EulerYXZ(Unity.Mathematics.float3 xyz) => Unity.Mathematics.RigidTransform.EulerYXZ(xyz);

        /// <summary>   Returns a <see cref="MaxMath.RigidTransform"/> constructed by first performing a rotation around the y-axis, then the z-axis and finally the x-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RigidTransform EulerYZX(Unity.Mathematics.float3 xyz) => Unity.Mathematics.RigidTransform.EulerYZX(xyz);

        /// <summary>   Returns a <see cref="MaxMath.RigidTransform"/> constructed by first performing a rotation around the z-axis, then the x-axis and finally the y-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin. This is the default order rotation order in Unity.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RigidTransform EulerZXY(Unity.Mathematics.float3 xyz) => Unity.Mathematics.RigidTransform.EulerZXY(xyz);

        /// <summary>   Returns a <see cref="MaxMath.RigidTransform"/> constructed by first performing a rotation around the z-axis, then the y-axis and finally the x-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RigidTransform EulerZYX(Unity.Mathematics.float3 xyz) => Unity.Mathematics.RigidTransform.EulerZYX(xyz);


        /// <summary>   Returns a <see cref="MaxMath.RigidTransform"/> constructed by first performing a rotation around the x-axis, then the y-axis and finally the z-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RigidTransform EulerXYZ(float x, float y, float z) => Unity.Mathematics.RigidTransform.EulerXYZ(x, y, z);

        /// <summary>   Returns a <see cref="MaxMath.RigidTransform"/> constructed by first performing a rotation around the x-axis, then the z-axis and finally the y-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RigidTransform EulerXZY(float x, float y, float z) => Unity.Mathematics.RigidTransform.EulerXZY(x, y, z);

        /// <summary>   Returns a <see cref="MaxMath.RigidTransform"/> constructed by first performing a rotation around the y-axis, then the x-axis and finally the z-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RigidTransform EulerYXZ(float x, float y, float z) => Unity.Mathematics.RigidTransform.EulerYXZ(x, y, z);

        /// <summary>   Returns a <see cref="MaxMath.RigidTransform"/> constructed by first performing a rotation around the y-axis, then the z-axis and finally the x-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RigidTransform EulerYZX(float x, float y, float z) => Unity.Mathematics.RigidTransform.EulerYZX(x, y, z);

        /// <summary>   Returns a <see cref="MaxMath.RigidTransform"/> constructed by first performing a rotation around the z-axis, then the x-axis and finally the y-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin. This is the default order rotation order in Unity.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RigidTransform EulerZXY(float x, float y, float z) => Unity.Mathematics.RigidTransform.EulerZXY(x, y, z);

        /// <summary>   Returns a <see cref="MaxMath.RigidTransform"/> constructed by first performing a rotation around the z-axis, then the y-axis and finally the x-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RigidTransform EulerZYX(float x, float y, float z) => Unity.Mathematics.RigidTransform.EulerZYX(x, y, z);

        /// <summary>   Returns a <see cref="MaxMath.RigidTransform"/> constructed by first performing 3 rotations around the principal axes in a given order. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin. When the rotation order is known at compile time, it is recommended for performance reasons to use specific Euler rotation constructors such as EulerZXY(...).  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RigidTransform Euler(float3 xyz, RotationOrder order = RotationOrder.ZXY) => Unity.Mathematics.RigidTransform.Euler(xyz, (Unity.Mathematics.math.RotationOrder)order);

        /// <summary>   Returns a <see cref="MaxMath.RigidTransform"/> constructed by first performing 3 rotations around the principal axes in a given order. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin. When the rotation order is known at compile time, it is recommended for performance reasons to use specific Euler rotation constructors such as EulerZXY(...).  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RigidTransform Euler(float x, float y, float z, RotationOrder order = RotationOrder.Default) => Unity.Mathematics.RigidTransform.Euler(x, y, z, (Unity.Mathematics.math.RotationOrder)order);

        /// <summary>   Returns a <see cref="MaxMath.RigidTransform"/> that rotates around the x-axis by a given number of radians.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RigidTransform RotateX(float angle) => Unity.Mathematics.RigidTransform.RotateX(angle);

        /// <summary>   Returns a <see cref="MaxMath.RigidTransform"/> that rotates around the y-axis by a given number of radians.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RigidTransform RotateY(float angle) => Unity.Mathematics.RigidTransform.RotateY(angle);

        /// <summary>   Returns a <see cref="MaxMath.RigidTransform"/> that rotates around the z-axis by a given number of radians.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RigidTransform RotateZ(float angle) => Unity.Mathematics.RigidTransform.RotateZ(angle);

        /// <summary>   Returns a <see cref="MaxMath.RigidTransform"/> that translates by an amount specified by a <see cref="MaxMath.float3"/> vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RigidTransform Translate(float3 vector) => Unity.Mathematics.RigidTransform.Translate(vector);

        /// <summary>   Returns a <see cref="MaxMath.RigidTransform"/> that translates by an amount specified by a <see cref="MaxMath.float3"/> vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RigidTransform Translate(Unity.Mathematics.float3 vector) => Unity.Mathematics.RigidTransform.Translate(vector);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.RigidTransform other) => this.Equals((RigidTransform)other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(RigidTransform other) => all(this.rot.value == other.rot.value & this.pos.xyzz == other.pos.xyzz);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly bool Equals(object other) => other is RigidTransform converted && Equals(converted);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() { return (int)math.hash(this); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((Unity.Mathematics.RigidTransform)this).ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public  readonly string ToString(string format, IFormatProvider formatProvider) => ((Unity.Mathematics.RigidTransform)this).ToString(format, formatProvider);
    }
}
