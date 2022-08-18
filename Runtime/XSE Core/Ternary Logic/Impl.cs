using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 ternarylogic_si128(v128 a, v128 b, v128 c, TernaryOperation code)
        {
			return ternarylogic_si128(a, b, c, (byte)code);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 ternarylogic_si128(v128 a, v128 b, v128 c, byte code)
        {
            if (Sse2.IsSse2Supported)
            {
				switch (code)
				{
					case 0x00:
					{
						v128 c0 = Sse2.setzero_si128();
						return c0;
					}
					case 0x01:
					{
						v128 t0 = Sse2.or_si128(b, c);
						v128 t1 = Sse2.or_si128(a, t0);
						v128 c1 = setall_si128();
						v128 t2 = Sse2.xor_si128(t1, c1);
						return t2;
					}
					case 0x02:
					{
						v128 t0 = Sse2.or_si128(b, a);
						v128 t1 = Sse2.andnot_si128(t0, c);
						return t1;
					}
					case 0x03:
					{
						v128 t0 = Sse2.or_si128(b, a);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(t0, c1);
						return t1;
					}
					case 0x04:
					{
						v128 t0 = Sse2.or_si128(a, c);
						v128 t1 = Sse2.andnot_si128(t0, b);
						return t1;
					}
					case 0x05:
					{
						v128 t0 = Sse2.or_si128(c, a);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(t0, c1);
						return t1;
					}
					case 0x06:
					{
						v128 t0 = Sse2.xor_si128(b, c);
						v128 t1 = Sse2.andnot_si128(a, t0);
						return t1;
					}
					case 0x07:
					{
						v128 t0 = Sse2.and_si128(b, c);
						v128 t1 = Sse2.or_si128(a, t0);
						v128 c1 = setall_si128();
						v128 t2 = Sse2.xor_si128(t1, c1);
						return t2;
					}
					case 0x08:
					{
						v128 t0 = Sse2.andnot_si128(a, b);
						v128 t1 = Sse2.and_si128(t0, c);
						return t1;
					}
					case 0x09:
					{
						v128 t0 = Sse2.xor_si128(b, c);
						v128 t1 = Sse2.or_si128(a, t0);
						v128 c1 = setall_si128();
						v128 t2 = Sse2.xor_si128(t1, c1);
						return t2;
					}
					case 0x0A:
					{
						v128 t0 = Sse2.andnot_si128(a, c);
						return t0;
					}
					case 0x0B:
					{
						v128 c1 = setall_si128();
						v128 t0 = Sse2.xor_si128(b, c1);
						v128 t1 = Sse2.or_si128(t0, c);
						v128 t2 = Sse2.andnot_si128(a, t1);
						return t2;
					}
					case 0x0C:
					{
						v128 t0 = Sse2.andnot_si128(a, b);
						return t0;
					}
					case 0x0D:
					{
						v128 c1 = setall_si128();
						v128 t0 = Sse2.xor_si128(c, c1);
						v128 t1 = Sse2.or_si128(b, t0);
						v128 t2 = Sse2.andnot_si128(a, t1);
						return t2;
					}
					case 0x0E:
					{
						v128 t0 = Sse2.or_si128(b, c);
						v128 t1 = Sse2.andnot_si128(a, t0);
						return t1;
					}
					case 0x0F:
					{
						v128 c1 = setall_si128();
						v128 t0 = Sse2.xor_si128(a, c1);
						return t0;
					}
					case 0x10:
					{
						v128 t0 = Sse2.or_si128(b, c);
						v128 t1 = Sse2.andnot_si128(t0, a);
						return t1;
					}
					case 0x11:
					{
						v128 t0 = Sse2.or_si128(c, b);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(t0, c1);
						return t1;
					}
					case 0x12:
					{
						v128 t0 = Sse2.xor_si128(a, c);
						v128 t1 = Sse2.andnot_si128(b, t0);
						return t1;
					}
					case 0x13:
					{
						v128 t0 = Sse2.and_si128(a, c);
						v128 t1 = Sse2.or_si128(b, t0);
						v128 c1 = setall_si128();
						v128 t2 = Sse2.xor_si128(t1, c1);
						return t2;
					}
					case 0x14:
					{
						v128 t0 = Sse2.xor_si128(a, b);
						v128 t1 = Sse2.andnot_si128(c, t0);
						return t1;
					}
					case 0x15:
					{
						v128 t0 = Sse2.and_si128(b, a);
						v128 t1 = Sse2.or_si128(c, t0);
						v128 c1 = setall_si128();
						v128 t2 = Sse2.xor_si128(t1, c1);
						return t2;
					}
					case 0x16:
					{
						v128 t0 = Sse2.or_si128(b, c);
						v128 t1 = Sse2.andnot_si128(t0, a);
						v128 t2 = Sse2.xor_si128(b, c);
						v128 t3 = Sse2.andnot_si128(a, t2);
						v128 t4 = Sse2.or_si128(t1, t3);
						return t4;
					}
					case 0x17:
					{
						v128 t0 = Sse2.or_si128(b, c);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(t0, c1);
						v128 t2 = Sse2.xor_si128(b, c);
						v128 t3 = Sse2.andnot_si128(a, t2);
						v128 t4 = Sse2.or_si128(t1, t3);
						return t4;
					}
					case 0x18:
					{
						v128 t0 = Sse2.xor_si128(a, b);
						v128 t1 = Sse2.xor_si128(a, c);
						v128 t2 = Sse2.and_si128(t0, t1);
						return t2;
					}
					case 0x19:
					{
						v128 t0 = Sse2.and_si128(a, b);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(c, c1);
						v128 t2 = Sse2.xor_si128(b, t1);
						v128 t3 = Sse2.andnot_si128(t0, t2);
						return t3;
					}
					case 0x1A:
					{
						v128 t0 = Sse2.and_si128(a, b);
						v128 t1 = Sse2.xor_si128(a, c);
						v128 t2 = Sse2.andnot_si128(t0, t1);
						return t2;
					}
					case 0x1B:
					{
						v128 t0 = Sse2.andnot_si128(a, c);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(b, c1);
						v128 t2 = Sse2.andnot_si128(c, t1);
						v128 t3 = Sse2.or_si128(t0, t2);
						return t3;
					}
					case 0x1C:
					{
						v128 t0 = Sse2.and_si128(a, c);
						v128 t1 = Sse2.xor_si128(a, b);
						v128 t2 = Sse2.andnot_si128(t0, t1);
						return t2;
					}
					case 0x1D:
					{
						v128 t0 = Sse2.andnot_si128(a, b);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(c, c1);
						v128 t2 = Sse2.andnot_si128(b, t1);
						v128 t3 = Sse2.or_si128(t0, t2);
						return t3;
					}
					case 0x1E:
					{
						v128 t0 = Sse2.or_si128(b, c);
						v128 t1 = Sse2.xor_si128(a, t0);
						return t1;
					}
					case 0x1F:
					{
						v128 t0 = Sse2.or_si128(b, c);
						v128 t1 = Sse2.and_si128(a, t0);
						v128 c1 = setall_si128();
						v128 t2 = Sse2.xor_si128(t1, c1);
						return t2;
					}
					case 0x20:
					{
						v128 t0 = Sse2.andnot_si128(b, a);
						v128 t1 = Sse2.and_si128(t0, c);
						return t1;
					}
					case 0x21:
					{
						v128 t0 = Sse2.xor_si128(a, c);
						v128 t1 = Sse2.or_si128(b, t0);
						v128 c1 = setall_si128();
						v128 t2 = Sse2.xor_si128(t1, c1);
						return t2;
					}
					case 0x22:
					{
						v128 t0 = Sse2.andnot_si128(b, c);
						return t0;
					}
					case 0x23:
					{
						v128 c1 = setall_si128();
						v128 t0 = Sse2.xor_si128(a, c1);
						v128 t1 = Sse2.or_si128(t0, c);
						v128 t2 = Sse2.andnot_si128(b, t1);
						return t2;
					}
					case 0x24:
					{
						v128 t0 = Sse2.xor_si128(a, b);
						v128 t1 = Sse2.xor_si128(b, c);
						v128 t2 = Sse2.and_si128(t0, t1);
						return t2;
					}
					case 0x25:
					{
						v128 t0 = Sse2.and_si128(a, b);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(c, c1);
						v128 t2 = Sse2.xor_si128(a, t1);
						v128 t3 = Sse2.andnot_si128(t0, t2);
						return t3;
					}
					case 0x26:
					{
						v128 t0 = Sse2.and_si128(a, b);
						v128 t1 = Sse2.xor_si128(b, c);
						v128 t2 = Sse2.andnot_si128(t0, t1);
						return t2;
					}
					case 0x27:
					{
						v128 t0 = Sse2.andnot_si128(b, c);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(a, c1);
						v128 t2 = Sse2.andnot_si128(c, t1);
						v128 t3 = Sse2.or_si128(t0, t2);
						return t3;
					}
					case 0x28:
					{
						v128 t0 = Sse2.xor_si128(b, a);
						v128 t1 = Sse2.and_si128(c, t0);
						return t1;
					}
					case 0x29:
					{
						v128 t0 = Sse2.xor_si128(b, a);
						v128 t1 = Sse2.and_si128(c, t0);
						v128 t2 = Sse2.or_si128(b, a);
						v128 c1 = setall_si128();
						v128 t3 = Sse2.xor_si128(t2, c1);
						v128 t4 = Sse2.andnot_si128(c, t3);
						v128 t5 = Sse2.or_si128(t1, t4);
						return t5;
					}
					case 0x2A:
					{
						v128 t0 = Sse2.and_si128(b, a);
						v128 t1 = Sse2.andnot_si128(t0, c);
						return t1;
					}
					case 0x2B:
					{
						v128 t0 = Sse2.and_si128(b, a);
						v128 t1 = Sse2.andnot_si128(t0, c);
						v128 t2 = Sse2.or_si128(b, a);
						v128 c1 = setall_si128();
						v128 t3 = Sse2.xor_si128(t2, c1);
						v128 t4 = Sse2.andnot_si128(c, t3);
						v128 t5 = Sse2.or_si128(t1, t4);
						return t5;
					}
					case 0x2C:
					{
						v128 t0 = Sse2.or_si128(b, c);
						v128 t1 = Sse2.xor_si128(a, b);
						v128 t2 = Sse2.and_si128(t0, t1);
						return t2;
					}
					case 0x2D:
					{
						v128 c1 = setall_si128();
						v128 t0 = Sse2.xor_si128(c, c1);
						v128 t1 = Sse2.or_si128(b, t0);
						v128 t2 = Sse2.xor_si128(a, t1);
						return t2;
					}
					case 0x2E:
					{
						v128 t0 = Sse2.or_si128(b, c);
						v128 t1 = Sse2.and_si128(a, b);
						v128 t2 = Sse2.xor_si128(t0, t1);
						return t2;
					}
					case 0x2F:
					{
						v128 t0 = Sse2.andnot_si128(b, c);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(a, c1);
						v128 t2 = Sse2.or_si128(t0, t1);
						return t2;
					}
					case 0x30:
					{
						v128 t0 = Sse2.andnot_si128(b, a);
						return t0;
					}
					case 0x31:
					{
						v128 c1 = setall_si128();
						v128 t0 = Sse2.xor_si128(c, c1);
						v128 t1 = Sse2.or_si128(a, t0);
						v128 t2 = Sse2.andnot_si128(b, t1);
						return t2;
					}
					case 0x32:
					{
						v128 t0 = Sse2.or_si128(a, c);
						v128 t1 = Sse2.andnot_si128(b, t0);
						return t1;
					}
					case 0x33:
					{
						v128 c1 = setall_si128();
						v128 t0 = Sse2.xor_si128(b, c1);
						return t0;
					}
					case 0x34:
					{
						v128 t0 = Sse2.and_si128(b, c);
						v128 t1 = Sse2.xor_si128(a, b);
						v128 t2 = Sse2.andnot_si128(t0, t1);
						return t2;
					}
					case 0x35:
					{
						v128 t0 = Sse2.andnot_si128(b, a);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(c, c1);
						v128 t2 = Sse2.andnot_si128(a, t1);
						v128 t3 = Sse2.or_si128(t0, t2);
						return t3;
					}
					case 0x36:
					{
						v128 t0 = Sse2.or_si128(a, c);
						v128 t1 = Sse2.xor_si128(b, t0);
						return t1;
					}
					case 0x37:
					{
						v128 t0 = Sse2.or_si128(a, c);
						v128 t1 = Sse2.and_si128(b, t0);
						v128 c1 = setall_si128();
						v128 t2 = Sse2.xor_si128(t1, c1);
						return t2;
					}
					case 0x38:
					{
						v128 t0 = Sse2.or_si128(a, c);
						v128 t1 = Sse2.xor_si128(a, b);
						v128 t2 = Sse2.and_si128(t0, t1);
						return t2;
					}
					case 0x39:
					{
						v128 c1 = setall_si128();
						v128 t0 = Sse2.xor_si128(c, c1);
						v128 t1 = Sse2.or_si128(a, t0);
						v128 t2 = Sse2.xor_si128(b, t1);
						return t2;
					}
					case 0x3A:
					{
						v128 t0 = Sse2.andnot_si128(b, a);
						v128 t1 = Sse2.andnot_si128(a, c);
						v128 t2 = Sse2.or_si128(t0, t1);
						return t2;
					}
					case 0x3B:
					{
						v128 t0 = Sse2.andnot_si128(a, c);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(b, c1);
						v128 t2 = Sse2.or_si128(t0, t1);
						return t2;
					}
					case 0x3C:
					{
						v128 t0 = Sse2.xor_si128(b, a);
						return t0;
					}
					case 0x3D:
					{
						v128 t0 = Sse2.xor_si128(a, b);
						v128 t1 = Sse2.or_si128(a, c);
						v128 c1 = setall_si128();
						v128 t2 = Sse2.xor_si128(t1, c1);
						v128 t3 = Sse2.or_si128(t0, t2);
						return t3;
					}
					case 0x3E:
					{
						v128 t0 = Sse2.andnot_si128(a, c);
						v128 t1 = Sse2.xor_si128(a, b);
						v128 t2 = Sse2.or_si128(t0, t1);
						return t2;
					}
					case 0x3F:
					{
						v128 t0 = Sse2.and_si128(b, a);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(t0, c1);
						return t1;
					}
					case 0x40:
					{
						v128 t0 = Sse2.andnot_si128(c, a);
						v128 t1 = Sse2.and_si128(t0, b);
						return t1;
					}
					case 0x41:
					{
						v128 t0 = Sse2.xor_si128(b, a);
						v128 t1 = Sse2.or_si128(c, t0);
						v128 c1 = setall_si128();
						v128 t2 = Sse2.xor_si128(t1, c1);
						return t2;
					}
					case 0x42:
					{
						v128 t0 = Sse2.xor_si128(a, c);
						v128 t1 = Sse2.xor_si128(b, c);
						v128 t2 = Sse2.and_si128(t0, t1);
						return t2;
					}
					case 0x43:
					{
						v128 t0 = Sse2.and_si128(a, c);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(b, c1);
						v128 t2 = Sse2.xor_si128(a, t1);
						v128 t3 = Sse2.andnot_si128(t0, t2);
						return t3;
					}
					case 0x44:
					{
						v128 t0 = Sse2.andnot_si128(c, b);
						return t0;
					}
					case 0x45:
					{
						v128 c1 = setall_si128();
						v128 t0 = Sse2.xor_si128(a, c1);
						v128 t1 = Sse2.or_si128(t0, b);
						v128 t2 = Sse2.andnot_si128(c, t1);
						return t2;
					}
					case 0x46:
					{
						v128 t0 = Sse2.and_si128(a, c);
						v128 t1 = Sse2.xor_si128(b, c);
						v128 t2 = Sse2.andnot_si128(t0, t1);
						return t2;
					}
					case 0x47:
					{
						v128 t0 = Sse2.andnot_si128(c, b);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(a, c1);
						v128 t2 = Sse2.andnot_si128(b, t1);
						v128 t3 = Sse2.or_si128(t0, t2);
						return t3;
					}
					case 0x48:
					{
						v128 t0 = Sse2.xor_si128(a, c);
						v128 t1 = Sse2.and_si128(b, t0);
						return t1;
					}
					case 0x49:
					{
						v128 t0 = Sse2.xor_si128(a, c);
						v128 t1 = Sse2.and_si128(b, t0);
						v128 t2 = Sse2.or_si128(a, c);
						v128 c1 = setall_si128();
						v128 t3 = Sse2.xor_si128(t2, c1);
						v128 t4 = Sse2.andnot_si128(b, t3);
						v128 t5 = Sse2.or_si128(t1, t4);
						return t5;
					}
					case 0x4A:
					{
						v128 t0 = Sse2.or_si128(b, c);
						v128 t1 = Sse2.xor_si128(a, c);
						v128 t2 = Sse2.and_si128(t0, t1);
						return t2;
					}
					case 0x4B:
					{
						v128 c1 = setall_si128();
						v128 t0 = Sse2.xor_si128(b, c1);
						v128 t1 = Sse2.or_si128(t0, c);
						v128 t2 = Sse2.xor_si128(a, t1);
						return t2;
					}
					case 0x4C:
					{
						v128 t0 = Sse2.and_si128(a, c);
						v128 t1 = Sse2.andnot_si128(t0, b);
						return t1;
					}
					case 0x4D:
					{
						v128 t0 = Sse2.and_si128(a, c);
						v128 t1 = Sse2.andnot_si128(t0, b);
						v128 t2 = Sse2.or_si128(a, c);
						v128 c1 = setall_si128();
						v128 t3 = Sse2.xor_si128(t2, c1);
						v128 t4 = Sse2.andnot_si128(b, t3);
						v128 t5 = Sse2.or_si128(t1, t4);
						return t5;
					}
					case 0x4E:
					{
						v128 t0 = Sse2.andnot_si128(a, c);
						v128 t1 = Sse2.andnot_si128(c, b);
						v128 t2 = Sse2.or_si128(t0, t1);
						return t2;
					}
					case 0x4F:
					{
						v128 t0 = Sse2.andnot_si128(c, b);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(a, c1);
						v128 t2 = Sse2.or_si128(t0, t1);
						return t2;
					}
					case 0x50:
					{
						v128 t0 = Sse2.andnot_si128(c, a);
						return t0;
					}
					case 0x51:
					{
						v128 c1 = setall_si128();
						v128 t0 = Sse2.xor_si128(b, c1);
						v128 t1 = Sse2.or_si128(a, t0);
						v128 t2 = Sse2.andnot_si128(c, t1);
						return t2;
					}
					case 0x52:
					{
						v128 t0 = Sse2.and_si128(b, c);
						v128 t1 = Sse2.xor_si128(a, c);
						v128 t2 = Sse2.andnot_si128(t0, t1);
						return t2;
					}
					case 0x53:
					{
						v128 t0 = Sse2.andnot_si128(c, a);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(b, c1);
						v128 t2 = Sse2.andnot_si128(a, t1);
						v128 t3 = Sse2.or_si128(t0, t2);
						return t3;
					}
					case 0x54:
					{
						v128 t0 = Sse2.or_si128(a, b);
						v128 t1 = Sse2.andnot_si128(c, t0);
						return t1;
					}
					case 0x55:
					{
						v128 c1 = setall_si128();
						v128 t0 = Sse2.xor_si128(c, c1);
						return t0;
					}
					case 0x56:
					{
						v128 t0 = Sse2.or_si128(b, a);
						v128 t1 = Sse2.xor_si128(c, t0);
						return t1;
					}
					case 0x57:
					{
						v128 t0 = Sse2.or_si128(b, a);
						v128 t1 = Sse2.and_si128(c, t0);
						v128 c1 = setall_si128();
						v128 t2 = Sse2.xor_si128(t1, c1);
						return t2;
					}
					case 0x58:
					{
						v128 t0 = Sse2.or_si128(a, b);
						v128 t1 = Sse2.xor_si128(a, c);
						v128 t2 = Sse2.and_si128(t0, t1);
						return t2;
					}
					case 0x59:
					{
						v128 c1 = setall_si128();
						v128 t0 = Sse2.xor_si128(b, c1);
						v128 t1 = Sse2.or_si128(a, t0);
						v128 t2 = Sse2.xor_si128(c, t1);
						return t2;
					}
					case 0x5A:
					{
						v128 t0 = Sse2.xor_si128(c, a);
						return t0;
					}
					case 0x5B:
					{
						v128 t0 = Sse2.xor_si128(a, c);
						v128 t1 = Sse2.or_si128(a, b);
						v128 c1 = setall_si128();
						v128 t2 = Sse2.xor_si128(t1, c1);
						v128 t3 = Sse2.or_si128(t0, t2);
						return t3;
					}
					case 0x5C:
					{
						v128 t0 = Sse2.andnot_si128(c, a);
						v128 t1 = Sse2.andnot_si128(a, b);
						v128 t2 = Sse2.or_si128(t0, t1);
						return t2;
					}
					case 0x5D:
					{
						v128 t0 = Sse2.andnot_si128(a, b);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(c, c1);
						v128 t2 = Sse2.or_si128(t0, t1);
						return t2;
					}
					case 0x5E:
					{
						v128 t0 = Sse2.andnot_si128(c, b);
						v128 t1 = Sse2.xor_si128(a, c);
						v128 t2 = Sse2.or_si128(t0, t1);
						return t2;
					}
					case 0x5F:
					{
						v128 t0 = Sse2.and_si128(c, a);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(t0, c1);
						return t1;
					}
					case 0x60:
					{
						v128 t0 = Sse2.xor_si128(b, c);
						v128 t1 = Sse2.and_si128(a, t0);
						return t1;
					}
					case 0x61:
					{
						v128 t0 = Sse2.xor_si128(b, c);
						v128 t1 = Sse2.and_si128(a, t0);
						v128 t2 = Sse2.or_si128(b, c);
						v128 c1 = setall_si128();
						v128 t3 = Sse2.xor_si128(t2, c1);
						v128 t4 = Sse2.andnot_si128(a, t3);
						v128 t5 = Sse2.or_si128(t1, t4);
						return t5;
					}
					case 0x62:
					{
						v128 t0 = Sse2.or_si128(a, c);
						v128 t1 = Sse2.xor_si128(b, c);
						v128 t2 = Sse2.and_si128(t0, t1);
						return t2;
					}
					case 0x63:
					{
						v128 c1 = setall_si128();
						v128 t0 = Sse2.xor_si128(a, c1);
						v128 t1 = Sse2.or_si128(t0, c);
						v128 t2 = Sse2.xor_si128(b, t1);
						return t2;
					}
					case 0x64:
					{
						v128 t0 = Sse2.or_si128(a, b);
						v128 t1 = Sse2.xor_si128(b, c);
						v128 t2 = Sse2.and_si128(t0, t1);
						return t2;
					}
					case 0x65:
					{
						v128 c1 = setall_si128();
						v128 t0 = Sse2.xor_si128(a, c1);
						v128 t1 = Sse2.or_si128(t0, b);
						v128 t2 = Sse2.xor_si128(c, t1);
						return t2;
					}
					case 0x66:
					{
						v128 t0 = Sse2.xor_si128(c, b);
						return t0;
					}
					case 0x67:
					{
						v128 t0 = Sse2.xor_si128(b, c);
						v128 t1 = Sse2.or_si128(a, b);
						v128 c1 = setall_si128();
						v128 t2 = Sse2.xor_si128(t1, c1);
						v128 t3 = Sse2.or_si128(t0, t2);
						return t3;
					}
					case 0x68:
					{
						v128 t0 = Sse2.xor_si128(b, c);
						v128 t1 = Sse2.and_si128(a, t0);
						v128 t2 = Sse2.and_si128(b, c);
						v128 t3 = Sse2.andnot_si128(a, t2);
						v128 t4 = Sse2.or_si128(t1, t3);
						return t4;
					}
					case 0x69:
					{
						v128 t0 = Sse2.xor_si128(b, c);
						v128 t1 = Sse2.xor_si128(a, t0);
						v128 c1 = setall_si128();
						v128 t2 = Sse2.xor_si128(t1, c1);
						return t2;
					}
					case 0x6A:
					{
						v128 t0 = Sse2.and_si128(b, a);
						v128 t1 = Sse2.xor_si128(c, t0);
						return t1;
					}
					case 0x6B:
					{
						v128 t0 = Sse2.andnot_si128(a, c);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(a, c1);
						v128 t2 = Sse2.xor_si128(b, c);
						v128 t3 = Sse2.xor_si128(t1, t2);
						v128 t4 = Sse2.or_si128(t0, t3);
						return t4;
					}
					case 0x6C:
					{
						v128 t0 = Sse2.and_si128(a, c);
						v128 t1 = Sse2.xor_si128(b, t0);
						return t1;
					}
					case 0x6D:
					{
						v128 t0 = Sse2.andnot_si128(a, b);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(a, c1);
						v128 t2 = Sse2.xor_si128(b, c);
						v128 t3 = Sse2.xor_si128(t1, t2);
						v128 t4 = Sse2.or_si128(t0, t3);
						return t4;
					}
					case 0x6E:
					{
						v128 t0 = Sse2.andnot_si128(a, b);
						v128 t1 = Sse2.xor_si128(b, c);
						v128 t2 = Sse2.or_si128(t0, t1);
						return t2;
					}
					case 0x6F:
					{
						v128 t0 = Sse2.xor_si128(b, c);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(a, c1);
						v128 t2 = Sse2.or_si128(t0, t1);
						return t2;
					}
					case 0x70:
					{
						v128 t0 = Sse2.and_si128(b, c);
						v128 t1 = Sse2.andnot_si128(t0, a);
						return t1;
					}
					case 0x71:
					{
						v128 t0 = Sse2.or_si128(b, c);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(t0, c1);
						v128 t2 = Sse2.xor_si128(b, c);
						v128 t3 = Sse2.and_si128(a, t2);
						v128 t4 = Sse2.or_si128(t1, t3);
						return t4;
					}
					case 0x72:
					{
						v128 t0 = Sse2.andnot_si128(b, c);
						v128 t1 = Sse2.andnot_si128(c, a);
						v128 t2 = Sse2.or_si128(t0, t1);
						return t2;
					}
					case 0x73:
					{
						v128 t0 = Sse2.andnot_si128(c, a);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(b, c1);
						v128 t2 = Sse2.or_si128(t0, t1);
						return t2;
					}
					case 0x74:
					{
						v128 t0 = Sse2.andnot_si128(c, b);
						v128 t1 = Sse2.andnot_si128(b, a);
						v128 t2 = Sse2.or_si128(t0, t1);
						return t2;
					}
					case 0x75:
					{
						v128 t0 = Sse2.andnot_si128(b, a);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(c, c1);
						v128 t2 = Sse2.or_si128(t0, t1);
						return t2;
					}
					case 0x76:
					{
						v128 t0 = Sse2.andnot_si128(b, a);
						v128 t1 = Sse2.xor_si128(b, c);
						v128 t2 = Sse2.or_si128(t0, t1);
						return t2;
					}
					case 0x77:
					{
						v128 t0 = Sse2.and_si128(c, b);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(t0, c1);
						return t1;
					}
					case 0x78:
					{
						v128 t0 = Sse2.and_si128(b, c);
						v128 t1 = Sse2.xor_si128(a, t0);
						return t1;
					}
					case 0x79:
					{
						v128 t0 = Sse2.andnot_si128(b, a);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(b, c1);
						v128 t2 = Sse2.xor_si128(a, c);
						v128 t3 = Sse2.xor_si128(t1, t2);
						v128 t4 = Sse2.or_si128(t0, t3);
						return t4;
					}
					case 0x7A:
					{
						v128 t0 = Sse2.andnot_si128(b, a);
						v128 t1 = Sse2.xor_si128(a, c);
						v128 t2 = Sse2.or_si128(t0, t1);
						return t2;
					}
					case 0x7B:
					{
						v128 t0 = Sse2.xor_si128(a, c);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(b, c1);
						v128 t2 = Sse2.or_si128(t0, t1);
						return t2;
					}
					case 0x7C:
					{
						v128 t0 = Sse2.andnot_si128(c, a);
						v128 t1 = Sse2.xor_si128(a, b);
						v128 t2 = Sse2.or_si128(t0, t1);
						return t2;
					}
					case 0x7D:
					{
						v128 t0 = Sse2.xor_si128(a, b);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(c, c1);
						v128 t2 = Sse2.or_si128(t0, t1);
						return t2;
					}
					case 0x7E:
					{
						v128 t0 = Sse2.xor_si128(a, b);
						v128 t1 = Sse2.xor_si128(a, c);
						v128 t2 = Sse2.or_si128(t0, t1);
						return t2;
					}
					case 0x7F:
					{
						v128 t0 = Sse2.and_si128(a, b);
						v128 t1 = Sse2.and_si128(t0, c);
						v128 c1 = setall_si128();
						v128 t2 = Sse2.xor_si128(t1, c1);
						return t2;
					}
					case 0x80:
					{
						v128 t0 = Sse2.and_si128(b, c);
						v128 t1 = Sse2.and_si128(a, t0);
						return t1;
					}
					case 0x81:
					{
						v128 t0 = Sse2.xor_si128(a, c);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(b, c1);
						v128 t2 = Sse2.xor_si128(a, t1);
						v128 t3 = Sse2.andnot_si128(t0, t2);
						return t3;
					}
					case 0x82:
					{
						v128 t0 = Sse2.xor_si128(b, a);
						v128 t1 = Sse2.andnot_si128(t0, c);
						return t1;
					}
					case 0x83:
					{
						v128 t0 = Sse2.xor_si128(a, b);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(a, c1);
						v128 t2 = Sse2.or_si128(t1, c);
						v128 t3 = Sse2.andnot_si128(t0, t2);
						return t3;
					}
					case 0x84:
					{
						v128 t0 = Sse2.xor_si128(a, c);
						v128 t1 = Sse2.andnot_si128(t0, b);
						return t1;
					}
					case 0x85:
					{
						v128 t0 = Sse2.xor_si128(a, c);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(c, c1);
						v128 t2 = Sse2.or_si128(b, t1);
						v128 t3 = Sse2.andnot_si128(t0, t2);
						return t3;
					}
					case 0x86:
					{
						v128 t0 = Sse2.or_si128(b, c);
						v128 t1 = Sse2.xor_si128(a, b);
						v128 t2 = Sse2.xor_si128(c, t1);
						v128 t3 = Sse2.and_si128(t0, t2);
						return t3;
					}
					case 0x87:
					{
						v128 t0 = Sse2.and_si128(b, c);
						v128 t1 = Sse2.xor_si128(a, t0);
						v128 c1 = setall_si128();
						v128 t2 = Sse2.xor_si128(t1, c1);
						return t2;
					}
					case 0x88:
					{
						v128 t0 = Sse2.and_si128(c, b);
						return t0;
					}
					case 0x89:
					{
						v128 t0 = Sse2.xor_si128(b, c);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(a, c1);
						v128 t2 = Sse2.or_si128(t1, b);
						v128 t3 = Sse2.andnot_si128(t0, t2);
						return t3;
					}
					case 0x8A:
					{
						v128 t0 = Sse2.andnot_si128(b, a);
						v128 t1 = Sse2.andnot_si128(t0, c);
						return t1;
					}
					case 0x8B:
					{
						v128 t0 = Sse2.and_si128(b, c);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(a, c1);
						v128 t2 = Sse2.andnot_si128(b, t1);
						v128 t3 = Sse2.or_si128(t0, t2);
						return t3;
					}
					case 0x8C:
					{
						v128 t0 = Sse2.andnot_si128(c, a);
						v128 t1 = Sse2.andnot_si128(t0, b);
						return t1;
					}
					case 0x8D:
					{
						v128 t0 = Sse2.and_si128(c, b);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(a, c1);
						v128 t2 = Sse2.andnot_si128(c, t1);
						v128 t3 = Sse2.or_si128(t0, t2);
						return t3;
					}
					case 0x8E:
					{
						v128 t0 = Sse2.and_si128(b, c);
						v128 t1 = Sse2.xor_si128(b, c);
						v128 t2 = Sse2.andnot_si128(a, t1);
						v128 t3 = Sse2.or_si128(t0, t2);
						return t3;
					}
					case 0x8F:
					{
						v128 t0 = Sse2.and_si128(b, c);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(a, c1);
						v128 t2 = Sse2.or_si128(t0, t1);
						return t2;
					}
					case 0x90:
					{
						v128 t0 = Sse2.xor_si128(b, c);
						v128 t1 = Sse2.andnot_si128(t0, a);
						return t1;
					}
					case 0x91:
					{
						v128 t0 = Sse2.xor_si128(b, c);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(b, c1);
						v128 t2 = Sse2.or_si128(a, t1);
						v128 t3 = Sse2.andnot_si128(t0, t2);
						return t3;
					}
					case 0x92:
					{
						v128 t0 = Sse2.or_si128(a, c);
						v128 t1 = Sse2.xor_si128(a, b);
						v128 t2 = Sse2.xor_si128(c, t1);
						v128 t3 = Sse2.and_si128(t0, t2);
						return t3;
					}
					case 0x93:
					{
						v128 t0 = Sse2.and_si128(a, c);
						v128 t1 = Sse2.xor_si128(b, t0);
						v128 c1 = setall_si128();
						v128 t2 = Sse2.xor_si128(t1, c1);
						return t2;
					}
					case 0x94:
					{
						v128 t0 = Sse2.or_si128(a, b);
						v128 t1 = Sse2.xor_si128(a, c);
						v128 t2 = Sse2.xor_si128(b, t1);
						v128 t3 = Sse2.and_si128(t0, t2);
						return t3;
					}
					case 0x95:
					{
						v128 t0 = Sse2.and_si128(b, a);
						v128 t1 = Sse2.xor_si128(c, t0);
						v128 c1 = setall_si128();
						v128 t2 = Sse2.xor_si128(t1, c1);
						return t2;
					}
					case 0x96:
					{
						v128 t0 = Sse2.xor_si128(b, c);
						v128 t1 = Sse2.xor_si128(a, t0);
						return t1;
					}
					case 0x97:
					{
						v128 t0 = Sse2.xor_si128(b, c);
						v128 t1 = Sse2.andnot_si128(t0, a);
						v128 t2 = Sse2.and_si128(b, c);
						v128 c1 = setall_si128();
						v128 t3 = Sse2.xor_si128(t2, c1);
						v128 t4 = Sse2.andnot_si128(a, t3);
						v128 t5 = Sse2.or_si128(t1, t4);
						return t5;
					}
					case 0x98:
					{
						v128 t0 = Sse2.xor_si128(b, c);
						v128 t1 = Sse2.or_si128(a, b);
						v128 t2 = Sse2.andnot_si128(t0, t1);
						return t2;
					}
					case 0x99:
					{
						v128 t0 = Sse2.xor_si128(c, b);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(t0, c1);
						return t1;
					}
					case 0x9A:
					{
						v128 t0 = Sse2.andnot_si128(b, a);
						v128 t1 = Sse2.xor_si128(t0, c);
						return t1;
					}
					case 0x9B:
					{
						v128 t0 = Sse2.andnot_si128(a, c);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(c, c1);
						v128 t2 = Sse2.xor_si128(b, t1);
						v128 t3 = Sse2.or_si128(t0, t2);
						return t3;
					}
					case 0x9C:
					{
						v128 t0 = Sse2.andnot_si128(c, a);
						v128 t1 = Sse2.xor_si128(t0, b);
						return t1;
					}
					case 0x9D:
					{
						v128 t0 = Sse2.andnot_si128(a, b);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(c, c1);
						v128 t2 = Sse2.xor_si128(b, t1);
						v128 t3 = Sse2.or_si128(t0, t2);
						return t3;
					}
					case 0x9E:
					{
						v128 t0 = Sse2.and_si128(b, c);
						v128 t1 = Sse2.xor_si128(a, b);
						v128 t2 = Sse2.xor_si128(c, t1);
						v128 t3 = Sse2.or_si128(t0, t2);
						return t3;
					}
					case 0x9F:
					{
						v128 t0 = Sse2.xor_si128(b, c);
						v128 t1 = Sse2.and_si128(a, t0);
						v128 c1 = setall_si128();
						v128 t2 = Sse2.xor_si128(t1, c1);
						return t2;
					}
					case 0xA0:
					{
						v128 t0 = Sse2.and_si128(c, a);
						return t0;
					}
					case 0xA1:
					{
						v128 t0 = Sse2.xor_si128(a, c);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(b, c1);
						v128 t2 = Sse2.or_si128(a, t1);
						v128 t3 = Sse2.andnot_si128(t0, t2);
						return t3;
					}
					case 0xA2:
					{
						v128 t0 = Sse2.andnot_si128(a, b);
						v128 t1 = Sse2.andnot_si128(t0, c);
						return t1;
					}
					case 0xA3:
					{
						v128 t0 = Sse2.and_si128(a, c);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(b, c1);
						v128 t2 = Sse2.andnot_si128(a, t1);
						v128 t3 = Sse2.or_si128(t0, t2);
						return t3;
					}
					case 0xA4:
					{
						v128 t0 = Sse2.xor_si128(a, c);
						v128 t1 = Sse2.or_si128(a, b);
						v128 t2 = Sse2.andnot_si128(t0, t1);
						return t2;
					}
					case 0xA5:
					{
						v128 t0 = Sse2.xor_si128(c, a);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(t0, c1);
						return t1;
					}
					case 0xA6:
					{
						v128 t0 = Sse2.andnot_si128(a, b);
						v128 t1 = Sse2.xor_si128(t0, c);
						return t1;
					}
					case 0xA7:
					{
						v128 t0 = Sse2.andnot_si128(b, c);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(c, c1);
						v128 t2 = Sse2.xor_si128(a, t1);
						v128 t3 = Sse2.or_si128(t0, t2);
						return t3;
					}
					case 0xA8:
					{
						v128 t0 = Sse2.or_si128(a, b);
						v128 t1 = Sse2.and_si128(c, t0);
						return t1;
					}
					case 0xA9:
					{
						v128 t0 = Sse2.or_si128(b, a);
						v128 t1 = Sse2.xor_si128(c, t0);
						v128 c1 = setall_si128();
						v128 t2 = Sse2.xor_si128(t1, c1);
						return t2;
					}
					case 0xAA:
					{
						return c;
					}
					case 0xAB:
					{
						v128 t0 = Sse2.or_si128(b, a);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(t0, c1);
						v128 t2 = Sse2.or_si128(c, t1);
						return t2;
					}
					case 0xAC:
					{
						v128 t0 = Sse2.and_si128(a, c);
						v128 t1 = Sse2.andnot_si128(a, b);
						v128 t2 = Sse2.or_si128(t0, t1);
						return t2;
					}
					case 0xAD:
					{
						v128 t0 = Sse2.and_si128(b, c);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(c, c1);
						v128 t2 = Sse2.xor_si128(a, t1);
						v128 t3 = Sse2.or_si128(t0, t2);
						return t3;
					}
					case 0xAE:
					{
						v128 t0 = Sse2.andnot_si128(a, b);
						v128 t1 = Sse2.or_si128(t0, c);
						return t1;
					}
					case 0xAF:
					{
						v128 c1 = setall_si128();
						v128 t0 = Sse2.xor_si128(a, c1);
						v128 t1 = Sse2.or_si128(c, t0);
						return t1;
					}
					case 0xB0:
					{
						v128 t0 = Sse2.andnot_si128(c, b);
						v128 t1 = Sse2.andnot_si128(t0, a);
						return t1;
					}
					case 0xB1:
					{
						v128 t0 = Sse2.and_si128(c, a);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(b, c1);
						v128 t2 = Sse2.andnot_si128(c, t1);
						v128 t3 = Sse2.or_si128(t0, t2);
						return t3;
					}
					case 0xB2:
					{
						v128 t0 = Sse2.and_si128(a, c);
						v128 t1 = Sse2.and_si128(b, t0);
						v128 t2 = Sse2.or_si128(a, c);
						v128 t3 = Sse2.andnot_si128(b, t2);
						v128 t4 = Sse2.or_si128(t1, t3);
						return t4;
					}
					case 0xB3:
					{
						v128 t0 = Sse2.and_si128(a, c);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(b, c1);
						v128 t2 = Sse2.or_si128(t0, t1);
						return t2;
					}
					case 0xB4:
					{
						v128 t0 = Sse2.andnot_si128(c, b);
						v128 t1 = Sse2.xor_si128(t0, a);
						return t1;
					}
					case 0xB5:
					{
						v128 t0 = Sse2.andnot_si128(b, a);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(c, c1);
						v128 t2 = Sse2.xor_si128(a, t1);
						v128 t3 = Sse2.or_si128(t0, t2);
						return t3;
					}
					case 0xB6:
					{
						v128 t0 = Sse2.and_si128(a, c);
						v128 t1 = Sse2.xor_si128(a, b);
						v128 t2 = Sse2.xor_si128(c, t1);
						v128 t3 = Sse2.or_si128(t0, t2);
						return t3;
					}
					case 0xB7:
					{
						v128 t0 = Sse2.xor_si128(a, c);
						v128 t1 = Sse2.and_si128(b, t0);
						v128 c1 = setall_si128();
						v128 t2 = Sse2.xor_si128(t1, c1);
						return t2;
					}
					case 0xB8:
					{
						v128 t0 = Sse2.and_si128(b, c);
						v128 t1 = Sse2.andnot_si128(b, a);
						v128 t2 = Sse2.or_si128(t0, t1);
						return t2;
					}
					case 0xB9:
					{
						v128 t0 = Sse2.and_si128(a, c);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(c, c1);
						v128 t2 = Sse2.xor_si128(b, t1);
						v128 t3 = Sse2.or_si128(t0, t2);
						return t3;
					}
					case 0xBA:
					{
						v128 t0 = Sse2.andnot_si128(b, a);
						v128 t1 = Sse2.or_si128(t0, c);
						return t1;
					}
					case 0xBB:
					{
						v128 c1 = setall_si128();
						v128 t0 = Sse2.xor_si128(b, c1);
						v128 t1 = Sse2.or_si128(c, t0);
						return t1;
					}
					case 0xBC:
					{
						v128 t0 = Sse2.and_si128(a, c);
						v128 t1 = Sse2.xor_si128(a, b);
						v128 t2 = Sse2.or_si128(t0, t1);
						return t2;
					}
					case 0xBD:
					{
						v128 t0 = Sse2.xor_si128(a, b);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(c, c1);
						v128 t2 = Sse2.xor_si128(a, t1);
						v128 t3 = Sse2.or_si128(t0, t2);
						return t3;
					}
					case 0xBE:
					{
						v128 t0 = Sse2.xor_si128(b, a);
						v128 t1 = Sse2.or_si128(c, t0);
						return t1;
					}
					case 0xBF:
					{
						v128 t0 = Sse2.and_si128(b, a);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(t0, c1);
						v128 t2 = Sse2.or_si128(c, t1);
						return t2;
					}
					case 0xC0:
					{
						v128 t0 = Sse2.and_si128(b, a);
						return t0;
					}
					case 0xC1:
					{
						v128 t0 = Sse2.xor_si128(a, b);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(c, c1);
						v128 t2 = Sse2.or_si128(a, t1);
						v128 t3 = Sse2.andnot_si128(t0, t2);
						return t3;
					}
					case 0xC2:
					{
						v128 t0 = Sse2.xor_si128(a, b);
						v128 t1 = Sse2.or_si128(a, c);
						v128 t2 = Sse2.andnot_si128(t0, t1);
						return t2;
					}
					case 0xC3:
					{
						v128 t0 = Sse2.xor_si128(b, a);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(t0, c1);
						return t1;
					}
					case 0xC4:
					{
						v128 t0 = Sse2.andnot_si128(a, c);
						v128 t1 = Sse2.andnot_si128(t0, b);
						return t1;
					}
					case 0xC5:
					{
						v128 t0 = Sse2.and_si128(a, b);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(c, c1);
						v128 t2 = Sse2.andnot_si128(a, t1);
						v128 t3 = Sse2.or_si128(t0, t2);
						return t3;
					}
					case 0xC6:
					{
						v128 t0 = Sse2.andnot_si128(a, c);
						v128 t1 = Sse2.xor_si128(t0, b);
						return t1;
					}
					case 0xC7:
					{
						v128 t0 = Sse2.andnot_si128(c, b);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(b, c1);
						v128 t2 = Sse2.xor_si128(a, t1);
						v128 t3 = Sse2.or_si128(t0, t2);
						return t3;
					}
					case 0xC8:
					{
						v128 t0 = Sse2.or_si128(a, c);
						v128 t1 = Sse2.and_si128(b, t0);
						return t1;
					}
					case 0xC9:
					{
						v128 t0 = Sse2.or_si128(a, c);
						v128 t1 = Sse2.xor_si128(b, t0);
						v128 c1 = setall_si128();
						v128 t2 = Sse2.xor_si128(t1, c1);
						return t2;
					}
					case 0xCA:
					{
						v128 t0 = Sse2.and_si128(a, b);
						v128 t1 = Sse2.andnot_si128(a, c);
						v128 t2 = Sse2.or_si128(t0, t1);
						return t2;
					}
					case 0xCB:
					{
						v128 t0 = Sse2.and_si128(b, c);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(b, c1);
						v128 t2 = Sse2.xor_si128(a, t1);
						v128 t3 = Sse2.or_si128(t0, t2);
						return t3;
					}
					case 0xCC:
					{
						return b;
					}
					case 0xCD:
					{
						v128 t0 = Sse2.or_si128(a, c);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(t0, c1);
						v128 t2 = Sse2.or_si128(b, t1);
						return t2;
					}
					case 0xCE:
					{
						v128 t0 = Sse2.andnot_si128(a, c);
						v128 t1 = Sse2.or_si128(t0, b);
						return t1;
					}
					case 0xCF:
					{
						v128 c1 = setall_si128();
						v128 t0 = Sse2.xor_si128(a, c1);
						v128 t1 = Sse2.or_si128(b, t0);
						return t1;
					}
					case 0xD0:
					{
						v128 t0 = Sse2.andnot_si128(b, c);
						v128 t1 = Sse2.andnot_si128(t0, a);
						return t1;
					}
					case 0xD1:
					{
						v128 t0 = Sse2.or_si128(b, c);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(t0, c1);
						v128 t2 = Sse2.and_si128(a, b);
						v128 t3 = Sse2.or_si128(t1, t2);
						return t3;
					}
					case 0xD2:
					{
						v128 t0 = Sse2.andnot_si128(b, c);
						v128 t1 = Sse2.xor_si128(t0, a);
						return t1;
					}
					case 0xD3:
					{
						v128 t0 = Sse2.andnot_si128(c, a);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(b, c1);
						v128 t2 = Sse2.xor_si128(a, t1);
						v128 t3 = Sse2.or_si128(t0, t2);
						return t3;
					}
					case 0xD4:
					{
						v128 t0 = Sse2.andnot_si128(c, b);
						v128 t1 = Sse2.xor_si128(b, c);
						v128 t2 = Sse2.andnot_si128(t1, a);
						v128 t3 = Sse2.or_si128(t0, t2);
						return t3;
					}
					case 0xD5:
					{
						v128 t0 = Sse2.and_si128(a, b);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(c, c1);
						v128 t2 = Sse2.or_si128(t0, t1);
						return t2;
					}
					case 0xD6:
					{
						v128 t0 = Sse2.and_si128(a, b);
						v128 t1 = Sse2.xor_si128(a, c);
						v128 t2 = Sse2.xor_si128(b, t1);
						v128 t3 = Sse2.or_si128(t0, t2);
						return t3;
					}
					case 0xD7:
					{
						v128 t0 = Sse2.xor_si128(b, a);
						v128 t1 = Sse2.and_si128(c, t0);
						v128 c1 = setall_si128();
						v128 t2 = Sse2.xor_si128(t1, c1);
						return t2;
					}
					case 0xD8:
					{
						v128 t0 = Sse2.and_si128(c, b);
						v128 t1 = Sse2.andnot_si128(c, a);
						v128 t2 = Sse2.or_si128(t0, t1);
						return t2;
					}
					case 0xD9:
					{
						v128 t0 = Sse2.and_si128(a, b);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(c, c1);
						v128 t2 = Sse2.xor_si128(b, t1);
						v128 t3 = Sse2.or_si128(t0, t2);
						return t3;
					}
					case 0xDA:
					{
						v128 t0 = Sse2.and_si128(a, b);
						v128 t1 = Sse2.xor_si128(a, c);
						v128 t2 = Sse2.or_si128(t0, t1);
						return t2;
					}
					case 0xDB:
					{
						v128 t0 = Sse2.xor_si128(a, c);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(b, c1);
						v128 t2 = Sse2.xor_si128(a, t1);
						v128 t3 = Sse2.or_si128(t0, t2);
						return t3;
					}
					case 0xDC:
					{
						v128 t0 = Sse2.andnot_si128(c, a);
						v128 t1 = Sse2.or_si128(t0, b);
						return t1;
					}
					case 0xDD:
					{
						v128 c1 = setall_si128();
						v128 t0 = Sse2.xor_si128(c, c1);
						v128 t1 = Sse2.or_si128(b, t0);
						return t1;
					}
					case 0xDE:
					{
						v128 t0 = Sse2.xor_si128(a, c);
						v128 t1 = Sse2.or_si128(b, t0);
						return t1;
					}
					case 0xDF:
					{
						v128 t0 = Sse2.and_si128(a, c);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(t0, c1);
						v128 t2 = Sse2.or_si128(b, t1);
						return t2;
					}
					case 0xE0:
					{
						v128 t0 = Sse2.or_si128(b, c);
						v128 t1 = Sse2.and_si128(a, t0);
						return t1;
					}
					case 0xE1:
					{
						v128 t0 = Sse2.or_si128(b, c);
						v128 t1 = Sse2.xor_si128(a, t0);
						v128 c1 = setall_si128();
						v128 t2 = Sse2.xor_si128(t1, c1);
						return t2;
					}
					case 0xE2:
					{
						v128 t0 = Sse2.and_si128(b, a);
						v128 t1 = Sse2.andnot_si128(b, c);
						v128 t2 = Sse2.or_si128(t0, t1);
						return t2;
					}
					case 0xE3:
					{
						v128 t0 = Sse2.and_si128(a, c);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(b, c1);
						v128 t2 = Sse2.xor_si128(a, t1);
						v128 t3 = Sse2.or_si128(t0, t2);
						return t3;
					}
					case 0xE4:
					{
						v128 t0 = Sse2.and_si128(c, a);
						v128 t1 = Sse2.andnot_si128(c, b);
						v128 t2 = Sse2.or_si128(t0, t1);
						return t2;
					}
					case 0xE5:
					{
						v128 t0 = Sse2.and_si128(a, b);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(c, c1);
						v128 t2 = Sse2.xor_si128(a, t1);
						v128 t3 = Sse2.or_si128(t0, t2);
						return t3;
					}
					case 0xE6:
					{
						v128 t0 = Sse2.and_si128(a, b);
						v128 t1 = Sse2.xor_si128(b, c);
						v128 t2 = Sse2.or_si128(t0, t1);
						return t2;
					}
					case 0xE7:
					{
						v128 t0 = Sse2.xor_si128(b, c);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(b, c1);
						v128 t2 = Sse2.xor_si128(a, t1);
						v128 t3 = Sse2.or_si128(t0, t2);
						return t3;
					}
					case 0xE8:
					{
						v128 t0 = Sse2.and_si128(b, c);
						v128 t1 = Sse2.xor_si128(b, c);
						v128 t2 = Sse2.and_si128(a, t1);
						v128 t3 = Sse2.or_si128(t0, t2);
						return t3;
					}
					case 0xE9:
					{
						v128 t0 = Sse2.and_si128(a, b);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(c, c1);
						v128 t2 = Sse2.xor_si128(a, t1);
						v128 t3 = Sse2.xor_si128(b, t2);
						v128 t4 = Sse2.or_si128(t0, t3);
						return t4;
					}
					case 0xEA:
					{
						v128 t0 = Sse2.and_si128(b, a);
						v128 t1 = Sse2.or_si128(c, t0);
						return t1;
					}
					case 0xEB:
					{
						v128 t0 = Sse2.xor_si128(b, a);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(t0, c1);
						v128 t2 = Sse2.or_si128(c, t1);
						return t2;
					}
					case 0xEC:
					{
						v128 t0 = Sse2.and_si128(a, c);
						v128 t1 = Sse2.or_si128(b, t0);
						return t1;
					}
					case 0xED:
					{
						v128 t0 = Sse2.xor_si128(a, c);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(t0, c1);
						v128 t2 = Sse2.or_si128(b, t1);
						return t2;
					}
					case 0xEE:
					{
						v128 t0 = Sse2.or_si128(c, b);
						return t0;
					}
					case 0xEF:
					{
						v128 c1 = setall_si128();
						v128 t0 = Sse2.xor_si128(a, c1);
						v128 t1 = Sse2.or_si128(t0, c);
						v128 t2 = Sse2.or_si128(b, t1);
						return t2;
					}
					case 0xF0:
					{
						return a;
					}
					case 0xF1:
					{
						v128 t0 = Sse2.or_si128(b, c);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(t0, c1);
						v128 t2 = Sse2.or_si128(a, t1);
						return t2;
					}
					case 0xF2:
					{
						v128 t0 = Sse2.andnot_si128(b, c);
						v128 t1 = Sse2.or_si128(t0, a);
						return t1;
					}
					case 0xF3:
					{
						v128 c1 = setall_si128();
						v128 t0 = Sse2.xor_si128(b, c1);
						v128 t1 = Sse2.or_si128(a, t0);
						return t1;
					}
					case 0xF4:
					{
						v128 t0 = Sse2.andnot_si128(c, b);
						v128 t1 = Sse2.or_si128(t0, a);
						return t1;
					}
					case 0xF5:
					{
						v128 c1 = setall_si128();
						v128 t0 = Sse2.xor_si128(c, c1);
						v128 t1 = Sse2.or_si128(a, t0);
						return t1;
					}
					case 0xF6:
					{
						v128 t0 = Sse2.xor_si128(b, c);
						v128 t1 = Sse2.or_si128(a, t0);
						return t1;
					}
					case 0xF7:
					{
						v128 t0 = Sse2.and_si128(b, c);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(t0, c1);
						v128 t2 = Sse2.or_si128(a, t1);
						return t2;
					}
					case 0xF8:
					{
						v128 t0 = Sse2.and_si128(b, c);
						v128 t1 = Sse2.or_si128(a, t0);
						return t1;
					}
					case 0xF9:
					{
						v128 t0 = Sse2.xor_si128(b, c);
						v128 c1 = setall_si128();
						v128 t1 = Sse2.xor_si128(t0, c1);
						v128 t2 = Sse2.or_si128(a, t1);
						return t2;
					}
					case 0xFA:
					{
						v128 t0 = Sse2.or_si128(c, a);
						return t0;
					}
					case 0xFB:
					{
						v128 c1 = setall_si128();
						v128 t0 = Sse2.xor_si128(b, c1);
						v128 t1 = Sse2.or_si128(t0, c);
						v128 t2 = Sse2.or_si128(a, t1);
						return t2;
					}
					case 0xFC:
					{
						v128 t0 = Sse2.or_si128(b, a);
						return t0;
					}
					case 0xFD:
					{
						v128 c1 = setall_si128();
						v128 t0 = Sse2.xor_si128(c, c1);
						v128 t1 = Sse2.or_si128(b, t0);
						v128 t2 = Sse2.or_si128(a, t1);
						return t2;
					}
					case 0xFE:
					{
						v128 t0 = Sse2.or_si128(b, c);
						v128 t1 = Sse2.or_si128(a, t0);
						return t1;
					}
					case 0xFF:
					{
						v128 c1 = setall_si128();
						return c1;
					}

					default: return default(v128);
				}
			}
			else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_ternarylogic_si256(v256 a, v256 b, v256 c, TernaryOperation code)
        {
			return mm256_ternarylogic_si256(a, b, c, (byte)code);
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_ternarylogic_si256(v256 a, v256 b, v256 c, byte code)
        {
            if (Avx2.IsAvx2Supported)
            {
				switch (code)
				{
					case 0x00:
					{
						v256 c0 = Avx.mm256_setzero_si256();
						return c0;
					}
					case 0x01:
					{
						v256 t0 = Avx2.mm256_or_si256(b, c);
						v256 t1 = Avx2.mm256_or_si256(a, t0);
						v256 c1 = mm256_setall_si256();
						v256 t2 = Avx2.mm256_xor_si256(t1, c1);
						return t2;
					}
					case 0x02:
					{
						v256 t0 = Avx2.mm256_or_si256(b, a);
						v256 t1 = Avx2.mm256_andnot_si256(t0, c);
						return t1;
					}
					case 0x03:
					{
						v256 t0 = Avx2.mm256_or_si256(b, a);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(t0, c1);
						return t1;
					}
					case 0x04:
					{
						v256 t0 = Avx2.mm256_or_si256(a, c);
						v256 t1 = Avx2.mm256_andnot_si256(t0, b);
						return t1;
					}
					case 0x05:
					{
						v256 t0 = Avx2.mm256_or_si256(c, a);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(t0, c1);
						return t1;
					}
					case 0x06:
					{
						v256 t0 = Avx2.mm256_xor_si256(b, c);
						v256 t1 = Avx2.mm256_andnot_si256(a, t0);
						return t1;
					}
					case 0x07:
					{
						v256 t0 = Avx2.mm256_and_si256(b, c);
						v256 t1 = Avx2.mm256_or_si256(a, t0);
						v256 c1 = mm256_setall_si256();
						v256 t2 = Avx2.mm256_xor_si256(t1, c1);
						return t2;
					}
					case 0x08:
					{
						v256 t0 = Avx2.mm256_andnot_si256(a, b);
						v256 t1 = Avx2.mm256_and_si256(t0, c);
						return t1;
					}
					case 0x09:
					{
						v256 t0 = Avx2.mm256_xor_si256(b, c);
						v256 t1 = Avx2.mm256_or_si256(a, t0);
						v256 c1 = mm256_setall_si256();
						v256 t2 = Avx2.mm256_xor_si256(t1, c1);
						return t2;
					}
					case 0x0A:
					{
						v256 t0 = Avx2.mm256_andnot_si256(a, c);
						return t0;
					}
					case 0x0B:
					{
						v256 c1 = mm256_setall_si256();
						v256 t0 = Avx2.mm256_xor_si256(b, c1);
						v256 t1 = Avx2.mm256_or_si256(t0, c);
						v256 t2 = Avx2.mm256_andnot_si256(a, t1);
						return t2;
					}
					case 0x0C:
					{
						v256 t0 = Avx2.mm256_andnot_si256(a, b);
						return t0;
					}
					case 0x0D:
					{
						v256 c1 = mm256_setall_si256();
						v256 t0 = Avx2.mm256_xor_si256(c, c1);
						v256 t1 = Avx2.mm256_or_si256(b, t0);
						v256 t2 = Avx2.mm256_andnot_si256(a, t1);
						return t2;
					}
					case 0x0E:
					{
						v256 t0 = Avx2.mm256_or_si256(b, c);
						v256 t1 = Avx2.mm256_andnot_si256(a, t0);
						return t1;
					}
					case 0x0F:
					{
						v256 c1 = mm256_setall_si256();
						v256 t0 = Avx2.mm256_xor_si256(a, c1);
						return t0;
					}
					case 0x10:
					{
						v256 t0 = Avx2.mm256_or_si256(b, c);
						v256 t1 = Avx2.mm256_andnot_si256(t0, a);
						return t1;
					}
					case 0x11:
					{
						v256 t0 = Avx2.mm256_or_si256(c, b);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(t0, c1);
						return t1;
					}
					case 0x12:
					{
						v256 t0 = Avx2.mm256_xor_si256(a, c);
						v256 t1 = Avx2.mm256_andnot_si256(b, t0);
						return t1;
					}
					case 0x13:
					{
						v256 t0 = Avx2.mm256_and_si256(a, c);
						v256 t1 = Avx2.mm256_or_si256(b, t0);
						v256 c1 = mm256_setall_si256();
						v256 t2 = Avx2.mm256_xor_si256(t1, c1);
						return t2;
					}
					case 0x14:
					{
						v256 t0 = Avx2.mm256_xor_si256(a, b);
						v256 t1 = Avx2.mm256_andnot_si256(c, t0);
						return t1;
					}
					case 0x15:
					{
						v256 t0 = Avx2.mm256_and_si256(b, a);
						v256 t1 = Avx2.mm256_or_si256(c, t0);
						v256 c1 = mm256_setall_si256();
						v256 t2 = Avx2.mm256_xor_si256(t1, c1);
						return t2;
					}
					case 0x16:
					{
						v256 t0 = Avx2.mm256_or_si256(b, c);
						v256 t1 = Avx2.mm256_andnot_si256(t0, a);
						v256 t2 = Avx2.mm256_xor_si256(b, c);
						v256 t3 = Avx2.mm256_andnot_si256(a, t2);
						v256 t4 = Avx2.mm256_or_si256(t1, t3);
						return t4;
					}
					case 0x17:
					{
						v256 t0 = Avx2.mm256_or_si256(b, c);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(t0, c1);
						v256 t2 = Avx2.mm256_xor_si256(b, c);
						v256 t3 = Avx2.mm256_andnot_si256(a, t2);
						v256 t4 = Avx2.mm256_or_si256(t1, t3);
						return t4;
					}
					case 0x18:
					{
						v256 t0 = Avx2.mm256_xor_si256(a, b);
						v256 t1 = Avx2.mm256_xor_si256(a, c);
						v256 t2 = Avx2.mm256_and_si256(t0, t1);
						return t2;
					}
					case 0x19:
					{
						v256 t0 = Avx2.mm256_and_si256(a, b);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(c, c1);
						v256 t2 = Avx2.mm256_xor_si256(b, t1);
						v256 t3 = Avx2.mm256_andnot_si256(t0, t2);
						return t3;
					}
					case 0x1A:
					{
						v256 t0 = Avx2.mm256_and_si256(a, b);
						v256 t1 = Avx2.mm256_xor_si256(a, c);
						v256 t2 = Avx2.mm256_andnot_si256(t0, t1);
						return t2;
					}
					case 0x1B:
					{
						v256 t0 = Avx2.mm256_andnot_si256(a, c);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(b, c1);
						v256 t2 = Avx2.mm256_andnot_si256(c, t1);
						v256 t3 = Avx2.mm256_or_si256(t0, t2);
						return t3;
					}
					case 0x1C:
					{
						v256 t0 = Avx2.mm256_and_si256(a, c);
						v256 t1 = Avx2.mm256_xor_si256(a, b);
						v256 t2 = Avx2.mm256_andnot_si256(t0, t1);
						return t2;
					}
					case 0x1D:
					{
						v256 t0 = Avx2.mm256_andnot_si256(a, b);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(c, c1);
						v256 t2 = Avx2.mm256_andnot_si256(b, t1);
						v256 t3 = Avx2.mm256_or_si256(t0, t2);
						return t3;
					}
					case 0x1E:
					{
						v256 t0 = Avx2.mm256_or_si256(b, c);
						v256 t1 = Avx2.mm256_xor_si256(a, t0);
						return t1;
					}
					case 0x1F:
					{
						v256 t0 = Avx2.mm256_or_si256(b, c);
						v256 t1 = Avx2.mm256_and_si256(a, t0);
						v256 c1 = mm256_setall_si256();
						v256 t2 = Avx2.mm256_xor_si256(t1, c1);
						return t2;
					}
					case 0x20:
					{
						v256 t0 = Avx2.mm256_andnot_si256(b, a);
						v256 t1 = Avx2.mm256_and_si256(t0, c);
						return t1;
					}
					case 0x21:
					{
						v256 t0 = Avx2.mm256_xor_si256(a, c);
						v256 t1 = Avx2.mm256_or_si256(b, t0);
						v256 c1 = mm256_setall_si256();
						v256 t2 = Avx2.mm256_xor_si256(t1, c1);
						return t2;
					}
					case 0x22:
					{
						v256 t0 = Avx2.mm256_andnot_si256(b, c);
						return t0;
					}
					case 0x23:
					{
						v256 c1 = mm256_setall_si256();
						v256 t0 = Avx2.mm256_xor_si256(a, c1);
						v256 t1 = Avx2.mm256_or_si256(t0, c);
						v256 t2 = Avx2.mm256_andnot_si256(b, t1);
						return t2;
					}
					case 0x24:
					{
						v256 t0 = Avx2.mm256_xor_si256(a, b);
						v256 t1 = Avx2.mm256_xor_si256(b, c);
						v256 t2 = Avx2.mm256_and_si256(t0, t1);
						return t2;
					}
					case 0x25:
					{
						v256 t0 = Avx2.mm256_and_si256(a, b);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(c, c1);
						v256 t2 = Avx2.mm256_xor_si256(a, t1);
						v256 t3 = Avx2.mm256_andnot_si256(t0, t2);
						return t3;
					}
					case 0x26:
					{
						v256 t0 = Avx2.mm256_and_si256(a, b);
						v256 t1 = Avx2.mm256_xor_si256(b, c);
						v256 t2 = Avx2.mm256_andnot_si256(t0, t1);
						return t2;
					}
					case 0x27:
					{
						v256 t0 = Avx2.mm256_andnot_si256(b, c);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(a, c1);
						v256 t2 = Avx2.mm256_andnot_si256(c, t1);
						v256 t3 = Avx2.mm256_or_si256(t0, t2);
						return t3;
					}
					case 0x28:
					{
						v256 t0 = Avx2.mm256_xor_si256(b, a);
						v256 t1 = Avx2.mm256_and_si256(c, t0);
						return t1;
					}
					case 0x29:
					{
						v256 t0 = Avx2.mm256_xor_si256(b, a);
						v256 t1 = Avx2.mm256_and_si256(c, t0);
						v256 t2 = Avx2.mm256_or_si256(b, a);
						v256 c1 = mm256_setall_si256();
						v256 t3 = Avx2.mm256_xor_si256(t2, c1);
						v256 t4 = Avx2.mm256_andnot_si256(c, t3);
						v256 t5 = Avx2.mm256_or_si256(t1, t4);
						return t5;
					}
					case 0x2A:
					{
						v256 t0 = Avx2.mm256_and_si256(b, a);
						v256 t1 = Avx2.mm256_andnot_si256(t0, c);
						return t1;
					}
					case 0x2B:
					{
						v256 t0 = Avx2.mm256_and_si256(b, a);
						v256 t1 = Avx2.mm256_andnot_si256(t0, c);
						v256 t2 = Avx2.mm256_or_si256(b, a);
						v256 c1 = mm256_setall_si256();
						v256 t3 = Avx2.mm256_xor_si256(t2, c1);
						v256 t4 = Avx2.mm256_andnot_si256(c, t3);
						v256 t5 = Avx2.mm256_or_si256(t1, t4);
						return t5;
					}
					case 0x2C:
					{
						v256 t0 = Avx2.mm256_or_si256(b, c);
						v256 t1 = Avx2.mm256_xor_si256(a, b);
						v256 t2 = Avx2.mm256_and_si256(t0, t1);
						return t2;
					}
					case 0x2D:
					{
						v256 c1 = mm256_setall_si256();
						v256 t0 = Avx2.mm256_xor_si256(c, c1);
						v256 t1 = Avx2.mm256_or_si256(b, t0);
						v256 t2 = Avx2.mm256_xor_si256(a, t1);
						return t2;
					}
					case 0x2E:
					{
						v256 t0 = Avx2.mm256_or_si256(b, c);
						v256 t1 = Avx2.mm256_and_si256(a, b);
						v256 t2 = Avx2.mm256_xor_si256(t0, t1);
						return t2;
					}
					case 0x2F:
					{
						v256 t0 = Avx2.mm256_andnot_si256(b, c);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(a, c1);
						v256 t2 = Avx2.mm256_or_si256(t0, t1);
						return t2;
					}
					case 0x30:
					{
						v256 t0 = Avx2.mm256_andnot_si256(b, a);
						return t0;
					}
					case 0x31:
					{
						v256 c1 = mm256_setall_si256();
						v256 t0 = Avx2.mm256_xor_si256(c, c1);
						v256 t1 = Avx2.mm256_or_si256(a, t0);
						v256 t2 = Avx2.mm256_andnot_si256(b, t1);
						return t2;
					}
					case 0x32:
					{
						v256 t0 = Avx2.mm256_or_si256(a, c);
						v256 t1 = Avx2.mm256_andnot_si256(b, t0);
						return t1;
					}
					case 0x33:
					{
						v256 c1 = mm256_setall_si256();
						v256 t0 = Avx2.mm256_xor_si256(b, c1);
						return t0;
					}
					case 0x34:
					{
						v256 t0 = Avx2.mm256_and_si256(b, c);
						v256 t1 = Avx2.mm256_xor_si256(a, b);
						v256 t2 = Avx2.mm256_andnot_si256(t0, t1);
						return t2;
					}
					case 0x35:
					{
						v256 t0 = Avx2.mm256_andnot_si256(b, a);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(c, c1);
						v256 t2 = Avx2.mm256_andnot_si256(a, t1);
						v256 t3 = Avx2.mm256_or_si256(t0, t2);
						return t3;
					}
					case 0x36:
					{
						v256 t0 = Avx2.mm256_or_si256(a, c);
						v256 t1 = Avx2.mm256_xor_si256(b, t0);
						return t1;
					}
					case 0x37:
					{
						v256 t0 = Avx2.mm256_or_si256(a, c);
						v256 t1 = Avx2.mm256_and_si256(b, t0);
						v256 c1 = mm256_setall_si256();
						v256 t2 = Avx2.mm256_xor_si256(t1, c1);
						return t2;
					}
					case 0x38:
					{
						v256 t0 = Avx2.mm256_or_si256(a, c);
						v256 t1 = Avx2.mm256_xor_si256(a, b);
						v256 t2 = Avx2.mm256_and_si256(t0, t1);
						return t2;
					}
					case 0x39:
					{
						v256 c1 = mm256_setall_si256();
						v256 t0 = Avx2.mm256_xor_si256(c, c1);
						v256 t1 = Avx2.mm256_or_si256(a, t0);
						v256 t2 = Avx2.mm256_xor_si256(b, t1);
						return t2;
					}
					case 0x3A:
					{
						v256 t0 = Avx2.mm256_andnot_si256(b, a);
						v256 t1 = Avx2.mm256_andnot_si256(a, c);
						v256 t2 = Avx2.mm256_or_si256(t0, t1);
						return t2;
					}
					case 0x3B:
					{
						v256 t0 = Avx2.mm256_andnot_si256(a, c);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(b, c1);
						v256 t2 = Avx2.mm256_or_si256(t0, t1);
						return t2;
					}
					case 0x3C:
					{
						v256 t0 = Avx2.mm256_xor_si256(b, a);
						return t0;
					}
					case 0x3D:
					{
						v256 t0 = Avx2.mm256_xor_si256(a, b);
						v256 t1 = Avx2.mm256_or_si256(a, c);
						v256 c1 = mm256_setall_si256();
						v256 t2 = Avx2.mm256_xor_si256(t1, c1);
						v256 t3 = Avx2.mm256_or_si256(t0, t2);
						return t3;
					}
					case 0x3E:
					{
						v256 t0 = Avx2.mm256_andnot_si256(a, c);
						v256 t1 = Avx2.mm256_xor_si256(a, b);
						v256 t2 = Avx2.mm256_or_si256(t0, t1);
						return t2;
					}
					case 0x3F:
					{
						v256 t0 = Avx2.mm256_and_si256(b, a);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(t0, c1);
						return t1;
					}
					case 0x40:
					{
						v256 t0 = Avx2.mm256_andnot_si256(c, a);
						v256 t1 = Avx2.mm256_and_si256(t0, b);
						return t1;
					}
					case 0x41:
					{
						v256 t0 = Avx2.mm256_xor_si256(b, a);
						v256 t1 = Avx2.mm256_or_si256(c, t0);
						v256 c1 = mm256_setall_si256();
						v256 t2 = Avx2.mm256_xor_si256(t1, c1);
						return t2;
					}
					case 0x42:
					{
						v256 t0 = Avx2.mm256_xor_si256(a, c);
						v256 t1 = Avx2.mm256_xor_si256(b, c);
						v256 t2 = Avx2.mm256_and_si256(t0, t1);
						return t2;
					}
					case 0x43:
					{
						v256 t0 = Avx2.mm256_and_si256(a, c);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(b, c1);
						v256 t2 = Avx2.mm256_xor_si256(a, t1);
						v256 t3 = Avx2.mm256_andnot_si256(t0, t2);
						return t3;
					}
					case 0x44:
					{
						v256 t0 = Avx2.mm256_andnot_si256(c, b);
						return t0;
					}
					case 0x45:
					{
						v256 c1 = mm256_setall_si256();
						v256 t0 = Avx2.mm256_xor_si256(a, c1);
						v256 t1 = Avx2.mm256_or_si256(t0, b);
						v256 t2 = Avx2.mm256_andnot_si256(c, t1);
						return t2;
					}
					case 0x46:
					{
						v256 t0 = Avx2.mm256_and_si256(a, c);
						v256 t1 = Avx2.mm256_xor_si256(b, c);
						v256 t2 = Avx2.mm256_andnot_si256(t0, t1);
						return t2;
					}
					case 0x47:
					{
						v256 t0 = Avx2.mm256_andnot_si256(c, b);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(a, c1);
						v256 t2 = Avx2.mm256_andnot_si256(b, t1);
						v256 t3 = Avx2.mm256_or_si256(t0, t2);
						return t3;
					}
					case 0x48:
					{
						v256 t0 = Avx2.mm256_xor_si256(a, c);
						v256 t1 = Avx2.mm256_and_si256(b, t0);
						return t1;
					}
					case 0x49:
					{
						v256 t0 = Avx2.mm256_xor_si256(a, c);
						v256 t1 = Avx2.mm256_and_si256(b, t0);
						v256 t2 = Avx2.mm256_or_si256(a, c);
						v256 c1 = mm256_setall_si256();
						v256 t3 = Avx2.mm256_xor_si256(t2, c1);
						v256 t4 = Avx2.mm256_andnot_si256(b, t3);
						v256 t5 = Avx2.mm256_or_si256(t1, t4);
						return t5;
					}
					case 0x4A:
					{
						v256 t0 = Avx2.mm256_or_si256(b, c);
						v256 t1 = Avx2.mm256_xor_si256(a, c);
						v256 t2 = Avx2.mm256_and_si256(t0, t1);
						return t2;
					}
					case 0x4B:
					{
						v256 c1 = mm256_setall_si256();
						v256 t0 = Avx2.mm256_xor_si256(b, c1);
						v256 t1 = Avx2.mm256_or_si256(t0, c);
						v256 t2 = Avx2.mm256_xor_si256(a, t1);
						return t2;
					}
					case 0x4C:
					{
						v256 t0 = Avx2.mm256_and_si256(a, c);
						v256 t1 = Avx2.mm256_andnot_si256(t0, b);
						return t1;
					}
					case 0x4D:
					{
						v256 t0 = Avx2.mm256_and_si256(a, c);
						v256 t1 = Avx2.mm256_andnot_si256(t0, b);
						v256 t2 = Avx2.mm256_or_si256(a, c);
						v256 c1 = mm256_setall_si256();
						v256 t3 = Avx2.mm256_xor_si256(t2, c1);
						v256 t4 = Avx2.mm256_andnot_si256(b, t3);
						v256 t5 = Avx2.mm256_or_si256(t1, t4);
						return t5;
					}
					case 0x4E:
					{
						v256 t0 = Avx2.mm256_andnot_si256(a, c);
						v256 t1 = Avx2.mm256_andnot_si256(c, b);
						v256 t2 = Avx2.mm256_or_si256(t0, t1);
						return t2;
					}
					case 0x4F:
					{
						v256 t0 = Avx2.mm256_andnot_si256(c, b);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(a, c1);
						v256 t2 = Avx2.mm256_or_si256(t0, t1);
						return t2;
					}
					case 0x50:
					{
						v256 t0 = Avx2.mm256_andnot_si256(c, a);
						return t0;
					}
					case 0x51:
					{
						v256 c1 = mm256_setall_si256();
						v256 t0 = Avx2.mm256_xor_si256(b, c1);
						v256 t1 = Avx2.mm256_or_si256(a, t0);
						v256 t2 = Avx2.mm256_andnot_si256(c, t1);
						return t2;
					}
					case 0x52:
					{
						v256 t0 = Avx2.mm256_and_si256(b, c);
						v256 t1 = Avx2.mm256_xor_si256(a, c);
						v256 t2 = Avx2.mm256_andnot_si256(t0, t1);
						return t2;
					}
					case 0x53:
					{
						v256 t0 = Avx2.mm256_andnot_si256(c, a);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(b, c1);
						v256 t2 = Avx2.mm256_andnot_si256(a, t1);
						v256 t3 = Avx2.mm256_or_si256(t0, t2);
						return t3;
					}
					case 0x54:
					{
						v256 t0 = Avx2.mm256_or_si256(a, b);
						v256 t1 = Avx2.mm256_andnot_si256(c, t0);
						return t1;
					}
					case 0x55:
					{
						v256 c1 = mm256_setall_si256();
						v256 t0 = Avx2.mm256_xor_si256(c, c1);
						return t0;
					}
					case 0x56:
					{
						v256 t0 = Avx2.mm256_or_si256(b, a);
						v256 t1 = Avx2.mm256_xor_si256(c, t0);
						return t1;
					}
					case 0x57:
					{
						v256 t0 = Avx2.mm256_or_si256(b, a);
						v256 t1 = Avx2.mm256_and_si256(c, t0);
						v256 c1 = mm256_setall_si256();
						v256 t2 = Avx2.mm256_xor_si256(t1, c1);
						return t2;
					}
					case 0x58:
					{
						v256 t0 = Avx2.mm256_or_si256(a, b);
						v256 t1 = Avx2.mm256_xor_si256(a, c);
						v256 t2 = Avx2.mm256_and_si256(t0, t1);
						return t2;
					}
					case 0x59:
					{
						v256 c1 = mm256_setall_si256();
						v256 t0 = Avx2.mm256_xor_si256(b, c1);
						v256 t1 = Avx2.mm256_or_si256(a, t0);
						v256 t2 = Avx2.mm256_xor_si256(c, t1);
						return t2;
					}
					case 0x5A:
					{
						v256 t0 = Avx2.mm256_xor_si256(c, a);
						return t0;
					}
					case 0x5B:
					{
						v256 t0 = Avx2.mm256_xor_si256(a, c);
						v256 t1 = Avx2.mm256_or_si256(a, b);
						v256 c1 = mm256_setall_si256();
						v256 t2 = Avx2.mm256_xor_si256(t1, c1);
						v256 t3 = Avx2.mm256_or_si256(t0, t2);
						return t3;
					}
					case 0x5C:
					{
						v256 t0 = Avx2.mm256_andnot_si256(c, a);
						v256 t1 = Avx2.mm256_andnot_si256(a, b);
						v256 t2 = Avx2.mm256_or_si256(t0, t1);
						return t2;
					}
					case 0x5D:
					{
						v256 t0 = Avx2.mm256_andnot_si256(a, b);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(c, c1);
						v256 t2 = Avx2.mm256_or_si256(t0, t1);
						return t2;
					}
					case 0x5E:
					{
						v256 t0 = Avx2.mm256_andnot_si256(c, b);
						v256 t1 = Avx2.mm256_xor_si256(a, c);
						v256 t2 = Avx2.mm256_or_si256(t0, t1);
						return t2;
					}
					case 0x5F:
					{
						v256 t0 = Avx2.mm256_and_si256(c, a);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(t0, c1);
						return t1;
					}
					case 0x60:
					{
						v256 t0 = Avx2.mm256_xor_si256(b, c);
						v256 t1 = Avx2.mm256_and_si256(a, t0);
						return t1;
					}
					case 0x61:
					{
						v256 t0 = Avx2.mm256_xor_si256(b, c);
						v256 t1 = Avx2.mm256_and_si256(a, t0);
						v256 t2 = Avx2.mm256_or_si256(b, c);
						v256 c1 = mm256_setall_si256();
						v256 t3 = Avx2.mm256_xor_si256(t2, c1);
						v256 t4 = Avx2.mm256_andnot_si256(a, t3);
						v256 t5 = Avx2.mm256_or_si256(t1, t4);
						return t5;
					}
					case 0x62:
					{
						v256 t0 = Avx2.mm256_or_si256(a, c);
						v256 t1 = Avx2.mm256_xor_si256(b, c);
						v256 t2 = Avx2.mm256_and_si256(t0, t1);
						return t2;
					}
					case 0x63:
					{
						v256 c1 = mm256_setall_si256();
						v256 t0 = Avx2.mm256_xor_si256(a, c1);
						v256 t1 = Avx2.mm256_or_si256(t0, c);
						v256 t2 = Avx2.mm256_xor_si256(b, t1);
						return t2;
					}
					case 0x64:
					{
						v256 t0 = Avx2.mm256_or_si256(a, b);
						v256 t1 = Avx2.mm256_xor_si256(b, c);
						v256 t2 = Avx2.mm256_and_si256(t0, t1);
						return t2;
					}
					case 0x65:
					{
						v256 c1 = mm256_setall_si256();
						v256 t0 = Avx2.mm256_xor_si256(a, c1);
						v256 t1 = Avx2.mm256_or_si256(t0, b);
						v256 t2 = Avx2.mm256_xor_si256(c, t1);
						return t2;
					}
					case 0x66:
					{
						v256 t0 = Avx2.mm256_xor_si256(c, b);
						return t0;
					}
					case 0x67:
					{
						v256 t0 = Avx2.mm256_xor_si256(b, c);
						v256 t1 = Avx2.mm256_or_si256(a, b);
						v256 c1 = mm256_setall_si256();
						v256 t2 = Avx2.mm256_xor_si256(t1, c1);
						v256 t3 = Avx2.mm256_or_si256(t0, t2);
						return t3;
					}
					case 0x68:
					{
						v256 t0 = Avx2.mm256_xor_si256(b, c);
						v256 t1 = Avx2.mm256_and_si256(a, t0);
						v256 t2 = Avx2.mm256_and_si256(b, c);
						v256 t3 = Avx2.mm256_andnot_si256(a, t2);
						v256 t4 = Avx2.mm256_or_si256(t1, t3);
						return t4;
					}
					case 0x69:
					{
						v256 t0 = Avx2.mm256_xor_si256(b, c);
						v256 t1 = Avx2.mm256_xor_si256(a, t0);
						v256 c1 = mm256_setall_si256();
						v256 t2 = Avx2.mm256_xor_si256(t1, c1);
						return t2;
					}
					case 0x6A:
					{
						v256 t0 = Avx2.mm256_and_si256(b, a);
						v256 t1 = Avx2.mm256_xor_si256(c, t0);
						return t1;
					}
					case 0x6B:
					{
						v256 t0 = Avx2.mm256_andnot_si256(a, c);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(a, c1);
						v256 t2 = Avx2.mm256_xor_si256(b, c);
						v256 t3 = Avx2.mm256_xor_si256(t1, t2);
						v256 t4 = Avx2.mm256_or_si256(t0, t3);
						return t4;
					}
					case 0x6C:
					{
						v256 t0 = Avx2.mm256_and_si256(a, c);
						v256 t1 = Avx2.mm256_xor_si256(b, t0);
						return t1;
					}
					case 0x6D:
					{
						v256 t0 = Avx2.mm256_andnot_si256(a, b);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(a, c1);
						v256 t2 = Avx2.mm256_xor_si256(b, c);
						v256 t3 = Avx2.mm256_xor_si256(t1, t2);
						v256 t4 = Avx2.mm256_or_si256(t0, t3);
						return t4;
					}
					case 0x6E:
					{
						v256 t0 = Avx2.mm256_andnot_si256(a, b);
						v256 t1 = Avx2.mm256_xor_si256(b, c);
						v256 t2 = Avx2.mm256_or_si256(t0, t1);
						return t2;
					}
					case 0x6F:
					{
						v256 t0 = Avx2.mm256_xor_si256(b, c);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(a, c1);
						v256 t2 = Avx2.mm256_or_si256(t0, t1);
						return t2;
					}
					case 0x70:
					{
						v256 t0 = Avx2.mm256_and_si256(b, c);
						v256 t1 = Avx2.mm256_andnot_si256(t0, a);
						return t1;
					}
					case 0x71:
					{
						v256 t0 = Avx2.mm256_or_si256(b, c);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(t0, c1);
						v256 t2 = Avx2.mm256_xor_si256(b, c);
						v256 t3 = Avx2.mm256_and_si256(a, t2);
						v256 t4 = Avx2.mm256_or_si256(t1, t3);
						return t4;
					}
					case 0x72:
					{
						v256 t0 = Avx2.mm256_andnot_si256(b, c);
						v256 t1 = Avx2.mm256_andnot_si256(c, a);
						v256 t2 = Avx2.mm256_or_si256(t0, t1);
						return t2;
					}
					case 0x73:
					{
						v256 t0 = Avx2.mm256_andnot_si256(c, a);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(b, c1);
						v256 t2 = Avx2.mm256_or_si256(t0, t1);
						return t2;
					}
					case 0x74:
					{
						v256 t0 = Avx2.mm256_andnot_si256(c, b);
						v256 t1 = Avx2.mm256_andnot_si256(b, a);
						v256 t2 = Avx2.mm256_or_si256(t0, t1);
						return t2;
					}
					case 0x75:
					{
						v256 t0 = Avx2.mm256_andnot_si256(b, a);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(c, c1);
						v256 t2 = Avx2.mm256_or_si256(t0, t1);
						return t2;
					}
					case 0x76:
					{
						v256 t0 = Avx2.mm256_andnot_si256(b, a);
						v256 t1 = Avx2.mm256_xor_si256(b, c);
						v256 t2 = Avx2.mm256_or_si256(t0, t1);
						return t2;
					}
					case 0x77:
					{
						v256 t0 = Avx2.mm256_and_si256(c, b);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(t0, c1);
						return t1;
					}
					case 0x78:
					{
						v256 t0 = Avx2.mm256_and_si256(b, c);
						v256 t1 = Avx2.mm256_xor_si256(a, t0);
						return t1;
					}
					case 0x79:
					{
						v256 t0 = Avx2.mm256_andnot_si256(b, a);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(b, c1);
						v256 t2 = Avx2.mm256_xor_si256(a, c);
						v256 t3 = Avx2.mm256_xor_si256(t1, t2);
						v256 t4 = Avx2.mm256_or_si256(t0, t3);
						return t4;
					}
					case 0x7A:
					{
						v256 t0 = Avx2.mm256_andnot_si256(b, a);
						v256 t1 = Avx2.mm256_xor_si256(a, c);
						v256 t2 = Avx2.mm256_or_si256(t0, t1);
						return t2;
					}
					case 0x7B:
					{
						v256 t0 = Avx2.mm256_xor_si256(a, c);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(b, c1);
						v256 t2 = Avx2.mm256_or_si256(t0, t1);
						return t2;
					}
					case 0x7C:
					{
						v256 t0 = Avx2.mm256_andnot_si256(c, a);
						v256 t1 = Avx2.mm256_xor_si256(a, b);
						v256 t2 = Avx2.mm256_or_si256(t0, t1);
						return t2;
					}
					case 0x7D:
					{
						v256 t0 = Avx2.mm256_xor_si256(a, b);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(c, c1);
						v256 t2 = Avx2.mm256_or_si256(t0, t1);
						return t2;
					}
					case 0x7E:
					{
						v256 t0 = Avx2.mm256_xor_si256(a, b);
						v256 t1 = Avx2.mm256_xor_si256(a, c);
						v256 t2 = Avx2.mm256_or_si256(t0, t1);
						return t2;
					}
					case 0x7F:
					{
						v256 t0 = Avx2.mm256_and_si256(a, b);
						v256 t1 = Avx2.mm256_and_si256(t0, c);
						v256 c1 = mm256_setall_si256();
						v256 t2 = Avx2.mm256_xor_si256(t1, c1);
						return t2;
					}
					case 0x80:
					{
						v256 t0 = Avx2.mm256_and_si256(b, c);
						v256 t1 = Avx2.mm256_and_si256(a, t0);
						return t1;
					}
					case 0x81:
					{
						v256 t0 = Avx2.mm256_xor_si256(a, c);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(b, c1);
						v256 t2 = Avx2.mm256_xor_si256(a, t1);
						v256 t3 = Avx2.mm256_andnot_si256(t0, t2);
						return t3;
					}
					case 0x82:
					{
						v256 t0 = Avx2.mm256_xor_si256(b, a);
						v256 t1 = Avx2.mm256_andnot_si256(t0, c);
						return t1;
					}
					case 0x83:
					{
						v256 t0 = Avx2.mm256_xor_si256(a, b);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(a, c1);
						v256 t2 = Avx2.mm256_or_si256(t1, c);
						v256 t3 = Avx2.mm256_andnot_si256(t0, t2);
						return t3;
					}
					case 0x84:
					{
						v256 t0 = Avx2.mm256_xor_si256(a, c);
						v256 t1 = Avx2.mm256_andnot_si256(t0, b);
						return t1;
					}
					case 0x85:
					{
						v256 t0 = Avx2.mm256_xor_si256(a, c);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(c, c1);
						v256 t2 = Avx2.mm256_or_si256(b, t1);
						v256 t3 = Avx2.mm256_andnot_si256(t0, t2);
						return t3;
					}
					case 0x86:
					{
						v256 t0 = Avx2.mm256_or_si256(b, c);
						v256 t1 = Avx2.mm256_xor_si256(a, b);
						v256 t2 = Avx2.mm256_xor_si256(c, t1);
						v256 t3 = Avx2.mm256_and_si256(t0, t2);
						return t3;
					}
					case 0x87:
					{
						v256 t0 = Avx2.mm256_and_si256(b, c);
						v256 t1 = Avx2.mm256_xor_si256(a, t0);
						v256 c1 = mm256_setall_si256();
						v256 t2 = Avx2.mm256_xor_si256(t1, c1);
						return t2;
					}
					case 0x88:
					{
						v256 t0 = Avx2.mm256_and_si256(c, b);
						return t0;
					}
					case 0x89:
					{
						v256 t0 = Avx2.mm256_xor_si256(b, c);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(a, c1);
						v256 t2 = Avx2.mm256_or_si256(t1, b);
						v256 t3 = Avx2.mm256_andnot_si256(t0, t2);
						return t3;
					}
					case 0x8A:
					{
						v256 t0 = Avx2.mm256_andnot_si256(b, a);
						v256 t1 = Avx2.mm256_andnot_si256(t0, c);
						return t1;
					}
					case 0x8B:
					{
						v256 t0 = Avx2.mm256_and_si256(b, c);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(a, c1);
						v256 t2 = Avx2.mm256_andnot_si256(b, t1);
						v256 t3 = Avx2.mm256_or_si256(t0, t2);
						return t3;
					}
					case 0x8C:
					{
						v256 t0 = Avx2.mm256_andnot_si256(c, a);
						v256 t1 = Avx2.mm256_andnot_si256(t0, b);
						return t1;
					}
					case 0x8D:
					{
						v256 t0 = Avx2.mm256_and_si256(c, b);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(a, c1);
						v256 t2 = Avx2.mm256_andnot_si256(c, t1);
						v256 t3 = Avx2.mm256_or_si256(t0, t2);
						return t3;
					}
					case 0x8E:
					{
						v256 t0 = Avx2.mm256_and_si256(b, c);
						v256 t1 = Avx2.mm256_xor_si256(b, c);
						v256 t2 = Avx2.mm256_andnot_si256(a, t1);
						v256 t3 = Avx2.mm256_or_si256(t0, t2);
						return t3;
					}
					case 0x8F:
					{
						v256 t0 = Avx2.mm256_and_si256(b, c);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(a, c1);
						v256 t2 = Avx2.mm256_or_si256(t0, t1);
						return t2;
					}
					case 0x90:
					{
						v256 t0 = Avx2.mm256_xor_si256(b, c);
						v256 t1 = Avx2.mm256_andnot_si256(t0, a);
						return t1;
					}
					case 0x91:
					{
						v256 t0 = Avx2.mm256_xor_si256(b, c);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(b, c1);
						v256 t2 = Avx2.mm256_or_si256(a, t1);
						v256 t3 = Avx2.mm256_andnot_si256(t0, t2);
						return t3;
					}
					case 0x92:
					{
						v256 t0 = Avx2.mm256_or_si256(a, c);
						v256 t1 = Avx2.mm256_xor_si256(a, b);
						v256 t2 = Avx2.mm256_xor_si256(c, t1);
						v256 t3 = Avx2.mm256_and_si256(t0, t2);
						return t3;
					}
					case 0x93:
					{
						v256 t0 = Avx2.mm256_and_si256(a, c);
						v256 t1 = Avx2.mm256_xor_si256(b, t0);
						v256 c1 = mm256_setall_si256();
						v256 t2 = Avx2.mm256_xor_si256(t1, c1);
						return t2;
					}
					case 0x94:
					{
						v256 t0 = Avx2.mm256_or_si256(a, b);
						v256 t1 = Avx2.mm256_xor_si256(a, c);
						v256 t2 = Avx2.mm256_xor_si256(b, t1);
						v256 t3 = Avx2.mm256_and_si256(t0, t2);
						return t3;
					}
					case 0x95:
					{
						v256 t0 = Avx2.mm256_and_si256(b, a);
						v256 t1 = Avx2.mm256_xor_si256(c, t0);
						v256 c1 = mm256_setall_si256();
						v256 t2 = Avx2.mm256_xor_si256(t1, c1);
						return t2;
					}
					case 0x96:
					{
						v256 t0 = Avx2.mm256_xor_si256(b, c);
						v256 t1 = Avx2.mm256_xor_si256(a, t0);
						return t1;
					}
					case 0x97:
					{
						v256 t0 = Avx2.mm256_xor_si256(b, c);
						v256 t1 = Avx2.mm256_andnot_si256(t0, a);
						v256 t2 = Avx2.mm256_and_si256(b, c);
						v256 c1 = mm256_setall_si256();
						v256 t3 = Avx2.mm256_xor_si256(t2, c1);
						v256 t4 = Avx2.mm256_andnot_si256(a, t3);
						v256 t5 = Avx2.mm256_or_si256(t1, t4);
						return t5;
					}
					case 0x98:
					{
						v256 t0 = Avx2.mm256_xor_si256(b, c);
						v256 t1 = Avx2.mm256_or_si256(a, b);
						v256 t2 = Avx2.mm256_andnot_si256(t0, t1);
						return t2;
					}
					case 0x99:
					{
						v256 t0 = Avx2.mm256_xor_si256(c, b);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(t0, c1);
						return t1;
					}
					case 0x9A:
					{
						v256 t0 = Avx2.mm256_andnot_si256(b, a);
						v256 t1 = Avx2.mm256_xor_si256(t0, c);
						return t1;
					}
					case 0x9B:
					{
						v256 t0 = Avx2.mm256_andnot_si256(a, c);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(c, c1);
						v256 t2 = Avx2.mm256_xor_si256(b, t1);
						v256 t3 = Avx2.mm256_or_si256(t0, t2);
						return t3;
					}
					case 0x9C:
					{
						v256 t0 = Avx2.mm256_andnot_si256(c, a);
						v256 t1 = Avx2.mm256_xor_si256(t0, b);
						return t1;
					}
					case 0x9D:
					{
						v256 t0 = Avx2.mm256_andnot_si256(a, b);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(c, c1);
						v256 t2 = Avx2.mm256_xor_si256(b, t1);
						v256 t3 = Avx2.mm256_or_si256(t0, t2);
						return t3;
					}
					case 0x9E:
					{
						v256 t0 = Avx2.mm256_and_si256(b, c);
						v256 t1 = Avx2.mm256_xor_si256(a, b);
						v256 t2 = Avx2.mm256_xor_si256(c, t1);
						v256 t3 = Avx2.mm256_or_si256(t0, t2);
						return t3;
					}
					case 0x9F:
					{
						v256 t0 = Avx2.mm256_xor_si256(b, c);
						v256 t1 = Avx2.mm256_and_si256(a, t0);
						v256 c1 = mm256_setall_si256();
						v256 t2 = Avx2.mm256_xor_si256(t1, c1);
						return t2;
					}
					case 0xA0:
					{
						v256 t0 = Avx2.mm256_and_si256(c, a);
						return t0;
					}
					case 0xA1:
					{
						v256 t0 = Avx2.mm256_xor_si256(a, c);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(b, c1);
						v256 t2 = Avx2.mm256_or_si256(a, t1);
						v256 t3 = Avx2.mm256_andnot_si256(t0, t2);
						return t3;
					}
					case 0xA2:
					{
						v256 t0 = Avx2.mm256_andnot_si256(a, b);
						v256 t1 = Avx2.mm256_andnot_si256(t0, c);
						return t1;
					}
					case 0xA3:
					{
						v256 t0 = Avx2.mm256_and_si256(a, c);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(b, c1);
						v256 t2 = Avx2.mm256_andnot_si256(a, t1);
						v256 t3 = Avx2.mm256_or_si256(t0, t2);
						return t3;
					}
					case 0xA4:
					{
						v256 t0 = Avx2.mm256_xor_si256(a, c);
						v256 t1 = Avx2.mm256_or_si256(a, b);
						v256 t2 = Avx2.mm256_andnot_si256(t0, t1);
						return t2;
					}
					case 0xA5:
					{
						v256 t0 = Avx2.mm256_xor_si256(c, a);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(t0, c1);
						return t1;
					}
					case 0xA6:
					{
						v256 t0 = Avx2.mm256_andnot_si256(a, b);
						v256 t1 = Avx2.mm256_xor_si256(t0, c);
						return t1;
					}
					case 0xA7:
					{
						v256 t0 = Avx2.mm256_andnot_si256(b, c);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(c, c1);
						v256 t2 = Avx2.mm256_xor_si256(a, t1);
						v256 t3 = Avx2.mm256_or_si256(t0, t2);
						return t3;
					}
					case 0xA8:
					{
						v256 t0 = Avx2.mm256_or_si256(a, b);
						v256 t1 = Avx2.mm256_and_si256(c, t0);
						return t1;
					}
					case 0xA9:
					{
						v256 t0 = Avx2.mm256_or_si256(b, a);
						v256 t1 = Avx2.mm256_xor_si256(c, t0);
						v256 c1 = mm256_setall_si256();
						v256 t2 = Avx2.mm256_xor_si256(t1, c1);
						return t2;
					}
					case 0xAA:
					{
						return c;
					}
					case 0xAB:
					{
						v256 t0 = Avx2.mm256_or_si256(b, a);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(t0, c1);
						v256 t2 = Avx2.mm256_or_si256(c, t1);
						return t2;
					}
					case 0xAC:
					{
						v256 t0 = Avx2.mm256_and_si256(a, c);
						v256 t1 = Avx2.mm256_andnot_si256(a, b);
						v256 t2 = Avx2.mm256_or_si256(t0, t1);
						return t2;
					}
					case 0xAD:
					{
						v256 t0 = Avx2.mm256_and_si256(b, c);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(c, c1);
						v256 t2 = Avx2.mm256_xor_si256(a, t1);
						v256 t3 = Avx2.mm256_or_si256(t0, t2);
						return t3;
					}
					case 0xAE:
					{
						v256 t0 = Avx2.mm256_andnot_si256(a, b);
						v256 t1 = Avx2.mm256_or_si256(t0, c);
						return t1;
					}
					case 0xAF:
					{
						v256 c1 = mm256_setall_si256();
						v256 t0 = Avx2.mm256_xor_si256(a, c1);
						v256 t1 = Avx2.mm256_or_si256(c, t0);
						return t1;
					}
					case 0xB0:
					{
						v256 t0 = Avx2.mm256_andnot_si256(c, b);
						v256 t1 = Avx2.mm256_andnot_si256(t0, a);
						return t1;
					}
					case 0xB1:
					{
						v256 t0 = Avx2.mm256_and_si256(c, a);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(b, c1);
						v256 t2 = Avx2.mm256_andnot_si256(c, t1);
						v256 t3 = Avx2.mm256_or_si256(t0, t2);
						return t3;
					}
					case 0xB2:
					{
						v256 t0 = Avx2.mm256_and_si256(a, c);
						v256 t1 = Avx2.mm256_and_si256(b, t0);
						v256 t2 = Avx2.mm256_or_si256(a, c);
						v256 t3 = Avx2.mm256_andnot_si256(b, t2);
						v256 t4 = Avx2.mm256_or_si256(t1, t3);
						return t4;
					}
					case 0xB3:
					{
						v256 t0 = Avx2.mm256_and_si256(a, c);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(b, c1);
						v256 t2 = Avx2.mm256_or_si256(t0, t1);
						return t2;
					}
					case 0xB4:
					{
						v256 t0 = Avx2.mm256_andnot_si256(c, b);
						v256 t1 = Avx2.mm256_xor_si256(t0, a);
						return t1;
					}
					case 0xB5:
					{
						v256 t0 = Avx2.mm256_andnot_si256(b, a);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(c, c1);
						v256 t2 = Avx2.mm256_xor_si256(a, t1);
						v256 t3 = Avx2.mm256_or_si256(t0, t2);
						return t3;
					}
					case 0xB6:
					{
						v256 t0 = Avx2.mm256_and_si256(a, c);
						v256 t1 = Avx2.mm256_xor_si256(a, b);
						v256 t2 = Avx2.mm256_xor_si256(c, t1);
						v256 t3 = Avx2.mm256_or_si256(t0, t2);
						return t3;
					}
					case 0xB7:
					{
						v256 t0 = Avx2.mm256_xor_si256(a, c);
						v256 t1 = Avx2.mm256_and_si256(b, t0);
						v256 c1 = mm256_setall_si256();
						v256 t2 = Avx2.mm256_xor_si256(t1, c1);
						return t2;
					}
					case 0xB8:
					{
						v256 t0 = Avx2.mm256_and_si256(b, c);
						v256 t1 = Avx2.mm256_andnot_si256(b, a);
						v256 t2 = Avx2.mm256_or_si256(t0, t1);
						return t2;
					}
					case 0xB9:
					{
						v256 t0 = Avx2.mm256_and_si256(a, c);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(c, c1);
						v256 t2 = Avx2.mm256_xor_si256(b, t1);
						v256 t3 = Avx2.mm256_or_si256(t0, t2);
						return t3;
					}
					case 0xBA:
					{
						v256 t0 = Avx2.mm256_andnot_si256(b, a);
						v256 t1 = Avx2.mm256_or_si256(t0, c);
						return t1;
					}
					case 0xBB:
					{
						v256 c1 = mm256_setall_si256();
						v256 t0 = Avx2.mm256_xor_si256(b, c1);
						v256 t1 = Avx2.mm256_or_si256(c, t0);
						return t1;
					}
					case 0xBC:
					{
						v256 t0 = Avx2.mm256_and_si256(a, c);
						v256 t1 = Avx2.mm256_xor_si256(a, b);
						v256 t2 = Avx2.mm256_or_si256(t0, t1);
						return t2;
					}
					case 0xBD:
					{
						v256 t0 = Avx2.mm256_xor_si256(a, b);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(c, c1);
						v256 t2 = Avx2.mm256_xor_si256(a, t1);
						v256 t3 = Avx2.mm256_or_si256(t0, t2);
						return t3;
					}
					case 0xBE:
					{
						v256 t0 = Avx2.mm256_xor_si256(b, a);
						v256 t1 = Avx2.mm256_or_si256(c, t0);
						return t1;
					}
					case 0xBF:
					{
						v256 t0 = Avx2.mm256_and_si256(b, a);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(t0, c1);
						v256 t2 = Avx2.mm256_or_si256(c, t1);
						return t2;
					}
					case 0xC0:
					{
						v256 t0 = Avx2.mm256_and_si256(b, a);
						return t0;
					}
					case 0xC1:
					{
						v256 t0 = Avx2.mm256_xor_si256(a, b);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(c, c1);
						v256 t2 = Avx2.mm256_or_si256(a, t1);
						v256 t3 = Avx2.mm256_andnot_si256(t0, t2);
						return t3;
					}
					case 0xC2:
					{
						v256 t0 = Avx2.mm256_xor_si256(a, b);
						v256 t1 = Avx2.mm256_or_si256(a, c);
						v256 t2 = Avx2.mm256_andnot_si256(t0, t1);
						return t2;
					}
					case 0xC3:
					{
						v256 t0 = Avx2.mm256_xor_si256(b, a);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(t0, c1);
						return t1;
					}
					case 0xC4:
					{
						v256 t0 = Avx2.mm256_andnot_si256(a, c);
						v256 t1 = Avx2.mm256_andnot_si256(t0, b);
						return t1;
					}
					case 0xC5:
					{
						v256 t0 = Avx2.mm256_and_si256(a, b);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(c, c1);
						v256 t2 = Avx2.mm256_andnot_si256(a, t1);
						v256 t3 = Avx2.mm256_or_si256(t0, t2);
						return t3;
					}
					case 0xC6:
					{
						v256 t0 = Avx2.mm256_andnot_si256(a, c);
						v256 t1 = Avx2.mm256_xor_si256(t0, b);
						return t1;
					}
					case 0xC7:
					{
						v256 t0 = Avx2.mm256_andnot_si256(c, b);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(b, c1);
						v256 t2 = Avx2.mm256_xor_si256(a, t1);
						v256 t3 = Avx2.mm256_or_si256(t0, t2);
						return t3;
					}
					case 0xC8:
					{
						v256 t0 = Avx2.mm256_or_si256(a, c);
						v256 t1 = Avx2.mm256_and_si256(b, t0);
						return t1;
					}
					case 0xC9:
					{
						v256 t0 = Avx2.mm256_or_si256(a, c);
						v256 t1 = Avx2.mm256_xor_si256(b, t0);
						v256 c1 = mm256_setall_si256();
						v256 t2 = Avx2.mm256_xor_si256(t1, c1);
						return t2;
					}
					case 0xCA:
					{
						v256 t0 = Avx2.mm256_and_si256(a, b);
						v256 t1 = Avx2.mm256_andnot_si256(a, c);
						v256 t2 = Avx2.mm256_or_si256(t0, t1);
						return t2;
					}
					case 0xCB:
					{
						v256 t0 = Avx2.mm256_and_si256(b, c);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(b, c1);
						v256 t2 = Avx2.mm256_xor_si256(a, t1);
						v256 t3 = Avx2.mm256_or_si256(t0, t2);
						return t3;
					}
					case 0xCC:
					{
						return b;
					}
					case 0xCD:
					{
						v256 t0 = Avx2.mm256_or_si256(a, c);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(t0, c1);
						v256 t2 = Avx2.mm256_or_si256(b, t1);
						return t2;
					}
					case 0xCE:
					{
						v256 t0 = Avx2.mm256_andnot_si256(a, c);
						v256 t1 = Avx2.mm256_or_si256(t0, b);
						return t1;
					}
					case 0xCF:
					{
						v256 c1 = mm256_setall_si256();
						v256 t0 = Avx2.mm256_xor_si256(a, c1);
						v256 t1 = Avx2.mm256_or_si256(b, t0);
						return t1;
					}
					case 0xD0:
					{
						v256 t0 = Avx2.mm256_andnot_si256(b, c);
						v256 t1 = Avx2.mm256_andnot_si256(t0, a);
						return t1;
					}
					case 0xD1:
					{
						v256 t0 = Avx2.mm256_or_si256(b, c);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(t0, c1);
						v256 t2 = Avx2.mm256_and_si256(a, b);
						v256 t3 = Avx2.mm256_or_si256(t1, t2);
						return t3;
					}
					case 0xD2:
					{
						v256 t0 = Avx2.mm256_andnot_si256(b, c);
						v256 t1 = Avx2.mm256_xor_si256(t0, a);
						return t1;
					}
					case 0xD3:
					{
						v256 t0 = Avx2.mm256_andnot_si256(c, a);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(b, c1);
						v256 t2 = Avx2.mm256_xor_si256(a, t1);
						v256 t3 = Avx2.mm256_or_si256(t0, t2);
						return t3;
					}
					case 0xD4:
					{
						v256 t0 = Avx2.mm256_andnot_si256(c, b);
						v256 t1 = Avx2.mm256_xor_si256(b, c);
						v256 t2 = Avx2.mm256_andnot_si256(t1, a);
						v256 t3 = Avx2.mm256_or_si256(t0, t2);
						return t3;
					}
					case 0xD5:
					{
						v256 t0 = Avx2.mm256_and_si256(a, b);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(c, c1);
						v256 t2 = Avx2.mm256_or_si256(t0, t1);
						return t2;
					}
					case 0xD6:
					{
						v256 t0 = Avx2.mm256_and_si256(a, b);
						v256 t1 = Avx2.mm256_xor_si256(a, c);
						v256 t2 = Avx2.mm256_xor_si256(b, t1);
						v256 t3 = Avx2.mm256_or_si256(t0, t2);
						return t3;
					}
					case 0xD7:
					{
						v256 t0 = Avx2.mm256_xor_si256(b, a);
						v256 t1 = Avx2.mm256_and_si256(c, t0);
						v256 c1 = mm256_setall_si256();
						v256 t2 = Avx2.mm256_xor_si256(t1, c1);
						return t2;
					}
					case 0xD8:
					{
						v256 t0 = Avx2.mm256_and_si256(c, b);
						v256 t1 = Avx2.mm256_andnot_si256(c, a);
						v256 t2 = Avx2.mm256_or_si256(t0, t1);
						return t2;
					}
					case 0xD9:
					{
						v256 t0 = Avx2.mm256_and_si256(a, b);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(c, c1);
						v256 t2 = Avx2.mm256_xor_si256(b, t1);
						v256 t3 = Avx2.mm256_or_si256(t0, t2);
						return t3;
					}
					case 0xDA:
					{
						v256 t0 = Avx2.mm256_and_si256(a, b);
						v256 t1 = Avx2.mm256_xor_si256(a, c);
						v256 t2 = Avx2.mm256_or_si256(t0, t1);
						return t2;
					}
					case 0xDB:
					{
						v256 t0 = Avx2.mm256_xor_si256(a, c);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(b, c1);
						v256 t2 = Avx2.mm256_xor_si256(a, t1);
						v256 t3 = Avx2.mm256_or_si256(t0, t2);
						return t3;
					}
					case 0xDC:
					{
						v256 t0 = Avx2.mm256_andnot_si256(c, a);
						v256 t1 = Avx2.mm256_or_si256(t0, b);
						return t1;
					}
					case 0xDD:
					{
						v256 c1 = mm256_setall_si256();
						v256 t0 = Avx2.mm256_xor_si256(c, c1);
						v256 t1 = Avx2.mm256_or_si256(b, t0);
						return t1;
					}
					case 0xDE:
					{
						v256 t0 = Avx2.mm256_xor_si256(a, c);
						v256 t1 = Avx2.mm256_or_si256(b, t0);
						return t1;
					}
					case 0xDF:
					{
						v256 t0 = Avx2.mm256_and_si256(a, c);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(t0, c1);
						v256 t2 = Avx2.mm256_or_si256(b, t1);
						return t2;
					}
					case 0xE0:
					{
						v256 t0 = Avx2.mm256_or_si256(b, c);
						v256 t1 = Avx2.mm256_and_si256(a, t0);
						return t1;
					}
					case 0xE1:
					{
						v256 t0 = Avx2.mm256_or_si256(b, c);
						v256 t1 = Avx2.mm256_xor_si256(a, t0);
						v256 c1 = mm256_setall_si256();
						v256 t2 = Avx2.mm256_xor_si256(t1, c1);
						return t2;
					}
					case 0xE2:
					{
						v256 t0 = Avx2.mm256_and_si256(b, a);
						v256 t1 = Avx2.mm256_andnot_si256(b, c);
						v256 t2 = Avx2.mm256_or_si256(t0, t1);
						return t2;
					}
					case 0xE3:
					{
						v256 t0 = Avx2.mm256_and_si256(a, c);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(b, c1);
						v256 t2 = Avx2.mm256_xor_si256(a, t1);
						v256 t3 = Avx2.mm256_or_si256(t0, t2);
						return t3;
					}
					case 0xE4:
					{
						v256 t0 = Avx2.mm256_and_si256(c, a);
						v256 t1 = Avx2.mm256_andnot_si256(c, b);
						v256 t2 = Avx2.mm256_or_si256(t0, t1);
						return t2;
					}
					case 0xE5:
					{
						v256 t0 = Avx2.mm256_and_si256(a, b);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(c, c1);
						v256 t2 = Avx2.mm256_xor_si256(a, t1);
						v256 t3 = Avx2.mm256_or_si256(t0, t2);
						return t3;
					}
					case 0xE6:
					{
						v256 t0 = Avx2.mm256_and_si256(a, b);
						v256 t1 = Avx2.mm256_xor_si256(b, c);
						v256 t2 = Avx2.mm256_or_si256(t0, t1);
						return t2;
					}
					case 0xE7:
					{
						v256 t0 = Avx2.mm256_xor_si256(b, c);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(b, c1);
						v256 t2 = Avx2.mm256_xor_si256(a, t1);
						v256 t3 = Avx2.mm256_or_si256(t0, t2);
						return t3;
					}
					case 0xE8:
					{
						v256 t0 = Avx2.mm256_and_si256(b, c);
						v256 t1 = Avx2.mm256_xor_si256(b, c);
						v256 t2 = Avx2.mm256_and_si256(a, t1);
						v256 t3 = Avx2.mm256_or_si256(t0, t2);
						return t3;
					}
					case 0xE9:
					{
						v256 t0 = Avx2.mm256_and_si256(a, b);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(c, c1);
						v256 t2 = Avx2.mm256_xor_si256(a, t1);
						v256 t3 = Avx2.mm256_xor_si256(b, t2);
						v256 t4 = Avx2.mm256_or_si256(t0, t3);
						return t4;
					}
					case 0xEA:
					{
						v256 t0 = Avx2.mm256_and_si256(b, a);
						v256 t1 = Avx2.mm256_or_si256(c, t0);
						return t1;
					}
					case 0xEB:
					{
						v256 t0 = Avx2.mm256_xor_si256(b, a);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(t0, c1);
						v256 t2 = Avx2.mm256_or_si256(c, t1);
						return t2;
					}
					case 0xEC:
					{
						v256 t0 = Avx2.mm256_and_si256(a, c);
						v256 t1 = Avx2.mm256_or_si256(b, t0);
						return t1;
					}
					case 0xED:
					{
						v256 t0 = Avx2.mm256_xor_si256(a, c);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(t0, c1);
						v256 t2 = Avx2.mm256_or_si256(b, t1);
						return t2;
					}
					case 0xEE:
					{
						v256 t0 = Avx2.mm256_or_si256(c, b);
						return t0;
					}
					case 0xEF:
					{
						v256 c1 = mm256_setall_si256();
						v256 t0 = Avx2.mm256_xor_si256(a, c1);
						v256 t1 = Avx2.mm256_or_si256(t0, c);
						v256 t2 = Avx2.mm256_or_si256(b, t1);
						return t2;
					}
					case 0xF0:
					{
						return a;
					}
					case 0xF1:
					{
						v256 t0 = Avx2.mm256_or_si256(b, c);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(t0, c1);
						v256 t2 = Avx2.mm256_or_si256(a, t1);
						return t2;
					}
					case 0xF2:
					{
						v256 t0 = Avx2.mm256_andnot_si256(b, c);
						v256 t1 = Avx2.mm256_or_si256(t0, a);
						return t1;
					}
					case 0xF3:
					{
						v256 c1 = mm256_setall_si256();
						v256 t0 = Avx2.mm256_xor_si256(b, c1);
						v256 t1 = Avx2.mm256_or_si256(a, t0);
						return t1;
					}
					case 0xF4:
					{
						v256 t0 = Avx2.mm256_andnot_si256(c, b);
						v256 t1 = Avx2.mm256_or_si256(t0, a);
						return t1;
					}
					case 0xF5:
					{
						v256 c1 = mm256_setall_si256();
						v256 t0 = Avx2.mm256_xor_si256(c, c1);
						v256 t1 = Avx2.mm256_or_si256(a, t0);
						return t1;
					}
					case 0xF6:
					{
						v256 t0 = Avx2.mm256_xor_si256(b, c);
						v256 t1 = Avx2.mm256_or_si256(a, t0);
						return t1;
					}
					case 0xF7:
					{
						v256 t0 = Avx2.mm256_and_si256(b, c);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(t0, c1);
						v256 t2 = Avx2.mm256_or_si256(a, t1);
						return t2;
					}
					case 0xF8:
					{
						v256 t0 = Avx2.mm256_and_si256(b, c);
						v256 t1 = Avx2.mm256_or_si256(a, t0);
						return t1;
					}
					case 0xF9:
					{
						v256 t0 = Avx2.mm256_xor_si256(b, c);
						v256 c1 = mm256_setall_si256();
						v256 t1 = Avx2.mm256_xor_si256(t0, c1);
						v256 t2 = Avx2.mm256_or_si256(a, t1);
						return t2;
					}
					case 0xFA:
					{
						v256 t0 = Avx2.mm256_or_si256(c, a);
						return t0;
					}
					case 0xFB:
					{
						v256 c1 = mm256_setall_si256();
						v256 t0 = Avx2.mm256_xor_si256(b, c1);
						v256 t1 = Avx2.mm256_or_si256(t0, c);
						v256 t2 = Avx2.mm256_or_si256(a, t1);
						return t2;
					}
					case 0xFC:
					{
						v256 t0 = Avx2.mm256_or_si256(b, a);
						return t0;
					}
					case 0xFD:
					{
						v256 c1 = mm256_setall_si256();
						v256 t0 = Avx2.mm256_xor_si256(c, c1);
						v256 t1 = Avx2.mm256_or_si256(b, t0);
						v256 t2 = Avx2.mm256_or_si256(a, t1);
						return t2;
					}
					case 0xFE:
					{
						v256 t0 = Avx2.mm256_or_si256(b, c);
						v256 t1 = Avx2.mm256_or_si256(a, t0);
						return t1;
					}
					case 0xFF:
					{
						v256 c1 = mm256_setall_si256();
						return c1;
					}

					default: return default(v256);
				}
			}
            else if (Avx.IsAvxSupported)
            {
				switch (code)
				{
					case 0x00:
					{
						v256 c0 = Avx.mm256_setzero_ps();
						return c0;
					}
					case 0x01:
					{
						v256 t0 = Avx.mm256_or_ps(b, c);
						v256 t1 = Avx.mm256_or_ps(a, t0);
						v256 c1 = mm256_setall_ps();
						v256 t2 = Avx.mm256_xor_ps(t1, c1);
						return t2;
					}
					case 0x02:
					{
						v256 t0 = Avx.mm256_or_ps(b, a);
						v256 t1 = Avx.mm256_andnot_ps(t0, c);
						return t1;
					}
					case 0x03:
					{
						v256 t0 = Avx.mm256_or_ps(b, a);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(t0, c1);
						return t1;
					}
					case 0x04:
					{
						v256 t0 = Avx.mm256_or_ps(a, c);
						v256 t1 = Avx.mm256_andnot_ps(t0, b);
						return t1;
					}
					case 0x05:
					{
						v256 t0 = Avx.mm256_or_ps(c, a);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(t0, c1);
						return t1;
					}
					case 0x06:
					{
						v256 t0 = Avx.mm256_xor_ps(b, c);
						v256 t1 = Avx.mm256_andnot_ps(a, t0);
						return t1;
					}
					case 0x07:
					{
						v256 t0 = Avx.mm256_and_ps(b, c);
						v256 t1 = Avx.mm256_or_ps(a, t0);
						v256 c1 = mm256_setall_ps();
						v256 t2 = Avx.mm256_xor_ps(t1, c1);
						return t2;
					}
					case 0x08:
					{
						v256 t0 = Avx.mm256_andnot_ps(a, b);
						v256 t1 = Avx.mm256_and_ps(t0, c);
						return t1;
					}
					case 0x09:
					{
						v256 t0 = Avx.mm256_xor_ps(b, c);
						v256 t1 = Avx.mm256_or_ps(a, t0);
						v256 c1 = mm256_setall_ps();
						v256 t2 = Avx.mm256_xor_ps(t1, c1);
						return t2;
					}
					case 0x0A:
					{
						v256 t0 = Avx.mm256_andnot_ps(a, c);
						return t0;
					}
					case 0x0B:
					{
						v256 c1 = mm256_setall_ps();
						v256 t0 = Avx.mm256_xor_ps(b, c1);
						v256 t1 = Avx.mm256_or_ps(t0, c);
						v256 t2 = Avx.mm256_andnot_ps(a, t1);
						return t2;
					}
					case 0x0C:
					{
						v256 t0 = Avx.mm256_andnot_ps(a, b);
						return t0;
					}
					case 0x0D:
					{
						v256 c1 = mm256_setall_ps();
						v256 t0 = Avx.mm256_xor_ps(c, c1);
						v256 t1 = Avx.mm256_or_ps(b, t0);
						v256 t2 = Avx.mm256_andnot_ps(a, t1);
						return t2;
					}
					case 0x0E:
					{
						v256 t0 = Avx.mm256_or_ps(b, c);
						v256 t1 = Avx.mm256_andnot_ps(a, t0);
						return t1;
					}
					case 0x0F:
					{
						v256 c1 = mm256_setall_ps();
						v256 t0 = Avx.mm256_xor_ps(a, c1);
						return t0;
					}
					case 0x10:
					{
						v256 t0 = Avx.mm256_or_ps(b, c);
						v256 t1 = Avx.mm256_andnot_ps(t0, a);
						return t1;
					}
					case 0x11:
					{
						v256 t0 = Avx.mm256_or_ps(c, b);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(t0, c1);
						return t1;
					}
					case 0x12:
					{
						v256 t0 = Avx.mm256_xor_ps(a, c);
						v256 t1 = Avx.mm256_andnot_ps(b, t0);
						return t1;
					}
					case 0x13:
					{
						v256 t0 = Avx.mm256_and_ps(a, c);
						v256 t1 = Avx.mm256_or_ps(b, t0);
						v256 c1 = mm256_setall_ps();
						v256 t2 = Avx.mm256_xor_ps(t1, c1);
						return t2;
					}
					case 0x14:
					{
						v256 t0 = Avx.mm256_xor_ps(a, b);
						v256 t1 = Avx.mm256_andnot_ps(c, t0);
						return t1;
					}
					case 0x15:
					{
						v256 t0 = Avx.mm256_and_ps(b, a);
						v256 t1 = Avx.mm256_or_ps(c, t0);
						v256 c1 = mm256_setall_ps();
						v256 t2 = Avx.mm256_xor_ps(t1, c1);
						return t2;
					}
					case 0x16:
					{
						v256 t0 = Avx.mm256_or_ps(b, c);
						v256 t1 = Avx.mm256_andnot_ps(t0, a);
						v256 t2 = Avx.mm256_xor_ps(b, c);
						v256 t3 = Avx.mm256_andnot_ps(a, t2);
						v256 t4 = Avx.mm256_or_ps(t1, t3);
						return t4;
					}
					case 0x17:
					{
						v256 t0 = Avx.mm256_or_ps(b, c);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(t0, c1);
						v256 t2 = Avx.mm256_xor_ps(b, c);
						v256 t3 = Avx.mm256_andnot_ps(a, t2);
						v256 t4 = Avx.mm256_or_ps(t1, t3);
						return t4;
					}
					case 0x18:
					{
						v256 t0 = Avx.mm256_xor_ps(a, b);
						v256 t1 = Avx.mm256_xor_ps(a, c);
						v256 t2 = Avx.mm256_and_ps(t0, t1);
						return t2;
					}
					case 0x19:
					{
						v256 t0 = Avx.mm256_and_ps(a, b);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(c, c1);
						v256 t2 = Avx.mm256_xor_ps(b, t1);
						v256 t3 = Avx.mm256_andnot_ps(t0, t2);
						return t3;
					}
					case 0x1A:
					{
						v256 t0 = Avx.mm256_and_ps(a, b);
						v256 t1 = Avx.mm256_xor_ps(a, c);
						v256 t2 = Avx.mm256_andnot_ps(t0, t1);
						return t2;
					}
					case 0x1B:
					{
						v256 t0 = Avx.mm256_andnot_ps(a, c);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(b, c1);
						v256 t2 = Avx.mm256_andnot_ps(c, t1);
						v256 t3 = Avx.mm256_or_ps(t0, t2);
						return t3;
					}
					case 0x1C:
					{
						v256 t0 = Avx.mm256_and_ps(a, c);
						v256 t1 = Avx.mm256_xor_ps(a, b);
						v256 t2 = Avx.mm256_andnot_ps(t0, t1);
						return t2;
					}
					case 0x1D:
					{
						v256 t0 = Avx.mm256_andnot_ps(a, b);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(c, c1);
						v256 t2 = Avx.mm256_andnot_ps(b, t1);
						v256 t3 = Avx.mm256_or_ps(t0, t2);
						return t3;
					}
					case 0x1E:
					{
						v256 t0 = Avx.mm256_or_ps(b, c);
						v256 t1 = Avx.mm256_xor_ps(a, t0);
						return t1;
					}
					case 0x1F:
					{
						v256 t0 = Avx.mm256_or_ps(b, c);
						v256 t1 = Avx.mm256_and_ps(a, t0);
						v256 c1 = mm256_setall_ps();
						v256 t2 = Avx.mm256_xor_ps(t1, c1);
						return t2;
					}
					case 0x20:
					{
						v256 t0 = Avx.mm256_andnot_ps(b, a);
						v256 t1 = Avx.mm256_and_ps(t0, c);
						return t1;
					}
					case 0x21:
					{
						v256 t0 = Avx.mm256_xor_ps(a, c);
						v256 t1 = Avx.mm256_or_ps(b, t0);
						v256 c1 = mm256_setall_ps();
						v256 t2 = Avx.mm256_xor_ps(t1, c1);
						return t2;
					}
					case 0x22:
					{
						v256 t0 = Avx.mm256_andnot_ps(b, c);
						return t0;
					}
					case 0x23:
					{
						v256 c1 = mm256_setall_ps();
						v256 t0 = Avx.mm256_xor_ps(a, c1);
						v256 t1 = Avx.mm256_or_ps(t0, c);
						v256 t2 = Avx.mm256_andnot_ps(b, t1);
						return t2;
					}
					case 0x24:
					{
						v256 t0 = Avx.mm256_xor_ps(a, b);
						v256 t1 = Avx.mm256_xor_ps(b, c);
						v256 t2 = Avx.mm256_and_ps(t0, t1);
						return t2;
					}
					case 0x25:
					{
						v256 t0 = Avx.mm256_and_ps(a, b);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(c, c1);
						v256 t2 = Avx.mm256_xor_ps(a, t1);
						v256 t3 = Avx.mm256_andnot_ps(t0, t2);
						return t3;
					}
					case 0x26:
					{
						v256 t0 = Avx.mm256_and_ps(a, b);
						v256 t1 = Avx.mm256_xor_ps(b, c);
						v256 t2 = Avx.mm256_andnot_ps(t0, t1);
						return t2;
					}
					case 0x27:
					{
						v256 t0 = Avx.mm256_andnot_ps(b, c);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(a, c1);
						v256 t2 = Avx.mm256_andnot_ps(c, t1);
						v256 t3 = Avx.mm256_or_ps(t0, t2);
						return t3;
					}
					case 0x28:
					{
						v256 t0 = Avx.mm256_xor_ps(b, a);
						v256 t1 = Avx.mm256_and_ps(c, t0);
						return t1;
					}
					case 0x29:
					{
						v256 t0 = Avx.mm256_xor_ps(b, a);
						v256 t1 = Avx.mm256_and_ps(c, t0);
						v256 t2 = Avx.mm256_or_ps(b, a);
						v256 c1 = mm256_setall_ps();
						v256 t3 = Avx.mm256_xor_ps(t2, c1);
						v256 t4 = Avx.mm256_andnot_ps(c, t3);
						v256 t5 = Avx.mm256_or_ps(t1, t4);
						return t5;
					}
					case 0x2A:
					{
						v256 t0 = Avx.mm256_and_ps(b, a);
						v256 t1 = Avx.mm256_andnot_ps(t0, c);
						return t1;
					}
					case 0x2B:
					{
						v256 t0 = Avx.mm256_and_ps(b, a);
						v256 t1 = Avx.mm256_andnot_ps(t0, c);
						v256 t2 = Avx.mm256_or_ps(b, a);
						v256 c1 = mm256_setall_ps();
						v256 t3 = Avx.mm256_xor_ps(t2, c1);
						v256 t4 = Avx.mm256_andnot_ps(c, t3);
						v256 t5 = Avx.mm256_or_ps(t1, t4);
						return t5;
					}
					case 0x2C:
					{
						v256 t0 = Avx.mm256_or_ps(b, c);
						v256 t1 = Avx.mm256_xor_ps(a, b);
						v256 t2 = Avx.mm256_and_ps(t0, t1);
						return t2;
					}
					case 0x2D:
					{
						v256 c1 = mm256_setall_ps();
						v256 t0 = Avx.mm256_xor_ps(c, c1);
						v256 t1 = Avx.mm256_or_ps(b, t0);
						v256 t2 = Avx.mm256_xor_ps(a, t1);
						return t2;
					}
					case 0x2E:
					{
						v256 t0 = Avx.mm256_or_ps(b, c);
						v256 t1 = Avx.mm256_and_ps(a, b);
						v256 t2 = Avx.mm256_xor_ps(t0, t1);
						return t2;
					}
					case 0x2F:
					{
						v256 t0 = Avx.mm256_andnot_ps(b, c);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(a, c1);
						v256 t2 = Avx.mm256_or_ps(t0, t1);
						return t2;
					}
					case 0x30:
					{
						v256 t0 = Avx.mm256_andnot_ps(b, a);
						return t0;
					}
					case 0x31:
					{
						v256 c1 = mm256_setall_ps();
						v256 t0 = Avx.mm256_xor_ps(c, c1);
						v256 t1 = Avx.mm256_or_ps(a, t0);
						v256 t2 = Avx.mm256_andnot_ps(b, t1);
						return t2;
					}
					case 0x32:
					{
						v256 t0 = Avx.mm256_or_ps(a, c);
						v256 t1 = Avx.mm256_andnot_ps(b, t0);
						return t1;
					}
					case 0x33:
					{
						v256 c1 = mm256_setall_ps();
						v256 t0 = Avx.mm256_xor_ps(b, c1);
						return t0;
					}
					case 0x34:
					{
						v256 t0 = Avx.mm256_and_ps(b, c);
						v256 t1 = Avx.mm256_xor_ps(a, b);
						v256 t2 = Avx.mm256_andnot_ps(t0, t1);
						return t2;
					}
					case 0x35:
					{
						v256 t0 = Avx.mm256_andnot_ps(b, a);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(c, c1);
						v256 t2 = Avx.mm256_andnot_ps(a, t1);
						v256 t3 = Avx.mm256_or_ps(t0, t2);
						return t3;
					}
					case 0x36:
					{
						v256 t0 = Avx.mm256_or_ps(a, c);
						v256 t1 = Avx.mm256_xor_ps(b, t0);
						return t1;
					}
					case 0x37:
					{
						v256 t0 = Avx.mm256_or_ps(a, c);
						v256 t1 = Avx.mm256_and_ps(b, t0);
						v256 c1 = mm256_setall_ps();
						v256 t2 = Avx.mm256_xor_ps(t1, c1);
						return t2;
					}
					case 0x38:
					{
						v256 t0 = Avx.mm256_or_ps(a, c);
						v256 t1 = Avx.mm256_xor_ps(a, b);
						v256 t2 = Avx.mm256_and_ps(t0, t1);
						return t2;
					}
					case 0x39:
					{
						v256 c1 = mm256_setall_ps();
						v256 t0 = Avx.mm256_xor_ps(c, c1);
						v256 t1 = Avx.mm256_or_ps(a, t0);
						v256 t2 = Avx.mm256_xor_ps(b, t1);
						return t2;
					}
					case 0x3A:
					{
						v256 t0 = Avx.mm256_andnot_ps(b, a);
						v256 t1 = Avx.mm256_andnot_ps(a, c);
						v256 t2 = Avx.mm256_or_ps(t0, t1);
						return t2;
					}
					case 0x3B:
					{
						v256 t0 = Avx.mm256_andnot_ps(a, c);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(b, c1);
						v256 t2 = Avx.mm256_or_ps(t0, t1);
						return t2;
					}
					case 0x3C:
					{
						v256 t0 = Avx.mm256_xor_ps(b, a);
						return t0;
					}
					case 0x3D:
					{
						v256 t0 = Avx.mm256_xor_ps(a, b);
						v256 t1 = Avx.mm256_or_ps(a, c);
						v256 c1 = mm256_setall_ps();
						v256 t2 = Avx.mm256_xor_ps(t1, c1);
						v256 t3 = Avx.mm256_or_ps(t0, t2);
						return t3;
					}
					case 0x3E:
					{
						v256 t0 = Avx.mm256_andnot_ps(a, c);
						v256 t1 = Avx.mm256_xor_ps(a, b);
						v256 t2 = Avx.mm256_or_ps(t0, t1);
						return t2;
					}
					case 0x3F:
					{
						v256 t0 = Avx.mm256_and_ps(b, a);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(t0, c1);
						return t1;
					}
					case 0x40:
					{
						v256 t0 = Avx.mm256_andnot_ps(c, a);
						v256 t1 = Avx.mm256_and_ps(t0, b);
						return t1;
					}
					case 0x41:
					{
						v256 t0 = Avx.mm256_xor_ps(b, a);
						v256 t1 = Avx.mm256_or_ps(c, t0);
						v256 c1 = mm256_setall_ps();
						v256 t2 = Avx.mm256_xor_ps(t1, c1);
						return t2;
					}
					case 0x42:
					{
						v256 t0 = Avx.mm256_xor_ps(a, c);
						v256 t1 = Avx.mm256_xor_ps(b, c);
						v256 t2 = Avx.mm256_and_ps(t0, t1);
						return t2;
					}
					case 0x43:
					{
						v256 t0 = Avx.mm256_and_ps(a, c);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(b, c1);
						v256 t2 = Avx.mm256_xor_ps(a, t1);
						v256 t3 = Avx.mm256_andnot_ps(t0, t2);
						return t3;
					}
					case 0x44:
					{
						v256 t0 = Avx.mm256_andnot_ps(c, b);
						return t0;
					}
					case 0x45:
					{
						v256 c1 = mm256_setall_ps();
						v256 t0 = Avx.mm256_xor_ps(a, c1);
						v256 t1 = Avx.mm256_or_ps(t0, b);
						v256 t2 = Avx.mm256_andnot_ps(c, t1);
						return t2;
					}
					case 0x46:
					{
						v256 t0 = Avx.mm256_and_ps(a, c);
						v256 t1 = Avx.mm256_xor_ps(b, c);
						v256 t2 = Avx.mm256_andnot_ps(t0, t1);
						return t2;
					}
					case 0x47:
					{
						v256 t0 = Avx.mm256_andnot_ps(c, b);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(a, c1);
						v256 t2 = Avx.mm256_andnot_ps(b, t1);
						v256 t3 = Avx.mm256_or_ps(t0, t2);
						return t3;
					}
					case 0x48:
					{
						v256 t0 = Avx.mm256_xor_ps(a, c);
						v256 t1 = Avx.mm256_and_ps(b, t0);
						return t1;
					}
					case 0x49:
					{
						v256 t0 = Avx.mm256_xor_ps(a, c);
						v256 t1 = Avx.mm256_and_ps(b, t0);
						v256 t2 = Avx.mm256_or_ps(a, c);
						v256 c1 = mm256_setall_ps();
						v256 t3 = Avx.mm256_xor_ps(t2, c1);
						v256 t4 = Avx.mm256_andnot_ps(b, t3);
						v256 t5 = Avx.mm256_or_ps(t1, t4);
						return t5;
					}
					case 0x4A:
					{
						v256 t0 = Avx.mm256_or_ps(b, c);
						v256 t1 = Avx.mm256_xor_ps(a, c);
						v256 t2 = Avx.mm256_and_ps(t0, t1);
						return t2;
					}
					case 0x4B:
					{
						v256 c1 = mm256_setall_ps();
						v256 t0 = Avx.mm256_xor_ps(b, c1);
						v256 t1 = Avx.mm256_or_ps(t0, c);
						v256 t2 = Avx.mm256_xor_ps(a, t1);
						return t2;
					}
					case 0x4C:
					{
						v256 t0 = Avx.mm256_and_ps(a, c);
						v256 t1 = Avx.mm256_andnot_ps(t0, b);
						return t1;
					}
					case 0x4D:
					{
						v256 t0 = Avx.mm256_and_ps(a, c);
						v256 t1 = Avx.mm256_andnot_ps(t0, b);
						v256 t2 = Avx.mm256_or_ps(a, c);
						v256 c1 = mm256_setall_ps();
						v256 t3 = Avx.mm256_xor_ps(t2, c1);
						v256 t4 = Avx.mm256_andnot_ps(b, t3);
						v256 t5 = Avx.mm256_or_ps(t1, t4);
						return t5;
					}
					case 0x4E:
					{
						v256 t0 = Avx.mm256_andnot_ps(a, c);
						v256 t1 = Avx.mm256_andnot_ps(c, b);
						v256 t2 = Avx.mm256_or_ps(t0, t1);
						return t2;
					}
					case 0x4F:
					{
						v256 t0 = Avx.mm256_andnot_ps(c, b);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(a, c1);
						v256 t2 = Avx.mm256_or_ps(t0, t1);
						return t2;
					}
					case 0x50:
					{
						v256 t0 = Avx.mm256_andnot_ps(c, a);
						return t0;
					}
					case 0x51:
					{
						v256 c1 = mm256_setall_ps();
						v256 t0 = Avx.mm256_xor_ps(b, c1);
						v256 t1 = Avx.mm256_or_ps(a, t0);
						v256 t2 = Avx.mm256_andnot_ps(c, t1);
						return t2;
					}
					case 0x52:
					{
						v256 t0 = Avx.mm256_and_ps(b, c);
						v256 t1 = Avx.mm256_xor_ps(a, c);
						v256 t2 = Avx.mm256_andnot_ps(t0, t1);
						return t2;
					}
					case 0x53:
					{
						v256 t0 = Avx.mm256_andnot_ps(c, a);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(b, c1);
						v256 t2 = Avx.mm256_andnot_ps(a, t1);
						v256 t3 = Avx.mm256_or_ps(t0, t2);
						return t3;
					}
					case 0x54:
					{
						v256 t0 = Avx.mm256_or_ps(a, b);
						v256 t1 = Avx.mm256_andnot_ps(c, t0);
						return t1;
					}
					case 0x55:
					{
						v256 c1 = mm256_setall_ps();
						v256 t0 = Avx.mm256_xor_ps(c, c1);
						return t0;
					}
					case 0x56:
					{
						v256 t0 = Avx.mm256_or_ps(b, a);
						v256 t1 = Avx.mm256_xor_ps(c, t0);
						return t1;
					}
					case 0x57:
					{
						v256 t0 = Avx.mm256_or_ps(b, a);
						v256 t1 = Avx.mm256_and_ps(c, t0);
						v256 c1 = mm256_setall_ps();
						v256 t2 = Avx.mm256_xor_ps(t1, c1);
						return t2;
					}
					case 0x58:
					{
						v256 t0 = Avx.mm256_or_ps(a, b);
						v256 t1 = Avx.mm256_xor_ps(a, c);
						v256 t2 = Avx.mm256_and_ps(t0, t1);
						return t2;
					}
					case 0x59:
					{
						v256 c1 = mm256_setall_ps();
						v256 t0 = Avx.mm256_xor_ps(b, c1);
						v256 t1 = Avx.mm256_or_ps(a, t0);
						v256 t2 = Avx.mm256_xor_ps(c, t1);
						return t2;
					}
					case 0x5A:
					{
						v256 t0 = Avx.mm256_xor_ps(c, a);
						return t0;
					}
					case 0x5B:
					{
						v256 t0 = Avx.mm256_xor_ps(a, c);
						v256 t1 = Avx.mm256_or_ps(a, b);
						v256 c1 = mm256_setall_ps();
						v256 t2 = Avx.mm256_xor_ps(t1, c1);
						v256 t3 = Avx.mm256_or_ps(t0, t2);
						return t3;
					}
					case 0x5C:
					{
						v256 t0 = Avx.mm256_andnot_ps(c, a);
						v256 t1 = Avx.mm256_andnot_ps(a, b);
						v256 t2 = Avx.mm256_or_ps(t0, t1);
						return t2;
					}
					case 0x5D:
					{
						v256 t0 = Avx.mm256_andnot_ps(a, b);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(c, c1);
						v256 t2 = Avx.mm256_or_ps(t0, t1);
						return t2;
					}
					case 0x5E:
					{
						v256 t0 = Avx.mm256_andnot_ps(c, b);
						v256 t1 = Avx.mm256_xor_ps(a, c);
						v256 t2 = Avx.mm256_or_ps(t0, t1);
						return t2;
					}
					case 0x5F:
					{
						v256 t0 = Avx.mm256_and_ps(c, a);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(t0, c1);
						return t1;
					}
					case 0x60:
					{
						v256 t0 = Avx.mm256_xor_ps(b, c);
						v256 t1 = Avx.mm256_and_ps(a, t0);
						return t1;
					}
					case 0x61:
					{
						v256 t0 = Avx.mm256_xor_ps(b, c);
						v256 t1 = Avx.mm256_and_ps(a, t0);
						v256 t2 = Avx.mm256_or_ps(b, c);
						v256 c1 = mm256_setall_ps();
						v256 t3 = Avx.mm256_xor_ps(t2, c1);
						v256 t4 = Avx.mm256_andnot_ps(a, t3);
						v256 t5 = Avx.mm256_or_ps(t1, t4);
						return t5;
					}
					case 0x62:
					{
						v256 t0 = Avx.mm256_or_ps(a, c);
						v256 t1 = Avx.mm256_xor_ps(b, c);
						v256 t2 = Avx.mm256_and_ps(t0, t1);
						return t2;
					}
					case 0x63:
					{
						v256 c1 = mm256_setall_ps();
						v256 t0 = Avx.mm256_xor_ps(a, c1);
						v256 t1 = Avx.mm256_or_ps(t0, c);
						v256 t2 = Avx.mm256_xor_ps(b, t1);
						return t2;
					}
					case 0x64:
					{
						v256 t0 = Avx.mm256_or_ps(a, b);
						v256 t1 = Avx.mm256_xor_ps(b, c);
						v256 t2 = Avx.mm256_and_ps(t0, t1);
						return t2;
					}
					case 0x65:
					{
						v256 c1 = mm256_setall_ps();
						v256 t0 = Avx.mm256_xor_ps(a, c1);
						v256 t1 = Avx.mm256_or_ps(t0, b);
						v256 t2 = Avx.mm256_xor_ps(c, t1);
						return t2;
					}
					case 0x66:
					{
						v256 t0 = Avx.mm256_xor_ps(c, b);
						return t0;
					}
					case 0x67:
					{
						v256 t0 = Avx.mm256_xor_ps(b, c);
						v256 t1 = Avx.mm256_or_ps(a, b);
						v256 c1 = mm256_setall_ps();
						v256 t2 = Avx.mm256_xor_ps(t1, c1);
						v256 t3 = Avx.mm256_or_ps(t0, t2);
						return t3;
					}
					case 0x68:
					{
						v256 t0 = Avx.mm256_xor_ps(b, c);
						v256 t1 = Avx.mm256_and_ps(a, t0);
						v256 t2 = Avx.mm256_and_ps(b, c);
						v256 t3 = Avx.mm256_andnot_ps(a, t2);
						v256 t4 = Avx.mm256_or_ps(t1, t3);
						return t4;
					}
					case 0x69:
					{
						v256 t0 = Avx.mm256_xor_ps(b, c);
						v256 t1 = Avx.mm256_xor_ps(a, t0);
						v256 c1 = mm256_setall_ps();
						v256 t2 = Avx.mm256_xor_ps(t1, c1);
						return t2;
					}
					case 0x6A:
					{
						v256 t0 = Avx.mm256_and_ps(b, a);
						v256 t1 = Avx.mm256_xor_ps(c, t0);
						return t1;
					}
					case 0x6B:
					{
						v256 t0 = Avx.mm256_andnot_ps(a, c);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(a, c1);
						v256 t2 = Avx.mm256_xor_ps(b, c);
						v256 t3 = Avx.mm256_xor_ps(t1, t2);
						v256 t4 = Avx.mm256_or_ps(t0, t3);
						return t4;
					}
					case 0x6C:
					{
						v256 t0 = Avx.mm256_and_ps(a, c);
						v256 t1 = Avx.mm256_xor_ps(b, t0);
						return t1;
					}
					case 0x6D:
					{
						v256 t0 = Avx.mm256_andnot_ps(a, b);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(a, c1);
						v256 t2 = Avx.mm256_xor_ps(b, c);
						v256 t3 = Avx.mm256_xor_ps(t1, t2);
						v256 t4 = Avx.mm256_or_ps(t0, t3);
						return t4;
					}
					case 0x6E:
					{
						v256 t0 = Avx.mm256_andnot_ps(a, b);
						v256 t1 = Avx.mm256_xor_ps(b, c);
						v256 t2 = Avx.mm256_or_ps(t0, t1);
						return t2;
					}
					case 0x6F:
					{
						v256 t0 = Avx.mm256_xor_ps(b, c);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(a, c1);
						v256 t2 = Avx.mm256_or_ps(t0, t1);
						return t2;
					}
					case 0x70:
					{
						v256 t0 = Avx.mm256_and_ps(b, c);
						v256 t1 = Avx.mm256_andnot_ps(t0, a);
						return t1;
					}
					case 0x71:
					{
						v256 t0 = Avx.mm256_or_ps(b, c);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(t0, c1);
						v256 t2 = Avx.mm256_xor_ps(b, c);
						v256 t3 = Avx.mm256_and_ps(a, t2);
						v256 t4 = Avx.mm256_or_ps(t1, t3);
						return t4;
					}
					case 0x72:
					{
						v256 t0 = Avx.mm256_andnot_ps(b, c);
						v256 t1 = Avx.mm256_andnot_ps(c, a);
						v256 t2 = Avx.mm256_or_ps(t0, t1);
						return t2;
					}
					case 0x73:
					{
						v256 t0 = Avx.mm256_andnot_ps(c, a);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(b, c1);
						v256 t2 = Avx.mm256_or_ps(t0, t1);
						return t2;
					}
					case 0x74:
					{
						v256 t0 = Avx.mm256_andnot_ps(c, b);
						v256 t1 = Avx.mm256_andnot_ps(b, a);
						v256 t2 = Avx.mm256_or_ps(t0, t1);
						return t2;
					}
					case 0x75:
					{
						v256 t0 = Avx.mm256_andnot_ps(b, a);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(c, c1);
						v256 t2 = Avx.mm256_or_ps(t0, t1);
						return t2;
					}
					case 0x76:
					{
						v256 t0 = Avx.mm256_andnot_ps(b, a);
						v256 t1 = Avx.mm256_xor_ps(b, c);
						v256 t2 = Avx.mm256_or_ps(t0, t1);
						return t2;
					}
					case 0x77:
					{
						v256 t0 = Avx.mm256_and_ps(c, b);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(t0, c1);
						return t1;
					}
					case 0x78:
					{
						v256 t0 = Avx.mm256_and_ps(b, c);
						v256 t1 = Avx.mm256_xor_ps(a, t0);
						return t1;
					}
					case 0x79:
					{
						v256 t0 = Avx.mm256_andnot_ps(b, a);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(b, c1);
						v256 t2 = Avx.mm256_xor_ps(a, c);
						v256 t3 = Avx.mm256_xor_ps(t1, t2);
						v256 t4 = Avx.mm256_or_ps(t0, t3);
						return t4;
					}
					case 0x7A:
					{
						v256 t0 = Avx.mm256_andnot_ps(b, a);
						v256 t1 = Avx.mm256_xor_ps(a, c);
						v256 t2 = Avx.mm256_or_ps(t0, t1);
						return t2;
					}
					case 0x7B:
					{
						v256 t0 = Avx.mm256_xor_ps(a, c);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(b, c1);
						v256 t2 = Avx.mm256_or_ps(t0, t1);
						return t2;
					}
					case 0x7C:
					{
						v256 t0 = Avx.mm256_andnot_ps(c, a);
						v256 t1 = Avx.mm256_xor_ps(a, b);
						v256 t2 = Avx.mm256_or_ps(t0, t1);
						return t2;
					}
					case 0x7D:
					{
						v256 t0 = Avx.mm256_xor_ps(a, b);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(c, c1);
						v256 t2 = Avx.mm256_or_ps(t0, t1);
						return t2;
					}
					case 0x7E:
					{
						v256 t0 = Avx.mm256_xor_ps(a, b);
						v256 t1 = Avx.mm256_xor_ps(a, c);
						v256 t2 = Avx.mm256_or_ps(t0, t1);
						return t2;
					}
					case 0x7F:
					{
						v256 t0 = Avx.mm256_and_ps(a, b);
						v256 t1 = Avx.mm256_and_ps(t0, c);
						v256 c1 = mm256_setall_ps();
						v256 t2 = Avx.mm256_xor_ps(t1, c1);
						return t2;
					}
					case 0x80:
					{
						v256 t0 = Avx.mm256_and_ps(b, c);
						v256 t1 = Avx.mm256_and_ps(a, t0);
						return t1;
					}
					case 0x81:
					{
						v256 t0 = Avx.mm256_xor_ps(a, c);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(b, c1);
						v256 t2 = Avx.mm256_xor_ps(a, t1);
						v256 t3 = Avx.mm256_andnot_ps(t0, t2);
						return t3;
					}
					case 0x82:
					{
						v256 t0 = Avx.mm256_xor_ps(b, a);
						v256 t1 = Avx.mm256_andnot_ps(t0, c);
						return t1;
					}
					case 0x83:
					{
						v256 t0 = Avx.mm256_xor_ps(a, b);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(a, c1);
						v256 t2 = Avx.mm256_or_ps(t1, c);
						v256 t3 = Avx.mm256_andnot_ps(t0, t2);
						return t3;
					}
					case 0x84:
					{
						v256 t0 = Avx.mm256_xor_ps(a, c);
						v256 t1 = Avx.mm256_andnot_ps(t0, b);
						return t1;
					}
					case 0x85:
					{
						v256 t0 = Avx.mm256_xor_ps(a, c);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(c, c1);
						v256 t2 = Avx.mm256_or_ps(b, t1);
						v256 t3 = Avx.mm256_andnot_ps(t0, t2);
						return t3;
					}
					case 0x86:
					{
						v256 t0 = Avx.mm256_or_ps(b, c);
						v256 t1 = Avx.mm256_xor_ps(a, b);
						v256 t2 = Avx.mm256_xor_ps(c, t1);
						v256 t3 = Avx.mm256_and_ps(t0, t2);
						return t3;
					}
					case 0x87:
					{
						v256 t0 = Avx.mm256_and_ps(b, c);
						v256 t1 = Avx.mm256_xor_ps(a, t0);
						v256 c1 = mm256_setall_ps();
						v256 t2 = Avx.mm256_xor_ps(t1, c1);
						return t2;
					}
					case 0x88:
					{
						v256 t0 = Avx.mm256_and_ps(c, b);
						return t0;
					}
					case 0x89:
					{
						v256 t0 = Avx.mm256_xor_ps(b, c);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(a, c1);
						v256 t2 = Avx.mm256_or_ps(t1, b);
						v256 t3 = Avx.mm256_andnot_ps(t0, t2);
						return t3;
					}
					case 0x8A:
					{
						v256 t0 = Avx.mm256_andnot_ps(b, a);
						v256 t1 = Avx.mm256_andnot_ps(t0, c);
						return t1;
					}
					case 0x8B:
					{
						v256 t0 = Avx.mm256_and_ps(b, c);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(a, c1);
						v256 t2 = Avx.mm256_andnot_ps(b, t1);
						v256 t3 = Avx.mm256_or_ps(t0, t2);
						return t3;
					}
					case 0x8C:
					{
						v256 t0 = Avx.mm256_andnot_ps(c, a);
						v256 t1 = Avx.mm256_andnot_ps(t0, b);
						return t1;
					}
					case 0x8D:
					{
						v256 t0 = Avx.mm256_and_ps(c, b);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(a, c1);
						v256 t2 = Avx.mm256_andnot_ps(c, t1);
						v256 t3 = Avx.mm256_or_ps(t0, t2);
						return t3;
					}
					case 0x8E:
					{
						v256 t0 = Avx.mm256_and_ps(b, c);
						v256 t1 = Avx.mm256_xor_ps(b, c);
						v256 t2 = Avx.mm256_andnot_ps(a, t1);
						v256 t3 = Avx.mm256_or_ps(t0, t2);
						return t3;
					}
					case 0x8F:
					{
						v256 t0 = Avx.mm256_and_ps(b, c);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(a, c1);
						v256 t2 = Avx.mm256_or_ps(t0, t1);
						return t2;
					}
					case 0x90:
					{
						v256 t0 = Avx.mm256_xor_ps(b, c);
						v256 t1 = Avx.mm256_andnot_ps(t0, a);
						return t1;
					}
					case 0x91:
					{
						v256 t0 = Avx.mm256_xor_ps(b, c);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(b, c1);
						v256 t2 = Avx.mm256_or_ps(a, t1);
						v256 t3 = Avx.mm256_andnot_ps(t0, t2);
						return t3;
					}
					case 0x92:
					{
						v256 t0 = Avx.mm256_or_ps(a, c);
						v256 t1 = Avx.mm256_xor_ps(a, b);
						v256 t2 = Avx.mm256_xor_ps(c, t1);
						v256 t3 = Avx.mm256_and_ps(t0, t2);
						return t3;
					}
					case 0x93:
					{
						v256 t0 = Avx.mm256_and_ps(a, c);
						v256 t1 = Avx.mm256_xor_ps(b, t0);
						v256 c1 = mm256_setall_ps();
						v256 t2 = Avx.mm256_xor_ps(t1, c1);
						return t2;
					}
					case 0x94:
					{
						v256 t0 = Avx.mm256_or_ps(a, b);
						v256 t1 = Avx.mm256_xor_ps(a, c);
						v256 t2 = Avx.mm256_xor_ps(b, t1);
						v256 t3 = Avx.mm256_and_ps(t0, t2);
						return t3;
					}
					case 0x95:
					{
						v256 t0 = Avx.mm256_and_ps(b, a);
						v256 t1 = Avx.mm256_xor_ps(c, t0);
						v256 c1 = mm256_setall_ps();
						v256 t2 = Avx.mm256_xor_ps(t1, c1);
						return t2;
					}
					case 0x96:
					{
						v256 t0 = Avx.mm256_xor_ps(b, c);
						v256 t1 = Avx.mm256_xor_ps(a, t0);
						return t1;
					}
					case 0x97:
					{
						v256 t0 = Avx.mm256_xor_ps(b, c);
						v256 t1 = Avx.mm256_andnot_ps(t0, a);
						v256 t2 = Avx.mm256_and_ps(b, c);
						v256 c1 = mm256_setall_ps();
						v256 t3 = Avx.mm256_xor_ps(t2, c1);
						v256 t4 = Avx.mm256_andnot_ps(a, t3);
						v256 t5 = Avx.mm256_or_ps(t1, t4);
						return t5;
					}
					case 0x98:
					{
						v256 t0 = Avx.mm256_xor_ps(b, c);
						v256 t1 = Avx.mm256_or_ps(a, b);
						v256 t2 = Avx.mm256_andnot_ps(t0, t1);
						return t2;
					}
					case 0x99:
					{
						v256 t0 = Avx.mm256_xor_ps(c, b);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(t0, c1);
						return t1;
					}
					case 0x9A:
					{
						v256 t0 = Avx.mm256_andnot_ps(b, a);
						v256 t1 = Avx.mm256_xor_ps(t0, c);
						return t1;
					}
					case 0x9B:
					{
						v256 t0 = Avx.mm256_andnot_ps(a, c);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(c, c1);
						v256 t2 = Avx.mm256_xor_ps(b, t1);
						v256 t3 = Avx.mm256_or_ps(t0, t2);
						return t3;
					}
					case 0x9C:
					{
						v256 t0 = Avx.mm256_andnot_ps(c, a);
						v256 t1 = Avx.mm256_xor_ps(t0, b);
						return t1;
					}
					case 0x9D:
					{
						v256 t0 = Avx.mm256_andnot_ps(a, b);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(c, c1);
						v256 t2 = Avx.mm256_xor_ps(b, t1);
						v256 t3 = Avx.mm256_or_ps(t0, t2);
						return t3;
					}
					case 0x9E:
					{
						v256 t0 = Avx.mm256_and_ps(b, c);
						v256 t1 = Avx.mm256_xor_ps(a, b);
						v256 t2 = Avx.mm256_xor_ps(c, t1);
						v256 t3 = Avx.mm256_or_ps(t0, t2);
						return t3;
					}
					case 0x9F:
					{
						v256 t0 = Avx.mm256_xor_ps(b, c);
						v256 t1 = Avx.mm256_and_ps(a, t0);
						v256 c1 = mm256_setall_ps();
						v256 t2 = Avx.mm256_xor_ps(t1, c1);
						return t2;
					}
					case 0xA0:
					{
						v256 t0 = Avx.mm256_and_ps(c, a);
						return t0;
					}
					case 0xA1:
					{
						v256 t0 = Avx.mm256_xor_ps(a, c);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(b, c1);
						v256 t2 = Avx.mm256_or_ps(a, t1);
						v256 t3 = Avx.mm256_andnot_ps(t0, t2);
						return t3;
					}
					case 0xA2:
					{
						v256 t0 = Avx.mm256_andnot_ps(a, b);
						v256 t1 = Avx.mm256_andnot_ps(t0, c);
						return t1;
					}
					case 0xA3:
					{
						v256 t0 = Avx.mm256_and_ps(a, c);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(b, c1);
						v256 t2 = Avx.mm256_andnot_ps(a, t1);
						v256 t3 = Avx.mm256_or_ps(t0, t2);
						return t3;
					}
					case 0xA4:
					{
						v256 t0 = Avx.mm256_xor_ps(a, c);
						v256 t1 = Avx.mm256_or_ps(a, b);
						v256 t2 = Avx.mm256_andnot_ps(t0, t1);
						return t2;
					}
					case 0xA5:
					{
						v256 t0 = Avx.mm256_xor_ps(c, a);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(t0, c1);
						return t1;
					}
					case 0xA6:
					{
						v256 t0 = Avx.mm256_andnot_ps(a, b);
						v256 t1 = Avx.mm256_xor_ps(t0, c);
						return t1;
					}
					case 0xA7:
					{
						v256 t0 = Avx.mm256_andnot_ps(b, c);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(c, c1);
						v256 t2 = Avx.mm256_xor_ps(a, t1);
						v256 t3 = Avx.mm256_or_ps(t0, t2);
						return t3;
					}
					case 0xA8:
					{
						v256 t0 = Avx.mm256_or_ps(a, b);
						v256 t1 = Avx.mm256_and_ps(c, t0);
						return t1;
					}
					case 0xA9:
					{
						v256 t0 = Avx.mm256_or_ps(b, a);
						v256 t1 = Avx.mm256_xor_ps(c, t0);
						v256 c1 = mm256_setall_ps();
						v256 t2 = Avx.mm256_xor_ps(t1, c1);
						return t2;
					}
					case 0xAA:
					{
						return c;
					}
					case 0xAB:
					{
						v256 t0 = Avx.mm256_or_ps(b, a);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(t0, c1);
						v256 t2 = Avx.mm256_or_ps(c, t1);
						return t2;
					}
					case 0xAC:
					{
						v256 t0 = Avx.mm256_and_ps(a, c);
						v256 t1 = Avx.mm256_andnot_ps(a, b);
						v256 t2 = Avx.mm256_or_ps(t0, t1);
						return t2;
					}
					case 0xAD:
					{
						v256 t0 = Avx.mm256_and_ps(b, c);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(c, c1);
						v256 t2 = Avx.mm256_xor_ps(a, t1);
						v256 t3 = Avx.mm256_or_ps(t0, t2);
						return t3;
					}
					case 0xAE:
					{
						v256 t0 = Avx.mm256_andnot_ps(a, b);
						v256 t1 = Avx.mm256_or_ps(t0, c);
						return t1;
					}
					case 0xAF:
					{
						v256 c1 = mm256_setall_ps();
						v256 t0 = Avx.mm256_xor_ps(a, c1);
						v256 t1 = Avx.mm256_or_ps(c, t0);
						return t1;
					}
					case 0xB0:
					{
						v256 t0 = Avx.mm256_andnot_ps(c, b);
						v256 t1 = Avx.mm256_andnot_ps(t0, a);
						return t1;
					}
					case 0xB1:
					{
						v256 t0 = Avx.mm256_and_ps(c, a);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(b, c1);
						v256 t2 = Avx.mm256_andnot_ps(c, t1);
						v256 t3 = Avx.mm256_or_ps(t0, t2);
						return t3;
					}
					case 0xB2:
					{
						v256 t0 = Avx.mm256_and_ps(a, c);
						v256 t1 = Avx.mm256_and_ps(b, t0);
						v256 t2 = Avx.mm256_or_ps(a, c);
						v256 t3 = Avx.mm256_andnot_ps(b, t2);
						v256 t4 = Avx.mm256_or_ps(t1, t3);
						return t4;
					}
					case 0xB3:
					{
						v256 t0 = Avx.mm256_and_ps(a, c);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(b, c1);
						v256 t2 = Avx.mm256_or_ps(t0, t1);
						return t2;
					}
					case 0xB4:
					{
						v256 t0 = Avx.mm256_andnot_ps(c, b);
						v256 t1 = Avx.mm256_xor_ps(t0, a);
						return t1;
					}
					case 0xB5:
					{
						v256 t0 = Avx.mm256_andnot_ps(b, a);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(c, c1);
						v256 t2 = Avx.mm256_xor_ps(a, t1);
						v256 t3 = Avx.mm256_or_ps(t0, t2);
						return t3;
					}
					case 0xB6:
					{
						v256 t0 = Avx.mm256_and_ps(a, c);
						v256 t1 = Avx.mm256_xor_ps(a, b);
						v256 t2 = Avx.mm256_xor_ps(c, t1);
						v256 t3 = Avx.mm256_or_ps(t0, t2);
						return t3;
					}
					case 0xB7:
					{
						v256 t0 = Avx.mm256_xor_ps(a, c);
						v256 t1 = Avx.mm256_and_ps(b, t0);
						v256 c1 = mm256_setall_ps();
						v256 t2 = Avx.mm256_xor_ps(t1, c1);
						return t2;
					}
					case 0xB8:
					{
						v256 t0 = Avx.mm256_and_ps(b, c);
						v256 t1 = Avx.mm256_andnot_ps(b, a);
						v256 t2 = Avx.mm256_or_ps(t0, t1);
						return t2;
					}
					case 0xB9:
					{
						v256 t0 = Avx.mm256_and_ps(a, c);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(c, c1);
						v256 t2 = Avx.mm256_xor_ps(b, t1);
						v256 t3 = Avx.mm256_or_ps(t0, t2);
						return t3;
					}
					case 0xBA:
					{
						v256 t0 = Avx.mm256_andnot_ps(b, a);
						v256 t1 = Avx.mm256_or_ps(t0, c);
						return t1;
					}
					case 0xBB:
					{
						v256 c1 = mm256_setall_ps();
						v256 t0 = Avx.mm256_xor_ps(b, c1);
						v256 t1 = Avx.mm256_or_ps(c, t0);
						return t1;
					}
					case 0xBC:
					{
						v256 t0 = Avx.mm256_and_ps(a, c);
						v256 t1 = Avx.mm256_xor_ps(a, b);
						v256 t2 = Avx.mm256_or_ps(t0, t1);
						return t2;
					}
					case 0xBD:
					{
						v256 t0 = Avx.mm256_xor_ps(a, b);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(c, c1);
						v256 t2 = Avx.mm256_xor_ps(a, t1);
						v256 t3 = Avx.mm256_or_ps(t0, t2);
						return t3;
					}
					case 0xBE:
					{
						v256 t0 = Avx.mm256_xor_ps(b, a);
						v256 t1 = Avx.mm256_or_ps(c, t0);
						return t1;
					}
					case 0xBF:
					{
						v256 t0 = Avx.mm256_and_ps(b, a);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(t0, c1);
						v256 t2 = Avx.mm256_or_ps(c, t1);
						return t2;
					}
					case 0xC0:
					{
						v256 t0 = Avx.mm256_and_ps(b, a);
						return t0;
					}
					case 0xC1:
					{
						v256 t0 = Avx.mm256_xor_ps(a, b);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(c, c1);
						v256 t2 = Avx.mm256_or_ps(a, t1);
						v256 t3 = Avx.mm256_andnot_ps(t0, t2);
						return t3;
					}
					case 0xC2:
					{
						v256 t0 = Avx.mm256_xor_ps(a, b);
						v256 t1 = Avx.mm256_or_ps(a, c);
						v256 t2 = Avx.mm256_andnot_ps(t0, t1);
						return t2;
					}
					case 0xC3:
					{
						v256 t0 = Avx.mm256_xor_ps(b, a);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(t0, c1);
						return t1;
					}
					case 0xC4:
					{
						v256 t0 = Avx.mm256_andnot_ps(a, c);
						v256 t1 = Avx.mm256_andnot_ps(t0, b);
						return t1;
					}
					case 0xC5:
					{
						v256 t0 = Avx.mm256_and_ps(a, b);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(c, c1);
						v256 t2 = Avx.mm256_andnot_ps(a, t1);
						v256 t3 = Avx.mm256_or_ps(t0, t2);
						return t3;
					}
					case 0xC6:
					{
						v256 t0 = Avx.mm256_andnot_ps(a, c);
						v256 t1 = Avx.mm256_xor_ps(t0, b);
						return t1;
					}
					case 0xC7:
					{
						v256 t0 = Avx.mm256_andnot_ps(c, b);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(b, c1);
						v256 t2 = Avx.mm256_xor_ps(a, t1);
						v256 t3 = Avx.mm256_or_ps(t0, t2);
						return t3;
					}
					case 0xC8:
					{
						v256 t0 = Avx.mm256_or_ps(a, c);
						v256 t1 = Avx.mm256_and_ps(b, t0);
						return t1;
					}
					case 0xC9:
					{
						v256 t0 = Avx.mm256_or_ps(a, c);
						v256 t1 = Avx.mm256_xor_ps(b, t0);
						v256 c1 = mm256_setall_ps();
						v256 t2 = Avx.mm256_xor_ps(t1, c1);
						return t2;
					}
					case 0xCA:
					{
						v256 t0 = Avx.mm256_and_ps(a, b);
						v256 t1 = Avx.mm256_andnot_ps(a, c);
						v256 t2 = Avx.mm256_or_ps(t0, t1);
						return t2;
					}
					case 0xCB:
					{
						v256 t0 = Avx.mm256_and_ps(b, c);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(b, c1);
						v256 t2 = Avx.mm256_xor_ps(a, t1);
						v256 t3 = Avx.mm256_or_ps(t0, t2);
						return t3;
					}
					case 0xCC:
					{
						return b;
					}
					case 0xCD:
					{
						v256 t0 = Avx.mm256_or_ps(a, c);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(t0, c1);
						v256 t2 = Avx.mm256_or_ps(b, t1);
						return t2;
					}
					case 0xCE:
					{
						v256 t0 = Avx.mm256_andnot_ps(a, c);
						v256 t1 = Avx.mm256_or_ps(t0, b);
						return t1;
					}
					case 0xCF:
					{
						v256 c1 = mm256_setall_ps();
						v256 t0 = Avx.mm256_xor_ps(a, c1);
						v256 t1 = Avx.mm256_or_ps(b, t0);
						return t1;
					}
					case 0xD0:
					{
						v256 t0 = Avx.mm256_andnot_ps(b, c);
						v256 t1 = Avx.mm256_andnot_ps(t0, a);
						return t1;
					}
					case 0xD1:
					{
						v256 t0 = Avx.mm256_or_ps(b, c);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(t0, c1);
						v256 t2 = Avx.mm256_and_ps(a, b);
						v256 t3 = Avx.mm256_or_ps(t1, t2);
						return t3;
					}
					case 0xD2:
					{
						v256 t0 = Avx.mm256_andnot_ps(b, c);
						v256 t1 = Avx.mm256_xor_ps(t0, a);
						return t1;
					}
					case 0xD3:
					{
						v256 t0 = Avx.mm256_andnot_ps(c, a);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(b, c1);
						v256 t2 = Avx.mm256_xor_ps(a, t1);
						v256 t3 = Avx.mm256_or_ps(t0, t2);
						return t3;
					}
					case 0xD4:
					{
						v256 t0 = Avx.mm256_andnot_ps(c, b);
						v256 t1 = Avx.mm256_xor_ps(b, c);
						v256 t2 = Avx.mm256_andnot_ps(t1, a);
						v256 t3 = Avx.mm256_or_ps(t0, t2);
						return t3;
					}
					case 0xD5:
					{
						v256 t0 = Avx.mm256_and_ps(a, b);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(c, c1);
						v256 t2 = Avx.mm256_or_ps(t0, t1);
						return t2;
					}
					case 0xD6:
					{
						v256 t0 = Avx.mm256_and_ps(a, b);
						v256 t1 = Avx.mm256_xor_ps(a, c);
						v256 t2 = Avx.mm256_xor_ps(b, t1);
						v256 t3 = Avx.mm256_or_ps(t0, t2);
						return t3;
					}
					case 0xD7:
					{
						v256 t0 = Avx.mm256_xor_ps(b, a);
						v256 t1 = Avx.mm256_and_ps(c, t0);
						v256 c1 = mm256_setall_ps();
						v256 t2 = Avx.mm256_xor_ps(t1, c1);
						return t2;
					}
					case 0xD8:
					{
						v256 t0 = Avx.mm256_and_ps(c, b);
						v256 t1 = Avx.mm256_andnot_ps(c, a);
						v256 t2 = Avx.mm256_or_ps(t0, t1);
						return t2;
					}
					case 0xD9:
					{
						v256 t0 = Avx.mm256_and_ps(a, b);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(c, c1);
						v256 t2 = Avx.mm256_xor_ps(b, t1);
						v256 t3 = Avx.mm256_or_ps(t0, t2);
						return t3;
					}
					case 0xDA:
					{
						v256 t0 = Avx.mm256_and_ps(a, b);
						v256 t1 = Avx.mm256_xor_ps(a, c);
						v256 t2 = Avx.mm256_or_ps(t0, t1);
						return t2;
					}
					case 0xDB:
					{
						v256 t0 = Avx.mm256_xor_ps(a, c);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(b, c1);
						v256 t2 = Avx.mm256_xor_ps(a, t1);
						v256 t3 = Avx.mm256_or_ps(t0, t2);
						return t3;
					}
					case 0xDC:
					{
						v256 t0 = Avx.mm256_andnot_ps(c, a);
						v256 t1 = Avx.mm256_or_ps(t0, b);
						return t1;
					}
					case 0xDD:
					{
						v256 c1 = mm256_setall_ps();
						v256 t0 = Avx.mm256_xor_ps(c, c1);
						v256 t1 = Avx.mm256_or_ps(b, t0);
						return t1;
					}
					case 0xDE:
					{
						v256 t0 = Avx.mm256_xor_ps(a, c);
						v256 t1 = Avx.mm256_or_ps(b, t0);
						return t1;
					}
					case 0xDF:
					{
						v256 t0 = Avx.mm256_and_ps(a, c);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(t0, c1);
						v256 t2 = Avx.mm256_or_ps(b, t1);
						return t2;
					}
					case 0xE0:
					{
						v256 t0 = Avx.mm256_or_ps(b, c);
						v256 t1 = Avx.mm256_and_ps(a, t0);
						return t1;
					}
					case 0xE1:
					{
						v256 t0 = Avx.mm256_or_ps(b, c);
						v256 t1 = Avx.mm256_xor_ps(a, t0);
						v256 c1 = mm256_setall_ps();
						v256 t2 = Avx.mm256_xor_ps(t1, c1);
						return t2;
					}
					case 0xE2:
					{
						v256 t0 = Avx.mm256_and_ps(b, a);
						v256 t1 = Avx.mm256_andnot_ps(b, c);
						v256 t2 = Avx.mm256_or_ps(t0, t1);
						return t2;
					}
					case 0xE3:
					{
						v256 t0 = Avx.mm256_and_ps(a, c);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(b, c1);
						v256 t2 = Avx.mm256_xor_ps(a, t1);
						v256 t3 = Avx.mm256_or_ps(t0, t2);
						return t3;
					}
					case 0xE4:
					{
						v256 t0 = Avx.mm256_and_ps(c, a);
						v256 t1 = Avx.mm256_andnot_ps(c, b);
						v256 t2 = Avx.mm256_or_ps(t0, t1);
						return t2;
					}
					case 0xE5:
					{
						v256 t0 = Avx.mm256_and_ps(a, b);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(c, c1);
						v256 t2 = Avx.mm256_xor_ps(a, t1);
						v256 t3 = Avx.mm256_or_ps(t0, t2);
						return t3;
					}
					case 0xE6:
					{
						v256 t0 = Avx.mm256_and_ps(a, b);
						v256 t1 = Avx.mm256_xor_ps(b, c);
						v256 t2 = Avx.mm256_or_ps(t0, t1);
						return t2;
					}
					case 0xE7:
					{
						v256 t0 = Avx.mm256_xor_ps(b, c);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(b, c1);
						v256 t2 = Avx.mm256_xor_ps(a, t1);
						v256 t3 = Avx.mm256_or_ps(t0, t2);
						return t3;
					}
					case 0xE8:
					{
						v256 t0 = Avx.mm256_and_ps(b, c);
						v256 t1 = Avx.mm256_xor_ps(b, c);
						v256 t2 = Avx.mm256_and_ps(a, t1);
						v256 t3 = Avx.mm256_or_ps(t0, t2);
						return t3;
					}
					case 0xE9:
					{
						v256 t0 = Avx.mm256_and_ps(a, b);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(c, c1);
						v256 t2 = Avx.mm256_xor_ps(a, t1);
						v256 t3 = Avx.mm256_xor_ps(b, t2);
						v256 t4 = Avx.mm256_or_ps(t0, t3);
						return t4;
					}
					case 0xEA:
					{
						v256 t0 = Avx.mm256_and_ps(b, a);
						v256 t1 = Avx.mm256_or_ps(c, t0);
						return t1;
					}
					case 0xEB:
					{
						v256 t0 = Avx.mm256_xor_ps(b, a);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(t0, c1);
						v256 t2 = Avx.mm256_or_ps(c, t1);
						return t2;
					}
					case 0xEC:
					{
						v256 t0 = Avx.mm256_and_ps(a, c);
						v256 t1 = Avx.mm256_or_ps(b, t0);
						return t1;
					}
					case 0xED:
					{
						v256 t0 = Avx.mm256_xor_ps(a, c);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(t0, c1);
						v256 t2 = Avx.mm256_or_ps(b, t1);
						return t2;
					}
					case 0xEE:
					{
						v256 t0 = Avx.mm256_or_ps(c, b);
						return t0;
					}
					case 0xEF:
					{
						v256 c1 = mm256_setall_ps();
						v256 t0 = Avx.mm256_xor_ps(a, c1);
						v256 t1 = Avx.mm256_or_ps(t0, c);
						v256 t2 = Avx.mm256_or_ps(b, t1);
						return t2;
					}
					case 0xF0:
					{
						return a;
					}
					case 0xF1:
					{
						v256 t0 = Avx.mm256_or_ps(b, c);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(t0, c1);
						v256 t2 = Avx.mm256_or_ps(a, t1);
						return t2;
					}
					case 0xF2:
					{
						v256 t0 = Avx.mm256_andnot_ps(b, c);
						v256 t1 = Avx.mm256_or_ps(t0, a);
						return t1;
					}
					case 0xF3:
					{
						v256 c1 = mm256_setall_ps();
						v256 t0 = Avx.mm256_xor_ps(b, c1);
						v256 t1 = Avx.mm256_or_ps(a, t0);
						return t1;
					}
					case 0xF4:
					{
						v256 t0 = Avx.mm256_andnot_ps(c, b);
						v256 t1 = Avx.mm256_or_ps(t0, a);
						return t1;
					}
					case 0xF5:
					{
						v256 c1 = mm256_setall_ps();
						v256 t0 = Avx.mm256_xor_ps(c, c1);
						v256 t1 = Avx.mm256_or_ps(a, t0);
						return t1;
					}
					case 0xF6:
					{
						v256 t0 = Avx.mm256_xor_ps(b, c);
						v256 t1 = Avx.mm256_or_ps(a, t0);
						return t1;
					}
					case 0xF7:
					{
						v256 t0 = Avx.mm256_and_ps(b, c);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(t0, c1);
						v256 t2 = Avx.mm256_or_ps(a, t1);
						return t2;
					}
					case 0xF8:
					{
						v256 t0 = Avx.mm256_and_ps(b, c);
						v256 t1 = Avx.mm256_or_ps(a, t0);
						return t1;
					}
					case 0xF9:
					{
						v256 t0 = Avx.mm256_xor_ps(b, c);
						v256 c1 = mm256_setall_ps();
						v256 t1 = Avx.mm256_xor_ps(t0, c1);
						v256 t2 = Avx.mm256_or_ps(a, t1);
						return t2;
					}
					case 0xFA:
					{
						v256 t0 = Avx.mm256_or_ps(c, a);
						return t0;
					}
					case 0xFB:
					{
						v256 c1 = mm256_setall_ps();
						v256 t0 = Avx.mm256_xor_ps(b, c1);
						v256 t1 = Avx.mm256_or_ps(t0, c);
						v256 t2 = Avx.mm256_or_ps(a, t1);
						return t2;
					}
					case 0xFC:
					{
						v256 t0 = Avx.mm256_or_ps(b, a);
						return t0;
					}
					case 0xFD:
					{
						v256 c1 = mm256_setall_ps();
						v256 t0 = Avx.mm256_xor_ps(c, c1);
						v256 t1 = Avx.mm256_or_ps(b, t0);
						v256 t2 = Avx.mm256_or_ps(a, t1);
						return t2;
					}
					case 0xFE:
					{
						v256 t0 = Avx.mm256_or_ps(b, c);
						v256 t1 = Avx.mm256_or_ps(a, t0);
						return t1;
					}
					case 0xFF:
					{
						v256 c1 = mm256_setall_ps();
						return c1;
					}

					default: return default(v256);
				}
			}
			else throw new IllegalInstructionException();
        }
    }
}
