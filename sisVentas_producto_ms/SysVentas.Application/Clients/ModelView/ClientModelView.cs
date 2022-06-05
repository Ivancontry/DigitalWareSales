using SysVentas.Application.Base;
using SysVentas.Domain.Entities.Clients;
namespace SysVentas.Application.Clients.ModelView
{
    public class ClientModelView : DTO<long, Client, ClientModelView>
    {
        public long Id { get; set; }
        public string Identification { get; internal set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Age { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
