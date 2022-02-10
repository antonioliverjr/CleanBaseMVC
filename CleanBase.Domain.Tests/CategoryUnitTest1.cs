using CleanBase.Domain.Entities;
using CleanBase.Domain.Validation;
using FluentAssertions;
using System;
using Xunit;

namespace CleanBase.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should().NotThrow<DomainExceptionValidation>();
        }
        [Fact(DisplayName = "Create Category Id Invalid Domain Exception")]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalid()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Id é invalido");
        }
        [Fact(DisplayName = "Create Category Short Name Value Domain Exception")]
        public void CreateCategory_ShortNameValue_DomainExceptionInvalid()
        {
            Action action = () => new Category(1, "ad");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Name invalido. Name deve conter no mínimo 3 caracteres.");
        }
        [Fact(DisplayName = "Create Category Missing Name Value Domain Exception")]
        public void CreateCategory_MissingNameValue_DomainExceptionInvalid()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Name invalido. Name é required.");
        }
        [Fact(DisplayName = "Create Category Null Value Name Domain Exception")]
        public void CreateCategory_NullNameValue_DomainExceptionInvalid()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Name invalido. Name é required.");
        }
    }
}
