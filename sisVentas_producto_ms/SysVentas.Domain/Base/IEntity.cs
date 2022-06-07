namespace SysVentas.Domain.Base
{
    public interface IEntity<T>
    {
        T Id { get; set; }
        string Status { get; set; }

    }
   
}