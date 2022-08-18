// In Burst compiled code, the exception Message is not displayed, which makes it not user friendly (June 11th '22)

//using System;
//using System.Runtime.CompilerServices;
//using Unity.Burst.CompilerServices;
//
//namespace MaxMath
//{
//    public class ConstantException : Exception
//    {
//        private ConstantException() 
//        {  }
//
//        public ConstantException(string paramName, string funcName) 
//            : base($"The \"{ funcName }\" parameter \"{ paramName }\" was expected to be constant.") 
//        { 
//
//        }
//
//        // In Burst compiled code, the exception Message is not displayed, which makes it not user friendly (June 11th '22)
//        public static void ThrowIfNonConstant<T>(T value, string paramName, [CallerMemberName] string funcName = null) 
//            where T : unmanaged
//        {
//            if (Constant.IsConstantExpression(1))
//            {
//                if (Constant.IsConstantExpression(value))
//                {
//                    return;
//                }
//                else
//                {
//                    throw new ConstantException(paramName, funcName);
//                }
//            }
//        }
//    }
//}