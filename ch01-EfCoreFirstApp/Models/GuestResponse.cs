namespace EfCoreFirstApp.Models;

public class GuestResponse
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public bool? WillAttend { get; set; }
}