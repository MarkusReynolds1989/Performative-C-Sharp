namespace ManageComplexity;

public class FeedGrain
{
    private FeedGrain(string scGroupId,
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

    public static FeedGrain CreateFeedGrain(string[] split) =>
        new(split[0],
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