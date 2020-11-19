# MaxMath
A C# SIMD math library, supplementary to Unity.Mathematics using Unity.Burst. 

It extends Unity.Mathematics' SIMD vector types with (s)byte, (u)short and (u)long vectors. 
Many operations present in Unity.Mathematics have been transcribed to work with the new vector types in addition to many new useful functions having been added.

Note: 
- Unity_DevTools (a repository of mine) is required. Unit tests for this library are included in this repository.
- There are currently no fallback procedures regarding AVX/2 support. Thus AVX2 is required. (Work in progress)
