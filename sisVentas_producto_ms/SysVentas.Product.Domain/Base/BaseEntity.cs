using System;
using System.Collections.Generic;
namespace SysVentas.Products.Domain.Base
{
    public abstract class BaseEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    public abstract class Entity<T> : BaseEntity, IEntity<T>
    { 
        public virtual T Id { get; set; }
        public string Status { get; set; }
    }
    public enum StatusObject
    {
        Inactive = 0,
        Active = 1,
        Approve = 2,
        Cancel = 3
    }

    public static class StatusView
    {
        private static readonly IDictionary<StatusObject, string> Values = new Dictionary<StatusObject, string>()
        {
            {
                StatusObject.Active, "AC"
            },
            {
                StatusObject.Inactive, "IN"
            },
            {
                StatusObject.Approve, "AN"
            },
            {
                StatusObject.Approve, "AP"
            }
        };
        public static string Get(StatusObject status) => Values[status];

    }


}
