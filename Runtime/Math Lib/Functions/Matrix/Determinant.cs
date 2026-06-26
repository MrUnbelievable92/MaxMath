using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>   Returns the determinant of an <see cref="MaxMath.sbyte4x4"/> matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int determinant(sbyte4x4 m)
        {
            return determinant((int4x4)m);
        }
        
        /// <summary>   Returns the determinant of an <see cref="MaxMath.short4x4"/> matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int determinant(short4x4 m)
        {
            return determinant((int4x4)m);
        }
        
        /// <summary>   Returns the determinant of an <see cref="MaxMath.int4x4"/> matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int determinant(int4x4 m)
        {
            int4 v0 = shuffle(m.c1, m.c0, ShuffleComponent.LeftY, ShuffleComponent.RightY, ShuffleComponent.RightY, ShuffleComponent.RightY);
            int4 v1 = shuffle(m.c2, m.c1, ShuffleComponent.LeftZ, ShuffleComponent.LeftZ,  ShuffleComponent.RightZ, ShuffleComponent.RightZ);
            int4 v2 = shuffle(m.c3, m.c2, ShuffleComponent.LeftW, ShuffleComponent.LeftW,  ShuffleComponent.LeftW,  ShuffleComponent.RightW);
            int4 v3 = shuffle(m.c2, m.c1, ShuffleComponent.LeftW, ShuffleComponent.LeftW,  ShuffleComponent.RightW, ShuffleComponent.RightW);
            int4 v4 = shuffle(m.c3, m.c2, ShuffleComponent.LeftZ, ShuffleComponent.LeftZ,  ShuffleComponent.LeftZ,  ShuffleComponent.RightZ);
            int4 v5 = shuffle(m.c2, m.c1, ShuffleComponent.LeftY, ShuffleComponent.LeftY,  ShuffleComponent.RightY, ShuffleComponent.RightY);
            int4 v6 = shuffle(m.c1, m.c0, ShuffleComponent.LeftZ, ShuffleComponent.RightZ, ShuffleComponent.RightZ, ShuffleComponent.RightZ);
            int4 v7 = shuffle(m.c1, m.c0, ShuffleComponent.LeftW, ShuffleComponent.RightW, ShuffleComponent.RightW, ShuffleComponent.RightW);
            int4 v8 = shuffle(m.c3, m.c2, ShuffleComponent.LeftY, ShuffleComponent.LeftY,  ShuffleComponent.LeftY,  ShuffleComponent.RightY);

            int4 t = v0 * (v1 * v2 - v3 * v4) - v5 * (v6 * v2 - v7 * v4) + v8 * (v6 * v3 - v7 * v1); 

            t *= new int4(shuffle(m.c0, m.c1, ShuffleComponent.LeftX, ShuffleComponent.RightX),
                          shuffle(m.c2, m.c3, ShuffleComponent.LeftX, ShuffleComponent.RightX));
            t -= t.yyww;
            return t.x + t.z;
        }
        
        /// <summary>   Returns the determinant of an <see cref="MaxMath.int4x4"/> matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int determinant(Unity.Mathematics.int4x4 m)
        {
            return determinant((int4x4)m);
        }

        /// <summary>   Returns the determinant of an <see cref="MaxMath.long4x4"/> matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long determinant(long4x4 m)
        {
            long4 v0 = shuffle(m.c1, m.c0, ShuffleComponent.LeftY, ShuffleComponent.RightY, ShuffleComponent.RightY, ShuffleComponent.RightY);
            long4 v1 = shuffle(m.c2, m.c1, ShuffleComponent.LeftZ, ShuffleComponent.LeftZ,  ShuffleComponent.RightZ, ShuffleComponent.RightZ);
            long4 v2 = shuffle(m.c3, m.c2, ShuffleComponent.LeftW, ShuffleComponent.LeftW,  ShuffleComponent.LeftW,  ShuffleComponent.RightW);
            long4 v3 = shuffle(m.c2, m.c1, ShuffleComponent.LeftW, ShuffleComponent.LeftW,  ShuffleComponent.RightW, ShuffleComponent.RightW);
            long4 v4 = shuffle(m.c3, m.c2, ShuffleComponent.LeftZ, ShuffleComponent.LeftZ,  ShuffleComponent.LeftZ,  ShuffleComponent.RightZ);
            long4 v5 = shuffle(m.c2, m.c1, ShuffleComponent.LeftY, ShuffleComponent.LeftY,  ShuffleComponent.RightY, ShuffleComponent.RightY);
            long4 v6 = shuffle(m.c1, m.c0, ShuffleComponent.LeftZ, ShuffleComponent.RightZ, ShuffleComponent.RightZ, ShuffleComponent.RightZ);
            long4 v7 = shuffle(m.c1, m.c0, ShuffleComponent.LeftW, ShuffleComponent.RightW, ShuffleComponent.RightW, ShuffleComponent.RightW);
            long4 v8 = shuffle(m.c3, m.c2, ShuffleComponent.LeftY, ShuffleComponent.LeftY,  ShuffleComponent.LeftY,  ShuffleComponent.RightY);

            long4 t = v0 * (v1 * v2 - v3 * v4) - v5 * (v6 * v2 - v7 * v4) + v8 * (v6 * v3 - v7 * v1); 
            
            long2 lo = t.xy;
            long2 hi = t.zw;
            lo *= shuffle(m.c0, m.c1, ShuffleComponent.LeftX, ShuffleComponent.RightX);
            hi *= shuffle(m.c2, m.c3, ShuffleComponent.LeftX, ShuffleComponent.RightX);
            lo -= lo.yy;
            hi -= hi.yy;

            return (lo + hi).x;
        }

        /// <summary>   Returns the determinant of an <see cref="MaxMath.float4x4"/> matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float determinant(float4x4 m)
        {
            float4 v0 = shuffle(m.c1, m.c0, ShuffleComponent.LeftY, ShuffleComponent.RightY, ShuffleComponent.RightY, ShuffleComponent.RightY);
            float4 v1 = shuffle(m.c2, m.c1, ShuffleComponent.LeftZ, ShuffleComponent.LeftZ,  ShuffleComponent.RightZ, ShuffleComponent.RightZ);
            float4 v2 = shuffle(m.c3, m.c2, ShuffleComponent.LeftW, ShuffleComponent.LeftW,  ShuffleComponent.LeftW,  ShuffleComponent.RightW);
            float4 v3 = shuffle(m.c2, m.c1, ShuffleComponent.LeftW, ShuffleComponent.LeftW,  ShuffleComponent.RightW, ShuffleComponent.RightW);
            float4 v4 = shuffle(m.c3, m.c2, ShuffleComponent.LeftZ, ShuffleComponent.LeftZ,  ShuffleComponent.LeftZ,  ShuffleComponent.RightZ);
            float4 v5 = shuffle(m.c2, m.c1, ShuffleComponent.LeftY, ShuffleComponent.LeftY,  ShuffleComponent.RightY, ShuffleComponent.RightY);
            float4 v6 = shuffle(m.c1, m.c0, ShuffleComponent.LeftZ, ShuffleComponent.RightZ, ShuffleComponent.RightZ, ShuffleComponent.RightZ);
            float4 v7 = shuffle(m.c1, m.c0, ShuffleComponent.LeftW, ShuffleComponent.RightW, ShuffleComponent.RightW, ShuffleComponent.RightW);
            float4 v8 = shuffle(m.c3, m.c2, ShuffleComponent.LeftY, ShuffleComponent.LeftY,  ShuffleComponent.LeftY,  ShuffleComponent.RightY);

            float4 t = v0 * (v1 * v2 - v3 * v4) - v5 * (v6 * v2 - v7 * v4) + v8 * (v6 * v3 - v7 * v1); 

            t *= new float4(shuffle(m.c0, m.c1, ShuffleComponent.LeftX, ShuffleComponent.RightX),
                          shuffle(m.c2, m.c3, ShuffleComponent.LeftX, ShuffleComponent.RightX));
            t -= t.yyww;
            return t.x + t.z;
        }

        /// <summary>   Returns the determinant of an <see cref="MaxMath.float4x4"/> matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float determinant(Unity.Mathematics.float4x4 m)
        {
            return determinant((float4x4)m);
        }

        /// <summary>   Returns the determinant of an <see cref="MaxMath.double4x4"/> matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double determinant(double4x4 m)
        {
            double4 v0 = shuffle(m.c1, m.c0, ShuffleComponent.LeftY, ShuffleComponent.RightY, ShuffleComponent.RightY, ShuffleComponent.RightY);
            double4 v1 = shuffle(m.c2, m.c1, ShuffleComponent.LeftZ, ShuffleComponent.LeftZ,  ShuffleComponent.RightZ, ShuffleComponent.RightZ);
            double4 v2 = shuffle(m.c3, m.c2, ShuffleComponent.LeftW, ShuffleComponent.LeftW,  ShuffleComponent.LeftW,  ShuffleComponent.RightW);
            double4 v3 = shuffle(m.c2, m.c1, ShuffleComponent.LeftW, ShuffleComponent.LeftW,  ShuffleComponent.RightW, ShuffleComponent.RightW);
            double4 v4 = shuffle(m.c3, m.c2, ShuffleComponent.LeftZ, ShuffleComponent.LeftZ,  ShuffleComponent.LeftZ,  ShuffleComponent.RightZ);
            double4 v5 = shuffle(m.c2, m.c1, ShuffleComponent.LeftY, ShuffleComponent.LeftY,  ShuffleComponent.RightY, ShuffleComponent.RightY);
            double4 v6 = shuffle(m.c1, m.c0, ShuffleComponent.LeftZ, ShuffleComponent.RightZ, ShuffleComponent.RightZ, ShuffleComponent.RightZ);
            double4 v7 = shuffle(m.c1, m.c0, ShuffleComponent.LeftW, ShuffleComponent.RightW, ShuffleComponent.RightW, ShuffleComponent.RightW);
            double4 v8 = shuffle(m.c3, m.c2, ShuffleComponent.LeftY, ShuffleComponent.LeftY,  ShuffleComponent.LeftY,  ShuffleComponent.RightY);

            double4 t = v0 * (v1 * v2 - v3 * v4) - v5 * (v6 * v2 - v7 * v4) + v8 * (v6 * v3 - v7 * v1); 

            double2 lo = t.xy;
            double2 hi = t.zw;
            lo *= shuffle(m.c0, m.c1, ShuffleComponent.LeftX, ShuffleComponent.RightX);
            hi *= shuffle(m.c2, m.c3, ShuffleComponent.LeftX, ShuffleComponent.RightX);
            lo -= lo.yy;
            hi -= hi.yy;

            return (lo + hi).x;
        }
        
        /// <summary>   Returns the determinant of an <see cref="MaxMath.double4x4"/> matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double determinant(Unity.Mathematics.double4x4 m)
        {
            return determinant((double4x4)m);
        }


        /// <summary>   Returns the determinant of an <see cref="MaxMath.sbyte3x3"/> matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int determinant(sbyte3x3 m)
        {
            return determinant((int3x3)m);
        }
        
        /// <summary>   Returns the determinant of an <see cref="MaxMath.short3x3"/> matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int determinant(short3x3 m)
        {
            return determinant((int3x3)m);
        }
        
        /// <summary>   Returns the determinant of an <see cref="MaxMath.int3x3"/> matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int determinant(int3x3 m)
        {
            int3 v0 = shuffle(m.c1, m.c0, ShuffleComponent.LeftY, ShuffleComponent.RightY, ShuffleComponent.RightY);
            int3 v1 = shuffle(m.c2, m.c1, ShuffleComponent.LeftZ, ShuffleComponent.LeftZ,  ShuffleComponent.RightZ);
            int3 v2 = shuffle(m.c1, m.c0, ShuffleComponent.LeftZ, ShuffleComponent.RightZ, ShuffleComponent.RightZ);
            int3 v3 = shuffle(m.c2, m.c1, ShuffleComponent.LeftY, ShuffleComponent.LeftY,  ShuffleComponent.RightY);
            
            int3 t = v0 * v1 - v2 * v3;
            t *= new int3(m.c0.x, -m.c1.x, m.c2.x);

            return csum(t);
        }
        
        /// <summary>   Returns the determinant of an <see cref="MaxMath.int3x3"/> matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int determinant(Unity.Mathematics.int3x3 m)
        {
            return determinant((int3x3)m);
        }

        /// <summary>   Returns the determinant of an <see cref="MaxMath.long3x3"/> matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long determinant(long3x3 m)
        {
            long m00 = m.c1.y * m.c2.z - m.c1.z * m.c2.y;
            long m01 = m.c0.y * m.c2.z - m.c0.z * m.c2.y;
            long m02 = m.c0.y * m.c1.z - m.c0.z * m.c1.y;

            return m.c0.x * m00 - m.c1.x * m01 + m.c2.x * m02;
        }

        /// <summary>   Returns the determinant of an <see cref="MaxMath.float3x3"/> matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float determinant(float3x3 m)
        {
            return Unity.Mathematics.math.determinant(m);
        }

        /// <summary>   Returns the determinant of an <see cref="MaxMath.float3x3"/> matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float determinant(Unity.Mathematics.float3x3 m)
        {
            return determinant((float3x3)m);
        }

        /// <summary>   Returns the determinant of an <see cref="MaxMath.double3x3"/> matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double determinant(double3x3 m)
        {
            return Unity.Mathematics.math.determinant(m);
        }
        
        /// <summary>   Returns the determinant of an <see cref="MaxMath.double3x3"/> matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double determinant(Unity.Mathematics.double3x3 m)
        {
            return determinant((double3x3)m);
        }


        /// <summary>   Returns the determinant of an <see cref="MaxMath.sbyte2x2"/> matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int determinant(sbyte2x2 m)
        {
            return determinant((int2x2)m);
        }
        
        /// <summary>   Returns the determinant of an <see cref="MaxMath.short2x2"/> matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int determinant(short2x2 m)
        {
            return determinant((int2x2)m);
        }
        
        /// <summary>   Returns the determinant of an <see cref="MaxMath.int2x2"/> matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int determinant(int2x2 m)
        {
            int2 t = m.c0 * m.c1.yx;
            return t.x - t.y;
        }
        
        /// <summary>   Returns the determinant of an <see cref="MaxMath.int2x2"/> matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int determinant(Unity.Mathematics.int2x2 m)
        {
            return determinant((int2x2)m);
        }

        /// <summary>   Returns the determinant of an <see cref="MaxMath.long2x2"/> matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long determinant(long2x2 m)
        {
            return m.c0.x * m.c1.y - m.c1.x * m.c0.y;
        }

        /// <summary>   Returns the determinant of an <see cref="MaxMath.float2x2"/> matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float determinant(float2x2 m)
        {
            float2 t = m.c0 * m.c1.yx;
            return t.x - t.y;
        }

        /// <summary>   Returns the determinant of an <see cref="MaxMath.float2x2"/> matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float determinant(Unity.Mathematics.float2x2 m)
        {
            return determinant((float2x2)m);
        }

        /// <summary>   Returns the determinant of an <see cref="MaxMath.double2x2"/> matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double determinant(double2x2 m)
        {
            double2 t = m.c0 * m.c1.yx;
            return t.x - t.y;
        }
        
        /// <summary>   Returns the determinant of an <see cref="MaxMath.double2x2"/> matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double determinant(Unity.Mathematics.double2x2 m)
        {
            return determinant((double2x2)m);
        }
    }
}