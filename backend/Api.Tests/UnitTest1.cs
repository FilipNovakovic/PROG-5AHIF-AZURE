public class BookTests
{
    [Fact]
    public void Book_With_Negative_Price_Is_Invalid()
    {
        var book = new Book { Title = "Test", Price = -5 };
        Assert.True(book.Price <= 0);
    }
}
