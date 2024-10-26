//#define SSE2NEON_PRECISE_MINMAX
//#define SSE2NEON_PRECISE_DIV
//#define SSE2NEON_PRECISE_SQRT
//#define SSE2NEON_PRECISE_RSQRT
//#define SSE2NEON_PRECISE_RCP

using System;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.Arm.Neon;
using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
		internal static class imm8
		{
			internal static class X86
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 shuffle_ps(v128 a, v128 b, int imm8)
				{
					if (Sse2.IsSse2Supported)
					{
						switch (imm8)
						{
							case SHUFFLE_0000: return Sse.shuffle_ps(a, b, SHUFFLE_0000);
							case SHUFFLE_0001: return Sse.shuffle_ps(a, b, SHUFFLE_0001);
							case SHUFFLE_0002: return Sse.shuffle_ps(a, b, SHUFFLE_0002);
							case SHUFFLE_0003: return Sse.shuffle_ps(a, b, SHUFFLE_0003);
							case SHUFFLE_0010: return Sse.shuffle_ps(a, b, SHUFFLE_0010);
							case SHUFFLE_0011: return Sse.shuffle_ps(a, b, SHUFFLE_0011);
							case SHUFFLE_0012: return Sse.shuffle_ps(a, b, SHUFFLE_0012);
							case SHUFFLE_0013: return Sse.shuffle_ps(a, b, SHUFFLE_0013);
							case SHUFFLE_0020: return Sse.shuffle_ps(a, b, SHUFFLE_0020);
							case SHUFFLE_0021: return Sse.shuffle_ps(a, b, SHUFFLE_0021);
							case SHUFFLE_0022: return Sse.shuffle_ps(a, b, SHUFFLE_0022);
							case SHUFFLE_0023: return Sse.shuffle_ps(a, b, SHUFFLE_0023);
							case SHUFFLE_0030: return Sse.shuffle_ps(a, b, SHUFFLE_0030);
							case SHUFFLE_0031: return Sse.shuffle_ps(a, b, SHUFFLE_0031);
							case SHUFFLE_0032: return Sse.shuffle_ps(a, b, SHUFFLE_0032);
							case SHUFFLE_0033: return Sse.shuffle_ps(a, b, SHUFFLE_0033);
							case SHUFFLE_0100: return Sse.shuffle_ps(a, b, SHUFFLE_0100);
							case SHUFFLE_0101: return Sse.shuffle_ps(a, b, SHUFFLE_0101);
							case SHUFFLE_0102: return Sse.shuffle_ps(a, b, SHUFFLE_0102);
							case SHUFFLE_0103: return Sse.shuffle_ps(a, b, SHUFFLE_0103);
							case SHUFFLE_0110: return Sse.shuffle_ps(a, b, SHUFFLE_0110);
							case SHUFFLE_0111: return Sse.shuffle_ps(a, b, SHUFFLE_0111);
							case SHUFFLE_0112: return Sse.shuffle_ps(a, b, SHUFFLE_0112);
							case SHUFFLE_0113: return Sse.shuffle_ps(a, b, SHUFFLE_0113);
							case SHUFFLE_0120: return Sse.shuffle_ps(a, b, SHUFFLE_0120);
							case SHUFFLE_0121: return Sse.shuffle_ps(a, b, SHUFFLE_0121);
							case SHUFFLE_0122: return Sse.shuffle_ps(a, b, SHUFFLE_0122);
							case SHUFFLE_0123: return Sse.shuffle_ps(a, b, SHUFFLE_0123);
							case SHUFFLE_0130: return Sse.shuffle_ps(a, b, SHUFFLE_0130);
							case SHUFFLE_0131: return Sse.shuffle_ps(a, b, SHUFFLE_0131);
							case SHUFFLE_0132: return Sse.shuffle_ps(a, b, SHUFFLE_0132);
							case SHUFFLE_0133: return Sse.shuffle_ps(a, b, SHUFFLE_0133);
							case SHUFFLE_0200: return Sse.shuffle_ps(a, b, SHUFFLE_0200);
							case SHUFFLE_0201: return Sse.shuffle_ps(a, b, SHUFFLE_0201);
							case SHUFFLE_0202: return Sse.shuffle_ps(a, b, SHUFFLE_0202);
							case SHUFFLE_0203: return Sse.shuffle_ps(a, b, SHUFFLE_0203);
							case SHUFFLE_0210: return Sse.shuffle_ps(a, b, SHUFFLE_0210);
							case SHUFFLE_0211: return Sse.shuffle_ps(a, b, SHUFFLE_0211);
							case SHUFFLE_0212: return Sse.shuffle_ps(a, b, SHUFFLE_0212);
							case SHUFFLE_0213: return Sse.shuffle_ps(a, b, SHUFFLE_0213);
							case SHUFFLE_0220: return Sse.shuffle_ps(a, b, SHUFFLE_0220);
							case SHUFFLE_0221: return Sse.shuffle_ps(a, b, SHUFFLE_0221);
							case SHUFFLE_0222: return Sse.shuffle_ps(a, b, SHUFFLE_0222);
							case SHUFFLE_0223: return Sse.shuffle_ps(a, b, SHUFFLE_0223);
							case SHUFFLE_0230: return Sse.shuffle_ps(a, b, SHUFFLE_0230);
							case SHUFFLE_0231: return Sse.shuffle_ps(a, b, SHUFFLE_0231);
							case SHUFFLE_0232: return Sse.shuffle_ps(a, b, SHUFFLE_0232);
							case SHUFFLE_0233: return Sse.shuffle_ps(a, b, SHUFFLE_0233);
							case SHUFFLE_0300: return Sse.shuffle_ps(a, b, SHUFFLE_0300);
							case SHUFFLE_0301: return Sse.shuffle_ps(a, b, SHUFFLE_0301);
							case SHUFFLE_0302: return Sse.shuffle_ps(a, b, SHUFFLE_0302);
							case SHUFFLE_0303: return Sse.shuffle_ps(a, b, SHUFFLE_0303);
							case SHUFFLE_0310: return Sse.shuffle_ps(a, b, SHUFFLE_0310);
							case SHUFFLE_0311: return Sse.shuffle_ps(a, b, SHUFFLE_0311);
							case SHUFFLE_0312: return Sse.shuffle_ps(a, b, SHUFFLE_0312);
							case SHUFFLE_0313: return Sse.shuffle_ps(a, b, SHUFFLE_0313);
							case SHUFFLE_0320: return Sse.shuffle_ps(a, b, SHUFFLE_0320);
							case SHUFFLE_0321: return Sse.shuffle_ps(a, b, SHUFFLE_0321);
							case SHUFFLE_0322: return Sse.shuffle_ps(a, b, SHUFFLE_0322);
							case SHUFFLE_0323: return Sse.shuffle_ps(a, b, SHUFFLE_0323);
							case SHUFFLE_0330: return Sse.shuffle_ps(a, b, SHUFFLE_0330);
							case SHUFFLE_0331: return Sse.shuffle_ps(a, b, SHUFFLE_0331);
							case SHUFFLE_0332: return Sse.shuffle_ps(a, b, SHUFFLE_0332);
							case SHUFFLE_0333: return Sse.shuffle_ps(a, b, SHUFFLE_0333);
							case SHUFFLE_1000: return Sse.shuffle_ps(a, b, SHUFFLE_1000);
							case SHUFFLE_1001: return Sse.shuffle_ps(a, b, SHUFFLE_1001);
							case SHUFFLE_1002: return Sse.shuffle_ps(a, b, SHUFFLE_1002);
							case SHUFFLE_1003: return Sse.shuffle_ps(a, b, SHUFFLE_1003);
							case SHUFFLE_1010: return Sse.shuffle_ps(a, b, SHUFFLE_1010);
							case SHUFFLE_1011: return Sse.shuffle_ps(a, b, SHUFFLE_1011);
							case SHUFFLE_1012: return Sse.shuffle_ps(a, b, SHUFFLE_1012);
							case SHUFFLE_1013: return Sse.shuffle_ps(a, b, SHUFFLE_1013);
							case SHUFFLE_1020: return Sse.shuffle_ps(a, b, SHUFFLE_1020);
							case SHUFFLE_1021: return Sse.shuffle_ps(a, b, SHUFFLE_1021);
							case SHUFFLE_1022: return Sse.shuffle_ps(a, b, SHUFFLE_1022);
							case SHUFFLE_1023: return Sse.shuffle_ps(a, b, SHUFFLE_1023);
							case SHUFFLE_1030: return Sse.shuffle_ps(a, b, SHUFFLE_1030);
							case SHUFFLE_1031: return Sse.shuffle_ps(a, b, SHUFFLE_1031);
							case SHUFFLE_1032: return Sse.shuffle_ps(a, b, SHUFFLE_1032);
							case SHUFFLE_1033: return Sse.shuffle_ps(a, b, SHUFFLE_1033);
							case SHUFFLE_1100: return Sse.shuffle_ps(a, b, SHUFFLE_1100);
							case SHUFFLE_1101: return Sse.shuffle_ps(a, b, SHUFFLE_1101);
							case SHUFFLE_1102: return Sse.shuffle_ps(a, b, SHUFFLE_1102);
							case SHUFFLE_1103: return Sse.shuffle_ps(a, b, SHUFFLE_1103);
							case SHUFFLE_1110: return Sse.shuffle_ps(a, b, SHUFFLE_1110);
							case SHUFFLE_1111: return Sse.shuffle_ps(a, b, SHUFFLE_1111);
							case SHUFFLE_1112: return Sse.shuffle_ps(a, b, SHUFFLE_1112);
							case SHUFFLE_1113: return Sse.shuffle_ps(a, b, SHUFFLE_1113);
							case SHUFFLE_1120: return Sse.shuffle_ps(a, b, SHUFFLE_1120);
							case SHUFFLE_1121: return Sse.shuffle_ps(a, b, SHUFFLE_1121);
							case SHUFFLE_1122: return Sse.shuffle_ps(a, b, SHUFFLE_1122);
							case SHUFFLE_1123: return Sse.shuffle_ps(a, b, SHUFFLE_1123);
							case SHUFFLE_1130: return Sse.shuffle_ps(a, b, SHUFFLE_1130);
							case SHUFFLE_1131: return Sse.shuffle_ps(a, b, SHUFFLE_1131);
							case SHUFFLE_1132: return Sse.shuffle_ps(a, b, SHUFFLE_1132);
							case SHUFFLE_1133: return Sse.shuffle_ps(a, b, SHUFFLE_1133);
							case SHUFFLE_1200: return Sse.shuffle_ps(a, b, SHUFFLE_1200);
							case SHUFFLE_1201: return Sse.shuffle_ps(a, b, SHUFFLE_1201);
							case SHUFFLE_1202: return Sse.shuffle_ps(a, b, SHUFFLE_1202);
							case SHUFFLE_1203: return Sse.shuffle_ps(a, b, SHUFFLE_1203);
							case SHUFFLE_1210: return Sse.shuffle_ps(a, b, SHUFFLE_1210);
							case SHUFFLE_1211: return Sse.shuffle_ps(a, b, SHUFFLE_1211);
							case SHUFFLE_1212: return Sse.shuffle_ps(a, b, SHUFFLE_1212);
							case SHUFFLE_1213: return Sse.shuffle_ps(a, b, SHUFFLE_1213);
							case SHUFFLE_1220: return Sse.shuffle_ps(a, b, SHUFFLE_1220);
							case SHUFFLE_1221: return Sse.shuffle_ps(a, b, SHUFFLE_1221);
							case SHUFFLE_1222: return Sse.shuffle_ps(a, b, SHUFFLE_1222);
							case SHUFFLE_1223: return Sse.shuffle_ps(a, b, SHUFFLE_1223);
							case SHUFFLE_1230: return Sse.shuffle_ps(a, b, SHUFFLE_1230);
							case SHUFFLE_1231: return Sse.shuffle_ps(a, b, SHUFFLE_1231);
							case SHUFFLE_1232: return Sse.shuffle_ps(a, b, SHUFFLE_1232);
							case SHUFFLE_1233: return Sse.shuffle_ps(a, b, SHUFFLE_1233);
							case SHUFFLE_1300: return Sse.shuffle_ps(a, b, SHUFFLE_1300);
							case SHUFFLE_1301: return Sse.shuffle_ps(a, b, SHUFFLE_1301);
							case SHUFFLE_1302: return Sse.shuffle_ps(a, b, SHUFFLE_1302);
							case SHUFFLE_1303: return Sse.shuffle_ps(a, b, SHUFFLE_1303);
							case SHUFFLE_1310: return Sse.shuffle_ps(a, b, SHUFFLE_1310);
							case SHUFFLE_1311: return Sse.shuffle_ps(a, b, SHUFFLE_1311);
							case SHUFFLE_1312: return Sse.shuffle_ps(a, b, SHUFFLE_1312);
							case SHUFFLE_1313: return Sse.shuffle_ps(a, b, SHUFFLE_1313);
							case SHUFFLE_1320: return Sse.shuffle_ps(a, b, SHUFFLE_1320);
							case SHUFFLE_1321: return Sse.shuffle_ps(a, b, SHUFFLE_1321);
							case SHUFFLE_1322: return Sse.shuffle_ps(a, b, SHUFFLE_1322);
							case SHUFFLE_1323: return Sse.shuffle_ps(a, b, SHUFFLE_1323);
							case SHUFFLE_1330: return Sse.shuffle_ps(a, b, SHUFFLE_1330);
							case SHUFFLE_1331: return Sse.shuffle_ps(a, b, SHUFFLE_1331);
							case SHUFFLE_1332: return Sse.shuffle_ps(a, b, SHUFFLE_1332);
							case SHUFFLE_1333: return Sse.shuffle_ps(a, b, SHUFFLE_1333);
							case SHUFFLE_2000: return Sse.shuffle_ps(a, b, SHUFFLE_2000);
							case SHUFFLE_2001: return Sse.shuffle_ps(a, b, SHUFFLE_2001);
							case SHUFFLE_2002: return Sse.shuffle_ps(a, b, SHUFFLE_2002);
							case SHUFFLE_2003: return Sse.shuffle_ps(a, b, SHUFFLE_2003);
							case SHUFFLE_2010: return Sse.shuffle_ps(a, b, SHUFFLE_2010);
							case SHUFFLE_2011: return Sse.shuffle_ps(a, b, SHUFFLE_2011);
							case SHUFFLE_2012: return Sse.shuffle_ps(a, b, SHUFFLE_2012);
							case SHUFFLE_2013: return Sse.shuffle_ps(a, b, SHUFFLE_2013);
							case SHUFFLE_2020: return Sse.shuffle_ps(a, b, SHUFFLE_2020);
							case SHUFFLE_2021: return Sse.shuffle_ps(a, b, SHUFFLE_2021);
							case SHUFFLE_2022: return Sse.shuffle_ps(a, b, SHUFFLE_2022);
							case SHUFFLE_2023: return Sse.shuffle_ps(a, b, SHUFFLE_2023);
							case SHUFFLE_2030: return Sse.shuffle_ps(a, b, SHUFFLE_2030);
							case SHUFFLE_2031: return Sse.shuffle_ps(a, b, SHUFFLE_2031);
							case SHUFFLE_2032: return Sse.shuffle_ps(a, b, SHUFFLE_2032);
							case SHUFFLE_2033: return Sse.shuffle_ps(a, b, SHUFFLE_2033);
							case SHUFFLE_2100: return Sse.shuffle_ps(a, b, SHUFFLE_2100);
							case SHUFFLE_2101: return Sse.shuffle_ps(a, b, SHUFFLE_2101);
							case SHUFFLE_2102: return Sse.shuffle_ps(a, b, SHUFFLE_2102);
							case SHUFFLE_2103: return Sse.shuffle_ps(a, b, SHUFFLE_2103);
							case SHUFFLE_2110: return Sse.shuffle_ps(a, b, SHUFFLE_2110);
							case SHUFFLE_2111: return Sse.shuffle_ps(a, b, SHUFFLE_2111);
							case SHUFFLE_2112: return Sse.shuffle_ps(a, b, SHUFFLE_2112);
							case SHUFFLE_2113: return Sse.shuffle_ps(a, b, SHUFFLE_2113);
							case SHUFFLE_2120: return Sse.shuffle_ps(a, b, SHUFFLE_2120);
							case SHUFFLE_2121: return Sse.shuffle_ps(a, b, SHUFFLE_2121);
							case SHUFFLE_2122: return Sse.shuffle_ps(a, b, SHUFFLE_2122);
							case SHUFFLE_2123: return Sse.shuffle_ps(a, b, SHUFFLE_2123);
							case SHUFFLE_2130: return Sse.shuffle_ps(a, b, SHUFFLE_2130);
							case SHUFFLE_2131: return Sse.shuffle_ps(a, b, SHUFFLE_2131);
							case SHUFFLE_2132: return Sse.shuffle_ps(a, b, SHUFFLE_2132);
							case SHUFFLE_2133: return Sse.shuffle_ps(a, b, SHUFFLE_2133);
							case SHUFFLE_2200: return Sse.shuffle_ps(a, b, SHUFFLE_2200);
							case SHUFFLE_2201: return Sse.shuffle_ps(a, b, SHUFFLE_2201);
							case SHUFFLE_2202: return Sse.shuffle_ps(a, b, SHUFFLE_2202);
							case SHUFFLE_2203: return Sse.shuffle_ps(a, b, SHUFFLE_2203);
							case SHUFFLE_2210: return Sse.shuffle_ps(a, b, SHUFFLE_2210);
							case SHUFFLE_2211: return Sse.shuffle_ps(a, b, SHUFFLE_2211);
							case SHUFFLE_2212: return Sse.shuffle_ps(a, b, SHUFFLE_2212);
							case SHUFFLE_2213: return Sse.shuffle_ps(a, b, SHUFFLE_2213);
							case SHUFFLE_2220: return Sse.shuffle_ps(a, b, SHUFFLE_2220);
							case SHUFFLE_2221: return Sse.shuffle_ps(a, b, SHUFFLE_2221);
							case SHUFFLE_2222: return Sse.shuffle_ps(a, b, SHUFFLE_2222);
							case SHUFFLE_2223: return Sse.shuffle_ps(a, b, SHUFFLE_2223);
							case SHUFFLE_2230: return Sse.shuffle_ps(a, b, SHUFFLE_2230);
							case SHUFFLE_2231: return Sse.shuffle_ps(a, b, SHUFFLE_2231);
							case SHUFFLE_2232: return Sse.shuffle_ps(a, b, SHUFFLE_2232);
							case SHUFFLE_2233: return Sse.shuffle_ps(a, b, SHUFFLE_2233);
							case SHUFFLE_2300: return Sse.shuffle_ps(a, b, SHUFFLE_2300);
							case SHUFFLE_2301: return Sse.shuffle_ps(a, b, SHUFFLE_2301);
							case SHUFFLE_2302: return Sse.shuffle_ps(a, b, SHUFFLE_2302);
							case SHUFFLE_2303: return Sse.shuffle_ps(a, b, SHUFFLE_2303);
							case SHUFFLE_2310: return Sse.shuffle_ps(a, b, SHUFFLE_2310);
							case SHUFFLE_2311: return Sse.shuffle_ps(a, b, SHUFFLE_2311);
							case SHUFFLE_2312: return Sse.shuffle_ps(a, b, SHUFFLE_2312);
							case SHUFFLE_2313: return Sse.shuffle_ps(a, b, SHUFFLE_2313);
							case SHUFFLE_2320: return Sse.shuffle_ps(a, b, SHUFFLE_2320);
							case SHUFFLE_2321: return Sse.shuffle_ps(a, b, SHUFFLE_2321);
							case SHUFFLE_2322: return Sse.shuffle_ps(a, b, SHUFFLE_2322);
							case SHUFFLE_2323: return Sse.shuffle_ps(a, b, SHUFFLE_2323);
							case SHUFFLE_2330: return Sse.shuffle_ps(a, b, SHUFFLE_2330);
							case SHUFFLE_2331: return Sse.shuffle_ps(a, b, SHUFFLE_2331);
							case SHUFFLE_2332: return Sse.shuffle_ps(a, b, SHUFFLE_2332);
							case SHUFFLE_2333: return Sse.shuffle_ps(a, b, SHUFFLE_2333);
							case SHUFFLE_3000: return Sse.shuffle_ps(a, b, SHUFFLE_3000);
							case SHUFFLE_3001: return Sse.shuffle_ps(a, b, SHUFFLE_3001);
							case SHUFFLE_3002: return Sse.shuffle_ps(a, b, SHUFFLE_3002);
							case SHUFFLE_3003: return Sse.shuffle_ps(a, b, SHUFFLE_3003);
							case SHUFFLE_3010: return Sse.shuffle_ps(a, b, SHUFFLE_3010);
							case SHUFFLE_3011: return Sse.shuffle_ps(a, b, SHUFFLE_3011);
							case SHUFFLE_3012: return Sse.shuffle_ps(a, b, SHUFFLE_3012);
							case SHUFFLE_3013: return Sse.shuffle_ps(a, b, SHUFFLE_3013);
							case SHUFFLE_3020: return Sse.shuffle_ps(a, b, SHUFFLE_3020);
							case SHUFFLE_3021: return Sse.shuffle_ps(a, b, SHUFFLE_3021);
							case SHUFFLE_3022: return Sse.shuffle_ps(a, b, SHUFFLE_3022);
							case SHUFFLE_3023: return Sse.shuffle_ps(a, b, SHUFFLE_3023);
							case SHUFFLE_3030: return Sse.shuffle_ps(a, b, SHUFFLE_3030);
							case SHUFFLE_3031: return Sse.shuffle_ps(a, b, SHUFFLE_3031);
							case SHUFFLE_3032: return Sse.shuffle_ps(a, b, SHUFFLE_3032);
							case SHUFFLE_3033: return Sse.shuffle_ps(a, b, SHUFFLE_3033);
							case SHUFFLE_3100: return Sse.shuffle_ps(a, b, SHUFFLE_3100);
							case SHUFFLE_3101: return Sse.shuffle_ps(a, b, SHUFFLE_3101);
							case SHUFFLE_3102: return Sse.shuffle_ps(a, b, SHUFFLE_3102);
							case SHUFFLE_3103: return Sse.shuffle_ps(a, b, SHUFFLE_3103);
							case SHUFFLE_3110: return Sse.shuffle_ps(a, b, SHUFFLE_3110);
							case SHUFFLE_3111: return Sse.shuffle_ps(a, b, SHUFFLE_3111);
							case SHUFFLE_3112: return Sse.shuffle_ps(a, b, SHUFFLE_3112);
							case SHUFFLE_3113: return Sse.shuffle_ps(a, b, SHUFFLE_3113);
							case SHUFFLE_3120: return Sse.shuffle_ps(a, b, SHUFFLE_3120);
							case SHUFFLE_3121: return Sse.shuffle_ps(a, b, SHUFFLE_3121);
							case SHUFFLE_3122: return Sse.shuffle_ps(a, b, SHUFFLE_3122);
							case SHUFFLE_3123: return Sse.shuffle_ps(a, b, SHUFFLE_3123);
							case SHUFFLE_3130: return Sse.shuffle_ps(a, b, SHUFFLE_3130);
							case SHUFFLE_3131: return Sse.shuffle_ps(a, b, SHUFFLE_3131);
							case SHUFFLE_3132: return Sse.shuffle_ps(a, b, SHUFFLE_3132);
							case SHUFFLE_3133: return Sse.shuffle_ps(a, b, SHUFFLE_3133);
							case SHUFFLE_3200: return Sse.shuffle_ps(a, b, SHUFFLE_3200);
							case SHUFFLE_3201: return Sse.shuffle_ps(a, b, SHUFFLE_3201);
							case SHUFFLE_3202: return Sse.shuffle_ps(a, b, SHUFFLE_3202);
							case SHUFFLE_3203: return Sse.shuffle_ps(a, b, SHUFFLE_3203);
							case SHUFFLE_3210: return Sse.shuffle_ps(a, b, SHUFFLE_3210);
							case SHUFFLE_3211: return Sse.shuffle_ps(a, b, SHUFFLE_3211);
							case SHUFFLE_3212: return Sse.shuffle_ps(a, b, SHUFFLE_3212);
							case SHUFFLE_3213: return Sse.shuffle_ps(a, b, SHUFFLE_3213);
							case SHUFFLE_3220: return Sse.shuffle_ps(a, b, SHUFFLE_3220);
							case SHUFFLE_3221: return Sse.shuffle_ps(a, b, SHUFFLE_3221);
							case SHUFFLE_3222: return Sse.shuffle_ps(a, b, SHUFFLE_3222);
							case SHUFFLE_3223: return Sse.shuffle_ps(a, b, SHUFFLE_3223);
							case SHUFFLE_3230: return Sse.shuffle_ps(a, b, SHUFFLE_3230);
							case SHUFFLE_3231: return Sse.shuffle_ps(a, b, SHUFFLE_3231);
							case SHUFFLE_3232: return Sse.shuffle_ps(a, b, SHUFFLE_3232);
							case SHUFFLE_3233: return Sse.shuffle_ps(a, b, SHUFFLE_3233);
							case SHUFFLE_3300: return Sse.shuffle_ps(a, b, SHUFFLE_3300);
							case SHUFFLE_3301: return Sse.shuffle_ps(a, b, SHUFFLE_3301);
							case SHUFFLE_3302: return Sse.shuffle_ps(a, b, SHUFFLE_3302);
							case SHUFFLE_3303: return Sse.shuffle_ps(a, b, SHUFFLE_3303);
							case SHUFFLE_3310: return Sse.shuffle_ps(a, b, SHUFFLE_3310);
							case SHUFFLE_3311: return Sse.shuffle_ps(a, b, SHUFFLE_3311);
							case SHUFFLE_3312: return Sse.shuffle_ps(a, b, SHUFFLE_3312);
							case SHUFFLE_3313: return Sse.shuffle_ps(a, b, SHUFFLE_3313);
							case SHUFFLE_3320: return Sse.shuffle_ps(a, b, SHUFFLE_3320);
							case SHUFFLE_3321: return Sse.shuffle_ps(a, b, SHUFFLE_3321);
							case SHUFFLE_3322: return Sse.shuffle_ps(a, b, SHUFFLE_3322);
							case SHUFFLE_3323: return Sse.shuffle_ps(a, b, SHUFFLE_3323);
							case SHUFFLE_3330: return Sse.shuffle_ps(a, b, SHUFFLE_3330);
							case SHUFFLE_3331: return Sse.shuffle_ps(a, b, SHUFFLE_3331);
							case SHUFFLE_3332: return Sse.shuffle_ps(a, b, SHUFFLE_3332);
							case SHUFFLE_3333: return Sse.shuffle_ps(a, b, SHUFFLE_3333);
							default: return a;
						}
					}
					else throw new IllegalInstructionException();
				}
				
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 shuffle_epi32(v128 a, int imm8)
				{
					if (Sse2.IsSse2Supported)
					{
						switch (imm8)
						{
							case SHUFFLE_0000: return Sse2.shuffle_epi32(a, SHUFFLE_0000);
							case SHUFFLE_0001: return Sse2.shuffle_epi32(a, SHUFFLE_0001);
							case SHUFFLE_0002: return Sse2.shuffle_epi32(a, SHUFFLE_0002);
							case SHUFFLE_0003: return Sse2.shuffle_epi32(a, SHUFFLE_0003);
							case SHUFFLE_0010: return Sse2.shuffle_epi32(a, SHUFFLE_0010);
							case SHUFFLE_0011: return Sse2.shuffle_epi32(a, SHUFFLE_0011);
							case SHUFFLE_0012: return Sse2.shuffle_epi32(a, SHUFFLE_0012);
							case SHUFFLE_0013: return Sse2.shuffle_epi32(a, SHUFFLE_0013);
							case SHUFFLE_0020: return Sse2.shuffle_epi32(a, SHUFFLE_0020);
							case SHUFFLE_0021: return Sse2.shuffle_epi32(a, SHUFFLE_0021);
							case SHUFFLE_0022: return Sse2.shuffle_epi32(a, SHUFFLE_0022);
							case SHUFFLE_0023: return Sse2.shuffle_epi32(a, SHUFFLE_0023);
							case SHUFFLE_0030: return Sse2.shuffle_epi32(a, SHUFFLE_0030);
							case SHUFFLE_0031: return Sse2.shuffle_epi32(a, SHUFFLE_0031);
							case SHUFFLE_0032: return Sse2.shuffle_epi32(a, SHUFFLE_0032);
							case SHUFFLE_0033: return Sse2.shuffle_epi32(a, SHUFFLE_0033);
							case SHUFFLE_0100: return Sse2.shuffle_epi32(a, SHUFFLE_0100);
							case SHUFFLE_0101: return Sse2.shuffle_epi32(a, SHUFFLE_0101);
							case SHUFFLE_0102: return Sse2.shuffle_epi32(a, SHUFFLE_0102);
							case SHUFFLE_0103: return Sse2.shuffle_epi32(a, SHUFFLE_0103);
							case SHUFFLE_0110: return Sse2.shuffle_epi32(a, SHUFFLE_0110);
							case SHUFFLE_0111: return Sse2.shuffle_epi32(a, SHUFFLE_0111);
							case SHUFFLE_0112: return Sse2.shuffle_epi32(a, SHUFFLE_0112);
							case SHUFFLE_0113: return Sse2.shuffle_epi32(a, SHUFFLE_0113);
							case SHUFFLE_0120: return Sse2.shuffle_epi32(a, SHUFFLE_0120);
							case SHUFFLE_0121: return Sse2.shuffle_epi32(a, SHUFFLE_0121);
							case SHUFFLE_0122: return Sse2.shuffle_epi32(a, SHUFFLE_0122);
							case SHUFFLE_0123: return Sse2.shuffle_epi32(a, SHUFFLE_0123);
							case SHUFFLE_0130: return Sse2.shuffle_epi32(a, SHUFFLE_0130);
							case SHUFFLE_0131: return Sse2.shuffle_epi32(a, SHUFFLE_0131);
							case SHUFFLE_0132: return Sse2.shuffle_epi32(a, SHUFFLE_0132);
							case SHUFFLE_0133: return Sse2.shuffle_epi32(a, SHUFFLE_0133);
							case SHUFFLE_0200: return Sse2.shuffle_epi32(a, SHUFFLE_0200);
							case SHUFFLE_0201: return Sse2.shuffle_epi32(a, SHUFFLE_0201);
							case SHUFFLE_0202: return Sse2.shuffle_epi32(a, SHUFFLE_0202);
							case SHUFFLE_0203: return Sse2.shuffle_epi32(a, SHUFFLE_0203);
							case SHUFFLE_0210: return Sse2.shuffle_epi32(a, SHUFFLE_0210);
							case SHUFFLE_0211: return Sse2.shuffle_epi32(a, SHUFFLE_0211);
							case SHUFFLE_0212: return Sse2.shuffle_epi32(a, SHUFFLE_0212);
							case SHUFFLE_0213: return Sse2.shuffle_epi32(a, SHUFFLE_0213);
							case SHUFFLE_0220: return Sse2.shuffle_epi32(a, SHUFFLE_0220);
							case SHUFFLE_0221: return Sse2.shuffle_epi32(a, SHUFFLE_0221);
							case SHUFFLE_0222: return Sse2.shuffle_epi32(a, SHUFFLE_0222);
							case SHUFFLE_0223: return Sse2.shuffle_epi32(a, SHUFFLE_0223);
							case SHUFFLE_0230: return Sse2.shuffle_epi32(a, SHUFFLE_0230);
							case SHUFFLE_0231: return Sse2.shuffle_epi32(a, SHUFFLE_0231);
							case SHUFFLE_0232: return Sse2.shuffle_epi32(a, SHUFFLE_0232);
							case SHUFFLE_0233: return Sse2.shuffle_epi32(a, SHUFFLE_0233);
							case SHUFFLE_0300: return Sse2.shuffle_epi32(a, SHUFFLE_0300);
							case SHUFFLE_0301: return Sse2.shuffle_epi32(a, SHUFFLE_0301);
							case SHUFFLE_0302: return Sse2.shuffle_epi32(a, SHUFFLE_0302);
							case SHUFFLE_0303: return Sse2.shuffle_epi32(a, SHUFFLE_0303);
							case SHUFFLE_0310: return Sse2.shuffle_epi32(a, SHUFFLE_0310);
							case SHUFFLE_0311: return Sse2.shuffle_epi32(a, SHUFFLE_0311);
							case SHUFFLE_0312: return Sse2.shuffle_epi32(a, SHUFFLE_0312);
							case SHUFFLE_0313: return Sse2.shuffle_epi32(a, SHUFFLE_0313);
							case SHUFFLE_0320: return Sse2.shuffle_epi32(a, SHUFFLE_0320);
							case SHUFFLE_0321: return Sse2.shuffle_epi32(a, SHUFFLE_0321);
							case SHUFFLE_0322: return Sse2.shuffle_epi32(a, SHUFFLE_0322);
							case SHUFFLE_0323: return Sse2.shuffle_epi32(a, SHUFFLE_0323);
							case SHUFFLE_0330: return Sse2.shuffle_epi32(a, SHUFFLE_0330);
							case SHUFFLE_0331: return Sse2.shuffle_epi32(a, SHUFFLE_0331);
							case SHUFFLE_0332: return Sse2.shuffle_epi32(a, SHUFFLE_0332);
							case SHUFFLE_0333: return Sse2.shuffle_epi32(a, SHUFFLE_0333);
							case SHUFFLE_1000: return Sse2.shuffle_epi32(a, SHUFFLE_1000);
							case SHUFFLE_1001: return Sse2.shuffle_epi32(a, SHUFFLE_1001);
							case SHUFFLE_1002: return Sse2.shuffle_epi32(a, SHUFFLE_1002);
							case SHUFFLE_1003: return Sse2.shuffle_epi32(a, SHUFFLE_1003);
							case SHUFFLE_1010: return Sse2.shuffle_epi32(a, SHUFFLE_1010);
							case SHUFFLE_1011: return Sse2.shuffle_epi32(a, SHUFFLE_1011);
							case SHUFFLE_1012: return Sse2.shuffle_epi32(a, SHUFFLE_1012);
							case SHUFFLE_1013: return Sse2.shuffle_epi32(a, SHUFFLE_1013);
							case SHUFFLE_1020: return Sse2.shuffle_epi32(a, SHUFFLE_1020);
							case SHUFFLE_1021: return Sse2.shuffle_epi32(a, SHUFFLE_1021);
							case SHUFFLE_1022: return Sse2.shuffle_epi32(a, SHUFFLE_1022);
							case SHUFFLE_1023: return Sse2.shuffle_epi32(a, SHUFFLE_1023);
							case SHUFFLE_1030: return Sse2.shuffle_epi32(a, SHUFFLE_1030);
							case SHUFFLE_1031: return Sse2.shuffle_epi32(a, SHUFFLE_1031);
							case SHUFFLE_1032: return Sse2.shuffle_epi32(a, SHUFFLE_1032);
							case SHUFFLE_1033: return Sse2.shuffle_epi32(a, SHUFFLE_1033);
							case SHUFFLE_1100: return Sse2.shuffle_epi32(a, SHUFFLE_1100);
							case SHUFFLE_1101: return Sse2.shuffle_epi32(a, SHUFFLE_1101);
							case SHUFFLE_1102: return Sse2.shuffle_epi32(a, SHUFFLE_1102);
							case SHUFFLE_1103: return Sse2.shuffle_epi32(a, SHUFFLE_1103);
							case SHUFFLE_1110: return Sse2.shuffle_epi32(a, SHUFFLE_1110);
							case SHUFFLE_1111: return Sse2.shuffle_epi32(a, SHUFFLE_1111);
							case SHUFFLE_1112: return Sse2.shuffle_epi32(a, SHUFFLE_1112);
							case SHUFFLE_1113: return Sse2.shuffle_epi32(a, SHUFFLE_1113);
							case SHUFFLE_1120: return Sse2.shuffle_epi32(a, SHUFFLE_1120);
							case SHUFFLE_1121: return Sse2.shuffle_epi32(a, SHUFFLE_1121);
							case SHUFFLE_1122: return Sse2.shuffle_epi32(a, SHUFFLE_1122);
							case SHUFFLE_1123: return Sse2.shuffle_epi32(a, SHUFFLE_1123);
							case SHUFFLE_1130: return Sse2.shuffle_epi32(a, SHUFFLE_1130);
							case SHUFFLE_1131: return Sse2.shuffle_epi32(a, SHUFFLE_1131);
							case SHUFFLE_1132: return Sse2.shuffle_epi32(a, SHUFFLE_1132);
							case SHUFFLE_1133: return Sse2.shuffle_epi32(a, SHUFFLE_1133);
							case SHUFFLE_1200: return Sse2.shuffle_epi32(a, SHUFFLE_1200);
							case SHUFFLE_1201: return Sse2.shuffle_epi32(a, SHUFFLE_1201);
							case SHUFFLE_1202: return Sse2.shuffle_epi32(a, SHUFFLE_1202);
							case SHUFFLE_1203: return Sse2.shuffle_epi32(a, SHUFFLE_1203);
							case SHUFFLE_1210: return Sse2.shuffle_epi32(a, SHUFFLE_1210);
							case SHUFFLE_1211: return Sse2.shuffle_epi32(a, SHUFFLE_1211);
							case SHUFFLE_1212: return Sse2.shuffle_epi32(a, SHUFFLE_1212);
							case SHUFFLE_1213: return Sse2.shuffle_epi32(a, SHUFFLE_1213);
							case SHUFFLE_1220: return Sse2.shuffle_epi32(a, SHUFFLE_1220);
							case SHUFFLE_1221: return Sse2.shuffle_epi32(a, SHUFFLE_1221);
							case SHUFFLE_1222: return Sse2.shuffle_epi32(a, SHUFFLE_1222);
							case SHUFFLE_1223: return Sse2.shuffle_epi32(a, SHUFFLE_1223);
							case SHUFFLE_1230: return Sse2.shuffle_epi32(a, SHUFFLE_1230);
							case SHUFFLE_1231: return Sse2.shuffle_epi32(a, SHUFFLE_1231);
							case SHUFFLE_1232: return Sse2.shuffle_epi32(a, SHUFFLE_1232);
							case SHUFFLE_1233: return Sse2.shuffle_epi32(a, SHUFFLE_1233);
							case SHUFFLE_1300: return Sse2.shuffle_epi32(a, SHUFFLE_1300);
							case SHUFFLE_1301: return Sse2.shuffle_epi32(a, SHUFFLE_1301);
							case SHUFFLE_1302: return Sse2.shuffle_epi32(a, SHUFFLE_1302);
							case SHUFFLE_1303: return Sse2.shuffle_epi32(a, SHUFFLE_1303);
							case SHUFFLE_1310: return Sse2.shuffle_epi32(a, SHUFFLE_1310);
							case SHUFFLE_1311: return Sse2.shuffle_epi32(a, SHUFFLE_1311);
							case SHUFFLE_1312: return Sse2.shuffle_epi32(a, SHUFFLE_1312);
							case SHUFFLE_1313: return Sse2.shuffle_epi32(a, SHUFFLE_1313);
							case SHUFFLE_1320: return Sse2.shuffle_epi32(a, SHUFFLE_1320);
							case SHUFFLE_1321: return Sse2.shuffle_epi32(a, SHUFFLE_1321);
							case SHUFFLE_1322: return Sse2.shuffle_epi32(a, SHUFFLE_1322);
							case SHUFFLE_1323: return Sse2.shuffle_epi32(a, SHUFFLE_1323);
							case SHUFFLE_1330: return Sse2.shuffle_epi32(a, SHUFFLE_1330);
							case SHUFFLE_1331: return Sse2.shuffle_epi32(a, SHUFFLE_1331);
							case SHUFFLE_1332: return Sse2.shuffle_epi32(a, SHUFFLE_1332);
							case SHUFFLE_1333: return Sse2.shuffle_epi32(a, SHUFFLE_1333);
							case SHUFFLE_2000: return Sse2.shuffle_epi32(a, SHUFFLE_2000);
							case SHUFFLE_2001: return Sse2.shuffle_epi32(a, SHUFFLE_2001);
							case SHUFFLE_2002: return Sse2.shuffle_epi32(a, SHUFFLE_2002);
							case SHUFFLE_2003: return Sse2.shuffle_epi32(a, SHUFFLE_2003);
							case SHUFFLE_2010: return Sse2.shuffle_epi32(a, SHUFFLE_2010);
							case SHUFFLE_2011: return Sse2.shuffle_epi32(a, SHUFFLE_2011);
							case SHUFFLE_2012: return Sse2.shuffle_epi32(a, SHUFFLE_2012);
							case SHUFFLE_2013: return Sse2.shuffle_epi32(a, SHUFFLE_2013);
							case SHUFFLE_2020: return Sse2.shuffle_epi32(a, SHUFFLE_2020);
							case SHUFFLE_2021: return Sse2.shuffle_epi32(a, SHUFFLE_2021);
							case SHUFFLE_2022: return Sse2.shuffle_epi32(a, SHUFFLE_2022);
							case SHUFFLE_2023: return Sse2.shuffle_epi32(a, SHUFFLE_2023);
							case SHUFFLE_2030: return Sse2.shuffle_epi32(a, SHUFFLE_2030);
							case SHUFFLE_2031: return Sse2.shuffle_epi32(a, SHUFFLE_2031);
							case SHUFFLE_2032: return Sse2.shuffle_epi32(a, SHUFFLE_2032);
							case SHUFFLE_2033: return Sse2.shuffle_epi32(a, SHUFFLE_2033);
							case SHUFFLE_2100: return Sse2.shuffle_epi32(a, SHUFFLE_2100);
							case SHUFFLE_2101: return Sse2.shuffle_epi32(a, SHUFFLE_2101);
							case SHUFFLE_2102: return Sse2.shuffle_epi32(a, SHUFFLE_2102);
							case SHUFFLE_2103: return Sse2.shuffle_epi32(a, SHUFFLE_2103);
							case SHUFFLE_2110: return Sse2.shuffle_epi32(a, SHUFFLE_2110);
							case SHUFFLE_2111: return Sse2.shuffle_epi32(a, SHUFFLE_2111);
							case SHUFFLE_2112: return Sse2.shuffle_epi32(a, SHUFFLE_2112);
							case SHUFFLE_2113: return Sse2.shuffle_epi32(a, SHUFFLE_2113);
							case SHUFFLE_2120: return Sse2.shuffle_epi32(a, SHUFFLE_2120);
							case SHUFFLE_2121: return Sse2.shuffle_epi32(a, SHUFFLE_2121);
							case SHUFFLE_2122: return Sse2.shuffle_epi32(a, SHUFFLE_2122);
							case SHUFFLE_2123: return Sse2.shuffle_epi32(a, SHUFFLE_2123);
							case SHUFFLE_2130: return Sse2.shuffle_epi32(a, SHUFFLE_2130);
							case SHUFFLE_2131: return Sse2.shuffle_epi32(a, SHUFFLE_2131);
							case SHUFFLE_2132: return Sse2.shuffle_epi32(a, SHUFFLE_2132);
							case SHUFFLE_2133: return Sse2.shuffle_epi32(a, SHUFFLE_2133);
							case SHUFFLE_2200: return Sse2.shuffle_epi32(a, SHUFFLE_2200);
							case SHUFFLE_2201: return Sse2.shuffle_epi32(a, SHUFFLE_2201);
							case SHUFFLE_2202: return Sse2.shuffle_epi32(a, SHUFFLE_2202);
							case SHUFFLE_2203: return Sse2.shuffle_epi32(a, SHUFFLE_2203);
							case SHUFFLE_2210: return Sse2.shuffle_epi32(a, SHUFFLE_2210);
							case SHUFFLE_2211: return Sse2.shuffle_epi32(a, SHUFFLE_2211);
							case SHUFFLE_2212: return Sse2.shuffle_epi32(a, SHUFFLE_2212);
							case SHUFFLE_2213: return Sse2.shuffle_epi32(a, SHUFFLE_2213);
							case SHUFFLE_2220: return Sse2.shuffle_epi32(a, SHUFFLE_2220);
							case SHUFFLE_2221: return Sse2.shuffle_epi32(a, SHUFFLE_2221);
							case SHUFFLE_2222: return Sse2.shuffle_epi32(a, SHUFFLE_2222);
							case SHUFFLE_2223: return Sse2.shuffle_epi32(a, SHUFFLE_2223);
							case SHUFFLE_2230: return Sse2.shuffle_epi32(a, SHUFFLE_2230);
							case SHUFFLE_2231: return Sse2.shuffle_epi32(a, SHUFFLE_2231);
							case SHUFFLE_2232: return Sse2.shuffle_epi32(a, SHUFFLE_2232);
							case SHUFFLE_2233: return Sse2.shuffle_epi32(a, SHUFFLE_2233);
							case SHUFFLE_2300: return Sse2.shuffle_epi32(a, SHUFFLE_2300);
							case SHUFFLE_2301: return Sse2.shuffle_epi32(a, SHUFFLE_2301);
							case SHUFFLE_2302: return Sse2.shuffle_epi32(a, SHUFFLE_2302);
							case SHUFFLE_2303: return Sse2.shuffle_epi32(a, SHUFFLE_2303);
							case SHUFFLE_2310: return Sse2.shuffle_epi32(a, SHUFFLE_2310);
							case SHUFFLE_2311: return Sse2.shuffle_epi32(a, SHUFFLE_2311);
							case SHUFFLE_2312: return Sse2.shuffle_epi32(a, SHUFFLE_2312);
							case SHUFFLE_2313: return Sse2.shuffle_epi32(a, SHUFFLE_2313);
							case SHUFFLE_2320: return Sse2.shuffle_epi32(a, SHUFFLE_2320);
							case SHUFFLE_2321: return Sse2.shuffle_epi32(a, SHUFFLE_2321);
							case SHUFFLE_2322: return Sse2.shuffle_epi32(a, SHUFFLE_2322);
							case SHUFFLE_2323: return Sse2.shuffle_epi32(a, SHUFFLE_2323);
							case SHUFFLE_2330: return Sse2.shuffle_epi32(a, SHUFFLE_2330);
							case SHUFFLE_2331: return Sse2.shuffle_epi32(a, SHUFFLE_2331);
							case SHUFFLE_2332: return Sse2.shuffle_epi32(a, SHUFFLE_2332);
							case SHUFFLE_2333: return Sse2.shuffle_epi32(a, SHUFFLE_2333);
							case SHUFFLE_3000: return Sse2.shuffle_epi32(a, SHUFFLE_3000);
							case SHUFFLE_3001: return Sse2.shuffle_epi32(a, SHUFFLE_3001);
							case SHUFFLE_3002: return Sse2.shuffle_epi32(a, SHUFFLE_3002);
							case SHUFFLE_3003: return Sse2.shuffle_epi32(a, SHUFFLE_3003);
							case SHUFFLE_3010: return Sse2.shuffle_epi32(a, SHUFFLE_3010);
							case SHUFFLE_3011: return Sse2.shuffle_epi32(a, SHUFFLE_3011);
							case SHUFFLE_3012: return Sse2.shuffle_epi32(a, SHUFFLE_3012);
							case SHUFFLE_3013: return Sse2.shuffle_epi32(a, SHUFFLE_3013);
							case SHUFFLE_3020: return Sse2.shuffle_epi32(a, SHUFFLE_3020);
							case SHUFFLE_3021: return Sse2.shuffle_epi32(a, SHUFFLE_3021);
							case SHUFFLE_3022: return Sse2.shuffle_epi32(a, SHUFFLE_3022);
							case SHUFFLE_3023: return Sse2.shuffle_epi32(a, SHUFFLE_3023);
							case SHUFFLE_3030: return Sse2.shuffle_epi32(a, SHUFFLE_3030);
							case SHUFFLE_3031: return Sse2.shuffle_epi32(a, SHUFFLE_3031);
							case SHUFFLE_3032: return Sse2.shuffle_epi32(a, SHUFFLE_3032);
							case SHUFFLE_3033: return Sse2.shuffle_epi32(a, SHUFFLE_3033);
							case SHUFFLE_3100: return Sse2.shuffle_epi32(a, SHUFFLE_3100);
							case SHUFFLE_3101: return Sse2.shuffle_epi32(a, SHUFFLE_3101);
							case SHUFFLE_3102: return Sse2.shuffle_epi32(a, SHUFFLE_3102);
							case SHUFFLE_3103: return Sse2.shuffle_epi32(a, SHUFFLE_3103);
							case SHUFFLE_3110: return Sse2.shuffle_epi32(a, SHUFFLE_3110);
							case SHUFFLE_3111: return Sse2.shuffle_epi32(a, SHUFFLE_3111);
							case SHUFFLE_3112: return Sse2.shuffle_epi32(a, SHUFFLE_3112);
							case SHUFFLE_3113: return Sse2.shuffle_epi32(a, SHUFFLE_3113);
							case SHUFFLE_3120: return Sse2.shuffle_epi32(a, SHUFFLE_3120);
							case SHUFFLE_3121: return Sse2.shuffle_epi32(a, SHUFFLE_3121);
							case SHUFFLE_3122: return Sse2.shuffle_epi32(a, SHUFFLE_3122);
							case SHUFFLE_3123: return Sse2.shuffle_epi32(a, SHUFFLE_3123);
							case SHUFFLE_3130: return Sse2.shuffle_epi32(a, SHUFFLE_3130);
							case SHUFFLE_3131: return Sse2.shuffle_epi32(a, SHUFFLE_3131);
							case SHUFFLE_3132: return Sse2.shuffle_epi32(a, SHUFFLE_3132);
							case SHUFFLE_3133: return Sse2.shuffle_epi32(a, SHUFFLE_3133);
							case SHUFFLE_3200: return Sse2.shuffle_epi32(a, SHUFFLE_3200);
							case SHUFFLE_3201: return Sse2.shuffle_epi32(a, SHUFFLE_3201);
							case SHUFFLE_3202: return Sse2.shuffle_epi32(a, SHUFFLE_3202);
							case SHUFFLE_3203: return Sse2.shuffle_epi32(a, SHUFFLE_3203);
							case SHUFFLE_3210: return Sse2.shuffle_epi32(a, SHUFFLE_3210);
							case SHUFFLE_3211: return Sse2.shuffle_epi32(a, SHUFFLE_3211);
							case SHUFFLE_3212: return Sse2.shuffle_epi32(a, SHUFFLE_3212);
							case SHUFFLE_3213: return Sse2.shuffle_epi32(a, SHUFFLE_3213);
							case SHUFFLE_3220: return Sse2.shuffle_epi32(a, SHUFFLE_3220);
							case SHUFFLE_3221: return Sse2.shuffle_epi32(a, SHUFFLE_3221);
							case SHUFFLE_3222: return Sse2.shuffle_epi32(a, SHUFFLE_3222);
							case SHUFFLE_3223: return Sse2.shuffle_epi32(a, SHUFFLE_3223);
							case SHUFFLE_3230: return Sse2.shuffle_epi32(a, SHUFFLE_3230);
							case SHUFFLE_3231: return Sse2.shuffle_epi32(a, SHUFFLE_3231);
							case SHUFFLE_3232: return Sse2.shuffle_epi32(a, SHUFFLE_3232);
							case SHUFFLE_3233: return Sse2.shuffle_epi32(a, SHUFFLE_3233);
							case SHUFFLE_3300: return Sse2.shuffle_epi32(a, SHUFFLE_3300);
							case SHUFFLE_3301: return Sse2.shuffle_epi32(a, SHUFFLE_3301);
							case SHUFFLE_3302: return Sse2.shuffle_epi32(a, SHUFFLE_3302);
							case SHUFFLE_3303: return Sse2.shuffle_epi32(a, SHUFFLE_3303);
							case SHUFFLE_3310: return Sse2.shuffle_epi32(a, SHUFFLE_3310);
							case SHUFFLE_3311: return Sse2.shuffle_epi32(a, SHUFFLE_3311);
							case SHUFFLE_3312: return Sse2.shuffle_epi32(a, SHUFFLE_3312);
							case SHUFFLE_3313: return Sse2.shuffle_epi32(a, SHUFFLE_3313);
							case SHUFFLE_3320: return Sse2.shuffle_epi32(a, SHUFFLE_3320);
							case SHUFFLE_3321: return Sse2.shuffle_epi32(a, SHUFFLE_3321);
							case SHUFFLE_3322: return Sse2.shuffle_epi32(a, SHUFFLE_3322);
							case SHUFFLE_3323: return Sse2.shuffle_epi32(a, SHUFFLE_3323);
							case SHUFFLE_3330: return Sse2.shuffle_epi32(a, SHUFFLE_3330);
							case SHUFFLE_3331: return Sse2.shuffle_epi32(a, SHUFFLE_3331);
							case SHUFFLE_3332: return Sse2.shuffle_epi32(a, SHUFFLE_3332);
							case SHUFFLE_3333: return Sse2.shuffle_epi32(a, SHUFFLE_3333);
							default: return a;
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public static v128 shufflehi_epi16(v128 a, int imm8)
				{
					if (Sse2.IsSse2Supported)
					{
						switch (imm8)
						{
							case SHUFFLE_0000: return Sse2.shufflehi_epi16(a, SHUFFLE_0000);
							case SHUFFLE_0001: return Sse2.shufflehi_epi16(a, SHUFFLE_0001);
							case SHUFFLE_0002: return Sse2.shufflehi_epi16(a, SHUFFLE_0002);
							case SHUFFLE_0003: return Sse2.shufflehi_epi16(a, SHUFFLE_0003);
							case SHUFFLE_0010: return Sse2.shufflehi_epi16(a, SHUFFLE_0010);
							case SHUFFLE_0011: return Sse2.shufflehi_epi16(a, SHUFFLE_0011);
							case SHUFFLE_0012: return Sse2.shufflehi_epi16(a, SHUFFLE_0012);
							case SHUFFLE_0013: return Sse2.shufflehi_epi16(a, SHUFFLE_0013);
							case SHUFFLE_0020: return Sse2.shufflehi_epi16(a, SHUFFLE_0020);
							case SHUFFLE_0021: return Sse2.shufflehi_epi16(a, SHUFFLE_0021);
							case SHUFFLE_0022: return Sse2.shufflehi_epi16(a, SHUFFLE_0022);
							case SHUFFLE_0023: return Sse2.shufflehi_epi16(a, SHUFFLE_0023);
							case SHUFFLE_0030: return Sse2.shufflehi_epi16(a, SHUFFLE_0030);
							case SHUFFLE_0031: return Sse2.shufflehi_epi16(a, SHUFFLE_0031);
							case SHUFFLE_0032: return Sse2.shufflehi_epi16(a, SHUFFLE_0032);
							case SHUFFLE_0033: return Sse2.shufflehi_epi16(a, SHUFFLE_0033);
							case SHUFFLE_0100: return Sse2.shufflehi_epi16(a, SHUFFLE_0100);
							case SHUFFLE_0101: return Sse2.shufflehi_epi16(a, SHUFFLE_0101);
							case SHUFFLE_0102: return Sse2.shufflehi_epi16(a, SHUFFLE_0102);
							case SHUFFLE_0103: return Sse2.shufflehi_epi16(a, SHUFFLE_0103);
							case SHUFFLE_0110: return Sse2.shufflehi_epi16(a, SHUFFLE_0110);
							case SHUFFLE_0111: return Sse2.shufflehi_epi16(a, SHUFFLE_0111);
							case SHUFFLE_0112: return Sse2.shufflehi_epi16(a, SHUFFLE_0112);
							case SHUFFLE_0113: return Sse2.shufflehi_epi16(a, SHUFFLE_0113);
							case SHUFFLE_0120: return Sse2.shufflehi_epi16(a, SHUFFLE_0120);
							case SHUFFLE_0121: return Sse2.shufflehi_epi16(a, SHUFFLE_0121);
							case SHUFFLE_0122: return Sse2.shufflehi_epi16(a, SHUFFLE_0122);
							case SHUFFLE_0123: return Sse2.shufflehi_epi16(a, SHUFFLE_0123);
							case SHUFFLE_0130: return Sse2.shufflehi_epi16(a, SHUFFLE_0130);
							case SHUFFLE_0131: return Sse2.shufflehi_epi16(a, SHUFFLE_0131);
							case SHUFFLE_0132: return Sse2.shufflehi_epi16(a, SHUFFLE_0132);
							case SHUFFLE_0133: return Sse2.shufflehi_epi16(a, SHUFFLE_0133);
							case SHUFFLE_0200: return Sse2.shufflehi_epi16(a, SHUFFLE_0200);
							case SHUFFLE_0201: return Sse2.shufflehi_epi16(a, SHUFFLE_0201);
							case SHUFFLE_0202: return Sse2.shufflehi_epi16(a, SHUFFLE_0202);
							case SHUFFLE_0203: return Sse2.shufflehi_epi16(a, SHUFFLE_0203);
							case SHUFFLE_0210: return Sse2.shufflehi_epi16(a, SHUFFLE_0210);
							case SHUFFLE_0211: return Sse2.shufflehi_epi16(a, SHUFFLE_0211);
							case SHUFFLE_0212: return Sse2.shufflehi_epi16(a, SHUFFLE_0212);
							case SHUFFLE_0213: return Sse2.shufflehi_epi16(a, SHUFFLE_0213);
							case SHUFFLE_0220: return Sse2.shufflehi_epi16(a, SHUFFLE_0220);
							case SHUFFLE_0221: return Sse2.shufflehi_epi16(a, SHUFFLE_0221);
							case SHUFFLE_0222: return Sse2.shufflehi_epi16(a, SHUFFLE_0222);
							case SHUFFLE_0223: return Sse2.shufflehi_epi16(a, SHUFFLE_0223);
							case SHUFFLE_0230: return Sse2.shufflehi_epi16(a, SHUFFLE_0230);
							case SHUFFLE_0231: return Sse2.shufflehi_epi16(a, SHUFFLE_0231);
							case SHUFFLE_0232: return Sse2.shufflehi_epi16(a, SHUFFLE_0232);
							case SHUFFLE_0233: return Sse2.shufflehi_epi16(a, SHUFFLE_0233);
							case SHUFFLE_0300: return Sse2.shufflehi_epi16(a, SHUFFLE_0300);
							case SHUFFLE_0301: return Sse2.shufflehi_epi16(a, SHUFFLE_0301);
							case SHUFFLE_0302: return Sse2.shufflehi_epi16(a, SHUFFLE_0302);
							case SHUFFLE_0303: return Sse2.shufflehi_epi16(a, SHUFFLE_0303);
							case SHUFFLE_0310: return Sse2.shufflehi_epi16(a, SHUFFLE_0310);
							case SHUFFLE_0311: return Sse2.shufflehi_epi16(a, SHUFFLE_0311);
							case SHUFFLE_0312: return Sse2.shufflehi_epi16(a, SHUFFLE_0312);
							case SHUFFLE_0313: return Sse2.shufflehi_epi16(a, SHUFFLE_0313);
							case SHUFFLE_0320: return Sse2.shufflehi_epi16(a, SHUFFLE_0320);
							case SHUFFLE_0321: return Sse2.shufflehi_epi16(a, SHUFFLE_0321);
							case SHUFFLE_0322: return Sse2.shufflehi_epi16(a, SHUFFLE_0322);
							case SHUFFLE_0323: return Sse2.shufflehi_epi16(a, SHUFFLE_0323);
							case SHUFFLE_0330: return Sse2.shufflehi_epi16(a, SHUFFLE_0330);
							case SHUFFLE_0331: return Sse2.shufflehi_epi16(a, SHUFFLE_0331);
							case SHUFFLE_0332: return Sse2.shufflehi_epi16(a, SHUFFLE_0332);
							case SHUFFLE_0333: return Sse2.shufflehi_epi16(a, SHUFFLE_0333);
							case SHUFFLE_1000: return Sse2.shufflehi_epi16(a, SHUFFLE_1000);
							case SHUFFLE_1001: return Sse2.shufflehi_epi16(a, SHUFFLE_1001);
							case SHUFFLE_1002: return Sse2.shufflehi_epi16(a, SHUFFLE_1002);
							case SHUFFLE_1003: return Sse2.shufflehi_epi16(a, SHUFFLE_1003);
							case SHUFFLE_1010: return Sse2.shufflehi_epi16(a, SHUFFLE_1010);
							case SHUFFLE_1011: return Sse2.shufflehi_epi16(a, SHUFFLE_1011);
							case SHUFFLE_1012: return Sse2.shufflehi_epi16(a, SHUFFLE_1012);
							case SHUFFLE_1013: return Sse2.shufflehi_epi16(a, SHUFFLE_1013);
							case SHUFFLE_1020: return Sse2.shufflehi_epi16(a, SHUFFLE_1020);
							case SHUFFLE_1021: return Sse2.shufflehi_epi16(a, SHUFFLE_1021);
							case SHUFFLE_1022: return Sse2.shufflehi_epi16(a, SHUFFLE_1022);
							case SHUFFLE_1023: return Sse2.shufflehi_epi16(a, SHUFFLE_1023);
							case SHUFFLE_1030: return Sse2.shufflehi_epi16(a, SHUFFLE_1030);
							case SHUFFLE_1031: return Sse2.shufflehi_epi16(a, SHUFFLE_1031);
							case SHUFFLE_1032: return Sse2.shufflehi_epi16(a, SHUFFLE_1032);
							case SHUFFLE_1033: return Sse2.shufflehi_epi16(a, SHUFFLE_1033);
							case SHUFFLE_1100: return Sse2.shufflehi_epi16(a, SHUFFLE_1100);
							case SHUFFLE_1101: return Sse2.shufflehi_epi16(a, SHUFFLE_1101);
							case SHUFFLE_1102: return Sse2.shufflehi_epi16(a, SHUFFLE_1102);
							case SHUFFLE_1103: return Sse2.shufflehi_epi16(a, SHUFFLE_1103);
							case SHUFFLE_1110: return Sse2.shufflehi_epi16(a, SHUFFLE_1110);
							case SHUFFLE_1111: return Sse2.shufflehi_epi16(a, SHUFFLE_1111);
							case SHUFFLE_1112: return Sse2.shufflehi_epi16(a, SHUFFLE_1112);
							case SHUFFLE_1113: return Sse2.shufflehi_epi16(a, SHUFFLE_1113);
							case SHUFFLE_1120: return Sse2.shufflehi_epi16(a, SHUFFLE_1120);
							case SHUFFLE_1121: return Sse2.shufflehi_epi16(a, SHUFFLE_1121);
							case SHUFFLE_1122: return Sse2.shufflehi_epi16(a, SHUFFLE_1122);
							case SHUFFLE_1123: return Sse2.shufflehi_epi16(a, SHUFFLE_1123);
							case SHUFFLE_1130: return Sse2.shufflehi_epi16(a, SHUFFLE_1130);
							case SHUFFLE_1131: return Sse2.shufflehi_epi16(a, SHUFFLE_1131);
							case SHUFFLE_1132: return Sse2.shufflehi_epi16(a, SHUFFLE_1132);
							case SHUFFLE_1133: return Sse2.shufflehi_epi16(a, SHUFFLE_1133);
							case SHUFFLE_1200: return Sse2.shufflehi_epi16(a, SHUFFLE_1200);
							case SHUFFLE_1201: return Sse2.shufflehi_epi16(a, SHUFFLE_1201);
							case SHUFFLE_1202: return Sse2.shufflehi_epi16(a, SHUFFLE_1202);
							case SHUFFLE_1203: return Sse2.shufflehi_epi16(a, SHUFFLE_1203);
							case SHUFFLE_1210: return Sse2.shufflehi_epi16(a, SHUFFLE_1210);
							case SHUFFLE_1211: return Sse2.shufflehi_epi16(a, SHUFFLE_1211);
							case SHUFFLE_1212: return Sse2.shufflehi_epi16(a, SHUFFLE_1212);
							case SHUFFLE_1213: return Sse2.shufflehi_epi16(a, SHUFFLE_1213);
							case SHUFFLE_1220: return Sse2.shufflehi_epi16(a, SHUFFLE_1220);
							case SHUFFLE_1221: return Sse2.shufflehi_epi16(a, SHUFFLE_1221);
							case SHUFFLE_1222: return Sse2.shufflehi_epi16(a, SHUFFLE_1222);
							case SHUFFLE_1223: return Sse2.shufflehi_epi16(a, SHUFFLE_1223);
							case SHUFFLE_1230: return Sse2.shufflehi_epi16(a, SHUFFLE_1230);
							case SHUFFLE_1231: return Sse2.shufflehi_epi16(a, SHUFFLE_1231);
							case SHUFFLE_1232: return Sse2.shufflehi_epi16(a, SHUFFLE_1232);
							case SHUFFLE_1233: return Sse2.shufflehi_epi16(a, SHUFFLE_1233);
							case SHUFFLE_1300: return Sse2.shufflehi_epi16(a, SHUFFLE_1300);
							case SHUFFLE_1301: return Sse2.shufflehi_epi16(a, SHUFFLE_1301);
							case SHUFFLE_1302: return Sse2.shufflehi_epi16(a, SHUFFLE_1302);
							case SHUFFLE_1303: return Sse2.shufflehi_epi16(a, SHUFFLE_1303);
							case SHUFFLE_1310: return Sse2.shufflehi_epi16(a, SHUFFLE_1310);
							case SHUFFLE_1311: return Sse2.shufflehi_epi16(a, SHUFFLE_1311);
							case SHUFFLE_1312: return Sse2.shufflehi_epi16(a, SHUFFLE_1312);
							case SHUFFLE_1313: return Sse2.shufflehi_epi16(a, SHUFFLE_1313);
							case SHUFFLE_1320: return Sse2.shufflehi_epi16(a, SHUFFLE_1320);
							case SHUFFLE_1321: return Sse2.shufflehi_epi16(a, SHUFFLE_1321);
							case SHUFFLE_1322: return Sse2.shufflehi_epi16(a, SHUFFLE_1322);
							case SHUFFLE_1323: return Sse2.shufflehi_epi16(a, SHUFFLE_1323);
							case SHUFFLE_1330: return Sse2.shufflehi_epi16(a, SHUFFLE_1330);
							case SHUFFLE_1331: return Sse2.shufflehi_epi16(a, SHUFFLE_1331);
							case SHUFFLE_1332: return Sse2.shufflehi_epi16(a, SHUFFLE_1332);
							case SHUFFLE_1333: return Sse2.shufflehi_epi16(a, SHUFFLE_1333);
							case SHUFFLE_2000: return Sse2.shufflehi_epi16(a, SHUFFLE_2000);
							case SHUFFLE_2001: return Sse2.shufflehi_epi16(a, SHUFFLE_2001);
							case SHUFFLE_2002: return Sse2.shufflehi_epi16(a, SHUFFLE_2002);
							case SHUFFLE_2003: return Sse2.shufflehi_epi16(a, SHUFFLE_2003);
							case SHUFFLE_2010: return Sse2.shufflehi_epi16(a, SHUFFLE_2010);
							case SHUFFLE_2011: return Sse2.shufflehi_epi16(a, SHUFFLE_2011);
							case SHUFFLE_2012: return Sse2.shufflehi_epi16(a, SHUFFLE_2012);
							case SHUFFLE_2013: return Sse2.shufflehi_epi16(a, SHUFFLE_2013);
							case SHUFFLE_2020: return Sse2.shufflehi_epi16(a, SHUFFLE_2020);
							case SHUFFLE_2021: return Sse2.shufflehi_epi16(a, SHUFFLE_2021);
							case SHUFFLE_2022: return Sse2.shufflehi_epi16(a, SHUFFLE_2022);
							case SHUFFLE_2023: return Sse2.shufflehi_epi16(a, SHUFFLE_2023);
							case SHUFFLE_2030: return Sse2.shufflehi_epi16(a, SHUFFLE_2030);
							case SHUFFLE_2031: return Sse2.shufflehi_epi16(a, SHUFFLE_2031);
							case SHUFFLE_2032: return Sse2.shufflehi_epi16(a, SHUFFLE_2032);
							case SHUFFLE_2033: return Sse2.shufflehi_epi16(a, SHUFFLE_2033);
							case SHUFFLE_2100: return Sse2.shufflehi_epi16(a, SHUFFLE_2100);
							case SHUFFLE_2101: return Sse2.shufflehi_epi16(a, SHUFFLE_2101);
							case SHUFFLE_2102: return Sse2.shufflehi_epi16(a, SHUFFLE_2102);
							case SHUFFLE_2103: return Sse2.shufflehi_epi16(a, SHUFFLE_2103);
							case SHUFFLE_2110: return Sse2.shufflehi_epi16(a, SHUFFLE_2110);
							case SHUFFLE_2111: return Sse2.shufflehi_epi16(a, SHUFFLE_2111);
							case SHUFFLE_2112: return Sse2.shufflehi_epi16(a, SHUFFLE_2112);
							case SHUFFLE_2113: return Sse2.shufflehi_epi16(a, SHUFFLE_2113);
							case SHUFFLE_2120: return Sse2.shufflehi_epi16(a, SHUFFLE_2120);
							case SHUFFLE_2121: return Sse2.shufflehi_epi16(a, SHUFFLE_2121);
							case SHUFFLE_2122: return Sse2.shufflehi_epi16(a, SHUFFLE_2122);
							case SHUFFLE_2123: return Sse2.shufflehi_epi16(a, SHUFFLE_2123);
							case SHUFFLE_2130: return Sse2.shufflehi_epi16(a, SHUFFLE_2130);
							case SHUFFLE_2131: return Sse2.shufflehi_epi16(a, SHUFFLE_2131);
							case SHUFFLE_2132: return Sse2.shufflehi_epi16(a, SHUFFLE_2132);
							case SHUFFLE_2133: return Sse2.shufflehi_epi16(a, SHUFFLE_2133);
							case SHUFFLE_2200: return Sse2.shufflehi_epi16(a, SHUFFLE_2200);
							case SHUFFLE_2201: return Sse2.shufflehi_epi16(a, SHUFFLE_2201);
							case SHUFFLE_2202: return Sse2.shufflehi_epi16(a, SHUFFLE_2202);
							case SHUFFLE_2203: return Sse2.shufflehi_epi16(a, SHUFFLE_2203);
							case SHUFFLE_2210: return Sse2.shufflehi_epi16(a, SHUFFLE_2210);
							case SHUFFLE_2211: return Sse2.shufflehi_epi16(a, SHUFFLE_2211);
							case SHUFFLE_2212: return Sse2.shufflehi_epi16(a, SHUFFLE_2212);
							case SHUFFLE_2213: return Sse2.shufflehi_epi16(a, SHUFFLE_2213);
							case SHUFFLE_2220: return Sse2.shufflehi_epi16(a, SHUFFLE_2220);
							case SHUFFLE_2221: return Sse2.shufflehi_epi16(a, SHUFFLE_2221);
							case SHUFFLE_2222: return Sse2.shufflehi_epi16(a, SHUFFLE_2222);
							case SHUFFLE_2223: return Sse2.shufflehi_epi16(a, SHUFFLE_2223);
							case SHUFFLE_2230: return Sse2.shufflehi_epi16(a, SHUFFLE_2230);
							case SHUFFLE_2231: return Sse2.shufflehi_epi16(a, SHUFFLE_2231);
							case SHUFFLE_2232: return Sse2.shufflehi_epi16(a, SHUFFLE_2232);
							case SHUFFLE_2233: return Sse2.shufflehi_epi16(a, SHUFFLE_2233);
							case SHUFFLE_2300: return Sse2.shufflehi_epi16(a, SHUFFLE_2300);
							case SHUFFLE_2301: return Sse2.shufflehi_epi16(a, SHUFFLE_2301);
							case SHUFFLE_2302: return Sse2.shufflehi_epi16(a, SHUFFLE_2302);
							case SHUFFLE_2303: return Sse2.shufflehi_epi16(a, SHUFFLE_2303);
							case SHUFFLE_2310: return Sse2.shufflehi_epi16(a, SHUFFLE_2310);
							case SHUFFLE_2311: return Sse2.shufflehi_epi16(a, SHUFFLE_2311);
							case SHUFFLE_2312: return Sse2.shufflehi_epi16(a, SHUFFLE_2312);
							case SHUFFLE_2313: return Sse2.shufflehi_epi16(a, SHUFFLE_2313);
							case SHUFFLE_2320: return Sse2.shufflehi_epi16(a, SHUFFLE_2320);
							case SHUFFLE_2321: return Sse2.shufflehi_epi16(a, SHUFFLE_2321);
							case SHUFFLE_2322: return Sse2.shufflehi_epi16(a, SHUFFLE_2322);
							case SHUFFLE_2323: return Sse2.shufflehi_epi16(a, SHUFFLE_2323);
							case SHUFFLE_2330: return Sse2.shufflehi_epi16(a, SHUFFLE_2330);
							case SHUFFLE_2331: return Sse2.shufflehi_epi16(a, SHUFFLE_2331);
							case SHUFFLE_2332: return Sse2.shufflehi_epi16(a, SHUFFLE_2332);
							case SHUFFLE_2333: return Sse2.shufflehi_epi16(a, SHUFFLE_2333);
							case SHUFFLE_3000: return Sse2.shufflehi_epi16(a, SHUFFLE_3000);
							case SHUFFLE_3001: return Sse2.shufflehi_epi16(a, SHUFFLE_3001);
							case SHUFFLE_3002: return Sse2.shufflehi_epi16(a, SHUFFLE_3002);
							case SHUFFLE_3003: return Sse2.shufflehi_epi16(a, SHUFFLE_3003);
							case SHUFFLE_3010: return Sse2.shufflehi_epi16(a, SHUFFLE_3010);
							case SHUFFLE_3011: return Sse2.shufflehi_epi16(a, SHUFFLE_3011);
							case SHUFFLE_3012: return Sse2.shufflehi_epi16(a, SHUFFLE_3012);
							case SHUFFLE_3013: return Sse2.shufflehi_epi16(a, SHUFFLE_3013);
							case SHUFFLE_3020: return Sse2.shufflehi_epi16(a, SHUFFLE_3020);
							case SHUFFLE_3021: return Sse2.shufflehi_epi16(a, SHUFFLE_3021);
							case SHUFFLE_3022: return Sse2.shufflehi_epi16(a, SHUFFLE_3022);
							case SHUFFLE_3023: return Sse2.shufflehi_epi16(a, SHUFFLE_3023);
							case SHUFFLE_3030: return Sse2.shufflehi_epi16(a, SHUFFLE_3030);
							case SHUFFLE_3031: return Sse2.shufflehi_epi16(a, SHUFFLE_3031);
							case SHUFFLE_3032: return Sse2.shufflehi_epi16(a, SHUFFLE_3032);
							case SHUFFLE_3033: return Sse2.shufflehi_epi16(a, SHUFFLE_3033);
							case SHUFFLE_3100: return Sse2.shufflehi_epi16(a, SHUFFLE_3100);
							case SHUFFLE_3101: return Sse2.shufflehi_epi16(a, SHUFFLE_3101);
							case SHUFFLE_3102: return Sse2.shufflehi_epi16(a, SHUFFLE_3102);
							case SHUFFLE_3103: return Sse2.shufflehi_epi16(a, SHUFFLE_3103);
							case SHUFFLE_3110: return Sse2.shufflehi_epi16(a, SHUFFLE_3110);
							case SHUFFLE_3111: return Sse2.shufflehi_epi16(a, SHUFFLE_3111);
							case SHUFFLE_3112: return Sse2.shufflehi_epi16(a, SHUFFLE_3112);
							case SHUFFLE_3113: return Sse2.shufflehi_epi16(a, SHUFFLE_3113);
							case SHUFFLE_3120: return Sse2.shufflehi_epi16(a, SHUFFLE_3120);
							case SHUFFLE_3121: return Sse2.shufflehi_epi16(a, SHUFFLE_3121);
							case SHUFFLE_3122: return Sse2.shufflehi_epi16(a, SHUFFLE_3122);
							case SHUFFLE_3123: return Sse2.shufflehi_epi16(a, SHUFFLE_3123);
							case SHUFFLE_3130: return Sse2.shufflehi_epi16(a, SHUFFLE_3130);
							case SHUFFLE_3131: return Sse2.shufflehi_epi16(a, SHUFFLE_3131);
							case SHUFFLE_3132: return Sse2.shufflehi_epi16(a, SHUFFLE_3132);
							case SHUFFLE_3133: return Sse2.shufflehi_epi16(a, SHUFFLE_3133);
							case SHUFFLE_3200: return Sse2.shufflehi_epi16(a, SHUFFLE_3200);
							case SHUFFLE_3201: return Sse2.shufflehi_epi16(a, SHUFFLE_3201);
							case SHUFFLE_3202: return Sse2.shufflehi_epi16(a, SHUFFLE_3202);
							case SHUFFLE_3203: return Sse2.shufflehi_epi16(a, SHUFFLE_3203);
							case SHUFFLE_3210: return Sse2.shufflehi_epi16(a, SHUFFLE_3210);
							case SHUFFLE_3211: return Sse2.shufflehi_epi16(a, SHUFFLE_3211);
							case SHUFFLE_3212: return Sse2.shufflehi_epi16(a, SHUFFLE_3212);
							case SHUFFLE_3213: return Sse2.shufflehi_epi16(a, SHUFFLE_3213);
							case SHUFFLE_3220: return Sse2.shufflehi_epi16(a, SHUFFLE_3220);
							case SHUFFLE_3221: return Sse2.shufflehi_epi16(a, SHUFFLE_3221);
							case SHUFFLE_3222: return Sse2.shufflehi_epi16(a, SHUFFLE_3222);
							case SHUFFLE_3223: return Sse2.shufflehi_epi16(a, SHUFFLE_3223);
							case SHUFFLE_3230: return Sse2.shufflehi_epi16(a, SHUFFLE_3230);
							case SHUFFLE_3231: return Sse2.shufflehi_epi16(a, SHUFFLE_3231);
							case SHUFFLE_3232: return Sse2.shufflehi_epi16(a, SHUFFLE_3232);
							case SHUFFLE_3233: return Sse2.shufflehi_epi16(a, SHUFFLE_3233);
							case SHUFFLE_3300: return Sse2.shufflehi_epi16(a, SHUFFLE_3300);
							case SHUFFLE_3301: return Sse2.shufflehi_epi16(a, SHUFFLE_3301);
							case SHUFFLE_3302: return Sse2.shufflehi_epi16(a, SHUFFLE_3302);
							case SHUFFLE_3303: return Sse2.shufflehi_epi16(a, SHUFFLE_3303);
							case SHUFFLE_3310: return Sse2.shufflehi_epi16(a, SHUFFLE_3310);
							case SHUFFLE_3311: return Sse2.shufflehi_epi16(a, SHUFFLE_3311);
							case SHUFFLE_3312: return Sse2.shufflehi_epi16(a, SHUFFLE_3312);
							case SHUFFLE_3313: return Sse2.shufflehi_epi16(a, SHUFFLE_3313);
							case SHUFFLE_3320: return Sse2.shufflehi_epi16(a, SHUFFLE_3320);
							case SHUFFLE_3321: return Sse2.shufflehi_epi16(a, SHUFFLE_3321);
							case SHUFFLE_3322: return Sse2.shufflehi_epi16(a, SHUFFLE_3322);
							case SHUFFLE_3323: return Sse2.shufflehi_epi16(a, SHUFFLE_3323);
							case SHUFFLE_3330: return Sse2.shufflehi_epi16(a, SHUFFLE_3330);
							case SHUFFLE_3331: return Sse2.shufflehi_epi16(a, SHUFFLE_3331);
							case SHUFFLE_3332: return Sse2.shufflehi_epi16(a, SHUFFLE_3332);
							case SHUFFLE_3333: return Sse2.shufflehi_epi16(a, SHUFFLE_3333);
							default: return a;
						}
					}
					else throw new IllegalInstructionException();
				}
				
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public static v128 shufflelo_epi16(v128 a, int imm8)
				{
					if (Sse2.IsSse2Supported)
					{
						switch (imm8)
						{
							case SHUFFLE_0000: return Sse2.shufflelo_epi16(a, SHUFFLE_0000);
							case SHUFFLE_0001: return Sse2.shufflelo_epi16(a, SHUFFLE_0001);
							case SHUFFLE_0002: return Sse2.shufflelo_epi16(a, SHUFFLE_0002);
							case SHUFFLE_0003: return Sse2.shufflelo_epi16(a, SHUFFLE_0003);
							case SHUFFLE_0010: return Sse2.shufflelo_epi16(a, SHUFFLE_0010);
							case SHUFFLE_0011: return Sse2.shufflelo_epi16(a, SHUFFLE_0011);
							case SHUFFLE_0012: return Sse2.shufflelo_epi16(a, SHUFFLE_0012);
							case SHUFFLE_0013: return Sse2.shufflelo_epi16(a, SHUFFLE_0013);
							case SHUFFLE_0020: return Sse2.shufflelo_epi16(a, SHUFFLE_0020);
							case SHUFFLE_0021: return Sse2.shufflelo_epi16(a, SHUFFLE_0021);
							case SHUFFLE_0022: return Sse2.shufflelo_epi16(a, SHUFFLE_0022);
							case SHUFFLE_0023: return Sse2.shufflelo_epi16(a, SHUFFLE_0023);
							case SHUFFLE_0030: return Sse2.shufflelo_epi16(a, SHUFFLE_0030);
							case SHUFFLE_0031: return Sse2.shufflelo_epi16(a, SHUFFLE_0031);
							case SHUFFLE_0032: return Sse2.shufflelo_epi16(a, SHUFFLE_0032);
							case SHUFFLE_0033: return Sse2.shufflelo_epi16(a, SHUFFLE_0033);
							case SHUFFLE_0100: return Sse2.shufflelo_epi16(a, SHUFFLE_0100);
							case SHUFFLE_0101: return Sse2.shufflelo_epi16(a, SHUFFLE_0101);
							case SHUFFLE_0102: return Sse2.shufflelo_epi16(a, SHUFFLE_0102);
							case SHUFFLE_0103: return Sse2.shufflelo_epi16(a, SHUFFLE_0103);
							case SHUFFLE_0110: return Sse2.shufflelo_epi16(a, SHUFFLE_0110);
							case SHUFFLE_0111: return Sse2.shufflelo_epi16(a, SHUFFLE_0111);
							case SHUFFLE_0112: return Sse2.shufflelo_epi16(a, SHUFFLE_0112);
							case SHUFFLE_0113: return Sse2.shufflelo_epi16(a, SHUFFLE_0113);
							case SHUFFLE_0120: return Sse2.shufflelo_epi16(a, SHUFFLE_0120);
							case SHUFFLE_0121: return Sse2.shufflelo_epi16(a, SHUFFLE_0121);
							case SHUFFLE_0122: return Sse2.shufflelo_epi16(a, SHUFFLE_0122);
							case SHUFFLE_0123: return Sse2.shufflelo_epi16(a, SHUFFLE_0123);
							case SHUFFLE_0130: return Sse2.shufflelo_epi16(a, SHUFFLE_0130);
							case SHUFFLE_0131: return Sse2.shufflelo_epi16(a, SHUFFLE_0131);
							case SHUFFLE_0132: return Sse2.shufflelo_epi16(a, SHUFFLE_0132);
							case SHUFFLE_0133: return Sse2.shufflelo_epi16(a, SHUFFLE_0133);
							case SHUFFLE_0200: return Sse2.shufflelo_epi16(a, SHUFFLE_0200);
							case SHUFFLE_0201: return Sse2.shufflelo_epi16(a, SHUFFLE_0201);
							case SHUFFLE_0202: return Sse2.shufflelo_epi16(a, SHUFFLE_0202);
							case SHUFFLE_0203: return Sse2.shufflelo_epi16(a, SHUFFLE_0203);
							case SHUFFLE_0210: return Sse2.shufflelo_epi16(a, SHUFFLE_0210);
							case SHUFFLE_0211: return Sse2.shufflelo_epi16(a, SHUFFLE_0211);
							case SHUFFLE_0212: return Sse2.shufflelo_epi16(a, SHUFFLE_0212);
							case SHUFFLE_0213: return Sse2.shufflelo_epi16(a, SHUFFLE_0213);
							case SHUFFLE_0220: return Sse2.shufflelo_epi16(a, SHUFFLE_0220);
							case SHUFFLE_0221: return Sse2.shufflelo_epi16(a, SHUFFLE_0221);
							case SHUFFLE_0222: return Sse2.shufflelo_epi16(a, SHUFFLE_0222);
							case SHUFFLE_0223: return Sse2.shufflelo_epi16(a, SHUFFLE_0223);
							case SHUFFLE_0230: return Sse2.shufflelo_epi16(a, SHUFFLE_0230);
							case SHUFFLE_0231: return Sse2.shufflelo_epi16(a, SHUFFLE_0231);
							case SHUFFLE_0232: return Sse2.shufflelo_epi16(a, SHUFFLE_0232);
							case SHUFFLE_0233: return Sse2.shufflelo_epi16(a, SHUFFLE_0233);
							case SHUFFLE_0300: return Sse2.shufflelo_epi16(a, SHUFFLE_0300);
							case SHUFFLE_0301: return Sse2.shufflelo_epi16(a, SHUFFLE_0301);
							case SHUFFLE_0302: return Sse2.shufflelo_epi16(a, SHUFFLE_0302);
							case SHUFFLE_0303: return Sse2.shufflelo_epi16(a, SHUFFLE_0303);
							case SHUFFLE_0310: return Sse2.shufflelo_epi16(a, SHUFFLE_0310);
							case SHUFFLE_0311: return Sse2.shufflelo_epi16(a, SHUFFLE_0311);
							case SHUFFLE_0312: return Sse2.shufflelo_epi16(a, SHUFFLE_0312);
							case SHUFFLE_0313: return Sse2.shufflelo_epi16(a, SHUFFLE_0313);
							case SHUFFLE_0320: return Sse2.shufflelo_epi16(a, SHUFFLE_0320);
							case SHUFFLE_0321: return Sse2.shufflelo_epi16(a, SHUFFLE_0321);
							case SHUFFLE_0322: return Sse2.shufflelo_epi16(a, SHUFFLE_0322);
							case SHUFFLE_0323: return Sse2.shufflelo_epi16(a, SHUFFLE_0323);
							case SHUFFLE_0330: return Sse2.shufflelo_epi16(a, SHUFFLE_0330);
							case SHUFFLE_0331: return Sse2.shufflelo_epi16(a, SHUFFLE_0331);
							case SHUFFLE_0332: return Sse2.shufflelo_epi16(a, SHUFFLE_0332);
							case SHUFFLE_0333: return Sse2.shufflelo_epi16(a, SHUFFLE_0333);
							case SHUFFLE_1000: return Sse2.shufflelo_epi16(a, SHUFFLE_1000);
							case SHUFFLE_1001: return Sse2.shufflelo_epi16(a, SHUFFLE_1001);
							case SHUFFLE_1002: return Sse2.shufflelo_epi16(a, SHUFFLE_1002);
							case SHUFFLE_1003: return Sse2.shufflelo_epi16(a, SHUFFLE_1003);
							case SHUFFLE_1010: return Sse2.shufflelo_epi16(a, SHUFFLE_1010);
							case SHUFFLE_1011: return Sse2.shufflelo_epi16(a, SHUFFLE_1011);
							case SHUFFLE_1012: return Sse2.shufflelo_epi16(a, SHUFFLE_1012);
							case SHUFFLE_1013: return Sse2.shufflelo_epi16(a, SHUFFLE_1013);
							case SHUFFLE_1020: return Sse2.shufflelo_epi16(a, SHUFFLE_1020);
							case SHUFFLE_1021: return Sse2.shufflelo_epi16(a, SHUFFLE_1021);
							case SHUFFLE_1022: return Sse2.shufflelo_epi16(a, SHUFFLE_1022);
							case SHUFFLE_1023: return Sse2.shufflelo_epi16(a, SHUFFLE_1023);
							case SHUFFLE_1030: return Sse2.shufflelo_epi16(a, SHUFFLE_1030);
							case SHUFFLE_1031: return Sse2.shufflelo_epi16(a, SHUFFLE_1031);
							case SHUFFLE_1032: return Sse2.shufflelo_epi16(a, SHUFFLE_1032);
							case SHUFFLE_1033: return Sse2.shufflelo_epi16(a, SHUFFLE_1033);
							case SHUFFLE_1100: return Sse2.shufflelo_epi16(a, SHUFFLE_1100);
							case SHUFFLE_1101: return Sse2.shufflelo_epi16(a, SHUFFLE_1101);
							case SHUFFLE_1102: return Sse2.shufflelo_epi16(a, SHUFFLE_1102);
							case SHUFFLE_1103: return Sse2.shufflelo_epi16(a, SHUFFLE_1103);
							case SHUFFLE_1110: return Sse2.shufflelo_epi16(a, SHUFFLE_1110);
							case SHUFFLE_1111: return Sse2.shufflelo_epi16(a, SHUFFLE_1111);
							case SHUFFLE_1112: return Sse2.shufflelo_epi16(a, SHUFFLE_1112);
							case SHUFFLE_1113: return Sse2.shufflelo_epi16(a, SHUFFLE_1113);
							case SHUFFLE_1120: return Sse2.shufflelo_epi16(a, SHUFFLE_1120);
							case SHUFFLE_1121: return Sse2.shufflelo_epi16(a, SHUFFLE_1121);
							case SHUFFLE_1122: return Sse2.shufflelo_epi16(a, SHUFFLE_1122);
							case SHUFFLE_1123: return Sse2.shufflelo_epi16(a, SHUFFLE_1123);
							case SHUFFLE_1130: return Sse2.shufflelo_epi16(a, SHUFFLE_1130);
							case SHUFFLE_1131: return Sse2.shufflelo_epi16(a, SHUFFLE_1131);
							case SHUFFLE_1132: return Sse2.shufflelo_epi16(a, SHUFFLE_1132);
							case SHUFFLE_1133: return Sse2.shufflelo_epi16(a, SHUFFLE_1133);
							case SHUFFLE_1200: return Sse2.shufflelo_epi16(a, SHUFFLE_1200);
							case SHUFFLE_1201: return Sse2.shufflelo_epi16(a, SHUFFLE_1201);
							case SHUFFLE_1202: return Sse2.shufflelo_epi16(a, SHUFFLE_1202);
							case SHUFFLE_1203: return Sse2.shufflelo_epi16(a, SHUFFLE_1203);
							case SHUFFLE_1210: return Sse2.shufflelo_epi16(a, SHUFFLE_1210);
							case SHUFFLE_1211: return Sse2.shufflelo_epi16(a, SHUFFLE_1211);
							case SHUFFLE_1212: return Sse2.shufflelo_epi16(a, SHUFFLE_1212);
							case SHUFFLE_1213: return Sse2.shufflelo_epi16(a, SHUFFLE_1213);
							case SHUFFLE_1220: return Sse2.shufflelo_epi16(a, SHUFFLE_1220);
							case SHUFFLE_1221: return Sse2.shufflelo_epi16(a, SHUFFLE_1221);
							case SHUFFLE_1222: return Sse2.shufflelo_epi16(a, SHUFFLE_1222);
							case SHUFFLE_1223: return Sse2.shufflelo_epi16(a, SHUFFLE_1223);
							case SHUFFLE_1230: return Sse2.shufflelo_epi16(a, SHUFFLE_1230);
							case SHUFFLE_1231: return Sse2.shufflelo_epi16(a, SHUFFLE_1231);
							case SHUFFLE_1232: return Sse2.shufflelo_epi16(a, SHUFFLE_1232);
							case SHUFFLE_1233: return Sse2.shufflelo_epi16(a, SHUFFLE_1233);
							case SHUFFLE_1300: return Sse2.shufflelo_epi16(a, SHUFFLE_1300);
							case SHUFFLE_1301: return Sse2.shufflelo_epi16(a, SHUFFLE_1301);
							case SHUFFLE_1302: return Sse2.shufflelo_epi16(a, SHUFFLE_1302);
							case SHUFFLE_1303: return Sse2.shufflelo_epi16(a, SHUFFLE_1303);
							case SHUFFLE_1310: return Sse2.shufflelo_epi16(a, SHUFFLE_1310);
							case SHUFFLE_1311: return Sse2.shufflelo_epi16(a, SHUFFLE_1311);
							case SHUFFLE_1312: return Sse2.shufflelo_epi16(a, SHUFFLE_1312);
							case SHUFFLE_1313: return Sse2.shufflelo_epi16(a, SHUFFLE_1313);
							case SHUFFLE_1320: return Sse2.shufflelo_epi16(a, SHUFFLE_1320);
							case SHUFFLE_1321: return Sse2.shufflelo_epi16(a, SHUFFLE_1321);
							case SHUFFLE_1322: return Sse2.shufflelo_epi16(a, SHUFFLE_1322);
							case SHUFFLE_1323: return Sse2.shufflelo_epi16(a, SHUFFLE_1323);
							case SHUFFLE_1330: return Sse2.shufflelo_epi16(a, SHUFFLE_1330);
							case SHUFFLE_1331: return Sse2.shufflelo_epi16(a, SHUFFLE_1331);
							case SHUFFLE_1332: return Sse2.shufflelo_epi16(a, SHUFFLE_1332);
							case SHUFFLE_1333: return Sse2.shufflelo_epi16(a, SHUFFLE_1333);
							case SHUFFLE_2000: return Sse2.shufflelo_epi16(a, SHUFFLE_2000);
							case SHUFFLE_2001: return Sse2.shufflelo_epi16(a, SHUFFLE_2001);
							case SHUFFLE_2002: return Sse2.shufflelo_epi16(a, SHUFFLE_2002);
							case SHUFFLE_2003: return Sse2.shufflelo_epi16(a, SHUFFLE_2003);
							case SHUFFLE_2010: return Sse2.shufflelo_epi16(a, SHUFFLE_2010);
							case SHUFFLE_2011: return Sse2.shufflelo_epi16(a, SHUFFLE_2011);
							case SHUFFLE_2012: return Sse2.shufflelo_epi16(a, SHUFFLE_2012);
							case SHUFFLE_2013: return Sse2.shufflelo_epi16(a, SHUFFLE_2013);
							case SHUFFLE_2020: return Sse2.shufflelo_epi16(a, SHUFFLE_2020);
							case SHUFFLE_2021: return Sse2.shufflelo_epi16(a, SHUFFLE_2021);
							case SHUFFLE_2022: return Sse2.shufflelo_epi16(a, SHUFFLE_2022);
							case SHUFFLE_2023: return Sse2.shufflelo_epi16(a, SHUFFLE_2023);
							case SHUFFLE_2030: return Sse2.shufflelo_epi16(a, SHUFFLE_2030);
							case SHUFFLE_2031: return Sse2.shufflelo_epi16(a, SHUFFLE_2031);
							case SHUFFLE_2032: return Sse2.shufflelo_epi16(a, SHUFFLE_2032);
							case SHUFFLE_2033: return Sse2.shufflelo_epi16(a, SHUFFLE_2033);
							case SHUFFLE_2100: return Sse2.shufflelo_epi16(a, SHUFFLE_2100);
							case SHUFFLE_2101: return Sse2.shufflelo_epi16(a, SHUFFLE_2101);
							case SHUFFLE_2102: return Sse2.shufflelo_epi16(a, SHUFFLE_2102);
							case SHUFFLE_2103: return Sse2.shufflelo_epi16(a, SHUFFLE_2103);
							case SHUFFLE_2110: return Sse2.shufflelo_epi16(a, SHUFFLE_2110);
							case SHUFFLE_2111: return Sse2.shufflelo_epi16(a, SHUFFLE_2111);
							case SHUFFLE_2112: return Sse2.shufflelo_epi16(a, SHUFFLE_2112);
							case SHUFFLE_2113: return Sse2.shufflelo_epi16(a, SHUFFLE_2113);
							case SHUFFLE_2120: return Sse2.shufflelo_epi16(a, SHUFFLE_2120);
							case SHUFFLE_2121: return Sse2.shufflelo_epi16(a, SHUFFLE_2121);
							case SHUFFLE_2122: return Sse2.shufflelo_epi16(a, SHUFFLE_2122);
							case SHUFFLE_2123: return Sse2.shufflelo_epi16(a, SHUFFLE_2123);
							case SHUFFLE_2130: return Sse2.shufflelo_epi16(a, SHUFFLE_2130);
							case SHUFFLE_2131: return Sse2.shufflelo_epi16(a, SHUFFLE_2131);
							case SHUFFLE_2132: return Sse2.shufflelo_epi16(a, SHUFFLE_2132);
							case SHUFFLE_2133: return Sse2.shufflelo_epi16(a, SHUFFLE_2133);
							case SHUFFLE_2200: return Sse2.shufflelo_epi16(a, SHUFFLE_2200);
							case SHUFFLE_2201: return Sse2.shufflelo_epi16(a, SHUFFLE_2201);
							case SHUFFLE_2202: return Sse2.shufflelo_epi16(a, SHUFFLE_2202);
							case SHUFFLE_2203: return Sse2.shufflelo_epi16(a, SHUFFLE_2203);
							case SHUFFLE_2210: return Sse2.shufflelo_epi16(a, SHUFFLE_2210);
							case SHUFFLE_2211: return Sse2.shufflelo_epi16(a, SHUFFLE_2211);
							case SHUFFLE_2212: return Sse2.shufflelo_epi16(a, SHUFFLE_2212);
							case SHUFFLE_2213: return Sse2.shufflelo_epi16(a, SHUFFLE_2213);
							case SHUFFLE_2220: return Sse2.shufflelo_epi16(a, SHUFFLE_2220);
							case SHUFFLE_2221: return Sse2.shufflelo_epi16(a, SHUFFLE_2221);
							case SHUFFLE_2222: return Sse2.shufflelo_epi16(a, SHUFFLE_2222);
							case SHUFFLE_2223: return Sse2.shufflelo_epi16(a, SHUFFLE_2223);
							case SHUFFLE_2230: return Sse2.shufflelo_epi16(a, SHUFFLE_2230);
							case SHUFFLE_2231: return Sse2.shufflelo_epi16(a, SHUFFLE_2231);
							case SHUFFLE_2232: return Sse2.shufflelo_epi16(a, SHUFFLE_2232);
							case SHUFFLE_2233: return Sse2.shufflelo_epi16(a, SHUFFLE_2233);
							case SHUFFLE_2300: return Sse2.shufflelo_epi16(a, SHUFFLE_2300);
							case SHUFFLE_2301: return Sse2.shufflelo_epi16(a, SHUFFLE_2301);
							case SHUFFLE_2302: return Sse2.shufflelo_epi16(a, SHUFFLE_2302);
							case SHUFFLE_2303: return Sse2.shufflelo_epi16(a, SHUFFLE_2303);
							case SHUFFLE_2310: return Sse2.shufflelo_epi16(a, SHUFFLE_2310);
							case SHUFFLE_2311: return Sse2.shufflelo_epi16(a, SHUFFLE_2311);
							case SHUFFLE_2312: return Sse2.shufflelo_epi16(a, SHUFFLE_2312);
							case SHUFFLE_2313: return Sse2.shufflelo_epi16(a, SHUFFLE_2313);
							case SHUFFLE_2320: return Sse2.shufflelo_epi16(a, SHUFFLE_2320);
							case SHUFFLE_2321: return Sse2.shufflelo_epi16(a, SHUFFLE_2321);
							case SHUFFLE_2322: return Sse2.shufflelo_epi16(a, SHUFFLE_2322);
							case SHUFFLE_2323: return Sse2.shufflelo_epi16(a, SHUFFLE_2323);
							case SHUFFLE_2330: return Sse2.shufflelo_epi16(a, SHUFFLE_2330);
							case SHUFFLE_2331: return Sse2.shufflelo_epi16(a, SHUFFLE_2331);
							case SHUFFLE_2332: return Sse2.shufflelo_epi16(a, SHUFFLE_2332);
							case SHUFFLE_2333: return Sse2.shufflelo_epi16(a, SHUFFLE_2333);
							case SHUFFLE_3000: return Sse2.shufflelo_epi16(a, SHUFFLE_3000);
							case SHUFFLE_3001: return Sse2.shufflelo_epi16(a, SHUFFLE_3001);
							case SHUFFLE_3002: return Sse2.shufflelo_epi16(a, SHUFFLE_3002);
							case SHUFFLE_3003: return Sse2.shufflelo_epi16(a, SHUFFLE_3003);
							case SHUFFLE_3010: return Sse2.shufflelo_epi16(a, SHUFFLE_3010);
							case SHUFFLE_3011: return Sse2.shufflelo_epi16(a, SHUFFLE_3011);
							case SHUFFLE_3012: return Sse2.shufflelo_epi16(a, SHUFFLE_3012);
							case SHUFFLE_3013: return Sse2.shufflelo_epi16(a, SHUFFLE_3013);
							case SHUFFLE_3020: return Sse2.shufflelo_epi16(a, SHUFFLE_3020);
							case SHUFFLE_3021: return Sse2.shufflelo_epi16(a, SHUFFLE_3021);
							case SHUFFLE_3022: return Sse2.shufflelo_epi16(a, SHUFFLE_3022);
							case SHUFFLE_3023: return Sse2.shufflelo_epi16(a, SHUFFLE_3023);
							case SHUFFLE_3030: return Sse2.shufflelo_epi16(a, SHUFFLE_3030);
							case SHUFFLE_3031: return Sse2.shufflelo_epi16(a, SHUFFLE_3031);
							case SHUFFLE_3032: return Sse2.shufflelo_epi16(a, SHUFFLE_3032);
							case SHUFFLE_3033: return Sse2.shufflelo_epi16(a, SHUFFLE_3033);
							case SHUFFLE_3100: return Sse2.shufflelo_epi16(a, SHUFFLE_3100);
							case SHUFFLE_3101: return Sse2.shufflelo_epi16(a, SHUFFLE_3101);
							case SHUFFLE_3102: return Sse2.shufflelo_epi16(a, SHUFFLE_3102);
							case SHUFFLE_3103: return Sse2.shufflelo_epi16(a, SHUFFLE_3103);
							case SHUFFLE_3110: return Sse2.shufflelo_epi16(a, SHUFFLE_3110);
							case SHUFFLE_3111: return Sse2.shufflelo_epi16(a, SHUFFLE_3111);
							case SHUFFLE_3112: return Sse2.shufflelo_epi16(a, SHUFFLE_3112);
							case SHUFFLE_3113: return Sse2.shufflelo_epi16(a, SHUFFLE_3113);
							case SHUFFLE_3120: return Sse2.shufflelo_epi16(a, SHUFFLE_3120);
							case SHUFFLE_3121: return Sse2.shufflelo_epi16(a, SHUFFLE_3121);
							case SHUFFLE_3122: return Sse2.shufflelo_epi16(a, SHUFFLE_3122);
							case SHUFFLE_3123: return Sse2.shufflelo_epi16(a, SHUFFLE_3123);
							case SHUFFLE_3130: return Sse2.shufflelo_epi16(a, SHUFFLE_3130);
							case SHUFFLE_3131: return Sse2.shufflelo_epi16(a, SHUFFLE_3131);
							case SHUFFLE_3132: return Sse2.shufflelo_epi16(a, SHUFFLE_3132);
							case SHUFFLE_3133: return Sse2.shufflelo_epi16(a, SHUFFLE_3133);
							case SHUFFLE_3200: return Sse2.shufflelo_epi16(a, SHUFFLE_3200);
							case SHUFFLE_3201: return Sse2.shufflelo_epi16(a, SHUFFLE_3201);
							case SHUFFLE_3202: return Sse2.shufflelo_epi16(a, SHUFFLE_3202);
							case SHUFFLE_3203: return Sse2.shufflelo_epi16(a, SHUFFLE_3203);
							case SHUFFLE_3210: return Sse2.shufflelo_epi16(a, SHUFFLE_3210);
							case SHUFFLE_3211: return Sse2.shufflelo_epi16(a, SHUFFLE_3211);
							case SHUFFLE_3212: return Sse2.shufflelo_epi16(a, SHUFFLE_3212);
							case SHUFFLE_3213: return Sse2.shufflelo_epi16(a, SHUFFLE_3213);
							case SHUFFLE_3220: return Sse2.shufflelo_epi16(a, SHUFFLE_3220);
							case SHUFFLE_3221: return Sse2.shufflelo_epi16(a, SHUFFLE_3221);
							case SHUFFLE_3222: return Sse2.shufflelo_epi16(a, SHUFFLE_3222);
							case SHUFFLE_3223: return Sse2.shufflelo_epi16(a, SHUFFLE_3223);
							case SHUFFLE_3230: return Sse2.shufflelo_epi16(a, SHUFFLE_3230);
							case SHUFFLE_3231: return Sse2.shufflelo_epi16(a, SHUFFLE_3231);
							case SHUFFLE_3232: return Sse2.shufflelo_epi16(a, SHUFFLE_3232);
							case SHUFFLE_3233: return Sse2.shufflelo_epi16(a, SHUFFLE_3233);
							case SHUFFLE_3300: return Sse2.shufflelo_epi16(a, SHUFFLE_3300);
							case SHUFFLE_3301: return Sse2.shufflelo_epi16(a, SHUFFLE_3301);
							case SHUFFLE_3302: return Sse2.shufflelo_epi16(a, SHUFFLE_3302);
							case SHUFFLE_3303: return Sse2.shufflelo_epi16(a, SHUFFLE_3303);
							case SHUFFLE_3310: return Sse2.shufflelo_epi16(a, SHUFFLE_3310);
							case SHUFFLE_3311: return Sse2.shufflelo_epi16(a, SHUFFLE_3311);
							case SHUFFLE_3312: return Sse2.shufflelo_epi16(a, SHUFFLE_3312);
							case SHUFFLE_3313: return Sse2.shufflelo_epi16(a, SHUFFLE_3313);
							case SHUFFLE_3320: return Sse2.shufflelo_epi16(a, SHUFFLE_3320);
							case SHUFFLE_3321: return Sse2.shufflelo_epi16(a, SHUFFLE_3321);
							case SHUFFLE_3322: return Sse2.shufflelo_epi16(a, SHUFFLE_3322);
							case SHUFFLE_3323: return Sse2.shufflelo_epi16(a, SHUFFLE_3323);
							case SHUFFLE_3330: return Sse2.shufflelo_epi16(a, SHUFFLE_3330);
							case SHUFFLE_3331: return Sse2.shufflelo_epi16(a, SHUFFLE_3331);
							case SHUFFLE_3332: return Sse2.shufflelo_epi16(a, SHUFFLE_3332);
							case SHUFFLE_3333: return Sse2.shufflelo_epi16(a, SHUFFLE_3333);
							default: return a;
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public static v128 shuffle_pd(v128 a, v128 b, int imm8)
				{
					if (Sse2.IsSse2Supported)
					{
						switch (imm8)
						{
							case SHUFFLE_0000: return Sse2.shuffle_pd(a, b, SHUFFLE_0000);
							case SHUFFLE_0001: return Sse2.shuffle_pd(a, b, SHUFFLE_0001);
							case SHUFFLE_0002: return Sse2.shuffle_pd(a, b, SHUFFLE_0002);
							case SHUFFLE_0003: return Sse2.shuffle_pd(a, b, SHUFFLE_0003);
							case SHUFFLE_0010: return Sse2.shuffle_pd(a, b, SHUFFLE_0010);
							case SHUFFLE_0011: return Sse2.shuffle_pd(a, b, SHUFFLE_0011);
							case SHUFFLE_0012: return Sse2.shuffle_pd(a, b, SHUFFLE_0012);
							case SHUFFLE_0013: return Sse2.shuffle_pd(a, b, SHUFFLE_0013);
							case SHUFFLE_0020: return Sse2.shuffle_pd(a, b, SHUFFLE_0020);
							case SHUFFLE_0021: return Sse2.shuffle_pd(a, b, SHUFFLE_0021);
							case SHUFFLE_0022: return Sse2.shuffle_pd(a, b, SHUFFLE_0022);
							case SHUFFLE_0023: return Sse2.shuffle_pd(a, b, SHUFFLE_0023);
							case SHUFFLE_0030: return Sse2.shuffle_pd(a, b, SHUFFLE_0030);
							case SHUFFLE_0031: return Sse2.shuffle_pd(a, b, SHUFFLE_0031);
							case SHUFFLE_0032: return Sse2.shuffle_pd(a, b, SHUFFLE_0032);
							case SHUFFLE_0033: return Sse2.shuffle_pd(a, b, SHUFFLE_0033);
							case SHUFFLE_0100: return Sse2.shuffle_pd(a, b, SHUFFLE_0100);
							case SHUFFLE_0101: return Sse2.shuffle_pd(a, b, SHUFFLE_0101);
							case SHUFFLE_0102: return Sse2.shuffle_pd(a, b, SHUFFLE_0102);
							case SHUFFLE_0103: return Sse2.shuffle_pd(a, b, SHUFFLE_0103);
							case SHUFFLE_0110: return Sse2.shuffle_pd(a, b, SHUFFLE_0110);
							case SHUFFLE_0111: return Sse2.shuffle_pd(a, b, SHUFFLE_0111);
							case SHUFFLE_0112: return Sse2.shuffle_pd(a, b, SHUFFLE_0112);
							case SHUFFLE_0113: return Sse2.shuffle_pd(a, b, SHUFFLE_0113);
							case SHUFFLE_0120: return Sse2.shuffle_pd(a, b, SHUFFLE_0120);
							case SHUFFLE_0121: return Sse2.shuffle_pd(a, b, SHUFFLE_0121);
							case SHUFFLE_0122: return Sse2.shuffle_pd(a, b, SHUFFLE_0122);
							case SHUFFLE_0123: return Sse2.shuffle_pd(a, b, SHUFFLE_0123);
							case SHUFFLE_0130: return Sse2.shuffle_pd(a, b, SHUFFLE_0130);
							case SHUFFLE_0131: return Sse2.shuffle_pd(a, b, SHUFFLE_0131);
							case SHUFFLE_0132: return Sse2.shuffle_pd(a, b, SHUFFLE_0132);
							case SHUFFLE_0133: return Sse2.shuffle_pd(a, b, SHUFFLE_0133);
							case SHUFFLE_0200: return Sse2.shuffle_pd(a, b, SHUFFLE_0200);
							case SHUFFLE_0201: return Sse2.shuffle_pd(a, b, SHUFFLE_0201);
							case SHUFFLE_0202: return Sse2.shuffle_pd(a, b, SHUFFLE_0202);
							case SHUFFLE_0203: return Sse2.shuffle_pd(a, b, SHUFFLE_0203);
							case SHUFFLE_0210: return Sse2.shuffle_pd(a, b, SHUFFLE_0210);
							case SHUFFLE_0211: return Sse2.shuffle_pd(a, b, SHUFFLE_0211);
							case SHUFFLE_0212: return Sse2.shuffle_pd(a, b, SHUFFLE_0212);
							case SHUFFLE_0213: return Sse2.shuffle_pd(a, b, SHUFFLE_0213);
							case SHUFFLE_0220: return Sse2.shuffle_pd(a, b, SHUFFLE_0220);
							case SHUFFLE_0221: return Sse2.shuffle_pd(a, b, SHUFFLE_0221);
							case SHUFFLE_0222: return Sse2.shuffle_pd(a, b, SHUFFLE_0222);
							case SHUFFLE_0223: return Sse2.shuffle_pd(a, b, SHUFFLE_0223);
							case SHUFFLE_0230: return Sse2.shuffle_pd(a, b, SHUFFLE_0230);
							case SHUFFLE_0231: return Sse2.shuffle_pd(a, b, SHUFFLE_0231);
							case SHUFFLE_0232: return Sse2.shuffle_pd(a, b, SHUFFLE_0232);
							case SHUFFLE_0233: return Sse2.shuffle_pd(a, b, SHUFFLE_0233);
							case SHUFFLE_0300: return Sse2.shuffle_pd(a, b, SHUFFLE_0300);
							case SHUFFLE_0301: return Sse2.shuffle_pd(a, b, SHUFFLE_0301);
							case SHUFFLE_0302: return Sse2.shuffle_pd(a, b, SHUFFLE_0302);
							case SHUFFLE_0303: return Sse2.shuffle_pd(a, b, SHUFFLE_0303);
							case SHUFFLE_0310: return Sse2.shuffle_pd(a, b, SHUFFLE_0310);
							case SHUFFLE_0311: return Sse2.shuffle_pd(a, b, SHUFFLE_0311);
							case SHUFFLE_0312: return Sse2.shuffle_pd(a, b, SHUFFLE_0312);
							case SHUFFLE_0313: return Sse2.shuffle_pd(a, b, SHUFFLE_0313);
							case SHUFFLE_0320: return Sse2.shuffle_pd(a, b, SHUFFLE_0320);
							case SHUFFLE_0321: return Sse2.shuffle_pd(a, b, SHUFFLE_0321);
							case SHUFFLE_0322: return Sse2.shuffle_pd(a, b, SHUFFLE_0322);
							case SHUFFLE_0323: return Sse2.shuffle_pd(a, b, SHUFFLE_0323);
							case SHUFFLE_0330: return Sse2.shuffle_pd(a, b, SHUFFLE_0330);
							case SHUFFLE_0331: return Sse2.shuffle_pd(a, b, SHUFFLE_0331);
							case SHUFFLE_0332: return Sse2.shuffle_pd(a, b, SHUFFLE_0332);
							case SHUFFLE_0333: return Sse2.shuffle_pd(a, b, SHUFFLE_0333);
							case SHUFFLE_1000: return Sse2.shuffle_pd(a, b, SHUFFLE_1000);
							case SHUFFLE_1001: return Sse2.shuffle_pd(a, b, SHUFFLE_1001);
							case SHUFFLE_1002: return Sse2.shuffle_pd(a, b, SHUFFLE_1002);
							case SHUFFLE_1003: return Sse2.shuffle_pd(a, b, SHUFFLE_1003);
							case SHUFFLE_1010: return Sse2.shuffle_pd(a, b, SHUFFLE_1010);
							case SHUFFLE_1011: return Sse2.shuffle_pd(a, b, SHUFFLE_1011);
							case SHUFFLE_1012: return Sse2.shuffle_pd(a, b, SHUFFLE_1012);
							case SHUFFLE_1013: return Sse2.shuffle_pd(a, b, SHUFFLE_1013);
							case SHUFFLE_1020: return Sse2.shuffle_pd(a, b, SHUFFLE_1020);
							case SHUFFLE_1021: return Sse2.shuffle_pd(a, b, SHUFFLE_1021);
							case SHUFFLE_1022: return Sse2.shuffle_pd(a, b, SHUFFLE_1022);
							case SHUFFLE_1023: return Sse2.shuffle_pd(a, b, SHUFFLE_1023);
							case SHUFFLE_1030: return Sse2.shuffle_pd(a, b, SHUFFLE_1030);
							case SHUFFLE_1031: return Sse2.shuffle_pd(a, b, SHUFFLE_1031);
							case SHUFFLE_1032: return Sse2.shuffle_pd(a, b, SHUFFLE_1032);
							case SHUFFLE_1033: return Sse2.shuffle_pd(a, b, SHUFFLE_1033);
							case SHUFFLE_1100: return Sse2.shuffle_pd(a, b, SHUFFLE_1100);
							case SHUFFLE_1101: return Sse2.shuffle_pd(a, b, SHUFFLE_1101);
							case SHUFFLE_1102: return Sse2.shuffle_pd(a, b, SHUFFLE_1102);
							case SHUFFLE_1103: return Sse2.shuffle_pd(a, b, SHUFFLE_1103);
							case SHUFFLE_1110: return Sse2.shuffle_pd(a, b, SHUFFLE_1110);
							case SHUFFLE_1111: return Sse2.shuffle_pd(a, b, SHUFFLE_1111);
							case SHUFFLE_1112: return Sse2.shuffle_pd(a, b, SHUFFLE_1112);
							case SHUFFLE_1113: return Sse2.shuffle_pd(a, b, SHUFFLE_1113);
							case SHUFFLE_1120: return Sse2.shuffle_pd(a, b, SHUFFLE_1120);
							case SHUFFLE_1121: return Sse2.shuffle_pd(a, b, SHUFFLE_1121);
							case SHUFFLE_1122: return Sse2.shuffle_pd(a, b, SHUFFLE_1122);
							case SHUFFLE_1123: return Sse2.shuffle_pd(a, b, SHUFFLE_1123);
							case SHUFFLE_1130: return Sse2.shuffle_pd(a, b, SHUFFLE_1130);
							case SHUFFLE_1131: return Sse2.shuffle_pd(a, b, SHUFFLE_1131);
							case SHUFFLE_1132: return Sse2.shuffle_pd(a, b, SHUFFLE_1132);
							case SHUFFLE_1133: return Sse2.shuffle_pd(a, b, SHUFFLE_1133);
							case SHUFFLE_1200: return Sse2.shuffle_pd(a, b, SHUFFLE_1200);
							case SHUFFLE_1201: return Sse2.shuffle_pd(a, b, SHUFFLE_1201);
							case SHUFFLE_1202: return Sse2.shuffle_pd(a, b, SHUFFLE_1202);
							case SHUFFLE_1203: return Sse2.shuffle_pd(a, b, SHUFFLE_1203);
							case SHUFFLE_1210: return Sse2.shuffle_pd(a, b, SHUFFLE_1210);
							case SHUFFLE_1211: return Sse2.shuffle_pd(a, b, SHUFFLE_1211);
							case SHUFFLE_1212: return Sse2.shuffle_pd(a, b, SHUFFLE_1212);
							case SHUFFLE_1213: return Sse2.shuffle_pd(a, b, SHUFFLE_1213);
							case SHUFFLE_1220: return Sse2.shuffle_pd(a, b, SHUFFLE_1220);
							case SHUFFLE_1221: return Sse2.shuffle_pd(a, b, SHUFFLE_1221);
							case SHUFFLE_1222: return Sse2.shuffle_pd(a, b, SHUFFLE_1222);
							case SHUFFLE_1223: return Sse2.shuffle_pd(a, b, SHUFFLE_1223);
							case SHUFFLE_1230: return Sse2.shuffle_pd(a, b, SHUFFLE_1230);
							case SHUFFLE_1231: return Sse2.shuffle_pd(a, b, SHUFFLE_1231);
							case SHUFFLE_1232: return Sse2.shuffle_pd(a, b, SHUFFLE_1232);
							case SHUFFLE_1233: return Sse2.shuffle_pd(a, b, SHUFFLE_1233);
							case SHUFFLE_1300: return Sse2.shuffle_pd(a, b, SHUFFLE_1300);
							case SHUFFLE_1301: return Sse2.shuffle_pd(a, b, SHUFFLE_1301);
							case SHUFFLE_1302: return Sse2.shuffle_pd(a, b, SHUFFLE_1302);
							case SHUFFLE_1303: return Sse2.shuffle_pd(a, b, SHUFFLE_1303);
							case SHUFFLE_1310: return Sse2.shuffle_pd(a, b, SHUFFLE_1310);
							case SHUFFLE_1311: return Sse2.shuffle_pd(a, b, SHUFFLE_1311);
							case SHUFFLE_1312: return Sse2.shuffle_pd(a, b, SHUFFLE_1312);
							case SHUFFLE_1313: return Sse2.shuffle_pd(a, b, SHUFFLE_1313);
							case SHUFFLE_1320: return Sse2.shuffle_pd(a, b, SHUFFLE_1320);
							case SHUFFLE_1321: return Sse2.shuffle_pd(a, b, SHUFFLE_1321);
							case SHUFFLE_1322: return Sse2.shuffle_pd(a, b, SHUFFLE_1322);
							case SHUFFLE_1323: return Sse2.shuffle_pd(a, b, SHUFFLE_1323);
							case SHUFFLE_1330: return Sse2.shuffle_pd(a, b, SHUFFLE_1330);
							case SHUFFLE_1331: return Sse2.shuffle_pd(a, b, SHUFFLE_1331);
							case SHUFFLE_1332: return Sse2.shuffle_pd(a, b, SHUFFLE_1332);
							case SHUFFLE_1333: return Sse2.shuffle_pd(a, b, SHUFFLE_1333);
							case SHUFFLE_2000: return Sse2.shuffle_pd(a, b, SHUFFLE_2000);
							case SHUFFLE_2001: return Sse2.shuffle_pd(a, b, SHUFFLE_2001);
							case SHUFFLE_2002: return Sse2.shuffle_pd(a, b, SHUFFLE_2002);
							case SHUFFLE_2003: return Sse2.shuffle_pd(a, b, SHUFFLE_2003);
							case SHUFFLE_2010: return Sse2.shuffle_pd(a, b, SHUFFLE_2010);
							case SHUFFLE_2011: return Sse2.shuffle_pd(a, b, SHUFFLE_2011);
							case SHUFFLE_2012: return Sse2.shuffle_pd(a, b, SHUFFLE_2012);
							case SHUFFLE_2013: return Sse2.shuffle_pd(a, b, SHUFFLE_2013);
							case SHUFFLE_2020: return Sse2.shuffle_pd(a, b, SHUFFLE_2020);
							case SHUFFLE_2021: return Sse2.shuffle_pd(a, b, SHUFFLE_2021);
							case SHUFFLE_2022: return Sse2.shuffle_pd(a, b, SHUFFLE_2022);
							case SHUFFLE_2023: return Sse2.shuffle_pd(a, b, SHUFFLE_2023);
							case SHUFFLE_2030: return Sse2.shuffle_pd(a, b, SHUFFLE_2030);
							case SHUFFLE_2031: return Sse2.shuffle_pd(a, b, SHUFFLE_2031);
							case SHUFFLE_2032: return Sse2.shuffle_pd(a, b, SHUFFLE_2032);
							case SHUFFLE_2033: return Sse2.shuffle_pd(a, b, SHUFFLE_2033);
							case SHUFFLE_2100: return Sse2.shuffle_pd(a, b, SHUFFLE_2100);
							case SHUFFLE_2101: return Sse2.shuffle_pd(a, b, SHUFFLE_2101);
							case SHUFFLE_2102: return Sse2.shuffle_pd(a, b, SHUFFLE_2102);
							case SHUFFLE_2103: return Sse2.shuffle_pd(a, b, SHUFFLE_2103);
							case SHUFFLE_2110: return Sse2.shuffle_pd(a, b, SHUFFLE_2110);
							case SHUFFLE_2111: return Sse2.shuffle_pd(a, b, SHUFFLE_2111);
							case SHUFFLE_2112: return Sse2.shuffle_pd(a, b, SHUFFLE_2112);
							case SHUFFLE_2113: return Sse2.shuffle_pd(a, b, SHUFFLE_2113);
							case SHUFFLE_2120: return Sse2.shuffle_pd(a, b, SHUFFLE_2120);
							case SHUFFLE_2121: return Sse2.shuffle_pd(a, b, SHUFFLE_2121);
							case SHUFFLE_2122: return Sse2.shuffle_pd(a, b, SHUFFLE_2122);
							case SHUFFLE_2123: return Sse2.shuffle_pd(a, b, SHUFFLE_2123);
							case SHUFFLE_2130: return Sse2.shuffle_pd(a, b, SHUFFLE_2130);
							case SHUFFLE_2131: return Sse2.shuffle_pd(a, b, SHUFFLE_2131);
							case SHUFFLE_2132: return Sse2.shuffle_pd(a, b, SHUFFLE_2132);
							case SHUFFLE_2133: return Sse2.shuffle_pd(a, b, SHUFFLE_2133);
							case SHUFFLE_2200: return Sse2.shuffle_pd(a, b, SHUFFLE_2200);
							case SHUFFLE_2201: return Sse2.shuffle_pd(a, b, SHUFFLE_2201);
							case SHUFFLE_2202: return Sse2.shuffle_pd(a, b, SHUFFLE_2202);
							case SHUFFLE_2203: return Sse2.shuffle_pd(a, b, SHUFFLE_2203);
							case SHUFFLE_2210: return Sse2.shuffle_pd(a, b, SHUFFLE_2210);
							case SHUFFLE_2211: return Sse2.shuffle_pd(a, b, SHUFFLE_2211);
							case SHUFFLE_2212: return Sse2.shuffle_pd(a, b, SHUFFLE_2212);
							case SHUFFLE_2213: return Sse2.shuffle_pd(a, b, SHUFFLE_2213);
							case SHUFFLE_2220: return Sse2.shuffle_pd(a, b, SHUFFLE_2220);
							case SHUFFLE_2221: return Sse2.shuffle_pd(a, b, SHUFFLE_2221);
							case SHUFFLE_2222: return Sse2.shuffle_pd(a, b, SHUFFLE_2222);
							case SHUFFLE_2223: return Sse2.shuffle_pd(a, b, SHUFFLE_2223);
							case SHUFFLE_2230: return Sse2.shuffle_pd(a, b, SHUFFLE_2230);
							case SHUFFLE_2231: return Sse2.shuffle_pd(a, b, SHUFFLE_2231);
							case SHUFFLE_2232: return Sse2.shuffle_pd(a, b, SHUFFLE_2232);
							case SHUFFLE_2233: return Sse2.shuffle_pd(a, b, SHUFFLE_2233);
							case SHUFFLE_2300: return Sse2.shuffle_pd(a, b, SHUFFLE_2300);
							case SHUFFLE_2301: return Sse2.shuffle_pd(a, b, SHUFFLE_2301);
							case SHUFFLE_2302: return Sse2.shuffle_pd(a, b, SHUFFLE_2302);
							case SHUFFLE_2303: return Sse2.shuffle_pd(a, b, SHUFFLE_2303);
							case SHUFFLE_2310: return Sse2.shuffle_pd(a, b, SHUFFLE_2310);
							case SHUFFLE_2311: return Sse2.shuffle_pd(a, b, SHUFFLE_2311);
							case SHUFFLE_2312: return Sse2.shuffle_pd(a, b, SHUFFLE_2312);
							case SHUFFLE_2313: return Sse2.shuffle_pd(a, b, SHUFFLE_2313);
							case SHUFFLE_2320: return Sse2.shuffle_pd(a, b, SHUFFLE_2320);
							case SHUFFLE_2321: return Sse2.shuffle_pd(a, b, SHUFFLE_2321);
							case SHUFFLE_2322: return Sse2.shuffle_pd(a, b, SHUFFLE_2322);
							case SHUFFLE_2323: return Sse2.shuffle_pd(a, b, SHUFFLE_2323);
							case SHUFFLE_2330: return Sse2.shuffle_pd(a, b, SHUFFLE_2330);
							case SHUFFLE_2331: return Sse2.shuffle_pd(a, b, SHUFFLE_2331);
							case SHUFFLE_2332: return Sse2.shuffle_pd(a, b, SHUFFLE_2332);
							case SHUFFLE_2333: return Sse2.shuffle_pd(a, b, SHUFFLE_2333);
							case SHUFFLE_3000: return Sse2.shuffle_pd(a, b, SHUFFLE_3000);
							case SHUFFLE_3001: return Sse2.shuffle_pd(a, b, SHUFFLE_3001);
							case SHUFFLE_3002: return Sse2.shuffle_pd(a, b, SHUFFLE_3002);
							case SHUFFLE_3003: return Sse2.shuffle_pd(a, b, SHUFFLE_3003);
							case SHUFFLE_3010: return Sse2.shuffle_pd(a, b, SHUFFLE_3010);
							case SHUFFLE_3011: return Sse2.shuffle_pd(a, b, SHUFFLE_3011);
							case SHUFFLE_3012: return Sse2.shuffle_pd(a, b, SHUFFLE_3012);
							case SHUFFLE_3013: return Sse2.shuffle_pd(a, b, SHUFFLE_3013);
							case SHUFFLE_3020: return Sse2.shuffle_pd(a, b, SHUFFLE_3020);
							case SHUFFLE_3021: return Sse2.shuffle_pd(a, b, SHUFFLE_3021);
							case SHUFFLE_3022: return Sse2.shuffle_pd(a, b, SHUFFLE_3022);
							case SHUFFLE_3023: return Sse2.shuffle_pd(a, b, SHUFFLE_3023);
							case SHUFFLE_3030: return Sse2.shuffle_pd(a, b, SHUFFLE_3030);
							case SHUFFLE_3031: return Sse2.shuffle_pd(a, b, SHUFFLE_3031);
							case SHUFFLE_3032: return Sse2.shuffle_pd(a, b, SHUFFLE_3032);
							case SHUFFLE_3033: return Sse2.shuffle_pd(a, b, SHUFFLE_3033);
							case SHUFFLE_3100: return Sse2.shuffle_pd(a, b, SHUFFLE_3100);
							case SHUFFLE_3101: return Sse2.shuffle_pd(a, b, SHUFFLE_3101);
							case SHUFFLE_3102: return Sse2.shuffle_pd(a, b, SHUFFLE_3102);
							case SHUFFLE_3103: return Sse2.shuffle_pd(a, b, SHUFFLE_3103);
							case SHUFFLE_3110: return Sse2.shuffle_pd(a, b, SHUFFLE_3110);
							case SHUFFLE_3111: return Sse2.shuffle_pd(a, b, SHUFFLE_3111);
							case SHUFFLE_3112: return Sse2.shuffle_pd(a, b, SHUFFLE_3112);
							case SHUFFLE_3113: return Sse2.shuffle_pd(a, b, SHUFFLE_3113);
							case SHUFFLE_3120: return Sse2.shuffle_pd(a, b, SHUFFLE_3120);
							case SHUFFLE_3121: return Sse2.shuffle_pd(a, b, SHUFFLE_3121);
							case SHUFFLE_3122: return Sse2.shuffle_pd(a, b, SHUFFLE_3122);
							case SHUFFLE_3123: return Sse2.shuffle_pd(a, b, SHUFFLE_3123);
							case SHUFFLE_3130: return Sse2.shuffle_pd(a, b, SHUFFLE_3130);
							case SHUFFLE_3131: return Sse2.shuffle_pd(a, b, SHUFFLE_3131);
							case SHUFFLE_3132: return Sse2.shuffle_pd(a, b, SHUFFLE_3132);
							case SHUFFLE_3133: return Sse2.shuffle_pd(a, b, SHUFFLE_3133);
							case SHUFFLE_3200: return Sse2.shuffle_pd(a, b, SHUFFLE_3200);
							case SHUFFLE_3201: return Sse2.shuffle_pd(a, b, SHUFFLE_3201);
							case SHUFFLE_3202: return Sse2.shuffle_pd(a, b, SHUFFLE_3202);
							case SHUFFLE_3203: return Sse2.shuffle_pd(a, b, SHUFFLE_3203);
							case SHUFFLE_3210: return Sse2.shuffle_pd(a, b, SHUFFLE_3210);
							case SHUFFLE_3211: return Sse2.shuffle_pd(a, b, SHUFFLE_3211);
							case SHUFFLE_3212: return Sse2.shuffle_pd(a, b, SHUFFLE_3212);
							case SHUFFLE_3213: return Sse2.shuffle_pd(a, b, SHUFFLE_3213);
							case SHUFFLE_3220: return Sse2.shuffle_pd(a, b, SHUFFLE_3220);
							case SHUFFLE_3221: return Sse2.shuffle_pd(a, b, SHUFFLE_3221);
							case SHUFFLE_3222: return Sse2.shuffle_pd(a, b, SHUFFLE_3222);
							case SHUFFLE_3223: return Sse2.shuffle_pd(a, b, SHUFFLE_3223);
							case SHUFFLE_3230: return Sse2.shuffle_pd(a, b, SHUFFLE_3230);
							case SHUFFLE_3231: return Sse2.shuffle_pd(a, b, SHUFFLE_3231);
							case SHUFFLE_3232: return Sse2.shuffle_pd(a, b, SHUFFLE_3232);
							case SHUFFLE_3233: return Sse2.shuffle_pd(a, b, SHUFFLE_3233);
							case SHUFFLE_3300: return Sse2.shuffle_pd(a, b, SHUFFLE_3300);
							case SHUFFLE_3301: return Sse2.shuffle_pd(a, b, SHUFFLE_3301);
							case SHUFFLE_3302: return Sse2.shuffle_pd(a, b, SHUFFLE_3302);
							case SHUFFLE_3303: return Sse2.shuffle_pd(a, b, SHUFFLE_3303);
							case SHUFFLE_3310: return Sse2.shuffle_pd(a, b, SHUFFLE_3310);
							case SHUFFLE_3311: return Sse2.shuffle_pd(a, b, SHUFFLE_3311);
							case SHUFFLE_3312: return Sse2.shuffle_pd(a, b, SHUFFLE_3312);
							case SHUFFLE_3313: return Sse2.shuffle_pd(a, b, SHUFFLE_3313);
							case SHUFFLE_3320: return Sse2.shuffle_pd(a, b, SHUFFLE_3320);
							case SHUFFLE_3321: return Sse2.shuffle_pd(a, b, SHUFFLE_3321);
							case SHUFFLE_3322: return Sse2.shuffle_pd(a, b, SHUFFLE_3322);
							case SHUFFLE_3323: return Sse2.shuffle_pd(a, b, SHUFFLE_3323);
							case SHUFFLE_3330: return Sse2.shuffle_pd(a, b, SHUFFLE_3330);
							case SHUFFLE_3331: return Sse2.shuffle_pd(a, b, SHUFFLE_3331);
							case SHUFFLE_3332: return Sse2.shuffle_pd(a, b, SHUFFLE_3332);
							case SHUFFLE_3333: return Sse2.shuffle_pd(a, b, SHUFFLE_3333);
							default: return a;
						}
					}
					else throw new IllegalInstructionException();
				}
			}

			internal static class Arm
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v64 vset_lane_f32(float a, v64 b, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 1:  return Unity.Burst.Intrinsics.Arm.Neon.vset_lane_f32(a, b, 1);
							default: return Unity.Burst.Intrinsics.Arm.Neon.vset_lane_f32(a, b, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v64 vset_lane_f64(double a, v64 b, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							default: return Unity.Burst.Intrinsics.Arm.Neon.vset_lane_f64(a, b, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v64 vset_lane_u8(byte a, v64 b, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 7:   return Unity.Burst.Intrinsics.Arm.Neon.vset_lane_u8(a, b, 7);
							case 6:   return Unity.Burst.Intrinsics.Arm.Neon.vset_lane_u8(a, b, 6);
							case 5:   return Unity.Burst.Intrinsics.Arm.Neon.vset_lane_u8(a, b, 5);
							case 4:   return Unity.Burst.Intrinsics.Arm.Neon.vset_lane_u8(a, b, 4);
							case 3:   return Unity.Burst.Intrinsics.Arm.Neon.vset_lane_u8(a, b, 3);
							case 2:   return Unity.Burst.Intrinsics.Arm.Neon.vset_lane_u8(a, b, 2);
							case 1:   return Unity.Burst.Intrinsics.Arm.Neon.vset_lane_u8(a, b, 1);
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vset_lane_u8(a, b, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v64 vset_lane_u16(ushort a, v64 b, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 3:   return Unity.Burst.Intrinsics.Arm.Neon.vset_lane_u16(a, b, 3);
							case 2:   return Unity.Burst.Intrinsics.Arm.Neon.vset_lane_u16(a, b, 2);
							case 1:   return Unity.Burst.Intrinsics.Arm.Neon.vset_lane_u16(a, b, 1);
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vset_lane_u16(a, b, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v64 vset_lane_u32(uint a, v64 b, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 1:   return Unity.Burst.Intrinsics.Arm.Neon.vset_lane_u32(a, b, 1);
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vset_lane_u32(a, b, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v64 vset_lane_u64(ulong a, v64 b, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vset_lane_u64(a, b, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v64 vset_lane_s8(sbyte a, v64 b, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 7:   return Unity.Burst.Intrinsics.Arm.Neon.vset_lane_s8(a, b, 7);
							case 6:   return Unity.Burst.Intrinsics.Arm.Neon.vset_lane_s8(a, b, 6);
							case 5:   return Unity.Burst.Intrinsics.Arm.Neon.vset_lane_s8(a, b, 5);
							case 4:   return Unity.Burst.Intrinsics.Arm.Neon.vset_lane_s8(a, b, 4);
							case 3:   return Unity.Burst.Intrinsics.Arm.Neon.vset_lane_s8(a, b, 3);
							case 2:   return Unity.Burst.Intrinsics.Arm.Neon.vset_lane_s8(a, b, 2);
							case 1:   return Unity.Burst.Intrinsics.Arm.Neon.vset_lane_s8(a, b, 1);
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vset_lane_s8(a, b, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v64 vset_lane_s16(short a, v64 b, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 3:   return Unity.Burst.Intrinsics.Arm.Neon.vset_lane_s16(a, b, 3);
							case 2:   return Unity.Burst.Intrinsics.Arm.Neon.vset_lane_s16(a, b, 2);
							case 1:   return Unity.Burst.Intrinsics.Arm.Neon.vset_lane_s16(a, b, 1);
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vset_lane_s16(a, b, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v64 vset_lane_s32(int a, v64 b, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 1:   return Unity.Burst.Intrinsics.Arm.Neon.vset_lane_s32(a, b, 1);
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vset_lane_s32(a, b, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v64 vset_lane_s64(long a, v64 b, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vset_lane_s64(a, b, 0);
						}
					}
					else throw new IllegalInstructionException();
				}


				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static float vget_lane_f32(v64 a, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 1:  return Unity.Burst.Intrinsics.Arm.Neon.vget_lane_f32(a, 1);
							default: return Unity.Burst.Intrinsics.Arm.Neon.vget_lane_f32(a, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static double vget_lane_f64(v64 a, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							default: return Unity.Burst.Intrinsics.Arm.Neon.vget_lane_f64(a, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static byte vget_lane_u8(v64 a, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 7:   return Unity.Burst.Intrinsics.Arm.Neon.vget_lane_u8(a, 7);
							case 6:   return Unity.Burst.Intrinsics.Arm.Neon.vget_lane_u8(a, 6);
							case 5:   return Unity.Burst.Intrinsics.Arm.Neon.vget_lane_u8(a, 5);
							case 4:   return Unity.Burst.Intrinsics.Arm.Neon.vget_lane_u8(a, 4);
							case 3:   return Unity.Burst.Intrinsics.Arm.Neon.vget_lane_u8(a, 3);
							case 2:   return Unity.Burst.Intrinsics.Arm.Neon.vget_lane_u8(a, 2);
							case 1:   return Unity.Burst.Intrinsics.Arm.Neon.vget_lane_u8(a, 1);
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vget_lane_u8(a, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static ushort vget_lane_u16(v64 a, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 3:   return Unity.Burst.Intrinsics.Arm.Neon.vget_lane_u16(a, 3);
							case 2:   return Unity.Burst.Intrinsics.Arm.Neon.vget_lane_u16(a, 2);
							case 1:   return Unity.Burst.Intrinsics.Arm.Neon.vget_lane_u16(a, 1);
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vget_lane_u16(a, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static uint vget_lane_u32(v64 a, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 1:   return Unity.Burst.Intrinsics.Arm.Neon.vget_lane_u32(a, 1);
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vget_lane_u32(a, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static ulong vget_lane_u64(v64 a, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vget_lane_u64(a, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static sbyte vget_lane_s8(v64 a, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 7:   return Unity.Burst.Intrinsics.Arm.Neon.vget_lane_s8(a, 7);
							case 6:   return Unity.Burst.Intrinsics.Arm.Neon.vget_lane_s8(a, 6);
							case 5:   return Unity.Burst.Intrinsics.Arm.Neon.vget_lane_s8(a, 5);
							case 4:   return Unity.Burst.Intrinsics.Arm.Neon.vget_lane_s8(a, 4);
							case 3:   return Unity.Burst.Intrinsics.Arm.Neon.vget_lane_s8(a, 3);
							case 2:   return Unity.Burst.Intrinsics.Arm.Neon.vget_lane_s8(a, 2);
							case 1:   return Unity.Burst.Intrinsics.Arm.Neon.vget_lane_s8(a, 1);
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vget_lane_s8(a, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static short vget_lane_s16(v64 a, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 3:   return Unity.Burst.Intrinsics.Arm.Neon.vget_lane_s16(a, 3);
							case 2:   return Unity.Burst.Intrinsics.Arm.Neon.vget_lane_s16(a, 2);
							case 1:   return Unity.Burst.Intrinsics.Arm.Neon.vget_lane_s16(a, 1);
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vget_lane_s16(a, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static int vget_lane_s32(v64 a, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 1:   return Unity.Burst.Intrinsics.Arm.Neon.vget_lane_s32(a, 1);
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vget_lane_s32(a, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static long vget_lane_s64(v64 a, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vget_lane_s64(a, 0);
						}
					}
					else throw new IllegalInstructionException();
				}


				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 vsetq_lane_f32(float a, v128 b, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 3:  return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_f32(a, b, 3);
							case 2:  return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_f32(a, b, 2);
							case 1:  return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_f32(a, b, 1);
							default: return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_f32(a, b, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 vsetq_lane_f64(double a, v128 b, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 1:  return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_f64(a, b, 1);
							default: return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_f64(a, b, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 vsetq_lane_u8(byte a, v128 b, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 15:  return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_u8(a, b, 15);
							case 14:  return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_u8(a, b, 14);
							case 13:  return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_u8(a, b, 13);
							case 12:  return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_u8(a, b, 12);
							case 11:  return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_u8(a, b, 11);
							case 10:  return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_u8(a, b, 10);
							case 9:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_u8(a, b, 9);
							case 8:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_u8(a, b, 8);
							case 7:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_u8(a, b, 7);
							case 6:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_u8(a, b, 6);
							case 5:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_u8(a, b, 5);
							case 4:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_u8(a, b, 4);
							case 3:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_u8(a, b, 3);
							case 2:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_u8(a, b, 2);
							case 1:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_u8(a, b, 1);
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_u8(a, b, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 vsetq_lane_u16(ushort a, v128 b, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 7:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_u16(a, b, 7);
							case 6:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_u16(a, b, 6);
							case 5:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_u16(a, b, 5);
							case 4:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_u16(a, b, 4);
							case 3:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_u16(a, b, 3);
							case 2:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_u16(a, b, 2);
							case 1:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_u16(a, b, 1);
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_u16(a, b, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 vsetq_lane_u32(uint a, v128 b, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 3:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_u32(a, b, 3);
							case 2:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_u32(a, b, 2);
							case 1:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_u32(a, b, 1);
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_u32(a, b, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 vsetq_lane_u64(ulong a, v128 b, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 1:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_u64(a, b, 1);
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_u64(a, b, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 vsetq_lane_s8(sbyte a, v128 b, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 15:  return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_s8(a, b, 15);
							case 14:  return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_s8(a, b, 14);
							case 13:  return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_s8(a, b, 13);
							case 12:  return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_s8(a, b, 12);
							case 11:  return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_s8(a, b, 11);
							case 10:  return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_s8(a, b, 10);
							case 9:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_s8(a, b, 9);
							case 8:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_s8(a, b, 8);
							case 7:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_s8(a, b, 7);
							case 6:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_s8(a, b, 6);
							case 5:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_s8(a, b, 5);
							case 4:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_s8(a, b, 4);
							case 3:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_s8(a, b, 3);
							case 2:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_s8(a, b, 2);
							case 1:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_s8(a, b, 1);
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_s8(a, b, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 vsetq_lane_s16(short a, v128 b, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 7:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_s16(a, b, 7);
							case 6:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_s16(a, b, 6);
							case 5:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_s16(a, b, 5);
							case 4:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_s16(a, b, 4);
							case 3:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_s16(a, b, 3);
							case 2:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_s16(a, b, 2);
							case 1:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_s16(a, b, 1);
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_s16(a, b, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 vsetq_lane_s32(int a, v128 b, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 3:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_s32(a, b, 3);
							case 2:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_s32(a, b, 2);
							case 1:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_s32(a, b, 1);
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_s32(a, b, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 vsetq_lane_s64(long a, v128 b, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 1:   return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_s64(a, b, 1);
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vsetq_lane_s64(a, b, 0);
						}
					}
					else throw new IllegalInstructionException();
				}


				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static float vgetq_lane_f32(v128 a, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 3:  return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_f32(a, 3);
							case 2:  return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_f32(a, 2);
							case 1:  return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_f32(a, 1);
							default: return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_f32(a, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static double vgetq_lane_f64(v128 a, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 1:  return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_f64(a, 1);
							default: return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_f64(a, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static byte vgetq_lane_u8(v128 a, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 15:  return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_u8(a, 15);
							case 14:  return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_u8(a, 14);
							case 13:  return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_u8(a, 13);
							case 12:  return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_u8(a, 12);
							case 11:  return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_u8(a, 11);
							case 10:  return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_u8(a, 10);
							case 9:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_u8(a, 9);
							case 8:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_u8(a, 8);
							case 7:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_u8(a, 7);
							case 6:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_u8(a, 6);
							case 5:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_u8(a, 5);
							case 4:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_u8(a, 4);
							case 3:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_u8(a, 3);
							case 2:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_u8(a, 2);
							case 1:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_u8(a, 1);
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_u8(a, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static ushort vgetq_lane_u16(v128 a, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 7:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_u16(a, 7);
							case 6:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_u16(a, 6);
							case 5:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_u16(a, 5);
							case 4:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_u16(a, 4);
							case 3:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_u16(a, 3);
							case 2:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_u16(a, 2);
							case 1:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_u16(a, 1);
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_u16(a, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static uint vgetq_lane_u32(v128 a, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 3:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_u32(a, 3);
							case 2:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_u32(a, 2);
							case 1:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_u32(a, 1);
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_u32(a, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static ulong vgetq_lane_u64(v128 a, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 1:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_u64(a, 1);
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_u64(a, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static sbyte vgetq_lane_s8(v128 a, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 15:  return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_s8(a, 15);
							case 14:  return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_s8(a, 14);
							case 13:  return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_s8(a, 13);
							case 12:  return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_s8(a, 12);
							case 11:  return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_s8(a, 11);
							case 10:  return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_s8(a, 10);
							case 9:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_s8(a, 9);
							case 8:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_s8(a, 8);
							case 7:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_s8(a, 7);
							case 6:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_s8(a, 6);
							case 5:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_s8(a, 5);
							case 4:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_s8(a, 4);
							case 3:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_s8(a, 3);
							case 2:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_s8(a, 2);
							case 1:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_s8(a, 1);
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_s8(a, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static short vgetq_lane_s16(v128 a, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 7:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_s16(a, 7);
							case 6:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_s16(a, 6);
							case 5:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_s16(a, 5);
							case 4:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_s16(a, 4);
							case 3:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_s16(a, 3);
							case 2:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_s16(a, 2);
							case 1:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_s16(a, 1);
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_s16(a, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static int vgetq_lane_s32(v128 a, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 3:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_s32(a, 3);
							case 2:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_s32(a, 2);
							case 1:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_s32(a, 1);
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_s32(a, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static long vgetq_lane_s64(v128 a, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 1:   return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_s64(a, 1);
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vgetq_lane_s64(a, 0);
						}
					}
					else throw new IllegalInstructionException();
				}
				
				
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 vextq_f32(v128 a, v128 b, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 3:  return Unity.Burst.Intrinsics.Arm.Neon.vextq_f32(a, b, 3);
							case 2:  return Unity.Burst.Intrinsics.Arm.Neon.vextq_f32(a, b, 2);
							case 1:  return Unity.Burst.Intrinsics.Arm.Neon.vextq_f32(a, b, 1);
							default: return Unity.Burst.Intrinsics.Arm.Neon.vextq_f32(a, b, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 vextq_f64(v128 a, v128 b, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 1:  return Unity.Burst.Intrinsics.Arm.Neon.vextq_f64(a, b, 1);
							default: return Unity.Burst.Intrinsics.Arm.Neon.vextq_f64(a, b, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 vextq_u8(v128 a, v128 b, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 15:  return Unity.Burst.Intrinsics.Arm.Neon.vextq_u8(a, b, 15);
							case 14:  return Unity.Burst.Intrinsics.Arm.Neon.vextq_u8(a, b, 14);
							case 13:  return Unity.Burst.Intrinsics.Arm.Neon.vextq_u8(a, b, 13);
							case 12:  return Unity.Burst.Intrinsics.Arm.Neon.vextq_u8(a, b, 12);
							case 11:  return Unity.Burst.Intrinsics.Arm.Neon.vextq_u8(a, b, 11);
							case 10:  return Unity.Burst.Intrinsics.Arm.Neon.vextq_u8(a, b, 10);
							case 9:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_u8(a, b, 9);
							case 8:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_u8(a, b, 8);
							case 7:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_u8(a, b, 7);
							case 6:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_u8(a, b, 6);
							case 5:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_u8(a, b, 5);
							case 4:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_u8(a, b, 4);
							case 3:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_u8(a, b, 3);
							case 2:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_u8(a, b, 2);
							case 1:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_u8(a, b, 1);
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vextq_u8(a, b, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 vextq_u16(v128 a, v128 b, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 7:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_u16(a, b, 7);
							case 6:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_u16(a, b, 6);
							case 5:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_u16(a, b, 5);
							case 4:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_u16(a, b, 4);
							case 3:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_u16(a, b, 3);
							case 2:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_u16(a, b, 2);
							case 1:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_u16(a, b, 1);
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vextq_u16(a, b, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 vextq_u32(v128 a, v128 b, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 3:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_u32(a, b, 3);
							case 2:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_u32(a, b, 2);
							case 1:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_u32(a, b, 1);
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vextq_u32(a, b, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 vextq_u64(v128 a, v128 b, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 1:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_u64(a, b, 1);
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vextq_u64(a, b, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 vextq_s8(v128 a, v128 b, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 15:  return Unity.Burst.Intrinsics.Arm.Neon.vextq_s8(a, b, 15);
							case 14:  return Unity.Burst.Intrinsics.Arm.Neon.vextq_s8(a, b, 14);
							case 13:  return Unity.Burst.Intrinsics.Arm.Neon.vextq_s8(a, b, 13);
							case 12:  return Unity.Burst.Intrinsics.Arm.Neon.vextq_s8(a, b, 12);
							case 11:  return Unity.Burst.Intrinsics.Arm.Neon.vextq_s8(a, b, 11);
							case 10:  return Unity.Burst.Intrinsics.Arm.Neon.vextq_s8(a, b, 10);
							case 9:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_s8(a, b, 9);
							case 8:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_s8(a, b, 8);
							case 7:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_s8(a, b, 7);
							case 6:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_s8(a, b, 6);
							case 5:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_s8(a, b, 5);
							case 4:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_s8(a, b, 4);
							case 3:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_s8(a, b, 3);
							case 2:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_s8(a, b, 2);
							case 1:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_s8(a, b, 1);
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vextq_s8(a, b, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 vextq_s16(v128 a, v128 b, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 7:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_s16(a, b, 7);
							case 6:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_s16(a, b, 6);
							case 5:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_s16(a, b, 5);
							case 4:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_s16(a, b, 4);
							case 3:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_s16(a, b, 3);
							case 2:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_s16(a, b, 2);
							case 1:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_s16(a, b, 1);
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vextq_s16(a, b, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 vextq_s32(v128 a, v128 b, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 3:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_s32(a, b, 3);
							case 2:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_s32(a, b, 2);
							case 1:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_s32(a, b, 1);
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vextq_s32(a, b, 0);
						}
					}
					else throw new IllegalInstructionException();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal static v128 vextq_s64(v128 a, v128 b, int imm8)
				{
					if (IsNeonSupported)
					{
						switch (imm8)
						{
							case 1:   return Unity.Burst.Intrinsics.Arm.Neon.vextq_s64(a, b, 1);
							default:  return Unity.Burst.Intrinsics.Arm.Neon.vextq_s64(a, b, 0);
						}
					}
					else throw new IllegalInstructionException();
				}
			}

			internal const int SHUFFLE_0000 = (0 << 6) | (0 << 4) | (0 << 2) | (0 << 0);
			internal const int SHUFFLE_0001 = (0 << 6) | (0 << 4) | (0 << 2) | (1 << 0);
			internal const int SHUFFLE_0002 = (0 << 6) | (0 << 4) | (0 << 2) | (2 << 0);
			internal const int SHUFFLE_0003 = (0 << 6) | (0 << 4) | (0 << 2) | (3 << 0);
			internal const int SHUFFLE_0010 = (0 << 6) | (0 << 4) | (1 << 2) | (0 << 0);
			internal const int SHUFFLE_0011 = (0 << 6) | (0 << 4) | (1 << 2) | (1 << 0);
			internal const int SHUFFLE_0012 = (0 << 6) | (0 << 4) | (1 << 2) | (2 << 0);
			internal const int SHUFFLE_0013 = (0 << 6) | (0 << 4) | (1 << 2) | (3 << 0);
			internal const int SHUFFLE_0020 = (0 << 6) | (0 << 4) | (2 << 2) | (0 << 0);
			internal const int SHUFFLE_0021 = (0 << 6) | (0 << 4) | (2 << 2) | (1 << 0);
			internal const int SHUFFLE_0022 = (0 << 6) | (0 << 4) | (2 << 2) | (2 << 0);
			internal const int SHUFFLE_0023 = (0 << 6) | (0 << 4) | (2 << 2) | (3 << 0);
			internal const int SHUFFLE_0030 = (0 << 6) | (0 << 4) | (3 << 2) | (0 << 0);
			internal const int SHUFFLE_0031 = (0 << 6) | (0 << 4) | (3 << 2) | (1 << 0);
			internal const int SHUFFLE_0032 = (0 << 6) | (0 << 4) | (3 << 2) | (2 << 0);
			internal const int SHUFFLE_0033 = (0 << 6) | (0 << 4) | (3 << 2) | (3 << 0);
			internal const int SHUFFLE_0100 = (0 << 6) | (1 << 4) | (0 << 2) | (0 << 0);
			internal const int SHUFFLE_0101 = (0 << 6) | (1 << 4) | (0 << 2) | (1 << 0);
			internal const int SHUFFLE_0102 = (0 << 6) | (1 << 4) | (0 << 2) | (2 << 0);
			internal const int SHUFFLE_0103 = (0 << 6) | (1 << 4) | (0 << 2) | (3 << 0);
			internal const int SHUFFLE_0110 = (0 << 6) | (1 << 4) | (1 << 2) | (0 << 0);
			internal const int SHUFFLE_0111 = (0 << 6) | (1 << 4) | (1 << 2) | (1 << 0);
			internal const int SHUFFLE_0112 = (0 << 6) | (1 << 4) | (1 << 2) | (2 << 0);
			internal const int SHUFFLE_0113 = (0 << 6) | (1 << 4) | (1 << 2) | (3 << 0);
			internal const int SHUFFLE_0120 = (0 << 6) | (1 << 4) | (2 << 2) | (0 << 0);
			internal const int SHUFFLE_0121 = (0 << 6) | (1 << 4) | (2 << 2) | (1 << 0);
			internal const int SHUFFLE_0122 = (0 << 6) | (1 << 4) | (2 << 2) | (2 << 0);
			internal const int SHUFFLE_0123 = (0 << 6) | (1 << 4) | (2 << 2) | (3 << 0);
			internal const int SHUFFLE_0130 = (0 << 6) | (1 << 4) | (3 << 2) | (0 << 0);
			internal const int SHUFFLE_0131 = (0 << 6) | (1 << 4) | (3 << 2) | (1 << 0);
			internal const int SHUFFLE_0132 = (0 << 6) | (1 << 4) | (3 << 2) | (2 << 0);
			internal const int SHUFFLE_0133 = (0 << 6) | (1 << 4) | (3 << 2) | (3 << 0);
			internal const int SHUFFLE_0200 = (0 << 6) | (2 << 4) | (0 << 2) | (0 << 0);
			internal const int SHUFFLE_0201 = (0 << 6) | (2 << 4) | (0 << 2) | (1 << 0);
			internal const int SHUFFLE_0202 = (0 << 6) | (2 << 4) | (0 << 2) | (2 << 0);
			internal const int SHUFFLE_0203 = (0 << 6) | (2 << 4) | (0 << 2) | (3 << 0);
			internal const int SHUFFLE_0210 = (0 << 6) | (2 << 4) | (1 << 2) | (0 << 0);
			internal const int SHUFFLE_0211 = (0 << 6) | (2 << 4) | (1 << 2) | (1 << 0);
			internal const int SHUFFLE_0212 = (0 << 6) | (2 << 4) | (1 << 2) | (2 << 0);
			internal const int SHUFFLE_0213 = (0 << 6) | (2 << 4) | (1 << 2) | (3 << 0);
			internal const int SHUFFLE_0220 = (0 << 6) | (2 << 4) | (2 << 2) | (0 << 0);
			internal const int SHUFFLE_0221 = (0 << 6) | (2 << 4) | (2 << 2) | (1 << 0);
			internal const int SHUFFLE_0222 = (0 << 6) | (2 << 4) | (2 << 2) | (2 << 0);
			internal const int SHUFFLE_0223 = (0 << 6) | (2 << 4) | (2 << 2) | (3 << 0);
			internal const int SHUFFLE_0230 = (0 << 6) | (2 << 4) | (3 << 2) | (0 << 0);
			internal const int SHUFFLE_0231 = (0 << 6) | (2 << 4) | (3 << 2) | (1 << 0);
			internal const int SHUFFLE_0232 = (0 << 6) | (2 << 4) | (3 << 2) | (2 << 0);
			internal const int SHUFFLE_0233 = (0 << 6) | (2 << 4) | (3 << 2) | (3 << 0);
			internal const int SHUFFLE_0300 = (0 << 6) | (3 << 4) | (0 << 2) | (0 << 0);
			internal const int SHUFFLE_0301 = (0 << 6) | (3 << 4) | (0 << 2) | (1 << 0);
			internal const int SHUFFLE_0302 = (0 << 6) | (3 << 4) | (0 << 2) | (2 << 0);
			internal const int SHUFFLE_0303 = (0 << 6) | (3 << 4) | (0 << 2) | (3 << 0);
			internal const int SHUFFLE_0310 = (0 << 6) | (3 << 4) | (1 << 2) | (0 << 0);
			internal const int SHUFFLE_0311 = (0 << 6) | (3 << 4) | (1 << 2) | (1 << 0);
			internal const int SHUFFLE_0312 = (0 << 6) | (3 << 4) | (1 << 2) | (2 << 0);
			internal const int SHUFFLE_0313 = (0 << 6) | (3 << 4) | (1 << 2) | (3 << 0);
			internal const int SHUFFLE_0320 = (0 << 6) | (3 << 4) | (2 << 2) | (0 << 0);
			internal const int SHUFFLE_0321 = (0 << 6) | (3 << 4) | (2 << 2) | (1 << 0);
			internal const int SHUFFLE_0322 = (0 << 6) | (3 << 4) | (2 << 2) | (2 << 0);
			internal const int SHUFFLE_0323 = (0 << 6) | (3 << 4) | (2 << 2) | (3 << 0);
			internal const int SHUFFLE_0330 = (0 << 6) | (3 << 4) | (3 << 2) | (0 << 0);
			internal const int SHUFFLE_0331 = (0 << 6) | (3 << 4) | (3 << 2) | (1 << 0);
			internal const int SHUFFLE_0332 = (0 << 6) | (3 << 4) | (3 << 2) | (2 << 0);
			internal const int SHUFFLE_0333 = (0 << 6) | (3 << 4) | (3 << 2) | (3 << 0);
			internal const int SHUFFLE_1000 = (1 << 6) | (0 << 4) | (0 << 2) | (0 << 0);
			internal const int SHUFFLE_1001 = (1 << 6) | (0 << 4) | (0 << 2) | (1 << 0);
			internal const int SHUFFLE_1002 = (1 << 6) | (0 << 4) | (0 << 2) | (2 << 0);
			internal const int SHUFFLE_1003 = (1 << 6) | (0 << 4) | (0 << 2) | (3 << 0);
			internal const int SHUFFLE_1010 = (1 << 6) | (0 << 4) | (1 << 2) | (0 << 0);
			internal const int SHUFFLE_1011 = (1 << 6) | (0 << 4) | (1 << 2) | (1 << 0);
			internal const int SHUFFLE_1012 = (1 << 6) | (0 << 4) | (1 << 2) | (2 << 0);
			internal const int SHUFFLE_1013 = (1 << 6) | (0 << 4) | (1 << 2) | (3 << 0);
			internal const int SHUFFLE_1020 = (1 << 6) | (0 << 4) | (2 << 2) | (0 << 0);
			internal const int SHUFFLE_1021 = (1 << 6) | (0 << 4) | (2 << 2) | (1 << 0);
			internal const int SHUFFLE_1022 = (1 << 6) | (0 << 4) | (2 << 2) | (2 << 0);
			internal const int SHUFFLE_1023 = (1 << 6) | (0 << 4) | (2 << 2) | (3 << 0);
			internal const int SHUFFLE_1030 = (1 << 6) | (0 << 4) | (3 << 2) | (0 << 0);
			internal const int SHUFFLE_1031 = (1 << 6) | (0 << 4) | (3 << 2) | (1 << 0);
			internal const int SHUFFLE_1032 = (1 << 6) | (0 << 4) | (3 << 2) | (2 << 0);
			internal const int SHUFFLE_1033 = (1 << 6) | (0 << 4) | (3 << 2) | (3 << 0);
			internal const int SHUFFLE_1100 = (1 << 6) | (1 << 4) | (0 << 2) | (0 << 0);
			internal const int SHUFFLE_1101 = (1 << 6) | (1 << 4) | (0 << 2) | (1 << 0);
			internal const int SHUFFLE_1102 = (1 << 6) | (1 << 4) | (0 << 2) | (2 << 0);
			internal const int SHUFFLE_1103 = (1 << 6) | (1 << 4) | (0 << 2) | (3 << 0);
			internal const int SHUFFLE_1110 = (1 << 6) | (1 << 4) | (1 << 2) | (0 << 0);
			internal const int SHUFFLE_1111 = (1 << 6) | (1 << 4) | (1 << 2) | (1 << 0);
			internal const int SHUFFLE_1112 = (1 << 6) | (1 << 4) | (1 << 2) | (2 << 0);
			internal const int SHUFFLE_1113 = (1 << 6) | (1 << 4) | (1 << 2) | (3 << 0);
			internal const int SHUFFLE_1120 = (1 << 6) | (1 << 4) | (2 << 2) | (0 << 0);
			internal const int SHUFFLE_1121 = (1 << 6) | (1 << 4) | (2 << 2) | (1 << 0);
			internal const int SHUFFLE_1122 = (1 << 6) | (1 << 4) | (2 << 2) | (2 << 0);
			internal const int SHUFFLE_1123 = (1 << 6) | (1 << 4) | (2 << 2) | (3 << 0);
			internal const int SHUFFLE_1130 = (1 << 6) | (1 << 4) | (3 << 2) | (0 << 0);
			internal const int SHUFFLE_1131 = (1 << 6) | (1 << 4) | (3 << 2) | (1 << 0);
			internal const int SHUFFLE_1132 = (1 << 6) | (1 << 4) | (3 << 2) | (2 << 0);
			internal const int SHUFFLE_1133 = (1 << 6) | (1 << 4) | (3 << 2) | (3 << 0);
			internal const int SHUFFLE_1200 = (1 << 6) | (2 << 4) | (0 << 2) | (0 << 0);
			internal const int SHUFFLE_1201 = (1 << 6) | (2 << 4) | (0 << 2) | (1 << 0);
			internal const int SHUFFLE_1202 = (1 << 6) | (2 << 4) | (0 << 2) | (2 << 0);
			internal const int SHUFFLE_1203 = (1 << 6) | (2 << 4) | (0 << 2) | (3 << 0);
			internal const int SHUFFLE_1210 = (1 << 6) | (2 << 4) | (1 << 2) | (0 << 0);
			internal const int SHUFFLE_1211 = (1 << 6) | (2 << 4) | (1 << 2) | (1 << 0);
			internal const int SHUFFLE_1212 = (1 << 6) | (2 << 4) | (1 << 2) | (2 << 0);
			internal const int SHUFFLE_1213 = (1 << 6) | (2 << 4) | (1 << 2) | (3 << 0);
			internal const int SHUFFLE_1220 = (1 << 6) | (2 << 4) | (2 << 2) | (0 << 0);
			internal const int SHUFFLE_1221 = (1 << 6) | (2 << 4) | (2 << 2) | (1 << 0);
			internal const int SHUFFLE_1222 = (1 << 6) | (2 << 4) | (2 << 2) | (2 << 0);
			internal const int SHUFFLE_1223 = (1 << 6) | (2 << 4) | (2 << 2) | (3 << 0);
			internal const int SHUFFLE_1230 = (1 << 6) | (2 << 4) | (3 << 2) | (0 << 0);
			internal const int SHUFFLE_1231 = (1 << 6) | (2 << 4) | (3 << 2) | (1 << 0);
			internal const int SHUFFLE_1232 = (1 << 6) | (2 << 4) | (3 << 2) | (2 << 0);
			internal const int SHUFFLE_1233 = (1 << 6) | (2 << 4) | (3 << 2) | (3 << 0);
			internal const int SHUFFLE_1300 = (1 << 6) | (3 << 4) | (0 << 2) | (0 << 0);
			internal const int SHUFFLE_1301 = (1 << 6) | (3 << 4) | (0 << 2) | (1 << 0);
			internal const int SHUFFLE_1302 = (1 << 6) | (3 << 4) | (0 << 2) | (2 << 0);
			internal const int SHUFFLE_1303 = (1 << 6) | (3 << 4) | (0 << 2) | (3 << 0);
			internal const int SHUFFLE_1310 = (1 << 6) | (3 << 4) | (1 << 2) | (0 << 0);
			internal const int SHUFFLE_1311 = (1 << 6) | (3 << 4) | (1 << 2) | (1 << 0);
			internal const int SHUFFLE_1312 = (1 << 6) | (3 << 4) | (1 << 2) | (2 << 0);
			internal const int SHUFFLE_1313 = (1 << 6) | (3 << 4) | (1 << 2) | (3 << 0);
			internal const int SHUFFLE_1320 = (1 << 6) | (3 << 4) | (2 << 2) | (0 << 0);
			internal const int SHUFFLE_1321 = (1 << 6) | (3 << 4) | (2 << 2) | (1 << 0);
			internal const int SHUFFLE_1322 = (1 << 6) | (3 << 4) | (2 << 2) | (2 << 0);
			internal const int SHUFFLE_1323 = (1 << 6) | (3 << 4) | (2 << 2) | (3 << 0);
			internal const int SHUFFLE_1330 = (1 << 6) | (3 << 4) | (3 << 2) | (0 << 0);
			internal const int SHUFFLE_1331 = (1 << 6) | (3 << 4) | (3 << 2) | (1 << 0);
			internal const int SHUFFLE_1332 = (1 << 6) | (3 << 4) | (3 << 2) | (2 << 0);
			internal const int SHUFFLE_1333 = (1 << 6) | (3 << 4) | (3 << 2) | (3 << 0);
			internal const int SHUFFLE_2000 = (2 << 6) | (0 << 4) | (0 << 2) | (0 << 0);
			internal const int SHUFFLE_2001 = (2 << 6) | (0 << 4) | (0 << 2) | (1 << 0);
			internal const int SHUFFLE_2002 = (2 << 6) | (0 << 4) | (0 << 2) | (2 << 0);
			internal const int SHUFFLE_2003 = (2 << 6) | (0 << 4) | (0 << 2) | (3 << 0);
			internal const int SHUFFLE_2010 = (2 << 6) | (0 << 4) | (1 << 2) | (0 << 0);
			internal const int SHUFFLE_2011 = (2 << 6) | (0 << 4) | (1 << 2) | (1 << 0);
			internal const int SHUFFLE_2012 = (2 << 6) | (0 << 4) | (1 << 2) | (2 << 0);
			internal const int SHUFFLE_2013 = (2 << 6) | (0 << 4) | (1 << 2) | (3 << 0);
			internal const int SHUFFLE_2020 = (2 << 6) | (0 << 4) | (2 << 2) | (0 << 0);
			internal const int SHUFFLE_2021 = (2 << 6) | (0 << 4) | (2 << 2) | (1 << 0);
			internal const int SHUFFLE_2022 = (2 << 6) | (0 << 4) | (2 << 2) | (2 << 0);
			internal const int SHUFFLE_2023 = (2 << 6) | (0 << 4) | (2 << 2) | (3 << 0);
			internal const int SHUFFLE_2030 = (2 << 6) | (0 << 4) | (3 << 2) | (0 << 0);
			internal const int SHUFFLE_2031 = (2 << 6) | (0 << 4) | (3 << 2) | (1 << 0);
			internal const int SHUFFLE_2032 = (2 << 6) | (0 << 4) | (3 << 2) | (2 << 0);
			internal const int SHUFFLE_2033 = (2 << 6) | (0 << 4) | (3 << 2) | (3 << 0);
			internal const int SHUFFLE_2100 = (2 << 6) | (1 << 4) | (0 << 2) | (0 << 0);
			internal const int SHUFFLE_2101 = (2 << 6) | (1 << 4) | (0 << 2) | (1 << 0);
			internal const int SHUFFLE_2102 = (2 << 6) | (1 << 4) | (0 << 2) | (2 << 0);
			internal const int SHUFFLE_2103 = (2 << 6) | (1 << 4) | (0 << 2) | (3 << 0);
			internal const int SHUFFLE_2110 = (2 << 6) | (1 << 4) | (1 << 2) | (0 << 0);
			internal const int SHUFFLE_2111 = (2 << 6) | (1 << 4) | (1 << 2) | (1 << 0);
			internal const int SHUFFLE_2112 = (2 << 6) | (1 << 4) | (1 << 2) | (2 << 0);
			internal const int SHUFFLE_2113 = (2 << 6) | (1 << 4) | (1 << 2) | (3 << 0);
			internal const int SHUFFLE_2120 = (2 << 6) | (1 << 4) | (2 << 2) | (0 << 0);
			internal const int SHUFFLE_2121 = (2 << 6) | (1 << 4) | (2 << 2) | (1 << 0);
			internal const int SHUFFLE_2122 = (2 << 6) | (1 << 4) | (2 << 2) | (2 << 0);
			internal const int SHUFFLE_2123 = (2 << 6) | (1 << 4) | (2 << 2) | (3 << 0);
			internal const int SHUFFLE_2130 = (2 << 6) | (1 << 4) | (3 << 2) | (0 << 0);
			internal const int SHUFFLE_2131 = (2 << 6) | (1 << 4) | (3 << 2) | (1 << 0);
			internal const int SHUFFLE_2132 = (2 << 6) | (1 << 4) | (3 << 2) | (2 << 0);
			internal const int SHUFFLE_2133 = (2 << 6) | (1 << 4) | (3 << 2) | (3 << 0);
			internal const int SHUFFLE_2200 = (2 << 6) | (2 << 4) | (0 << 2) | (0 << 0);
			internal const int SHUFFLE_2201 = (2 << 6) | (2 << 4) | (0 << 2) | (1 << 0);
			internal const int SHUFFLE_2202 = (2 << 6) | (2 << 4) | (0 << 2) | (2 << 0);
			internal const int SHUFFLE_2203 = (2 << 6) | (2 << 4) | (0 << 2) | (3 << 0);
			internal const int SHUFFLE_2210 = (2 << 6) | (2 << 4) | (1 << 2) | (0 << 0);
			internal const int SHUFFLE_2211 = (2 << 6) | (2 << 4) | (1 << 2) | (1 << 0);
			internal const int SHUFFLE_2212 = (2 << 6) | (2 << 4) | (1 << 2) | (2 << 0);
			internal const int SHUFFLE_2213 = (2 << 6) | (2 << 4) | (1 << 2) | (3 << 0);
			internal const int SHUFFLE_2220 = (2 << 6) | (2 << 4) | (2 << 2) | (0 << 0);
			internal const int SHUFFLE_2221 = (2 << 6) | (2 << 4) | (2 << 2) | (1 << 0);
			internal const int SHUFFLE_2222 = (2 << 6) | (2 << 4) | (2 << 2) | (2 << 0);
			internal const int SHUFFLE_2223 = (2 << 6) | (2 << 4) | (2 << 2) | (3 << 0);
			internal const int SHUFFLE_2230 = (2 << 6) | (2 << 4) | (3 << 2) | (0 << 0);
			internal const int SHUFFLE_2231 = (2 << 6) | (2 << 4) | (3 << 2) | (1 << 0);
			internal const int SHUFFLE_2232 = (2 << 6) | (2 << 4) | (3 << 2) | (2 << 0);
			internal const int SHUFFLE_2233 = (2 << 6) | (2 << 4) | (3 << 2) | (3 << 0);
			internal const int SHUFFLE_2300 = (2 << 6) | (3 << 4) | (0 << 2) | (0 << 0);
			internal const int SHUFFLE_2301 = (2 << 6) | (3 << 4) | (0 << 2) | (1 << 0);
			internal const int SHUFFLE_2302 = (2 << 6) | (3 << 4) | (0 << 2) | (2 << 0);
			internal const int SHUFFLE_2303 = (2 << 6) | (3 << 4) | (0 << 2) | (3 << 0);
			internal const int SHUFFLE_2310 = (2 << 6) | (3 << 4) | (1 << 2) | (0 << 0);
			internal const int SHUFFLE_2311 = (2 << 6) | (3 << 4) | (1 << 2) | (1 << 0);
			internal const int SHUFFLE_2312 = (2 << 6) | (3 << 4) | (1 << 2) | (2 << 0);
			internal const int SHUFFLE_2313 = (2 << 6) | (3 << 4) | (1 << 2) | (3 << 0);
			internal const int SHUFFLE_2320 = (2 << 6) | (3 << 4) | (2 << 2) | (0 << 0);
			internal const int SHUFFLE_2321 = (2 << 6) | (3 << 4) | (2 << 2) | (1 << 0);
			internal const int SHUFFLE_2322 = (2 << 6) | (3 << 4) | (2 << 2) | (2 << 0);
			internal const int SHUFFLE_2323 = (2 << 6) | (3 << 4) | (2 << 2) | (3 << 0);
			internal const int SHUFFLE_2330 = (2 << 6) | (3 << 4) | (3 << 2) | (0 << 0);
			internal const int SHUFFLE_2331 = (2 << 6) | (3 << 4) | (3 << 2) | (1 << 0);
			internal const int SHUFFLE_2332 = (2 << 6) | (3 << 4) | (3 << 2) | (2 << 0);
			internal const int SHUFFLE_2333 = (2 << 6) | (3 << 4) | (3 << 2) | (3 << 0);
			internal const int SHUFFLE_3000 = (3 << 6) | (0 << 4) | (0 << 2) | (0 << 0);
			internal const int SHUFFLE_3001 = (3 << 6) | (0 << 4) | (0 << 2) | (1 << 0);
			internal const int SHUFFLE_3002 = (3 << 6) | (0 << 4) | (0 << 2) | (2 << 0);
			internal const int SHUFFLE_3003 = (3 << 6) | (0 << 4) | (0 << 2) | (3 << 0);
			internal const int SHUFFLE_3010 = (3 << 6) | (0 << 4) | (1 << 2) | (0 << 0);
			internal const int SHUFFLE_3011 = (3 << 6) | (0 << 4) | (1 << 2) | (1 << 0);
			internal const int SHUFFLE_3012 = (3 << 6) | (0 << 4) | (1 << 2) | (2 << 0);
			internal const int SHUFFLE_3013 = (3 << 6) | (0 << 4) | (1 << 2) | (3 << 0);
			internal const int SHUFFLE_3020 = (3 << 6) | (0 << 4) | (2 << 2) | (0 << 0);
			internal const int SHUFFLE_3021 = (3 << 6) | (0 << 4) | (2 << 2) | (1 << 0);
			internal const int SHUFFLE_3022 = (3 << 6) | (0 << 4) | (2 << 2) | (2 << 0);
			internal const int SHUFFLE_3023 = (3 << 6) | (0 << 4) | (2 << 2) | (3 << 0);
			internal const int SHUFFLE_3030 = (3 << 6) | (0 << 4) | (3 << 2) | (0 << 0);
			internal const int SHUFFLE_3031 = (3 << 6) | (0 << 4) | (3 << 2) | (1 << 0);
			internal const int SHUFFLE_3032 = (3 << 6) | (0 << 4) | (3 << 2) | (2 << 0);
			internal const int SHUFFLE_3033 = (3 << 6) | (0 << 4) | (3 << 2) | (3 << 0);
			internal const int SHUFFLE_3100 = (3 << 6) | (1 << 4) | (0 << 2) | (0 << 0);
			internal const int SHUFFLE_3101 = (3 << 6) | (1 << 4) | (0 << 2) | (1 << 0);
			internal const int SHUFFLE_3102 = (3 << 6) | (1 << 4) | (0 << 2) | (2 << 0);
			internal const int SHUFFLE_3103 = (3 << 6) | (1 << 4) | (0 << 2) | (3 << 0);
			internal const int SHUFFLE_3110 = (3 << 6) | (1 << 4) | (1 << 2) | (0 << 0);
			internal const int SHUFFLE_3111 = (3 << 6) | (1 << 4) | (1 << 2) | (1 << 0);
			internal const int SHUFFLE_3112 = (3 << 6) | (1 << 4) | (1 << 2) | (2 << 0);
			internal const int SHUFFLE_3113 = (3 << 6) | (1 << 4) | (1 << 2) | (3 << 0);
			internal const int SHUFFLE_3120 = (3 << 6) | (1 << 4) | (2 << 2) | (0 << 0);
			internal const int SHUFFLE_3121 = (3 << 6) | (1 << 4) | (2 << 2) | (1 << 0);
			internal const int SHUFFLE_3122 = (3 << 6) | (1 << 4) | (2 << 2) | (2 << 0);
			internal const int SHUFFLE_3123 = (3 << 6) | (1 << 4) | (2 << 2) | (3 << 0);
			internal const int SHUFFLE_3130 = (3 << 6) | (1 << 4) | (3 << 2) | (0 << 0);
			internal const int SHUFFLE_3131 = (3 << 6) | (1 << 4) | (3 << 2) | (1 << 0);
			internal const int SHUFFLE_3132 = (3 << 6) | (1 << 4) | (3 << 2) | (2 << 0);
			internal const int SHUFFLE_3133 = (3 << 6) | (1 << 4) | (3 << 2) | (3 << 0);
			internal const int SHUFFLE_3200 = (3 << 6) | (2 << 4) | (0 << 2) | (0 << 0);
			internal const int SHUFFLE_3201 = (3 << 6) | (2 << 4) | (0 << 2) | (1 << 0);
			internal const int SHUFFLE_3202 = (3 << 6) | (2 << 4) | (0 << 2) | (2 << 0);
			internal const int SHUFFLE_3203 = (3 << 6) | (2 << 4) | (0 << 2) | (3 << 0);
			internal const int SHUFFLE_3210 = (3 << 6) | (2 << 4) | (1 << 2) | (0 << 0);
			internal const int SHUFFLE_3211 = (3 << 6) | (2 << 4) | (1 << 2) | (1 << 0);
			internal const int SHUFFLE_3212 = (3 << 6) | (2 << 4) | (1 << 2) | (2 << 0);
			internal const int SHUFFLE_3213 = (3 << 6) | (2 << 4) | (1 << 2) | (3 << 0);
			internal const int SHUFFLE_3220 = (3 << 6) | (2 << 4) | (2 << 2) | (0 << 0);
			internal const int SHUFFLE_3221 = (3 << 6) | (2 << 4) | (2 << 2) | (1 << 0);
			internal const int SHUFFLE_3222 = (3 << 6) | (2 << 4) | (2 << 2) | (2 << 0);
			internal const int SHUFFLE_3223 = (3 << 6) | (2 << 4) | (2 << 2) | (3 << 0);
			internal const int SHUFFLE_3230 = (3 << 6) | (2 << 4) | (3 << 2) | (0 << 0);
			internal const int SHUFFLE_3231 = (3 << 6) | (2 << 4) | (3 << 2) | (1 << 0);
			internal const int SHUFFLE_3232 = (3 << 6) | (2 << 4) | (3 << 2) | (2 << 0);
			internal const int SHUFFLE_3233 = (3 << 6) | (2 << 4) | (3 << 2) | (3 << 0);
			internal const int SHUFFLE_3300 = (3 << 6) | (3 << 4) | (0 << 2) | (0 << 0);
			internal const int SHUFFLE_3301 = (3 << 6) | (3 << 4) | (0 << 2) | (1 << 0);
			internal const int SHUFFLE_3302 = (3 << 6) | (3 << 4) | (0 << 2) | (2 << 0);
			internal const int SHUFFLE_3303 = (3 << 6) | (3 << 4) | (0 << 2) | (3 << 0);
			internal const int SHUFFLE_3310 = (3 << 6) | (3 << 4) | (1 << 2) | (0 << 0);
			internal const int SHUFFLE_3311 = (3 << 6) | (3 << 4) | (1 << 2) | (1 << 0);
			internal const int SHUFFLE_3312 = (3 << 6) | (3 << 4) | (1 << 2) | (2 << 0);
			internal const int SHUFFLE_3313 = (3 << 6) | (3 << 4) | (1 << 2) | (3 << 0);
			internal const int SHUFFLE_3320 = (3 << 6) | (3 << 4) | (2 << 2) | (0 << 0);
			internal const int SHUFFLE_3321 = (3 << 6) | (3 << 4) | (2 << 2) | (1 << 0);
			internal const int SHUFFLE_3322 = (3 << 6) | (3 << 4) | (2 << 2) | (2 << 0);
			internal const int SHUFFLE_3323 = (3 << 6) | (3 << 4) | (2 << 2) | (3 << 0);
			internal const int SHUFFLE_3330 = (3 << 6) | (3 << 4) | (3 << 2) | (0 << 0);
			internal const int SHUFFLE_3331 = (3 << 6) | (3 << 4) | (3 << 2) | (1 << 0);
			internal const int SHUFFLE_3332 = (3 << 6) | (3 << 4) | (3 << 2) | (2 << 0);
			internal const int SHUFFLE_3333 = (3 << 6) | (3 << 4) | (3 << 2) | (3 << 0);
		}

        private const int FROUND_TO_NEAREST_INT = 0x00;
        private const int FROUND_TO_NEG_INF = 0x01;
        private const int FROUND_TO_POS_INF = 0x02;
        private const int FROUND_TO_ZERO = 0x03;
        private const int FROUND_CUR_DIRECTION = 0x04;
        private const int FROUND_NO_EXC = 0x08;
        private const int FROUND_RAISE_EXC = 0x00;
        private const int FROUND_NINT = FROUND_TO_NEAREST_INT | FROUND_RAISE_EXC;
        private const int FROUND_FLOOR = FROUND_TO_NEG_INF | FROUND_RAISE_EXC;
        private const int FROUND_CEIL = FROUND_TO_POS_INF | FROUND_RAISE_EXC;
        private const int FROUND_TRUNC = FROUND_TO_ZERO | FROUND_RAISE_EXC;
        private const int FROUND_RINT = FROUND_CUR_DIRECTION | FROUND_RAISE_EXC;
        private const int FROUND_NEARBYINT = FROUND_CUR_DIRECTION | FROUND_NO_EXC;
        private const int ROUND_NEAREST = 0x0000;
        private const int ROUND_DOWN = 0x2000;
        private const int ROUND_UP = 0x4000;
        private const int ROUND_TOWARD_ZERO = 0x6000;
        private const int FLUSH_ZERO_MASK = 0x8000;
        private const int FLUSH_ZERO_ON = 0x8000;
        private const int FLUSH_ZERO_OFF = 0x0000;
        private const int DENORMALS_ZERO_MASK = 0x0040;
        private const int DENORMALS_ZERO_ON = 0x0040;
        private const int DENORMALS_ZERO_OFF = 0x0000;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 loadu_si128(void* ptr)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.loadu_si128(ptr);
			}
            else if (IsNeonSupported)
            {
                return vld1q_s32((int*)ptr);
            }
			else throw new IllegalInstructionException();
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cvtsi64_ss(v128 a, long b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.cvtsi64_ss(a, b);
			}
            else if (IsNeonSupported)
            {
                return Xse.imm8.Arm.vsetq_lane_f32((float)b, a, 0);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 add_ss(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.add_ss(a, b);
			}
            else if (IsNeonSupported)
            {
                float b0 = Xse.imm8.Arm.vgetq_lane_f32(b, 0);
                v128 value = Xse.imm8.Arm.vsetq_lane_f32(b0, vdupq_n_f32(0), 0);
                return vaddq_f32(a, value);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 add_ps(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.add_ps(a, b);
			}
            else if (IsNeonSupported)
            {
                return vaddq_f32(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 sub_ss(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.sub_ss(a, b);
			}
            else if (IsNeonSupported)
            {
                return move_ss(a, sub_ps(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 sub_ps(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.sub_ps(a, b);
			}
            else if (IsNeonSupported)
            {
                return vsubq_f32(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 mul_ss(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.mul_ss(a, b);
			}
            else if (IsNeonSupported)
            {
                return move_ss(a, mul_ps(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 mul_ps(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.mul_ps(a, b);
			}
            else if (IsNeonSupported)
            {
                return vmulq_f32(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 div_ss(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.div_ss(a, b);
			}
            else if (IsNeonSupported)
            {
                float value = Xse.imm8.Arm.vgetq_lane_f32(div_ps(a, b), 0);
                return Xse.imm8.Arm.vsetq_lane_f32(value, a, 0);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 div_ps(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.div_ps(a, b);
			}
            else if (IsNeonSupported)
            {
            #if !SSE2NEON_PRECISE_DIV
                return vdivq_f32(a, b);
            #else
                v128 recip = vrecpeq_f32(b);
                recip = vmulq_f32(recip, vrecpsq_f32(recip, b));
                recip = vmulq_f32(recip, vrecpsq_f32(recip, b));
                return vmulq_f32(a, recip);
            #endif
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 sqrt_ss(v128 a)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.sqrt_ss(a);
			}
            else if (IsNeonSupported)
            {
                float value = Xse.imm8.Arm.vgetq_lane_f32(sqrt_ps(a), 0);
                return Xse.imm8.Arm.vsetq_lane_f32(value, a, 0);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 sqrt_ps(v128 a)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.sqrt_ps(a);
			}
            else if (IsNeonSupported)
            {
            #if !SSE2NEON_PRECISE_SQRT
                return vsqrtq_f32(a);
            #else
                v128 recip = vrsqrteq_f32(a);
                v128 pos_inf = vdupq_n_u32(0x7F800000);
                v128 div_by_zero = vceqq_u32(pos_inf, recip);
                recip = vandq_u32(vmvnq_u32(div_by_zero), recip);
                recip = vmulq_f32(vrsqrtsq_f32(vmulq_f32(recip, recip), a), recip);
                recip = vmulq_f32(vrsqrtsq_f32(vmulq_f32(recip, recip), a), recip);
                return vmulq_f32(a, recip);
            #endif
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 rcp_ss(v128 a)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.rcp_ss(a);
			}
            else if (IsNeonSupported)
            {
                return move_ss(a, rcp_ps(a));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 rcp_ps(v128 a)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.rcp_ps(a);
			}
            else if (IsNeonSupported)
            {
                v128 recip = vrecpeq_f32(a);
			#if SSE2NEON_PRECISE_RCP
                recip = vmulq_f32(recip, vrecpsq_f32(recip, a));
			#endif
                return recip;
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 rsqrt_ss(v128 a)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.rsqrt_ss(a);
			}
            else if (IsNeonSupported)
            {
                return Xse.imm8.Arm.vsetq_lane_f32(Xse.imm8.Arm.vgetq_lane_f32(rsqrt_ps(a), 0), a, 0);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 rsqrt_ps(v128 a)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.rsqrt_ps(a);
			}
            else if (IsNeonSupported)
            {
                v128 r = vrsqrteq_f32(a);
			#if SSE2NEON_PRECISE_RSQRT
                v128 pos_inf = vdupq_n_u32(0x7F800000);
                v128 neg_inf = vdupq_n_u32(0xFF800000);
                v128 has_pos_zero = vceqq_u32(pos_inf, r);
                v128 has_neg_zero = vceqq_u32(neg_inf, r);
                r = vmulq_f32(r, vrsqrtsq_f32(vmulq_f32(a, r), r));
                r = vbslq_f32(has_pos_zero, pos_inf, r);
                r = vbslq_f32(has_neg_zero, neg_inf, r);
			#endif
                return r;
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 min_ss(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.min_ss(a, b);
			}
            else if (IsNeonSupported)
            {
                float value = Xse.imm8.Arm.vgetq_lane_f32(min_ps(a, b), 0);
                return Xse.imm8.Arm.vsetq_lane_f32(value, a, 0);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 min_ps(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.min_ps(a, b);
			}
            else if (IsNeonSupported)
            {
            #if SSE2NEON_PRECISE_MINMAX
                return vbslq_f32(vcltq_f32(a, b), a, b);
            #else
                return vminq_f32(a, b);
            #endif
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 max_ss(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.max_ss(a, b);
			}
            else if (IsNeonSupported)
            {
                float value = Xse.imm8.Arm.vgetq_lane_f32(max_ps(a, b), 0);
                return Xse.imm8.Arm.vsetq_lane_f32(value, a, 0);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 max_ps(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.max_ps(a, b);
			}
            else if (IsNeonSupported)
            {
            #if SSE2NEON_PRECISE_MINMAX
                return vbslq_f32(vcgtq_f32(a, b), a, b);
            #else
                return vmaxq_f32(a, b);
            #endif
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 and_ps(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.and_ps(a, b);
			}
            else if (IsNeonSupported)
            {
                return vandq_s32(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 andnot_ps(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.andnot_ps(a, b);
			}
            else if (IsNeonSupported)
            {
                return vbicq_s32(b, a);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 or_ps(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.or_ps(a, b);
			}
            else if (IsNeonSupported)
            {
                return vorrq_s32(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 xor_ps(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.xor_ps(a, b);
			}
            else if (IsNeonSupported)
            {
                return veorq_s32(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpeq_ss(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.cmpeq_ss(a, b);
			}
            else if (IsNeonSupported)
            {
                return move_ss(a, cmpeq_ps(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpeq_ps(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.cmpeq_ps(a, b);
			}
            else if (IsNeonSupported)
            {
                return vceqq_f32(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmplt_ss(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.cmplt_ss(a, b);
			}
            else if (IsNeonSupported)
            {
                return move_ss(a, cmplt_ps(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmplt_ps(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.cmplt_ps(a, b);
			}
            else if (IsNeonSupported)
            {
                return vcltq_f32(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmple_ss(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.cmple_ss(a, b);
			}
            else if (IsNeonSupported)
            {
                return move_ss(a, cmple_ps(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmple_ps(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.cmple_ps(a, b);
			}
            else if (IsNeonSupported)
            {
                return vcleq_f32(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpgt_ss(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.cmpgt_ss(a, b);
			}
            else if (IsNeonSupported)
            {
                return move_ss(a, cmpgt_ps(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpgt_ps(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.cmpgt_ps(a, b);
			}
            else if (IsNeonSupported)
            {
                return vcgtq_f32(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpge_ss(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.cmpge_ss(a, b);
			}
            else if (IsNeonSupported)
            {
                return move_ss(a, cmpge_ps(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpge_ps(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.cmpge_ps(a, b);
			}
            else if (IsNeonSupported)
            {
                return vcgeq_f32(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpneq_ss(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.cmpneq_ss(a, b);
			}
            else if (IsNeonSupported)
            {
                return move_ss(a, cmpneq_ps(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpneq_ps(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.cmpneq_ps(a, b);
			}
            else if (IsNeonSupported)
            {
                return vmvnq_u32(vceqq_f32(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpnlt_ss(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.cmpnlt_ss(a, b);
			}
            else if (IsNeonSupported)
            {
                return move_ss(a, cmpnlt_ps(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpnlt_ps(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.cmpnlt_ps(a, b);
			}
            else if (IsNeonSupported)
            {
                return vmvnq_u32(vcltq_f32(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpnle_ss(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.cmpnle_ss(a, b);
			}
            else if (IsNeonSupported)
            {
                return move_ss(a, cmpnle_ps(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpnle_ps(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.cmpnle_ps(a, b);
			}
            else if (IsNeonSupported)
            {
                return vmvnq_u32(vcleq_f32(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpngt_ss(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.cmpngt_ss(a, b);
			}
            else if (IsNeonSupported)
            {
                return move_ss(a, cmpngt_ps(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpngt_ps(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.cmpngt_ps(a, b);
			}
            else if (IsNeonSupported)
            {
                return vmvnq_u32(vcgtq_f32(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpnge_ss(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.cmpnge_ss(a, b);
			}
            else if (IsNeonSupported)
            {
                return move_ss(a, cmpnge_ps(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpnge_ps(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.cmpnge_ps(a, b);
			}
            else if (IsNeonSupported)
            {
                return vmvnq_u32(vcgeq_f32(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpord_ss(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.cmpord_ss(a, b);
			}
            else if (IsNeonSupported)
            {
                return move_ss(a, cmpord_ps(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpord_ps(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.cmpord_ps(a, b);
			}
            else if (IsNeonSupported)
            {
                v128 ceqaa = vceqq_f32(a, a);
                v128 ceqbb = vceqq_f32(b, b);
                return vandq_u32(ceqaa, ceqbb);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpunord_ss(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.cmpunord_ss(a, b);
			}
            else if (IsNeonSupported)
            {
                return move_ss(a, cmpunord_ps(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpunord_ps(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.cmpunord_ps(a, b);
			}
            else if (IsNeonSupported)
            {
                v128 f32a = vceqq_f32(a, a);
                v128 f32b = vceqq_f32(b, b);
                return vmvnq_u32(vandq_u32(f32a, f32b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int comieq_ss(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.comieq_ss(a, b);
			}
            else if (IsNeonSupported)
            {
                v128 a_eq_b = vceqq_f32(a, b);
                return (int)Xse.imm8.Arm.vgetq_lane_u32(a_eq_b, 0) & 0x1;
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int comilt_ss(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.comilt_ss(a, b);
			}
            else if (IsNeonSupported)
            {
                v128 a_lt_b = vcltq_f32(a, b);
                return (int)Xse.imm8.Arm.vgetq_lane_u32(a_lt_b, 0) & 0x1;
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int comile_ss(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.comile_ss(a, b);
			}
            else if (IsNeonSupported)
            {
                v128 a_le_b = vcleq_f32(a, b);
                return (int)Xse.imm8.Arm.vgetq_lane_u32(a_le_b, 0) & 0x1;
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int comigt_ss(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.comigt_ss(a, b);
			}
            else if (IsNeonSupported)
            {
                v128 a_gt_b = vcgtq_f32(a, b);
                return (int)Xse.imm8.Arm.vgetq_lane_u32(a_gt_b, 0) & 0x1;
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int comige_ss(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.comige_ss(a, b);
			}
            else if (IsNeonSupported)
            {
                v128 a_ge_b = vcgeq_f32(a, b);
                return (int)Xse.imm8.Arm.vgetq_lane_u32(a_ge_b, 0) & 0x1;
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int comineq_ss(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.comineq_ss(a, b);
			}
            else if (IsNeonSupported)
            {
                return comieq_ss(a, b) ^ 0x1;
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int cvt_ss2si(v128 a)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.cvt_ss2si(a);
			}
            else if (IsNeonSupported)
            {
                return Xse.imm8.Arm.vgetq_lane_s32(vcvtnq_s32_f32(vrndiq_f32(a)), 0);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long cvtss_si64(v128 a)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.cvtss_si64(a);
			}
            else if (IsNeonSupported)
            {
                return (long)Xse.imm8.Arm.vgetq_lane_f32(vrndiq_f32(a), 0);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float cvtss_f32(v128 a)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.cvtss_f32(a);
			}
            else if (IsNeonSupported)
            {
                return Xse.imm8.Arm.vgetq_lane_f32(a, 0);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int cvtt_ss2si(v128 a)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.cvtt_ss2si(a);
			}
            else if (IsNeonSupported)
            {
                return Xse.imm8.Arm.vgetq_lane_s32(vcvtq_s32_f32(a), 0);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long cvttss_si64(v128 a)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.cvttss_si64(a);
			}
            else if (IsNeonSupported)
            {
                return (long)Xse.imm8.Arm.vgetq_lane_f32(a, 0);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 set_ss(float a)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.set_ss(a);
			}
            else if (IsNeonSupported)
            {
                return Xse.imm8.Arm.vsetq_lane_f32(a, vdupq_n_f32(0), 0);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 set_ps(float e3, float e2, float e1, float e0)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.set_ps(e3, e2, e1, e0);
			}
			else if (IsNeonSupported)
			{
				return new v128(e0, e1, e2, e3);
			}
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 setr_ps(float e3, float e2, float e1, float e0)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.setr_ps(e3, e2, e1, e0);
			}
			else if (IsNeonSupported)
			{
				return new v128(e3, e2, e1, e0);
			}
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 move_ss(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.move_ss(a, b);
			}
            else if (IsNeonSupported)
            {
                return Xse.imm8.Arm.vsetq_lane_f32(Xse.imm8.Arm.vgetq_lane_f32(b, 0), a, 0);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int SHUFFLE(int d, int c, int b, int a)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.SHUFFLE(d, c, b, a);
			}
			else if (IsNeonSupported)
			{
				return (d << 6) | (c << 4) | (b << 2) | a;
			}
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 shuffle_ps(v128 a, v128 b, int imm8)
		{
			if (Sse2.IsSse2Supported)
			{
				return Xse.imm8.X86.shuffle_ps(a, b, imm8);
			}
            else if (IsNeonSupported)
            {
                switch (imm8)
                {
                    case Xse.imm8.SHUFFLE_1032:
                    {
                        v64 a32 = vget_high_f32(a);
                        v64 b10 = vget_low_f32(b);
                        return vcombine_f32(a32, b10);
                    }
                    case Xse.imm8.SHUFFLE_2301:
                    {
                        v64 a01 = vrev64_f32(vget_low_f32(a));
                        v64 b23 = vrev64_f32(vget_high_f32(b));
                        return vcombine_f32(a01, b23);
                    }
                    case Xse.imm8.SHUFFLE_0321:
                    {
                        v64 a21 = vget_high_f32(Xse.imm8.Arm.vextq_f32(a, a, 3));
                        v64 b03 = vget_low_f32(Xse.imm8.Arm.vextq_f32(b, b, 3));
                        return vcombine_f32(a21, b03);
                    }
                    case Xse.imm8.SHUFFLE_2103:
                    {
                        v64 a03 = vget_low_f32(Xse.imm8.Arm.vextq_f32(a, a, 3));
                        v64 b21 = vget_high_f32(Xse.imm8.Arm.vextq_f32(b, b, 3));
                        return vcombine_f32(a03, b21);
                    }
                    case Xse.imm8.SHUFFLE_1010:
                    {
                        return movelh_ps(a, b);
                    }
                    case Xse.imm8.SHUFFLE_1001:
                    {
                        v64 a01 = vrev64_f32(vget_low_f32(a));
                        v64 b10 = vget_low_f32(b);
                        return vcombine_f32(a01, b10);
                    }
                    case Xse.imm8.SHUFFLE_0101:
                    {
                        v64 a01 = vrev64_f32(vget_low_f32(a));
                        v64 b01 = vrev64_f32(vget_low_f32(b));
                        return vcombine_f32(a01, b01);
                    }
                    case Xse.imm8.SHUFFLE_3210:
                    {
                        v64 a10 = vget_low_f32(a);
                        v64 b32 = vget_high_f32(b);
                        return vcombine_f32(a10, b32);
                    }
                    case Xse.imm8.SHUFFLE_0011:
                    {
                        v64 a11 = vdup_lane_f32(vget_low_f32(a), 1);
                        v64 b00 = vdup_lane_f32(vget_low_f32(b), 0);
                        return vcombine_f32(a11, b00);
                    }
                    case Xse.imm8.SHUFFLE_0022:
                    {
                        v64 a22 = vdup_lane_f32(vget_high_f32(a), 0);
                        v64 b00 = vdup_lane_f32(vget_low_f32(b), 0);
                        return vcombine_f32(a22, b00);
                    }
                    case Xse.imm8.SHUFFLE_2200:
                    {
                        v64 a00 = vdup_lane_f32(vget_low_f32(a), 0);
                        v64 b22 = vdup_lane_f32(vget_high_f32(b), 0);
                        return vcombine_f32(a00, b22);
                    }
                    case Xse.imm8.SHUFFLE_3202:
                    {
                        float a0 = Xse.imm8.Arm.vgetq_lane_f32(a, 0);
                        v64 a22 = vdup_lane_f32(vget_high_f32(a), 0);
                        v64 a02 = Xse.imm8.Arm.vset_lane_f32(a0, a22, 1);
                        v64 b32 = vget_high_f32(b);
                        return vcombine_f32(a02, b32);
                    }
                    case Xse.imm8.SHUFFLE_3232:
                    {
                        return movehl_ps(b, a);
                    }
                    case Xse.imm8.SHUFFLE_1133:
                    {
                        v64 a33 = vdup_lane_f32(vget_high_f32(a), 1);
                        v64 b11 = vdup_lane_f32(vget_low_f32(b), 1);
                        return vcombine_f32(a33, b11);
                    }
                    case Xse.imm8.SHUFFLE_2010:
                    {
                        v64 a10 = vget_low_f32(a);
                        float b2 = Xse.imm8.Arm.vgetq_lane_f32(b, 2);
                        v64 b00 = vdup_lane_f32(vget_low_f32(b), 0);
                        v64 b20 = Xse.imm8.Arm.vset_lane_f32(b2, b00, 1);
                        return vcombine_f32(a10, b20);
                    }
                    case Xse.imm8.SHUFFLE_2001:
                    {
                        v64 a01 = vrev64_f32(vget_low_f32(a));
                        float b2 = Xse.imm8.Arm.vgetq_lane_f32(b, 2);
                        v64 b00 = vdup_lane_f32(vget_low_f32(b), 0);
                        v64 b20 = Xse.imm8.Arm.vset_lane_f32(b2, b00, 1);
                        return vcombine_f32(a01, b20);
                    }
                    case Xse.imm8.SHUFFLE_2032:
                    {
                        v64 a32 = vget_high_f32(a);
                        float b2 = Xse.imm8.Arm.vgetq_lane_f32(b, 2);
                        v64 b00 = vdup_lane_f32(vget_low_f32(b), 0);
                        v64 b20 = Xse.imm8.Arm.vset_lane_f32(b2, b00, 1);
                        return vcombine_f32(a32, b20);
                    }
                    default:
                    {
                        return Xse.imm8.Arm.vsetq_lane_f32(Xse.imm8.Arm.vgetq_lane_f32(b, (imm8 >> 6) & 0x3), Xse.imm8.Arm.vsetq_lane_f32(Xse.imm8.Arm.vgetq_lane_f32(b, (imm8 >> 4) & 0x3), Xse.imm8.Arm.vsetq_lane_f32(Xse.imm8.Arm.vgetq_lane_f32(a, (imm8 >> 2) & 0x3), vmovq_n_f32(Xse.imm8.Arm.vgetq_lane_f32(a, imm8 & (0x3))), 1), 2), 3);
                    }
                }
			}
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 unpackhi_ps(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.unpackhi_ps(a, b);
			}
            else if (IsNeonSupported)
            {
                return vzip2q_f32(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 unpacklo_ps(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.unpacklo_ps(a, b);
			}
            else if (IsNeonSupported)
            {
                return vzip1q_f32(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 movehl_ps(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.movehl_ps(a, b);
			}
            else if (IsNeonSupported)
            {
                return vzip2q_u64(b, a);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 movelh_ps(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.movelh_ps(a, b);
			}
            else if (IsNeonSupported)
            {
                v64 a10 = vget_low_f32(a);
                v64 b10 = vget_low_f32(b);
                return vcombine_f32(a10, b10);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int movemask_ps(v128 a)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.movemask_ps(a);
			}
            else if (IsNeonSupported)
            {
                v128 tmp = vshrq_n_u32(a, 31);
                return (int)vaddvq_u32(vshlq_u32(tmp, new v128(0, 1, 2, 3)));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 setzero_ps()
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse.setzero_ps();
			}
            else if (IsNeonSupported)
            {
                return vdupq_n_f32(0);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long cvtsd_si64(v128 a)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cvtsd_si64(a);
			}
            else if (IsNeonSupported)
            {
                return (long)Xse.imm8.Arm.vgetq_lane_f64(vrndiq_f64(a), 0);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long cvttsd_si64(v128 a)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cvttsd_si64(a);
			}
            else if (IsNeonSupported)
            {
                return Xse.imm8.Arm.vgetq_lane_s64(vcvtq_s64_f64(a), 0);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 add_epi8(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.add_epi8(a, b);
			}
            else if (IsNeonSupported)
            {
                return vaddq_s8(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 add_epi16(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.add_epi16(a, b);
			}
            else if (IsNeonSupported)
            {
                return vaddq_s16(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 add_epi32(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.add_epi32(a, b);
			}
            else if (IsNeonSupported)
            {
                return vaddq_s32(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 add_epi64(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.add_epi64(a, b);
			}
            else if (IsNeonSupported)
            {
                return vaddq_s64(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 madd_epi16(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.madd_epi16(a, b);
			}
            else if (IsNeonSupported)
            {
                v128 low = vmull_s16(vget_low_s16(a), vget_low_s16(b));
                v128 high = vmull_high_s16(a, b);
                return vpaddq_s32(low, high);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 sad_epu8(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.sad_epu8(a, b);
			}
            else if (IsNeonSupported)
            {
                v128 t = vpaddlq_u8(vabdq_u8(a, b));
                return vpaddlq_u32(vpaddlq_u16(t));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 sub_epi8(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.sub_epi8(a, b);
			}
            else if (IsNeonSupported)
            {
                return vsubq_s8(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 sub_epi16(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.sub_epi16(a, b);
			}
            else if (IsNeonSupported)
            {
                return vsubq_s16(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 sub_epi32(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.sub_epi32(a, b);
			}
            else if (IsNeonSupported)
            {
                return vsubq_s32(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 sub_epi64(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.sub_epi64(a, b);
			}
            else if (IsNeonSupported)
            {
                return vsubq_s64(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 and_si128(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.and_si128(a, b);
			}
            else if (IsNeonSupported)
            {
                return vandq_s32(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 andnot_si128(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.andnot_si128(a, b);
			}
            else if (IsNeonSupported)
            {
                return vbicq_s32(b, a);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 or_si128(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.or_si128(a, b);
			}
            else if (IsNeonSupported)
            {
                return vorrq_s32(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 xor_si128(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.xor_si128(a, b);
			}
            else if (IsNeonSupported)
            {
                return veorq_s32(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpeq_epi8(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cmpeq_epi8(a, b);
			}
            else if (IsNeonSupported)
            {
                return vceqq_s8(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpeq_epi16(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cmpeq_epi16(a, b);
			}
            else if (IsNeonSupported)
            {
                return vceqq_s16(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpeq_epi32(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cmpeq_epi32(a, b);
			}
            else if (IsNeonSupported)
            {
                return vceqq_s32(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpgt_epi8(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cmpgt_epi8(a, b);
			}
            else if (IsNeonSupported)
            {
                return vcgtq_s8(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpgt_epi16(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cmpgt_epi16(a, b);
			}
            else if (IsNeonSupported)
            {
                return vcgtq_s16(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpgt_epi32(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cmpgt_epi32(a, b);
			}
            else if (IsNeonSupported)
            {
                return vcgtq_s32(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 setzero_si128()
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.setzero_si128();
			}
            else if (IsNeonSupported)
            {
                return vdupq_n_s32(0);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cvtepi32_pd(v128 a)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cvtepi32_pd(a);
			}
            else if (IsNeonSupported)
            {
                return vcvtq_f64_s64(vmovl_s32(vget_low_s32(a)));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cvtsi32_sd(v128 a, int b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cvtsi32_sd(a, b);
			}
            else if (IsNeonSupported)
            {
                return Xse.imm8.Arm.vsetq_lane_f64((double)b, a, 0);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cvtsi64x_sd(v128 a, long b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cvtsi64x_sd(a, b);
			}
            else if (IsNeonSupported)
            {
                return Xse.imm8.Arm.vsetq_lane_f64((double)b, a, 0);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cvtepi32_ps(v128 a)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cvtepi32_ps(a);
			}
            else if (IsNeonSupported)
            {
                return vcvtq_f32_s32(a);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int cvtsi128_si32(v128 a)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cvtsi128_si32(a);
			}
            else if (IsNeonSupported)
            {
                return Xse.imm8.Arm.vgetq_lane_s32(a, 0);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long cvtsi128_si64x(v128 a)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cvtsi128_si64x(a);
			}
            else if (IsNeonSupported)
            {
                return Xse.imm8.Arm.vgetq_lane_s64(a, 0);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 set_epi64x(long e1, long e0)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.set_epi64x(e1, e0);
			}
            else if (IsNeonSupported)
            {
                return vcombine_s64(vcreate_s64((ulong)e0), vcreate_s64((ulong)e1));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 set_epi32(int e3, int e2, int e1, int e0)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.set_epi32(e3, e2, e1, e0);
			}
			else if (IsNeonSupported)
			{
				return new v128(e0, e1, e2, e3);
			}
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 set_epi16(short e7, short e6, short e5, short e4, short e3, short e2, short e1, short e0)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.set_epi16(e7, e6, e5, e4, e3, e2, e1, e0);
			}
			else if (IsNeonSupported)
			{
				return new v128(e0, e1, e2, e3, e4, e5, e6, e7);
			}
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 set_epi8(sbyte e15_, sbyte e14_, sbyte e13_, sbyte e12_, sbyte e11_, sbyte e10_, sbyte e9_, sbyte e8_, sbyte e7_, sbyte e6_, sbyte e5_, sbyte e4_, sbyte e3_, sbyte e2_, sbyte e1_, sbyte e0_)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.set_epi8(e15_, e14_, e13_, e12_, e11_, e10_, e9_, e8_, e7_, e6_, e5_, e4_, e3_, e2_, e1_, e0_);
			}
			else if (IsNeonSupported)
			{
				return new v128(e0_,  e1_,  e2_,  e3_,
				                e4_,  e5_,  e6_,  e7_,
				                e8_,  e9_,  e10_, e11_,
				                e12_, e13_, e14_, e15_);
			}
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 setr_epi32(int e3, int e2, int e1, int e0)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.setr_epi32(e3, e2, e1, e0);
			}
            else if (IsNeonSupported)
			{
				return new v128(e3, e2, e1, e0);
			}
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 setr_epi16(short e7, short e6, short e5, short e4, short e3, short e2, short e1, short e0)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.setr_epi16(e7, e6, e5, e4, e3, e2, e1, e0);
			}
            else if (IsNeonSupported)
			{
				return new v128(e7, e6, e5, e4, e3, e2, e1, e0);
			}
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 setr_epi8(sbyte e15_, sbyte e14_, sbyte e13_, sbyte e12_, sbyte e11_, sbyte e10_, sbyte e9_, sbyte e8_, sbyte e7_, sbyte e6_, sbyte e5_, sbyte e4_, sbyte e3_, sbyte e2_, sbyte e1_, sbyte e0_)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.setr_epi8(e15_, e14_, e13_, e12_, e11_, e10_, e9_, e8_, e7_, e6_, e5_, e4_, e3_, e2_, e1_, e0_);
			}
            else if (IsNeonSupported)
			{
				return new v128(e15_, e14_, e13_, e12_,
				                e11_, e10_, e9_,  e8_,
				                e7_,  e6_,  e5_,  e4_,
				                e3_,  e2_,  e1_,  e0_);
			}
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 move_epi64(v128 a)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.move_epi64(a);
			}
            else if (IsNeonSupported)
            {
                return Xse.imm8.Arm.vsetq_lane_s64(0, a, 1);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 packs_epi16(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.packs_epi16(a, b);
			}
            else if (IsNeonSupported)
            {
                return vcombine_s8(vqmovn_s16(a), vqmovn_s16(b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 packs_epi32(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.packs_epi32(a, b);
			}
            else if (IsNeonSupported)
            {
                return vcombine_s16(vqmovn_s32(a), vqmovn_s32(b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 packus_epi16(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.packus_epi16(a, b);
			}
            else if (IsNeonSupported)
            {
                return vcombine_u8(vqmovun_s16(a), vqmovun_s16(b));
            }
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int movemask_epi8(v128 a)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.movemask_epi8(a);
			}
            else if (IsNeonSupported)
            {
                v128 input = a;
                v128 high_bits = vshrq_n_u8(input, 7);
                v128 paired16 = vsraq_n_u16(high_bits, high_bits, 7);
                v128 paired32 = vsraq_n_u32(paired16, paired16, 14);
                v128 paired64 = vsraq_n_u64(paired32, paired32, 28);
                return Xse.imm8.Arm.vgetq_lane_u8(paired64, 0) | ((int)Xse.imm8.Arm.vgetq_lane_u8(paired64, 8) << 8);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 shuffle_epi32(v128 a, int imm8)
		{
			if (Sse2.IsSse2Supported)
			{
				return Xse.imm8.X86.shuffle_epi32(a, imm8);
			}
            else if (IsNeonSupported)
            {
                switch (imm8)
                {
                    case Xse.imm8.SHUFFLE_1032:
                    {
                        v64 a32 = vget_high_s32(a);
                        v64 a10 = vget_low_s32(a);
                        return vcombine_s32(a32, a10);
                    }
                    case Xse.imm8.SHUFFLE_2301:
                    {
                        v64 a01 = vrev64_s32(vget_low_s32(a));
                        v64 a23 = vrev64_s32(vget_high_s32(a));
                        return vcombine_s32(a01, a23);
                    }
                    case Xse.imm8.SHUFFLE_0321:
                    {
                        return Xse.imm8.Arm.vextq_s32(a, a, 1);
                    }
                    case Xse.imm8.SHUFFLE_2103:
                    {
                        return Xse.imm8.Arm.vextq_s32(a, a, 3);
                    }
                    case Xse.imm8.SHUFFLE_1010:
                    {
                        return vdupq_laneq_s64(a, 0);
                    }
                    case Xse.imm8.SHUFFLE_3232:
                    {
                        return vdupq_laneq_s64(a, 1);
                    }
                    case Xse.imm8.SHUFFLE_1001:
                    {
                        v64 a01 = vrev64_s32(vget_low_s32(a));
                        v64 a10 = vget_low_s32(a);
                        return vcombine_s32(a01, a10);
                    }
                    case Xse.imm8.SHUFFLE_0101:
                    {
                        v64 a01 = vrev64_s32(vget_low_s32(a));
                        return vcombine_s32(a01, a01);
                    }
                    case Xse.imm8.SHUFFLE_2211:
                    {
                        v64 a11 = vdup_lane_s32(vget_low_s32(a), 1);
                        v64 a22 = vdup_lane_s32(vget_high_s32(a), 0);
                        return vcombine_s32(a11, a22);
                    }
                    case Xse.imm8.SHUFFLE_0122:
                    {
                        v64 a22 = vdup_lane_s32(vget_high_s32(a), 0);
                        v64 a01 = vrev64_s32(vget_low_s32(a));
                        return vcombine_s32(a22, a01);
                    }
                    case Xse.imm8.SHUFFLE_3332:
                    {
                        v64 a32 = vget_high_s32(a);
                        v64 a33 = vdup_lane_s32(vget_high_s32(a), 1);
                        return vcombine_s32(a32, a33);
                    }
                    case Xse.imm8.SHUFFLE_0000:
                    {
                        return vdupq_laneq_s32(a, 0);
                    }
                    case Xse.imm8.SHUFFLE_1111:
                    {
                        return vdupq_laneq_s32(a, 1);
                    }
                    case Xse.imm8.SHUFFLE_2222:
                    {
                        return vdupq_laneq_s32(a, 2);
                    }
                    case Xse.imm8.SHUFFLE_3333:
                    {
                        return vdupq_laneq_s32(a, 3);
                    }
                    default:
                    {
                        return Xse.imm8.Arm.vsetq_lane_s32(Xse.imm8.Arm.vgetq_lane_s32(a, (imm8 >> 6) & 0x3), Xse.imm8.Arm.vsetq_lane_s32(Xse.imm8.Arm.vgetq_lane_s32(a, (imm8 >> 4) & 0x3), Xse.imm8.Arm.vsetq_lane_s32(Xse.imm8.Arm.vgetq_lane_s32(a, (imm8 >> 2) & 0x3), vmovq_n_s32(Xse.imm8.Arm.vgetq_lane_s32(a, imm8 & (0x3))), 1), 2), 3);
                    }
                }
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 shufflehi_epi16(v128 a, int imm8)
		{
			if (Sse2.IsSse2Supported)
			{
				return Xse.imm8.X86.shufflehi_epi16(a, imm8);
			}
            else if (IsNeonSupported)
            {
                v128 ret = a;
                v64 highBits = vget_high_s16(ret);
                ret = Xse.imm8.Arm.vsetq_lane_s16(Xse.imm8.Arm.vget_lane_s16(highBits, (imm8 >> 0) & 0x3), ret, 0);
                ret = Xse.imm8.Arm.vsetq_lane_s16(Xse.imm8.Arm.vget_lane_s16(highBits, (imm8 >> 2) & 0x3), ret, 1);
                ret = Xse.imm8.Arm.vsetq_lane_s16(Xse.imm8.Arm.vget_lane_s16(highBits, (imm8 >> 4) & 0x3), ret, 2);
                ret = Xse.imm8.Arm.vsetq_lane_s16(Xse.imm8.Arm.vget_lane_s16(highBits, (imm8 >> 6) & 0x3), ret, 3);
                return ret;
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 shufflelo_epi16(v128 a, int imm8)
		{
			if (Sse2.IsSse2Supported)
			{
				return Xse.imm8.X86.shufflelo_epi16(a, imm8);
			}
            else if (IsNeonSupported)
            {
                v128 ret = a;
                v64 lowBits = vget_low_s16(ret);
                ret = Xse.imm8.Arm.vsetq_lane_s16(Xse.imm8.Arm.vget_lane_s16(lowBits, (imm8 >> 0) & 0x3), ret, 0);
                ret = Xse.imm8.Arm.vsetq_lane_s16(Xse.imm8.Arm.vget_lane_s16(lowBits, (imm8 >> 2) & 0x3), ret, 1);
                ret = Xse.imm8.Arm.vsetq_lane_s16(Xse.imm8.Arm.vget_lane_s16(lowBits, (imm8 >> 4) & 0x3), ret, 2);
                ret = Xse.imm8.Arm.vsetq_lane_s16(Xse.imm8.Arm.vget_lane_s16(lowBits, (imm8 >> 6) & 0x3), ret, 3);
                return ret;
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 unpackhi_epi8(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.unpackhi_epi8(a, b);
			}
            else if (IsNeonSupported)
            {
                return vzip2q_s8(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 unpackhi_epi16(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.unpackhi_epi16(a, b);
			}
            else if (IsNeonSupported)
            {
                return vzip2q_s16(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 unpackhi_epi32(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.unpackhi_epi32(a, b);
			}
            else if (IsNeonSupported)
            {
                return vzip2q_s32(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 unpackhi_epi64(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.unpackhi_epi64(a, b);
			}
            else if (IsNeonSupported)
            {
                return vzip2q_s64(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 unpacklo_epi8(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.unpacklo_epi8(a, b);
			}
            else if (IsNeonSupported)
            {
                return vzip1q_s8(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 unpacklo_epi16(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.unpacklo_epi16(a, b);
			}
            else if (IsNeonSupported)
            {
                return vzip1q_s16(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 unpacklo_epi32(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.unpacklo_epi32(a, b);
			}
            else if (IsNeonSupported)
            {
                return vzip1q_s32(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 unpacklo_epi64(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.unpacklo_epi64(a, b);
			}
            else if (IsNeonSupported)
            {
                return vzip1q_s64(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 add_sd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.add_sd(a, b);
			}
            else if (IsNeonSupported)
            {
                return move_sd(a, add_pd(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 add_pd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.add_pd(a, b);
			}
            else if (IsNeonSupported)
            {
                return vaddq_f64(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 div_sd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.div_sd(a, b);
			}
            else if (IsNeonSupported)
            {
                v128 tmp = vdivq_f64(a, b);
                return Xse.imm8.Arm.vsetq_lane_f64(Xse.imm8.Arm.vgetq_lane_f64(a, 1), tmp, 1);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 div_pd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.div_pd(a, b);
			}
            else if (IsNeonSupported)
            {
                return vdivq_f64(a, b);
            }
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 max_sd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.max_sd(a, b);
			}
            else if (IsNeonSupported)
            {
                return move_sd(a, max_pd(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 max_pd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.max_pd(a, b);
			}
            else if (IsNeonSupported)
            {
            #if SSE2NEON_PRECISE_MINMAX
                v128 _a = a;
                v128 _b = b;
                return vbslq_f64(vcgtq_f64(_a, _b), _a, _b);
            #else
                return vmaxq_f64(a, b);
            #endif
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 min_sd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.min_sd(a, b);
			}
            else if (IsNeonSupported)
            {
                return move_sd(a, min_pd(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 min_pd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.min_pd(a, b);
			}
            else if (IsNeonSupported)
            {
            #if SSE2NEON_PRECISE_MINMAX
                v128 _a = a;
                v128 _b = b;
                return vbslq_f64(vcltq_f64(_a, _b), _a, _b);
            #else
                return vminq_f64(a, b);
            #endif
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 mul_sd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.mul_sd(a, b);
			}
            else if (IsNeonSupported)
            {
                return move_sd(a, mul_pd(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 mul_pd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.mul_pd(a, b);
			}
            else if (IsNeonSupported)
            {
                return vmulq_f64(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 sqrt_sd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.sqrt_sd(a, b);
			}
            else if (IsNeonSupported)
            {
                return move_sd(a, sqrt_pd(b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 sqrt_pd(v128 a)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.sqrt_pd(a);
			}
            else if (IsNeonSupported)
            {
                return vsqrtq_f64(a);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 sub_sd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.sub_sd(a, b);
			}
            else if (IsNeonSupported)
            {
                return move_sd(a, sub_pd(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 sub_pd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.sub_pd(a, b);
			}
            else if (IsNeonSupported)
            {
                return vsubq_f64(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 and_pd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.and_pd(a, b);
			}
            else if (IsNeonSupported)
            {
                return vandq_s64(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 andnot_pd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.andnot_pd(a, b);
			}
            else if (IsNeonSupported)
            {
                return vbicq_s64(b, a);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 or_pd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.or_pd(a, b);
			}
            else if (IsNeonSupported)
            {
                return vorrq_s64(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 xor_pd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.xor_pd(a, b);
			}
            else if (IsNeonSupported)
            {
                return veorq_s64(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpeq_sd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cmpeq_sd(a, b);
			}
            else if (IsNeonSupported)
            {
                return move_sd(a, cmpeq_pd(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmplt_sd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cmplt_sd(a, b);
			}
            else if (IsNeonSupported)
            {
                return move_sd(a, cmplt_pd(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmple_sd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cmple_sd(a, b);
			}
            else if (IsNeonSupported)
            {
                return move_sd(a, cmple_pd(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpgt_sd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cmpgt_sd(a, b);
			}
            else if (IsNeonSupported)
            {
                return move_sd(a, cmpgt_pd(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpge_sd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cmpge_sd(a, b);
			}
            else if (IsNeonSupported)
            {
                return move_sd(a, cmpge_pd(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpord_sd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cmpord_sd(a, b);
			}
            else if (IsNeonSupported)
            {
                return move_sd(a, cmpord_pd(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpunord_sd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cmpunord_sd(a, b);
			}
            else if (IsNeonSupported)
            {
                return move_sd(a, cmpunord_pd(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpneq_sd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cmpneq_sd(a, b);
			}
            else if (IsNeonSupported)
            {
                return move_sd(a, cmpneq_pd(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpnlt_sd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cmpnlt_sd(a, b);
			}
            else if (IsNeonSupported)
            {
                return move_sd(a, cmpnlt_pd(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpnle_sd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cmpnle_sd(a, b);
			}
            else if (IsNeonSupported)
            {
                return move_sd(a, cmpnle_pd(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpngt_sd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cmpngt_sd(a, b);
			}
            else if (IsNeonSupported)
            {
                return move_sd(a, cmpngt_pd(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpnge_sd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cmpnge_sd(a, b);
			}
            else if (IsNeonSupported)
            {
                return move_sd(a, cmpnge_pd(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpeq_pd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cmpeq_pd(a, b);
			}
            else if (IsNeonSupported)
            {
                return vceqq_f64(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmplt_pd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cmplt_pd(a, b);
			}
            else if (IsNeonSupported)
            {
                return vcltq_f64(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmple_pd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cmple_pd(a, b);
			}
            else if (IsNeonSupported)
            {
                return vcleq_f64(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpgt_pd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cmpgt_pd(a, b);
			}
            else if (IsNeonSupported)
            {
                return vcgtq_f64(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpge_pd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cmpge_pd(a, b);
			}
            else if (IsNeonSupported)
            {
                return vcgeq_f64(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpord_pd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cmpord_pd(a, b);
			}
            else if (IsNeonSupported)
            {
                v128 not_nan_a = vceqq_f64(a, a);
                v128 not_nan_b = vceqq_f64(b, b);
                return vandq_u64(not_nan_a, not_nan_b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpunord_pd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cmpunord_pd(a, b);
			}
            else if (IsNeonSupported)
            {
                v128 not_nan_a = vceqq_f64(a, a);
                v128 not_nan_b = vceqq_f64(b, b);
                return vmvnq_s32(vandq_u64(not_nan_a, not_nan_b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpneq_pd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cmpneq_pd(a, b);
			}
            else if (IsNeonSupported)
            {
                return vmvnq_s32(vceqq_f64(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpnlt_pd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cmpnlt_pd(a, b);
			}
            else if (IsNeonSupported)
            {
                return veorq_u64(vcltq_f64(a, b), vdupq_n_u64(ulong.MaxValue));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpnle_pd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cmpnle_pd(a, b);
			}
            else if (IsNeonSupported)
            {
                return veorq_u64(vcleq_f64(a, b), vdupq_n_u64(ulong.MaxValue));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpngt_pd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cmpngt_pd(a, b);
			}
            else if (IsNeonSupported)
            {
                return veorq_u64(vcgtq_f64(a, b), vdupq_n_u64(ulong.MaxValue));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cmpnge_pd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cmpnge_pd(a, b);
			}
            else if (IsNeonSupported)
            {
                return veorq_u64(vcgeq_f64(a, b), vdupq_n_u64(ulong.MaxValue));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int comieq_sd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.comieq_sd(a, b);
			}
            else if (IsNeonSupported)
            {
                return (int)Xse.imm8.Arm.vgetq_lane_u64(vceqq_f64(a, b), 0) & 0x1;
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int comilt_sd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.comilt_sd(a, b);
			}
            else if (IsNeonSupported)
            {
                return (int)Xse.imm8.Arm.vgetq_lane_u64(vcltq_f64(a, b), 0) & 0x1;
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int comile_sd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.comile_sd(a, b);
			}
            else if (IsNeonSupported)
            {
                return (int)Xse.imm8.Arm.vgetq_lane_u64(vcleq_f64(a, b), 0) & 0x1;
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int comigt_sd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.comigt_sd(a, b);
			}
            else if (IsNeonSupported)
            {
                return (int)Xse.imm8.Arm.vgetq_lane_u64(vcgtq_f64(a, b), 0) & 0x1;
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int comige_sd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.comige_sd(a, b);
			}
            else if (IsNeonSupported)
            {
                return (int)Xse.imm8.Arm.vgetq_lane_u64(vcgeq_f64(a, b), 0) & 0x1;
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int comineq_sd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.comineq_sd(a, b);
			}
            else if (IsNeonSupported)
            {
                return comieq_sd(a, b) ^ 0x1;
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cvtpd_ps(v128 a)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cvtpd_ps(a);
			}
            else if (IsNeonSupported)
            {
                v64 tmp = vcvt_f32_f64(a);
                return vcombine_f32(tmp, vdup_n_f32(0));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cvtps_pd(v128 a)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cvtps_pd(a);
			}
            else if (IsNeonSupported)
            {
                return vcvt_f64_f32(vget_low_f32(a));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cvtpd_epi32(v128 a)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cvtpd_epi32(a);
			}
            else if (IsNeonSupported)
            {
                v128 rnd = round_pd(a, FROUND_CUR_DIRECTION);
                return set_epi32(0, 0, (int)rnd.Double1, (int)rnd.Double0);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int cvtsd_si32(v128 a)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cvtsd_si32(a);
			}
            else if (IsNeonSupported)
            {
                return (int)Xse.imm8.Arm.vgetq_lane_f64(vrndiq_f64(a), 0);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long cvtsd_si64x(v128 a)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cvtsd_si64x(a);
			}
            else if (IsNeonSupported)
            {
                return (long)Xse.imm8.Arm.vgetq_lane_f64(vrndiq_f64(a), 0);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cvtsd_ss(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cvtsd_ss(a, b);
			}
            else if (IsNeonSupported)
            {
                return Xse.imm8.Arm.vsetq_lane_f32(Xse.imm8.Arm.vget_lane_f32(vcvt_f32_f64(b), 0), a, 0);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double cvtsd_f64(v128 a)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cvtsd_f64(a);
			}
            else if (IsNeonSupported)
            {
                return (double)Xse.imm8.Arm.vgetq_lane_f64(a, 0);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cvtss_sd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cvtss_sd(a, b);
			}
            else if (IsNeonSupported)
            {
                double d = (double)Xse.imm8.Arm.vgetq_lane_f32(b, 0);
                return Xse.imm8.Arm.vsetq_lane_f64(d, a, 0);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cvttpd_epi32(v128 a)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cvttpd_epi32(a);
			}
            else if (IsNeonSupported)
            {
                return set_epi32(0, 0, (int)a.Double1, (int)a.Double0);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int cvttsd_si32(v128 a)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cvttsd_si32(a);
			}
            else if (IsNeonSupported)
			{
				return (int)a.Double0;
			}
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long cvttsd_si64x(v128 a)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cvttsd_si64x(a);
			}
            else if (IsNeonSupported)
            {
                return Xse.imm8.Arm.vgetq_lane_s64(vcvtq_s64_f64(a), 0);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cvtps_epi32(v128 a)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cvtps_epi32(a);
			}
            else if (IsNeonSupported)
            {
                return vcvtnq_s32_f32(a);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 cvttps_epi32(v128 a)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.cvttps_epi32(a);
			}
            else if (IsNeonSupported)
            {
                return vcvtq_s32_f32(a);
            }
			else throw new IllegalInstructionException();
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 set_sd(double a)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.set_sd(a);
			}
            else if (IsNeonSupported)
            {
                return Xse.imm8.Arm.vsetq_lane_f64(a, vdupq_n_f64(0), 0);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 set_pd(double e1, double e0)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.set_pd(e1, e0);
			}
            else if (IsNeonSupported)
			{
				return new v128(e0, e1);
			}
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 setr_pd(double e1, double e0)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.setr_pd(e1, e0);
			}
            else if (IsNeonSupported)
            {
                return set_pd(e0, e1);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 unpackhi_pd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.unpackhi_pd(a, b);
			}
            else if (IsNeonSupported)
            {
                return vzip2q_f64(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 unpacklo_pd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.unpacklo_pd(a, b);
			}
            else if (IsNeonSupported)
            {
                return vzip1q_f64(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int movemask_pd(v128 a)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.movemask_pd(a);
			}
            else if (IsNeonSupported)
            {
                v128 high_bits = vshrq_n_u64(a, 63);
                return (int)(Xse.imm8.Arm.vgetq_lane_u64(high_bits, 0) | (Xse.imm8.Arm.vgetq_lane_u64(high_bits, 1)<< 1));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 shuffle_pd(v128 a, v128 b, int imm8)
		{
			if (Sse2.IsSse2Supported)
			{
				return Xse.imm8.X86.shuffle_pd(a, b, imm8);
			}
            else if (IsNeonSupported)
            {
                return set_epi64x(Xse.imm8.Arm.vgetq_lane_s64(b, (imm8 & 0x2) >> 1), Xse.imm8.Arm.vgetq_lane_s64(a, imm8 & 0x1));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 move_sd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.move_sd(a, b);
			}
            else if (IsNeonSupported)
            {
                return vcombine_f32(vget_low_f32(b), vget_high_f32(a));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 hadd_pd(v128 a, v128 b)
		{
			if (Sse3.IsSse3Supported)
			{
				return Sse3.hadd_pd(a, b);
			}
            else if (IsNeonSupported)
            {
                return vpaddq_f64(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 hadd_ps(v128 a, v128 b)
		{
			if (Sse3.IsSse3Supported)
			{
				return Sse3.hadd_ps(a, b);
			}
            else if (IsNeonSupported)
            {
                return vpaddq_f32(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 hsub_pd(v128 a, v128 b)
		{
			if (Sse3.IsSse3Supported)
			{
				return Sse3.hsub_pd(a, b);
			}
            else if (IsNeonSupported)
            {
                return vsubq_f64(vuzp1q_f64(a, b), vuzp2q_f64(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 hsub_ps(v128 a, v128 b)
		{
			if (Sse3.IsSse3Supported)
			{
				return Sse3.hsub_ps(a, b);
			}
            else if (IsNeonSupported)
            {
                return vsubq_f32(vuzp1q_f32(a, b), vuzp2q_f32(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 movedup_pd(v128 a)
		{
			if (Sse3.IsSse3Supported)
			{
				return Sse3.movedup_pd(a);
			}
            else if (IsNeonSupported)
            {
                return vdupq_laneq_f64(a, 0);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 movehdup_ps(v128 a)
		{
			if (Sse3.IsSse3Supported)
			{
				return Sse3.movehdup_ps(a);
			}
            else if (IsNeonSupported)
            {
                return vtrn2q_f32(a, a);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 moveldup_ps(v128 a)
		{
			if (Sse3.IsSse3Supported)
			{
				return Sse3.moveldup_ps(a);
			}
            else if (IsNeonSupported)
            {
                return vtrn1q_f32(a, a);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 shuffle_epi8(v128 a, v128 b)
		{
			if (Ssse3.IsSsse3Supported)
			{
				return Ssse3.shuffle_epi8(a, b);
			}
            else if (IsNeonSupported)
            {
                return vqtbl1q_s8(a, vandq_u8(b, vdupq_n_u8(0x8F)));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 alignr_epi8(v128 a, v128 b, int count)
		{
			if (Ssse3.IsSsse3Supported)
			{
				switch (count)
				{
					case 0:  return Ssse3.alignr_epi8(a, b, 0);
					case 1:  return Ssse3.alignr_epi8(a, b, 1);
					case 2:  return Ssse3.alignr_epi8(a, b, 2);
					case 3:  return Ssse3.alignr_epi8(a, b, 3);
					case 4:  return Ssse3.alignr_epi8(a, b, 4);
					case 5:  return Ssse3.alignr_epi8(a, b, 5);
					case 6:  return Ssse3.alignr_epi8(a, b, 6);
					case 7:  return Ssse3.alignr_epi8(a, b, 7);
					case 8:  return Ssse3.alignr_epi8(a, b, 8);
					case 9:  return Ssse3.alignr_epi8(a, b, 9);
					case 10: return Ssse3.alignr_epi8(a, b, 10);
					case 11: return Ssse3.alignr_epi8(a, b, 11);
					case 12: return Ssse3.alignr_epi8(a, b, 12);
					case 13: return Ssse3.alignr_epi8(a, b, 13);
					case 14: return Ssse3.alignr_epi8(a, b, 14);
					case 15: return Ssse3.alignr_epi8(a, b, 15);
					default: return Ssse3.alignr_epi8(a, b, 16);
				}
			}
            else if (IsNeonSupported)
            {
                if ((count & ~31) != 0)
                {
                    return vdupq_n_u8(0);
                }
                else if (count >= 16)
                {
                    return bsrli_si128(a, count >= 16 ? count - 16 : 0);
                }
                else
                {
                    return Xse.imm8.Arm.vextq_u8(b, a, count < 16 ? count : 0);
                }
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 hadd_epi16(v128 a, v128 b)
		{
			if (Ssse3.IsSsse3Supported)
			{
				return Ssse3.hadd_epi16(a, b);
			}
            else if (IsNeonSupported)
            {
                return vpaddq_s16(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 hadds_epi16(v128 a, v128 b)
		{
			if (Ssse3.IsSsse3Supported)
			{
				return Ssse3.hadds_epi16(a, b);
			}
            else if (IsNeonSupported)
            {
                return vqaddq_s16(vuzp1q_s16(a, b), vuzp2q_s16(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 hadd_epi32(v128 a, v128 b)
		{
			if (Ssse3.IsSsse3Supported)
			{
				return Ssse3.hadd_epi32(a, b);
			}
            else if (IsNeonSupported)
            {
                return vpaddq_s32(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 hsub_epi16(v128 a, v128 b)
		{
			if (Ssse3.IsSsse3Supported)
			{
				return Ssse3.hsub_epi16(a, b);
			}
            else if (IsNeonSupported)
            {
                return vsubq_s16(vuzp1q_s16(a, b), vuzp2q_s16(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 hsubs_epi16(v128 a, v128 b)
		{
			if (Ssse3.IsSsse3Supported)
			{
				return Ssse3.hsubs_epi16(a, b);
			}
            else if (IsNeonSupported)
            {
                return vqsubq_s16(vuzp1q_s16(a, b), vuzp2q_s16(a, b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 hsub_epi32(v128 a, v128 b)
		{
			if (Ssse3.IsSsse3Supported)
			{
				return Ssse3.hsub_epi32(a, b);
			}
            else if (IsNeonSupported)
            {
                return vsubq_s32(vuzp1q_s32(a, b), vuzp2q_s32(a, b));
            }
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 sign_epi8(v128 a, v128 b)
		{
			if (Ssse3.IsSsse3Supported)
			{
				return Ssse3.sign_epi8(a, b);
			}
            else if (IsNeonSupported)
            {
                v128 ltMask = vshrq_n_s8(b, 7);
                v128 zeroMask = vceqzq_s8(b);
                v128 masked = vbslq_s8(ltMask, vnegq_s8(a), a);
                v128 res = vbicq_s8(masked, zeroMask);
                return res;
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 sign_epi16(v128 a, v128 b)
		{
			if (Ssse3.IsSsse3Supported)
			{
				return Ssse3.sign_epi16(a, b);
			}
            else if (IsNeonSupported)
            {
                v128 ltMask = vshrq_n_s16(b, 15);
                v128 zeroMask = vceqzq_s16(b);
                v128 masked = vbslq_s16(ltMask, vnegq_s16(a), a);
                v128 res = vbicq_s16(masked, zeroMask);
                return res;
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 sign_epi32(v128 a, v128 b)
		{
			if (Ssse3.IsSsse3Supported)
			{
				return Ssse3.sign_epi32(a, b);
			}
            else if (IsNeonSupported)
            {
                v128 ltMask = vshrq_n_s32(b, 31);
                v128 zeroMask = vceqzq_s32(b);
                v128 masked = vbslq_s32(ltMask, vnegq_s32(a), a);
                v128 res = vbicq_s32(masked, zeroMask);
                return res;
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 dp_pd(v128 a, v128 b, int imm8)
		{
			if (Sse4_1.IsSse41Supported)
			{
				return Sse4_1.dp_pd(a, b, imm8);
			}
            else if (IsNeonSupported)
            {
                long bit0Mask = (imm8 & 0x01) != 0 ? -1 : 0;
                long bit1Mask = (imm8 & 0x02) != 0 ? -1 : 0;
                double d0 = (imm8 & 0x10) != 0 ? Xse.imm8.Arm.vgetq_lane_f64(a, 0) * Xse.imm8.Arm.vgetq_lane_f64(b, 0) : 0;
                double d1 = (imm8 & 0x20) != 0 ? Xse.imm8.Arm.vgetq_lane_f64(a, 1) * Xse.imm8.Arm.vgetq_lane_f64(b, 1) : 0;
                v128 tmp = set_pd(d1, d0);
                double sum = vpaddd_f64(tmp);

                v128 sumMask = set_epi64x(bit1Mask, bit0Mask);
                v128 res = and_pd(set1_pd(sum), sumMask);
                return res;
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 dp_ps(v128 a, v128 b, int imm8)
		{
			if (Sse4_1.IsSse41Supported)
			{
				return Sse4_1.dp_ps(a, b, imm8);
			}
            else if (IsNeonSupported)
            {
                v128 elementwise_prod = mul_ps(a, b);

                if (imm8 == 0xFF){
                    return set1_ps(vaddvq_f32(elementwise_prod));
                }

                if ((imm8 & 0x0F)== 0x0F)
                {
                    if ((imm8 & (1 << 4)) == 0) elementwise_prod = Xse.imm8.Arm.vsetq_lane_f32(0.0f, elementwise_prod, 0);
                    if ((imm8 & (1 << 5)) == 0) elementwise_prod = Xse.imm8.Arm.vsetq_lane_f32(0.0f, elementwise_prod, 1);
                    if ((imm8 & (1 << 6)) == 0) elementwise_prod = Xse.imm8.Arm.vsetq_lane_f32(0.0f, elementwise_prod, 2);
                    if ((imm8 & (1 << 7)) == 0) elementwise_prod = Xse.imm8.Arm.vsetq_lane_f32(0.0f, elementwise_prod, 3);
                    return set1_ps(vaddvq_f32(elementwise_prod));
                }

                float s = 0.0f;

                if ((imm8 & (1 << 4)) != 0) s += Xse.imm8.Arm.vgetq_lane_f32(elementwise_prod, 0);
                if ((imm8 & (1 << 5)) != 0) s += Xse.imm8.Arm.vgetq_lane_f32(elementwise_prod, 1);
                if ((imm8 & (1 << 6)) != 0) s += Xse.imm8.Arm.vgetq_lane_f32(elementwise_prod, 2);
                if ((imm8 & (1 << 7)) != 0) s += Xse.imm8.Arm.vgetq_lane_f32(elementwise_prod, 3);

                return new v128
                (
                    (imm8 & 0x1) != 0 ? s : 0.0f,
                    (imm8 & 0x2) != 0 ? s : 0.0f,
                    (imm8 & 0x4) != 0 ? s : 0.0f,
                    (imm8 & 0x8) != 0 ? s : 0.0f
                );
            }
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 packus_epi32(v128 a, v128 b)
		{
			if (Sse4_1.IsSse41Supported)
			{
				return Sse4_1.packus_epi32(a, b);
			}
            else if (IsNeonSupported)
            {
                return vcombine_u16(vqmovun_s32(a), vqmovun_s32(b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int testz_si128(v128 a, v128 b)
		{
			if (Sse4_1.IsSse41Supported)
			{
				return Sse4_1.testz_si128(a, b);
			}
            else if (IsNeonSupported)
            {
                v128 s64 = vandq_s64(a, b);
                bool r = (Xse.imm8.Arm.vgetq_lane_s64(s64, 0) | Xse.imm8.Arm.vgetq_lane_s64(s64, 1)) == 0;
                return *(byte*)&r;
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int testc_si128(v128 a, v128 b)
		{
			if (Sse4_1.IsSse41Supported)
			{
				return Sse4_1.testc_si128(a, b);
			}
            else if (IsNeonSupported)
            {
                v128 s64 = vbicq_s64(b, a);
                bool r = (Xse.imm8.Arm.vgetq_lane_s64(s64, 0) | Xse.imm8.Arm.vgetq_lane_s64(s64, 1)) == 0;
                return *(byte*)&r;
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int testnzc_si128(v128 a, v128 b)
		{
			if (Sse4_1.IsSse41Supported)
			{
				return Sse4_1.testnzc_si128(a, b);
			}
            else if (IsNeonSupported)
            {
                return test_mix_ones_zeroes(a, b);
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int test_all_zeros(v128 a, v128 mask)
		{
			if (Sse4_1.IsSse41Supported)
			{
				return Sse4_1.test_all_zeros(a, mask);
			}
            else if (IsNeonSupported)
            {
                v128 a_and_mask = vandq_s64(a, mask);
                bool r = (Xse.imm8.Arm.vgetq_lane_s64(a_and_mask, 0) | Xse.imm8.Arm.vgetq_lane_s64(a_and_mask, 1)) == 0;
                return *(byte*)&r;
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int test_mix_ones_zeroes(v128 a, v128 mask)
		{
			if (Sse4_1.IsSse41Supported)
			{
				return Sse4_1.test_mix_ones_zeroes(a, mask);
			}
            else if (IsNeonSupported)
            {
                v128 zf = vandq_u64(mask, a);
                v128 cf = vbicq_u64(mask, a);
                v128 result = vandq_u64(zf, cf);
                bool r = (Xse.imm8.Arm.vgetq_lane_u64(result, 0) | Xse.imm8.Arm.vgetq_lane_u64(result, 1)) == 0;
                return *(byte*)&r;
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int test_all_ones(v128 a)
		{
			if (Sse4_1.IsSse41Supported)
			{
				return Sse4_1.test_all_ones(a);
			}
            else if (IsNeonSupported)
            {
                bool r = (Xse.imm8.Arm.vgetq_lane_s64(a, 0) & Xse.imm8.Arm.vgetq_lane_s64(a, 1)) == -1;
                return *(byte*)&r;
            }
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 minpos_epu16(v128 a)
		{
			if (Sse4_1.IsSse41Supported)
			{
				return Sse4_1.minpos_epu16(a);
			}
            else if (IsNeonSupported)
            {
                ushort min = vminvq_u16(a);
                v128 minv = vdupq_n_u16(min);
                v128 cmeq = vceqq_u16(minv, a);
                ushort idx = vminvq_u16(vornq_u16(new v128(0, 1, 2, 3, 4, 5, 6, 7), cmeq));

                v128 dst = setzero_si128();
                dst = Xse.imm8.Arm.vsetq_lane_u16(min, dst, 0);
                dst = Xse.imm8.Arm.vsetq_lane_u16(idx, dst, 1);
                return dst;
            }
			else throw new IllegalInstructionException();
		}
    }
}