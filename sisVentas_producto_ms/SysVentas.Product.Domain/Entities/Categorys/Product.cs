using System;
using SysVentas.Domain.Base;
namespace SysVentas.Domain.Entities.Categorys
{
    public class Product
    {
        public long Id { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public long CategoryId { get; set; }

        public Product()
        {

        }
        public Product(DateTime date, string name, string code, decimal amount, decimal price)
        {
            Date = date;
            Name = name;
            Code = code;
            Amount = amount;
            Price = price;
            Status = StatusView.Get(StatusObject.Active);
        }

        internal void Edit(string code, string name, decimal amount)
        {
            Name = name;
            Code = code;
            Amount = amount;
        }

        internal void Inactive()
        {
            Status = StatusView.Get(StatusObject.Inactive);
        }

        internal void Active()
        {
            Status = StatusView.Get(StatusObject.Active);
        }

        public DomainValidation CanUpdateProductStock(decimal cuantity)
        {
            var validator = new DomainValidation();
            if (Status == StatusView.Get(StatusObject.Inactive)) {
                validator.AddFailed("Update Stock", $"Producto {Code} - {Name} se encuentra inactivo");
            }
            if (cuantity < 0) {
                validator.AddFailed("Update Stock",$"La cantidad a comprar del producto {Code} - {Name} supera a la del inventario actual {Amount}");
            }
            return validator;
        }
        public void UpdateProductStock(decimal cuantity) {
            Amount += cuantity;
        }

    }
}
