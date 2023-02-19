namespace ManageComplexity;

using System;
using System.IO;

internal static class Program
{
    private static Span<string> ReadInput(string path)
    {
        var lines = File.ReadAllLines(path);

        return lines.AsSpan()[1..];
    }

    private static FeedGrain[] SlowFeedGrainBuilder(string path)
    {
        var lines = ReadInput(path);
        var feedGrains = new FeedGrain[lines.Length];
        var i = 0;
        foreach (var line in lines)
        {
            var split = line.Split("\t");
            feedGrains[i] = FeedGrain.CreateFeedGrain(split);
            i += 1;
        }

        return feedGrains;
    }

    private static FeedGrains FastestFeedGrainBuilder(string path)
    {
        var lines = ReadInput(path);
        var feedGrains = new FeedGrains(lines.Length);

        foreach (var line in lines)
        {
            var split = line.Split("\t");
            feedGrains.LoadSlots(split);
        }

        return feedGrains;
    }

    private static void Main()
    {
        // Use your own path here.
        const string path = @"C:\Users\marku\Code\C#\Performative-C-Sharp\Data\FeedGrains.txt";

        // This one is slow.
        // Around 19 seconds.

        var slow = SlowFeedGrainBuilder(path);

        // This one is slower due to multiThread.
        // Initiating the thread pool and managing the threads is an overhead, so you should only 
        // use it when you know you have many items and you have profiled.
        // Also around 19 seconds.
        //var slower = SlowerFeedGrainBuilder(path);

        foreach (var feedGrain in slow)
        {
            var temp = feedGrain.Amount + 1;
        }

        // More than double the speed. 7 seconds.
        //var fastest = FastestFeedGrainBuilder(path);

        /*for (var i = 0; i < fastest.ScGroupIds.Count; i += 1)
        {
            var temp = fastest.SortOrders[i] + 1;
        }*/
    }
}