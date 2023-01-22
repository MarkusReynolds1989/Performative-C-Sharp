namespace TopicExampleCode;

public static class Parallelization
{
    public static IEnumerable<int> StringsToIntegers(IEnumerable<string> input)
    {
        var output = new List<int>();
        foreach (var line in input)
        {
            output.Add(int.Parse(line));
        }

        return output;
    }

    public static IEnumerable<int> StringsToIntegersParallel(IEnumerable<string> input)
    {
        var output = new List<int>();
        Parallel.ForEach(input, line => { output.Add(int.Parse(line)); });
        return output;
    }
}