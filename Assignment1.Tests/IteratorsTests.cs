
namespace Assignment1.Tests;

public class IteratorsTests
{

    [Fact]
    public void Flatten_EmptyList_ReturnsEmptyList()
    {
        var list = new List<List<int>>();
        var result = Iterators.Flatten(list);
        Assert.Empty(result);
    }

    [Fact]
    public void Flatten_ListWithList_1_2_3_4_Returns_List_1_2_3_4()
    {
        var list = new List<List<int>> { new List<int>() { 1, 2, 3, 4 } };
        var result = Iterators.Flatten(list);
        Assert.Equal(new[] { 1, 2, 3, 4 }, result);
    }

}