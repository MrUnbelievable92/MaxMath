using System.IO;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using DevTools;

namespace MaxMath.Tests
{
    public static class ___TESTING___
    {
        private static string ProjectPath => Application.dataPath.Substring(0, Application.dataPath.Length - "Assets".AsDirectory().Length).AsDirectory() + "LocalPackages".AsDirectory() + "MaxMath".AsDirectory() + "Runtime";
        
        private const string SSE = "Sse.IsSseSupported";
        private const string SSE2 = "Sse2.IsSse2Supported";
        private const string SSE3 = "Sse3.IsSse3Supported";
        private const string SSSE3 = "Ssse3.IsSsse3Supported";
        private const string SSE4_1 = "Sse4_1.IsSse41Supported";
        private const string SSE4_2 = "Sse4_2.IsSse42Supported";
        private const string AVX = "Avx.IsAvxSupported";
        private const string AVX2 = "Avx2.IsAvx2Supported";
        private const string FMA = "Fma.IsFmaSupported";
        private const string BMI1 = "Bmi1.IsBmi1Supported";
        private const string BMI2 = "Bmi2.IsBmi2Supported";
        private const string POPCNT = "Popcnt.IsPopcntSupported";
        private const string F16C = "F16C.IsF16CSupported";

        private const string CONST = "Constant.IsConstantExpression";

        private const string TESTING = "#define TESTING";


        private static void DeactivateAll()
        {
            DeactivateFeatureSet(SSE);
            DeactivateFeatureSet(SSE2);
            DeactivateFeatureSet(SSE3);
            DeactivateFeatureSet(SSSE3);
            DeactivateFeatureSet(SSE4_1);
            DeactivateFeatureSet(SSE4_2);
            DeactivateFeatureSet(AVX);
            DeactivateFeatureSet(AVX2);
            DeactivateFeatureSet(FMA);
            DeactivateFeatureSet(BMI1);
            DeactivateFeatureSet(BMI2);
            DeactivateFeatureSet(POPCNT);
            DeactivateFeatureSet(F16C);
        }

        private static void DeactivatePreprocessorDirective(string define)
        {
            DirectoryExtensions.ForEachFile(ProjectPath,
            (file) => 
            {
                if (Path.GetExtension(file) != ".cs")
                {
                    return;
                }

                string fileContent = File.ReadAllText(file);
                int idx = fileContent.IndexOf(define);

                if (idx > 1 && fileContent[idx - 1] != '/' && fileContent[idx - 2] != '/')
                {
                    fileContent = fileContent.Replace(define, "//" + define);
                    File.WriteAllText(file, fileContent);
                }
            });
        }
        private static void ActivatePreprocessorDirective(string define)
        {
            DirectoryExtensions.ForEachFile(ProjectPath,
            (file) => 
            {
                if (Path.GetExtension(file) != ".cs")
                {
                    return;
                }
                
                string fileContent = File.ReadAllText(file);

                if (fileContent.Contains("//" + define))
                {
                    fileContent = fileContent.Replace("//" + define, define);
                    File.WriteAllText(file, fileContent);
                }
            });
        }

        private static void DeactivateFeatureSet(string featureSet)
        {
            DirectoryExtensions.ForEachFile(ProjectPath,
            (file) => 
            {
                if (Path.GetExtension(file) != ".cs")
                {
                    return;
                }

                string fileContent = File.ReadAllText(file);

                bool any = false;
                int index = 0;
                while ((index = fileContent.IndexOf("!" + featureSet, index + 1)) != -1)
                {
                    any = true;
                    fileContent = fileContent.Remove(index, 1);
                }

                if (any)
                {
                    File.WriteAllText(file, fileContent);
                }
            });
        }
        private static void ActivateFeatureSet(string featureSet)
        {
            DirectoryExtensions.ForEachFile(ProjectPath,
            (file) => 
            {
                if (Path.GetExtension(file) != ".cs")
                {
                    return;
                }

                string fileContent = File.ReadAllText(file);
                
                bool any = false;
                int index = 0;
                while ((index = fileContent.IndexOf(featureSet, index + 1)) != -1)
                {
                    any = true;
                    if (fileContent[index - 1] != '!')
                    {
                        fileContent = fileContent.Insert(index, "!");
                        index++;
                    }
                }
                
                if (any)
                {
                    File.WriteAllText(file, fileContent);
                }
            });
        }


