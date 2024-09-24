using FluentAssertions;
using HelpStockApp.Domain.Entities;
using HelpStockApp.Domain.Validation;
using System.Xml.Serialization;
using Xunit;


namespace HelpStockApp.Domain.Test
{
    public class ProductUnitTest
    {
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParameter_ResultObjectsValidState()
        {
            Action action = () => new Product(1, "Ventilador", "Ventilador Mondial Turbo Silencioso", 89.99m, 5, "imgvent");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Invalid Id")]
        public void CreateProduct_WithInvalidIdParameter_ResultException()
        {
            Action action = () => new Product(-1, "Ventilador", "Ventilador Mondial Turbo Silencioso", 89.99m, 5, "imgvent");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id value.");
        }

        [Fact(DisplayName = "Create Product With Invalid Price")]
        public void CreateProduct_WithInvalidPriceParameter_ResultException()
        {
            Action action = () => new Product(1, "Ventilador", "Ventilador Mondial Turbo Silencioso", -1, 5, "imgvent");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Price, price negative value is unlikely!");
        }
        [Fact(DisplayName = "Create Product With Invalid Stock")]
        public void CreateProduct_WithInvalidStockParameter_ResultException()
        {
            Action action = () => new Product(1, "Ventilador", "Ventilador Mondial Turbo Silencioso", 89.99m, -1, "imgvent");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Stock, stock negative value is unlikely!");
        }
        [Fact(DisplayName = "Create Product With Null Name")]
        public void CreateProduct_WithNullNameParameter_ResultException()
        {
            Action action = () => new Product(1, null, "Ventilador Mondial Turbo Silencioso", 89.99m, 5, "imgvent");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, name is required!");
        }
        [Fact(DisplayName = "Create Product With Short Name")]
        public void CreateProduct_WithShortNameParameter_ResultException()
        {
            Action action = () => new Product(1, "Ve", "Ventilador Mondial Turbo Silencioso", 89.99m, 5, "imgvent");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, too short. minimum 3 characters!");
        }
        [Fact(DisplayName = "Create Product With Null Description")]
        public void CreateProduct_WithNullDescriptionParameter_ResultException()
        {
            Action action = () => new Product(1, "Ventilador", null, 89.99m, 5, "imgvent");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid description, description is required!");
        }
        [Fact(DisplayName = "Create Product With Short Description")]
        public void CreateProduct_WithShortDescriptionParameter_ResultException()
        {
            Action action = () => new Product(1, "Ventilador", "Vent", 89.99m, 5, "imgvent");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid description, too short. minimum 5 characters!");
        }
        [Fact(DisplayName = "Create Product With Empty Name")]
        public void CreateProduct_WithEmptyNameParameter_ResultException()
        {
            Action action = () => new Product(1, "", "Ventilador Mondial Turbo Silencioso", 89.99m, 5, "imgvent");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, name is required!");
        }
        [Fact(DisplayName = "Create Product With Empty Description")]
        public void CreateProduct_WithEmptyDescriptionParameter_ResultException()
        {
            Action action = () => new Product(1, "Ventilador", "", 89.99m, 5, "imgvent");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid description, description is required!");
        }
        [Fact(DisplayName = "Create Product With Long Image Url")]
        public void CreateProduct_WithLongImageUrlParameter_ResultException()
        {
            Action action = () => new Product(1, "Ventilador", "Ventilador Mondial Turbo Silencioso", 89.99m, 5, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed eu est urna. Fusce ligula urna, porttitor eu dictum non, dapibus sed est. Aenean id quam lacus. Nulla nec finibus nisl. Ut dignissim id ipsum eu commodo. Sed leo elit, hendrerit vel bibendum et, pharetra sit amet lectus. Cras sit amet porta justo, non eleifend sem. Sed at leo lacus. Etiam quis justo in turpis scelerisque laoreet vel id urna. Maecenas tempus, lacus eget tincidunt interdum, nisl velit volutpat erat, non commodo lectus orci vitae nunc. Aenean sodales mi sed ex tristique laoreet. Vivamus facilisis nunc non risus consequat, vitae volutpat neque ultricies. Integer tempus gravida sagittis. Praesent convallis ultrices nibh in sollicitudin.");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid image URL, too long. maximum 250 characters!");
        }
        [Fact(DisplayName = "Create Product With Null Image Url")]
        public void CreateProduct_WithNullImageUrlParameter_ResultException()
        {
            Action action = () => new Product(1, "Ventilador", "Ventilador Mondial Turbo Silencioso", 89.99m, 5, null);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid description, description is required!");
        }
        [Fact(DisplayName = "Create Product With Empty Image Url")]
        public void CreateProduct_WithEmptyImageUrlParameter_ResultException()
        {
            Action action = () => new Product(1, "Ventilador", "Ventilador Mondial Turbo Silencioso", 89.99m, 5, "");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid description, description is required!");
        }
    }
}
