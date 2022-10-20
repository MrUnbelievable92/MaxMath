using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public partial struct UInt128
    {
        internal static partial class __const
        {
            internal struct __magic128 
            {
                internal UInt128 mul;
                internal bool add;
                internal int shift;
            }
    
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static __magic128 getmagic_divuint128(UInt128 d) 
            {
                UInt128 nc, delta, q1, r1, q2, r2;
                __magic128 magu = default;
    
                int p = 127;
                nc = UInt128.MaxValue - ((UInt128)(-(Int128)d)) % d;
                q1 = UInt128.Common.divuint128(((UInt128)1 << 127) , nc);
                r1 = ((UInt128)1 << 127) - (q1 * nc);
                q2 = UInt128.Common.divuint128((((UInt128)1 << 127) - 1) , d);
                r2 = (((UInt128)1 << 127) - 1) - q2 * d;
    
                do 
                {
                    p++;
    
                    if (r1 >= nc - r1) 
                    {
                         q1 = (2 * q1) + 1;
                         r1 = (2 * r1) - nc;
                    }
                    else 
                    {
                         q1 *= 2;
                         r1 *= 2;
                    }
    
                    if (r2 + 1 >= d - r2) 
                    {
                         if (q2 >= (((UInt128)1 << 127) - 1)) 
                         {
                             magu.add = true;
                         }
    
                         q2 = (2 * q2) + 1;
                         r2 = (2 * r2) + 1 - d;
                    }
                    else 
                    {
                         if (q2 >= ((UInt128)1 << 127)) 
                         {
                             magu.add = true;
                         }
    
                         q2 *= 2;
                         r2 = (2 * r2) + 1;
                    }
                    delta = d - 1 - r2;
                } 
                while (p < 256 && (q1 < delta || (q1 == delta && r1 == 0)));
    
                magu.mul = q2 + 1;
                magu.shift = p - 128;
    
                return magu;
            }
    
            internal static UInt128 divuint128(UInt128 left, UInt128 right)
            {
                if (right == 1) return left;
                if (right == UInt128.MaxValue) return maxmath.touint128(left == UInt128.MaxValue);
    
    
                __magic128 m = getmagic_divuint128(right);
                Common.umul256(left, m.mul, out UInt128 hi, lo:false);
    
                if (m.add && m.shift > 0)
                {
                    UInt128 t = left - hi;
                    t >>= 1;
                    hi += t;
                    hi >>= (m.shift - 1);
                    
                    return hi;
                }
                else 
                {
                    return hi >> m.shift; 
                }
            }

            internal static UInt128 divrem10(UInt128 x, out ulong rem)
            {
                UInt128 mul = new UInt128(0xCCCC_CCCC_CCCC_CCCD, 0xCCCC_CCCC_CCCC_CCCC);
                Common.umul256(x, mul, out UInt128 hi, lo: false);
                UInt128 q = hi >> 3;

                UInt128 q10 = __const.shluint128(q, 3) + __const.shluint128(q, 1);

                rem = (x - q10).lo64;
                return q;
            }
        }
    }
}