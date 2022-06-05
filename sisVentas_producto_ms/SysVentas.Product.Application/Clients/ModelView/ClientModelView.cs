using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysVentas.Products.Application.Base;
using SysVentas.Products.Domain.Entities.Clients;

namespace SysVentas.Products.Application.Clients.ModelView
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
