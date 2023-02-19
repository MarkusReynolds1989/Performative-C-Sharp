namespace ManageComplexity;

using System;
using System.IO;
using System.Runtime.CompilerServices;

internal static class Program
{
    public class FeedGrain
    {
        public FeedGrain(string scGroupId,
                         string scGroupDescription,
                         string scGroupCommodityId,
                         string scGroupCommodityDescription,
                         string scGeographyId,
                         string sortOrder,
                         string scGeographyIndentedDescription,
                         string scCommodityId,
                         string scCommodityDescription,
                         string scAttributeId,
                         string scAttributeDescription,
                         string scUnitId,
                         string scUnitDescription,
                         string yearId,
                         string scFrequencyId,
                         string scFrequencyDescription,
                         string timePeriodId,
                         string timePeriodDescription,
                         string amount)
        {
            ScGroupId = string.IsNullOrEmpty(scGroupId) ? 0 : int.Parse(scGroupId);
            ScGroupDescription = scGroupDescription;
            ScGroupCommodityId = string.IsNullOrEmpty(scGroupCommodityId) ? 0 : int.Parse(scGroupCommodityId);
            ScGroupCommodityDescription = scGroupCommodityDescription;
            ScGeographyId = string.IsNullOrEmpty(scGeographyId) ? 0 : int.Parse(scGeographyId);
            SortOrder = string.IsNullOrEmpty(sortOrder) ? 0 : double.Parse(sortOrder);
            ScGeographyIndentedDescription = scGeographyIndentedDescription;
            ScCommodityId = string.IsNullOrEmpty(scCommodityId) ? 0 : int.Parse(scCommodityId);
            ScCommodityDescription = scCommodityDescription;
            ScAttributeId = string.IsNullOrEmpty(scAttributeId) ? 0 : int.Parse(scAttributeId);
            ScAttributeDescription = scAttributeDescription;
            ScUnitId = string.IsNullOrEmpty(scUnitId) ? 0 : int.Parse(scUnitId);
            YearId = string.IsNullOrEmpty(yearId) ? 0 : int.Parse(yearId);
            ScFrequencyId = string.IsNullOrEmpty(scFrequencyId) ? 0 : int.Parse(scFrequencyId);
            ScFrequencyDescription = scFrequencyDescription;
            ScUnitDescription = scUnitDescription;
            TimePeriodId = string.IsNullOrEmpty(timePeriodId) ? 0 : int.Parse(timePeriodId);
            TimePeriodDescription = timePeriodDescription;
            Amount = string.IsNullOrEmpty(amount) ? 0 : double.Parse(amount);
        }

        public int ScGroupId { get; set; }
        public string ScGroupDescription { get; set; }
        public int ScGroupCommodityId { get; set; }
        public string ScGroupCommodityDescription { get; set; }
        public int ScGeographyId { get; set; }
        public double SortOrder { get; set; }
        public string ScGeographyIndentedDescription { get; set; }
        public int ScCommodityId { get; set; }
        public string ScCommodityDescription { get; set; }
        public int ScAttributeId { get; set; }
        public string ScAttributeDescription { get; set; }
        public int ScUnitId { get; set; }

        public int YearId { get; set; }

        public int ScFrequencyId { get; set; }

        public string ScFrequencyDescription { get; set; }

        public string ScUnitDescription { get; set; }
        public int TimePeriodId { get; set; }
        public string TimePeriodDescription { get; set; }
        public double Amount { get; set; }
    }

    public class FeedGrains
    {
        public List<int> ScGroupIds { get; set; }
        public List<string> ScGroupDescriptions { get; set; }
        public List<int> ScGroupCommodityIds { get; set; }
        public List<string> ScGroupCommodityDescriptions { get; set; }
        public List<int> ScGeographyIds { get; set; }
        public List<double> SortOrders { get; set; }
        public List<string> ScGeographyIndentedDescriptions { get; set; }
        public List<int> ScCommodityIds { get; set; }
        public List<string> ScCommodityDescriptions { get; set; }
        public List<int> ScAttributeIds { get; set; }
        public List<string> ScAttributeDescriptions { get; set; }
        public List<int> ScUnitIds { get; set; }
        public List<int> YearIds { get; set; }
        public List<int> ScFrequencyIds { get; set; }
        public List<string> ScFrequencyDescriptions { get; set; }
        public List<string> ScUnitDescriptions { get; set; }
        public List<int> TimePeriodIds { get; set; }
        public List<string> TimePeriodDescriptions { get; set; }
        public List<double> Amounts { get; set; }

