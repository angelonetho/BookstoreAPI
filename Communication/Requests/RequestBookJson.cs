namespace BookstoreAPI.Communication.Requests;

public class CreateBook
{
    public string Title { get; set; }
    public string Author { get; set; }
    public Gender Gender { get; set; }
    public decimal Price { get; set; }
    public int Units { get; set; }
}
