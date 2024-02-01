namespace Ecommerce.Core.Abstract;

public abstract class BaseEntities
{
    public int Id { get; set; }
    public DateTime CreatTime { get; set; }
    public DateTime ModifiedTime { get; set; }
    public bool isDelete { get; set; }=false;
}
