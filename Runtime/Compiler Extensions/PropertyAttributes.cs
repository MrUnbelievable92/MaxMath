namespace MaxMath
{
    /// <summary>   Used by property drawers when vectors should be post normalized.    </summary>
    public class PostNormalizeAttribute : Unity.Mathematics.PostNormalizeAttribute {}

    /// <summary>   Used by property drawers when vectors should not be normalized.     </summary>
    public class DoNotNormalizeAttribute : Unity.Mathematics.DoNotNormalizeAttribute {}
}
