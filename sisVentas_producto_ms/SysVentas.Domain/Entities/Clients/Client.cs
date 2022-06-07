using System;
using SysVentas.Domain.Base;
namespace SysVentas.Domain.Entities.Clients
{
    public class Client: Entity<long>
    {
        public string Identification { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDay { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public Client()
        {
                
        }

        public Client(string identification,string name, string phone, DateTime birthDay, string address, string email)
        {
            Identification = identification;
            Name = name;
            Phone = phone;
            BirthDay = birthDay;
            Address = address;
            Email = email;
            Status = StatusView.Get(StatusObject.Active);
        }

        public void Edit(string identification, string name, string phone, DateTime birthDay, string address, string email)
        {
            Identification = identification;
            Name = name;
            Phone = phone;
            BirthDay = birthDay;
            Address = address;
            Email = email;
        }

        public void Active()
        {
            Status = StatusView.Get(StatusObject.Active);
        }

        public void Inactive()
        {
            Status = StatusView.Get(StatusObject.Inactive);
        }
    }
}
