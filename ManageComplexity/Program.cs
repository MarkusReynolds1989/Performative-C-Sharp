namespace ManageComplexity;

using System;
using System.IO;

internal static class Program
{
    private static Span<string> ReadInput(string path)
    {
        var lines = File.ReadAllLines(path);

        // Doesn't allocate a new array when slicing, returns this actual array at this index.
        return lines.AsSpan()[1..];
    }

    private static Span<FeedGrain> FeedGrainBuilder(string path)
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

    private static List<FeedGrain> FilterYears(Span<FeedGrain> feedGrains, int year, string comparer)
    {
        var list = new List<FeedGrain>(feedGrains.Length / 2);
        foreach (var feedGrain in feedGrains)
        {
            if (comparer == ">")
            {
                if (feedGrain.YearId > year)
                {
                    list.Add(feedGrain);
                }
            }
            else
            {
                if (feedGrain.YearId < year)
                {
                    list.Add(feedGrain);
                }
            }
        }

        return list;
    }

    // I want to get every year before 1950 where the amount was higher than all the years after 1950.
    // To qualify, each year before 1950 must be higher than every year after.
    /*private static List<FeedGrain> NaiveFilterHigherAmountYears(List<FeedGrain> yearsBefore1950,
                                                                List<FeedGrain> yearsAfter1950)
    {
        var list = new List<FeedGrain>(yearsAfter1950.Count);
        var higher = false;

        // Quadratic time complexity.
        // We should avoid this because it will make our code slower.
        foreach (var highYear in yearsAfter1950)
        {
            foreach (var lowYear in yearsBefore1950)
            {
                if (lowYear.Amount < highYear.Amount)
                {
                    higher = false;
                    break;
                }

                higher = true;
            }

            if (higher)
            {
                list.Add(highYear);
            }
        }
        
        list.TrimExcess();
        return list;
    }*/

    private static List<FeedGrain> LinearFilterHigherAmountYears(List<FeedGrain> yearsBefore1950,
                                                                 List<FeedGrain> yearsAfter1950)
    {
        var list = new List<FeedGrain>(yearsAfter1950.Count);
        var lowIndex = 0;
        var highIndex = 0;
        var higher = false;
        while (highIndex < yearsAfter1950.Count)
        {
            if (lowIndex < yearsBefore1950.Count)
            {
                if (yearsBefore1950[lowIndex].Amount < yearsAfter1950[highIndex].Amount)
                {
                    higher = false;
                    highIndex += 1;
                    lowIndex = 0;
                }
                else
                {
                    higher = true;
                    lowIndex += 1;
                }
            }
            else
            {
                if (higher)
                {
                    list.Add(yearsAfter1950[highIndex]);
                }

                // Go to the next year after 1950.
                highIndex += 1;
                // Go to the start of the before 1950 years all over again.
                lowIndex = 0;
            }
        }

        list.TrimExcess();
        return list;
    }

    private static void Main()
    {
        // Use your own path here.
        const string path = @"C:\Users\marku\Code\C#\Performative-C-Sharp\Data\FeedGrains.txt";

        // Takes around 6 seconds.
        var feedGrain = FeedGrainBuilder(path);

        var feedGrainBefore1950 = FilterYears(feedGrain, 1950, "<");
        var feedGrainAfter1950 = FilterYears(feedGrain, 1950, ">");

        var olderGoodYears = LinearFilterHigherAmountYears(feedGrainBefore1950, feedGrainAfter1950);
        Console.WriteLine(olderGoodYears.Count);
        var debug = 0;
    }
}