# MaxMath
A C# SIMD math library for use with Unity only, supplementary to Unity.Mathematics using Unity.Burst. 

It adds (s)byte, (u)short and (u)long SIMD vectors and matrices to the ones already provided by Unity.Mathematics. 
Almost all functions present in Unity.Mathematics have been transcribed to work with the new vector and matrix types in addition to many useful functions having been added.

Note: 
- C Sharp Dev Tools (a repository of mine) is required. Unit tests for this library are included in this repository.
- There are currently no fallback procedures regarding platform support without AVX2 apart from the managed C# implementations. Thus, for the most part, AVX2 is required if used with Burst. (Work in progress)
