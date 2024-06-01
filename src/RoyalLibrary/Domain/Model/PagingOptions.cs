namespace RoyalLibrary.Domain.Model;

public struct PagingOptions
{
    public int Offset { get; set; }

    public int Limit { get; set; }

    public void NextPage()
    {
        Offset += Limit;
    }
}