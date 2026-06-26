using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class math
	{
        /// <summary>   Returns a <see cref="uint"/> hash from a block of memory using the xxhash32 algorithm. Can only be used in an unsafe context.     </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe uint hash(void* pBuffer, int numBytes, uint seed = 0) => Unity.Mathematics.math.hash(pBuffer, numBytes, seed);


        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.bool2"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(bool2 v)
        {
            uint h = 0;
            h.SetField(v, 0);
            return h;
        }
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.bool3"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(bool3 v)
        {
            uint h = 0;
            h.SetField(v, 0);
            return h;
        }
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.bool4"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(bool4 v)
        {
            uint h = 0;
            h.SetField(v, 0);
            return h;
        }
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.bool8"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(bool8 v)
        {
            return (uint)bitmask(v);
        }
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.bool16"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(bool16 v)
        {
            return (uint)bitmask(v);
        }
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.bool32"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(bool32 v)
        {
            return (uint)bitmask(v);
        }

        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.quarter2"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(quarter2 v) => hash(asbyte(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.quarter3"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(quarter3 v) => hash(asbyte(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.quarter4"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(quarter4 v) => hash(asbyte(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.quarter8"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(quarter8 v) => hash(asbyte(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.quarter16"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(quarter16 v) => hash(asbyte(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.quarter32"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(quarter32 v) => hash(asbyte(v));

        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.half"/> values.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(half v) => v.value;

        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.half2"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(half2 v) => hash(asushort(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.half3"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(half3 v) => hash(asushort(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.half4"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(half4 v) => hash(asushort(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.half8"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(half8 v) => hash(asushort(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.half16"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(half16 v) => hash(asushort(v));

        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.float2"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(float2 v) => hash(asuint(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.float3"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(float3 v) => hash(asuint(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.float4"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(float4 v) => hash(asuint(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.float8"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(float8 v) => hash(asuint(v));

        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.double2"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(double2 v) => hash(asulong(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.double3"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(double3 v) => hash(asulong(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.double4"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(double4 v) => hash(asulong(v));

        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.byte2"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(byte2 v)
        {
            uint h = 0;
            h.SetField(v, 0);
            return h;
        }
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.byte3"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(byte3 v)
        {
            uint h = 0;
            h.SetField(v, 0);
            return h;
        }
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.byte4"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(byte4 v)
        {
            uint h = 0;
            h.SetField(v, 0);
            return h;
        }
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.byte8"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(byte8 v)
        {
            uint2 h = 0;
            h.SetField(v, 0);
            return hash(h);
        }
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.byte16"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(byte16 v)
        {
            uint4 h = 0;
            h.SetField(v, 0);
            return hash(h);
        }
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.byte32"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(byte32 v)
        {
            ulong4 h = 0;
            h.SetField(v, 0);
            return hash(h);
        }

        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.sbyte2"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(sbyte2 v) => hash(asbyte(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.sbyte3"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(sbyte3 v) => hash(asbyte(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.sbyte4"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(sbyte4 v) => hash(asbyte(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.sbyte8"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(sbyte8 v) => hash(asbyte(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.sbyte16"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(sbyte16 v) => hash(asbyte(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.sbyte32"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(sbyte32 v) => hash(asbyte(v));

        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ushort2"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(ushort2 v)
        {
            uint h = 0;
            h.SetField(v, 0);
            return h;
        }
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ushort3"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(ushort3 v)
        {
            uint2 h = 0;
            h.SetField(v, 0);
            return hash(h);
        }
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ushort4"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(ushort4 v)
        {
            uint2 h = 0;
            h.SetField(v, 0);
            return hash(h);
        }
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ushort8"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(ushort8 v)
        {
            uint4 h = 0;
            h.SetField(v, 0);
            return hash(h);
        }
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ushort16"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(ushort16 v)
        {
            ulong4 h = 0;
            h.SetField(v, 0);
            return hash(h);
        }

        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.short2"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(short2 v) => hash(asushort(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.short3"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(short3 v) => hash(asushort(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.short4"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(short4 v) => hash(asushort(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.short8"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(short8 v) => hash(asushort(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.short16"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(short16 v) => hash(asushort(v));

        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.int2"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(int2 v) => hash(asuint(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.int3"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(int3 v) => hash(asuint(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.int4"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(int4 v) => hash(asuint(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.int8"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(int8 v) => hash(asuint(v));

        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.uint2"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(uint2 v) => Unity.Mathematics.math.hash(v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.uint3"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(uint3 v) => Unity.Mathematics.math.hash(v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.uint4"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(uint4 v) => Unity.Mathematics.math.hash(v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.uint4"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(uint8 v)
        {
            ulong4 h = 0;
            h.SetField<ulong4, uint8>(v, 0);
            return hash(h);
        }

        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.long2"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(long2 v) => hash(asulong(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.long3"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(long3 v) => hash(asulong(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.long4"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(long4 v) => hash(asulong(v));

        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ulong2"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(ulong2 v) => hash(v.Reinterpret<ulong2, uint4>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ulong3"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(ulong3 v) => hash(v.xyzz);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ulong4"/> vector.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(ulong4 v)
        {
            uint8 __v = v.Reinterpret<ulong4, uint8>();
            uint8 lo = shuffle(__v, new uint8(0, 2, 4, 6,   0, 0, 0, 0));
            uint8 hi = shuffle(__v, new uint8(1, 3, 5, 7,   0, 0, 0, 0));

            return hash(lo.v4_0 ^ hi.v4_0);
        }

        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.bool2x2"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(bool2x2 v) => hash(new bool4(v.c0, v.c1));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.bool3x2"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(bool3x2 v) => hash(new bool8(v.c0, v.c1, new bool2()));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.bool4x2"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(bool4x2 v) => hash(new bool8(v.c0, v.c1));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.float2x2"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(float2x2 v) => hash(v.Reinterpret<float2x2, uint2x2>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.float3x2"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(float3x2 v) => hash(v.Reinterpret<float3x2, uint3x2>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.float4x2"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(float4x2 v) => hash(v.Reinterpret<float4x2, uint4x2>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.double2x2"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(double2x2 v) => hash(v.Reinterpret<double2x2, ulong2x2>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.double3x2"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(double3x2 v) => hash(v.Reinterpret<double3x2, ulong3x2>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.double4x2"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(double4x2 v) => hash(v.Reinterpret<double4x2, ulong4x2>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.sbyte2x2"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(sbyte2x2 v) => hash((byte2x2)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.sbyte3x2"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(sbyte3x2 v) => hash((byte3x2)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.sbyte4x2"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(sbyte4x2 v) => hash((byte4x2)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.byte2x2"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(byte2x2 v)
        {
            uint h = 0;
            h.SetField(v, 0);
            return h;
        }
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.byte3x2"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(byte3x2 v) => hash((uint3x2)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.byte4x2"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(byte4x2 v) => hash((byte4x2)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.short2x2"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(short2x2 v) => hash((uint2x2)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.short3x2"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(short3x2 v) => hash((uint3x2)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.short4x2"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(short4x2 v) => hash((uint4x2)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ushort2x2"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(ushort2x2 v) => hash((uint2x2)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ushort3x2"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(ushort3x2 v) => hash((uint3x2)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ushort4x2"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(ushort4x2 v) => hash((uint4x2)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.int2x2"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(int2x2 v) => hash((uint2x2)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.int3x2"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(int3x2 v) => hash((uint3x2)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.int4x2"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(int4x2 v) => hash((uint4x2)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.uint2x2"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(uint2x2 v) => Unity.Mathematics.math.hash(v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.uint3x2"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(uint3x2 v) => Unity.Mathematics.math.hash(v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.uint4x2"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(uint4x2 v) => Unity.Mathematics.math.hash(v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.long2x2"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(long2x2 v) => hash((ulong2x2)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.long3x2"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(long3x2 v) => hash((ulong3x2)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.long4x2"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(long4x2 v) => hash((ulong4x2)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ulong2x2"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(ulong2x2 v)
        {
            uint4 lo0 = shuffle(v.c0.Reinterpret<ulong2, uint4>(), new uint4(0, 2, 0, 0));
            uint4 hi0 = shuffle(v.c0.Reinterpret<ulong2, uint4>(), new uint4(1, 3, 0, 0));
            uint4 lo1 = shuffle(v.c1.Reinterpret<ulong2, uint4>(), new uint4(0, 2, 0, 0));
            uint4 hi1 = shuffle(v.c1.Reinterpret<ulong2, uint4>(), new uint4(1, 3, 0, 0));

            uint4 __c0 = lo0 ^ hi0;
            uint4 __c1 = lo1 ^ hi1;

            return hash(new uint4(__c0.xy, __c1.xy));
        }
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ulong3x2"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(ulong3x2 v) => hash(new ulong4x2(v.c0.xyzz, v.c1.xyzz));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ulong4x2"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(ulong4x2 v)
        {
            uint8 __c0 = v.c0.Reinterpret<ulong4, uint8>();
            uint8 lo0 = shuffle(__c0, new uint8(0, 2, 4, 6,   0, 0, 0, 0));
            uint8 hi0 = shuffle(__c0, new uint8(1, 3, 5, 7,   0, 0, 0, 0));
            uint8 __c1 = v.c1.Reinterpret<ulong4, uint8>();
            uint8 lo1 = shuffle(__c1, new uint8(0, 2, 4, 6,   0, 0, 0, 0));
            uint8 hi1 = shuffle(__c1, new uint8(1, 3, 5, 7,   0, 0, 0, 0));

            __c0 = lo0 ^ hi0;
            __c1 = lo1 ^ hi1;

            return hash(new uint4x2(__c0.v4_0, __c1.v4_0));
        }

        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.bool2x3"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(bool2x3 v) => hash(new bool8(v.c0, v.c1, v.c2, new bool2()));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.bool3x3"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(bool3x3 v) => hash(new bool16(v.c0, v.c1, v.c2, new bool3(), new bool4()));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.bool4x3"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(bool4x3 v) => hash(new bool16(v.c0, v.c1, v.c2, new bool4()));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.float2x3"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(float2x3 v) => hash(v.Reinterpret<float2x3, uint2x3>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.float3x3"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(float3x3 v) => hash(v.Reinterpret<float3x3, uint3x3>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.float4x3"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(float4x3 v) => hash(v.Reinterpret<float4x3, uint4x3>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.double2x3"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(double2x3 v) => hash(v.Reinterpret<double2x3, ulong2x3>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.double3x3"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(double3x3 v) => hash(v.Reinterpret<double3x3, ulong3x3>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.double4x3"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(double4x3 v) => hash(v.Reinterpret<double4x3, ulong4x3>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.sbyte2x3"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(sbyte2x3 v) => hash((byte2x3)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.sbyte3x3"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(sbyte3x3 v) => hash((byte3x3)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.sbyte4x3"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(sbyte4x3 v) => hash((byte4x3)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.byte2x3"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(byte2x3 v) => hash((uint2x3)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.byte3x3"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(byte3x3 v) => hash((uint3x3)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.byte4x3"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(byte4x3 v) => hash((uint4x3)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.short2x3"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(short2x3 v) => hash((ushort2x3)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.short3x3"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(short3x3 v) => hash((ushort3x3)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.short4x3"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(short4x3 v) => hash((ushort4x3)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ushort2x3"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(ushort2x3 v) => hash((uint2x3)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ushort3x3"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(ushort3x3 v) => hash((uint3x3)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ushort4x3"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(ushort4x3 v) => hash((uint4x3)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.int2x3"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(int2x3 v) => hash((uint2x3)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.int3x3"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(int3x3 v) => hash((uint3x3)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.int4x3"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(int4x3 v) => hash((uint4x3)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.uint2x3"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(uint2x3 v) => Unity.Mathematics.math.hash(v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.uint3x3"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(uint3x3 v) => Unity.Mathematics.math.hash(v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.uint4x3"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(uint4x3 v) => Unity.Mathematics.math.hash(v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.long2x3"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(long2x3 v) => hash((ulong2x3)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.long3x3"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(long3x3 v) => hash((ulong3x3)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.long4x3"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(long4x3 v) => hash((ulong4x3)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ulong2x3"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(ulong2x3 v)
        {
            uint4 lo0 = shuffle(v.c0.Reinterpret<ulong2, uint4>(), new uint4(0, 2, 0, 0));
            uint4 hi0 = shuffle(v.c0.Reinterpret<ulong2, uint4>(), new uint4(1, 3, 0, 0));
            uint4 lo1 = shuffle(v.c1.Reinterpret<ulong2, uint4>(), new uint4(0, 2, 0, 0));
            uint4 hi1 = shuffle(v.c1.Reinterpret<ulong2, uint4>(), new uint4(1, 3, 0, 0));
            uint4 lo2 = shuffle(v.c2.Reinterpret<ulong2, uint4>(), new uint4(0, 2, 0, 0));
            uint4 hi2 = shuffle(v.c2.Reinterpret<ulong2, uint4>(), new uint4(1, 3, 0, 0));

            uint4 __c0 = lo0 ^ hi0;
            uint4 __c1 = lo1 ^ hi1;
            uint4 __c2 = lo2 ^ hi2;

            return hash(new uint2x3(__c0.xy, __c1.xy, __c2.xy));
        }
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ulong3x3"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(ulong3x3 v) => hash(new ulong4x3(v.c0.xyzz, v.c1.xyzz, v.c2.xyzz));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ulong4x3"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(ulong4x3 v)
        {
            uint8 __c0 = v.c0.Reinterpret<ulong4, uint8>();
            uint8 lo0 = shuffle(__c0, new uint8(0, 2, 4, 6,   0, 0, 0, 0));
            uint8 hi0 = shuffle(__c0, new uint8(1, 3, 5, 7,   0, 0, 0, 0));
            uint8 __c1 = v.c1.Reinterpret<ulong4, uint8>();
            uint8 lo1 = shuffle(__c1, new uint8(0, 2, 4, 6,   0, 0, 0, 0));
            uint8 hi1 = shuffle(__c1, new uint8(1, 3, 5, 7,   0, 0, 0, 0));
            uint8 __c2 = v.c2.Reinterpret<ulong4, uint8>();
            uint8 lo2 = shuffle(__c2, new uint8(0, 2, 4, 6,   0, 0, 0, 0));
            uint8 hi2 = shuffle(__c2, new uint8(1, 3, 5, 7,   0, 0, 0, 0));

            __c0 = lo0 ^ hi0;
            __c1 = lo1 ^ hi1;
            __c2 = lo2 ^ hi2;

            return hash(new uint4x3(__c0.v4_0, __c1.v4_0, __c2.v4_0));
        }

        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.bool2x4"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(bool2x4 v) => hash(new bool8(v.c0, v.c1, v.c2, v.c3));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.bool3x4"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(bool3x4 v) => hash(new bool16(v.c0, v.c1, v.c2, v.c3, new bool4()));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.bool4x4"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(bool4x4 v) => hash(new bool16(v.c0, v.c1, v.c2, v.c3));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.float2x4"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(float2x4 v) => hash(v.Reinterpret<float2x4, uint2x4>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.float3x4"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(float3x4 v) => hash(v.Reinterpret<float3x4, uint3x4>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.float4x4"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(float4x4 v) => hash(v.Reinterpret<float4x4, uint4x4>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.double2x4"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(double2x4 v) => hash(v.Reinterpret<double2x4, ulong2x4>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.double3x4"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(double3x4 v) => hash(v.Reinterpret<double3x4, ulong3x4>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.double4x4"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(double4x4 v) => hash(v.Reinterpret<double4x4, ulong4x4>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.sbyte2x4"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(sbyte2x4 v) => hash((byte2x4)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.sbyte3x4"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(sbyte3x4 v) => hash((byte3x4)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.sbyte4x4"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(sbyte4x4 v) => hash((byte4x4)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.byte2x4"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(byte2x4 v) => hash((uint2x4)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.byte3x4"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(byte3x4 v) => hash((uint3x4)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.byte4x4"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(byte4x4 v) => hash((uint4x4)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.short2x4"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(short2x4 v) => hash((ushort2x4)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.short3x4"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(short3x4 v) => hash((ushort3x4)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.short4x4"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(short4x4 v) => hash((ushort4x4)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ushort2x4"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(ushort2x4 v) => hash((uint2x4)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ushort3x4"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(ushort3x4 v) => hash((uint3x4)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ushort4x4"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(ushort4x4 v) => hash((uint4x4)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.int2x4"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(int2x4 v) => hash((uint2x4)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.int3x4"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(int3x4 v) => hash((uint3x4)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.int4x4"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(int4x4 v) => hash((uint4x4)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.uint2x4"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(uint2x4 v) => Unity.Mathematics.math.hash(v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.uint3x4"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(uint3x4 v) => Unity.Mathematics.math.hash(v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.uint4x4"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(uint4x4 v) => Unity.Mathematics.math.hash(v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.long2x4"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(long2x4 v) => hash((ulong2x4)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.long3x4"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(long3x4 v) => hash((ulong3x4)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.long4x4"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(long4x4 v) => hash((ulong4x4)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ulong2x4"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(ulong2x4 v)
        {
            uint4 lo0 = shuffle(v.c0.Reinterpret<ulong2, uint4>(), new uint4(0, 2, 0, 0));
            uint4 hi0 = shuffle(v.c0.Reinterpret<ulong2, uint4>(), new uint4(1, 3, 0, 0));
            uint4 lo1 = shuffle(v.c1.Reinterpret<ulong2, uint4>(), new uint4(0, 2, 0, 0));
            uint4 hi1 = shuffle(v.c1.Reinterpret<ulong2, uint4>(), new uint4(1, 3, 0, 0));
            uint4 lo2 = shuffle(v.c2.Reinterpret<ulong2, uint4>(), new uint4(0, 2, 0, 0));
            uint4 hi2 = shuffle(v.c2.Reinterpret<ulong2, uint4>(), new uint4(1, 3, 0, 0));
            uint4 lo3 = shuffle(v.c3.Reinterpret<ulong2, uint4>(), new uint4(0, 2, 0, 0));
            uint4 hi3 = shuffle(v.c3.Reinterpret<ulong2, uint4>(), new uint4(1, 3, 0, 0));

            uint4 __c0 = lo0 ^ hi0;
            uint4 __c1 = lo1 ^ hi1;
            uint4 __c2 = lo2 ^ hi2;
            uint4 __c3 = lo3 ^ hi3;

            return hash(new uint2x4(__c0.xy, __c1.xy, __c2.xy, __c3.xy));
        }
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ulong3x4"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(ulong3x4 v) => hash(new ulong4x4(v.c0.xyzz, v.c1.xyzz, v.c2.xyzz, v.c3.xyzz));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ulong4x4"/> matrix.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(ulong4x4 v)
        {
            uint8 __c0 = v.c0.Reinterpret<ulong4, uint8>();
            uint8 lo0 = shuffle(__c0, new uint8(0, 2, 4, 6,   0, 0, 0, 0));
            uint8 hi0 = shuffle(__c0, new uint8(1, 3, 5, 7,   0, 0, 0, 0));
            uint8 __c1 = v.c1.Reinterpret<ulong4, uint8>();
            uint8 lo1 = shuffle(__c1, new uint8(0, 2, 4, 6,   0, 0, 0, 0));
            uint8 hi1 = shuffle(__c1, new uint8(1, 3, 5, 7,   0, 0, 0, 0));
            uint8 __c2 = v.c2.Reinterpret<ulong4, uint8>();
            uint8 lo2 = shuffle(__c2, new uint8(0, 2, 4, 6,   0, 0, 0, 0));
            uint8 hi2 = shuffle(__c2, new uint8(1, 3, 5, 7,   0, 0, 0, 0));
            uint8 __c3 = v.c3.Reinterpret<ulong4, uint8>();
            uint8 lo3 = shuffle(__c3, new uint8(0, 2, 4, 6,   0, 0, 0, 0));
            uint8 hi3 = shuffle(__c3, new uint8(1, 3, 5, 7,   0, 0, 0, 0));

            __c0 = lo0 ^ hi0;
            __c1 = lo1 ^ hi1;
            __c2 = lo2 ^ hi2;
            __c3 = lo3 ^ hi3;

            return hash(new uint4x4(__c0.v4_0, __c1.v4_0, __c2.v4_0, __c3.v4_0));
        }

        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.UInt128"/> value.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(UInt128 v) => hash(v.Reinterpret<UInt128, uint4>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.Int128"/> value.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(Int128 v) => hash(v.Reinterpret<Int128, uint4>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.quadruple"/> value.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(quadruple q) => hash(q.Reinterpret<quadruple, uint4>());


        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.quaternion"/> value.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(quaternion q) => hash(q.value);

        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.Plane"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(Plane p) => hash(p.NormalAndDistance);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.RigidTransform"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(RigidTransform t) => Unity.Mathematics.math.hash(t);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.MinMaxAABB"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(MinMaxAABB mm) => hash(new float3x2(mm.Min, mm.Max));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.AffineTransform"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(AffineTransform a) => hash((float3x4)a);


        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.bool2"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(bool2 v) => hashwide(touint(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.bool3"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(bool3 v) => hashwide(touint(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.bool4"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(bool4 v) => hashwide(touint(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.bool8"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(bool8 v)
        {
            return (uint)bitmask(v);
        }
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.bool16"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(bool16 v)
        {
            return (uint)bitmask(v);
        }
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.bool32"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(bool32 v)
        {
            return (uint)bitmask(v);
        }

        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.half"/> valuesWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(half v) => v.value;

        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.half2"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(half2 v) => hashwide(asushort(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.half3"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(half3 v) => hashwide(asushort(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.half4"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(half4 v) => hashwide(asushort(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.half8"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(half8 v) => hashwide(asushort(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.half16"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(half16 v) => hashwide(asushort(v));

        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.float2"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(float2 v) => hashwide(asuint(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.float3"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(float3 v) => hashwide(asuint(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.float4"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(float4 v) => hashwide(asuint(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.float8"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(float8 v) => hashwide(asuint(v));

        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.double2"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(double2 v) => hashwide(asulong(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.double3"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(double3 v) => hashwide(asulong(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.double4"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(double4 v) => hashwide(asulong(v));

        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.byte2"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(byte2 v) => hashwide((uint2)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.byte3"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(byte3 v) => hashwide((uint3)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.byte4"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(byte4 v) => hashwide((uint4)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.byte8"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(byte8 v) => hashwide(v.Reinterpret<byte8, ushort4>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.byte16"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(byte16 v)
        {
            uint4 h = 0;
            h.SetField(v, 0);
            return hashwide(h);
        }
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.byte32"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(byte32 v)
        {
            ulong4 h = 0;
            h.SetField(v, 0);
            return hashwide(h);
        }

        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.sbyte2"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(sbyte2 v) => hashwide(asbyte(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.sbyte3"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(sbyte3 v) => hashwide(asbyte(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.sbyte4"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(sbyte4 v) => hashwide(asbyte(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.sbyte8"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(sbyte8 v) => hashwide(asbyte(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.sbyte16"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(sbyte16 v) => hashwide(asbyte(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.sbyte32"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(sbyte32 v) => hashwide(asbyte(v));

        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ushort2"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(ushort2 v) => hashwide((uint2)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ushort3"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(ushort3 v) => hashwide((uint3)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ushort4"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(ushort4 v) => hashwide((uint4)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ushort8"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(ushort8 v)
        {
            uint4 h = 0;
            h.SetField(v, 0);
            return hashwide(h);
        }
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ushort16"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(ushort16 v)
        {
            ulong4 h = 0;
            h.SetField(v, 0);
            return hashwide(h);
        }

        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.short2"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(short2 v) => hashwide(asushort(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.short3"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(short3 v) => hashwide(asushort(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.short4"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(short4 v) => hashwide(asushort(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.short8"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(short8 v) => hashwide(asushort(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.short16"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(short16 v) => hashwide(asushort(v));

        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.int2"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(int2 v) => hashwide(asuint(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.int3"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(int3 v) => hashwide(asuint(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.int4"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(int4 v) => hashwide(asuint(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.int8"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(int8 v) => hashwide(asuint(v));

        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.uint2"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(uint2 v) => Unity.Mathematics.math.hashwide(v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.uint3"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(uint3 v) => Unity.Mathematics.math.hashwide(v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.uint4"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(uint4 v) => Unity.Mathematics.math.hashwide(v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.uint4"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(uint8 v)
        {
            ulong4 h = 0;
            h.SetField<ulong4, uint8>(v, 0);
            return hashwide(h);
        }

        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.long2"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(long2 v) => hashwide(asulong(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.long3"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(long3 v) => hashwide(asulong(v));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.long4"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(long4 v) => hashwide(asulong(v));

        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ulong2"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(ulong2 v)
        {
            uint4 lo = shuffle(v.Reinterpret<ulong2, uint4>(), new uint4(0, 2, 0, 0));
            uint4 hi = shuffle(v.Reinterpret<ulong2, uint4>(), new uint4(1, 3, 0, 0));

            uint4 __v = lo ^ hi;

            return hashwide(__v.xy);
        }
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ulong3"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(ulong3 v) => hashwide(v.xyzz).xyz;
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ulong4"/> vectorWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(ulong4 v)
        {
            uint8 __v = v.Reinterpret<ulong4, uint8>();
            uint8 lo = shuffle(__v, new uint8(0, 2, 4, 6,   0, 0, 0, 0));
            uint8 hi = shuffle(__v, new uint8(1, 3, 5, 7,   0, 0, 0, 0));

            return hashwide(lo.v4_0 ^ hi.v4_0);
        }

        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.bool2x2"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(bool2x2 v) => hashwide(new uint2x2(touint(v.c0), touint(v.c1)));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.bool3x2"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(bool3x2 v) => hashwide(new uint3x2(touint(v.c0), touint(v.c1)));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.bool4x2"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(bool4x2 v) => hashwide(new uint4x2(touint(v.c0), touint(v.c1)));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.float2x2"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(float2x2 v) => hashwide(v.Reinterpret<float2x2, uint2x2>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.float3x2"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(float3x2 v) => hashwide(v.Reinterpret<float3x2, uint3x2>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.float4x2"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(float4x2 v) => hashwide(v.Reinterpret<float4x2, uint4x2>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.double2x2"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(double2x2 v) => hashwide(v.Reinterpret<double2x2, ulong2x2>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.double3x2"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(double3x2 v) => hashwide(v.Reinterpret<double3x2, ulong3x2>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.double4x2"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(double4x2 v) => hashwide(v.Reinterpret<double4x2, ulong4x2>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.sbyte2x2"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(sbyte2x2 v) => hashwide((byte2x2)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.sbyte3x2"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(sbyte3x2 v) => hashwide((byte3x2)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.sbyte4x2"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(sbyte4x2 v) => hashwide((byte4x2)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.byte2x2"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(byte2x2 v) => hashwide((uint2x2)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.byte3x2"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(byte3x2 v) => hashwide((uint3x2)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.byte4x2"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(byte4x2 v) => hashwide((byte4x2)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.short2x2"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(short2x2 v) => hashwide((uint2x2)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.short3x2"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(short3x2 v) => hashwide((uint3x2)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.short4x2"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(short4x2 v) => hashwide((uint4x2)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ushort2x2"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(ushort2x2 v) => hashwide((uint2x2)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ushort3x2"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(ushort3x2 v) => hashwide((uint3x2)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ushort4x2"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(ushort4x2 v) => hashwide((uint4x2)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.int2x2"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(int2x2 v) => hashwide((uint2x2)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.int3x2"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(int3x2 v) => hashwide((uint3x2)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.int4x2"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(int4x2 v) => hashwide((uint4x2)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.uint2x2"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(uint2x2 v) => Unity.Mathematics.math.hashwide(v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.uint3x2"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(uint3x2 v) => Unity.Mathematics.math.hashwide(v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.uint4x2"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(uint4x2 v) => Unity.Mathematics.math.hashwide(v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.long2x2"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(long2x2 v) => hashwide((ulong2x2)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.long3x2"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(long3x2 v) => hashwide((ulong3x2)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.long4x2"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(long4x2 v) => hashwide((ulong4x2)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ulong2x2"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(ulong2x2 v)
        {
            uint4 lo0 = shuffle(v.c0.Reinterpret<ulong2, uint4>(), new uint4(0, 2, 0, 0));
            uint4 hi0 = shuffle(v.c0.Reinterpret<ulong2, uint4>(), new uint4(1, 3, 0, 0));
            uint4 lo1 = shuffle(v.c1.Reinterpret<ulong2, uint4>(), new uint4(0, 2, 0, 0));
            uint4 hi1 = shuffle(v.c1.Reinterpret<ulong2, uint4>(), new uint4(1, 3, 0, 0));

            uint4 __c0 = lo0 ^ hi0;
            uint4 __c1 = lo1 ^ hi1;

            return hashwide(new uint2x2(__c0.xy, __c1.xy));
        }
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ulong3x2"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(ulong3x2 v) => hashwide(new ulong4x2(v.c0.xyzz, v.c1.xyzz)).xyz;
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ulong4x2"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(ulong4x2 v)
        {
            uint8 __c0 = v.c0.Reinterpret<ulong4, uint8>();
            uint8 lo0 = shuffle(__c0, new uint8(0, 2, 4, 6,   0, 0, 0, 0));
            uint8 hi0 = shuffle(__c0, new uint8(1, 3, 5, 7,   0, 0, 0, 0));
            uint8 __c1 = v.c1.Reinterpret<ulong4, uint8>();
            uint8 lo1 = shuffle(__c1, new uint8(0, 2, 4, 6,   0, 0, 0, 0));
            uint8 hi1 = shuffle(__c1, new uint8(1, 3, 5, 7,   0, 0, 0, 0));

            __c0 = lo0 ^ hi0;
            __c1 = lo1 ^ hi1;

            return hashwide(new uint4x2(__c0.v4_0, __c1.v4_0));
        }

        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.bool2x3"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(bool2x3 v) => hashwide(new uint2x3(touint(v.c0), touint(v.c1), touint(v.c2)));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.bool3x3"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(bool3x3 v) => hashwide(new uint3x3(touint(v.c0), touint(v.c1), touint(v.c2)));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.bool4x3"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(bool4x3 v) => hashwide(new uint4x3(touint(v.c0), touint(v.c1), touint(v.c2)));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.float2x3"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(float2x3 v) => hashwide(v.Reinterpret<float2x3, uint2x3>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.float3x3"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(float3x3 v) => hashwide(v.Reinterpret<float3x3, uint3x3>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.float4x3"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(float4x3 v) => hashwide(v.Reinterpret<float4x3, uint4x3>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.double2x3"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(double2x3 v) => hashwide(v.Reinterpret<double2x3, ulong2x3>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.double3x3"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(double3x3 v) => hashwide(v.Reinterpret<double3x3, ulong3x3>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.double4x3"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(double4x3 v) => hashwide(v.Reinterpret<double4x3, ulong4x3>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.sbyte2x3"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(sbyte2x3 v) => hashwide((byte2x3)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.sbyte3x3"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(sbyte3x3 v) => hashwide((byte3x3)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.sbyte4x3"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(sbyte4x3 v) => hashwide((byte4x3)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.byte2x3"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(byte2x3 v) => hashwide((uint2x3)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.byte3x3"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(byte3x3 v) => hashwide((uint3x3)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.byte4x3"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(byte4x3 v) => hashwide((uint4x3)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.short2x3"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(short2x3 v) => hashwide((ushort2x3)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.short3x3"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(short3x3 v) => hashwide((ushort3x3)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.short4x3"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(short4x3 v) => hashwide((ushort4x3)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ushort2x3"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(ushort2x3 v) => hashwide((uint2x3)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ushort3x3"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(ushort3x3 v) => hashwide((uint3x3)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ushort4x3"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(ushort4x3 v) => hashwide((uint4x3)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.int2x3"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(int2x3 v) => hashwide((uint2x3)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.int3x3"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(int3x3 v) => hashwide((uint3x3)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.int4x3"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(int4x3 v) => hashwide((uint4x3)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.uint2x3"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(uint2x3 v) => Unity.Mathematics.math.hashwide(v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.uint3x3"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(uint3x3 v) => Unity.Mathematics.math.hashwide(v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.uint4x3"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(uint4x3 v) => Unity.Mathematics.math.hashwide(v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.long2x3"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(long2x3 v) => hashwide((ulong2x3)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.long3x3"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(long3x3 v) => hashwide((ulong3x3)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.long4x3"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(long4x3 v) => hashwide((ulong4x3)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ulong2x3"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(ulong2x3 v)
        {
            uint4 lo0 = shuffle(v.c0.Reinterpret<ulong2, uint4>(), new uint4(0, 2, 0, 0));
            uint4 hi0 = shuffle(v.c0.Reinterpret<ulong2, uint4>(), new uint4(1, 3, 0, 0));
            uint4 lo1 = shuffle(v.c1.Reinterpret<ulong2, uint4>(), new uint4(0, 2, 0, 0));
            uint4 hi1 = shuffle(v.c1.Reinterpret<ulong2, uint4>(), new uint4(1, 3, 0, 0));
            uint4 lo2 = shuffle(v.c2.Reinterpret<ulong2, uint4>(), new uint4(0, 2, 0, 0));
            uint4 hi2 = shuffle(v.c2.Reinterpret<ulong2, uint4>(), new uint4(1, 3, 0, 0));

            uint4 __c0 = lo0 ^ hi0;
            uint4 __c1 = lo1 ^ hi1;
            uint4 __c2 = lo2 ^ hi2;

            return hashwide(new uint2x3(__c0.xy, __c1.xy, __c2.xy));
        }
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ulong3x3"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(ulong3x3 v) => hashwide(new ulong4x3(v.c0.xyzz, v.c1.xyzz, v.c2.xyzz)).xyz;
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ulong4x3"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(ulong4x3 v)
        {
            uint8 __c0 = v.c0.Reinterpret<ulong4, uint8>();
            uint8 lo0 = shuffle(__c0, new uint8(0, 2, 4, 6,   0, 0, 0, 0));
            uint8 hi0 = shuffle(__c0, new uint8(1, 3, 5, 7,   0, 0, 0, 0));
            uint8 __c1 = v.c1.Reinterpret<ulong4, uint8>();
            uint8 lo1 = shuffle(__c1, new uint8(0, 2, 4, 6,   0, 0, 0, 0));
            uint8 hi1 = shuffle(__c1, new uint8(1, 3, 5, 7,   0, 0, 0, 0));
            uint8 __c2 = v.c2.Reinterpret<ulong4, uint8>();
            uint8 lo2 = shuffle(__c2, new uint8(0, 2, 4, 6,   0, 0, 0, 0));
            uint8 hi2 = shuffle(__c2, new uint8(1, 3, 5, 7,   0, 0, 0, 0));

            __c0 = lo0 ^ hi0;
            __c1 = lo1 ^ hi1;
            __c2 = lo2 ^ hi2;

            return hashwide(new uint4x3(__c0.v4_0, __c1.v4_0, __c2.v4_0));
        }

        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.bool2x4"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(bool2x4 v) => hashwide(new uint2x4(touint(v.c0), touint(v.c1), touint(v.c2), touint(v.c3)));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.bool3x4"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(bool3x4 v) => hashwide(new uint3x4(touint(v.c0), touint(v.c1), touint(v.c2), touint(v.c3)));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.bool4x4"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(bool4x4 v) => hashwide(new uint4x4(touint(v.c0), touint(v.c1), touint(v.c2), touint(v.c3)));
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.float2x4"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(float2x4 v) => hashwide(v.Reinterpret<float2x4, uint2x4>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.float3x4"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(float3x4 v) => hashwide(v.Reinterpret<float3x4, uint3x4>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.float4x4"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(float4x4 v) => hashwide(v.Reinterpret<float4x4, uint4x4>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.double2x4"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(double2x4 v) => hashwide(v.Reinterpret<double2x4, ulong2x4>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.double3x4"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(double3x4 v) => hashwide(v.Reinterpret<double3x4, ulong3x4>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.double4x4"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(double4x4 v) => hashwide(v.Reinterpret<double4x4, ulong4x4>());
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.sbyte2x4"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(sbyte2x4 v) => hashwide((byte2x4)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.sbyte3x4"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(sbyte3x4 v) => hashwide((byte3x4)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.sbyte4x4"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(sbyte4x4 v) => hashwide((byte4x4)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.byte2x4"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(byte2x4 v) => hashwide((uint2x4)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.byte3x4"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(byte3x4 v) => hashwide((uint3x4)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.byte4x4"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(byte4x4 v) => hashwide((uint4x4)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.short2x4"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(short2x4 v) => hashwide((ushort2x4)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.short3x4"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(short3x4 v) => hashwide((ushort3x4)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.short4x4"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(short4x4 v) => hashwide((ushort4x4)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ushort2x4"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(ushort2x4 v) => hashwide((uint2x4)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ushort3x4"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(ushort3x4 v) => hashwide((uint3x4)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ushort4x4"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(ushort4x4 v) => hashwide((uint4x4)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.int2x4"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(int2x4 v) => hashwide((uint2x4)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.int3x4"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(int3x4 v) => hashwide((uint3x4)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of an <see cref="MaxMath.int4x4"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(int4x4 v) => hashwide((uint4x4)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.uint2x4"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(uint2x4 v) => Unity.Mathematics.math.hashwide(v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.uint3x4"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(uint3x4 v) => Unity.Mathematics.math.hashwide(v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.uint4x4"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(uint4x4 v) => Unity.Mathematics.math.hashwide(v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.long2x4"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(long2x4 v) => hashwide((ulong2x4)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.long3x4"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(long3x4 v) => hashwide((ulong3x4)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.long4x4"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(long4x4 v) => hashwide((ulong4x4)v);
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ulong2x4"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(ulong2x4 v)
        {
            uint4 lo0 = shuffle(v.c0.Reinterpret<ulong2, uint4>(), new uint4(0, 2, 0, 0));
            uint4 hi0 = shuffle(v.c0.Reinterpret<ulong2, uint4>(), new uint4(1, 3, 0, 0));
            uint4 lo1 = shuffle(v.c1.Reinterpret<ulong2, uint4>(), new uint4(0, 2, 0, 0));
            uint4 hi1 = shuffle(v.c1.Reinterpret<ulong2, uint4>(), new uint4(1, 3, 0, 0));
            uint4 lo2 = shuffle(v.c2.Reinterpret<ulong2, uint4>(), new uint4(0, 2, 0, 0));
            uint4 hi2 = shuffle(v.c2.Reinterpret<ulong2, uint4>(), new uint4(1, 3, 0, 0));
            uint4 lo3 = shuffle(v.c3.Reinterpret<ulong2, uint4>(), new uint4(0, 2, 0, 0));
            uint4 hi3 = shuffle(v.c3.Reinterpret<ulong2, uint4>(), new uint4(1, 3, 0, 0));

            uint4 __c0 = lo0 ^ hi0;
            uint4 __c1 = lo1 ^ hi1;
            uint4 __c2 = lo2 ^ hi2;
            uint4 __c3 = lo3 ^ hi3;

            return hashwide(new uint2x4(__c0.xy, __c1.xy, __c2.xy, __c3.xy));
        }
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ulong3x4"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(ulong3x4 v) => hashwide(new ulong4x4(v.c0.xyzz, v.c1.xyzz, v.c2.xyzz, v.c3.xyzz)).xyz;
        
        /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.ulong4x4"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(ulong4x4 v)
        {
            uint8 __c0 = v.c0.Reinterpret<ulong4, uint8>();
            uint8 lo0 = shuffle(__c0, new uint8(0, 2, 4, 6,   0, 0, 0, 0));
            uint8 hi0 = shuffle(__c0, new uint8(1, 3, 5, 7,   0, 0, 0, 0));
            uint8 __c1 = v.c1.Reinterpret<ulong4, uint8>();
            uint8 lo1 = shuffle(__c1, new uint8(0, 2, 4, 6,   0, 0, 0, 0));
            uint8 hi1 = shuffle(__c1, new uint8(1, 3, 5, 7,   0, 0, 0, 0));
            uint8 __c2 = v.c2.Reinterpret<ulong4, uint8>();
            uint8 lo2 = shuffle(__c2, new uint8(0, 2, 4, 6,   0, 0, 0, 0));
            uint8 hi2 = shuffle(__c2, new uint8(1, 3, 5, 7,   0, 0, 0, 0));
            uint8 __c3 = v.c3.Reinterpret<ulong4, uint8>();
            uint8 lo3 = shuffle(__c3, new uint8(0, 2, 4, 6,   0, 0, 0, 0));
            uint8 hi3 = shuffle(__c3, new uint8(1, 3, 5, 7,   0, 0, 0, 0));

            __c0 = lo0 ^ hi0;
            __c1 = lo1 ^ hi1;
            __c2 = lo2 ^ hi2;
            __c3 = lo3 ^ hi3;

            return hashwide(new uint4x4(__c0.v4_0, __c1.v4_0, __c2.v4_0, __c3.v4_0));
        }

        
         /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.UInt128"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(UInt128 v) => hashwide(v.Reinterpret<UInt128, uint4>());
        
         /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.Int128"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(Int128 v) => hashwide(v.Reinterpret<Int128, uint4>());
        
         /// <summary>       Returns a <see cref="uint"/> hash code of a <see cref="MaxMath.quadruple"/> matrixWhen multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(quadruple q) => hashwide(q.Reinterpret<quadruple, uint4>());

        
        /// <summary>       Returns a <see cref="uint"/> vector hash code of a <see cref="MaxMath.quaternion"/> value. When multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(quaternion q) => hashwide(q.value);
        
        /// <summary>       Returns a <see cref="uint"/> vector hash code of a <see cref="MaxMath.RigidTransform"/> value. When multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(RigidTransform t) => Unity.Mathematics.math.hashwide(t);
        
        /// <summary>       Returns a <see cref="uint"/> vector hash code of a <see cref="MaxMath.Plane"/> value. When multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(Plane p) => hashwide(p.NormalAndDistance);
        
        /// <summary>       Returns a <see cref="uint"/> vector hash code of a <see cref="MaxMath.MinMaxAABB"/> value. When multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(MinMaxAABB mm) => hashwide(new float3x2(mm.Min, mm.Max));
        
        /// <summary>       Returns a <see cref="uint"/> vector hash code of a <see cref="MaxMath.AffineTransform"/> value. When multiple elements are to be hashed together, it can be more efficient to calculate and combine wide hashes that are only reduced to a narrow <see cref="uint"/> hash at the very end instead of at every step.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(AffineTransform a) => hashwide((float4x4)a);
    }
}
