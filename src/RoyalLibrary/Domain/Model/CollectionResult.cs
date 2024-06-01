namespace RoyalLibrary.Domain.Model;

public class CollectionResult<T>(List<T> items, int count)
{
    public List<T> Items { get; set; } = items;

    public int Count { get; set; } = count;
}