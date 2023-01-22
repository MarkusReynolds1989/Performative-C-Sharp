namespace TopicExampleCode;

public static class Parallelization
{
    public static IEnumerable<int> StringsToIntegers(int initialCapacity, IEnumerable<string> input)
    {
        var output = new List<int>(initialCapacity);
        foreach (var line in input)
        {
            output.Add(int.Parse(line));
        }

        return output;
    }

    public static IEnumerable<int> StringsToIntegersParallel(int initialCapacity, IEnumerable<string> input)
    {
        var output = new List<int>(initialCapacity);
        Parallel.ForEach(input, line => { output.Add(int.Parse(line)); });
        return output;
    }

    public static IEnumerable<int> StringsToIntegersParallelLinq(IEnumerable<string> input) =>
        input.AsParallel().Select(int.Parse);
}