namespace WebAPI.Models;

public class ResponseAPI <R>
{
    public int Status { get; set; }
    public string Message { get; set; }
    public R Content { get; set; }
}