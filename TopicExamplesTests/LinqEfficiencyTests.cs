namespace Tests;

public static class LinqEfficiencyTests
{
    [Fact(Skip = "Turn this on independently because it's slow.")]
    public static void BigAllocationForTest()
    {
        var _ = LinqEfficiency.BigAllocationFor();
    }

    [Fact(Skip = "Turn this on independently because it's slow.")]
    public static void BigAllocationForEachTest()
    {
        var _ = LinqEfficiency.BigAllocationForEach();
    }

    [Fact(Skip = "Turn this on independently because it's slow.")]
    public static void BigAllocationLinqTest()
    {
        var _ = LinqEfficiency.BigAllocationLinq();
    }

    [Fact(Skip = "Turn this on independently because it's slow.")]

    public static void GeneratorTest()
    {
        var _ = LinqEfficiency.BigAllocationGenerator().ToList();
    }

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

    [Fact]//(Skip = "Turn this on independently because it's slow.")]
    public static void ImmutableDictionaryLinqTest()
    {
        var _ = LinqEfficiency.GenerateDictionaryLinq();
    }
}