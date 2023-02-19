namespace ManageComplexity;

public class FeedGrains
{
    public List<int> ScGroupIds { get; }
    public List<string> ScGroupDescriptions { get; }
    public List<int> ScGroupCommodityIds { get; }
    public List<string> ScGroupCommodityDescriptions { get; }
    public List<int> ScGeographyIds { get; }
    public List<double> SortOrders { get; }
    public List<string> ScGeographyIndentedDescriptions { get; }
    public List<int> ScCommodityIds { get; }
    public List<string> ScCommodityDescriptions { get; }
    public List<int> ScAttributeIds { get; }
    public List<string> ScAttributeDescriptions { get; }
    public List<int> ScUnitIds { get; }
    public List<int> YearIds { get; }
    public List<int> ScFrequencyIds { get; }
    public List<string> ScFrequencyDescriptions { get; }
    public List<string> ScUnitDescriptions { get; }
    public List<int> TimePeriodIds { get; }
    public List<string> TimePeriodDescriptions { get; }
    public List<double> Amounts { get; }

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