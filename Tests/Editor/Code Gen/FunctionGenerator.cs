using System.Collections.Generic;

namespace MaxMath.Tests
{
    internal class FunctionGenerator
    {
        public string FunctionName { get; set; }
        public string[] ParameterNames { get; set; }
        public bool GenerateBoolean { get; set; }
        public bool GenerateFloatingPoint { get; set; }
        public bool GenerateInteger { get; set; }
        public bool GenerateScalar { get; set; }
        public bool GenerateVector { get; set; }
        public bool GenerateMatrix { get; set; }


        private string GenerateParameters(Parameter[] parameters)
        {
            return CodeGen.GenerateIterated(", ", parameters.Length, i => parameters[i].ToString());
        }
        private string GenerateArguments(Parameter[] parameters, string appendix = null)
        {
            return CodeGen.GenerateIterated(", ", parameters.Length, i => parameters[i].Name + (appendix ?? string.Empty));
        }
        private string GenerateScalarFallback(FunctionSignature signature)
        {
            return $"return new {signature.ReturnType.Value}({CodeGen.GenerateIterated(", ", signature.ReturnType.Value._elementCount, i => FunctionName + "(" + GenerateArguments(signature.Parameters, "." + signature.ReturnType.Value.GetFieldName(i)) + ")")});";
        }
        private string GenerateVectorFallback(FunctionSignature signature)
        {
            string result = $"return new {signature.ReturnType.Value}(";

            string appendix0;
            string appendix1;
            switch (signature.ReturnType.Value._elementCount)
            {
                case 3:
                case 4:
                {
                    appendix0 = ".xy";
                    appendix1 = signature.ReturnType.Value._elementCount == 3 ? ".z" : ".zw";
                    break;
                }
                default:
                {
                    int half = signature.ReturnType.Value._elementCount / 2;
                    appendix0 = $".v{half}_0";
                    appendix1 = $".v{half}_{half}";
                    break;
                }
            }
            result += FunctionName + "(" + GenerateArguments(signature.Parameters, appendix0) + ")";
            result += ", ";
            result += FunctionName + "(" + GenerateArguments(signature.Parameters, appendix1) + ")";
            result += ");";

            return result;
        }
        private string GenerateMatrixFallback(FunctionSignature signature)
        {
            return $"return new {signature.ReturnType.Value}({CodeGen.GenerateIterated(", ", signature.ReturnType.Value._columnCount, i => FunctionName + "(" + GenerateArguments(signature.Parameters, "." + signature.ReturnType.Value.GetFieldName(i)) + ")")});";
        }
        private string GenerateFunction(Function function)
        {
            string result = "[MethodImpl(MethodImplOptions.AggressiveInlining)]\n"
                 + $"public static {function.Signature.ReturnType.Value} {function.Name}({GenerateParameters(function.Signature.Parameters)})\n"
                 + "{\n";

            if (function.Signature.ReturnType.Value.IsScalar)
            {
                result += "\t\n";
            }
            else if (function.Signature.ReturnType.Value.IsVector)
            {
                result += (function.Signature.ReturnType.Value.IsV256 ? "\tif (Avx2.IsAvx2Supported)\n" 
                                                                      : "\tif (Architecture.IsSIMDSupported)\n")
                         + "\t{\n"
                         + "\t\t\n"
                         + "\t}\n"
                         + "\telse\n"
                         + "\t{\n"
                         + (function.Signature.ReturnType.Value.IsV256 ? $"\t\t{ GenerateVectorFallback(function.Signature) }\n" 
                                                                       : $"\t\t{ GenerateScalarFallback(function.Signature) }\n")
                         + "\t}\n";
            }
            else if (function.Signature.ReturnType.Value.IsMatrix)
            {
                result += $"\t{ GenerateMatrixFallback(function.Signature) }\n";
            }

            return result + "}\n";
        }

        private TypeInfo[] SelectTypes()
        {
            List<TypeInfo> types = new List<TypeInfo>();

            if (GenerateScalar) types.AddRange(TypeInfo.AllScalarTypes);
            if (GenerateVector) types.AddRange(TypeInfo.AllVectorTypes);
            if (GenerateMatrix) types.AddRange(TypeInfo.AllMatrixTypes);

            if (!GenerateBoolean)       types.RemoveAll(type => type._dataType == NumericDataType.Boolean);
            if (!GenerateInteger)       types.RemoveAll(type => type._dataType == NumericDataType.Integer);
            if (!GenerateFloatingPoint) types.RemoveAll(type => type._dataType == NumericDataType.FloatingPoint);

            return types.ToArray();
        }
        internal string GenerateFunctions()
        {
            TypeInfo[] types = SelectTypes();

            return CodeGen.GenerateIterated(
            "\n",
            types.Length, 
            i => 
            {
                Parameter[] parameters = new Parameter[ParameterNames.Length];
                for (int k = 0; k < parameters.Length; k++)
                {
                    parameters[k] = new Parameter(ParameterNames[k], types[i], Parameter.Reference.Value);
                }
                
                return GenerateFunction(new Function(FunctionName, new FunctionSignature(types[i], parameters)));
            });
        }
    }
}
