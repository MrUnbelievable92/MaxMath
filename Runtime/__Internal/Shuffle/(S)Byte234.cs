using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe internal static partial class Shuffle
    {
		internal static partial class Bytes
		{
		    internal static partial class Get
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xxxx(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
					{
				        return Xse.shuffle_epi8(x, Xse.setzero_si128());
					}
				    else if (BurstArchitecture.IsSIMDSupported)
					{
				        v128 _xxyy = Xse.unpacklo_epi8(x, x);

				        return Xse.unpacklo_epi16(_xxyy, _xxyy);
					}
				    else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xxxy(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
					{
				        return Xse.shuffle_epi8(x, new v128(0, 0, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
				    else if (BurstArchitecture.IsSIMDSupported)
					{
				        v128 xxyy = Xse.unpacklo_epi8(x, x);

				        return Xse.unpacklo_epi16(xxyy, x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xxxz(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
					{
				        return Xse.shuffle_epi8(x, new v128(0, 0, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
				    else if (BurstArchitecture.IsSIMDSupported)
					{
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);
				        v128 xxxxzz = Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 2, 0, 0));

				        return Xse.bsrli_si128(xxxxzz, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xxxw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
					{
						return Xse.shuffle_epi8(x, new v128(0, 0, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
					{
				        v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
				        v128 xxxxww = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 3, 0, 0));

				        return Xse.bsrli_si128(xxxxww, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xxyx(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
					{
				        return Xse.shuffle_epi8(x, new v128(0, 0, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
				    else if (BurstArchitecture.IsSIMDSupported)
					{
				        v128 xx = Xse.unpacklo_epi8(x, x);

				        return Xse.unpacklo_epi8(x, xx);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xxyy(v128 x)
				{
					if (BurstArchitecture.IsSIMDSupported)
					{
						return Xse.unpacklo_epi8(x, x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xxyz(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
					{
				        return Xse.shuffle_epi8(x, new v128(0, 0, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
					{
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 x_x_y_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(2, 1, 0, 0));

						return Xse.packus_epi16(x_x_y_z, x_x_y_z);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xxyw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
					{
						return Xse.shuffle_epi8(x, new v128(0, 0, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
					{
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 x_x_y_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 1, 0, 0));

						return Xse.packus_epi16(x_x_y_w, x_x_y_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xxzx(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
					{
				        return Xse.shuffle_epi8(x, new v128(0, 0, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
					{
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 x_x_z_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 2, 0, 0));

						return Xse.packus_epi16(x_x_z_x, x_x_z_x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xxzy(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
					{
				        return Xse.shuffle_epi8(x, new v128(0, 0, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
				    else if (BurstArchitecture.IsSIMDSupported)
					{
				        v128 z = Xse.bsrli_si128(x, 2 * sizeof(byte));
				        v128 xz = Xse.unpacklo_epi8(x, z);

				        return Xse.unpacklo_epi8(xz, x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xxzz(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
					{
				        return Xse.shuffle_epi8(x, new v128(0, 0, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
				    else if (BurstArchitecture.IsSIMDSupported)
					{
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);

				        return Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 0, 2, 0));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xxzw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
					{
						return Xse.shuffle_epi8(x, new v128(0, 0, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
					{
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 x_x_z_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 2, 0, 0));

						return Xse.packus_epi16(x_x_z_w, x_x_z_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xxwx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
					{
						return Xse.shuffle_epi8(x, new v128(0, 0, 3, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
					{
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 x_x_w_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 3, 0, 0));

						return Xse.packus_epi16(x_x_w_x, x_x_w_x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xxwy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
					{
						return Xse.shuffle_epi8(x, new v128(0, 0, 3, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
					{
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 x_x_w_y = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(1, 3, 0, 0));

						return Xse.packus_epi16(x_x_w_y, x_x_w_y);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xxwz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
					{
						return Xse.shuffle_epi8(x, new v128(0, 0, 3, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
					{
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 x_x_w_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(2, 3, 0, 0));

						return Xse.packus_epi16(x_x_w_z, x_x_w_z);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xxww(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
					{
						return Xse.shuffle_epi8(x, new v128(0, 0, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
					{
				        v128 xxyyzzww = Xse.unpacklo_epi8(x, x);

				        return Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 0, 3, 0));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xyxx(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
					{
				        return Xse.shuffle_epi8(x, new v128(0, 1, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
				    else if (BurstArchitecture.IsSIMDSupported)
					{
				        v128 _xxyy = Xse.unpacklo_epi8(x, x);

				        return Xse.unpacklo_epi16(x, _xxyy);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xyxy(v128 x)
				{
					if (BurstArchitecture.IsSIMDSupported)
					{
						return Xse.shufflelo_epi16(x, Sse.SHUFFLE(0, 0, 0, 0));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xyxz(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
					{
				        return Xse.shuffle_epi8(x, new v128(0, 1, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
				    else if (BurstArchitecture.IsSIMDSupported)
					{
				        v128 z = Xse.bsrli_si128(x, 2 * sizeof(byte));
				        v128 xz = Xse.unpacklo_epi8(x, z);

				        return Xse.unpacklo_epi16(x, xz);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xyxw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
					{
						return Xse.shuffle_epi8(x, new v128(0, 1, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
					{
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 x_y_x_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 0, 1, 0));

						return Xse.packus_epi16(x_y_x_w, x_y_x_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xyyx(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(0, 1, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 y = Xse.bsrli_si128(x, sizeof(byte));
				        v128 yx = Xse.unpacklo_epi8(y, x);

				        return Xse.unpacklo_epi16(x, yx);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xyyy(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(0, 1, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
					else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
				        v128 xxyyyy = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 1, 1, 0));

				        return Xse.bsrli_si128(xxyyyy, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xyyz(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(0, 1, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 yz = Xse.bsrli_si128(x, sizeof(byte));

				        return Xse.unpacklo_epi8(x, yz);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xyyw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(0, 1, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
				        v128 xxyyww = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 3, 1, 0));

				        return Xse.bsrli_si128(xxyyww, sizeof(byte));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xyzx(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(0, 1, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 _xyz = Xse.bslli_si128(x, sizeof(byte));
				        v128 _xyzx = Xse.unpacklo_epi32(_xyz, x);

				        return Xse.bsrli_si128(_xyzx, sizeof(byte));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xyzy(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(0, 1, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 x_y_z_y = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(1, 2, 1, 0));

						return Xse.packus_epi16(x_y_z_y, x_y_z_y);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xyzz(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(0, 1, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 z = Xse.bsrli_si128(x, 2 * sizeof(byte));
				        v128 zz = Xse.unpacklo_epi8(z, z);

				        return Xse.unpacklo_epi16(x, zz);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xywx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(0, 1, 3, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 x_y_w_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 3, 1, 0));

						return Xse.packus_epi16(x_y_w_x, x_y_w_x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xywy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(0, 1, 3, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 x_y_w_y = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(1, 3, 1, 0));

						return Xse.packus_epi16(x_y_w_y, x_y_w_y);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xywz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(0, 1, 3, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 x_y_w_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(2, 3, 1, 0));

						return Xse.packus_epi16(x_y_w_z, x_y_w_z);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xyww(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(0, 1, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 x_y_w_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 3, 1, 0));

						return Xse.packus_epi16(x_y_w_w, x_y_w_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xzxx(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(0, 2, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 x_z_x_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 0, 2, 0));

						return Xse.packus_epi16(x_z_x_x, x_z_x_x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xzxy(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(0, 2, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 z = Xse.bsrli_si128(x, 2 * sizeof(byte));
				        v128 xz = Xse.unpacklo_epi8(x, z);

				        return Xse.unpacklo_epi16(xz, x);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xzxz(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(0, 2, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 z = Xse.bsrli_si128(x, 2 * sizeof(byte));
				        v128 xz = Xse.unpacklo_epi8(x, z);

				        return Xse.unpacklo_epi16(xz, xz);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xzxw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(0, 2, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 x_z_x_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 0, 2, 0));

						return Xse.packus_epi16(x_z_x_w, x_z_x_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xzyx(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(0, 2, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 z = Xse.bsrli_si128(x, 2 * sizeof(byte));
				        v128 zx = Xse.unpacklo_epi8(z, x);

				        return Xse.unpacklo_epi8(x, zx);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xzyy(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(0, 2, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 x_z_y_y = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(1, 1, 2, 0));

						return Xse.packus_epi16(x_z_y_y, x_z_y_y);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xzyz(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(0, 2, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 z = Xse.bsrli_si128(x, 2 * sizeof(byte));
				        v128 zz = Xse.unpacklo_epi8(z, z);

				        return Xse.unpacklo_epi8(x, zz);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xzyw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(0, 2, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 zw = Xse.bsrli_si128(x, 2 * sizeof(byte));

				        return Xse.unpacklo_epi8(x, zw);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xzzx(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(0, 2, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);
				        v128 xxzzxx = Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 0, 2, 0));

				        return Xse.bsrli_si128(xxzzxx, sizeof(byte));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xzzy(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(0, 2, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);
				        v128 xxzzyy = Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 1, 2, 0));

				        return Xse.bsrli_si128(xxzzyy, sizeof(byte));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xzzz(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(0, 2, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);
				        v128 xxzzzz = Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 2, 2, 0));

				        return Xse.bsrli_si128(xxzzzz, sizeof(byte));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xzzw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(0, 2, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);
				        v128 xxzzww = Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 3, 2, 0));

				        return Xse.bsrli_si128(xxzzww, sizeof(byte));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xzwx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(0, 2, 3, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 x_z_w_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 3, 2, 0));

						return Xse.packus_epi16(x_z_w_x, x_z_w_x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xzwy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(0, 2, 3, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 x_z_w_y = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(1, 3, 2, 0));

						return Xse.packus_epi16(x_z_w_y, x_z_w_y);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xzwz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(0, 2, 3, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 x_z_w_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(2, 3, 2, 0));

						return Xse.packus_epi16(x_z_w_z, x_z_w_z);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xzww(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(0, 2, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 x_z_w_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 3, 2, 0));

						return Xse.packus_epi16(x_z_w_w, x_z_w_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xwxx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(0, 3, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 x_w_x_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 0, 3, 0));

						return Xse.packus_epi16(x_w_x_x, x_w_x_x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xwxy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(0, 3, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 x_w_x_y = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(1, 0, 3, 0));

						return Xse.packus_epi16(x_w_x_y, x_w_x_y);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xwxz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(0, 3, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 x_w_x_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(2, 0, 3, 0));

						return Xse.packus_epi16(x_w_x_z, x_w_x_z);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xwxw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(0, 3, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 x_w_x_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 0, 3, 0));

						return Xse.packus_epi16(x_w_x_w, x_w_x_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xwyx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(0, 3, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 x_w_y_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 1, 3, 0));

						return Xse.packus_epi16(x_w_y_x, x_w_y_x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xwyy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(0, 3, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 x_w_y_y = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(1, 1, 3, 0));

						return Xse.packus_epi16(x_w_y_y, x_w_y_y);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xwyz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(0, 3, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 x_w_y_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(2, 1, 3, 0));

						return Xse.packus_epi16(x_w_y_z, x_w_y_z);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xwyw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(0, 3, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 x_w_y_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 1, 3, 0));

						return Xse.packus_epi16(x_w_y_w, x_w_y_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xwzx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(0, 3, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 x_w_z_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 2, 3, 0));

						return Xse.packus_epi16(x_w_z_x, x_w_z_x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xwzy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(0, 3, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 x_w_z_y = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(1, 2, 3, 0));

						return Xse.packus_epi16(x_w_z_y, x_w_z_y);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xwzz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(0, 3, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 x_w_z_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(2, 2, 3, 0));

						return Xse.packus_epi16(x_w_z_z, x_w_z_z);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xwzw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(0, 3, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 x_w_z_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 2, 3, 0));

						return Xse.packus_epi16(x_w_z_w, x_w_z_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xwwx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(0, 3, 3, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
				        v128 xxwwxx = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 0, 3, 0));

				        return Xse.bsrli_si128(xxwwxx, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xwwy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(0, 3, 3, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
				        v128 xxwwyy = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 1, 3, 0));

				        return Xse.bsrli_si128(xxwwyy, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xwwz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(0, 3, 3, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
				        v128 xxwwzz = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 2, 3, 0));

				        return Xse.bsrli_si128(xxwwzz, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xwww(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(0, 3, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
				        v128 xxwwww = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 3, 3, 0));

				        return Xse.bsrli_si128(xxwwww, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yxxx(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(1, 0, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);
				        v128 yyxxxx = Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 0, 0, 1));

				        return Xse.bsrli_si128(yyxxxx, sizeof(byte));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yxxy(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(1, 0, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 y = Xse.bsrli_si128(x, sizeof(byte));
				        v128 yx = Xse.unpacklo_epi8(y, x);

				        return Xse.unpacklo_epi16(yx, x);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yxxz(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(1, 0, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);
				        v128 yyxxzz = Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 2, 0, 1));

				        return Xse.bsrli_si128(yyxxzz, sizeof(byte));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yxxw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 0, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
				        v128 yyxxww = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 3, 0, 1));

				        return Xse.bsrli_si128(yyxxww, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yxyx(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(1, 0, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 y = Xse.bsrli_si128(x, sizeof(byte));
				        v128 yx = Xse.unpacklo_epi8(y, x);

				        return Xse.unpacklo_epi16(yx, yx);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yxyy(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(1, 0, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 y = Xse.bsrli_si128(x, sizeof(byte));
				        v128 yy = Xse.unpacklo_epi8(y, y);

				        return Xse.unpacklo_epi8(yy, x);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yxyz(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(1, 0, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 yz = Xse.bsrli_si128(x, sizeof(byte));
				        v128 yx = Xse.unpacklo_epi8(yz, x);

				        return Xse.unpacklo_epi16(yx, yz);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yxyw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 0, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 y_x_y_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 1, 0, 1));

						return Xse.packus_epi16(y_x_y_w, y_x_y_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yxzx(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(1, 0, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 yz = Xse.bsrli_si128(x, sizeof(byte));
				        v128 xx = Xse.unpacklo_epi8(x, x);

				        return Xse.unpacklo_epi8(yz, xx);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yxzy(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(1, 0, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 yz = Xse.bsrli_si128(x, sizeof(byte));

				        return Xse.unpacklo_epi8(yz, x);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yxzz(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(1, 0, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 y_x_z_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(2, 2, 0, 1));

						return Xse.packus_epi16(y_x_z_z, y_x_z_z);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yxzw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 0, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 y_x_z_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 2, 0, 1));

						return Xse.packus_epi16(y_x_z_w, y_x_z_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yxwx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 0, 3, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 y_x_w_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 3, 0, 1));

						return Xse.packus_epi16(y_x_w_x, y_x_w_x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yxwy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 0, 3, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 y_x_w_y = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(1, 3, 0, 1));

						return Xse.packus_epi16(y_x_w_y, y_x_w_y);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yxwz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 0, 3, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 y_x_w_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(2, 3, 0, 1));

						return Xse.packus_epi16(y_x_w_z, y_x_w_z);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yxww(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 0, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 y_x_w_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 3, 0, 1));

						return Xse.packus_epi16(y_x_w_w, y_x_w_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yyxx(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(1, 1, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyy = Xse.unpacklo_epi8(x, x);

				        return Xse.shufflelo_epi16(xxyy, Sse.SHUFFLE(0, 1, 0, 1));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yyxy(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(1, 1, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 y = Xse.bsrli_si128(x, sizeof(byte));
				        v128 yy = Xse.unpacklo_epi8(y, y);

				        return Xse.unpacklo_epi16(yy, x);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yyxz(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(1, 1, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 yz = Xse.bsrli_si128(x, sizeof(byte));
				        v128 yx = Xse.unpacklo_epi8(yz, x);

				        return Xse.unpacklo_epi8(yx, yz);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yyxw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 1, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 y_y_x_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 0, 1, 1));

						return Xse.packus_epi16(y_y_x_w, y_y_x_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yyyx(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(1, 1, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);
				        v128 yyyyxx = Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 0, 1, 1));

				        return Xse.bsrli_si128(yyyyxx, sizeof(byte));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yyyy(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(1, 1, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);

				        return Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(1, 1, 1, 1));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yyyz(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(1, 1, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);
				        v128 yyyyzz = Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 2, 1, 1));

				        return Xse.bsrli_si128(yyyyzz, sizeof(byte));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yyyw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
					{
						return Xse.shuffle_epi8(x, new v128(1, 1, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
					{
					    v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
					    v128 yyyyww = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 3, 1, 1));

					    return Xse.bsrli_si128(yyyyww, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yyzx(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(1, 1, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 y_y_z_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 2, 1, 1));

						return Xse.packus_epi16(y_y_z_x, y_y_z_x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yyzy(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(1, 1, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 yz = Xse.bsrli_si128(x, sizeof(byte));
				        v128 yy = Xse.unpacklo_epi8(yz, yz);

				        return Xse.unpacklo_epi8(yz, yy);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yyzz(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(1, 1, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);

				        return Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 0, 2, 1));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yyzw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 1, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 y_y_z_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 2, 1, 1));

						return Xse.packus_epi16(y_y_z_w, y_y_z_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yywx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 1, 3, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 y_y_w_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 3, 1, 1));

						return Xse.packus_epi16(y_y_w_x, y_y_w_x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yywy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 1, 3, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 y_y_w_y = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(1, 3, 1, 1));

						return Xse.packus_epi16(y_y_w_y, y_y_w_y);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yywz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 1, 3, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 y_y_w_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(2, 3, 1, 1));

						return Xse.packus_epi16(y_y_w_z, y_y_w_z);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yyww(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 1, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);

				        return Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 0, 3, 1));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yzxx(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(1, 2, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 yz = Xse.bsrli_si128(x, sizeof(byte));
				        v128 xx = Xse.unpacklo_epi8(x, x);

				        return Xse.unpacklo_epi16(yz, xx);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yzxy(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(1, 2, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 yz = Xse.bsrli_si128(x, sizeof(byte));

				        return Xse.unpacklo_epi16(yz, x);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yzxz(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(1, 2, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 y_z_x_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(2, 0, 2, 1));

						return Xse.packus_epi16(y_z_x_z, y_z_x_z);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yzxw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 2, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 y_z_x_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 0, 2, 1));

						return Xse.packus_epi16(y_z_x_w, y_z_x_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yzyx(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(1, 2, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 yz = Xse.bsrli_si128(x, sizeof(byte));
				        v128 yx = Xse.unpacklo_epi8(yz, x);

				        return Xse.unpacklo_epi16(yz, yx);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yzyy(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(1, 2, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 yz = Xse.bsrli_si128(x, sizeof(byte));
				        v128 yy = Xse.unpacklo_epi8(yz, yz);

				        return Xse.unpacklo_epi16(yz, yy);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yzyz(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(1, 2, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 yz = Xse.bsrli_si128(x, sizeof(byte));

				        return Xse.unpacklo_epi16(yz, yz);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yzyw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 2, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 y_z_y_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 1, 2, 1));

						return Xse.packus_epi16(y_z_y_w, y_z_y_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yzzx(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(1, 2, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);
				        v128 yyzzxx = Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 0, 2, 1));

				        return Xse.bsrli_si128(yyzzxx, sizeof(byte));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yzzy(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(1, 2, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);
				        v128 yyzzyy = Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 1, 2, 1));

				        return Xse.bsrli_si128(yyzzyy, sizeof(byte));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yzzz(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(1, 2, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);
				        v128 yyzzzz = Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 2, 2, 1));

				        return Xse.bsrli_si128(yyzzzz, sizeof(byte));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yzzw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 2, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 y_z_z_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 2, 2, 1));

						return Xse.packus_epi16(y_z_z_w, y_z_z_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yzwx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 2, 3, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						int yzwx = math.ror(Xse.cvtsi128_si32(x), 8);

						return Xse.cvtsi32_si128(yzwx);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yzwy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 2, 3, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 y_z_w_y = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(1, 3, 2, 1));

						return Xse.packus_epi16(y_z_w_y, y_z_w_y);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yzwz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 2, 3, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 y_z_w_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(2, 3, 2, 1));

						return Xse.packus_epi16(y_z_w_z, y_z_w_z);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yzww(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 2, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 y_z_w_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 3, 2, 1));

						return Xse.packus_epi16(y_z_w_w, y_z_w_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 ywxx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 3, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 y_w_x_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 0, 3, 1));

						return Xse.packus_epi16(y_w_x_x, y_w_x_x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 ywxy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 3, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 y_w_x_y = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(1, 0, 3, 1));

						return Xse.packus_epi16(y_w_x_y, y_w_x_y);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 ywxz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 3, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 y_w_x_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(2, 0, 3, 1));

						return Xse.packus_epi16(y_w_x_z, y_w_x_z);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 ywxw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 3, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 y_w_x_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 0, 3, 1));

						return Xse.packus_epi16(y_w_x_w, y_w_x_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 ywyx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 3, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 y_w_y_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 1, 3, 1));

						return Xse.packus_epi16(y_w_y_x, y_w_y_x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 ywyy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 3, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 y_w_y_y = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(1, 1, 3, 1));

						return Xse.packus_epi16(y_w_y_y, y_w_y_y);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 ywyz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 3, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 y_w_y_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(2, 1, 3, 1));

						return Xse.packus_epi16(y_w_y_z, y_w_y_z);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 ywyw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 3, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 y_w_y_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 1, 3, 1));

						return Xse.packus_epi16(y_w_y_w, y_w_y_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 ywzx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 3, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 y_w_z_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 2, 3, 1));

						return Xse.packus_epi16(y_w_z_x, y_w_z_x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 ywzy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 3, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 y_w_z_y = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(1, 2, 3, 1));

						return Xse.packus_epi16(y_w_z_y, y_w_z_y);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 ywzz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 3, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 y_w_z_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(2, 2, 3, 1));

						return Xse.packus_epi16(y_w_z_z, y_w_z_z);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 ywzw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 3, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 y_w_z_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 2, 3, 1));

						return Xse.packus_epi16(y_w_z_w, y_w_z_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 ywwx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 3, 3, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);
				        v128 yywwxx = Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 0, 3, 1));

				        return Xse.bsrli_si128(yywwxx, sizeof(byte));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 ywwy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 3, 3, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);
				        v128 yywwyy = Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 1, 3, 1));

				        return Xse.bsrli_si128(yywwyy, sizeof(byte));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 ywwz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 3, 3, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);
				        v128 yywwzz = Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 2, 3, 1));

				        return Xse.bsrli_si128(yywwzz, sizeof(byte));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 ywww(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 3, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);
				        v128 yywwww = Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 3, 3, 1));

				        return Xse.bsrli_si128(yywwww, sizeof(byte));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zxxx(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 0, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);
				        v128 zzxxxx = Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 0, 0, 2));

				        return Xse.bsrli_si128(zzxxxx, sizeof(byte));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zxxy(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 0, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 xxyyzz = Xse.unpacklo_epi8(x, x);
						v128 zzxxyy = Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 1, 0, 2));

				        return Xse.bsrli_si128(zzxxyy, sizeof(byte));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zxxz(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 0, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);
				        v128 zzxxzz = Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 2, 0, 2));

				        return Xse.bsrli_si128(zzxxzz, sizeof(byte));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zxxw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 0, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);
				        v128 zzxxww = Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 3, 0, 2));

				        return Xse.bsrli_si128(zzxxww, sizeof(byte));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zxyx(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 0, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_x_y_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 1, 0, 2));

						return Xse.packus_epi16(z_x_y_x, z_x_y_x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zxyy(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 0, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_x_y_y = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(1, 1, 0, 2));

						return Xse.packus_epi16(z_x_y_y, z_x_y_y);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zxyz(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 0, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_x_y_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(2, 1, 0, 2));

						return Xse.packus_epi16(z_x_y_z, z_x_y_z);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zxyw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 0, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_x_y_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 1, 0, 2));

						return Xse.packus_epi16(z_x_y_w, z_x_y_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zxzx(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 0, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_x_z_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 2, 0, 2));

						return Xse.packus_epi16(z_x_z_x, z_x_z_x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zxzy(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 0, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 z = Xse.bsrli_si128(x, 2 * sizeof(byte));
				        v128 zz = Xse.unpacklo_epi8(z, z);

				        return Xse.unpacklo_epi8(zz, x);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zxzz(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 0, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_x_z_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(2, 2, 0, 2));

						return Xse.packus_epi16(z_x_z_z, z_x_z_z);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zxzw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 0, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_x_z_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 2, 0, 2));

						return Xse.packus_epi16(z_x_z_w, z_x_z_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zxwx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 0, 3, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_x_w_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 3, 0, 2));

						return Xse.packus_epi16(z_x_w_x, z_x_w_x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zxwy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 0, 3, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_x_w_y = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(1, 3, 0, 2));

						return Xse.packus_epi16(z_x_w_y, z_x_w_y);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zxwz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 0, 3, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_x_w_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(2, 3, 0, 2));

						return Xse.packus_epi16(z_x_w_z, z_x_w_z);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zxww(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 0, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_x_w_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 3, 0, 2));

						return Xse.packus_epi16(z_x_w_w, z_x_w_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zyxx(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 1, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_y_x_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 0, 1, 2));

						return Xse.packus_epi16(z_y_x_x, z_y_x_x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zyxy(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 1, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_y_x_y = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(1, 0, 1, 2));

						return Xse.packus_epi16(z_y_x_y, z_y_x_y);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zyxz(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 1, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_y_x_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(2, 0, 1, 2));

						return Xse.packus_epi16(z_y_x_z, z_y_x_z);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zyxw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 1, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_y_x_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 0, 1, 2));

						return Xse.packus_epi16(z_y_x_w, z_y_x_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zyyx(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 1, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);
				        v128 zzyyxx = Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 0, 1, 2));

				        return Xse.bsrli_si128(zzyyxx, sizeof(byte));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zyyy(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 1, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);
				        v128 zzyyyy = Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 1, 1, 2));

				        return Xse.bsrli_si128(zzyyyy, sizeof(byte));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zyyz(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 1, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);
				        v128 zzyyzz = Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 2, 1, 2));

				        return Xse.bsrli_si128(zzyyzz, sizeof(byte));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zyyw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 1, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
				        v128 zzyyww = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 3, 1, 2));

				        return Xse.bsrli_si128(zzyyww, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zyzx(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 1, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_y_z_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 2, 1, 2));

						return Xse.packus_epi16(z_y_z_x, z_y_z_x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zyzy(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 1, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_y_z_y = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(1, 2, 1, 2));

						return Xse.packus_epi16(z_y_z_y, z_y_z_y);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zyzz(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 1, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_y_z_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(2, 2, 1, 2));

						return Xse.packus_epi16(z_y_z_z, z_y_z_z);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zyzw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 1, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_y_z_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 2, 1, 2));

						return Xse.packus_epi16(z_y_z_w, z_y_z_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zywx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 1, 3, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_y_w_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 3, 1, 2));

						return Xse.packus_epi16(z_y_w_x, z_y_w_x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zywy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 1, 3, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_y_w_y = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(1, 3, 1, 2));

						return Xse.packus_epi16(z_y_w_y, z_y_w_y);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zywz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 1, 3, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_y_w_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(2, 3, 1, 2));

						return Xse.packus_epi16(z_y_w_z, z_y_w_z);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zyww(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 1, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_y_w_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 3, 1, 2));

						return Xse.packus_epi16(z_y_w_w, z_y_w_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zzxx(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 2, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);

				        return Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 0, 0, 2));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zzxy(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 2, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 z = Xse.bsrli_si128(x, 2 * sizeof(byte));
				        v128 zz = Xse.unpacklo_epi8(z, z);

				        return Xse.unpacklo_epi16(zz, x);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zzxz(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 2, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_z_x_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(2, 0, 2, 2));

						return Xse.packus_epi16(z_z_x_z, z_z_x_z);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zzxw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 2, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_z_x_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 0, 2, 2));

						return Xse.packus_epi16(z_z_x_w, z_z_x_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zzyx(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 2, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_z_y_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 1, 2, 2));

						return Xse.packus_epi16(z_z_y_x, z_z_y_x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zzyy(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 2, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);

				        return Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 0, 1, 2));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zzyz(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 2, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_z_y_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(2, 1, 2, 2));

						return Xse.packus_epi16(z_z_y_z, z_z_y_z);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zzyw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 2, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_z_y_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 1, 2, 2));

						return Xse.packus_epi16(z_z_y_w, z_z_y_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zzzx(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 2, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);
				        v128 zzzzxx = Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 0, 2, 2));

				        return Xse.bsrli_si128(zzzzxx, sizeof(byte));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zzzy(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 2, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);
				        v128 zzzzyy = Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 1, 2, 2));

				        return Xse.bsrli_si128(zzzzyy, sizeof(byte));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zzzz(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 2, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);

				        return Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 0, 2, 2));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zzzw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 2, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
				        v128 zzzzww = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 3, 2, 2));

				        return Xse.bsrli_si128(zzzzww, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zzwx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 2, 3, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_z_w_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 3, 2, 2));

						return Xse.packus_epi16(z_z_w_x, z_z_w_x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zzwy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 2, 3, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_z_w_y = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(1, 3, 2, 2));

						return Xse.packus_epi16(z_z_w_y, z_z_w_y);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zzwz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 2, 3, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_z_w_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(2, 3, 2, 2));

						return Xse.packus_epi16(z_z_w_z, z_z_w_z);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zzww(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 2, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzzww = Xse.unpacklo_epi8(x, x);

				        return Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 0, 3, 2));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zwxx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 3, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_w_x_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 0, 3, 2));

						return Xse.packus_epi16(z_w_x_x, z_w_x_x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zwxy(v128 x)
				{
					if (BurstArchitecture.IsSIMDSupported)
				    {
						return Xse.shufflelo_epi16(x, Sse.SHUFFLE(3, 3, 0, 1));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 zw = Xse.bsrli_si128(x, 2 * sizeof(byte));

						return Xse.unpacklo_epi16(zw, x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zwxz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 3, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_w_x_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(2, 0, 3, 2));

						return Xse.packus_epi16(z_w_x_z, z_w_x_z);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zwxw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 3, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_w_x_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 0, 3, 2));

						return Xse.packus_epi16(z_w_x_w, z_w_x_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zwyx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 3, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_w_y_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 1, 3, 2));

						return Xse.packus_epi16(z_w_y_x, z_w_y_x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zwyy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 3, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_w_y_y = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(1, 1, 3, 2));

						return Xse.packus_epi16(z_w_y_y, z_w_y_y);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zwyz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 3, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_w_y_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(2, 1, 3, 2));

						return Xse.packus_epi16(z_w_y_z, z_w_y_z);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zwyw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 3, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_w_y_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 1, 3, 2));

						return Xse.packus_epi16(z_w_y_w, z_w_y_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zwzx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 3, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_w_z_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 2, 3, 2));

						return Xse.packus_epi16(z_w_z_x, z_w_z_x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zwzy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 3, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_w_z_y = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(1, 2, 3, 2));

						return Xse.packus_epi16(z_w_z_y, z_w_z_y);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zwzz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 3, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_w_z_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(2, 2, 3, 2));

						return Xse.packus_epi16(z_w_z_z, z_w_z_z);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zwzw(v128 x)
				{
					if (BurstArchitecture.IsSIMDSupported)
				    {
						return Xse.shufflelo_epi16(x, Sse.SHUFFLE(3, 3, 1, 1));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 zw = Xse.bsrli_si128(x, 2 * sizeof(byte));

						return Xse.unpacklo_epi16(zw, zw);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zwwx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 3, 3, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
				        v128 zzwwxx = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 0, 3, 2));

				        return Xse.bsrli_si128(zzwwxx, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zwwy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 3, 3, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
				        v128 zzwwyy = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 1, 3, 2));

				        return Xse.bsrli_si128(zzwwyy, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zwwz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 3, 3, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
				        v128 zzwwzz = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 2, 3, 2));

				        return Xse.bsrli_si128(zzwwzz, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zwww(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 3, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
				        v128 zzwwww = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 3, 3, 2));

				        return Xse.bsrli_si128(zzwwww, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wxxx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 0, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
				        v128 wwxxxx = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 0, 0, 3));

				        return Xse.bsrli_si128(wwxxxx, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wxxy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 0, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
				        v128 wwxxyy = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 1, 0, 3));

				        return Xse.bsrli_si128(wwxxyy, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wxxz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 0, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
				        v128 wwxxzz = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 2, 0, 3));

				        return Xse.bsrli_si128(wwxxzz, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wxxw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 0, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
				        v128 wwxxww = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 3, 0, 3));

				        return Xse.bsrli_si128(wwxxww, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wxyx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 0, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_x_y_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 1, 0, 3));

						return Xse.packus_epi16(w_x_y_x, w_x_y_x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wxyy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 0, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_x_y_y = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(1, 1, 0, 3));

						return Xse.packus_epi16(w_x_y_y, w_x_y_y);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wxyz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 0, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						int wxyz = math.rol(Xse.cvtsi128_si32(x), 8);

						return Xse.cvtsi32_si128(wxyz);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wxyw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 0, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_x_y_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 1, 0, 3));

						return Xse.packus_epi16(w_x_y_w, w_x_y_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wxzx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 0, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_x_z_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 2, 0, 3));

						return Xse.packus_epi16(w_x_z_x, w_x_z_x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wxzy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 0, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_x_z_y = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(1, 2, 0, 3));

						return Xse.packus_epi16(w_x_z_y, w_x_z_y);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wxzz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 0, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_x_z_t = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(2, 2, 0, 3));

						return Xse.packus_epi16(w_x_z_t, w_x_z_t);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wxzw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 0, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_x_z_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 2, 0, 3));

						return Xse.packus_epi16(w_x_z_w, w_x_z_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wxwx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 0, 3, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_x_w_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 3, 0, 3));

						return Xse.packus_epi16(w_x_w_x, w_x_w_x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wxwy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 0, 3, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_x_w_y = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(1, 3, 0, 3));

						return Xse.packus_epi16(w_x_w_y, w_x_w_y);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wxwz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 0, 3, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_x_w_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(2, 3, 0, 3));

						return Xse.packus_epi16(w_x_w_z, w_x_w_z);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wxww(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 0, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_x_w_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 3, 0, 3));

						return Xse.packus_epi16(w_x_w_w, w_x_w_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wyxx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 1, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_y_x_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 0, 1, 3));

						return Xse.packus_epi16(w_y_x_x, w_y_x_x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wyxy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 1, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_y_x_y = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(1, 0, 1, 3));

						return Xse.packus_epi16(w_y_x_y, w_y_x_y);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wyxz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 1, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_y_x_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(2, 0, 1, 3));

						return Xse.packus_epi16(w_y_x_z, w_y_x_z);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wyxw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 1, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_y_x_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 0, 1, 3));

						return Xse.packus_epi16(w_y_x_w, w_y_x_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wyyx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 1, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
				        v128 wwyyxx = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 0, 1, 3));

				        return Xse.bsrli_si128(wwyyxx, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wyyy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 1, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
				        v128 wwyyyy = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 1, 1, 3));

				        return Xse.bsrli_si128(wwyyyy, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wyyz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 1, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
				        v128 wwyyzz = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 2, 1, 3));

				        return Xse.bsrli_si128(wwyyzz, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wyyw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 1, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);
				        v128 wwyyww = Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 3, 1, 3));

				        return Xse.bsrli_si128(wwyyww, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wyzx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 1, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_y_z_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 2, 1, 3));

						return Xse.packus_epi16(w_y_z_x, w_y_z_x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wyzy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 1, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_y_z_y = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(1, 2, 1, 3));

						return Xse.packus_epi16(w_y_z_y, w_y_z_y);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wyzz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 1, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_y_z_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(2, 2, 1, 3));

						return Xse.packus_epi16(w_y_z_z, w_y_z_z);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wyzw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 1, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_y_z_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 2, 1, 3));

						return Xse.packus_epi16(w_y_z_w, w_y_z_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wywx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 1, 3, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_y_w_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 3, 1, 3));

						return Xse.packus_epi16(w_y_w_x, w_y_w_x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wywy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 1, 3, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_y_w_y = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(1, 3, 1, 3));

						return Xse.packus_epi16(w_y_w_y, w_y_w_y);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wywz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 1, 3, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_y_w_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(2, 3, 1, 3));

						return Xse.packus_epi16(w_y_w_z, w_y_w_z);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wyww(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 1, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_y_w_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 3, 1, 3));

						return Xse.packus_epi16(w_y_w_w, w_y_w_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wzxx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 2, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_z_x_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 0, 2, 3));

						return Xse.packus_epi16(w_z_x_x, w_z_x_x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wzxy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 2, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_z_x_y = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(1, 0, 2, 3));

						return Xse.packus_epi16(w_z_x_y, w_z_x_y);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wzxz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 2, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_z_x_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(2, 0, 2, 3));

						return Xse.packus_epi16(w_z_x_z, w_z_x_z);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wzxw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 2, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_z_x_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 0, 2, 3));

						return Xse.packus_epi16(w_z_x_w, w_z_x_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wzyx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 2, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						int wzyx = maxmath.reversebytes(Xse.cvtsi128_si32(x));

						return Xse.cvtsi32_si128(wzyx);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wzyy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 2, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_z_y_y = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(1, 1, 2, 3));

						return Xse.packus_epi16(w_z_y_y, w_z_y_y);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wzyz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 2, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_z_y_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(2, 1, 2, 3));

						return Xse.packus_epi16(w_z_y_z, w_z_y_z);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wzyw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 2, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_z_y_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 1, 2, 3));

						return Xse.packus_epi16(w_z_y_w, w_z_y_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wzzx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 2, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
						v128 wwzzxx = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 0, 2, 3));

						return Xse.bsrli_si128(wwzzxx, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wzzy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 2, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
						v128 wwzzyy = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 1, 2, 3));

						return Xse.bsrli_si128(wwzzyy, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wzzz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 2, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
						v128 wwzzzz = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 2, 2, 3));

						return Xse.bsrli_si128(wwzzzz, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wzzw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 2, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
						v128 wwzzww = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 3, 2, 3));

						return Xse.bsrli_si128(wwzzww, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wzwx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 2, 3, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_z_w_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 3, 2, 3));

						return Xse.packus_epi16(w_z_w_x, w_z_w_x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wzwy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 2, 3, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_z_w_y = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(1, 3, 2, 3));

						return Xse.packus_epi16(w_z_w_y, w_z_w_y);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wzwz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 2, 3, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_z_w_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(2, 3, 2, 3));

						return Xse.packus_epi16(w_z_w_z, w_z_w_z);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wzww(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 2, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_z_w_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 3, 2, 3));

						return Xse.packus_epi16(w_z_w_w, w_z_w_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wwxx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 3, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 xxyyzzww = Xse.unpacklo_epi8(x, x);

						return Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 0, 0, 3));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wwxy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 3, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
						v128 ww = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 0, 0, 3));

						return Xse.unpacklo_epi16(ww, x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wwxz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 3, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_w_x_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(2, 0, 3, 3));

						return Xse.packus_epi16(w_w_x_z, w_w_x_z);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wwxw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 3, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_w_x_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 0, 3, 3));

						return Xse.packus_epi16(w_w_x_w, w_w_x_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wwyx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 3, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_w_y_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 1, 3, 3));

						return Xse.packus_epi16(w_w_y_x, w_w_y_x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wwyy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 3, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 xxyyzzww = Xse.unpacklo_epi8(x, x);

						return Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 0, 1, 3));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wwyz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 3, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_w_y_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(2, 1, 3, 3));

						return Xse.packus_epi16(w_w_y_z, w_w_y_z);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wwyw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 3, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_w_y_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 1, 3, 3));

						return Xse.packus_epi16(w_w_y_w, w_w_y_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wwzx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 3, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_w_z_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 2, 3, 3));

						return Xse.packus_epi16(w_w_z_x, w_w_z_x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wwzy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 3, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_w_z_y = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(1, 2, 3, 3));

						return Xse.packus_epi16(w_w_z_y, w_w_z_y);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wwzz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 3, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 xxyyzzww = Xse.unpacklo_epi8(x, x);

						return Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 0, 2, 3));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wwzw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 3, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_w_z_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(3, 2, 3, 3));

						return Xse.packus_epi16(w_w_z_w, w_w_z_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wwwx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 3, 3, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
						v128 wwwwxx = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 0, 3, 3));

						return Xse.bsrli_si128(wwwwxx, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wwwy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 3, 3, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
						v128 wwwwyy = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 1, 3, 3));

						return Xse.bsrli_si128(wwwwyy, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wwwz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 3, 3, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
						v128 wwwwzz = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 2, 3, 3));

						return Xse.bsrli_si128(wwwwzz, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wwww(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 3, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 xxyyzzww = Xse.unpacklo_epi8(x, x);

						return Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 0, 3, 3));
					}
					else throw new IllegalInstructionException();
				}


				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xxx(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, Xse.setzero_si128());
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyy = Xse.unpacklo_epi8(x, x);

				        return Xse.unpacklo_epi16(xxyy, xxyy);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xxy(v128 x)
				{
				    if (BurstArchitecture.IsSIMDSupported)
				    {
				        return Xse.unpacklo_epi8(x, x);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xxz(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(0, 0, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);

				        return Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 0, 2, 0));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xxw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(0, 0, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 xxyyzzww = Xse.unpacklo_epi8(x, x);

						return Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 0, 3, 0));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xyx(v128 x)
				{
				    if (BurstArchitecture.IsSIMDSupported)
				    {
				        return Xse.shufflelo_epi16(x, Sse.SHUFFLE(0, 0, 0, 0));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xyy(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(0, 1, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyy = Xse.unpacklo_epi8(x, x);

				        return Xse.bsrli_si128(xxyy, sizeof(byte));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xyz(v128 x)
				{
					if (BurstArchitecture.IsSIMDSupported)
				    {
						return (v128)x;
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xyw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(0, 1, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 w = Xse.bsrli_si128(x, 3 * sizeof(byte));

				        return Xse.unpacklo_epi16(x, w);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xzx(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(0, 2, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 z = Xse.bsrli_si128(x, 2 * sizeof(byte));
				        v128 xz = Xse.unpacklo_epi8(x, z);

				        return Xse.unpacklo_epi16(xz, xz);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xzy(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(0, 2, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 x_z_y = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 1, 2, 0));

						return Xse.packus_epi16(x_z_y, x_z_y);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xzz(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(0, 2, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);
				        v128 xxzz = Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 0, 2, 0));

				        return Xse.bsrli_si128(xxzz, sizeof(byte));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xzw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(0, 2, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 x_z_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 3, 2, 0));

						return Xse.packus_epi16(x_z_w, x_z_w);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xwx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(0, 3, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 w = Xse.bsrli_si128(x, 3 * sizeof(byte));
				        v128 xx = Xse.unpacklo_epi8(x, x);

				        return Xse.unpacklo_epi8(xx, w);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xwy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(0, 3, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 w = Xse.bsrli_si128(x, 3 * sizeof(byte));

				        return Xse.unpacklo_epi8(x, w);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xwz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(0, 3, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 x_w_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 2, 3, 0));

						return Xse.packus_epi16(x_w_z, x_w_z);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xww(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(0, 3, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
						v128 xxww = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 0, 3, 0));

						return Xse.bsrli_si128(xxww, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yxx(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(1, 0, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 y = Xse.bsrli_si128(x, sizeof(byte));
				        v128 yx = Xse.unpacklo_epi8(y, x);

				        return Xse.unpacklo_epi16(yx, x);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yxy(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(1, 0, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xyxy = Xse.shufflelo_epi16(x, Sse.SHUFFLE(0, 0, 0, 0));

				        return Xse.bsrli_si128(xyxy, sizeof(byte));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yxz(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(1, 0, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 y_x_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 2, 0, 1));

						return Xse.packus_epi16(y_x_z, y_x_z);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yxw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 0, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 y_x_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 3, 0, 1));

						return Xse.packus_epi16(y_x_w, y_x_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yyx(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(1, 1, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyy = Xse.unpacklo_epi8(x, x);

				        return Xse.shufflelo_epi16(xxyy, Sse.SHUFFLE(0, 0, 0, 1));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yyy(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(1, 1, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyy = Xse.unpacklo_epi8(x, x);

				        return Xse.shufflelo_epi16(xxyy, Sse.SHUFFLE(1, 1, 1, 1));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yyz(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(1, 1, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 xxyyzzww = Xse.unpacklo_epi8(x, x);

						return Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 0, 2, 1));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yyw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 1, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 xxyyzzww = Xse.unpacklo_epi8(x, x);

						return Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 0, 3, 1));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yzx(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(1, 2, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 yz = Xse.bsrli_si128(x, sizeof(byte));

				        return Xse.unpacklo_epi16(yz, x);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yzy(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(1, 2, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 yz = Xse.bsrli_si128(x, sizeof(byte));

				        return Xse.unpacklo_epi16(yz, yz);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yzz(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(1, 2, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);

				        return Xse.bsrli_si128(xxyyzz, 3 * sizeof(byte));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yzw(v128 x)
				{
					if (BurstArchitecture.IsSIMDSupported)
				    {
						return Xse.bsrli_si128(x, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 ywx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 3, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 y_w_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 0, 3, 1));

						return Xse.packus_epi16(y_w_x, y_w_x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 ywy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 3, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 y_w_y = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 1, 3, 1));

						return Xse.packus_epi16(y_w_y, y_w_y);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 ywz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 3, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 yz = Xse.bsrli_si128(x, sizeof(byte));
						v128 w = Xse.bsrli_si128(x, 3 * sizeof(byte));

						return Xse.unpacklo_epi8(yz, w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yww(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 3, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
						v128 yyww = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 0, 3, 1));

						return Xse.bsrli_si128(yyww, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zxx(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 0, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);
				        v128 zzxx = Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 0, 0, 2));

				        return Xse.bsrli_si128(zzxx, sizeof(byte));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zxy(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 0, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_x_y = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 1, 0, 2));

						return Xse.packus_epi16(z_x_y, z_x_y);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zxz(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 0, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_x_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 2, 0, 2));

						return Xse.packus_epi16(z_x_z, z_x_z);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zxw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 0, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 zw = Xse.bsrli_si128(x, 2 * sizeof(byte));

						return Xse.unpacklo_epi8(zw, x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zyx(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 1, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_y_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 0, 1, 2));

						return Xse.packus_epi16(z_y_x, z_y_x);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zyy(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 1, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);
				        v128 zzyy = Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 0, 1, 2));

				        return Xse.bsrli_si128(zzyy, sizeof(byte));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zyz(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 1, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 z_y_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 2, 1, 2));

						return Xse.packus_epi16(z_y_z, z_y_z);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zyw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 1, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 y = Xse.bsrli_si128(x, sizeof(byte));
						v128 zw = Xse.bsrli_si128(x, 2 * sizeof(byte));

						return Xse.unpacklo_epi8(zw, y);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zzx(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 2, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);

				        return Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 0, 0, 2));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zzy(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 2, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);

				        return Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 0, 1, 2));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zzz(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 2, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 xxyyzz = Xse.unpacklo_epi8(x, x);

				        return Xse.shufflelo_epi16(xxyyzz, Sse.SHUFFLE(0, 0, 2, 2));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zzw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 2, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 zw = Xse.bsrli_si128(x, 2 * sizeof(byte));

						return Xse.unpacklo_epi8(zw, zw);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zwx(v128 x)
				{
					if (BurstArchitecture.IsSIMDSupported)
				    {
						return Xse.shufflelo_epi16(x, Sse.SHUFFLE(3, 3, 0, 1));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 zw = Xse.bsrli_si128(x, 2 * sizeof(byte));

						return Xse.unpacklo_epi16(zw, x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zwy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 3, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 y = Xse.bsrli_si128(x, sizeof(byte));
						v128 zw = Xse.bsrli_si128(x, 2 * sizeof(byte));

						return Xse.unpacklo_epi16(zw, y);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zwz(v128 x)
				{
					if (BurstArchitecture.IsSIMDSupported)
				    {
						return Xse.shufflelo_epi16(x, Sse.SHUFFLE(3, 3, 1, 1));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 zw = Xse.bsrli_si128(x, 2 * sizeof(byte));

						return Xse.unpacklo_epi16(zw, zw);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zww(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(2, 3, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
						v128 zzww = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 0, 3, 2));

						return Xse.bsrli_si128(zzww, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wxx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 0, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
						v128 wwxx = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 0, 0, 3));

						return Xse.bsrli_si128(wwxx, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wxy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 0, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						int wxyz = math.rol(Xse.cvtsi128_si32(x), 8);

						return Xse.cvtsi32_si128(wxyz);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wxz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 0, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_x_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 2, 0, 3));

						return Xse.packus_epi16(w_x_z, w_x_z);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wxw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 0, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 w = Xse.bsrli_si128(x, 3 * sizeof(byte));
						v128 wx = Xse.unpacklo_epi8(w, x);

						return Xse.unpacklo_epi16(wx, wx);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wyx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 1, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_y_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 0, 1, 3));

						return Xse.packus_epi16(w_y_x, w_y_x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wyy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 1, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
						v128 wwyy = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 0, 1, 3));

						return Xse.bsrli_si128(wwyy, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wyz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 1, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_y_z = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 2, 1, 3));

						return Xse.packus_epi16(w_y_z, w_y_z);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wyw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 1, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_y_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 3, 1, 3));

						return Xse.packus_epi16(w_y_w, w_y_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wzx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 2, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_z_x = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 0, 2, 3));

						return Xse.packus_epi16(w_z_x, w_z_x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wzy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 2, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_z_y = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 1, 2, 3));

						return Xse.packus_epi16(w_z_y, w_z_y);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wzz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 2, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
						v128 wwzz = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 0, 2, 3));

						return Xse.bsrli_si128(wwzz, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wzw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 2, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 cast = Xse.unpacklo_epi8(x, Xse.setzero_si128());
						v128 w_z_w = Xse.shufflelo_epi16(cast, Sse.SHUFFLE(0, 3, 2, 3));

						return Xse.packus_epi16(w_z_w, w_z_w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wwx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 3, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 xxyyzzww = Xse.unpacklo_epi8(x, x);

						return Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 0, 0, 3));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wwy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 3, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 xxyyzzww = Xse.unpacklo_epi8(x, x);

						return Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 0, 1, 3));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wwz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 3, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 xxyyzzww = Xse.unpacklo_epi8(x, x);

						return Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 0, 2, 3));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 www(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 3, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 xxyyzzww = Xse.unpacklo_epi8(x, x);

						return Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(3, 3, 3, 3));
					}
					else throw new IllegalInstructionException();
				}


				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xx(v128 x)
				{
				    if (BurstArchitecture.IsSIMDSupported)
				    {
				        return Xse.unpacklo_epi8(x, x);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xy(v128 x)
				{
				    if (BurstArchitecture.IsSIMDSupported)
				    {
				        return (v128)x;
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xz(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(0, 2, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 z = Xse.bsrli_si128(x, 2 * sizeof(byte));

				        return Xse.unpacklo_epi8(x, z);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 xw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(0, 3, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 w = Xse.bsrli_si128(x, 3 * sizeof(byte));

						return Xse.unpacklo_epi8(x, w);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yx(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(1, 0, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 y = Xse.bsrli_si128(x, sizeof(byte));

				        return Xse.unpacklo_epi8(y, x);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yy(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(1, 1, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 y = Xse.bsrli_si128(x, sizeof(byte));

				        return Xse.unpacklo_epi8(y, y);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yz(v128 x)
				{
				    if (BurstArchitecture.IsSIMDSupported)
				    {
				        return Xse.bsrli_si128(x, sizeof(byte));
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 yw(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(1, 3, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
						v128 yyww = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 0, 3, 1));

						return Xse.bsrli_si128(yyww, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zx(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 0, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 z = Xse.bsrli_si128(x, 2 * sizeof(byte));

				        return Xse.unpacklo_epi8(z, x);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zy(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 1, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 y = Xse.bsrli_si128(x, sizeof(byte));
				        v128 z = Xse.bsrli_si128(x, 2 * sizeof(byte));

				        return Xse.unpacklo_epi8(z, y);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zz(v128 x)
				{
				    if (BurstArchitecture.IsTableLookupSupported)
				    {
				        return Xse.shuffle_epi8(x, new v128(2, 2, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
				    }
				    else if (BurstArchitecture.IsSIMDSupported)
				    {
				        v128 z = Xse.bsrli_si128(x, 2 * sizeof(byte));

				        return Xse.unpacklo_epi8(z, z);
				    }
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 zw(v128 x)
				{
					if (BurstArchitecture.IsSIMDSupported)
				    {
						return Xse.bsrli_si128(x, 2 * sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wx(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 0, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 w = Xse.bsrli_si128(x, 3 * sizeof(byte));

						return Xse.unpacklo_epi8(w, x);
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wy(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 1, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
						v128 wwyy = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 0, 1, 3));

						return Xse.bsrli_si128(wwyy, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 wz(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 2, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 xxyyzzww = Xse.unpacklo_epi8(x, x);
						v128 wwzz = Xse.shufflelo_epi16(xxyyzzww, Sse.SHUFFLE(0, 0, 2, 3));

						return Xse.bsrli_si128(wwzz, sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 ww(v128 x)
				{
					if (BurstArchitecture.IsTableLookupSupported)
				    {
						return Xse.shuffle_epi8(x, new v128(3, 3, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
					}
					else if (BurstArchitecture.IsSIMDSupported)
				    {
						v128 xxyyzzww = Xse.unpacklo_epi8(x, x);

						return Xse.bsrli_si128(xxyyzzww, 6 * sizeof(byte));
					}
					else throw new IllegalInstructionException();
				}
			}
		}
	}
}
