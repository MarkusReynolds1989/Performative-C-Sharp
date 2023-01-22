namespace Tests;

public class ParallelizationTests
{
    private readonly string[] _shortFile = File.ReadAllLines("strings_short.txt");
    // You will have to make your own "strings_long.txt" file or follow along.
    // Mine was 100_000_000 lines. It's just a file with the numbers 1 to 100_000_00 written on one line each.
    private readonly string[] _longFile = File.ReadAllLines("strings_long.txt");

    [Fact]
    public void AllStringsAreNumbersShort()
    {
        // This test will run faster because Parallelization takes time to setup.
        // You shouldn't use parallelization unless you have a large list of items you can handle
        // simultaneously.
        var results = Parallelization.StringsToIntegers(_shortFile);
    }

    [Fact]
    public void AllStringsAreNumbersParallelShort()
    {
        // This will run slower because it has set up rather then just starting to translate right away.
        // In parallel, turn all strings into integers.
        var results = Parallelization.StringsToIntegersParallel(_shortFile);
    }

    [Fact]
    public void AllStringsAreNumbersLong()
    {
        // Here's where we will see the speedup, the single threaded solution 
        // Will use one thread to go through the file one at a time to convert.
        var results = Parallelization.StringsToIntegers(_longFile);
    }

    [Fact]
    public void AllStringsAreNumbersParallelLong()
    {
        // The parallel implementation will run multiple threads to do the work on the strings.
        var results = Parallelization.StringsToIntegersParallel(_longFile);
    }
}