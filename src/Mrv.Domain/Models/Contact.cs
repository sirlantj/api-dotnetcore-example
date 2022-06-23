using System;
using System.Collections.Generic;
using NetDevPack.Domain;

namespace Mrv.Domain.Models
{
    public class Contact : Entity, IAggregateRoot
    {
        public Contact(int id, string name, string lastname, string email, string phone)
        {
            Id = id;
            Name = name;
            LastName = lastname;
            Email = email;
            Phone = phone;
        }

        // Empty constructor for EF
        protected Contact() { }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public string Phone { get; private set; }

    }
}