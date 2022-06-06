using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysVentas.Domain.Entities.Categorys;

namespace SysVentas.Infrastructure.Data.initialize
{
    public static class CategoryInitialize
    {
        public static void InitializeCategory(ProductDataContext productDataContext) {
            #region categoryTechnology
                var categoryTechnology = new Category(DateTime.Now,"Tec-001","Tecnología");
                var productLaptopAcer = new Product(DateTime.Now,"Acer Aspire 15","Acer-15",20,1800000);
                var productLaptopLenovo = new Product(DateTime.Now, "Lenovo", "Len-15", 20, 2800000);
                var productLaptopHp = new Product(DateTime.Now, "Lenovo", "HP-15", 20, 2100000);
                var productLaptopMac = new Product(DateTime.Now, "Mac", "Mac-15", 20, 3100000);
                categoryTechnology.Products.Add(productLaptopAcer);
                categoryTechnology.Products.Add(productLaptopLenovo);
                categoryTechnology.Products.Add(productLaptopHp);
                categoryTechnology.Products.Add(productLaptopMac);
            #endregion

            #region categoryClothing
                var categoryClothing = new Category(DateTime.Now, "Clo-002", "Ropa");
                var productClothingPants = new Product(DateTime.Now, "Pantalon Negro", "Pan-01", 15, 80000);
                var productClothingBlouse = new Product(DateTime.Now, "Blusa azul", "Blo-11", 20, 50000);
                var productClothingShort = new Product(DateTime.Now, "Short", "Sho-17", 20, 30000);
                var productClothingShirt = new Product(DateTime.Now, "Camisa", "Shi-11", 20, 50000);
                categoryClothing.Products.Add(productClothingPants);
                categoryClothing.Products.Add(productClothingShort);
                categoryClothing.Products.Add(productClothingBlouse);
                categoryClothing.Products.Add(productClothingShirt);
            #endregion

            #region categoryFootwear
                var categoryFootwear = new Category(DateTime.Now, "Foo-003", "Calzado");
                var productFootwearBlack = new Product(DateTime.Now, "Zapato Negro", "Zap-14", 15, 180000);
                var productFootwearBlue = new Product(DateTime.Now, "Blusa azul", "Zap-15", 20, 150000);
                var productFootwearWhite = new Product(DateTime.Now, "Short", "Zap-19", 20, 130000);
                var productFootwearGreen = new Product(DateTime.Now, "Camisa", "Zap-21", 20, 1450000);
                categoryFootwear.Products.Add(productFootwearBlack);
                categoryFootwear.Products.Add(productFootwearWhite);
                categoryFootwear.Products.Add(productFootwearGreen);
                categoryFootwear.Products.Add(productFootwearBlue);
            #endregion

            productDataContext.Categories.Add(categoryClothing);
            productDataContext.Categories.Add(categoryFootwear);
            productDataContext.Categories.Add(categoryTechnology);
            productDataContext.SaveChanges();
        }
    }
}
