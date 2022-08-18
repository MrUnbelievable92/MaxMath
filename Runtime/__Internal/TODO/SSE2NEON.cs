//using System.Runtime.CompilerServices;
//using Unity.Burst.Intrinsics;
//
//using static Unity.Burst.Intrinsics.X86;
//
//namespace MaxMath.Intrinsics
//{
//    unsafe public static partial class SSE2NEON
//    {
//        [MethodImpl(MethodImplOptions.AggressiveInlining)]
//        public static void Hello()
//        {
//
//        }
//
//static v128 shuffle_ps_1032(v128 a, v128 b)
//{
//    v64 a32 = Arm.Neon.vget_high_f32(a);
//    v64 b10 = Arm.Neon.vget_low_f32(b);
//
//    return Arm.Neon.vcombine_f32(a32, b10);
//}
//
//static v128 shuffle_ps_2301(v128 a, v128 b)
//{
//    v64 a01 = Arm.Neon.vrev64_f32(Arm.Neon.vget_low_f32(a));
//    v64 b23 = Arm.Neon.vrev64_f32(Arm.Neon.vget_high_f32(b));
//
//    return Arm.Neon.vcombine_f32(a01, b23);
//}
//
//static v128 shuffle_ps_0321(v128 a, v128 b)
//{
//    v64 a21 = Arm.Neon.vget_high_f32(Arm.Neon.vextq_f32(a, a, 3));
//    v64 b03 = Arm.Neon.vget_low_f32(Arm.Neon.vextq_f32(b, b, 3));
//
//    return Arm.Neon.vcombine_f32(a21, b03);
//}
//
//static v128 shuffle_ps_2103(v128 a, v128 b)
//{
//    v64 a03 = Arm.Neon.vget_low_f32(Arm.Neon.vextq_f32(a, a, 3));
//    v64 b21 = Arm.Neon.vget_high_f32(Arm.Neon.vextq_f32(b, b, 3));
//
//    return Arm.Neon.vcombine_f32(a03, b21);
//}
//
//static v128 shuffle_ps_1010(v128 a, v128 b)
//{
//    v64 a10 = Arm.Neon.vget_low_f32(a);
//    v64 b10 = Arm.Neon.vget_low_f32(b);
//
//    return Arm.Neon.vcombine_f32(a10, b10);
//}
//
//static v128 shuffle_ps_1001(v128 a, v128 b)
//{
//    v64 a01 = Arm.Neon.vrev64_f32(Arm.Neon.vget_low_f32(a));
//    v64 b10 = Arm.Neon.vget_low_f32(b);
//    return Arm.Neon.vcombine_f32(a01, b10);
//}
//
//static v128 shuffle_ps_0101(v128 a, v128 b)
//{
//    v64 a01 = Arm.Neon.vrev64_f32(Arm.Neon.vget_low_f32(a));
//    v64 b01 = Arm.Neon.vrev64_f32(Arm.Neon.vget_low_f32(b));
//
//    return Arm.Neon.vcombine_f32(a01, b01);
//}
//
//static v128 shuffle_ps_3210(v128 a, v128 b)
//{
//    v64 a10 = Arm.Neon.vget_low_f32(a);
//    v64 b32 = Arm.Neon.vget_high_f32(b);
//
//    return Arm.Neon.vcombine_f32(a10, b32);
//}
//
//static v128 shuffle_ps_0011(v128 a, v128 b)
//{
//    v64 a11 = Arm.Neon.vdup_lane_f32(Arm.Neon.vget_low_f32(a), 1);
//    v64 b00 = Arm.Neon.vdup_lane_f32(Arm.Neon.vget_low_f32(b), 0);
//
//    return Arm.Neon.vcombine_f32(a11, b00);
//}
//
//static v128 shuffle_ps_0022(v128 a, v128 b)
//{
//    v64 a22 = Arm.Neon.vdup_lane_f32(Arm.Neon.vget_high_f32(a), 0);
//    v64 b00 = Arm.Neon.vdup_lane_f32(Arm.Neon.vget_low_f32(b), 0);
//
//    return Arm.Neon.vcombine_f32(a22, b00);
//}
//
//static v128 shuffle_ps_2200(v128 a, v128 b)
//{
//    v64 a00 = Arm.Neon.vdup_lane_f32(Arm.Neon.vget_low_f32(a), 0);
//    v64 b22 = Arm.Neon.vdup_lane_f32(Arm.Neon.vget_high_f32(b), 0);
//
//    return Arm.Neon.vcombine_f32(a00, b22);
//}
//
//static v128 shuffle_ps_3202(v128 a, v128 b)
//{
//    float a0 = Arm.Neon.vgetq_lane_f32(a, 0);
//    v64 a22 = Arm.Neon.vdup_lane_f32(Arm.Neon.vget_high_f32(a), 0);
//    v64 a02 = Arm.Neon.vset_lane_f32(a0, a22, 1);
//    v64 b32 = Arm.Neon.vget_high_f32(b);
//
//    return Arm.Neon.vcombine_f32(a02, b32);
//}
//
//static v128 shuffle_ps_1133(v128 a, v128 b)
//{
//    v64 a33 = Arm.Neon.vdup_lane_f32(Arm.Neon.vget_high_f32(a), 1);
//    v64 b11 = Arm.Neon.vdup_lane_f32(Arm.Neon.vget_low_f32(b), 1);
//
//    return Arm.Neon.vcombine_f32(a33, b11);
//}
//
//static v128 shuffle_ps_2010(v128 a, v128 b)
//{
//    v64 a10 = Arm.Neon.vget_low_f32(a);
//    float b2 = Arm.Neon.vgetq_lane_f32(b, 2);
//    v64 b00 = Arm.Neon.vdup_lane_f32(Arm.Neon.vget_low_f32(b), 0);
//    v64 b20 = Arm.Neon.vset_lane_f32(b2, b00, 1);
//
//    return Arm.Neon.vcombine_f32(a10, b20);
//}
//
//static v128 shuffle_ps_2001(v128 a, v128 b)
//{
//    v64 a01 = Arm.Neon.vrev64_f32(Arm.Neon.vget_low_f32(a));
//    float b2 = Arm.Neon.vgetq_lane_f32(b, 2);
//    v64 b00 = Arm.Neon.vdup_lane_f32(Arm.Neon.vget_low_f32(b), 0);
//    v64 b20 = Arm.Neon.vset_lane_f32(b2, b00, 1);
//
//    return Arm.Neon.vcombine_f32(a01, b20);
//}
//
//static v128 shuffle_ps_2032(v128 a, v128 b)
//{
//    v64 a32 = Arm.Neon.vget_high_f32(a);
//    float b2 = Arm.Neon.vgetq_lane_f32(b, 2);
//    v64 b00 = Arm.Neon.vdup_lane_f32(Arm.Neon.vget_low_f32(b), 0);
//    v64 b20 = Arm.Neon.vset_lane_f32(b2, b00, 1);
//    return Arm.Neon.vcombine_f32(a32, b20);
//}
//
//// Kahan summation for accurate summation of floating-point numbers.
//// http://blog.zachbjornson.com/2019/08/11/fast-float-summation.html
//static void _sse2neon_kadd_f32(float *sum, float *c, float y)
//{
//    y -= *c;
//    float t = *sum + y;
//    *c = (t - *sum) - y;
//    *sum = t;
//}
//
//
//static v128 shuffle_epi_1032(v128 a)
//{
//    v64 a32 = Arm.Neon.vget_high_s32(a);
//    v64 a10 = Arm.Neon.vget_low_s32(a);
//
//    return Arm.Neon.vcombine_s32(a32, a10);
//}
//
//static v128 shuffle_epi_2301(v128 a)
//{
//    v64 a01 = Arm.Neon.vrev64_s32(Arm.Neon.vget_low_s32(a));
//    v64 a23 = Arm.Neon.vrev64_s32(Arm.Neon.vget_high_s32(a));
//
//    return Arm.Neon.vcombine_s32(a01, a23);
//}
//
//static v128 shuffle_epi_0321(v128 a)
//{
//    return Arm.Neon.vextq_s32(a, a, 1);
//}
//
//static v128 shuffle_epi_2103(v128 a)
//{
//    return Arm.Neon.vextq_s32(a, a, 3);
//}
//
//static v128 shuffle_epi_1010(v128 a)
//{
//    v64 a10 = Arm.Neon.vget_low_s32(a);
//
//    return Arm.Neon.vcombine_s32(a10, a10);
//}
//
//static v128 shuffle_epi_1001(v128 a)
//{
//    v64 a01 = Arm.Neon.vrev64_s32(Arm.Neon.vget_low_s32(a));
//    v64 a10 = Arm.Neon.vget_low_s32(a);
//
//    return Arm.Neon.vcombine_s32(a01, a10);
//}
//
//static v128 shuffle_epi_0101(v128 a)
//{
//    v64 a01 = Arm.Neon.vrev64_s32(Arm.Neon.vget_low_s32(a));
//
//    return Arm.Neon.vcombine_s32(a01, a01);
//}
//
//static v128 shuffle_epi_2211(v128 a)
//{
//    v64 a11 = Arm.Neon.vdup_lane_s32(Arm.Neon.vget_low_s32(a), 1);
//    v64 a22 = Arm.Neon.vdup_lane_s32(Arm.Neon.vget_high_s32(a), 0);
//
//    return Arm.Neon.vcombine_s32(a11, a22);
//}
//
//static v128 shuffle_epi_0122(v128 a)
//{
//    v64 a22 = Arm.Neon.vdup_lane_s32(Arm.Neon.vget_high_s32(a), 0);
//    v64 a01 = Arm.Neon.vrev64_s32(Arm.Neon.vget_low_s32(a));
//
//    return Arm.Neon.vcombine_s32(a22, a01);
//}
//
//static v128 shuffle_epi_3332(v128 a)
//{
//    v64 a32 = Arm.Neon.vget_high_s32(a);
//    v64 a33 = Arm.Neon.vdup_lane_s32(Arm.Neon.vget_high_s32(a), 1);
//
//    return Arm.Neon.vcombine_s32(a32, a33);
//}
//
//static v128 shuffle_epi32_splat(v128 a, int imm8)                          
//{                                              
//    return Arm.Neon.vdupq_laneq_s32(a, imm8);
//}
//
//static v128 shuffle_ps_default(v128 a, v128 b, int imm8)
//{
//    v128 ret;
//    ret = Arm.Neon.vmovq_n_f32(Arm.Neon.vgetq_lane_f32(a, (imm8) & (0x3)));
//    ret = Arm.Neon.vsetq_lane_f32(Arm.Neon.vgetq_lane_f32(a, ((imm8) >> 2) & 0x3), ret, 1);                                                       
//    ret = Arm.Neon.vsetq_lane_f32(Arm.Neon.vgetq_lane_f32(b, ((imm8) >> 4) & 0x3), ret, 2);                                                       
//    ret = Arm.Neon.vsetq_lane_f32(Arm.Neon.vgetq_lane_f32(b, ((imm8) >> 6) & 0x3), ret, 3);     
//    
//    return ret;                                       
//}
//
//static v128 shufflelo_epi16_function(v128 a, int imm8)                                  
//{                                                           
//    v128 ret = a;                           
//    v64 lowBits = Arm.Neon.vget_low_s16(ret);                                
//    ret = Arm.Neon.vsetq_lane_s16(Arm.Neon.vget_lane_s16(lowBits, (imm8) & (0x3)), ret, 0);  
//    ret = Arm.Neon.vsetq_lane_s16(Arm.Neon.vget_lane_s16(lowBits, ((imm8) >> 2) & 0x3), ret, 1);                                              
//    ret = Arm.Neon.vsetq_lane_s16(Arm.Neon.vget_lane_s16(lowBits, ((imm8) >> 4) & 0x3), ret, 2);                                              
//    ret = Arm.Neon.vsetq_lane_s16(Arm.Neon.vget_lane_s16(lowBits, ((imm8) >> 6) & 0x3), ret, 3);   
//
//    return ret;
//}
//
//static v128 shufflehi_epi16_function(v128 a, int imm8)                                   
//{                                                            
//    v128 ret = a;                            
//    v64 highBits = Arm.Neon.vget_high_s16(ret);                               
//    ret = Arm.Neon.vsetq_lane_s16(Arm.Neon.vget_lane_s16(highBits, (imm8) & (0x3)), ret, 4);  
//    ret = Arm.Neon.vsetq_lane_s16(Arm.Neon.vget_lane_s16(highBits, ((imm8) >> 2) & 0x3), ret, 5);                                               
//    ret = Arm.Neon.vsetq_lane_s16(Arm.Neon.vget_lane_s16(highBits, ((imm8) >> 4) & 0x3), ret, 6);                                               
//    ret = Arm.Neon.vsetq_lane_s16(Arm.Neon.vget_lane_s16(highBits, ((imm8) >> 6) & 0x3), ret, 7);     
//    
//    return ret;                                        
//}
//
//static v128 add_ps(v128 a, v128 b)
//{
//    return Arm.Neon.vaddq_f32(a, b);
//}
//
//static v128 add_ss(v128 a, v128 b)
//{
//    float b0 = Arm.Neon.vgetq_lane_f32(b, 0);
//    v128 value = Arm.Neon.vsetq_lane_f32(b0, Arm.Neon.vdupq_n_f32(0), 0);
//    // the upper values in the result must be the remnants of <a>.
//    return Arm.Neon.vaddq_f32(a, value);
//}
//
//static v128 and_ps(v128 a, v128 b)
//{
//    return Arm.Neon.vandq_s32(a, b);
//}
//
//static v128 andnot_ps(v128 a, v128 b)
//{
//    return Arm.Neon.vbicq_s32(b, a);
//}
//
//static v64 avg_pu16(v64 a, v64 b)
//{
//    return Arm.Neon.vrhadd_u16(a, b);
//}
//
//static v64 avg_pu8(v64 a, v64 b)
//{
//    return Arm.Neon.vrhadd_u8(a, b);
//}
//
//static v128 cmpeq_ps(v128 a, v128 b)
//{
//    return Arm.Neon.vceqq_f32(a, b);
//}
//
//static v128 cmpeq_ss(v128 a, v128 b)
//{
//    return move_ss(a, cmpeq_ps(a, b));
//}
//
//static v128 cmpge_ps(v128 a, v128 b)
//{
//    return Arm.Neon.vcgeq_f32(a, b);
//}
//
//static v128 cmpge_ss(v128 a, v128 b)
//{
//    return move_ss(a, cmpge_ps(a, b));
//}
//
//static v128 cmpgt_ps(v128 a, v128 b)
//{
//    return Arm.Neon.vcgtq_f32(a, b);
//}
//
//static v128 cmpgt_ss(v128 a, v128 b)
//{
//    return move_ss(a, cmpgt_ps(a, b));
//}
//
//static v128 cmple_ps(v128 a, v128 b)
//{
//    return Arm.Neon.vcleq_f32(a, b);
//}
//
//static v128 cmple_ss(v128 a, v128 b)
//{
//    return move_ss(a, cmple_ps(a, b));
//}
//
//static v128 cmplt_ps(v128 a, v128 b)
//{
//    return Arm.Neon.vcltq_f32(a, b);
//}
//
//static v128 cmplt_ss(v128 a, v128 b)
//{
//    return move_ss(a, cmplt_ps(a, b));
//}
//
//static v128 cmpneq_ps(v128 a, v128 b)
//{
//    return Arm.Neon.vmvnq_u32(Arm.Neon.vceqq_f32(a, b));
//}
//
//static v128 cmpneq_ss(v128 a, v128 b)
//{
//    return move_ss(a, cmpneq_ps(a, b));
//}
//
//static v128 cmpnge_ps(v128 a, v128 b)
//{
//    return Arm.Neon.vmvnq_u32(Arm.Neon.vcgeq_f32(a, b));
//}
//
//static v128 cmpnge_ss(v128 a, v128 b)
//{
//    return move_ss(a, cmpnge_ps(a, b));
//}
//
//static v128 cmpngt_ps(v128 a, v128 b)
//{
//    return Arm.Neon.vmvnq_u32(Arm.Neon.vcgtq_f32(a, b));
//}
//
//static v128 cmpngt_ss(v128 a, v128 b)
//{
//    return move_ss(a, cmpngt_ps(a, b));
//}
//
//static v128 cmpnle_ps(v128 a, v128 b)
//{
//    return Arm.Neon.vmvnq_u32(Arm.Neon.vcleq_f32(a, b));
//}
//
//static v128 cmpnle_ss(v128 a, v128 b)
//{
//    return move_ss(a, cmpnle_ps(a, b));
//}
//
//static v128 cmpnlt_ps(v128 a, v128 b)
//{
//    return Arm.Neon.vmvnq_u32(Arm.Neon.vcltq_f32(a, b));
//}
//
//static v128 cmpnlt_ss(v128 a, v128 b)
//{
//    return move_ss(a, cmpnlt_ps(a, b));
//}
//
//static v128 cmpord_ps(v128 a, v128 b)
//{
//    v128 ceqaa = Arm.Neon.vceqq_f32(a, a);
//    v128 ceqbb = Arm.Neon.vceqq_f32(b, b);
//
//    return Arm.Neon.vandq_u32(ceqaa, ceqbb);
//}
//
//static v128 cmpord_ss(v128 a, v128 b)
//{
//    return move_ss(a, cmpord_ps(a, b));
//}
//
//static v128 cmpunord_ps(v128 a, v128 b)
//{
//    v128 f32a = Arm.Neon.vceqq_f32(a, a);
//    v128 f32b = Arm.Neon.vceqq_f32(b, b);
//
//    return Arm.Neon.vmvnq_u32(Arm.Neon.vandq_u32(f32a, f32b));
//}
//
//static v128 cmpunord_ss(v128 a, v128 b)
//{
//    return move_ss(a, cmpunord_ps(a, b));
//}
//
//static int comieq_ss(v128 a, v128 b)
//{
//    v128 a_eq_b = Arm.Neon.vceqq_f32(a, b);
//
//    return (int)Arm.Neon.vgetq_lane_u32(a_eq_b, 0) & 0x1;
//}
//
//static int comige_ss(v128 a, v128 b)
//{
//    v128 a_ge_b = Arm.Neon.vcgeq_f32(a, b);
//
//    return (int)Arm.Neon.vgetq_lane_u32(a_ge_b, 0) & 0x1;
//}
//
//static int comigt_ss(v128 a, v128 b)
//{
//    v128 a_gt_b = Arm.Neon.vcgtq_f32(a, b);
//
//    return (int)Arm.Neon.vgetq_lane_u32(a_gt_b, 0) & 0x1;
//}
//
//static int comile_ss(v128 a, v128 b)
//{
//    v128 a_le_b = Arm.Neon.vcleq_f32(a, b);
//
//    return (int)Arm.Neon.vgetq_lane_u32(a_le_b, 0) & 0x1;
//}
//
//static int comilt_ss(v128 a, v128 b)
//{
//    v128 a_lt_b = Arm.Neon.vcltq_f32(a, b);
//
//    return (int)Arm.Neon.vgetq_lane_u32(a_lt_b, 0) & 0x1;
//}
//
//static int comineq_ss(v128 a, v128 b)
//{
//    return 1 ^ comieq_ss(a, b);
//}
//
//static v128 cvt_pi2ps(v128 a, v64 b)
//{
//    return Arm.Neon.vcombine_f32(Arm.Neon.vcvt_f32_s32(b), Arm.Neon.vget_high_f32(a));
//}
//
//static v64 cvt_ps2pi(v128 a)
//{
//    return Arm.Neon.vget_low_s32(Arm.Neon.vcvtnq_s32_f32(Arm.Neon.vrndiq_f32(a)));
//}
//
//static v128 cvt_si2ss(v128 a, int b)
//{
//    return Arm.Neon.vsetq_lane_f32((float)b, a, 0);
//}
//
//static int cvt_ss2si(v128 a)
//{
//    return Arm.Neon.vgetq_lane_s32(Arm.Neon.vcvtnq_s32_f32(Arm.Neon.vrndiq_f32(a)), 0);
//}
//
//static v128 cvtpi16_ps(v64 a)
//{
//    return Arm.Neon.vcvtq_f32_s32(Arm.Neon.vmovl_s16(a));
//}
//
//static v128 cvtpi32_ps(v128 a, v64 b)
//{
//    return Arm.Neon.vcombine_f32(Arm.Neon.vcvt_f32_s32(b), Arm.Neon.vget_high_f32(a));
//}
//
//static v128 cvtpi32x2_ps(v64 a, v64 b)
//{
//    return Arm.Neon.vcvtq_f32_s32(Arm.Neon.vcombine_s32(a, b));
//}
//
//static v128 cvtpi8_ps(v64 a)
//{
//    return Arm.Neon.vcvtq_f32_s32(Arm.Neon.vmovl_s16(Arm.Neon.vget_low_s16(Arm.Neon.vmovl_s8(a))));
//}
//
//static v64 cvtps_pi16(v128 a)
//{
//    v128 i16Min = set_ps1((float)short.MinValue);
//    v128 i16Max = set_ps1((float)short.MaxValue);
//    v128 i32Max = set_ps1((float)int.MaxValue);
//    v128 maxMask = and_ps(cmpge_ps(a, i16Max), cmple_ps(a, i32Max));
//    v128 betweenMask = and_ps(cmpgt_ps(a, i16Min), cmplt_ps(a, i16Max));
//    v128 minMask = cmpeq_epi32(or_si128(maxMask, betweenMask), setzero_si128());
//    v128 max = and_si128(maxMask, set1_epi32(short.MaxValue));
//    v128 min = and_si128(minMask, set1_epi32(short.MinValue));
//    v128 cvt = and_si128(betweenMask, cvtps_epi32(a));
//    v128 res32 = or_si128(or_si128(max, min), cvt);
//
//    return Arm.Neon.vmovn_s32(res32);
//}
//
//static v64 cvtps_pi32(v128 a) 
//{
//    return cvt_ps2pi(a);
//}
//
//static v64 cvtps_pi8(v128 a)
//{
//    v128 i8Min = set_ps1((float)sbyte.MinValue);
//    v128 i8Max = set_ps1((float)sbyte.MaxValue);
//    v128 i32Max = set_ps1((float)int.MaxValue);
//    v128 maxMask = and_ps(cmpge_ps(a, i8Max), cmple_ps(a, i32Max));
//    v128 betweenMask = and_ps(cmpgt_ps(a, i8Min), cmplt_ps(a, i8Max));
//    v128 minMask = cmpeq_epi32(or_si128(maxMask, betweenMask), setzero_si128());
//    v128 max = and_si128(maxMask, set1_epi32(sbyte.MaxValue));
//    v128 min = and_si128(minMask, set1_epi32(sbyte.MinValue));
//    v128 cvt = and_si128(betweenMask, cvtps_epi32(a));
//    v128 res32 = or_si128(or_si128(max, min), cvt);
//    v64 res16 = Arm.Neon.vmovn_s32(res32);
//    v64 res8 = Arm.Neon.vmovn_s16(Arm.Neon.vcombine_s16(res16, res16));
//    uint* bitMask = stackalloc uint[2]{ 0xFFFF_FFFF, 0 };
//    v64 mask = Arm.Neon.vld1_u32(bitMask);
//
//    return Arm.Neon.vorr_s8(Arm.Neon.vand_s8(mask, res8), Arm.Neon.vdup_n_s8(0));
//}
//
//static v128 cvtpu16_ps(v64 a)
//{
//    return Arm.Neon.vcvtq_f32_u32(Arm.Neon.vmovl_u16(a));
//}
//
//static v128 cvtpu8_ps(v64 a)
//{
//    return Arm.Neon.vcvtq_f32_u32(Arm.Neon.vmovl_u16(Arm.Neon.vget_low_u16(Arm.Neon.vmovl_u8(a))));
//}
//
//static v128 cvtsi32_ss(v128 a, int b) 
//{
//    return cvt_si2ss(a, b);
//}
//
//static v128 cvtsi64_ss(v128 a, long b)
//{
//    return Arm.Neon.vsetq_lane_f32((float) b, a, 0);
//}
//
//static float cvtss_f32(v128 a)
//{
//    return Arm.Neon.vgetq_lane_f32(a, 0);
//}
//
//static int cvtss_si32(v128 a) 
//{
//    return cvt_ss2si(a);
//}
//
//static long cvtss_si64(v128 a)
//{
//    return (long)Arm.Neon.vgetq_lane_f32(Arm.Neon.vrndiq_f32(a), 0);
//}
//
//static v64 cvtt_ps2pi(v128 a)
//{
//    return Arm.Neon.vget_low_s32(Arm.Neon.vcvtq_s32_f32(a));
//}
//
//static int cvtt_ss2si(v128 a)
//{
//    return Arm.Neon.vgetq_lane_s32(Arm.Neon.vcvtq_s32_f32(a), 0);
//}
//
//static v64 cvttps_pi32(v128 a) 
//{
//    return cvtt_ps2pi(a);
//}
//
//static int cvttss_si32(v128 a)
//{
//    return cvtt_ss2si(a);
//}
//
//static long cvttss_si64(v128 a)
//{
//    return (long)Arm.Neon.vgetq_lane_f32(a, 0);
//}
//
//static v128 div_ps(v128 a, v128 b)
//{
//    return Arm.Neon.vdivq_f32(a, b);
//}
//
//static v128 div_ss(v128 a, v128 b)
//{
//    float value = Arm.Neon.vgetq_lane_f32(div_ps(a, b), 0);
//
//    return Arm.Neon.vsetq_lane_f32(value, a, 0);
//}
//
//static ushort extract_pi16(v64 a, int imm8)
//{
//    return Arm.Neon.vget_lane_u16(a, imm8);
//}
//
//static v128 insert_pi16(short a, v64 b, int imm8)                               
//{       
//    return Arm.Neon.vset_lane_s16(b, a, imm8); 
//}
//
//static v128 load_ps(float* p)
//{
//    return Arm.Neon.vld1q_f32(p);
//}
//
//static v128 load_ss(float* p)
//{
//    return Arm.Neon.vsetq_lane_f32(*p, Arm.Neon.vdupq_n_f32(0), 0);
//}
//
//static v128 loadr_ps(float* p)
//{
//    v128 v = Arm.Neon.vrev64q_f32(Arm.Neon.vld1q_f32(p));
//
//    return Arm.Neon.vextq_f32(v, v, 2);
//}
//
//static v128 loadu_ps(float* p)
//{
//    return Arm.Neon.vld1q_f32(p);
//}
//
//static v128 loadu_si16(void* p)
//{
//    return Arm.Neon.vsetq_lane_s16(*(short*)p, Arm.Neon.vdupq_n_s16(0), 0);
//}
//
//static v128 loadu_si64(void* p)
//{
//    return Arm.Neon.vcombine_s64(Arm.Neon.vld1_s64((long*)p), Arm.Neon.vdup_n_s64(0));
//}
//
//static void maskmove_si64(v64 a, v64 mask, byte* mem_addr)
//{
//    v64 shr_mask = Arm.Neon.vshr_n_s8(mask, 7);
//    v128 b = load_ps((float*)mem_addr);
//    v64 masked = Arm.Neon.vbsl_s8(shr_mask, a, Arm.Neon.vget_low_u64(b));
//    Arm.Neon.vst1_s8((sbyte*)mem_addr, masked);
//}
//
//static v64 max_pi16(v64 a, v64 b)
//{
//    return Arm.Neon.vmax_s16(a, b);
//}
//
//static v128 max_ps(v128 a, v128 b)
//{
//    return Arm.Neon.vmaxq_f32(a, b);
//}
//
//static v64 max_pu8(v64 a, v64 b)
//{
//    return Arm.Neon.vmax_u8(a, b);
//}
//
//static v128 max_ss(v128 a, v128 b)
//{
//    float value = Arm.Neon.vgetq_lane_f32(max_ps(a, b), 0);
//
//    return Arm.Neon.vsetq_lane_f32(value, a, 0);
//}
//
//static v64 min_pi16(v64 a, v64 b)
//{
//    return Arm.Neon.vmin_s16(a, b);
//}
//
//static v128 min_ps(v128 a, v128 b)
//{
//    return Arm.Neon.vminq_f32(a, b);
//}
//
//static v64 min_pu8(v64 a, v64 b)
//{
//    return Arm.Neon.vmin_u8(a, b);
//}
//
//static v128 min_ss(v128 a, v128 b)
//{
//    float value = Arm.Neon.vgetq_lane_f32(min_ps(a, b), 0);
//    return Arm.Neon.vsetq_lane_f32(value, a, 0);
//}
//
//static v128 move_ss(v128 a, v128 b)
//{
//    return Arm.Neon.vsetq_lane_f32(Arm.Neon.vgetq_lane_f32(b, 0), a, 0);
//}
//
//static v128 movehl_ps(v128 __A, v128 __B)
//{
//    v64 a32 = Arm.Neon.vget_high_f32(__A);
//    v64 b32 = Arm.Neon.vget_high_f32(__B);
//
//    return Arm.Neon.vcombine_f32(b32, a32);
//}
//
//static v128 movelh_ps(v128 __A, v128 __B)
//{
//    v64 a10 = Arm.Neon.vget_low_f32(__A);
//    v64 b10 = Arm.Neon.vget_low_f32(__B);
//
//    return Arm.Neon.vcombine_f32(a10, b10);
//}
//
//static int movemask_pi8(v64 a)
//{
//    v64 input = a;
//    v64 shift = new v64(0, 1, 2, 3, 4, 5, 6, 7);
//    v64 tmp = Arm.Neon.vshr_n_u8(input, 7);
//
//    return Arm.Neon.vaddv_u8(Arm.Neon.vshl_u8(tmp, shift));
//}
//
//static int movemask_ps(v128 a)
//{
//    v128 input = a;
//    v128 shift = new v128(0, 1, 2, 3);
//    v128 tmp = Arm.Neon.vshrq_n_u32(input, 31);
//
//    return (int)Arm.Neon.vaddvq_u32(Arm.Neon.vshlq_u32(tmp, shift));
//}
//
//static v128 mul_ps(v128 a, v128 b)
//{
//    return Arm.Neon.vmulq_f32(a, b);
//}
//
//static v128 mul_ss(v128 a, v128 b)
//{
//    return move_ss(a, mul_ps(a, b));
//}
//
//static v64 mulhi_pu16(v64 a, v64 b)
//{
//    return Arm.Neon.vshrn_n_u32(Arm.Neon.vmull_u16(a, b), 16);
//}
//
//static v128 or_ps(v128 a, v128 b)
//{
//    return Arm.Neon.vorrq_s32(a, b);
//}
//
//static v128 rcp_ps(v128 a)
//{
//    v128 recip = Arm.Neon.vrecpeq_f32(a);
//    recip = Arm.Neon.vmulq_f32(recip, Arm.Neon.vrecpsq_f32(recip, a));
//
//    return recip;
//}
//
//static v128 rcp_ss(v128 a)
//{
//    return move_ss(a, rcp_ps(a));
//}
//
//static v128 rsqrt_ps(v128 a)
//{
//    a = Arm.Neon.vrsqrteq_f32(a);
//
//    return a;
//}
//
//static v128 rsqrt_ss(v128 a)
//{
//    return Arm.Neon.vsetq_lane_f32(Arm.Neon.vgetq_lane_f32(rsqrt_ps(a), 0), a, 0);
//}
//
//static v64 sad_pu8(v64 a, v64 b)
//{
//    v64 t = Arm.Neon.vpaddl_u32(Arm.Neon.vpaddl_u16(Arm.Neon.vpaddl_u8(Arm.Neon.vabd_u8(a, b))));
//
//    return Arm.Neon.vset_lane_u16((ushort)Arm.Neon.vget_lane_u64(t, 0), Arm.Neon.vdup_n_u16(0), 0);
//}
//
//static v128 set_ps(float w, float z, float y, float x)
//{
//    float* res = stackalloc float[] {x, y, z, w};
//
//    return Arm.Neon.vld1q_f32(res);
//}
//
//static v128 set_ps1(float _w)
//{
//    return Arm.Neon.vdupq_n_f32(_w);
//}
//
//static v128 set_ss(float a)
//{
//    float* res = stackalloc float[] {a, 0, 0, 0};
//
//    return Arm.Neon.vld1q_f32(res);
//}
//
//static v128 set1_ps(float _w)
//{
//    return Arm.Neon.vdupq_n_f32(_w);
//}
//
//static v128 setr_ps(float w, float z, float y, float x)
//{
//    float* res = stackalloc float[] {w, z, y, x};
//    return Arm.Neon.vld1q_f32(res);
//}
//
//static v128 setzero_ps()
//{
//    return Arm.Neon.vdupq_n_f32(0);
//}
//
//static v64 shuffle_pi16(v64 a, int imm8)                                               
//{                                                            
//    v64 ret;                                                         
//    ret = Arm.Neon.vmov_n_s16(Arm.Neon.vget_lane_s16(a, (imm8) & (0x3))); 
//    ret = Arm.Neon.vset_lane_s16(Arm.Neon.vget_lane_s16(a, ((imm8) >> 2) & 0x3), ret, 1);                                                                
//    ret = Arm.Neon.vset_lane_s16(Arm.Neon.vget_lane_s16(a, ((imm8) >> 4) & 0x3), ret, 2);                                                                
//    ret = Arm.Neon.vset_lane_s16(Arm.Neon.vget_lane_s16(a, ((imm8) >> 6) & 0x3), ret, 3);                                                                
//    
//    return ret;
//}
//
//static v128 sqrt_ps(v128 a)
//{
//    return Arm.Neon.vsqrtq_f32(a);
//}
//
//static v128 sqrt_ss(v128 a)
//{
//    float value = Arm.Neon.vgetq_lane_f32(sqrt_ps(a), 0);
//
//    return Arm.Neon.vsetq_lane_f32(value, a, 0);
//}
//
//static void store_ps(float* p, v128 a)
//{
//    Arm.Neon.vst1q_f32(p, a);
//}
//
//static void store_ps1(float* p, v128 a)
//{
//    float a0 = Arm.Neon.vgetq_lane_f32(a, 0);
//
//    Arm.Neon.vst1q_f32(p, Arm.Neon.vdupq_n_f32(a0));
//}
//
//static void store_ss(float* p, v128 a)
//{
//    Arm.Neon.vst1q_lane_f32(p, a, 0);
//}
//
//static void storeh_pi(v64* p, v128 a)
//{
//    *p = Arm.Neon.vget_high_f32(a);
//}
//
//static void storel_pi(v64* p, v128 a)
//{
//    *p = Arm.Neon.vget_low_f32(a);
//}
//
//static void storer_ps(float* p, v128 a)
//{
//    v128 tmp = Arm.Neon.vrev64q_f32(a);
//    v128 rev = Arm.Neon.vextq_f32(tmp, tmp, 2);
//
//    Arm.Neon.vst1q_f32(p, rev);
//}
//
//static void storeu_ps(float* p, v128 a)
//{
//    Arm.Neon.vst1q_f32(p, a);
//}
//
//static void storeu_si16(void* p, v128 a)
//{
//    Arm.Neon.vst1q_lane_s16((short*)p, a, 0);
//}
//
//static void storeu_si64(void* p, v128 a)
//{
//    Arm.Neon.vst1q_lane_s64((long*)p, a, 0);
//}
//
//static void stream_pi(v64* p, v64 a)
//{
//    Arm.Neon.vst1_s64((long*) p, a);
//}
//
//static void stream_ps(float* p, v128 a)
//{
//    Arm.Neon.vst1q_f32(p, a);
//}
//
//static v128 sub_ps(v128 a, v128 b)
//{
//    return Arm.Neon.vsubq_f32(a, b);
//}
//
//static v128 sub_ss(v128 a, v128 b)
//{
//    return move_ss(a, sub_ps(a, b));
//}
//
//static v128 undefined_si128()
//{
//    v128 a;
//    v128* p = &a;
//    return a;
//}
//
//static v128 undefined_ps()
//{
//    v128 a;
//    v128* p = &a;
//    return a;
//}
//
//static v128 unpackhi_ps(v128 a, v128 b)
//{
//    return Arm.Neon.vzip2q_f32(a, b);
//}
//
//static v128 unpacklo_ps(v128 a, v128 b)
//{
//    return Arm.Neon.vzip1q_f32(a, b);
//}
//
//static v128 xor_ps(v128 a, v128 b)
//{
//    return Arm.Neon.veorq_s32(a, b);
//}
//
//static v128 add_epi16(v128 a, v128 b)
//{
//    return Arm.Neon.vaddq_s16(a, b);
//}
//
//static v128 add_epi32(v128 a, v128 b)
//{
//    return Arm.Neon.vaddq_s32(a, b);
//}
//
//static v128 add_epi64(v128 a, v128 b)
//{
//    return Arm.Neon.vaddq_s64(a, b);
//}
//
//static v128 add_epi8(v128 a, v128 b)
//{
//    return Arm.Neon.vaddq_s8(a, b);
//}
//
//static v128 add_pd(v128 a, v128 b)
//{
//    return Arm.Neon.vaddq_f64(a, b);
//}
//
//static v128 add_sd(v128 a, v128 b)
//{
//    return move_sd(a, add_pd(a, b));
//}
//
//static v64 add_si64(v64 a, v64 b)
//{
//    return Arm.Neon.vadd_s64(a, b);
//}
//
//static v128 adds_epi16(v128 a, v128 b)
//{
//    return Arm.Neon.vqaddq_s16(a, b);
//}
//
//static v128 adds_epi8(v128 a, v128 b)
//{
//    return Arm.Neon.vqaddq_s8(a, b);
//}
//
//static v128 adds_epu16(v128 a, v128 b)
//{
//    return Arm.Neon.vqaddq_u16(a, b);
//}
//
//static v128 adds_epu8(v128 a, v128 b)
//{
//    return Arm.Neon.vqaddq_u8(a, b);
//}
//
//static v128 and_pd(v128 a, v128 b)
//{
//    return Arm.Neon.vandq_s64(a, b);
//}
//
//static v128 and_si128(v128 a, v128 b)
//{
//    return Arm.Neon.vandq_s32(a, b);
//}
//
//static v128 andnot_pd(v128 a, v128 b)
//{
//    return Arm.Neon.vbicq_s64(b, a);
//}
//
//static v128 andnot_si128(v128 a, v128 b)
//{
//    return Arm.Neon.vbicq_s32(b, a);
//}
//
//static v128 avg_epu16(v128 a, v128 b)
//{
//    return Arm.Neon.vrhaddq_u16(a, b);
//}
//
//static v128 avg_epu8(v128 a, v128 b)
//{
//    return Arm.Neon.vrhaddq_u8(a, b);
//}
//
//static v128 bslli_si128(v128 a, int imm8) 
//{
//    return slli_si128(a, imm8);
//}
//        
//static v128 bsrli_si128(v128 a, int imm8) 
//{
//    return srli_si128(a, imm8);
//}
//
//static v128 cmpeq_epi16(v128 a, v128 b)
//{
//    return Arm.Neon.vceqq_s16(a, b);
//}
//
//static v128 cmpeq_epi32(v128 a, v128 b)
//{
//    return Arm.Neon.vceqq_s32(a, b);
//}
//
//static v128 cmpeq_epi8(v128 a, v128 b)
//{
//    return Arm.Neon.vceqq_s8(a, b);
//}
//
//static v128 cmpeq_pd(v128 a, v128 b)
//{
//    return Arm.Neon.vceqq_f64(a, b);
//}
//
//static v128 cmpeq_sd(v128 a, v128 b)
//{
//    return move_sd(a, cmpeq_pd(a, b));
//}
//
//static v128 cmpge_pd(v128 a, v128 b)
//{
//    return Arm.Neon.vcgeq_f64(a, b);
//}
//
//static v128 cmpge_sd(v128 a, v128 b)
//{
//    return move_sd(a, cmpge_pd(a, b));
//}
//
//static v128 cmpgt_epi16(v128 a, v128 b)
//{
//    return Arm.Neon.vcgtq_s16(a, b);
//}
//
//static v128 cmpgt_epi32(v128 a, v128 b)
//{
//    return Arm.Neon.vcgtq_s32(a, b);
//}
//
//static v128 cmpgt_epi8(v128 a, v128 b)
//{
//    return Arm.Neon.vcgtq_s8(a, b);
//}
//
//static v128 cmpgt_pd(v128 a, v128 b)
//{
//    return Arm.Neon.vcgtq_f64(a, b);
//}
//
//static v128 cmpgt_sd(v128 a, v128 b)
//{
//    return move_sd(a, cmpgt_pd(a, b));
//}
//
//static v128 cmple_pd(v128 a, v128 b)
//{
//    return Arm.Neon.vcleq_f64(a, b);
//}
//
//static v128 cmple_sd(v128 a, v128 b)
//{
//    return move_sd(a, cmple_pd(a, b));
//}
//
//static v128 cmplt_epi16(v128 a, v128 b)
//{
//    return Arm.Neon.vcltq_s16(a, b);
//}
//
//static v128 cmplt_epi32(v128 a, v128 b)
//{
//    return Arm.Neon.vcltq_s32(a, b);
//}
//
//static v128 cmplt_epi8(v128 a, v128 b)
//{
//    return Arm.Neon.vcltq_s8(a, b);
//}
//
//static v128 cmplt_pd(v128 a, v128 b)
//{
//    return Arm.Neon.vcltq_f64(a, b);
//}
//
//static v128 cmplt_sd(v128 a, v128 b)
//{
//    return move_sd(a, cmplt_pd(a, b));
//}
//
//static v128 cmpneq_pd(v128 a, v128 b)
//{
//    return Arm.Neon.vmvnq_s32(Arm.Neon.vceqq_f64(a, b));
//}
//
//static v128 cmpneq_sd(v128 a, v128 b)
//{
//    return move_sd(a, cmpneq_pd(a, b));
//}
//
//static v128 cmpnge_pd(v128 a, v128 b)
//{
//    return Arm.Neon.veorq_u64(Arm.Neon.vcgeq_f64(a, b), Arm.Neon.vdupq_n_u64(ulong.MaxValue));
//}
//
//static v128 cmpnge_sd(v128 a, v128 b)
//{
//    return move_sd(a, cmpnge_pd(a, b));
//}
//
//static v128 cmpngt_pd(v128 a, v128 b)
//{
//    return Arm.Neon.veorq_u64(Arm.Neon.vcgtq_f64(a, b), Arm.Neon.vdupq_n_u64(ulong.MaxValue));
//}
//
//static v128 cmpngt_sd(v128 a, v128 b)
//{
//    return move_sd(a, cmpngt_pd(a, b));
//}
//
//static v128 cmpnle_pd(v128 a, v128 b)
//{
//    return Arm.Neon.veorq_u64(Arm.Neon.vcleq_f64(a, b), Arm.Neon.vdupq_n_u64(ulong.MaxValue));
//}
//
//static v128 cmpnle_sd(v128 a, v128 b)
//{
//    return move_sd(a, cmpnle_pd(a, b));
//}
//
//static v128 cmpnlt_pd(v128 a, v128 b)
//{
//    return Arm.Neon.veorq_u64(Arm.Neon.vcltq_f64(a, b), Arm.Neon.vdupq_n_u64(ulong.MaxValue));
//}
//
//static v128 cmpnlt_sd(v128 a, v128 b)
//{
//    return move_sd(a, cmpnlt_pd(a, b));
//}
//
//static v128 cmpord_pd(v128 a, v128 b)
//{
//    v128 not_nan_a = Arm.Neon.vceqq_f64(a, a);
//    v128 not_nan_b = Arm.Neon.vceqq_f64(b, b);
//
//    return Arm.Neon.vandq_u64(not_nan_a, not_nan_b);
//}
//
//static v128 cmpord_sd(v128 a, v128 b)
//{
//    return move_sd(a, cmpord_pd(a, b));
//}
//
//static v128 cmpunord_pd(v128 a, v128 b)
//{
//    v128 not_nan_a = Arm.Neon.vceqq_f64(a, a);
//    v128 not_nan_b = Arm.Neon.vceqq_f64(b, b);
//
//    return Arm.Neon.vmvnq_s32(Arm.Neon.vandq_u64(not_nan_a, not_nan_b));
//}
//
//static v128 cmpunord_sd(v128 a, v128 b)
//{
//    return move_sd(a, cmpunord_pd(a, b));
//}
//
//static int comige_sd(v128 a, v128 b)
//{
//    return (int)Arm.Neon.vgetq_lane_u64(Arm.Neon.vcgeq_f64(a, b), 0) & 0x1;
//}
//
//static int comigt_sd(v128 a, v128 b)
//{
//    return (int)Arm.Neon.vgetq_lane_u64(Arm.Neon.vcgtq_f64(a, b), 0) & 0x1;
//}
//
//static int comile_sd(v128 a, v128 b)
//{
//    return (int)Arm.Neon.vgetq_lane_u64(Arm.Neon.vcleq_f64(a, b), 0) & 0x1;
//}
//
//static int comilt_sd(v128 a, v128 b)
//{
//    return (int)Arm.Neon.vgetq_lane_u64(Arm.Neon.vcltq_f64(a, b), 0) & 0x1;
//}
//
//static int comieq_sd(v128 a, v128 b)
//{
//    return (int)Arm.Neon.vgetq_lane_u64(Arm.Neon.vceqq_f64(a, b), 0) & 0x1;
//}
//
//static int comineq_sd(v128 a, v128 b)
//{
//    return 1 ^ comieq_sd(a, b);
//}
//
//static v128 cvtepi32_pd(v128 a)
//{
//    return Arm.Neon.vcvtq_f64_s64(Arm.Neon.vmovl_s32(Arm.Neon.vget_low_s32(a)));
//}
//
//static v128 cvtepi32_ps(v128 a)
//{
//    return Arm.Neon.vcvtq_f32_s32(a);
//}
//
////static v128 cvtpd_epi32(v128 a)
////{
////    v128 rnd = round_pd(a, FROUND_CUR_DIRECTION);
////    double d0 = ((double *) &rnd)[0];
////    double d1 = ((double *) &rnd)[1];
////    return set_epi32(0, 0, (int)d1, (int)d0);
////}
////
////static v64 cvtpd_pi32(v128 a)
////{
////    v128 rnd = round_pd(a, FROUND_CUR_DIRECTION);
////    double d0 = ((double *) &rnd)[0];
////    double d1 = ((double *) &rnd)[1];
////    int ALIGN_STRUCT(16) data[2] = {(int) d0, (int) d1};
////    return Arm.Neon.vld1_s32(data);
////}
//
//static v128 cvtpd_ps(v128 a)
//{
//    v64 tmp = Arm.Neon.vcvt_f32_f64(a);
//
//    return Arm.Neon.vcombine_f32(tmp, Arm.Neon.vdup_n_f32(0));
//}
//
//static v128 cvtpi32_pd(v64 a)
//{
//    return Arm.Neon.vcvtq_f64_s64(Arm.Neon.vmovl_s32(a));
//}
//
////static v128 cvtps_epi32(v128 a)
////{
////#if defined(__aarch64__) || defined(__ARM_FEATURE_DIRECTED_ROUNDING)
////    switch (_MM_GET_ROUNDING_MODE()) {
////    case ROUND_NEAREST:
////        return vreinterpretq_m128i_s32(vcvtnq_s32_f32(a));
////    case ROUND_DOWN:
////        return vreinterpretq_m128i_s32(vcvtmq_s32_f32(a));
////    case ROUND_UP:
////        return vreinterpretq_m128i_s32(vcvtpq_s32_f32(a));
////    default:  // ROUND_TOWARD_ZERO
////        return vreinterpretq_m128i_s32(vcvtq_s32_f32(a));
////    }
////#else
////    float *f = (float *) &a;
////    switch (_MM_GET_ROUNDING_MODE()) {
////    case ROUND_NEAREST: {
////        v128 signmask = vdupq_n_u32(0x80000000);
////        v128 half = vbslq_f32(signmask, a,
////                                     vdupq_n_f32(0.5f)); /* +/- 0.5 */
////        v128 r_normal = vcvtq_s32_f32(vaddq_f32(
////            a, half)); /* round to integer: [a + 0.5]*/
////        v128 r_trunc = vcvtq_s32_f32(
////            a); /* truncate to integer: [a] */
////        v128 plusone = vreinterpretq_s32_u32(vshrq_n_u32(
////            vreinterpretq_u32_s32(vnegq_s32(r_trunc)), 31)); /* 1 or 0 */
////        v128 r_even = vbicq_s32(vaddq_s32(r_trunc, plusone),
////                                     vdupq_n_s32(1)); /* ([a] + {0,1}) & ~1 */
////        v128 delta = vsubq_f32(
////            a,
////            vcvtq_f32_s32(r_trunc)); /* compute delta: delta = (a - [a]) */
////        v128 is_delta_half =
////            vceqq_f32(delta, half); /* delta == +/- 0.5 */
////        return vreinterpretq_m128i_s32(
////            vbslq_s32(is_delta_half, r_even, r_normal));
////    }
////    case ROUND_DOWN:
////        return set_epi32(floorf(f[3]), floorf(f[2]), floorf(f[1]),
////                             floorf(f[0]));
////    case ROUND_UP:
////        return set_epi32(ceilf(f[3]), ceilf(f[2]), ceilf(f[1]),
////                             ceilf(f[0]));
////    default:  // ROUND_TOWARD_ZERO
////        return set_epi32((int) f[3], (int) f[2], (int) f[1],
////                             (int) f[0]);
////    }
////#endif
////}
//
//static v128 cvtps_pd(v128 a)
//{
//    return Arm.Neon.vcvt_f64_f32(Arm.Neon.vget_low_f32(a));
//}
//
//static double cvtsd_f64(v128 a)
//{
//    return (double)Arm.Neon.vgetq_lane_f64(a, 0);
//}
//
//static int cvtsd_si32(v128 a)
//{
//    return (int)Arm.Neon.vgetq_lane_f64(Arm.Neon.vrndiq_f64(a), 0);
//}
//
//static long cvtsd_si64(v128 a)
//{
//    return (long)Arm.Neon.vgetq_lane_f64(Arm.Neon.vrndiq_f64(a), 0);
//}
//
//static long cvtsd_si64x(v128 a)
//{
//    return cvtsd_si64(a);
//}
//
//static v128 cvtsd_ss(v128 a, v128 b)
//{
//    return Arm.Neon.vsetq_lane_f32(Arm.Neon.vget_lane_f32(Arm.Neon.vcvt_f32_f64(b), 0), a, 0);
//}
//
//static int cvtsi128_si32(v128 a)
//{
//    return Arm.Neon.vgetq_lane_s32(a, 0);
//}
//
//static long cvtsi128_si64(v128 a)
//{
//    return Arm.Neon.vgetq_lane_s64(a, 0);
//}
//
//static long cvtsi128_si64x(v128 a)
//{
//    return cvtsi128_si64(a);
//}
//
//static v128 cvtsi32_sd(v128 a, int b)
//{
//    return Arm.Neon.vsetq_lane_f64((double) b, a, 0);
//}
//
//static v128 cvtsi32_si128(int a)
//{
//    return Arm.Neon.vsetq_lane_s32(a, Arm.Neon.vdupq_n_s32(0), 0);
//}
//
//static v128 cvtsi64_sd(v128 a, long b)
//{
//    return Arm.Neon.vsetq_lane_f64((double) b, a, 0);
//}
//
//static v128 cvtsi64_si128(long a)
//{
//    return Arm.Neon.vsetq_lane_s64(a, Arm.Neon.vdupq_n_s64(0), 0);
//}
//
//static v128 cvtsi64x_si128(long a)
//{
//    return cvtsi64_si128(a);
//}
//
//static v128 cvtsi64x_sd(long a)
//{
//    return cvtsi64_si128(a);
//}
//
//static v128 cvtss_sd(v128 a, v128 b)
//{
//    return Arm.Neon.vsetq_lane_f64(Arm.Neon.vgetq_lane_f32(b, 0), a, 0);
//}
//
//static v128 cvttpd_epi32(v128 a)
//{
//    return set_epi32(0, 0, (int)a.Double0, (int)a.Double1);
//}
//
//static v64 cvttpd_pi32(v128 a)
//{
//    int* p = stackalloc int[] { (int)a.Double0, (int)a.Double1 };
//
//    return Arm.Neon.vld1_s32(p);
//}
//
//static v128 cvttps_epi32(v128 a)
//{
//    return Arm.Neon.vcvtq_s32_f32(a);
//}
//
//static int cvttsd_si32(v128 a)
//{
//    return (int)a.Double0;
//}
//
//static long cvttsd_si64(v128 a)
//{
//    return Arm.Neon.vgetq_lane_s64(Arm.Neon.vcvtq_s64_f64(a), 0);
//}
//
//static long cvttsd_si64x(v128 a)
//{
//    return cvttsd_si64(a);
//}
//
//static v128 div_pd(v128 a, v128 b)
//{
//    return Arm.Neon.vdivq_f64(a, b);
//}
//
//static v128 div_sd(v128 a, v128 b)
//{
//    v128 tmp = Arm.Neon.vdivq_f64(a, b);
//
//    return Arm.Neon.vsetq_lane_f64(Arm.Neon.vgetq_lane_f64(a, 1), tmp, 1);
//}
//
//static ushort extract_epi16(v128 a, int imm8)
//{
//    return Arm.Neon.vgetq_lane_u16(a, imm8);
//}
//
//static v128 insert_epi16(v128 a, short b, int imm8)
//{
//    return Arm.Neon.vsetq_lane_s16(b, a, imm8);
//}
//
//static v128 load_pd(double* p)
//{
//    return Arm.Neon.vld1q_f64(p);
//}
//
//static v128 load_sd(double* p)
//{
//    return Arm.Neon.vsetq_lane_f64(*p, Arm.Neon.vdupq_n_f64(0), 0);
//}
//
//static v128 load_si128(v128* p)
//{
//    return Arm.Neon.vld1q_s32((int*)p);
//}
//
//static v128 load1_pd(double* p)
//{
//    return Arm.Neon.vld1q_dup_f64(p);
//}
//
//static v128 loadh_pd(v128 a, double* p)
//{
//    return Arm.Neon.vcombine_f64(Arm.Neon.vget_low_f64(a), Arm.Neon.vld1_f64(p));
//}
//
//static v128 loadl_epi64(v128* p)
//{
//    return Arm.Neon.vcombine_s32(Arm.Neon.vld1_s32((int*)p), Arm.Neon.vcreate_s32(0));
//}
//
//static v128 loadl_pd(v128 a, double* p)
//{
//    return Arm.Neon.vcombine_f64(Arm.Neon.vld1_f64(p), Arm.Neon.vget_high_f64(a));
//}
//
//static v128 loadr_pd(double* p)
//{
//    v128 v = Arm.Neon.vld1q_f64(p);
//    return Arm.Neon.vextq_f64(v, v, 1);
//}
//
//static v128 loadu_pd(double* p)
//{
//    return load_pd(p);
//}
//
//static v128 loadu_si128(v128* p)
//{
//    return Arm.Neon.vld1q_s32((int*)p);
//}
//
//static v128 loadu_si32(void* p)
//{
//    return Arm.Neon.vsetq_lane_s32(*(int*)p, Arm.Neon.vdupq_n_s32(0), 0);
//}
//
//static v128 madd_epi16(v128 a, v128 b)
//{
//    v128 low = Arm.Neon.vmull_s16(Arm.Neon.vget_low_s16(a), Arm.Neon.vget_low_s16(b));
//    v128 high = Arm.Neon.vmull_s16(Arm.Neon.vget_high_s16(a), Arm.Neon.vget_high_s16(b));
//
//    v64 low_sum = Arm.Neon.vpadd_s32(Arm.Neon.vget_low_s32(low), Arm.Neon.vget_high_s32(low));
//    v64 high_sum = Arm.Neon.vpadd_s32(Arm.Neon.vget_low_s32(high), Arm.Neon.vget_high_s32(high));
//
//    return Arm.Neon.vcombine_s32(low_sum, high_sum);
//}
//
//static void maskmoveu_si128(v128 a, v128 mask, byte *mem_addr)
//{
//    v128 shr_mask = Arm.Neon.vshrq_n_s8(mask, 7);
//    v128 b = load_ps((float*) mem_addr);
//    v128 masked = Arm.Neon.vbslq_s8(shr_mask, a, b);
//    Arm.Neon.vst1q_s8((sbyte*)mem_addr, masked);
//}
//
//static v128 max_epi16(v128 a, v128 b)
//{
//    return Arm.Neon.vmaxq_s16(a, b);
//}
//
//static v128 max_epu8(v128 a, v128 b)
//{
//    return Arm.Neon.vmaxq_u8(a, b);
//}
//
//static v128 max_pd(v128 a, v128 b)
//{
//    return Arm.Neon.vmaxq_f64(a, b);
//}
//
//static v128 max_sd(v128 a, v128 b)
//{
//    return move_sd(a, max_pd(a, b));
//}
//
//static v128 min_epi16(v128 a, v128 b)
//{
//    return Arm.Neon.vminq_s16(a, b);
//}
//
//static v128 min_epu8(v128 a, v128 b)
//{
//    return Arm.Neon.vminq_u8(a, b);
//}
//
//static v128 min_pd(v128 a, v128 b)
//{
//    return Arm.Neon.vminq_f64(a, b);
//}
//
//static v128 min_sd(v128 a, v128 b)
//{
//    return move_sd(a, min_pd(a, b));
//}
//
//static v128 move_epi64(v128 a)
//{
//    return Arm.Neon.vsetq_lane_s64(0, a, 1);
//}
//
//static v128 move_sd(v128 a, v128 b)
//{
//    return Arm.Neon.vcombine_f32(Arm.Neon.vget_low_f32(b), Arm.Neon.vget_high_f32(a));
//}
//
//static int movemask_epi8(v128 a)
//{
//    v128 input = a;
//
//    v128 high_bits = Arm.Neon.vshrq_n_u8(input, 7);
//    v128 paired16 = Arm.Neon.vsraq_n_u16(high_bits, high_bits, 7);
//    v128 paired32 = Arm.Neon.vsraq_n_u32(paired16, paired16, 14);
//    v128 paired64 = Arm.Neon.vsraq_n_u64(paired32, paired32, 28);
//
//    return Arm.Neon.vgetq_lane_u8(paired64, 0) | ((int)Arm.Neon.vgetq_lane_u8(paired64, 8) << 8);
//}
//
//static int movemask_pd(v128 a)
//{
//    v128 input = a;
//    v128 high_bits = Arm.Neon.vshrq_n_u64(input, 63);
//
//    return (int)(Arm.Neon.vgetq_lane_u64(high_bits, 0) | (Arm.Neon.vgetq_lane_u64(high_bits, 1) << 1));
//}
//
//static v64 movepi64_pi64(v128 a)
//{
//    return Arm.Neon.vget_low_s64(a);
//}
//
//static v128 movpi64_epi64(v64 a)
//{
//    return Arm.Neon.vcombine_s64(a, Arm.Neon.vdup_n_s64(0));
//}
//
//static v128 mul_epu32(v128 a, v128 b)
//{
//    v64 a_lo = Arm.Neon.vmovn_u64(a);
//    v64 b_lo = Arm.Neon.vmovn_u64(b);
//
//    return Arm.Neon.vmull_u32(a_lo, b_lo);
//}
//
//static v128 mul_pd(v128 a, v128 b)
//{
//    return Arm.Neon.vmulq_f64(a, b);
//}
//
//static v128 mul_sd(v128 a, v128 b)
//{
//    return move_sd(a, mul_pd(a, b));
//}
//
//static v64 mul_su32(v64 a, v64 b)
//{
//    return Arm.Neon.vget_low_u64(Arm.Neon.vmull_u32(a, b));
//}
//
//static v128 mulhi_epi16(v128 a, v128 b)
//{
//    v64 a3210 = Arm.Neon.vget_low_s16(a);
//    v64 b3210 = Arm.Neon.vget_low_s16(b);
//    v128 ab3210 = Arm.Neon.vmull_s16(a3210, b3210);
//    v64 a7654 = Arm.Neon.vget_high_s16(a);
//    v64 b7654 = Arm.Neon.vget_high_s16(b);
//    v128 ab7654 = Arm.Neon.vmull_s16(a7654, b7654);
//    uint16x8x2_t r = Arm.Neon.vuzpq_u16(ab3210, ab7654);
//    return r.val[1];
//}
//
//static v128 mulhi_epu16(v128 a, v128 b)
//{
//    v64 a3210 = Arm.Neon.vget_low_u16(a);
//    v64 b3210 = Arm.Neon.vget_low_u16(b);
//    v128 ab3210 = Arm.Neon.vmull_u16(a3210, b3210);
//    v128 ab7654 = Arm.Neon.vmull_high_u16(a, b);
//    v128 r = Arm.Neon.vuzp2q_u16(ab3210, ab7654);
//    return r;
//}
//
//static v128 mullo_epi16(v128 a, v128 b)
//{
//    return Arm.Neon.vmulq_s16(a, b);
//}
//
//static v128 or_pd(v128 a, v128 b)
//{
//    return Arm.Neon.vorrq_s64(a, b);
//}
//
//static v128 or_si128(v128 a, v128 b)
//{
//    return Arm.Neon.vorrq_s32(a, b);
//}
//
//static v128 packs_epi16(v128 a, v128 b)
//{
//    return Arm.Neon.vcombine_s8(Arm.Neon.vqmovn_s16(a), Arm.Neon.vqmovn_s16(b));
//}
//
//static v128 packs_epi32(v128 a, v128 b)
//{
//    return Arm.Neon.vcombine_s16(Arm.Neon.vqmovn_s32(a), Arm.Neon.vqmovn_s32(b));
//}
//
//static v128 packus_epi16(v128 a, v128 b)
//{
//    return Arm.Neon.vcombine_u8(Arm.Neon.vqmovun_s16(a), Arm.Neon.vqmovun_s16(b));
//}
//
//static v128 sad_epu8(v128 a, v128 b)
//{
//    v128 t = Arm.Neon.vpaddlq_u8(Arm.Neon.vabdq_u8(a, b));
//
//    return Arm.Neon.vpaddlq_u32(Arm.Neon.vpaddlq_u16(t));
//}
//
//static v128 set_epi16(short i7,
//                      short i6,
//                      short i5,
//                      short i4,
//                      short i3,
//                      short i2,
//                      short i1,
//                      short i0)
//{
//    short* p = stackalloc short[] { i0, i1, i2, i3, i4, i5, i6, i7 };
//
//    return Arm.Neon.vld1q_s16(p);
//}
//
//static v128 set_epi32(int i3, int i2, int i1, int i0)
//{
//    int* p = stackalloc int[] { i0, i1, i2, i3 };
//
//    return Arm.Neon.vld1q_s32(p);
//}
//
//static v128 set_epi64(long i1, long i2)
//{
//    return set_epi64x(i1, i2);
//}
//
//static v128 set_epi64x(long i1, long i2)
//{
//    return Arm.Neon.vcombine_s64(Arm.Neon.vcreate_s64((ulong)i2), Arm.Neon.vcreate_s64((ulong)i1));
//}
//
//static v128 set_epi8(sbyte b15,
//                     sbyte b14,
//                     sbyte b13,
//                     sbyte b12,
//                     sbyte b11,
//                     sbyte b10,
//                     sbyte b9,
//                     sbyte b8,
//                     sbyte b7,
//                     sbyte b6,
//                     sbyte b5,
//                     sbyte b4,
//                     sbyte b3,
//                     sbyte b2,
//                     sbyte b1,
//                     sbyte b0)
//{
//    sbyte* p = stackalloc sbyte[] { b0,  b1,  b2,  b3,
//                                    b4,  b5,  b6,  b7,
//                                    b8,  b9,  b10, b11,
//                                    b12, b13, b14, b15 };
//    return Arm.Neon.vld1q_s8(p);
//}
//
//static v128 set_pd(double e1, double e0)
//{
//    double* p = stackalloc double[] { e0, e1 };
//
//    return Arm.Neon.vld1q_f64(p);
//}
//
//static v128 set_sd(double a)
//{
//    return set_pd(0, a);
//}
//
//static v128 set1_epi16(short w)
//{
//    return Arm.Neon.vdupq_n_s16(w);
//}
//
//static v128 set1_epi32(int _i)
//{
//    return Arm.Neon.vdupq_n_s32(_i);
//}
//
//static v128 set1_epi64(long _i)
//{
//    return Arm.Neon.vdupq_n_s64(_i);
//}
//
//static v128 set1_epi64x(long _i)
//{
//    return Arm.Neon.vdupq_n_s64(_i);
//}
//
//static v128 set1_epi8(sbyte w)
//{
//    return Arm.Neon.vdupq_n_s8(w);
//}
//
//static v128 set1_pd(double d)
//{
//    return Arm.Neon.vdupq_n_f64(d);
//}
//
//static v128 setr_epi16(short w0,
//                       short w1,
//                       short w2,
//                       short w3,
//                       short w4,
//                       short w5,
//                       short w6,
//                       short w7)
//{
//    short* p = stackalloc short[] { w0, w1, w2, w3, w4, w5, w6, w7 };
//
//    return Arm.Neon.vld1q_s16(p);
//}
//
//static v128 setr_epi32(int i3, int i2, int i1, int i0)
//{
//    int* p = stackalloc int[] { i3, i2, i1, i0 };
//
//    return Arm.Neon.vld1q_s32(p);
//}
//
//static v128 setr_epi64(long e1, long e0)
//{
//    return Arm.Neon.vcombine_s64(new v64(e1), new v64(e0)));
//}
//
//static v128 setr_epi8(sbyte b0,
//                      sbyte b1,
//                      sbyte b2,
//                      sbyte b3,
//                      sbyte b4,
//                      sbyte b5,
//                      sbyte b6,
//                      sbyte b7,
//                      sbyte b8,
//                      sbyte b9,
//                      sbyte b10,
//                      sbyte b11,
//                      sbyte b12,
//                      sbyte b13,
//                      sbyte b14,
//                      sbyte b15)
//{
//    sbyte* p = stackalloc sbyte[] { b0,  b1,  b2,  b3,
//                                    b4,  b5,  b6,  b7,
//                                    b8,  b9,  b10, b11,
//                                    b12, b13, b14, b15};
//    return Arm.Neon.vld1q_s8(p);
//}
//
//static v128 setr_pd(double e1, double e0)
//{
//    return set_pd(e0, e1);
//}
//
//static v128 setzero_pd()
//{
//    return Arm.Neon.vdupq_n_f64(0);
//}
//
//static v128 setzero_si128()
//{
//    return Arm.Neon.vdupq_n_s32(0);
//}
//
//static v128 shuffle_epi32(v128 a, int imm8)                        
//{                                      
//    v128 ret;                                     
//    switch (imm8) 
//    {                                   
//        case SHUFFLE(1, 0, 3, 2):                    
//            ret = shuffle_epi_1032((a));             
//            break;                                       
//        case SHUFFLE(2, 3, 0, 1):                    
//            ret = shuffle_epi_2301((a));             
//            break;                                       
//        case SHUFFLE(0, 3, 2, 1):                    
//            ret = shuffle_epi_0321((a));             
//            break;                                       
//        case SHUFFLE(2, 1, 0, 3):                    
//            ret = shuffle_epi_2103((a));             
//            break;                                       
//        case SHUFFLE(1, 0, 1, 0):                    
//            ret = shuffle_epi_1010((a));             
//            break;                                       
//        case SHUFFLE(1, 0, 0, 1):                    
//            ret = shuffle_epi_1001((a));             
//            break;                                       
//        case SHUFFLE(0, 1, 0, 1):                    
//            ret = shuffle_epi_0101((a));             
//            break;                                       
//        case SHUFFLE(2, 2, 1, 1):                    
//            ret = shuffle_epi_2211((a));             
//            break;                                      
//        case SHUFFLE(0, 1, 2, 2):                    
//            ret = shuffle_epi_0122((a));             
//            break;                                       
//        case SHUFFLE(3, 3, 3, 2):                    
//            ret = shuffle_epi_3332((a));             
//            break;                                       
//        case SHUFFLE(0, 0, 0, 0):                    
//            ret = shuffle_epi32_splat((a), 0);       
//            break;                                       
//        case SHUFFLE(1, 1, 1, 1):                    
//            ret = shuffle_epi32_splat((a), 1);       
//            break;                                       
//        case SHUFFLE(2, 2, 2, 2):                   
//            ret = shuffle_epi32_splat((a), 2);       
//            break;                                       
//        case SHUFFLE(3, 3, 3, 3):                    
//            ret = shuffle_epi32_splat((a), 3);       
//            break;                                       
//        default:                                         
//            ret = Arm.Neon.vmovq_n_s32(Arm.Neon.vgetq_lane_s32(a, (imm8) & (0x3)));     
//            ret = Arm.Neon.vsetq_lane_s32(Arm.Neon.vgetq_lane_s32(a, ((imm8) >> 2) & 0x3), ret, 1);                                                        
//            ret = Arm.Neon.vsetq_lane_s32(Arm.Neon.vgetq_lane_s32(a, ((imm8) >> 4) & 0x3), ret, 2);                                                        
//            ret = Arm.Neon.vsetq_lane_s32(Arm.Neon.vgetq_lane_s32(a, ((imm8) >> 6) & 0x3), ret, 3);                   
//            break;                                       
//    }                                                
//        
//    return ret;                                             
//}
//
//// Shuffle double-precision (64-bit) floating-point elements using the control
//// in imm8, and store the results in dst.
////
////   dst[63:0] := (imm8[0] == 0) ? a[63:0] : a[127:64]
////   dst[127:64] := (imm8[1] == 0) ? b[63:0] : b[127:64]
////
//static v128 shuffle_pd(a, b, imm8)                                     \
//    castsi128_pd(set_epi64x(                                   \
//        vgetq_lane_s64(b, (imm8 & 0x2) >> 1), \
//        vgetq_lane_s64(a, imm8 & 0x1)))
//
//// static v128 shufflehi_epi16(v128 a,
////                                          __constrange(0,255) int imm)
//static v128 shufflehi_epi16(a, imm) shufflehi_epi16_function((a), (imm))
//
//// static v128 shufflelo_epi16(v128 a,
////                                          __constrange(0,255) int imm)
//static v128 shufflelo_epi16(a, imm) shufflelo_epi16_function((a), (imm))
//
//// Shift packed 16-bit integers in a left by count while shifting in zeros, and
//// store the results in dst.
////
////   FOR j := 0 to 7
////     i := j*16
////     IF count[63:0] > 15
////       dst[i+15:i] := 0
////     ELSE
////       dst[i+15:i] := ZeroExtend16(a[i+15:i] << count[63:0])
////     FI
////   ENDFOR
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_sll_epi16
//static v128 sll_epi16(v128 a, v128 count)
//{
//    v128 vc = vdupq_n_s16((int16_t) c);
//    return vreinterpretq_m128i_s16(vshlq_s16(a, vc));
//}
//
//// Shift packed 32-bit integers in a left by count while shifting in zeros, and
//// store the results in dst.
////
////   FOR j := 0 to 3
////     i := j*32
////     IF count[63:0] > 31
////       dst[i+31:i] := 0
////     ELSE
////       dst[i+31:i] := ZeroExtend32(a[i+31:i] << count[63:0])
////     FI
////   ENDFOR
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_sll_epi32
//static v128 sll_epi32(v128 a, v128 count)
//{
//    v128 vc = vdupq_n_s32((int) c);
//    return vreinterpretq_m128i_s32(vshlq_s32(a, vc));
//}
//
//// Shift packed 64-bit integers in a left by count while shifting in zeros, and
//// store the results in dst.
////
////   FOR j := 0 to 1
////     i := j*64
////     IF count[63:0] > 63
////       dst[i+63:i] := 0
////     ELSE
////       dst[i+63:i] := ZeroExtend64(a[i+63:i] << count[63:0])
////     FI
////   ENDFOR
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_sll_epi64
//static v128 sll_epi64(v128 a, v128 count)
//{
//    v128 vc = vdupq_n_s64((long) c);
//    return vreinterpretq_m128i_s64(vshlq_s64(a, vc));
//}
//
//// Shift packed 16-bit integers in a left by imm8 while shifting in zeros, and
//// store the results in dst.
////
////   FOR j := 0 to 7
////     i := j*16
////     IF imm8[7:0] > 15
////       dst[i+15:i] := 0
////     ELSE
////       dst[i+15:i] := ZeroExtend16(a[i+15:i] << imm8[7:0])
////     FI
////   ENDFOR
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_slli_epi16
//static v128 slli_epi16(v128 a, int imm)
//{
//    return vreinterpretq_m128i_s16(
//        vshlq_s16(a, vdupq_n_s16(imm)));
//}
//
//// Shift packed 32-bit integers in a left by imm8 while shifting in zeros, and
//// store the results in dst.
////
////   FOR j := 0 to 3
////     i := j*32
////     IF imm8[7:0] > 31
////       dst[i+31:i] := 0
////     ELSE
////       dst[i+31:i] := ZeroExtend32(a[i+31:i] << imm8[7:0])
////     FI
////   ENDFOR
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_slli_epi32
//static v128 slli_epi32(v128 a, int imm)
//{
//    return vreinterpretq_m128i_s32(
//        vshlq_s32(a, vdupq_n_s32(imm)));
//}
//
//// Shift packed 64-bit integers in a left by imm8 while shifting in zeros, and
//// store the results in dst.
////
////   FOR j := 0 to 1
////     i := j*64
////     IF imm8[7:0] > 63
////       dst[i+63:i] := 0
////     ELSE
////       dst[i+63:i] := ZeroExtend64(a[i+63:i] << imm8[7:0])
////     FI
////   ENDFOR
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_slli_epi64
//static v128 slli_epi64(v128 a, int imm)
//{
//    return vreinterpretq_m128i_s64(
//        vshlq_s64(a, vdupq_n_s64(imm)));
//}
//
//// Shift a left by imm8 bytes while shifting in zeros, and store the results in
//// dst.
////
////   tmp := imm8[7:0]
////   IF tmp > 15
////     tmp := 16
////   FI
////   dst[127:0] := a[127:0] << (tmp*8)
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_slli_si128
//static v128 slli_si128(v128 a, int imm)
//{
//    v128 tmp[2] = {vdupq_n_u8(0), a};
//    return vreinterpretq_m128i_u8(
//        vld1q_u8(((usbyte const *) tmp) + (16 - imm)));
//}
//
//// Compute the square root of packed double-precision (64-bit) floating-point
//// elements in a, and store the results in dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_sqrt_pd
//static v128 sqrt_pd(v128 a)
//{
//#if defined(__aarch64__)
//    return vreinterpretq_m128d_f64(vsqrtq_f64(a));
//#else
//    double a0 = sqrt(((double *) &a)[0]);
//    double a1 = sqrt(((double *) &a)[1]);
//    return set_pd(a1, a0);
//#endif
//}
//
//// Compute the square root of the lower double-precision (64-bit) floating-point
//// element in b, store the result in the lower element of dst, and copy the
//// upper element from a to the upper element of dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_sqrt_sd
//static v128 sqrt_sd(v128 a, v128 b)
//{
//#if defined(__aarch64__)
//    return move_sd(a, sqrt_pd(b));
//#else
//    return set_pd(((double *) &a)[1], sqrt(((double *) &b)[0]));
//#endif
//}
//
//// Shift packed 16-bit integers in a right by count while shifting in sign bits,
//// and store the results in dst.
////
////   FOR j := 0 to 7
////     i := j*16
////     IF count[63:0] > 15
////       dst[i+15:i] := (a[i+15] ? 0xFFFF : 0x0)
////     ELSE
////       dst[i+15:i] := SignExtend16(a[i+15:i] >> count[63:0])
////     FI
////  ENDFOR
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_sra_epi16
//static v128 sra_epi16(v128 a, v128 count)
//{
//    long c = (long) vget_low_s64((v128) count);
//    return vreinterpretq_m128i_s16(vshlq_s16((v128) a, vdupq_n_s16(-c)));
//}
//
//// Shift packed 32-bit integers in a right by count while shifting in sign bits,
//// and store the results in dst.
////
////   FOR j := 0 to 3
////     i := j*32
////     IF count[63:0] > 31
////       dst[i+31:i] := (a[i+31] ? 0xFFFFFFFF : 0x0)
////     ELSE
////       dst[i+31:i] := SignExtend32(a[i+31:i] >> count[63:0])
////     FI
////  ENDFOR
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_sra_epi32
//static v128 sra_epi32(v128 a, v128 count)
//{
//    long c = (long) vget_low_s64((v128) count);
//    return vreinterpretq_m128i_s32(vshlq_s32((v128) a, vdupq_n_s32(-c)));
//}
//
//// Shift packed 16-bit integers in a right by imm8 while shifting in sign
//// bits, and store the results in dst.
////
////   FOR j := 0 to 7
////     i := j*16
////     IF imm8[7:0] > 15
////       dst[i+15:i] := (a[i+15] ? 0xFFFF : 0x0)
////     ELSE
////       dst[i+15:i] := SignExtend16(a[i+15:i] >> imm8[7:0])
////     FI
////   ENDFOR
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_srai_epi16
//static v128 srai_epi16(v128 a, int imm)
//{
//    return (v128) vshlq_s16((v128) a, vdupq_n_s16(-count));
//}
//
//// Shift packed 32-bit integers in a right by imm8 while shifting in sign bits,
//// and store the results in dst.
////
////   FOR j := 0 to 3
////     i := j*32
////     IF imm8[7:0] > 31
////       dst[i+31:i] := (a[i+31] ? 0xFFFFFFFF : 0x0)
////     ELSE
////       dst[i+31:i] := SignExtend32(a[i+31:i] >> imm8[7:0])
////     FI
////   ENDFOR
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_srai_epi32
//// static v128 srai_epi32(v128 a, __constrange(0,255) int imm)
//static v128 srai_epi32(a, imm)                                               
//    __extension__({                                                          
//        v128 ret;                                                         
//        if (_sse2neon_unlikely((imm) == 0)) {                                
//            ret = a;                                                         
//        } else              \
//            ret = vreinterpretq_m128i_s32(                                   
//                vshlq_s32(a, vdupq_n_s32(-(imm)))); 
//        ret;                                                                 
//    })
//
//// Shift packed 16-bit integers in a right by count while shifting in zeros, and
//// store the results in dst.
////
////   FOR j := 0 to 7
////     i := j*16
////     IF count[63:0] > 15
////       dst[i+15:i] := 0
////     ELSE
////       dst[i+15:i] := ZeroExtend16(a[i+15:i] >> count[63:0])
////     FI
////   ENDFOR
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_srl_epi16
//static v128 srl_epi16(v128 a, v128 count)
//{
//    ulong c = vreinterpretq_nth_u64_m128i(count, 0);
//
//    v128 vc = vdupq_n_s16(-(int16_t) c);
//    return vreinterpretq_m128i_u16(vshlq_u16(a, vc));
//}
//
//// Shift packed 32-bit integers in a right by count while shifting in zeros, and
//// store the results in dst.
////
////   FOR j := 0 to 3
////     i := j*32
////     IF count[63:0] > 31
////       dst[i+31:i] := 0
////     ELSE
////       dst[i+31:i] := ZeroExtend32(a[i+31:i] >> count[63:0])
////     FI
////   ENDFOR
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_srl_epi32
//static v128 srl_epi32(v128 a, v128 count)
//{
//    ulong c = vreinterpretq_nth_u64_m128i(count, 0);
//
//    v128 vc = vdupq_n_s32(-(int) c);
//    return vreinterpretq_m128i_u32(vshlq_u32(vreinterpretq_u32_m128i(a), vc));
//}
//
//// Shift packed 64-bit integers in a right by count while shifting in zeros, and
//// store the results in dst.
////
////   FOR j := 0 to 1
////     i := j*64
////     IF count[63:0] > 63
////       dst[i+63:i] := 0
////     ELSE
////       dst[i+63:i] := ZeroExtend64(a[i+63:i] >> count[63:0])
////     FI
////   ENDFOR
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_srl_epi64
//static v128 srl_epi64(v128 a, v128 count)
//{
//    ulong c = vreinterpretq_nth_u64_m128i(count, 0);
//
//    v128 vc = vdupq_n_s64(-(long) c);
//    return vreinterpretq_m128i_u64(vshlq_u64(a, vc));
//}
//
//// Shift packed 16-bit integers in a right by imm8 while shifting in zeros, and
//// store the results in dst.
////
////   FOR j := 0 to 7
////     i := j*16
////     IF imm8[7:0] > 15
////       dst[i+15:i] := 0
////     ELSE
////       dst[i+15:i] := ZeroExtend16(a[i+15:i] >> imm8[7:0])
////     FI
////   ENDFOR
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_srli_epi16
//static v128 srli_epi16(a, imm)                                               \
//    __extension__({                                                          \
//        v128 ret;                                                         \                         \
//            ret = vreinterpretq_m128i_u16(                                   \
//                vshlq_u16(a, vdupq_n_s16(-(imm)))); \
//        ret;                                                                 \
//    })
//
//// Shift packed 32-bit integers in a right by imm8 while shifting in zeros, and
//// store the results in dst.
////
////   FOR j := 0 to 3
////     i := j*32
////     IF imm8[7:0] > 31
////       dst[i+31:i] := 0
////     ELSE
////       dst[i+31:i] := ZeroExtend32(a[i+31:i] >> imm8[7:0])
////     FI
////   ENDFOR
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_srli_epi32
//// static v128 srli_epi32(v128 a, __constrange(0,255) int imm)
//static v128 srli_epi32(a, imm)                                               \
//    __extension__({                                                          \
//        v128 ret;                                                         \
//            ret = vreinterpretq_m128i_u32(                                   \
//                vshlq_u32(vreinterpretq_u32_m128i(a), vdupq_n_s32(-(imm)))); \
//        ret;                                                                 \
//    })
//
//// Shift packed 64-bit integers in a right by imm8 while shifting in zeros, and
//// store the results in dst.
////
////   FOR j := 0 to 1
////     i := j*64
////     IF imm8[7:0] > 63
////       dst[i+63:i] := 0
////     ELSE
////       dst[i+63:i] := ZeroExtend64(a[i+63:i] >> imm8[7:0])
////     FI
////   ENDFOR
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_srli_epi64
//static v128 srli_epi64(a, imm)                                               \
//    __extension__({                                                          \
//        v128 ret;                                                         \
//            ret = vreinterpretq_m128i_u64(                                   \
//                vshlq_u64(a, vdupq_n_s64(-(imm)))); \
//        ret;                                                                 \
//    })
//
//// Shift a right by imm8 bytes while shifting in zeros, and store the results in
//// dst.
////
////   tmp := imm8[7:0]
////   IF tmp > 15
////     tmp := 16
////   FI
////   dst[127:0] := a[127:0] >> (tmp*8)
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_srli_si128
//static v128 srli_si128(v128 a, int imm)
//{
//    v128 tmp[2] = {a, vdupq_n_u8(0)};
//    return vreinterpretq_m128i_u8(vld1q_u8(((usbyte const *) tmp) + imm));
//}
//
//// Store 128-bits (composed of 2 packed double-precision (64-bit) floating-point
//// elements) from a into memory. mem_addr must be aligned on a 16-byte boundary
//// or a general-protection exception may be generated.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_store_pd
//static void store_pd(double *mem_addr, v128 a)
//{
//#if defined(__aarch64__)
//    vst1q_f64((double *) mem_addr, a);
//#else
//    vst1q_f32((float *) mem_addr, a);
//#endif
//}
//
//// Store the lower double-precision (64-bit) floating-point element from a into
//// 2 contiguous elements in memory. mem_addr must be aligned on a 16-byte
//// boundary or a general-protection exception may be generated.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_store_pd1
//static void store_pd1(double *mem_addr, v128 a)
//{
//#if defined(__aarch64__)
//    float64x1_t a_low = vget_low_f64(a);
//    vst1q_f64((double *) mem_addr,
//              vreinterpretq_f64_m128d(vcombine_f64(a_low, a_low)));
//#else
//    v64 a_low = vget_low_f32(a);
//    vst1q_f32((float *) mem_addr,
//              vreinterpretq_f32_m128d(vcombine_f32(a_low, a_low)));
//#endif
//}
//
//// Store the lower double-precision (64-bit) floating-point element from a into
//// memory. mem_addr does not need to be aligned on any particular boundary.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=mm_store_sd
//static void store_sd(double *mem_addr, v128 a)
//{
//#if defined(__aarch64__)
//    vst1_f64((double *) mem_addr, vget_low_f64(a));
//#else
//    vst1_u64((ulong *) mem_addr, vget_low_u64(a));
//#endif
//}
//
//// Stores four 32-bit integer values as (as a v128 value) at the address p.
//// https://msdn.microsoft.com/en-us/library/vstudio/edk11s13(v=vs.100).aspx
//static void store_si128(v128* p, v128 a)
//{
//    vst1q_s32((int *) p, a);
//}
//
//// Store the lower double-precision (64-bit) floating-point element from a into
//// 2 contiguous elements in memory. mem_addr must be aligned on a 16-byte
//// boundary or a general-protection exception may be generated.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#expand=9,526,5601&text=_mm_store1_pd
//static v128 store1_pd store_pd1
//
//// Store the upper double-precision (64-bit) floating-point element from a into
//// memory.
////
////   MEM[mem_addr+63:mem_addr] := a[127:64]
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_storeh_pd
//static void storeh_pd(double *mem_addr, v128 a)
//{
//#if defined(__aarch64__)
//    vst1_f64((double *) mem_addr, vget_high_f64(a));
//#else
//    vst1_f32((float *) mem_addr, vget_high_f32(a));
//#endif
//}
//
//// Reads the lower 64 bits of b and stores them into the lower 64 bits of a.
//// https://msdn.microsoft.com/en-us/library/hhwf428f%28v=vs.90%29.aspx
//static void storel_epi64(v128 *a, v128 b)
//{
//    vst1_u64((ulong *) a, vget_low_u64(b));
//}
//
//// Store the lower double-precision (64-bit) floating-point element from a into
//// memory.
////
////   MEM[mem_addr+63:mem_addr] := a[63:0]
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_storel_pd
//static void storel_pd(double *mem_addr, v128 a)
//{
//#if defined(__aarch64__)
//    vst1_f64((double *) mem_addr, vget_low_f64(a));
//#else
//    vst1_f32((float *) mem_addr, vget_low_f32(a));
//#endif
//}
//
//// Store 2 double-precision (64-bit) floating-point elements from a into memory
//// in reverse order. mem_addr must be aligned on a 16-byte boundary or a
//// general-protection exception may be generated.
////
////   MEM[mem_addr+63:mem_addr] := a[127:64]
////   MEM[mem_addr+127:mem_addr+64] := a[63:0]
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_storer_pd
//static void storer_pd(double *mem_addr, v128 a)
//{
//    v128 f = a;
//    store_pd(mem_addr, vreinterpretq_m128d_f32(vextq_f32(f, f, 2)));
//}
//
//// Store 128-bits (composed of 2 packed double-precision (64-bit) floating-point
//// elements) from a into memory. mem_addr does not need to be aligned on any
//// particular boundary.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_storeu_pd
//static void storeu_pd(double *mem_addr, v128 a)
//{
//    store_pd(mem_addr, a);
//}
//
//// Stores 128-bits of integer data a at the address p.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_storeu_si128
//static void storeu_si128(v128* p, v128 a)
//{
//    vst1q_s32((int *) p, a);
//}
//
//// Stores 32-bits of integer data a at the address p.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_storeu_si32
//static void storeu_si32(void* p, v128 a)
//{
//    vst1q_lane_s32((int *) p, a, 0);
//}
//
//// Store 128-bits (composed of 2 packed double-precision (64-bit) floating-point
//// elements) from a into memory using a non-temporal memory hint. mem_addr must
//// be aligned on a 16-byte boundary or a general-protection exception may be
//// generated.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_stream_pd
//static void stream_pd(double* p, v128 a)
//{
//#if __has_builtin(__builtin_nontemporal_store)
//    __builtin_nontemporal_store(a, (v128 *) p);
//#elif defined(__aarch64__)
//    vst1q_f64(p, a);
//#else
//    vst1q_s64((long *) p, a);
//#endif
//}
//
//// Stores the data in a to the address p without polluting the caches.  If the
//// cache line containing address p is already in the cache, the cache will be
//// updated.
//// https://msdn.microsoft.com/en-us/library/ba08y07y%28v=vs.90%29.aspx
//static void stream_si128(v128* p, v128 a)
//{
//#if __has_builtin(__builtin_nontemporal_store)
//    __builtin_nontemporal_store(a, p);
//#else
//    vst1q_s64((long *) p, a);
//#endif
//}
//
//// Store 32-bit integer a into memory using a non-temporal hint to minimize
//// cache pollution. If the cache line containing address mem_addr is already in
//// the cache, the cache will be updated.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_stream_si32
//static void stream_si32(int *p, int a)
//{
//    vst1q_lane_s32((int *) p, vdupq_n_s32(a), 0);
//}
//
//// Store 64-bit integer a into memory using a non-temporal hint to minimize
//// cache pollution. If the cache line containing address mem_addr is already in
//// the cache, the cache will be updated.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_stream_si64
//static void stream_si64(long *p, long a)
//{
//    vst1_s64((long *) p, vdup_n_s64((long) a));
//}
//
//// Subtract packed 16-bit integers in b from packed 16-bit integers in a, and
//// store the results in dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_sub_epi16
//static v128 sub_epi16(v128 a, v128 b)
//{
//    return vreinterpretq_m128i_s16(
//        vsubq_s16(a, b));
//}
//
//// Subtracts the 4 signed or unsigned 32-bit integers of b from the 4 signed or
//// unsigned 32-bit integers of a.
////
////   r0 := a0 - b0
////   r1 := a1 - b1
////   r2 := a2 - b2
////   r3 := a3 - b3
////
//// https://msdn.microsoft.com/en-us/library/vstudio/fhh866h0(v=vs.100).aspx
//static v128 sub_epi32(v128 a, v128 b)
//{
//    return vreinterpretq_m128i_s32(
//        vsubq_s32(a, b));
//}
//
//// Subtract 2 packed 64-bit integers in b from 2 packed 64-bit integers in a,
//// and store the results in dst.
////    r0 := a0 - b0
////    r1 := a1 - b1
//static v128 sub_epi64(v128 a, v128 b)
//{
//    return vreinterpretq_m128i_s64(
//        vsubq_s64(a, b));
//}
//
//// Subtract packed 8-bit integers in b from packed 8-bit integers in a, and
//// store the results in dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_sub_epi8
//static v128 sub_epi8(v128 a, v128 b)
//{
//    return vreinterpretq_m128i_s8(
//        vsubq_s8(a, b));
//}
//
//// Subtract packed double-precision (64-bit) floating-point elements in b from
//// packed double-precision (64-bit) floating-point elements in a, and store the
//// results in dst.
////
////   FOR j := 0 to 1
////     i := j*64
////     dst[i+63:i] := a[i+63:i] - b[i+63:i]
////   ENDFOR
////
////  https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=mm_sub_pd
//static v128 sub_pd(v128 a, v128 b)
//{
//#if defined(__aarch64__)
//    return vreinterpretq_m128d_f64(
//        vsubq_f64(a, b));
//#else
//    double *da = (double *) &a;
//    double *db = (double *) &b;
//    double c[2];
//    c[0] = da[0] - db[0];
//    c[1] = da[1] - db[1];
//    return vld1q_f32((float *) c);
//#endif
//}
//
//// Subtract the lower double-precision (64-bit) floating-point element in b from
//// the lower double-precision (64-bit) floating-point element in a, store the
//// result in the lower element of dst, and copy the upper element from a to the
//// upper element of dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_sub_sd
//static v128 sub_sd(v128 a, v128 b)
//{
//    return move_sd(a, sub_pd(a, b));
//}
//
//// Subtract 64-bit integer b from 64-bit integer a, and store the result in dst.
////
////   dst[63:0] := a[63:0] - b[63:0]
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_sub_si64
//static v64 sub_si64(v64 a, v64 b)
//{
//    return vreinterpret_m64_s64(
//        vsub_s64(a, b));
//}
//
//// Subtracts the 8 signed 16-bit integers of b from the 8 signed 16-bit integers
//// of a and saturates.
////
////   r0 := SignedSaturate(a0 - b0)
////   r1 := SignedSaturate(a1 - b1)
////   ...
////   r7 := SignedSaturate(a7 - b7)
////
//// https://technet.microsoft.com/en-us/subscriptions/3247z5b8(v=vs.90)
//static v128 subs_epi16(v128 a, v128 b)
//{
//    return vreinterpretq_m128i_s16(
//        vqsubq_s16(a, b));
//}
//
//// Subtracts the 16 signed 8-bit integers of b from the 16 signed 8-bit integers
//// of a and saturates.
////
////   r0 := SignedSaturate(a0 - b0)
////   r1 := SignedSaturate(a1 - b1)
////   ...
////   r15 := SignedSaturate(a15 - b15)
////
//// https://technet.microsoft.com/en-us/subscriptions/by7kzks1(v=vs.90)
//static v128 subs_epi8(v128 a, v128 b)
//{
//    return vreinterpretq_m128i_s8(
//        vqsubq_s8(a, b));
//}
//
//// Subtracts the 8 unsigned 16-bit integers of bfrom the 8 unsigned 16-bit
//// integers of a and saturates..
//// https://technet.microsoft.com/en-us/subscriptions/index/f44y0s19(v=vs.90).aspx
//static v128 subs_epu16(v128 a, v128 b)
//{
//    return vreinterpretq_m128i_u16(
//        vqsubq_u16(a, b));
//}
//
//// Subtracts the 16 unsigned 8-bit integers of b from the 16 unsigned 8-bit
//// integers of a and saturates.
////
////   r0 := UnsignedSaturate(a0 - b0)
////   r1 := UnsignedSaturate(a1 - b1)
////   ...
////   r15 := UnsignedSaturate(a15 - b15)
////
//// https://technet.microsoft.com/en-us/subscriptions/yadkxc18(v=vs.90)
//static v128 subs_epu8(v128 a, v128 b)
//{
//    return vreinterpretq_m128i_u8(
//        vqsubq_u8(a, b));
//}
//
//// Return vector of type v128 with undefined elements.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_undefined_pd
//static v128 undefined_pd()
//{
//#if defined(__GNUC__) || defined(__clang__)
//#pragma GCC diagnostic push
//#pragma GCC diagnostic ignored "-Wuninitialized"
//#endif
//    v128 a;
//    return a;
//#if defined(__GNUC__) || defined(__clang__)
//#pragma GCC diagnostic pop
//#endif
//}
//
//// Interleaves the upper 4 signed or unsigned 16-bit integers in a with the
//// upper 4 signed or unsigned 16-bit integers in b.
////
////   r0 := a4
////   r1 := b4
////   r2 := a5
////   r3 := b5
////   r4 := a6
////   r5 := b6
////   r6 := a7
////   r7 := b7
////
//// https://msdn.microsoft.com/en-us/library/03196cz7(v=vs.100).aspx
//static v128 unpackhi_epi16(v128 a, v128 b)
//{
//#if defined(__aarch64__)
//    return vreinterpretq_m128i_s16(
//        vzip2q_s16(a, b));
//#else
//    v64 a1 = vget_high_s16(a);
//    v64 b1 = vget_high_s16(b);
//    int16x4x2_t result = vzip_s16(a1, b1);
//    return vreinterpretq_m128i_s16(vcombine_s16(result.val[0], result.val[1]));
//#endif
//}
//
//// Interleaves the upper 2 signed or unsigned 32-bit integers in a with the
//// upper 2 signed or unsigned 32-bit integers in b.
//// https://msdn.microsoft.com/en-us/library/65sa7cbs(v=vs.100).aspx
//static v128 unpackhi_epi32(v128 a, v128 b)
//{
//#if defined(__aarch64__)
//    return vreinterpretq_m128i_s32(
//        vzip2q_s32(a, b));
//#else
//    v64 a1 = vget_high_s32(a);
//    v64 b1 = vget_high_s32(b);
//    int32x2x2_t result = vzip_s32(a1, b1);
//    return vreinterpretq_m128i_s32(vcombine_s32(result.val[0], result.val[1]));
//#endif
//}
//
//// Interleaves the upper signed or unsigned 64-bit integer in a with the
//// upper signed or unsigned 64-bit integer in b.
////
////   r0 := a1
////   r1 := b1
//static v128 unpackhi_epi64(v128 a, v128 b)
//{
//    v64 a_h = vget_high_s64(a);
//    v64 b_h = vget_high_s64(b);
//    return vreinterpretq_m128i_s64(vcombine_s64(a_h, b_h));
//}
//
//// Interleaves the upper 8 signed or unsigned 8-bit integers in a with the upper
//// 8 signed or unsigned 8-bit integers in b.
////
////   r0 := a8
////   r1 := b8
////   r2 := a9
////   r3 := b9
////   ...
////   r14 := a15
////   r15 := b15
////
//// https://msdn.microsoft.com/en-us/library/t5h7783k(v=vs.100).aspx
//static v128 unpackhi_epi8(v128 a, v128 b)
//{
//#if defined(__aarch64__)
//    return vreinterpretq_m128i_s8(
//        vzip2q_s8(a, b));
//#else
//    v64 a1 =
//        vreinterpret_s8_s16(vget_high_s16(a));
//    v64 b1 =
//        vreinterpret_s8_s16(vget_high_s16(b));
//    int8x8x2_t result = vzip_s8(a1, b1);
//    return vreinterpretq_m128i_s8(vcombine_s8(result.val[0], result.val[1]));
//#endif
//}
//
//// Unpack and interleave double-precision (64-bit) floating-point elements from
//// the high half of a and b, and store the results in dst.
////
////   DEFINE INTERLEAVE_HIGH_QWORDS(src1[127:0], src2[127:0]) {
////     dst[63:0] := src1[127:64]
////     dst[127:64] := src2[127:64]
////     RETURN dst[127:0]
////   }
////   dst[127:0] := INTERLEAVE_HIGH_QWORDS(a[127:0], b[127:0])
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_unpackhi_pd
//static v128 unpackhi_pd(v128 a, v128 b)
//{
//#if defined(__aarch64__)
//    return vreinterpretq_m128d_f64(
//        vzip2q_f64(a, b));
//#else
//    return vreinterpretq_m128d_s64(
//        vcombine_s64(vget_high_s64(a),
//                     vget_high_s64(b)));
//#endif
//}
//
//// Interleaves the lower 4 signed or unsigned 16-bit integers in a with the
//// lower 4 signed or unsigned 16-bit integers in b.
////
////   r0 := a0
////   r1 := b0
////   r2 := a1
////   r3 := b1
////   r4 := a2
////   r5 := b2
////   r6 := a3
////   r7 := b3
////
//// https://msdn.microsoft.com/en-us/library/btxb17bw%28v=vs.90%29.aspx
//static v128 unpacklo_epi16(v128 a, v128 b)
//{
//#if defined(__aarch64__)
//    return vreinterpretq_m128i_s16(
//        vzip1q_s16(a, b));
//#else
//    v64 a1 = vget_low_s16(a);
//    v64 b1 = vget_low_s16(b);
//    int16x4x2_t result = vzip_s16(a1, b1);
//    return vreinterpretq_m128i_s16(vcombine_s16(result.val[0], result.val[1]));
//#endif
//}
//
//// Interleaves the lower 2 signed or unsigned 32 - bit integers in a with the
//// lower 2 signed or unsigned 32 - bit integers in b.
////
////   r0 := a0
////   r1 := b0
////   r2 := a1
////   r3 := b1
////
//// https://msdn.microsoft.com/en-us/library/x8atst9d(v=vs.100).aspx
//static v128 unpacklo_epi32(v128 a, v128 b)
//{
//#if defined(__aarch64__)
//    return vreinterpretq_m128i_s32(
//        vzip1q_s32(a, b));
//#else
//    v64 a1 = vget_low_s32(a);
//    v64 b1 = vget_low_s32(b);
//    int32x2x2_t result = vzip_s32(a1, b1);
//    return vreinterpretq_m128i_s32(vcombine_s32(result.val[0], result.val[1]));
//#endif
//}
//
//static v128 unpacklo_epi64(v128 a, v128 b)
//{
//    v64 a_l = vget_low_s64(a);
//    v64 b_l = vget_low_s64(b);
//    return vreinterpretq_m128i_s64(vcombine_s64(a_l, b_l));
//}
//
//// Interleaves the lower 8 signed or unsigned 8-bit integers in a with the lower
//// 8 signed or unsigned 8-bit integers in b.
////
////   r0 := a0
////   r1 := b0
////   r2 := a1
////   r3 := b1
////   ...
////   r14 := a7
////   r15 := b7
////
//// https://msdn.microsoft.com/en-us/library/xf7k860c%28v=vs.90%29.aspx
//static v128 unpacklo_epi8(v128 a, v128 b)
//{
//#if defined(__aarch64__)
//    return vreinterpretq_m128i_s8(
//        vzip1q_s8(a, b));
//#else
//    v64 a1 = vreinterpret_s8_s16(vget_low_s16(a));
//    v64 b1 = vreinterpret_s8_s16(vget_low_s16(b));
//    int8x8x2_t result = vzip_s8(a1, b1);
//    return vreinterpretq_m128i_s8(vcombine_s8(result.val[0], result.val[1]));
//#endif
//}
//
//// Unpack and interleave double-precision (64-bit) floating-point elements from
//// the low half of a and b, and store the results in dst.
////
////   DEFINE INTERLEAVE_QWORDS(src1[127:0], src2[127:0]) {
////     dst[63:0] := src1[63:0]
////     dst[127:64] := src2[63:0]
////     RETURN dst[127:0]
////   }
////   dst[127:0] := INTERLEAVE_QWORDS(a[127:0], b[127:0])
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_unpacklo_pd
//static v128 unpacklo_pd(v128 a, v128 b)
//{
//#if defined(__aarch64__)
//    return vreinterpretq_m128d_f64(
//        vzip1q_f64(a, b));
//#else
//    return vreinterpretq_m128d_s64(
//        vcombine_s64(vget_low_s64(a),
//                     vget_low_s64(b)));
//#endif
//}
//
//// Compute the bitwise XOR of packed double-precision (64-bit) floating-point
//// elements in a and b, and store the results in dst.
////
////   FOR j := 0 to 1
////      i := j*64
////      dst[i+63:i] := a[i+63:i] XOR b[i+63:i]
////   ENDFOR
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_xor_pd
//static v128 xor_pd(v128 a, v128 b)
//{
//    return vreinterpretq_m128d_s64(
//        veorq_s64(a, b));
//}
//
//// Computes the bitwise XOR of the 128-bit value in a and the 128-bit value in
//// b.  https://msdn.microsoft.com/en-us/library/fzt08www(v=vs.100).aspx
//static v128 xor_si128(v128 a, v128 b)
//{
//    return vreinterpretq_m128i_s32(
//        veorq_s32(a, b));
//}
//
///* SSE3 */
//
//// Alternatively add and subtract packed double-precision (64-bit)
//// floating-point elements in a to/from packed elements in b, and store the
//// results in dst.
////
//// FOR j := 0 to 1
////   i := j*64
////   IF ((j & 1) == 0)
////     dst[i+63:i] := a[i+63:i] - b[i+63:i]
////   ELSE
////     dst[i+63:i] := a[i+63:i] + b[i+63:i]
////   FI
//// ENDFOR
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_addsub_pd
//static v128 addsub_pd(v128 a, v128 b)
//{
//    _sse2neon_const v128 mask = set_pd(1.0f, -1.0f);
//#if defined(__aarch64__)
//    return vreinterpretq_m128d_f64(vfmaq_f64(a,
//                                             b,
//                                             vreinterpretq_f64_m128d(mask)));
//#else
//    return add_pd(_mm_mul_pd(b, mask), a);
//#endif
//}
//
//// Alternatively add and subtract packed single-precision (32-bit)
//// floating-point elements in a to/from packed elements in b, and store the
//// results in dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=addsub_ps
//static v128 addsub_ps(v128 a, v128 b)
//{
//    _sse2neon_const v128 mask = setr_ps(-1.0f, 1.0f, -1.0f, 1.0f);
//#if defined(__aarch64__) || defined(__ARM_FEATURE_FMA) /* VFPv4+ */
//    return Arm.Neon.vfmaq_f32(a,
//                                            vreinterpretq_f32_m128(mask),
//                                            b));
//#else
//    return add_ps(_mm_mul_ps(b, mask), a);
//#endif
//}
//
//// Horizontally add adjacent pairs of double-precision (64-bit) floating-point
//// elements in a and b, and pack the results in dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_hadd_pd
//static v128 hadd_pd(v128 a, v128 b)
//{
//#if defined(__aarch64__)
//    return vreinterpretq_m128d_f64(
//        vpaddq_f64(a, b));
//#else
//    double *da = (double *) &a;
//    double *db = (double *) &b;
//    double c[] = {da[0] + da[1], db[0] + db[1]};
//    return vreinterpretq_m128d_u64(vld1q_u64((ulong *) c));
//#endif
//}
//
//// Computes pairwise add of each argument as single-precision, floating-point
//// values a and b.
//// https://msdn.microsoft.com/en-us/library/yd9wecaa.aspx
//static v128 hadd_ps(v128 a, v128 b)
//{
//#if defined(__aarch64__)
//    return Arm.Neon.
//        vpaddq_f32(a, b));
//#else
//    v64 a10 = vget_low_f32(a);
//    v64 a32 = vget_high_f32(a);
//    v64 b10 = vget_low_f32(b);
//    v64 b32 = vget_high_f32(b);
//    return Arm.Neon.
//        vcombine_f32(vpadd_f32(a10, a32), vpadd_f32(b10, b32)));
//#endif
//}
//
//// Horizontally subtract adjacent pairs of double-precision (64-bit)
//// floating-point elements in a and b, and pack the results in dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_hsub_pd
//static v128 hsub_pd(v128 _a, v128 _b)
//{
//#if defined(__aarch64__)
//    v128 a = vreinterpretq_f64_m128d(_a);
//    v128 b = vreinterpretq_f64_m128d(_b);
//    return vreinterpretq_m128d_f64(
//        vsubq_f64(vuzp1q_f64(a, b), vuzp2q_f64(a, b)));
//#else
//    double *da = (double *) &_a;
//    double *db = (double *) &_b;
//    double c[] = {da[0] - da[1], db[0] - db[1]};
//    return vreinterpretq_m128d_u64(vld1q_u64((ulong *) c));
//#endif
//}
//
//// Horizontally subtract adjacent pairs of single-precision (32-bit)
//// floating-point elements in a and b, and pack the results in dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_hsub_ps
//static v128 hsub_ps(v128 _a, v128 _b)
//{
//    v128 a = vreinterpretq_f32_m128(_a);
//    v128 b = vreinterpretq_f32_m128(_b);
//#if defined(__aarch64__)
//    return Arm.Neon.
//        vsubq_f32(vuzp1q_f32(a, b), vuzp2q_f32(a, b)));
//#else
//    float32x4x2_t c = vuzpq_f32(a, b);
//    return Arm.Neon.vsubq_f32(c.val[0], c.val[1]));
//#endif
//}
//
//// Load 128-bits of integer data from unaligned memory into dst. This intrinsic
//// may perform better than loadu_si128 when the data crosses a cache line
//// boundary.
////
////   dst[127:0] := MEM[mem_addr+127:mem_addr]
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_lddqu_si128
//#define lddqu_si128 loadu_si128
//
//// Load a double-precision (64-bit) floating-point element from memory into both
//// elements of dst.
////
////   dst[63:0] := MEM[mem_addr+63:mem_addr]
////   dst[127:64] := MEM[mem_addr+63:mem_addr]
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_loaddup_pd
//#define loaddup_pd load1_pd
//
//// Duplicate the low double-precision (64-bit) floating-point element from a,
//// and store the results in dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_movedup_pd
//static v128 movedup_pd(v128 a)
//{
//#if defined(__aarch64__)
//    return vreinterpretq_m128d_f64(
//        vdupq_laneq_f64(a, 0));
//#else
//    return vreinterpretq_m128d_u64(
//        vdupq_n_u64(vgetq_lane_u64(a, 0)));
//#endif
//}
//
//// Duplicate odd-indexed single-precision (32-bit) floating-point elements
//// from a, and store the results in dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_movehdup_ps
//static v128 movehdup_ps(v128 a)
//{
//#if __has_builtin(__builtin_shufflevector)
//    return Arm.Neon.__builtin_shufflevector(
//        a, a, 1, 1, 3, 3));
//#else
//    float a1 = vgetq_lane_f32(a, 1);
//    float a3 = vgetq_lane_f32(a, 3);
//    float* res = stackalloc float[] {a1, a1, a3, a3};
//    return Arm.Neon.vld1q_f32(data));
//#endif
//}
//
//// Duplicate even-indexed single-precision (32-bit) floating-point elements
//// from a, and store the results in dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_moveldup_ps
//static v128 moveldup_ps(v128 a)
//{
//#if __has_builtin(__builtin_shufflevector)
//    return Arm.Neon.__builtin_shufflevector(
//        a, a, 0, 0, 2, 2));
//#else
//    float a0 = vgetq_lane_f32(a, 0);
//    float a2 = vgetq_lane_f32(a, 2);
//    float* res = stackalloc float[] {a0, a0, a2, a2};
//    return Arm.Neon.vld1q_f32(data));
//#endif
//}
//
///* SSSE3 */
//
//// Compute the absolute value of packed signed 16-bit integers in a, and store
//// the unsigned results in dst.
////
////   FOR j := 0 to 7
////     i := j*16
////     dst[i+15:i] := ABS(a[i+15:i])
////   ENDFOR
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_abs_epi16
//static v128 abs_epi16(v128 a)
//{
//    return vreinterpretq_m128i_s16(vabsq_s16(a));
//}
//
//// Compute the absolute value of packed signed 32-bit integers in a, and store
//// the unsigned results in dst.
////
////   FOR j := 0 to 3
////     i := j*32
////     dst[i+31:i] := ABS(a[i+31:i])
////   ENDFOR
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_abs_epi32
//static v128 abs_epi32(v128 a)
//{
//    return vreinterpretq_m128i_s32(vabsq_s32(a));
//}
//
//// Compute the absolute value of packed signed 8-bit integers in a, and store
//// the unsigned results in dst.
////
////   FOR j := 0 to 15
////     i := j*8
////     dst[i+7:i] := ABS(a[i+7:i])
////   ENDFOR
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_abs_epi8
//static v128 abs_epi8(v128 a)
//{
//    return vreinterpretq_m128i_s8(vabsq_s8(a));
//}
//
//// Compute the absolute value of packed signed 16-bit integers in a, and store
//// the unsigned results in dst.
////
////   FOR j := 0 to 3
////     i := j*16
////     dst[i+15:i] := ABS(a[i+15:i])
////   ENDFOR
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_abs_pi16
//static v64 abs_pi16(v64 a)
//{
//    return vreinterpret_m64_s16(vabs_s16(a));
//}
//
//// Compute the absolute value of packed signed 32-bit integers in a, and store
//// the unsigned results in dst.
////
////   FOR j := 0 to 1
////     i := j*32
////     dst[i+31:i] := ABS(a[i+31:i])
////   ENDFOR
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_abs_pi32
//static v64 abs_pi32(v64 a)
//{
//    return vreinterpret_m64_s32(vabs_s32(a));
//}
//
//// Compute the absolute value of packed signed 8-bit integers in a, and store
//// the unsigned results in dst.
////
////   FOR j := 0 to 7
////     i := j*8
////     dst[i+7:i] := ABS(a[i+7:i])
////   ENDFOR
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_abs_pi8
//static v64 abs_pi8(v64 a)
//{
//    return vreinterpret_m64_s8(vabs_s8(a));
//}
//
//// Concatenate 16-byte blocks in a and b into a 32-byte temporary result, shift
//// the result right by imm8 bytes, and store the low 16 bytes in dst.
////
////   tmp[255:0] := ((a[127:0] << 128)[255:0] OR b[127:0]) >> (imm8*8)
////   dst[127:0] := tmp[127:0]
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_alignr_epi8
//static v128 alignr_epi8(v128 a, v128 b, int imm)
//{
//    if (_sse2neon_unlikely(imm & ~31))
//        return setzero_si128();
//    int idx;
//    v128 tmp[2];
//    if (imm >= 16) {
//        idx = imm - 16;
//        tmp[0] = a;
//        tmp[1] = vdupq_n_u8(0);
//    } else {
//        idx = imm;
//        tmp[0] = b;
//        tmp[1] = a;
//    }
//    return vreinterpretq_m128i_u8(vld1q_u8(((usbyte const *) tmp) + idx));
//}
//
//// Concatenate 8-byte blocks in a and b into a 16-byte temporary result, shift
//// the result right by imm8 bytes, and store the low 8 bytes in dst.
////
////   tmp[127:0] := ((a[63:0] << 64)[127:0] OR b[63:0]) >> (imm8*8)
////   dst[63:0] := tmp[63:0]
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_alignr_pi8
//#define alignr_pi8(a, b, imm)                                           \
//    __extension__({                                                         \
//        v64 ret;                                                          \
//        if (_sse2neon_unlikely((imm) >= 16)) {                              \
//            ret = vreinterpret_m64_s8(vdup_n_s8(0));                        \
//        } else {                                                            \
//            v64 tmp_low, tmp_high;                                    \
//            if ((imm) >= 8) {                                               \
//                const int idx = (imm) -8;                                   \
//                tmp_low = a;                           \
//                tmp_high = vdup_n_u8(0);                                    \
//                ret = vreinterpret_m64_u8(vext_u8(tmp_low, tmp_high, idx)); \
//            } else {                                                        \
//                const int idx = (imm);                                      \
//                tmp_low = b;                           \
//                tmp_high = a;                          \
//                ret = vreinterpret_m64_u8(vext_u8(tmp_low, tmp_high, idx)); \
//            }                                                               \
//        }                                                                   \
//        ret;                                                                \
//    })
//
//// Computes pairwise add of each argument as a 16-bit signed or uinteger
//// values a and b.
//static v128 hadd_epi16(v128 _a, v128 _b)
//{
//    v128 a = vreinterpretq_s16_m128i(_a);
//    v128 b = vreinterpretq_s16_m128i(_b);
//#if defined(__aarch64__)
//    return vreinterpretq_m128i_s16(vpaddq_s16(a, b));
//#else
//    return vreinterpretq_m128i_s16(
//        vcombine_s16(vpadd_s16(vget_low_s16(a), vget_high_s16(a)),
//                     vpadd_s16(vget_low_s16(b), vget_high_s16(b))));
//#endif
//}
//
//// Computes pairwise add of each argument as a 32-bit signed or uinteger
//// values a and b.
//static v128 hadd_epi32(v128 _a, v128 _b)
//{
//    v128 a = vreinterpretq_s32_m128i(_a);
//    v128 b = vreinterpretq_s32_m128i(_b);
//    return vreinterpretq_m128i_s32(
//        vcombine_s32(vpadd_s32(vget_low_s32(a), vget_high_s32(a)),
//                     vpadd_s32(vget_low_s32(b), vget_high_s32(b))));
//}
//
//// Horizontally add adjacent pairs of 16-bit integers in a and b, and pack the
//// signed 16-bit results in dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_hadd_pi16
//static v64 hadd_pi16(v64 a, v64 b)
//{
//    return vreinterpret_m64_s16(
//        vpadd_s16(a, b));
//}
//
//// Horizontally add adjacent pairs of 32-bit integers in a and b, and pack the
//// signed 32-bit results in dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_hadd_pi32
//static v64 hadd_pi32(v64 a, v64 b)
//{
//    return vreinterpret_m64_s32(
//        vpadd_s32(a, b));
//}
//
//// Computes saturated pairwise sub of each argument as a 16-bit signed
//// integer values a and b.
//static v128 hadds_epi16(v128 _a, v128 _b)
//{
//#if defined(__aarch64__)
//    v128 a = vreinterpretq_s16_m128i(_a);
//    v128 b = vreinterpretq_s16_m128i(_b);
//    return vreinterpretq_s64_s16(
//        vqaddq_s16(vuzp1q_s16(a, b), vuzp2q_s16(a, b)));
//#else
//    v128 a = vreinterpretq_s32_m128i(_a);
//    v128 b = vreinterpretq_s32_m128i(_b);
//    // Interleave using vshrn/vmovn
//    // [a0|a2|a4|a6|b0|b2|b4|b6]
//    // [a1|a3|a5|a7|b1|b3|b5|b7]
//    v128 ab0246 = vcombine_s16(vmovn_s32(a), vmovn_s32(b));
//    v128 ab1357 = vcombine_s16(vshrn_n_s32(a, 16), vshrn_n_s32(b, 16));
//    // Saturated add
//    return vreinterpretq_m128i_s16(vqaddq_s16(ab0246, ab1357));
//#endif
//}
//
//// Horizontally add adjacent pairs of signed 16-bit integers in a and b using
//// saturation, and pack the signed 16-bit results in dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_hadds_pi16
//static v64 hadds_pi16(v64 _a, v64 _b)
//{
//    v64 a = vreinterpret_s16_m64(_a);
//    v64 b = vreinterpret_s16_m64(_b);
//#if defined(__aarch64__)
//    return vreinterpret_s64_s16(vqadd_s16(vuzp1_s16(a, b), vuzp2_s16(a, b)));
//#else
//    int16x4x2_t res = vuzp_s16(a, b);
//    return vreinterpret_s64_s16(vqadd_s16(res.val[0], res.val[1]));
//#endif
//}
//
//// Horizontally subtract adjacent pairs of 16-bit integers in a and b, and pack
//// the signed 16-bit results in dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_hsub_epi16
//static v128 hsub_epi16(v128 _a, v128 _b)
//{
//    v128 a = vreinterpretq_s16_m128i(_a);
//    v128 b = vreinterpretq_s16_m128i(_b);
//#if defined(__aarch64__)
//    return vreinterpretq_m128i_s16(
//        vsubq_s16(vuzp1q_s16(a, b), vuzp2q_s16(a, b)));
//#else
//    int16x8x2_t c = vuzpq_s16(a, b);
//    return vreinterpretq_m128i_s16(vsubq_s16(c.val[0], c.val[1]));
//#endif
//}
//
//// Horizontally subtract adjacent pairs of 32-bit integers in a and b, and pack
//// the signed 32-bit results in dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_hsub_epi32
//static v128 hsub_epi32(v128 _a, v128 _b)
//{
//    v128 a = vreinterpretq_s32_m128i(_a);
//    v128 b = vreinterpretq_s32_m128i(_b);
//#if defined(__aarch64__)
//    return vreinterpretq_m128i_s32(
//        vsubq_s32(vuzp1q_s32(a, b), vuzp2q_s32(a, b)));
//#else
//    int32x4x2_t c = vuzpq_s32(a, b);
//    return vreinterpretq_m128i_s32(vsubq_s32(c.val[0], c.val[1]));
//#endif
//}
//
//// Horizontally subtract adjacent pairs of 16-bit integers in a and b, and pack
//// the signed 16-bit results in dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_hsub_pi16
//static v64 hsub_pi16(v64 _a, v64 _b)
//{
//    v64 a = vreinterpret_s16_m64(_a);
//    v64 b = vreinterpret_s16_m64(_b);
//#if defined(__aarch64__)
//    return vreinterpret_m64_s16(vsub_s16(vuzp1_s16(a, b), vuzp2_s16(a, b)));
//#else
//    int16x4x2_t c = vuzp_s16(a, b);
//    return vreinterpret_m64_s16(vsub_s16(c.val[0], c.val[1]));
//#endif
//}
//
//// Horizontally subtract adjacent pairs of 32-bit integers in a and b, and pack
//// the signed 32-bit results in dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=mm_hsub_pi32
//static v64 hsub_pi32(v64 _a, v64 _b)
//{
//    v64 a = vreinterpret_s32_m64(_a);
//    v64 b = vreinterpret_s32_m64(_b);
//#if defined(__aarch64__)
//    return vreinterpret_m64_s32(vsub_s32(vuzp1_s32(a, b), vuzp2_s32(a, b)));
//#else
//    int32x2x2_t c = vuzp_s32(a, b);
//    return vreinterpret_m64_s32(vsub_s32(c.val[0], c.val[1]));
//#endif
//}
//
//// Computes saturated pairwise difference of each argument as a 16-bit signed
//// integer values a and b.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_hsubs_epi16
//static v128 hsubs_epi16(v128 _a, v128 _b)
//{
//    v128 a = vreinterpretq_s16_m128i(_a);
//    v128 b = vreinterpretq_s16_m128i(_b);
//#if defined(__aarch64__)
//    return vreinterpretq_m128i_s16(
//        vqsubq_s16(vuzp1q_s16(a, b), vuzp2q_s16(a, b)));
//#else
//    int16x8x2_t c = vuzpq_s16(a, b);
//    return vreinterpretq_m128i_s16(vqsubq_s16(c.val[0], c.val[1]));
//#endif
//}
//
//// Horizontally subtract adjacent pairs of signed 16-bit integers in a and b
//// using saturation, and pack the signed 16-bit results in dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_hsubs_pi16
//static v64 hsubs_pi16(v64 _a, v64 _b)
//{
//    v64 a = vreinterpret_s16_m64(_a);
//    v64 b = vreinterpret_s16_m64(_b);
//#if defined(__aarch64__)
//    return vreinterpret_m64_s16(vqsub_s16(vuzp1_s16(a, b), vuzp2_s16(a, b)));
//#else
//    int16x4x2_t c = vuzp_s16(a, b);
//    return vreinterpret_m64_s16(vqsub_s16(c.val[0], c.val[1]));
//#endif
//}
//
//// Vertically multiply each unsigned 8-bit integer from a with the corresponding
//// signed 8-bit integer from b, producing intermediate signed 16-bit integers.
//// Horizontally add adjacent pairs of intermediate signed 16-bit integers,
//// and pack the saturated results in dst.
////
////   FOR j := 0 to 7
////      i := j*16
////      dst[i+15:i] := Saturate_To_Int16( a[i+15:i+8]*b[i+15:i+8] +
////      a[i+7:i]*b[i+7:i] )
////   ENDFOR
//static v128 maddubs_epi16(v128 _a, v128 _b)
//{
//#if defined(__aarch64__)
//    v128 a = vreinterpretq_u8_m128i(_a);
//    v128 b = vreinterpretq_s8_m128i(_b);
//    v128 tl = vmulq_s16(vreinterpretq_s16_u16(vmovl_u8(vget_low_u8(a))),
//                             vmovl_s8(vget_low_s8(b)));
//    v128 th = vmulq_s16(vreinterpretq_s16_u16(vmovl_u8(vget_high_u8(a))),
//                             vmovl_s8(vget_high_s8(b)));
//    return vreinterpretq_m128i_s16(
//        vqaddq_s16(vuzp1q_s16(tl, th), vuzp2q_s16(tl, th)));
//#else
//    // This would be much simpler if x86 would choose to zero extend OR sign
//    // extend, not both. This could probably be optimized better.
//    v128 a = vreinterpretq_u16_m128i(_a);
//    v128 b = vreinterpretq_s16_m128i(_b);
//
//    // Zero extend a
//    v128 a_odd = vreinterpretq_s16_u16(vshrq_n_u16(a, 8));
//    v128 a_even = vreinterpretq_s16_u16(vbicq_u16(a, vdupq_n_u16(0xff00)));
//
//    // Sign extend by shifting left then shifting right.
//    v128 b_even = vshrq_n_s16(vshlq_n_s16(b, 8), 8);
//    v128 b_odd = vshrq_n_s16(b, 8);
//
//    // multiply
//    v128 prod1 = vmulq_s16(a_even, b_even);
//    v128 prod2 = vmulq_s16(a_odd, b_odd);
//
//    // saturated add
//    return vreinterpretq_m128i_s16(vqaddq_s16(prod1, prod2));
//#endif
//}
//
//// Vertically multiply each unsigned 8-bit integer from a with the corresponding
//// signed 8-bit integer from b, producing intermediate signed 16-bit integers.
//// Horizontally add adjacent pairs of intermediate signed 16-bit integers, and
//// pack the saturated results in dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_maddubs_pi16
//static v64 maddubs_pi16(v64 _a, v64 _b)
//{
//    v64 a = vreinterpret_u16_m64(_a);
//    v64 b = vreinterpret_s16_m64(_b);
//
//    // Zero extend a
//    v64 a_odd = vreinterpret_s16_u16(vshr_n_u16(a, 8));
//    v64 a_even = vreinterpret_s16_u16(vand_u16(a, vdup_n_u16(0xff)));
//
//    // Sign extend by shifting left then shifting right.
//    v64 b_even = vshr_n_s16(vshl_n_s16(b, 8), 8);
//    v64 b_odd = vshr_n_s16(b, 8);
//
//    // multiply
//    v64 prod1 = vmul_s16(a_even, b_even);
//    v64 prod2 = vmul_s16(a_odd, b_odd);
//
//    // saturated add
//    return vreinterpret_m64_s16(vqadd_s16(prod1, prod2));
//}
//
//// Multiply packed signed 16-bit integers in a and b, producing intermediate
//// signed 32-bit integers. Shift right by 15 bits while rounding up, and store
//// the packed 16-bit integers in dst.
////
////   r0 := Round(((int)a0 * (int)b0) >> 15)
////   r1 := Round(((int)a1 * (int)b1) >> 15)
////   r2 := Round(((int)a2 * (int)b2) >> 15)
////   ...
////   r7 := Round(((int)a7 * (int)b7) >> 15)
//static v128 mulhrs_epi16(v128 a, v128 b)
//{
//    // Has issues due to saturation
//    // return vreinterpretq_m128i_s16(vqrdmulhq_s16(a, b));
//
//    // Multiply
//    v128 mul_lo = vmull_s16(vget_low_s16(a),
//                                 vget_low_s16(b));
//    v128 mul_hi = vmull_s16(vget_high_s16(a),
//                                 vget_high_s16(b));
//
//    // Rounding narrowing shift right
//    // narrow = (int16_t)((mul + 16384) >> 15);
//    v64 narrow_lo = vrshrn_n_s32(mul_lo, 15);
//    v64 narrow_hi = vrshrn_n_s32(mul_hi, 15);
//
//    // Join together
//    return vreinterpretq_m128i_s16(vcombine_s16(narrow_lo, narrow_hi));
//}
//
//// Multiply packed signed 16-bit integers in a and b, producing intermediate
//// signed 32-bit integers. Truncate each intermediate integer to the 18 most
//// significant bits, round by adding 1, and store bits [16:1] to dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_mulhrs_pi16
//static v64 mulhrs_pi16(v64 a, v64 b)
//{
//    v128 mul_extend =
//        vmull_s16((a), (b));
//
//    // Rounding narrowing shift right
//    return vreinterpret_m64_s16(vrshrn_n_s32(mul_extend, 15));
//}
//
//// Shuffle packed 8-bit integers in a according to shuffle control mask in the
//// corresponding 8-bit element of b, and store the results in dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_shuffle_epi8
//static v128 shuffle_epi8(v128 a, v128 b)
//{
//    v128 tbl = a;   // input a
//    v128 idx = b;  // input b
//    v128 idx_masked =
//        vandq_u8(idx, vdupq_n_u8(0x8F));  // avoid using meaningless bits
//#if defined(__aarch64__)
//    return vreinterpretq_m128i_s8(vqtbl1q_s8(tbl, idx_masked));
//#elif defined(__GNUC__)
//    v128 ret;
//    // %e and %f represent the even and odd D registers
//    // respectively.
//    __asm__ __volatile__(
//        "vtbl.8  %e[ret], {%e[tbl], %f[tbl]}, %e[idx]\n"
//        "vtbl.8  %f[ret], {%e[tbl], %f[tbl]}, %f[idx]\n"
//        : [ret] "=&w"(ret)
//        : [tbl] "w"(tbl), [idx] "w"(idx_masked));
//    return vreinterpretq_m128i_s8(ret);
//#else
//    // use this line if testing on aarch64
//    int8x8x2_t a_split = {vget_low_s8(tbl), vget_high_s8(tbl)};
//    return vreinterpretq_m128i_s8(
//        vcombine_s8(vtbl2_s8(a_split, vget_low_u8(idx_masked)),
//                    vtbl2_s8(a_split, vget_high_u8(idx_masked))));
//#endif
//}
//
//// Shuffle packed 8-bit integers in a according to shuffle control mask in the
//// corresponding 8-bit element of b, and store the results in dst.
////
////   FOR j := 0 to 7
////     i := j*8
////     IF b[i+7] == 1
////       dst[i+7:i] := 0
////     ELSE
////       index[2:0] := b[i+2:i]
////       dst[i+7:i] := a[index*8+7:index*8]
////     FI
////   ENDFOR
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_shuffle_pi8
//static v64 shuffle_pi8(v64 a, v64 b)
//{
//    const v64 controlMask =
//        vand_s8(b, vdup_n_s8((sbyte) (0x1 << 7 | 0x07)));
//    v64 res = vtbl1_s8(a, controlMask);
//    return vreinterpret_m64_s8(res);
//}
//
//// Negate packed 16-bit integers in a when the corresponding signed
//// 16-bit integer in b is negative, and store the results in dst.
//// Element in dst are zeroed out when the corresponding element
//// in b is zero.
////
////   for i in 0..7
////     if b[i] < 0
////       r[i] := -a[i]
////     else if b[i] == 0
////       r[i] := 0
////     else
////       r[i] := a[i]
////     fi
////   done
//static v128 sign_epi16(v128 _a, v128 _b)
//{
//    v128 a = vreinterpretq_s16_m128i(_a);
//    v128 b = vreinterpretq_s16_m128i(_b);
//
//    // signed shift right: faster than vclt
//    // (b < 0) ? 0xFFFF : 0
//    v128 ltMask = vreinterpretq_u16_s16(vshrq_n_s16(b, 15));
//    // (b == 0) ? 0xFFFF : 0
//#if defined(__aarch64__)
//    v128 zeroMask = vreinterpretq_s16_u16(vceqzq_s16(b));
//#else
//    v128 zeroMask = vreinterpretq_s16_u16(vceqq_s16(b, vdupq_n_s16(0)));
//#endif
//
//    // bitwise select either a or negative 'a' (vnegq_s16(a) equals to negative
//    // 'a') based on ltMask
//    v128 masked = vbslq_s16(ltMask, vnegq_s16(a), a);
//    // res = masked & (~zeroMask)
//    v128 res = vbicq_s16(masked, zeroMask);
//    return vreinterpretq_m128i_s16(res);
//}
//
//// Negate packed 32-bit integers in a when the corresponding signed
//// 32-bit integer in b is negative, and store the results in dst.
//// Element in dst are zeroed out when the corresponding element
//// in b is zero.
////
////   for i in 0..3
////     if b[i] < 0
////       r[i] := -a[i]
////     else if b[i] == 0
////       r[i] := 0
////     else
////       r[i] := a[i]
////     fi
////   done
//static v128 sign_epi32(v128 _a, v128 _b)
//{
//    v128 a = vreinterpretq_s32_m128i(_a);
//    v128 b = vreinterpretq_s32_m128i(_b);
//
//    // signed shift right: faster than vclt
//    // (b < 0) ? 0xFFFFFFFF : 0
//    v128 ltMask = vreinterpretq_u32_s32(vshrq_n_s32(b, 31));
//
//    // (b == 0) ? 0xFFFFFFFF : 0
//#if defined(__aarch64__)
//    v128 zeroMask = vreinterpretq_s32_u32(vceqzq_s32(b));
//#else
//    v128 zeroMask = vreinterpretq_s32_u32(vceqq_s32(b, vdupq_n_s32(0)));
//#endif
//
//    // bitwise select either a or negative 'a' (vnegq_s32(a) equals to negative
//    // 'a') based on ltMask
//    v128 masked = vbslq_s32(ltMask, vnegq_s32(a), a);
//    // res = masked & (~zeroMask)
//    v128 res = vbicq_s32(masked, zeroMask);
//    return vreinterpretq_m128i_s32(res);
//}
//
//// Negate packed 8-bit integers in a when the corresponding signed
//// 8-bit integer in b is negative, and store the results in dst.
//// Element in dst are zeroed out when the corresponding element
//// in b is zero.
////
////   for i in 0..15
////     if b[i] < 0
////       r[i] := -a[i]
////     else if b[i] == 0
////       r[i] := 0
////     else
////       r[i] := a[i]
////     fi
////   done
//static v128 sign_epi8(v128 _a, v128 _b)
//{
//    v128 a = vreinterpretq_s8_m128i(_a);
//    v128 b = vreinterpretq_s8_m128i(_b);
//
//    // signed shift right: faster than vclt
//    // (b < 0) ? 0xFF : 0
//    v128 ltMask = vreinterpretq_u8_s8(vshrq_n_s8(b, 7));
//
//    // (b == 0) ? 0xFF : 0
//#if defined(__aarch64__)
//    v128 zeroMask = vreinterpretq_s8_u8(vceqzq_s8(b));
//#else
//    v128 zeroMask = vreinterpretq_s8_u8(vceqq_s8(b, vdupq_n_s8(0)));
//#endif
//
//    // bitwise select either a or negative 'a' (vnegq_s8(a) return negative 'a')
//    // based on ltMask
//    v128 masked = vbslq_s8(ltMask, vnegq_s8(a), a);
//    // res = masked & (~zeroMask)
//    v128 res = vbicq_s8(masked, zeroMask);
//
//    return vreinterpretq_m128i_s8(res);
//}
//
//// Negate packed 16-bit integers in a when the corresponding signed 16-bit
//// integer in b is negative, and store the results in dst. Element in dst are
//// zeroed out when the corresponding element in b is zero.
////
////   FOR j := 0 to 3
////      i := j*16
////      IF b[i+15:i] < 0
////        dst[i+15:i] := -(a[i+15:i])
////      ELSE IF b[i+15:i] == 0
////        dst[i+15:i] := 0
////      ELSE
////        dst[i+15:i] := a[i+15:i]
////      FI
////   ENDFOR
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_sign_pi16
//static v64 sign_pi16(v64 _a, v64 _b)
//{
//    v64 a = vreinterpret_s16_m64(_a);
//    v64 b = vreinterpret_s16_m64(_b);
//
//    // signed shift right: faster than vclt
//    // (b < 0) ? 0xFFFF : 0
//    v64 ltMask = vreinterpret_u16_s16(vshr_n_s16(b, 15));
//
//    // (b == 0) ? 0xFFFF : 0
//#if defined(__aarch64__)
//    v64 zeroMask = vreinterpret_s16_u16(vceqz_s16(b));
//#else
//    v64 zeroMask = vreinterpret_s16_u16(vceq_s16(b, vdup_n_s16(0)));
//#endif
//
//    // bitwise select either a or negative 'a' (vneg_s16(a) return negative 'a')
//    // based on ltMask
//    v64 masked = vbsl_s16(ltMask, vneg_s16(a), a);
//    // res = masked & (~zeroMask)
//    v64 res = vbic_s16(masked, zeroMask);
//
//    return vreinterpret_m64_s16(res);
//}
//
//// Negate packed 32-bit integers in a when the corresponding signed 32-bit
//// integer in b is negative, and store the results in dst. Element in dst are
//// zeroed out when the corresponding element in b is zero.
////
////   FOR j := 0 to 1
////      i := j*32
////      IF b[i+31:i] < 0
////        dst[i+31:i] := -(a[i+31:i])
////      ELSE IF b[i+31:i] == 0
////        dst[i+31:i] := 0
////      ELSE
////        dst[i+31:i] := a[i+31:i]
////      FI
////   ENDFOR
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_sign_pi32
//static v64 sign_pi32(v64 _a, v64 _b)
//{
//    v64 a = vreinterpret_s32_m64(_a);
//    v64 b = vreinterpret_s32_m64(_b);
//
//    // signed shift right: faster than vclt
//    // (b < 0) ? 0xFFFFFFFF : 0
//    v64 ltMask = vreinterpret_u32_s32(vshr_n_s32(b, 31));
//
//    // (b == 0) ? 0xFFFFFFFF : 0
//#if defined(__aarch64__)
//    v64 zeroMask = vreinterpret_s32_u32(vceqz_s32(b));
//#else
//    v64 zeroMask = vreinterpret_s32_u32(vceq_s32(b, vdup_n_s32(0)));
//#endif
//
//    // bitwise select either a or negative 'a' (vneg_s32(a) return negative 'a')
//    // based on ltMask
//    v64 masked = vbsl_s32(ltMask, vneg_s32(a), a);
//    // res = masked & (~zeroMask)
//    v64 res = vbic_s32(masked, zeroMask);
//
//    return vreinterpret_m64_s32(res);
//}
//
//// Negate packed 8-bit integers in a when the corresponding signed 8-bit integer
//// in b is negative, and store the results in dst. Element in dst are zeroed out
//// when the corresponding element in b is zero.
////
////   FOR j := 0 to 7
////      i := j*8
////      IF b[i+7:i] < 0
////        dst[i+7:i] := -(a[i+7:i])
////      ELSE IF b[i+7:i] == 0
////        dst[i+7:i] := 0
////      ELSE
////        dst[i+7:i] := a[i+7:i]
////      FI
////   ENDFOR
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_sign_pi8
//static v64 sign_pi8(v64 _a, v64 _b)
//{
//    v64 a = vreinterpret_s8_m64(_a);
//    v64 b = vreinterpret_s8_m64(_b);
//
//    // signed shift right: faster than vclt
//    // (b < 0) ? 0xFF : 0
//    v64 ltMask = vreinterpret_u8_s8(vshr_n_s8(b, 7));
//
//    // (b == 0) ? 0xFF : 0
//#if defined(__aarch64__)
//    v64 zeroMask = vreinterpret_s8_u8(vceqz_s8(b));
//#else
//    v64 zeroMask = vreinterpret_s8_u8(vceq_s8(b, vdup_n_s8(0)));
//#endif
//
//    // bitwise select either a or negative 'a' (vneg_s8(a) return negative 'a')
//    // based on ltMask
//    v64 masked = vbsl_s8(ltMask, vneg_s8(a), a);
//    // res = masked & (~zeroMask)
//    v64 res = vbic_s8(masked, zeroMask);
//
//    return vreinterpret_m64_s8(res);
//}
//
///* SSE4.1 */
//
//// Blend packed 16-bit integers from a and b using control mask imm8, and store
//// the results in dst.
////
////   FOR j := 0 to 7
////       i := j*16
////       IF imm8[j]
////           dst[i+15:i] := b[i+15:i]
////       ELSE
////           dst[i+15:i] := a[i+15:i]
////       FI
////   ENDFOR
//// static v128 blend_epi16(v128 a, v128 b,
////                                      __constrange(0,255) int imm)
//#define blend_epi16(a, b, imm)                                            \
//    __extension__({                                                           \
//        const uint16_t _mask[8] = {((imm) & (1 << 0)) ? (uint16_t) -1 : 0x0,  \
//                                   ((imm) & (1 << 1)) ? (uint16_t) -1 : 0x0,  \
//                                   ((imm) & (1 << 2)) ? (uint16_t) -1 : 0x0,  \
//                                   ((imm) & (1 << 3)) ? (uint16_t) -1 : 0x0,  \
//                                   ((imm) & (1 << 4)) ? (uint16_t) -1 : 0x0,  \
//                                   ((imm) & (1 << 5)) ? (uint16_t) -1 : 0x0,  \
//                                   ((imm) & (1 << 6)) ? (uint16_t) -1 : 0x0,  \
//                                   ((imm) & (1 << 7)) ? (uint16_t) -1 : 0x0}; \
//        v128 _mask_vec = vld1q_u16(_mask);                              \
//        v128 _a = a;                           \
//        v128 _b = b;                           \
//        vreinterpretq_m128i_u16(vbslq_u16(_mask_vec, _b, _a));                \
//    })
//
//// Blend packed double-precision (64-bit) floating-point elements from a and b
//// using control mask imm8, and store the results in dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_blend_pd
//#define blend_pd(a, b, imm)                                \
//    __extension__({                                            \
//        const ulong _mask[2] = {                            \
//            ((imm) & (1 << 0)) ? ~UINT64_C(0) : UINT64_C(0),   \
//            ((imm) & (1 << 1)) ? ~UINT64_C(0) : UINT64_C(0)};  \
//        v128 _mask_vec = vld1q_u64(_mask);               \
//        v128 _a = a;            \
//        v128 _b = b;            \
//        vreinterpretq_m128d_u64(vbslq_u64(_mask_vec, _b, _a)); \
//    })
//
//// Blend packed single-precision (32-bit) floating-point elements from a and b
//// using mask, and store the results in dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_blend_ps
//static v128 blend_ps(v128 _a, v128 _b, const byte imm8)
//{
//    const uint ALIGN_STRUCT(16)
//        data[4] = {((imm8) & (1 << 0)) ? UINT32_MAX : 0,
//                   ((imm8) & (1 << 1)) ? UINT32_MAX : 0,
//                   ((imm8) & (1 << 2)) ? UINT32_MAX : 0,
//                   ((imm8) & (1 << 3)) ? UINT32_MAX : 0};
//    v128 mask = vld1q_u32(data);
//    v128 a = vreinterpretq_f32_m128(_a);
//    v128 b = vreinterpretq_f32_m128(_b);
//    return Arm.Neon.vbslq_f32(mask, b, a));
//}
//
//// Blend packed 8-bit integers from a and b using mask, and store the results in
//// dst.
////
////   FOR j := 0 to 15
////       i := j*8
////       IF mask[i+7]
////           dst[i+7:i] := b[i+7:i]
////       ELSE
////           dst[i+7:i] := a[i+7:i]
////       FI
////   ENDFOR
//static v128 blendv_epi8(v128 _a, v128 _b, v128 _mask)
//{
//    // Use a signed shift right to create a mask with the sign bit
//    v128 mask =
//        vreinterpretq_u8_s8(vshrq_n_s8(vreinterpretq_s8_m128i(_mask), 7));
//    v128 a = vreinterpretq_u8_m128i(_a);
//    v128 b = vreinterpretq_u8_m128i(_b);
//    return vreinterpretq_m128i_u8(vbslq_u8(mask, b, a));
//}
//
//// Blend packed double-precision (64-bit) floating-point elements from a and b
//// using mask, and store the results in dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_blendv_pd
//static v128 blendv_pd(v128 _a, v128 _b, v128 _mask)
//{
//    v128 mask =
//        vreinterpretq_u64_s64(vshrq_n_s64(vreinterpretq_s64_m128d(_mask), 63));
//#if defined(__aarch64__)
//    v128 a = vreinterpretq_f64_m128d(_a);
//    v128 b = vreinterpretq_f64_m128d(_b);
//    return vreinterpretq_m128d_f64(vbslq_f64(mask, b, a));
//#else
//    v128 a = vreinterpretq_u64_m128d(_a);
//    v128 b = vreinterpretq_u64_m128d(_b);
//    return vreinterpretq_m128d_u64(vbslq_u64(mask, b, a));
//#endif
//}
//
//// Blend packed single-precision (32-bit) floating-point elements from a and b
//// using mask, and store the results in dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_blendv_ps
//static v128 blendv_ps(v128 _a, v128 _b, v128 _mask)
//{
//    // Use a signed shift right to create a mask with the sign bit
//    v128 mask =
//        vreinterpretq_u32_s32(vshrq_n_s32(vreinterpretq_s32_m128(_mask), 31));
//    v128 a = vreinterpretq_f32_m128(_a);
//    v128 b = vreinterpretq_f32_m128(_b);
//    return Arm.Neon.vbslq_f32(mask, b, a));
//}
//
//// Round the packed double-precision (64-bit) floating-point elements in a up
//// to an integer value, and store the results as packed double-precision
//// floating-point elements in dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_ceil_pd
//static v128 ceil_pd(v128 a)
//{
//#if defined(__aarch64__)
//    return vreinterpretq_m128d_f64(vrndpq_f64(a));
//#else
//    double *f = (double *) &a;
//    return set_pd(ceil(f[1]), ceil(f[0]));
//#endif
//}
//
//// Round the packed single-precision (32-bit) floating-point elements in a up to
//// an integer value, and store the results as packed single-precision
//// floating-point elements in dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_ceil_ps
//static v128 ceil_ps(v128 a)
//{
//#if defined(__aarch64__) || defined(__ARM_FEATURE_DIRECTED_ROUNDING)
//    return Arm.Neon.vrndpq_f32(a));
//#else
//    float *f = (float *) &a;
//    return set_ps(ceilf(f[3]), ceilf(f[2]), ceilf(f[1]), ceilf(f[0]));
//#endif
//}
//
//// Round the lower double-precision (64-bit) floating-point element in b up to
//// an integer value, store the result as a double-precision floating-point
//// element in the lower element of dst, and copy the upper element from a to the
//// upper element of dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_ceil_sd
//static v128 ceil_sd(v128 a, v128 b)
//{
//    return move_sd(a, ceil_pd(b));
//}
//
//// Round the lower single-precision (32-bit) floating-point element in b up to
//// an integer value, store the result as a single-precision floating-point
//// element in the lower element of dst, and copy the upper 3 packed elements
//// from a to the upper elements of dst.
////
////   dst[31:0] := CEIL(b[31:0])
////   dst[127:32] := a[127:32]
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_ceil_ss
//static v128 ceil_ss(v128 a, v128 b)
//{
//    return move_ss(a, ceil_ps(b));
//}
//
//// Compare packed 64-bit integers in a and b for equality, and store the results
//// in dst
//static v128 cmpeq_epi64(v128 a, v128 b)
//{
//#if defined(__aarch64__)
//    return vreinterpretq_m128i_u64(
//        vceqq_u64(a, b));
//#else
//    // ARMv7 lacks vceqq_u64
//    // (a == b) -> (a_lo == b_lo) && (a_hi == b_hi)
//    v128 cmp =
//        vceqq_u32(vreinterpretq_u32_m128i(a), vreinterpretq_u32_m128i(b));
//    v128 swapped = vrev64q_u32(cmp);
//    return vreinterpretq_m128i_u32(vandq_u32(cmp, swapped));
//#endif
//}
//
//// Converts the four signed 16-bit integers in the lower 64 bits to four signed
//// 32-bit integers.
//static v128 cvtepi16_epi32(v128 a)
//{
//    return vreinterpretq_m128i_s32(
//        vmovl_s16(vget_low_s16(a)));
//}
//
//// Converts the two signed 16-bit integers in the lower 32 bits two signed
//// 32-bit integers.
//static v128 cvtepi16_epi64(v128 a)
//{
//    v128 s16x8 = a;     /* xxxx xxxx xxxx 0B0A */
//    v128 s32x4 = vmovl_s16(vget_low_s16(s16x8)); /* 000x 000x 000B 000A */
//    v128 s64x2 = vmovl_s32(vget_low_s32(s32x4)); /* 0000 000B 0000 000A */
//    return vreinterpretq_m128i_s64(s64x2);
//}
//
//// Converts the two signed 32-bit integers in the lower 64 bits to two signed
//// 64-bit integers.
//static v128 cvtepi32_epi64(v128 a)
//{
//    return vreinterpretq_m128i_s64(
//        vmovl_s32(vget_low_s32(a)));
//}
//
//// Converts the four unsigned 8-bit integers in the lower 16 bits to four
//// unsigned 32-bit integers.
//static v128 cvtepi8_epi16(v128 a)
//{
//    v128 s8x16 = a;    /* xxxx xxxx xxxx DCBA */
//    v128 s16x8 = vmovl_s8(vget_low_s8(s8x16)); /* 0x0x 0x0x 0D0C 0B0A */
//    return vreinterpretq_m128i_s16(s16x8);
//}
//
//// Converts the four unsigned 8-bit integers in the lower 32 bits to four
//// unsigned 32-bit integers.
//static v128 cvtepi8_epi32(v128 a)
//{
//    v128 s8x16 = a;      /* xxxx xxxx xxxx DCBA */
//    v128 s16x8 = vmovl_s8(vget_low_s8(s8x16));   /* 0x0x 0x0x 0D0C 0B0A */
//    v128 s32x4 = vmovl_s16(vget_low_s16(s16x8)); /* 000D 000C 000B 000A */
//    return vreinterpretq_m128i_s32(s32x4);
//}
//
//// Converts the two signed 8-bit integers in the lower 32 bits to four
//// signed 64-bit integers.
//static v128 cvtepi8_epi64(v128 a)
//{
//    v128 s8x16 = a;      /* xxxx xxxx xxxx xxBA */
//    v128 s16x8 = vmovl_s8(vget_low_s8(s8x16));   /* 0x0x 0x0x 0x0x 0B0A */
//    v128 s32x4 = vmovl_s16(vget_low_s16(s16x8)); /* 000x 000x 000B 000A */
//    v128 s64x2 = vmovl_s32(vget_low_s32(s32x4)); /* 0000 000B 0000 000A */
//    return vreinterpretq_m128i_s64(s64x2);
//}
//
//// Converts the four unsigned 16-bit integers in the lower 64 bits to four
//// unsigned 32-bit integers.
//static v128 cvtepu16_epi32(v128 a)
//{
//    return vreinterpretq_m128i_u32(
//        vmovl_u16(vget_low_u16(a)));
//}
//
//// Converts the two unsigned 16-bit integers in the lower 32 bits to two
//// unsigned 64-bit integers.
//static v128 cvtepu16_epi64(v128 a)
//{
//    v128 u16x8 = a;     /* xxxx xxxx xxxx 0B0A */
//    v128 u32x4 = vmovl_u16(vget_low_u16(u16x8)); /* 000x 000x 000B 000A */
//    v128 u64x2 = vmovl_u32(vget_low_u32(u32x4)); /* 0000 000B 0000 000A */
//    return vreinterpretq_m128i_u64(u64x2);
//}
//
//// Converts the two unsigned 32-bit integers in the lower 64 bits to two
//// unsigned 64-bit integers.
//static v128 cvtepu32_epi64(v128 a)
//{
//    return vreinterpretq_m128i_u64(
//        vmovl_u32(vget_low_u32(vreinterpretq_u32_m128i(a))));
//}
//
//// Zero extend packed unsigned 8-bit integers in a to packed 16-bit integers,
//// and store the results in dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_cvtepu8_epi16
//static v128 cvtepu8_epi16(v128 a)
//{
//    v128 u8x16 = a;    /* xxxx xxxx HGFE DCBA */
//    v128 u16x8 = vmovl_u8(vget_low_u8(u8x16)); /* 0H0G 0F0E 0D0C 0B0A */
//    return vreinterpretq_m128i_u16(u16x8);
//}
//
//// Converts the four unsigned 8-bit integers in the lower 32 bits to four
//// unsigned 32-bit integers.
//// https://msdn.microsoft.com/en-us/library/bb531467%28v=vs.100%29.aspx
//static v128 cvtepu8_epi32(v128 a)
//{
//    v128 u8x16 = a;      /* xxxx xxxx xxxx DCBA */
//    v128 u16x8 = vmovl_u8(vget_low_u8(u8x16));   /* 0x0x 0x0x 0D0C 0B0A */
//    v128 u32x4 = vmovl_u16(vget_low_u16(u16x8)); /* 000D 000C 000B 000A */
//    return vreinterpretq_m128i_u32(u32x4);
//}
//
//// Converts the two unsigned 8-bit integers in the lower 16 bits to two
//// unsigned 64-bit integers.
//static v128 cvtepu8_epi64(v128 a)
//{
//    v128 u8x16 = a;      /* xxxx xxxx xxxx xxBA */
//    v128 u16x8 = vmovl_u8(vget_low_u8(u8x16));   /* 0x0x 0x0x 0x0x 0B0A */
//    v128 u32x4 = vmovl_u16(vget_low_u16(u16x8)); /* 000x 000x 000B 000A */
//    v128 u64x2 = vmovl_u32(vget_low_u32(u32x4)); /* 0000 000B 0000 000A */
//    return vreinterpretq_m128i_u64(u64x2);
//}
//
//// Conditionally multiply the packed double-precision (64-bit) floating-point
//// elements in a and b using the high 4 bits in imm8, sum the four products, and
//// conditionally store the sum in dst using the low 4 bits of imm8.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_dp_pd
//static v128 dp_pd(v128 a, v128 b, const int imm)
//{
//    // Generate mask value from constant immediate bit value
//    const long bit0Mask = imm & 0x01 ? UINT64_MAX : 0;
//    const long bit1Mask = imm & 0x02 ? UINT64_MAX : 0;
//#if !SSE2NEON_PRECISE_DP
//    const long bit4Mask = imm & 0x10 ? UINT64_MAX : 0;
//    const long bit5Mask = imm & 0x20 ? UINT64_MAX : 0;
//#endif
//    // Conditional multiplication
//#if !SSE2NEON_PRECISE_DP
//    v128 mul = mul_pd(a, b);
//    const v128 mulMask =
//        castsi128_pd(_mm_set_epi64x(bit5Mask, bit4Mask));
//    v128 tmp = and_pd(mul, mulMask);
//#else
//#if defined(__aarch64__)
//    double d0 = (imm & 0x10) ? vgetq_lane_f64(a, 0) *
//                                   vgetq_lane_f64(b, 0)
//                             : 0;
//    double d1 = (imm & 0x20) ? vgetq_lane_f64(a, 1) *
//                                   vgetq_lane_f64(b, 1)
//                             : 0;
//#else
//    double d0 = (imm & 0x10) ? ((double *) &a)[0] * ((double *) &b)[0] : 0;
//    double d1 = (imm & 0x20) ? ((double *) &a)[1] * ((double *) &b)[1] : 0;
//#endif
//    v128 tmp = set_pd(d1, d0);
//#endif
//    // Sum the products
//#if defined(__aarch64__)
//    double sum = vpaddd_f64(vreinterpretq_f64_m128d(tmp));
//#else
//    double sum = *((double *) &tmp) + *(((double *) &tmp) + 1);
//#endif
//    // Conditionally store the sum
//    const v128 sumMask =
//        castsi128_pd(_mm_set_epi64x(bit1Mask, bit0Mask));
//    v128 res = and_pd(_mm_set_pd1(sum), sumMask);
//    return res;
//}
//
//// Conditionally multiply the packed single-precision (32-bit) floating-point
//// elements in a and b using the high 4 bits in imm8, sum the four products,
//// and conditionally store the sum in dst using the low 4 bits of imm.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_dp_ps
//static v128 dp_ps(v128 a, v128 b, const int imm)
//{
//#if defined(__aarch64__)
//    /* shortcuts */
//    if (imm == 0xFF) {
//        return set1_ps(vaddvq_f32(_mm_mul_ps(a, b)));
//    }
//    if (imm == 0x7F) {
//        v128 m = mul_ps(a, b);
//        m[3] = 0;
//        return set1_ps(vaddvq_f32(m));
//    }
//#endif
//
//    float s = 0, c = 0;
//    v128 f32a = a;
//    v128 f32b = b;
//
//    /* To improve the accuracy of floating-point summation, Kahan algorithm
//     * is used for each operation.
//     */
//    if (imm & (1 << 4))
//        _sse2neon_kadd_f32(&s, &c, f32a[0] * f32b[0]);
//    if (imm & (1 << 5))
//        _sse2neon_kadd_f32(&s, &c, f32a[1] * f32b[1]);
//    if (imm & (1 << 6))
//        _sse2neon_kadd_f32(&s, &c, f32a[2] * f32b[2]);
//    if (imm & (1 << 7))
//        _sse2neon_kadd_f32(&s, &c, f32a[3] * f32b[3]);
//    s += c;
//
//    v128 res = {
//        (imm & 0x1) ? s : 0,
//        (imm & 0x2) ? s : 0,
//        (imm & 0x4) ? s : 0,
//        (imm & 0x8) ? s : 0,
//    };
//    return Arm.Neon.res);
//}
//
//// Extracts the selected signed or unsigned 32-bit integer from a and zero
//// extends.
//// static int extract_epi32(v128 a, __constrange(0,4) int imm)
//#define extract_epi32(a, imm) \
//    vgetq_lane_s32(a, (imm))
//
//// Extracts the selected signed or unsigned 64-bit integer from a and zero
//// extends.
//// static long extract_epi64(v128 a, __constrange(0,2) int imm)
//#define extract_epi64(a, imm) \
//    vgetq_lane_s64(a, (imm))
//
//// Extracts the selected signed or unsigned 8-bit integer from a and zero
//// extends.
//// static int extract_epi8(v128 a, __constrange(0,16) int imm)
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_extract_epi8
//#define extract_epi8(a, imm) vgetq_lane_u8(a, (imm))
//
//// Extracts the selected single-precision (32-bit) floating-point from a.
//// static int extract_ps(v128 a, __constrange(0,4) int imm)
//#define extract_ps(a, imm) vgetq_lane_s32(a, (imm))
//
//// Round the packed double-precision (64-bit) floating-point elements in a down
//// to an integer value, and store the results as packed double-precision
//// floating-point elements in dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_floor_pd
//static v128 floor_pd(v128 a)
//{
//#if defined(__aarch64__)
//    return vreinterpretq_m128d_f64(vrndmq_f64(a));
//#else
//    double *f = (double *) &a;
//    return set_pd(floor(f[1]), floor(f[0]));
//#endif
//}
//
//// Round the packed single-precision (32-bit) floating-point elements in a down
//// to an integer value, and store the results as packed single-precision
//// floating-point elements in dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_floor_ps
//static v128 floor_ps(v128 a)
//{
//#if defined(__aarch64__) || defined(__ARM_FEATURE_DIRECTED_ROUNDING)
//    return Arm.Neon.vrndmq_f32(a));
//#else
//    float *f = (float *) &a;
//    return set_ps(floorf(f[3]), floorf(f[2]), floorf(f[1]), floorf(f[0]));
//#endif
//}
//
//// Round the lower double-precision (64-bit) floating-point element in b down to
//// an integer value, store the result as a double-precision floating-point
//// element in the lower element of dst, and copy the upper element from a to the
//// upper element of dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_floor_sd
//static v128 floor_sd(v128 a, v128 b)
//{
//    return move_sd(a, floor_pd(b));
//}
//
//// Round the lower single-precision (32-bit) floating-point element in b down to
//// an integer value, store the result as a single-precision floating-point
//// element in the lower element of dst, and copy the upper 3 packed elements
//// from a to the upper elements of dst.
////
////   dst[31:0] := FLOOR(b[31:0])
////   dst[127:32] := a[127:32]
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_floor_ss
//static v128 floor_ss(v128 a, v128 b)
//{
//    return move_ss(a, floor_ps(b));
//}
//
//// Inserts the least significant 32 bits of b into the selected 32-bit integer
//// of a.
//// static v128 insert_epi32(v128 a, int b,
////                                       __constrange(0,4) int imm)
//#define insert_epi32(a, b, imm)                                  \
//    __extension__({                                                  \
//        vreinterpretq_m128i_s32(                                     \
//            vsetq_lane_s32((b), a, (imm))); \
//    })
//
//// Inserts the least significant 64 bits of b into the selected 64-bit integer
//// of a.
//// static v128 insert_epi64(v128 a, long b,
////                                       __constrange(0,2) int imm)
//#define insert_epi64(a, b, imm)                                  \
//    __extension__({                                                  \
//        vreinterpretq_m128i_s64(                                     \
//            vsetq_lane_s64((b), a, (imm))); \
//    })
//
//// Inserts the least significant 8 bits of b into the selected 8-bit integer
//// of a.
//// static v128 insert_epi8(v128 a, int b,
////                                      __constrange(0,16) int imm)
//#define insert_epi8(a, b, imm)                                 \
//    __extension__({                                                \
//        vreinterpretq_m128i_s8(                                    \
//            vsetq_lane_s8((b), a, (imm))); \
//    })
//
//// Copy a to tmp, then insert a single-precision (32-bit) floating-point
//// element from b into tmp using the control in imm8. Store tmp to dst using
//// the mask in imm8 (elements are zeroed out when the corresponding bit is set).
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=insert_ps
//#define insert_ps(a, b, imm8)                                              \
//    __extension__({                                                            \
//        v128 tmp1 =                                                     \
//            vsetq_lane_f32(vgetq_lane_f32(b, (imm8 >> 6) & 0x3),               \
//                           a, 0);                      \
//        v128 tmp2 =                                                     \
//            vsetq_lane_f32(vgetq_lane_f32(tmp1, 0), a, \
//                           ((imm8 >> 4) & 0x3));                               \
//        const uint data[4] = {((imm8) & (1 << 0)) ? UINT32_MAX : 0,        \
//                                  ((imm8) & (1 << 1)) ? UINT32_MAX : 0,        \
//                                  ((imm8) & (1 << 2)) ? UINT32_MAX : 0,        \
//                                  ((imm8) & (1 << 3)) ? UINT32_MAX : 0};       \
//        v128 mask = vld1q_u32(data);                                     \
//        v128 all_zeros = vdupq_n_f32(0);                                \
//                                                                               \
//        vreinterpretq_m128_f32(                                                \
//            vbslq_f32(mask, all_zeros, vreinterpretq_f32_m128(tmp2)));         \
//    })
//
//// epi versions of min/max
//// Computes the pariwise maximums of the four signed 32-bit integer values of a
//// and b.
////
//// A 128-bit parameter that can be defined with the following equations:
////   r0 := (a0 > b0) ? a0 : b0
////   r1 := (a1 > b1) ? a1 : b1
////   r2 := (a2 > b2) ? a2 : b2
////   r3 := (a3 > b3) ? a3 : b3
////
//// https://msdn.microsoft.com/en-us/library/vstudio/bb514055(v=vs.100).aspx
//static v128 max_epi32(v128 a, v128 b)
//{
//    return vreinterpretq_m128i_s32(
//        vmaxq_s32(a, b));
//}
//
//// Compare packed signed 8-bit integers in a and b, and store packed maximum
//// values in dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_max_epi8
//static v128 max_epi8(v128 a, v128 b)
//{
//    return vreinterpretq_m128i_s8(
//        vmaxq_s8(a, b));
//}
//
//// Compare packed unsigned 16-bit integers in a and b, and store packed maximum
//// values in dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_max_epu16
//static v128 max_epu16(v128 a, v128 b)
//{
//    return vreinterpretq_m128i_u16(
//        vmaxq_u16(a, b));
//}
//
//// Compare packed unsigned 32-bit integers in a and b, and store packed maximum
//// values in dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_max_epu32
//static v128 max_epu32(v128 a, v128 b)
//{
//    return vreinterpretq_m128i_u32(
//        vmaxq_u32(vreinterpretq_u32_m128i(a), vreinterpretq_u32_m128i(b)));
//}
//
//// Computes the pariwise minima of the four signed 32-bit integer values of a
//// and b.
////
//// A 128-bit parameter that can be defined with the following equations:
////   r0 := (a0 < b0) ? a0 : b0
////   r1 := (a1 < b1) ? a1 : b1
////   r2 := (a2 < b2) ? a2 : b2
////   r3 := (a3 < b3) ? a3 : b3
////
//// https://msdn.microsoft.com/en-us/library/vstudio/bb531476(v=vs.100).aspx
//static v128 min_epi32(v128 a, v128 b)
//{
//    return vreinterpretq_m128i_s32(
//        vminq_s32(a, b));
//}
//
//// Compare packed signed 8-bit integers in a and b, and store packed minimum
//// values in dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_min_epi8
//static v128 min_epi8(v128 a, v128 b)
//{
//    return vreinterpretq_m128i_s8(
//        vminq_s8(a, b));
//}
//
//// Compare packed unsigned 16-bit integers in a and b, and store packed minimum
//// values in dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_min_epu16
//static v128 min_epu16(v128 a, v128 b)
//{
//    return vreinterpretq_m128i_u16(
//        vminq_u16(a, b));
//}
//
//// Compare packed unsigned 32-bit integers in a and b, and store packed minimum
//// values in dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_max_epu32
//static v128 min_epu32(v128 a, v128 b)
//{
//    return vreinterpretq_m128i_u32(
//        vminq_u32(vreinterpretq_u32_m128i(a), vreinterpretq_u32_m128i(b)));
//}
//
//// Horizontally compute the minimum amongst the packed unsigned 16-bit integers
//// in a, store the minimum and index in dst, and zero the remaining bits in dst.
////
////   index[2:0] := 0
////   min[15:0] := a[15:0]
////   FOR j := 0 to 7
////       i := j*16
////       IF a[i+15:i] < min[15:0]
////           index[2:0] := j
////           min[15:0] := a[i+15:i]
////       FI
////   ENDFOR
////   dst[15:0] := min[15:0]
////   dst[18:16] := index[2:0]
////   dst[127:19] := 0
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_minpos_epu16
//static v128 minpos_epu16(v128 a)
//{
//    v128 dst;
//    uint16_t min, idx = 0;
//    // Find the minimum value
//#if defined(__aarch64__)
//    min = vminvq_u16(a);
//#else
//    v64 tmp;
//    tmp = vreinterpret_m64_u16(
//        vmin_u16(vget_low_u16(a),
//                 vget_high_u16(a)));
//    tmp = vreinterpret_m64_u16(
//        vpmin_u16(vreinterpret_u16_m64(tmp), vreinterpret_u16_m64(tmp)));
//    tmp = vreinterpret_m64_u16(
//        vpmin_u16(vreinterpret_u16_m64(tmp), vreinterpret_u16_m64(tmp)));
//    min = vget_lane_u16(vreinterpret_u16_m64(tmp), 0);
//#endif
//    // Get the index of the minimum value
//    int i;
//    for (i = 0; i < 8; i++) {
//        if (min == vgetq_lane_u16(a, 0)) {
//            idx = (uint16_t) i;
//            break;
//        }
//        a = srli_si128(a, 2);
//    }
//    // Generate result
//    dst = setzero_si128();
//    dst = vreinterpretq_m128i_u16(
//        vsetq_lane_u16(min, vreinterpretq_u16_m128i(dst), 0));
//    dst = vreinterpretq_m128i_u16(
//        vsetq_lane_u16(idx, vreinterpretq_u16_m128i(dst), 1));
//    return dst;
//}
//
//// Compute the sum of absolute differences (SADs) of quadruplets of unsigned
//// 8-bit integers in a compared to those in b, and store the 16-bit results in
//// dst. Eight SADs are performed using one quadruplet from b and eight
//// quadruplets from a. One quadruplet is selected from b starting at on the
//// offset specified in imm8. Eight quadruplets are formed from sequential 8-bit
//// integers selected from a starting at the offset specified in imm8.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_mpsadbw_epu8
//static v128 mpsadbw_epu8(v128 a, v128 b, const int imm)
//{
//    v128 _a, _b;
//
//    switch (imm & 0x4) {
//    case 0:
//        // do nothing
//        _a = a;
//        break;
//    case 4:
//        _a = vreinterpretq_u8_u32(vextq_u32(vreinterpretq_u32_m128i(a),
//                                            vreinterpretq_u32_m128i(a), 1));
//        break;
//    default:
//#if defined(__GNUC__) || defined(__clang__)
//        __builtin_unreachable();
//#endif
//        break;
//    }
//
//    switch (imm & 0x3) {
//    case 0:
//        _b = vreinterpretq_u8_u32(
//            vdupq_n_u32(vgetq_lane_u32(vreinterpretq_u32_m128i(b), 0)));
//        break;
//    case 1:
//        _b = vreinterpretq_u8_u32(
//            vdupq_n_u32(vgetq_lane_u32(vreinterpretq_u32_m128i(b), 1)));
//        break;
//    case 2:
//        _b = vreinterpretq_u8_u32(
//            vdupq_n_u32(vgetq_lane_u32(vreinterpretq_u32_m128i(b), 2)));
//        break;
//    case 3:
//        _b = vreinterpretq_u8_u32(
//            vdupq_n_u32(vgetq_lane_u32(vreinterpretq_u32_m128i(b), 3)));
//        break;
//    default:
//#if defined(__GNUC__) || defined(__clang__)
//        __builtin_unreachable();
//#endif
//        break;
//    }
//
//    v128 c04, c15, c26, c37;
//    v64 low_b = vget_low_u8(_b);
//    c04 = vabsq_s16(vreinterpretq_s16_u16(vsubl_u8(vget_low_u8(_a), low_b)));
//    _a = vextq_u8(_a, _a, 1);
//    c15 = vabsq_s16(vreinterpretq_s16_u16(vsubl_u8(vget_low_u8(_a), low_b)));
//    _a = vextq_u8(_a, _a, 1);
//    c26 = vabsq_s16(vreinterpretq_s16_u16(vsubl_u8(vget_low_u8(_a), low_b)));
//    _a = vextq_u8(_a, _a, 1);
//    c37 = vabsq_s16(vreinterpretq_s16_u16(vsubl_u8(vget_low_u8(_a), low_b)));
//#if defined(__aarch64__)
//    // |0|4|2|6|
//    c04 = vpaddq_s16(c04, c26);
//    // |1|5|3|7|
//    c15 = vpaddq_s16(c15, c37);
//
//    v128 trn1_c =
//        vtrn1q_s32(vreinterpretq_s32_s16(c04), vreinterpretq_s32_s16(c15));
//    v128 trn2_c =
//        vtrn2q_s32(vreinterpretq_s32_s16(c04), vreinterpretq_s32_s16(c15));
//    return vreinterpretq_m128i_s16(vpaddq_s16(vreinterpretq_s16_s32(trn1_c),
//                                              vreinterpretq_s16_s32(trn2_c)));
//#else
//    v64 c01, c23, c45, c67;
//    c01 = vpadd_s16(vget_low_s16(c04), vget_low_s16(c15));
//    c23 = vpadd_s16(vget_low_s16(c26), vget_low_s16(c37));
//    c45 = vpadd_s16(vget_high_s16(c04), vget_high_s16(c15));
//    c67 = vpadd_s16(vget_high_s16(c26), vget_high_s16(c37));
//
//    return vreinterpretq_m128i_s16(
//        vcombine_s16(vpadd_s16(c01, c23), vpadd_s16(c45, c67)));
//#endif
//}
//
//// Multiply the low signed 32-bit integers from each packed 64-bit element in
//// a and b, and store the signed 64-bit results in dst.
////
////   r0 :=  (long)(int)a0 * (long)(int)b0
////   r1 :=  (long)(int)a2 * (long)(int)b2
//static v128 mul_epi32(v128 a, v128 b)
//{
//    // vmull_s32 upcasts instead of masking, so we downcast.
//    v64 a_lo = vmovn_s64(a);
//    v64 b_lo = vmovn_s64(b);
//    return vreinterpretq_m128i_s64(vmull_s32(a_lo, b_lo));
//}
//
//// Multiplies the 4 signed or unsigned 32-bit integers from a by the 4 signed or
//// unsigned 32-bit integers from b.
//// https://msdn.microsoft.com/en-us/library/vstudio/bb531409(v=vs.100).aspx
//static v128 mullo_epi32(v128 a, v128 b)
//{
//    return vreinterpretq_m128i_s32(
//        vmulq_s32(a, b));
//}
//
//// Packs the 8 unsigned 32-bit integers from a and b into unsigned 16-bit
//// integers and saturates.
////
////   r0 := UnsignedSaturate(a0)
////   r1 := UnsignedSaturate(a1)
////   r2 := UnsignedSaturate(a2)
////   r3 := UnsignedSaturate(a3)
////   r4 := UnsignedSaturate(b0)
////   r5 := UnsignedSaturate(b1)
////   r6 := UnsignedSaturate(b2)
////   r7 := UnsignedSaturate(b3)
//static v128 packus_epi32(v128 a, v128 b)
//{
//    return vreinterpretq_m128i_u16(
//        vcombine_u16(vqmovun_s32(a),
//                     vqmovun_s32(b)));
//}
//
//// Round the packed double-precision (64-bit) floating-point elements in a using
//// the rounding parameter, and store the results as packed double-precision
//// floating-point elements in dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_round_pd
//static v128 round_pd(v128 a, int rounding)
//{
//#if defined(__aarch64__)
//    switch (rounding) {
//    case (_MM_FROUND_TO_NEAREST_INT | FROUND_NO_EXC):
//        return vreinterpretq_m128d_f64(vrndnq_f64(a));
//    case (_MM_FROUND_TO_NEG_INF | FROUND_NO_EXC):
//        return floor_pd(a);
//    case (_MM_FROUND_TO_POS_INF | FROUND_NO_EXC):
//        return ceil_pd(a);
//    case (_MM_FROUND_TO_ZERO | FROUND_NO_EXC):
//        return vreinterpretq_m128d_f64(vrndq_f64(a));
//    default:  //_MM_FROUND_CUR_DIRECTION
//        return vreinterpretq_m128d_f64(vrndiq_f64(a));
//    }
//#else
//    double *v_double = (double *) &a;
//
//    if (rounding == (_MM_FROUND_TO_NEAREST_INT | FROUND_NO_EXC) ||
//        (rounding == FROUND_CUR_DIRECTION &&
//         GET_ROUNDING_MODE() == ROUND_NEAREST)) {
//        double res[2], tmp;
//        for (int i = 0; i < 2; i++) {
//            tmp = (v_double[i] < 0) ? -v_double[i] : v_double[i];
//            double roundDown = floor(tmp);  // Round down value
//            double roundUp = ceil(tmp);     // Round up value
//            double diffDown = tmp - roundDown;
//            double diffUp = roundUp - tmp;
//            if (diffDown < diffUp) {
//                /* If it's closer to the round down value, then use it */
//                res[i] = roundDown;
//            } else if (diffDown > diffUp) {
//                /* If it's closer to the round up value, then use it */
//                res[i] = roundUp;
//            } else {
//                /* If it's equidistant between round up and round down value,
//                 * pick the one which is an even number */
//                double half = roundDown / 2;
//                if (half != floor(half)) {
//                    /* If the round down value is odd, return the round up value
//                     */
//                    res[i] = roundUp;
//                } else {
//                    /* If the round up value is odd, return the round down value
//                     */
//                    res[i] = roundDown;
//                }
//            }
//            res[i] = (v_double[i] < 0) ? -res[i] : res[i];
//        }
//        return set_pd(res[1], res[0]);
//    } else if (rounding == (_MM_FROUND_TO_NEG_INF | FROUND_NO_EXC) ||
//               (rounding == FROUND_CUR_DIRECTION &&
//                GET_ROUNDING_MODE() == ROUND_DOWN)) {
//        return floor_pd(a);
//    } else if (rounding == (_MM_FROUND_TO_POS_INF | FROUND_NO_EXC) ||
//               (rounding == FROUND_CUR_DIRECTION &&
//                GET_ROUNDING_MODE() == ROUND_UP)) {
//        return ceil_pd(a);
//    }
//    return set_pd(v_double[1] > 0 ? floor(v_double[1]) : ceil(v_double[1]),
//                      v_double[0] > 0 ? floor(v_double[0]) : ceil(v_double[0]));
//#endif
//}
//
//// Round the packed single-precision (32-bit) floating-point elements in a using
//// the rounding parameter, and store the results as packed single-precision
//// floating-point elements in dst.
//// software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_round_ps
//static v128 round_ps(v128 a, int rounding)
//{
//#if defined(__aarch64__) || defined(__ARM_FEATURE_DIRECTED_ROUNDING)
//    switch (rounding) {
//    case (_MM_FROUND_TO_NEAREST_INT | FROUND_NO_EXC):
//        return Arm.Neon.vrndnq_f32(a));
//    case (_MM_FROUND_TO_NEG_INF | FROUND_NO_EXC):
//        return floor_ps(a);
//    case (_MM_FROUND_TO_POS_INF | FROUND_NO_EXC):
//        return ceil_ps(a);
//    case (_MM_FROUND_TO_ZERO | FROUND_NO_EXC):
//        return Arm.Neon.vrndq_f32(a));
//    default:  //_MM_FROUND_CUR_DIRECTION
//        return Arm.Neon.vrndiq_f32(a));
//    }
//#else
//    float *v_float = (float *) &a;
//
//    if (rounding == (_MM_FROUND_TO_NEAREST_INT | FROUND_NO_EXC) ||
//        (rounding == FROUND_CUR_DIRECTION &&
//         GET_ROUNDING_MODE() == ROUND_NEAREST)) {
//        v128 signmask = vdupq_n_u32(0x80000000);
//        v128 half = vbslq_f32(signmask, a,
//                                     vdupq_n_f32(0.5f)); /* +/- 0.5 */
//        v128 r_normal = vcvtq_s32_f32(vaddq_f32(
//            a, half)); /* round to integer: [a + 0.5]*/
//        v128 r_trunc = vcvtq_s32_f32(
//            a); /* truncate to integer: [a] */
//        v128 plusone = vreinterpretq_s32_u32(vshrq_n_u32(
//            vreinterpretq_u32_s32(vnegq_s32(r_trunc)), 31)); /* 1 or 0 */
//        v128 r_even = vbicq_s32(vaddq_s32(r_trunc, plusone),
//                                     vdupq_n_s32(1)); /* ([a] + {0,1}) & ~1 */
//        v128 delta = vsubq_f32(
//            a,
//            vcvtq_f32_s32(r_trunc)); /* compute delta: delta = (a - [a]) */
//        v128 is_delta_half =
//            vceqq_f32(delta, half); /* delta == +/- 0.5 */
//        return Arm.Neon.
//            vcvtq_f32_s32(vbslq_s32(is_delta_half, r_even, r_normal)));
//    } else if (rounding == (_MM_FROUND_TO_NEG_INF | FROUND_NO_EXC) ||
//               (rounding == FROUND_CUR_DIRECTION &&
//                GET_ROUNDING_MODE() == ROUND_DOWN)) {
//        return floor_ps(a);
//    } else if (rounding == (_MM_FROUND_TO_POS_INF | FROUND_NO_EXC) ||
//               (rounding == FROUND_CUR_DIRECTION &&
//                GET_ROUNDING_MODE() == ROUND_UP)) {
//        return ceil_ps(a);
//    }
//    return set_ps(v_float[3] > 0 ? floorf(v_float[3]) : ceilf(v_float[3]),
//                      v_float[2] > 0 ? floorf(v_float[2]) : ceilf(v_float[2]),
//                      v_float[1] > 0 ? floorf(v_float[1]) : ceilf(v_float[1]),
//                      v_float[0] > 0 ? floorf(v_float[0]) : ceilf(v_float[0]));
//#endif
//}
//
//// Round the lower double-precision (64-bit) floating-point element in b using
//// the rounding parameter, store the result as a double-precision floating-point
//// element in the lower element of dst, and copy the upper element from a to the
//// upper element of dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_round_sd
//static v128 round_sd(v128 a, v128 b, int rounding)
//{
//    return move_sd(a, round_pd(b, rounding));
//}
//
//// Round the lower single-precision (32-bit) floating-point element in b using
//// the rounding parameter, store the result as a single-precision floating-point
//// element in the lower element of dst, and copy the upper 3 packed elements
//// from a to the upper elements of dst. Rounding is done according to the
//// rounding[3:0] parameter, which can be one of:
////     (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and
////     suppress exceptions
////     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and
////     suppress exceptions
////     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress
////     exceptions
////     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress
////     exceptions FROUND_CUR_DIRECTION // use MXCSR.RC; see
////     SET_ROUNDING_MODE
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_round_ss
//static v128 round_ss(v128 a, v128 b, int rounding)
//{
//    return move_ss(a, round_ps(b, rounding));
//}
//
//// Load 128-bits of integer data from memory into dst using a non-temporal
//// memory hint. mem_addr must be aligned on a 16-byte boundary or a
//// general-protection exception may be generated.
////
////   dst[127:0] := MEM[mem_addr+127:mem_addr]
////
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_stream_load_si128
//static v128 stream_load_si128(v128* p)
//{
//#if __has_builtin(__builtin_nontemporal_store)
//    return __builtin_nontemporal_load(p);
//#else
//    return vreinterpretq_m128i_s64(vld1q_s64((long *) p));
//#endif
//}
//
//// Compute the bitwise NOT of a and then AND with a 128-bit vector containing
//// all 1's, and return 1 if the result is zero, otherwise return 0.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_test_all_ones
//static int test_all_ones(v128 a)
//{
//    return (ulong) (vgetq_lane_s64(a, 0) & vgetq_lane_s64(a, 1)) ==
//           ~(ulong) 0;
//}
//
//// Compute the bitwise AND of 128 bits (representing integer data) in a and
//// mask, and return 1 if the result is zero, otherwise return 0.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_test_all_zeros
//static int test_all_zeros(v128 a, v128 mask)
//{
//    v128 a_and_mask =
//        vandq_s64(a, vreinterpretq_s64_m128i(mask));
//    return !(vgetq_lane_s64(a_and_mask, 0) | vgetq_lane_s64(a_and_mask, 1));
//}
//
//// Compute the bitwise AND of 128 bits (representing integer data) in a and
//// mask, and set ZF to 1 if the result is zero, otherwise set ZF to 0. Compute
//// the bitwise NOT of a and then AND with mask, and set CF to 1 if the result is
//// zero, otherwise set CF to 0. Return 1 if both the ZF and CF values are zero,
//// otherwise return 0.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=mm_test_mix_ones_zero
//static int test_mix_ones_zeros(v128 a, v128 mask)
//{
//    v128 zf =
//        vandq_u64(vreinterpretq_u64_m128i(mask), a);
//    v128 cf =
//        vbicq_u64(vreinterpretq_u64_m128i(mask), a);
//    v128 result = vandq_u64(zf, cf);
//    return !(vgetq_lane_u64(result, 0) | vgetq_lane_u64(result, 1));
//}
//
//// Compute the bitwise AND of 128 bits (representing integer data) in a and b,
//// and set ZF to 1 if the result is zero, otherwise set ZF to 0. Compute the
//// bitwise NOT of a and then AND with b, and set CF to 1 if the result is zero,
//// otherwise set CF to 0. Return the CF value.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_testc_si128
//static int testc_si128(v128 a, v128 b)
//{
//    v128 s64 =
//        vandq_s64(vreinterpretq_s64_s32(vmvnq_s32(a)),
//                  b);
//    return !(vgetq_lane_s64(s64, 0) | vgetq_lane_s64(s64, 1));
//}
//
//// Compute the bitwise AND of 128 bits (representing integer data) in a and b,
//// and set ZF to 1 if the result is zero, otherwise set ZF to 0. Compute the
//// bitwise NOT of a and then AND with b, and set CF to 1 if the result is zero,
//// otherwise set CF to 0. Return 1 if both the ZF and CF values are zero,
//// otherwise return 0.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_testnzc_si128
//#define testnzc_si128(a, b) test_mix_ones_zeros(a, b)
//
//// Compute the bitwise AND of 128 bits (representing integer data) in a and b,
//// and set ZF to 1 if the result is zero, otherwise set ZF to 0. Compute the
//// bitwise NOT of a and then AND with b, and set CF to 1 if the result is zero,
//// otherwise set CF to 0. Return the ZF value.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_testz_si128
//static int testz_si128(v128 a, v128 b)
//{
//    v128 s64 =
//        vandq_s64(a, b);
//    return !(vgetq_lane_s64(s64, 0) | vgetq_lane_s64(s64, 1));
//}
//
///* SSE4.2 */
//
//// Compares the 2 signed 64-bit integers in a and the 2 signed 64-bit integers
//// in b for greater than.
//static v128 cmpgt_epi64(v128 a, v128 b)
//{
//#if defined(__aarch64__)
//    return vreinterpretq_m128i_u64(
//        vcgtq_s64(a, b));
//#else
//    return vreinterpretq_m128i_s64(vshrq_n_s64(
//        vqsubq_s64(b, a),
//        63));
//#endif
//}
//
///* Others */
//
//// Perform a carry-less multiplication of two 64-bit integers, selected from a
//// and b according to imm8, and store the results in dst.
//// https://software.intel.com/sites/landingpage/IntrinsicsGuide/#text=_mm_clmulepi64_si128
//static v128 clmulepi64_si128(v128 _a, v128 _b, const int imm)
//{
//    v128 a = vreinterpretq_u64_m128i(_a);
//    v128 b = vreinterpretq_u64_m128i(_b);
//    switch (imm & 0x11) {
//    case 0x00:
//        return vreinterpretq_m128i_u64(
//            _sse2neon_vmull_p64(vget_low_u64(a), vget_low_u64(b)));
//    case 0x01:
//        return vreinterpretq_m128i_u64(
//            _sse2neon_vmull_p64(vget_high_u64(a), vget_low_u64(b)));
//    case 0x10:
//        return vreinterpretq_m128i_u64(
//            _sse2neon_vmull_p64(vget_low_u64(a), vget_high_u64(b)));
//    case 0x11:
//        return vreinterpretq_m128i_u64(
//            _sse2neon_vmull_p64(vget_high_u64(a), vget_high_u64(b)));
//    default:
//        abort();
//    }
//}
//}