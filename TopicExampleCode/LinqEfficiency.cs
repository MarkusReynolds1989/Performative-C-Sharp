using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;

namespace TopicExampleCode;

public static class LinqEfficiency
{
    // Make sure you are giving a capacity for lists that need to take a lot of elements.
    // This will make the allocation much more optimized.
    public static List<string> BigAllocationForEach()
    {
        var list = new List<string>(200_000_000);
        foreach (var _ in Enumerable.Range(0, 200_000_000))
        {
            list.Add("Really big string.");
        }

        return list;
    }

    public static List<string> BigAllocationForEachWithoutSize()
    {
        var list = new List<string>();
        foreach (var _ in Enumerable.Range(0, 200_000_000))
        {
            list.Add("Really big string.");
        }

        return list;
    }

    // This is ideal, but only for situations where you can get the capacity needed for your array.
    // For example, if you are querying a DB and can page the results you could easily use an array.
    public static string[] BigAllocationFor()
    {
        var list = new string[200_000_000];
        for (var i = 0; i < list.Length; i += 1)
        {
            list[i] = "Really big string.";
        }

        return list;
    }

    // This is inefficient, the benefit here is that the work is lazy but wouldn't really benefit you
    // if you need to do an operation on every element.
    public static List<string> BigAllocationLinq()
    {
        var list = new List<string>(200_000_000);
        list.AddRange(Enumerable.Range(0, 200_000_000).Select(_ => "Really big string."));

        return list;
    }

    // This is also very inefficient, see notes for above.
    public static IEnumerable<string> BigAllocationGenerator()
    {
        foreach (var _ in Enumerable.Range(0, 200_000_000))
        {
            yield return "Really big string";
        }
    }

    public static IDictionary<int, string> GenerateDictionaryManual()
    {
        var dictionary = new Dictionary<int, string>();
        foreach (var i in Enumerable.Range(0, 200_000_000))
        {
            dictionary.Add(i, "Test");
        }

        return dictionary.ToImmutableDictionary();
    }

    public static IDictionary<int, string> GenerateDictionaryLinq() =>
        Enumerable.Range(0, 200_000_000).ToDictionary(i => i, i => "Test").ToImmutableDictionary();
}