using System;
using System.Runtime.CompilerServices;

using static MaxMath.math;

namespace MaxMath
{
    /// <summary>   A quaternion type for representing rotations.   </summary>
    [Serializable]
    unsafe public partial struct quaternion : IEquatable<quaternion>, IEquatable<Unity.Mathematics.quaternion>, IFormattable
    {
        public float4 value;

        public static quaternion identity => new quaternion(0.0f, 0.0f, 0.0f, 1.0f);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quaternion(float x, float y, float z, float w) => this = new Unity.Mathematics.quaternion(x, y, z, w);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quaternion(float4 value) => this = new Unity.Mathematics.quaternion(value);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quaternion(float3x3 m) => this = new Unity.Mathematics.quaternion(m);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quaternion(float4x4 m) => this = new Unity.Mathematics.quaternion(m);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quaternion(Unity.Mathematics.float4 value) => this = new Unity.Mathematics.quaternion(value);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quaternion(Unity.Mathematics.float3x3 m) => this = new Unity.Mathematics.quaternion(m);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quaternion(Unity.Mathematics.float4x4 m) => this = new Unity.Mathematics.quaternion(m);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quaternion(UnityEngine.Quaternion q) => (Unity.Mathematics.quaternion)q;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UnityEngine.Quaternion(quaternion q) => (Unity.Mathematics.quaternion)q;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quaternion(Unity.Mathematics.quaternion q) => new quaternion { value = q.value };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.quaternion(quaternion q) => new Unity.Mathematics.quaternion { value = q.value };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quaternion(float4 v) => new quaternion { value = v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quaternion(Unity.Mathematics.float4 v) => new quaternion { value = v };
        

        /// <summary>       Returns a <see cref="MaxMath.float3"/> representing the world space left direction relative to a world space <see cref="quaternion"/> rotation.    </summary>
        public readonly float3 Left
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                float4 temp = new float4(0f, -2f, 2f, 0f) * value.wzyx;

                return (((value.yzxw * temp.zxyw) - (value.zxyw * temp.yzxw)) + mad(temp, value.wwww, new float4(-1f, 0f, 0f, 0f))).xyz;
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.float3"/> representing the world space right direction relative to a world space <see cref="quaternion"/> rotation.    </summary>
        public readonly float3 Right
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                float4 temp = new float4(0f, 2f, -2f, 0f) * value.wzyx;

                return (((value.yzxw * temp.zxyw) - (value.zxyw * temp.yzxw)) + mad(temp, value.wwww, new float4(1f, 0f, 0f, 0f))).xyz;
            }
            
        }

        /// <summary>       Returns a <see cref="MaxMath.float3"/> representing the world space up direction relative to a world space <see cref="quaternion"/> rotation.    </summary>
        public readonly float3 Up
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                float4 temp = new float4(-2f, 0f, 2f, 0f) * value.zyxw;

                return (((value.yzxw * temp.zxyw) - (value.zxyw * temp.yzxw)) + mad(temp, value.wwww, new float4(0f, 1f, 0f, 0f))).xyz;
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.float3"/> representing the world space down direction relative to a world space <see cref="quaternion"/> rotation.    </summary>
        public readonly float3 Down
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                float4 temp = new float4(2f, 0f, -2f, 0f) * value.zyxw;

                return (((value.yzxw * temp.zxyw) - (value.zxyw * temp.yzxw)) + mad(temp, value.wwww, new float4(0f, -1f, 0f, 0f))).xyz;
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.float3"/> representing the world space forward direction relative to a world space <see cref="quaternion"/> rotation.    </summary>
        public readonly float3 Forward
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                float4 temp = new float4(2f, -2f, 0f, 0f) * value.yxzw;

                return (((value.yzxw * temp.zxyw) - (value.zxyw * temp.yzxw)) + mad(temp, value.wwww, new float4(0f, 0f, 1f, 0f))).xyz;
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.float3"/> representing the world space backward direction relative to a world space <see cref="quaternion"/> rotation.    </summary>
        public readonly float3 Backward
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                float4 temp = new float4(-2f, 2f, 0f, 0f) * value.yxzw;

