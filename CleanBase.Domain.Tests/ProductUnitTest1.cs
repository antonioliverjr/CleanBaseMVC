using CleanBase.Domain.Entities;
using CleanBase.Domain.Validation;
using FluentAssertions;
using System;
using Xunit;

namespace CleanBase.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "Product image");
            action.Should().NotThrow<DomainExceptionValidation>();
        }
        [Fact(DisplayName = "Create Product Id Invalid Domain Exception")]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalid()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m, 99, "Product image");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Id é invalido");
        }
        [Fact(DisplayName = "Create Product Short Name Value Domain Exception")]
        public void CreateProduct_ShortNameValue_DomainExceptionInvalid()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 9.99m, 99, "Product image");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Name invalido. Name deve conter no mínimo 3 caracteres.");
        }
        [Fact(DisplayName = "Create Product Short Price Value Domain Exception")]
        public void CreateProduct_NegativePriceValue_DomainExceptionInvalid()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", -9.99m, 99, "Product image");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Price invalido. Deve ser diferente de zero.");
        }
        [Theory(DisplayName = "Create Product Short Stock Value Domain Exception")]
        [InlineData(-99)]
        public void CreateProduct_NegativeStockValue_DomainExceptionInvalid(int value)
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, value, "Product image");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Stock invalido. Deve ser diferente de zero.");
        }
        [Fact(DisplayName = "Create Product Long Image Value Domain Exception")]
        public void CreateProduct_LongImageName_DomainExceptionInvalid()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "Product image Product image Product image Product image Product image Product image Product image Product image Product image Product image Product image Product image Product image Product image Product image Product image Product image Product image Product image");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Nome da Image invalido. Deve conter no máximo 250 caracteres.");
        }
        [Fact(DisplayName = "Create Product Null Image Name Null Exception")]
        public void CreateProduct_WithNullImageName_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);
            action.Should().NotThrow<NullReferenceException>();
        }
    }
}
