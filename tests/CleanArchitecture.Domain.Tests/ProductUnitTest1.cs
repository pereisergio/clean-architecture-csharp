using System;
using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace CleanArchitecture.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m,
                99, "product image");
            action.Should()
                .NotThrow<CleanArchitecture.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Negative Id Throws Exception")]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m,
                99, "product image");

            action.Should().Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

        [Fact(DisplayName = "Create Product With Short Name Throws Exception")]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 9.99m, 99,
                "product image");
            action.Should().Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact(DisplayName = "Create Product With Long Image Name Throws Exception")]
        public void CreateProduct_LongImageName_DomainExceptionLongImageName()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m,
                99, "product image toooooooooooooooooooooooooooooooooooooooooooo loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooogggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg");

            action.Should()
                .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid image name, too long, maximum 250 characters");
        }

        [Fact(DisplayName = "Create Product With Null Image Name Does Not Throw Exception")]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);
            action.Should().NotThrow<CleanArchitecture.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Null Image Name Does Not Throw NullReferenceException")]
        public void CreateProduct_WithNullImageName_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);
            action.Should().NotThrow<NullReferenceException>();
        }

        [Fact(DisplayName = "Create Product With Empty Image Name Does Not Throw Exception")]
        public void CreateProduct_WithEmptyImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "");
            action.Should().NotThrow<CleanArchitecture.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Negative Price Throws Exception")]
        public void CreateProduct_InvalidPriceValue_DomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", -9.99m,
                99, "");
            action.Should().Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid price value");
        }

        [Theory(DisplayName = "Create Product With Negative Stock Throws Exception")]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Product(1, "Pro", "Product Description", 9.99m, value,
                "product image");
            action.Should().Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
                   .WithMessage("Invalid stock value");
        }
    }
}
