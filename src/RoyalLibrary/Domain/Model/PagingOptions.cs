namespace RoyalLibrary.Domain.Model;

public class PagingOptions
{
    public PagingOptions()
    {
    }

    public int Offset { get; set; } = 0;

    public int Limit { get; set; } = 20;

    public void NextPage()
    {
        Offset += Limit;
    }
}