        [Test]
        public static void _00_ACTIVATE_TEST_MODE()
        {
            DeactivatePreprocessorDirective(TESTING);

            ActivatePreprocessorDirective(TESTING);

            AssetDatabase.Refresh();
        }

        [Test]
        public static void _01_ACTIVATE_SSE()
        {
            DeactivateAll();

            ActivateFeatureSet(SSE);

            AssetDatabase.Refresh();
        }

        [Test]
        public static void _02_ACTIVATE_SSE2()
        {
            DeactivateAll();

            ActivateFeatureSet(SSE);
            ActivateFeatureSet(SSE2);

            AssetDatabase.Refresh();
        }

        [Test]
        public static void _03_ACTIVATE_SSE3()
        {
            DeactivateAll();

            ActivateFeatureSet(SSE);
            ActivateFeatureSet(SSE2);
            ActivateFeatureSet(SSE3);

            AssetDatabase.Refresh();
        }

        [Test]
        public static void _04_ACTIVATE_SSSE3()
        {
            DeactivateAll();

            ActivateFeatureSet(SSE);
            ActivateFeatureSet(SSE2);
            ActivateFeatureSet(SSE3);
            ActivateFeatureSet(SSSE3);

            AssetDatabase.Refresh();
        }

        [Test]
        public static void _05_ACTIVATE_SSE4_1()
        {
            DeactivateAll();

            ActivateFeatureSet(SSE);
            ActivateFeatureSet(SSE2);
            ActivateFeatureSet(SSE3);
            ActivateFeatureSet(SSSE3);
            ActivateFeatureSet(SSE4_1);

            AssetDatabase.Refresh();
        }

        [Test]
        public static void _06_ACTIVATE_SSE4_2()
        {
            DeactivateAll();

            ActivateFeatureSet(SSE);
            ActivateFeatureSet(SSE2);
            ActivateFeatureSet(SSE3);
            ActivateFeatureSet(SSSE3);
            ActivateFeatureSet(SSE4_1);
            ActivateFeatureSet(SSE4_2);

            AssetDatabase.Refresh();
        }

        [Test]
        public static void _07_ACTIVATE_AVX()
        {
            DeactivateAll();

            ActivateFeatureSet(SSE);
            ActivateFeatureSet(SSE2);
            ActivateFeatureSet(SSE3);
            ActivateFeatureSet(SSSE3);
            ActivateFeatureSet(SSE4_1);
            ActivateFeatureSet(SSE4_2);
            ActivateFeatureSet(AVX);

            AssetDatabase.Refresh();
        }

        [Test]
        public static void _08_ACTIVATE_AVX2()
        {
            DeactivateAll();

            ActivateFeatureSet(SSE);
            ActivateFeatureSet(SSE2);
            ActivateFeatureSet(SSE3);
            ActivateFeatureSet(SSSE3);
            ActivateFeatureSet(SSE4_1);
            ActivateFeatureSet(SSE4_2);
            ActivateFeatureSet(AVX);
            ActivateFeatureSet(AVX2);
            ActivateFeatureSet(FMA);
            ActivateFeatureSet(BMI1);
            ActivateFeatureSet(BMI2);
            ActivateFeatureSet(POPCNT);
            ActivateFeatureSet(F16C);

            AssetDatabase.Refresh();
        }

        [Test]
        public static void _09_ACTIVATE_CONST()
        {
            DeactivateFeatureSet(CONST);

            ActivateFeatureSet(CONST);

            AssetDatabase.Refresh();
        }

        [Test]
        public static void _10_RELEASE_MODE()
        {
            DeactivatePreprocessorDirective(TESTING);

            DeactivateAll();

            DeactivateFeatureSet(CONST);

            AssetDatabase.Refresh();
        }
    }
}
