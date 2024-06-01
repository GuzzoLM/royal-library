namespace RoyalLibrary.Domain.Model;

public struct BookFilter
{
    public int? UserId { get; set; }

    public string? Author { get; set; }

    public string? Isbn { get; set; }

    public bool? Own { get; set; }

    public bool? Love { get; set; }

    public bool? WantToRead { get; set; }
}