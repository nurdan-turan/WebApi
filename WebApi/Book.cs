namespace WebApi;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public int PageCount { get; set; }
    public int Price { get; set; }
    public DateTime PublishDate { get; set; }

}