                return (((value.yzxw * temp.zxyw) - (value.zxyw * temp.yzxw)) + mad(temp, value.wwww, new float4(0f, 0f, -1f, 0f))).xyz;
            }
        }


        /// <summary>
        /// Returns a quaternion representing a rotation around a unit axis by an angle in radians.
        /// The rotation direction is clockwise when looking along the rotation axis towards the origin.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion AxisAngle(float3 axis, float angle) => Unity.Mathematics.quaternion.AxisAngle(axis, angle);

        /// <summary>
        /// Returns a quaternion representing a rotation around a unit axis by an angle in radians.
        /// The rotation direction is clockwise when looking along the rotation axis towards the origin.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion AxisAngle(Unity.Mathematics.float3 axis, float angle) => Unity.Mathematics.quaternion.AxisAngle(axis, angle);

        /// <summary>
        /// Returns a quaternion constructed by first performing a rotation around the x-axis, then the y-axis and finally the z-axis.
        /// All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion EulerXYZ(float3 xyz) => Unity.Mathematics.quaternion.EulerXYZ(xyz);

        /// <summary>
        /// Returns a quaternion constructed by first performing a rotation around the x-axis, then the z-axis and finally the y-axis.
        /// All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion EulerXZY(float3 xyz) => Unity.Mathematics.quaternion.EulerXZY(xyz);

        /// <summary>
        /// Returns a quaternion constructed by first performing a rotation around the y-axis, then the x-axis and finally the z-axis.
        /// All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion EulerYXZ(float3 xyz) => Unity.Mathematics.quaternion.EulerYXZ(xyz);

        /// <summary>
        /// Returns a quaternion constructed by first performing a rotation around the y-axis, then the z-axis and finally the x-axis.
        /// All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion EulerYZX(float3 xyz) => Unity.Mathematics.quaternion.EulerYZX(xyz);

        /// <summary>
        /// Returns a quaternion constructed by first performing a rotation around the z-axis, then the x-axis and finally the y-axis.
        /// All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.
        /// This is the default order rotation order in Unity.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion EulerZXY(float3 xyz) => Unity.Mathematics.quaternion.EulerZXY(xyz);

        /// <summary>
        /// Returns a quaternion constructed by first performing a rotation around the z-axis, then the y-axis and finally the x-axis.
        /// All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion EulerZYX(float3 xyz) => Unity.Mathematics.quaternion.EulerZYX(xyz);

        /// <summary>
        /// Returns a quaternion constructed by first performing a rotation around the x-axis, then the y-axis and finally the z-axis.
        /// All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion EulerXYZ(Unity.Mathematics.float3 xyz) => Unity.Mathematics.quaternion.EulerXYZ(xyz);

        /// <summary>
        /// Returns a quaternion constructed by first performing a rotation around the x-axis, then the z-axis and finally the y-axis.
        /// All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion EulerXZY(Unity.Mathematics.float3 xyz) => Unity.Mathematics.quaternion.EulerXZY(xyz);

        /// <summary>
        /// Returns a quaternion constructed by first performing a rotation around the y-axis, then the x-axis and finally the z-axis.
        /// All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion EulerYXZ(Unity.Mathematics.float3 xyz) => Unity.Mathematics.quaternion.EulerYXZ(xyz);

        /// <summary>
        /// Returns a quaternion constructed by first performing a rotation around the y-axis, then the z-axis and finally the x-axis.
        /// All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion EulerYZX(Unity.Mathematics.float3 xyz) => Unity.Mathematics.quaternion.EulerYZX(xyz);

        /// <summary>
        /// Returns a quaternion constructed by first performing a rotation around the z-axis, then the x-axis and finally the y-axis.
        /// All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.
        /// This is the default order rotation order in Unity.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion EulerZXY(Unity.Mathematics.float3 xyz) => Unity.Mathematics.quaternion.EulerZXY(xyz);

        /// <summary>
        /// Returns a quaternion constructed by first performing a rotation around the z-axis, then the y-axis and finally the x-axis.
        /// All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion EulerZYX(Unity.Mathematics.float3 xyz) => Unity.Mathematics.quaternion.EulerZYX(xyz);

        /// <summary>
        /// Returns a quaternion constructed by first performing a rotation around the x-axis, then the y-axis and finally the z-axis.
        /// All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion EulerXYZ(float x, float y, float z) => Unity.Mathematics.quaternion.EulerXYZ(x, y, z);

        /// <summary>
        /// Returns a quaternion constructed by first performing a rotation around the x-axis, then the z-axis and finally the y-axis.
        /// All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion EulerXZY(float x, float y, float z) => Unity.Mathematics.quaternion.EulerXZY(x, y, z);

        /// <summary>
        /// Returns a quaternion constructed by first performing a rotation around the y-axis, then the x-axis and finally the z-axis.
        /// All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion EulerYXZ(float x, float y, float z) => Unity.Mathematics.quaternion.EulerYXZ(x, y, z);

        /// <summary>
        /// Returns a quaternion constructed by first performing a rotation around the y-axis, then the z-axis and finally the x-axis.
        /// All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion EulerYZX(float x, float y, float z) => Unity.Mathematics.quaternion.EulerYZX(x, y, z);

        /// <summary>
        /// Returns a quaternion constructed by first performing a rotation around the z-axis, then the x-axis and finally the y-axis.
        /// All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.
        /// This is the default order rotation order in Unity.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion EulerZXY(float x, float y, float z) => Unity.Mathematics.quaternion.EulerZXY(x, y, z);

        /// <summary>
        /// Returns a quaternion constructed by first performing a rotation around the z-axis, then the y-axis and finally the x-axis.
        /// All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion EulerZYX(float x, float y, float z) => Unity.Mathematics.quaternion.EulerZYX(x, y, z);

        /// <summary>
        /// Returns a quaternion constructed by first performing 3 rotations around the principal axes in a given order.
        /// All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.
        /// When the rotation order is known at compile time, it is recommended for performance reasons to use specific
        /// Euler rotation constructors such as EulerZXY(...).
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion Euler(float3 xyz, RotationOrder order = RotationOrder.ZXY) => Unity.Mathematics.quaternion.Euler(xyz, (Unity.Mathematics.math.RotationOrder)order);

        /// <summary>
        /// Returns a quaternion constructed by first performing 3 rotations around the principal axes in a given order.
        /// All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.
        /// When the rotation order is known at compile time, it is recommended for performance reasons to use specific
        /// Euler rotation constructors such as EulerZXY(...).
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion Euler(Unity.Mathematics.float3 xyz, RotationOrder order = RotationOrder.ZXY) => Unity.Mathematics.quaternion.Euler(xyz, (Unity.Mathematics.math.RotationOrder)order);

        /// <summary>
        /// Returns a quaternion constructed by first performing 3 rotations around the principal axes in a given order.
        /// All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.
        /// When the rotation order is known at compile time, it is recommended for performance reasons to use specific
        /// Euler rotation constructors such as EulerZXY(...).
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion Euler(float x, float y, float z, RotationOrder order = RotationOrder.Default) => Unity.Mathematics.quaternion.Euler(x, y, z, (Unity.Mathematics.math.RotationOrder)order);

        /// <summary>Returns a quaternion that rotates around the x-axis by a given number of radians.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion RotateX(float angle) => Unity.Mathematics.quaternion.RotateX(angle);

        /// <summary>Returns a quaternion that rotates around the y-axis by a given number of radians.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion RotateY(float angle) => Unity.Mathematics.quaternion.RotateY(angle);

        /// <summary>Returns a quaternion that rotates around the z-axis by a given number of radians.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion RotateZ(float angle) => Unity.Mathematics.quaternion.RotateZ(angle);

        /// <summary>
        /// Returns a quaternion view rotation given a unit length forward vector and a unit length up vector.
        /// The two input vectors are assumed to be unit length and not collinear.
        /// If these assumptions are not met use float3x3.LookRotationSafe instead.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion LookRotation(float3 forward, float3 up) => Unity.Mathematics.quaternion.LookRotation(forward, up);

        /// <summary>
        /// Returns a quaternion view rotation given a unit length forward vector and a unit length up vector.
        /// The two input vectors are assumed to be unit length and not collinear.
        /// If these assumptions are not met use float3x3.LookRotationSafe instead.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion LookRotation(Unity.Mathematics.float3 forward, Unity.Mathematics.float3 up) => Unity.Mathematics.quaternion.LookRotation(forward, up);

        /// <summary>
        /// Returns a quaternion view rotation given a unit length forward vector and a unit length up vector.
        /// The two input vectors are assumed to be unit length and not collinear.
        /// If these assumptions are not met use float3x3.LookRotationSafe instead.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion LookRotation(Unity.Mathematics.float3 forward, float3 up) => Unity.Mathematics.quaternion.LookRotation(forward, up);

        /// <summary>
        /// Returns a quaternion view rotation given a unit length forward vector and a unit length up vector.
        /// The two input vectors are assumed to be unit length and not collinear.
        /// If these assumptions are not met use float3x3.LookRotationSafe instead.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion LookRotation(float3 forward, Unity.Mathematics.float3 up) => Unity.Mathematics.quaternion.LookRotation(forward, up);

        /// <summary>
        /// Returns a quaternion view rotation given a forward vector and an up vector.
        /// The two input vectors are not assumed to be unit length.
        /// If the magnitude of either of the vectors is so extreme that the calculation cannot be carried out reliably or the vectors are collinear,
        /// the identity will be returned instead.
        /// </summary>
        public static quaternion LookRotationSafe(float3 forward, float3 up) => Unity.Mathematics.quaternion.LookRotationSafe(forward, up);

        /// <summary>
        /// Returns a quaternion view rotation given a forward vector and an up vector.
        /// The two input vectors are not assumed to be unit length.
        /// If the magnitude of either of the vectors is so extreme that the calculation cannot be carried out reliably or the vectors are collinear,
        /// the identity will be returned instead.
        /// </summary>
        public static quaternion LookRotationSafe(Unity.Mathematics.float3 forward, Unity.Mathematics.float3 up) => Unity.Mathematics.quaternion.LookRotationSafe(forward, up);

        /// <summary>
        /// Returns a quaternion view rotation given a forward vector and an up vector.
        /// The two input vectors are not assumed to be unit length.
        /// If the magnitude of either of the vectors is so extreme that the calculation cannot be carried out reliably or the vectors are collinear,
        /// the identity will be returned instead.
        /// </summary>
        public static quaternion LookRotationSafe(Unity.Mathematics.float3 forward, float3 up) => Unity.Mathematics.quaternion.LookRotationSafe(forward, up);

        /// <summary>
        /// Returns a quaternion view rotation given a forward vector and an up vector.
        /// The two input vectors are not assumed to be unit length.
        /// If the magnitude of either of the vectors is so extreme that the calculation cannot be carried out reliably or the vectors are collinear,
        /// the identity will be returned instead.
        /// </summary>
        public static quaternion LookRotationSafe(float3 forward, Unity.Mathematics.float3 up) => Unity.Mathematics.quaternion.LookRotationSafe(forward, up);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(quaternion other) => ((Unity.Mathematics.quaternion)this).Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.quaternion other) => ((Unity.Mathematics.quaternion)this).Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly bool Equals(object o) => (o is quaternion converted && Equals(converted)) || (o is Unity.Mathematics.quaternion convertedU && Equals(convertedU)); 

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((Unity.Mathematics.quaternion)this).ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) => ((Unity.Mathematics.quaternion)this).ToString(format, formatProvider);
    }
}
