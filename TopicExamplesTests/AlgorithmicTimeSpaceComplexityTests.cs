namespace Tests;

public class AlgorithmicTimeSpaceComplexityTests
{
    [Fact]
    public void QuadraticTimeComplexityTest()
    {
        var results = AlgorithmicTimeSpaceComplexity.QuadraticComplexity();
        var expected = new List<List<int>>
        {
            new() {2, 3, 4, 5},
            new() {2, 3, 4, 5}
        };

        Assert.Equal(expected, results);
    }

    [Fact]
    public void ExponentialTimeComplexityTest()
    {
        var results = AlgorithmicTimeSpaceComplexity.ExponentialComplexity();
        var expected = new List<List<List<int>>>
        {
            new() {new() {2, 3, 4, 5}, new() {2, 3, 4, 5}, new() {2, 3, 4, 5}},
            new() {new() {2, 3, 4, 5}, new() {2, 3, 4, 5}, new() {2, 3, 4, 5}}
        };

        Assert.Equal(expected, results);
    }
}