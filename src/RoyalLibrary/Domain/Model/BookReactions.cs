namespace RoyalLibrary.Domain.Model;

public class BookReactions
{
    public int Id { get; set; }

    public int BookId { get; set; }

    public Book? Book { get; set; }

    public int UserId { get; set; }

    public bool Own { get; set; }

    public bool Love { get; set; }

    public bool WantToRead { get; set; }
}