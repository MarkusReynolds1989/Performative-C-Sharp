namespace Tests;

public static class LinqEfficiencyTests
{
    // Fastest, it's going to take around 11 seconds. This is great for when you know how many elements you need exactly.
    [Fact(Skip = "Turn this on independently because it's slow.")]
    public static void BigAllocationForTest()
    {
        var _ = LinqEfficiency.BigAllocationFor();
    }

    // Takes around 21 seconds. Faster than Linq but still not great.
    [Fact(Skip = "Turn this on independently because it's slow.")]
    public static void BigAllocationForEachTest()
    {
        var _ = LinqEfficiency.BigAllocationForEach();
    }

    // Surprisingly faster than using a foreach with no initial size. If you don't know how many elements you will need
    // and can't get close it may be okay to use a Linq select.
    // Your mileage may vary, and will need profiling.
    // Takes around 27 seconds.
    [Fact(Skip = "Turn this on independently because it's slow.")]
    public static void BigAllocationLinqTest()
    {
        var _ = LinqEfficiency.BigAllocationLinq();
    }

    // 55 seconds, it's recommended to only use this when you are going to be chaining operations together
    // that way you don't allocate and process items you don't need.
    // In other words, the less you force enumeration the better.
    [Fact(Skip = "Turn this on independently because it's slow.")]

    public static void GeneratorTest()
    {
        // This won't actually work until we tell it to work with the ToList call.
        // Enumerable is lazy and won't work until you are explicit about needing it.
        var _ = LinqEfficiency.BigAllocationGenerator().ToList();
    }

    // Slowest, takes 61 seconds to do the process. 
    [Fact(Skip = "Turn this on independently because it's slow.")]
    public static void BigAllocationForEachWithoutSizeTest()
    {
        var _ = LinqEfficiency.BigAllocationForEachWithoutSize();
    }

    [Fact(Skip = "Turn this on independently because it's slow.")]
    public static void ImmutableDictionaryManualTest()
    {
        var _ = LinqEfficiency.GenerateDictionaryManual();
    }

    [Fact(Skip = "Turn this on independently because it's slow.")]
    public static void ImmutableDictionaryLinqTest()
    {
        var _ = LinqEfficiency.GenerateDictionaryLinq();
    }
}