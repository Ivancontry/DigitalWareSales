﻿using System;
using SysVentas.Products.Application.Base;
using SysVentas.Products.Domain;
using SysVentas.Products.Domain.Entities.Categorys;

namespace SysVentas.Products.Application.Categorys.ModelView
{
    public class ProductModelView : DTO<long, Domain.Entities.Categorys.Product, ProductModelView>
    {
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Amount { get; set; }
        public long CategoryId { get; set; }
    }
}