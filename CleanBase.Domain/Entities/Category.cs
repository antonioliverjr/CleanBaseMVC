using CleanBase.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanBase.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }
        
        public Category(string name)
        {
            ValidateDomain(name);
        }
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Id é invalido");
            Id = id;
            ValidateDomain(name);
        }
        public void Update(string name)
        {
            ValidateDomain(name);
        }

        public ICollection<Product> Products { get; set; }
        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name invalido. Name é required.");
            DomainExceptionValidation.When(name.Length < 3, "Name invalido. Name deve conter no mínimo 3 caracteres.");
            Name = name;
        }
    }
}
