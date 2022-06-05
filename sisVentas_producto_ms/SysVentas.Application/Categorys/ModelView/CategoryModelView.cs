using System;
using System.Collections.Generic;
using SysVentas.Application.Base;
using SysVentas.Domain.Entities.Categorys;
namespace SysVentas.Application.Categorys.ModelView
{
    public class CategoryModelView: DTO<long,Category,CategoryModelView>
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public List<ProductModelView> Products { get; set; }
    }

}
