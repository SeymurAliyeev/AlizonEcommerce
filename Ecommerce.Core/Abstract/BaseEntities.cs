namespace Ecommerce.Core.Abstract;

public abstract class BaseEntities
{
    public int Id { get; set; }
    public DateTime CreateTime { get; set; } = DateTime.Now;
    public DateTime ModifiedTime { get; set; } = DateTime.Now;
    public bool isDelete { get; set; }=false;
}
