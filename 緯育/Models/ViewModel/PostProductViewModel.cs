namespace TravelProject1._0.Areas.Admin.Models.ViewModel
{
    public class PostProductViewModel
    {
    public string ProductName { get; set; }

    public int Price { get; set; }

    public string? MainDescribe { get; set; }

    public int Id { get; set; }

    public string? SubDescribe { get; set; }

    public string? ShortDescribe { get; set; }

    public IFormFile File { get; set; }

    }
}
