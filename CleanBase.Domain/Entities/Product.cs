using CleanBase.Domain.Validation;

namespace CleanBase.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }
        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Id é invalido");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }
        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name é invalido. Name é required");
            DomainExceptionValidation.When(name.Length < 3, "Name invalido. Name deve conter no mínimo 3 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Name é invalido. Name é required");
            DomainExceptionValidation.When(description.Length < 5, "Name invalido. Name deve conter no mínimo 5 caracteres.");
            DomainExceptionValidation.When(price < 0, "Price invalido. Deve ser diferente de zero.");
            DomainExceptionValidation.When(stock < 0, "Price invalido. Deve ser diferente de zero.");
            DomainExceptionValidation.When(image.Length > 250,
                "Nome da Image invalido. Deve conter no máximo 250 caracteres.");
        }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
