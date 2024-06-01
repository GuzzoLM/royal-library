namespace RoyalLibrary.ViewModels;

public struct BookFilterViewModel
{
    public string? Author { get; set; }

    public string? Isbn { get; set; }

    public bool? Own { get; set; }

    public bool? Love { get; set; }

    public bool? WantToRead { get; set; }
}