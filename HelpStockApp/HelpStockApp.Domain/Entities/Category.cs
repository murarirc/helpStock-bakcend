﻿using HelpStockApp.Domain.Validation;

namespace HelpStockApp.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; }

        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id <= 0, "Invalid Id value.");
            DomainExceptionValidation.When(id.GetType() == typeof(string), "Invalid Id, Must be number.");
            Id = id;
            ValidateDomain(name);
        }

        public ICollection<Product> Products { get; set; }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name, name is required!");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short. minimum 3 characters!");

            Name= name;
        }
    }
 
}
