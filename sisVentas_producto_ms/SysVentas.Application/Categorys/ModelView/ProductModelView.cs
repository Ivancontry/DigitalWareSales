using System;
using SysVentas.Application.Base;
namespace SysVentas.Application.Categorys.ModelView
{
    public class ProductModelView : DTO<long, Domain.Entities.Categorys.Product, ProductModelView>
    {
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Amount { get; set; }
        public long CategoryId { get; set; }
        public decimal Price { get; set; }
    }
}