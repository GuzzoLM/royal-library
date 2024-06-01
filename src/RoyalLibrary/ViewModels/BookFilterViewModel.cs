namespace RoyalLibrary.ViewModels;

public class BookFilterViewModel
{
    public string? Author { get; set; }

    public string? Isbn { get; set; }

    public bool? Own { get; set; }

    public bool? Love { get; set; }

    public bool? WantToRead { get; set; }
}