using NetDevPack.Domain;
using System.Collections.Generic;

namespace Mrv.Domain.Models
{
    public class Category : Entity, IAggregateRoot
    {
        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }

        // Empty constructor for EF
        protected Category() { }

        public int Id { get; private set; }

        public string Name { get; private set; }

    }
}