using System;
using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace CleanArchitecture.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name ");
            action.Should()
                 .NotThrow<CleanArchitecture.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category With Negative Id Throws Exception")]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name ");
            action.Should()
                .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid Id value");
        }

        [Fact(DisplayName = "Create Category With Short Name Throws Exception")]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
                   .WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact(DisplayName = "Create Category With Empty Name Throws Exception")]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Create Category With Null Name Throws Exception")]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>();
        }
    }
}
