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
                ////10
                //UInt128 mul = new UInt128(0x6666_6666_6666_6667, 0x6666_6666_6666_6666),
                //umul256(left, mul, out UInt128 hi, lo:false);
                //return hi >> 2;
                //
                ////100
                //UInt128 mul = new UInt128(0x8F5C_28F5_C28F_5C29, 0x28F5_C28F_5C28_F5C2),
                //umul256(left, mul, out UInt128 hi, lo:false);
                //return hi >> 4;
                //
                ////1000
                //UInt128 mul = new UInt128(0xB22D_0E56_0418_9375, 0x4189_374B_C6A7_EF9D),
                //umul256(left, mul, out UInt128 hi, lo:false);
                //return hi >> 8;
                //
                ////10000
                //UInt128 mul = new UInt128(0xF4F0_D844_D013_A92B, 0x346D_C5D6_3886_594A),
                //umul256(left, mul, out UInt128 hi, lo:false);
                //return hi >> 11;
                //
                ////100000
                //UInt128 mul = new UInt128(0xC3F3_E037_0CDC_8755, 0x29F1_6B11_C6D1_E108),
                //umul256(left, mul, out UInt128 hi, lo:false);
                //return hi >> 14;
                //
                ////1000000
                //UInt128 mul = new UInt128(0x5A63_F9A4_9C2C_1B11, 0x0863_7BD0_5AF6_C69B),
                //umul256(left, mul, out UInt128 hi, lo:false);
                //return hi >> 15;
                //
                ////10000000
                //UInt128 mul = new UInt128(0x1E99_483B_0234_8DA7, 0x6B5F_CA6A_F2BD_215E),
                //umul256(left, mul, out UInt128 hi, lo:false);
                //return hi >> 22;
                //
                ////100000000
                //UInt128 mul = new UInt128(0x7EE1_0695_9B5D_3E1F, 0x55E6_3B88_C230_E77E),
                //umul256(left, mul, out UInt128 hi, lo:false);
                //return hi >> 25;
                //
                ////1000000000
                //UInt128 mul = new UInt128(0x98B4_0544_7C4A_9819, 0x44B8_2FA0_9B5A_52CB),
                //umul256(left, mul, out UInt128 hi, lo:false);
                //return hi >> 28;
                //
                ////10000000000
                //UInt128 mul = new UInt128(0xAD5C_D103_96A2_1347, 0x36F9_BFB3_AF7B_756F),
                //umul256(left, mul, out UInt128 hi, lo:false);
                //return hi >> 31;
                //
                ////100000000000
                //UInt128 mul = new UInt128(0x7BC7_B4D2_8A9C_EBA5, 0x57F5_FF85_E592_557F),
                //umul256(left, mul, out UInt128 hi, lo:false);
                //return hi >> 35;
                //
                ////1000000000000
                //UInt128 mul = new UInt128(0xFE4F_E1ED_D10B_9175, 0x232F_3302_5BD4_2232),
                //umul256(left, mul, out UInt128 hi, lo:false);
                //return hi >> 37;
                //
                ////10000000000000
                //UInt128 mul = new UInt128(0xCA19_697C_81AC_1BEF, 0x384B_84D0_92ED_0384),
                //umul256(left, mul, out UInt128 hi, lo:false);
                //return hi >> 41;
                //
                ////100000000000000
                //UInt128 mul = new UInt128(0xA9C2_4260_CF79_C64B, 0x5A12_6E1A_84AE_6C07),
                //umul256(left, mul, out UInt128 hi, lo:false);
                //return hi >> 45;
                //
                ////1000000000000000
                //UInt128 mul = new UInt128(0x87CE_9B80_A5FB_0509, 0x480E_BE7B_9D58_566C),
                //umul256(left, mul, out UInt128 hi, lo:false);
                //return hi >> 48;
                //
                ////10000000000000000
                //UInt128 mul = new UInt128(0xD30B_AF9A_1E62_6A6D, 0x39A5_652F_B113_7856),
                //umul256(left, mul, out UInt128 hi, lo:false);
                //return hi >> 51;
                //
                ////100000000000000000
                //UInt128 mul = new UInt128(0x426F_BFAE_7EB5_21F1, 0x2E1D_EA8C_8DA9_2D12),
                //umul256(left, mul, out UInt128 hi, lo:false);
                //return hi >> 54;
                //
                ////1000000000000000000
                //UInt128 mul = new UInt128(0x73AF_F322_E624_39FD, 0x0939_2EE8_E921_D5D0),
                //umul256(left, mul, out UInt128 hi, lo:false);
                //return hi >> 55;
                //
                ////10000000000000000000
                //UInt128 mul = new UInt128(0x9598_F4F1_E836_1973, 0x760F_253E_DB4A_B0D2),
                //umul256(left, mul, out UInt128 hi, lo:false);
                //return hi >> 62;
                //
                ////100000000000000000000
                //UInt128 mul = new UInt128(0x2F39_4219_2484_46BB, 0x0000_0000_0000_0000),
                //umul256(left, mul, out UInt128 hi, lo:false);
                //return hi >> 0;
                //
                ////1000000000000000000000
                //UInt128 mul = new UInt128(0x1DA0_5074_DA7B_EED4, 0x0000_0000_0000_0097),
                //umul256(left, mul, out UInt128 hi, lo:false);
                //return hi >> 13;
                //
                ////10000000000000000000000
                //UInt128 mul = new UInt128(0x5324_C68B_12DD_6339, 0xF1C9_0080_BAF7_2CB1),
                //umul256(left, mul, out UInt128 hi, lo:false);
                //return hi >> 73;
                //
                ////100000000000000000000000
                //UInt128 mul = new UInt128(0xDD6D_C14F_03C5_E0A5, 0x305B_6680_2564_A289),
                //umul256(left, mul, out UInt128 hi, lo:false);
                //return hi >> 74;
                //
                ////1000000000000000000000000
                //UInt128 mul = new UInt128(0xC492_6A96_7279_3543, 0x9ABE_14CD_4475_3B52),
                //umul256(left, mul, out UInt128 hi, lo:false);
                //return hi >> 79;
                //
                ////10000000000000000000000000
                //UInt128 mul = new UInt128(0x3A83_DDBD_83F5_2205, 0xF796_87AE_D3EE_C551),
                //umul256(left, mul, out UInt128 hi, lo:false);
                //return hi >> 83;
                //
                ////100000000000000000000000000
                //UInt128 mul = new UInt128(0x4A9B_257F_0195_40CF, 0x6309_0312_BB2C_4EED),
                //umul256(left, mul, out UInt128 hi, lo:false);
                //return hi >> 85;
                //
                ////1000000000000000000000000000
                //UInt128 mul = new UInt128(0x3BAF_5132_67AA_9A3F, 0x4F3A_68DB_C8F0_3F24),
                //umul256(left, mul, out UInt128 hi, lo:false);
                //return hi >> 88;
                //
                ////10000000000000000000000000000
                //UInt128 mul = new UInt128(0x8BCA_9D6E_1888_53FD, 0xFD87_B5F2_8300_CA0D),
                //umul256(left, mul, out UInt128 hi, lo:false);
                //return hi >> 93;
                //
                ////100000000000000000000000000000
                //UInt128 mul = new UInt128(0x096E_E458_13A0_4331, 0xCAD2_F7F5_359A_3B3E),
                //umul256(left, mul, out UInt128 hi, lo:false);
                //return hi >> 96;
                //
                ////1000000000000000000000000000000
                //UInt128 mul = new UInt128(0x424B_06F3_529A_051B, 0x4484_BFEE_BC29_F863),
                //umul256(left, mul, out UInt128 hi, lo:false);
                //UInt128 t = left - hi;
                //t >>= 1;
                //hi += t;
                //hi >>= 99;
                //
                //return hi;
                //
                ////10000000000000000000000000000000
                //UInt128 mul = new UInt128(0x01D5_9F29_0EE1_9DAF, 0x039D_6658_9687_F9E9),
                //umul256(left, mul, out UInt128 hi, lo:false);
                //UInt128 t = left - hi;
                //t >>= 1;
                //hi += t;
                //hi >>= 102;
                //
                //return hi;
                //
                ////100000000000000000000000000000000
                //UInt128 mul = new UInt128(0xCFBC_31DB_4B02_95E5, 0x9F62_3D5A_8A73_2974),
                //umul256(left, mul, out UInt128 hi, lo:false);
                //UInt128 t = left - hi;
                //t >>= 1;
                //hi += t;
                //hi >>= 106;
                //
                //return hi;
                //
                ////1000000000000000000000000000000000
                //UInt128 mul = new UInt128(0xECB1_AD8A_EACD_D58F, 0xA627_4BBD_D0FA_DD61),
                //umul256(left, mul, out UInt128 hi, lo:false);
                //return hi >> 109;
                //
                ////10000000000000000000000000000000000
                //UInt128 mul = new UInt128(0xBD5A_F13B_EF0B_113F, 0x84EC_3C97_DA62_4AB4),
                //umul256(left, mul, out UInt128 hi, lo:false);
                //return hi >> 112;
                //
                ////100000000000000000000000000000000000
                //UInt128 mul = new UInt128(0x955E_4EC6_4B44_E865, 0xD4AD_2DBF_C3D0_7787),
                //umul256(left, mul, out UInt128 hi, lo:false);
                //return hi >> 116;
                //
                ////1000000000000000000000000000000000000
                //UInt128 mul = new UInt128(0x6EF2_85E8_EAE8_5CF5, 0x5512_124C_B4B9_C969),
                //umul256(left, mul, out UInt128 hi, lo:false);
                //return hi >> 118;
                //
                ////10000000000000000000000000000000000000
                //UInt128 mul = new UInt128(0x7E50_D641_77DA_2E55, 0x881C_EA14_545C_7575),
                //umul256(left, mul, out UInt128 hi, lo:false);
                //return hi >> 122;
                //
                ////100000000000000000000000000000000000000
                //UInt128 mul = new UInt128(0xCB73_DE9A_C648_2511, 0x6CE3_EE76_A9E3_912A),
                //umul256(left, mul, out UInt128 hi, lo:false);
                //return hi >> 125;
            }
        }
    }
}