        public void LoadSlots(string[] values)
        {
            ScGroupIds.Add(string.IsNullOrEmpty(values[0]) ? 0 : int.Parse(values[0]));
            ScGroupDescriptions.Add(values[1]);
            ScGroupCommodityIds.Add(string.IsNullOrEmpty(values[2]) ? 0 : int.Parse(values[2]));
            ScGroupCommodityDescriptions.Add(values[3]);
            ScGeographyIds.Add(string.IsNullOrEmpty(values[4]) ? 0 : int.Parse(values[4]));
            SortOrders.Add(string.IsNullOrEmpty(values[5]) ? 0 : double.Parse(values[5]));
            ScGeographyIndentedDescriptions.Add(values[6]);
            ScCommodityIds.Add(string.IsNullOrEmpty(values[7]) ? 0 : int.Parse(values[7]));
            ScCommodityDescriptions.Add(values[8]);
            ScAttributeIds.Add(string.IsNullOrEmpty(values[9]) ? 0 : int.Parse(values[9]));
            ScAttributeDescriptions.Add(values[10]);
            ScUnitIds.Add(string.IsNullOrEmpty(values[11]) ? 0 : int.Parse(values[11]));
            ScUnitDescriptions.Add(values[12]);
            YearIds.Add(string.IsNullOrEmpty(values[13]) ? 0 : int.Parse(values[13]));
            ScFrequencyIds.Add(string.IsNullOrEmpty(values[14]) ? 0 : int.Parse(values[14]));
            ScFrequencyDescriptions.Add(values[15]);
            TimePeriodIds.Add(string.IsNullOrEmpty(values[16]) ? 0 : int.Parse(values[16]));
            TimePeriodDescriptions.Add(values[17]);
            Amounts.Add(string.IsNullOrEmpty(values[18]) ? 0 : double.Parse(values[18]));
        }

        public FeedGrains(int length)
        {
            ScGroupIds = new(length);
            ScGroupDescriptions = new(length);
            ScGroupCommodityIds = new(length);
            ScGroupCommodityDescriptions = new(length);
            ScGeographyIds = new(length);
            SortOrders = new(length);
            ScGeographyIndentedDescriptions = new(length);
            ScCommodityIds = new(length);
            ScCommodityDescriptions = new(length);
            ScAttributeIds = new(length);
            ScAttributeDescriptions = new(length);
            ScUnitIds = new(length);
            YearIds = new(length);
            ScFrequencyIds = new(length);
            ScFrequencyDescriptions = new(length);
            ScUnitDescriptions = new(length);
            TimePeriodIds = new(length);
            TimePeriodDescriptions = new(length);
            Amounts = new(length);
        }
    }

    private static void Main()
    {
        // Use your own path here.
        const string path = @"C:\Users\marku\Code\C#\Performative-C-Sharp\Data\FeedGrains.txt";

        // This one is very slow.
        // Around 19 seconds.
        //var slow = SlowFeedGrainBuilder(path);

        // This one should be faster due to multiThread.
        // Also around 19 seconds.
        //var faster = FasterFeedGrainBuilder(path);

        // More than double the speed. 7 seconds.
        var fastest = FastestFeedGrainBuilder(path);
        var debug = 0;
    }

    public static FeedGrain[] SlowFeedGrainBuilder(string path)
    {
        var lines = File.ReadLines(path);
        // Skip the header.
        lines = lines.Skip(1);
        var length = lines.Count();
        var feedGrains = new FeedGrain[length];

        // Very slow synchronous example.
        // Don't do this.
        // It has linear time complexity, every line we just create a class and push it into our array.
        for (var i = 0; i < length; i += 1)
        {
            var line = lines.First().Split("\t");
            var feedGrain = new FeedGrain(line[0],
                                          line[1],
                                          line[2],
                                          line[3],
                                          line[4],
                                          line[5],
                                          line[6],
                                          line[7],
                                          line[8],
                                          line[9],
                                          line[10],
                                          line[11],
                                          line[12],
                                          line[13],
                                          line[14],
                                          line[15],
                                          line[16],
                                          line[17],
                                          line[18]);
            feedGrains[i] = feedGrain;
        }

        return feedGrains;
    }

    public static FeedGrain[] FasterFeedGrainBuilder(string path)
    {
        var lines = File.ReadLines(path);
        // Skip the header.
        lines = lines.Skip(1);
        var length = lines.Count();
        var i = 0;
        var feedGrains = new FeedGrain[length];

        Parallel.ForEach(lines, line =>
        {
            var split = line.Split("\t");
            var feedGrain = new FeedGrain(split[0],
                                          split[1],
                                          split[2],
                                          split[3],
                                          split[4],
                                          split[5],
                                          split[6],
                                          split[7],
                                          split[8],
                                          split[9],
                                          split[10],
                                          split[11],
                                          split[12],
                                          split[13],
                                          split[14],
                                          split[15],
                                          split[16],
                                          split[17],
                                          split[18]);
            feedGrains[i] = feedGrain;
            i += 1;
        });

        return feedGrains;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static FeedGrains FastestFeedGrainBuilder(string path)
    {
        var lines = File.ReadLines(path);
        lines = lines.Skip(1);
        var length = lines.Count();
        var feedGrains = new FeedGrains(length);

        foreach (var line in lines)
        {
            var split = line.Split("\t");
            feedGrains.LoadSlots(split);
        }

        return feedGrains;
    }
}