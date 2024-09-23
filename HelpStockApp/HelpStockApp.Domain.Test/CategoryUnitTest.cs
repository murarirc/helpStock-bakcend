using FluentAssertions;
using HelpStockApp.Domain.Entities;
using HelpStockApp.Domain.Validation;
using Xunit;


namespace HelpStockApp.Domain.Test
{
    
    public class CategoryUnitTest
    {
        #region testes positivos de categoria
        [Fact(DisplayName = "Create Category with Valid State")]
        public void CreateCategory_WithValidParameter_ResultObjectsValidState()
        {
            Action action = () => new Category(1, "Electronic");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category With Category Name Alone Parameter.")]
        public void CreateCategory_WithValidParameterName_ResultObjectsValidState()
        {
            Action action = () => new Category("Electronics");
            action.Should().NotThrow<DomainExceptionValidation>();
        }
        #endregion

        #region Testes negativos de categoria
        [Fact(DisplayName = "Create Category With Valid Id")]
        public void CreateCategory_WithInvalidParametersId_ResultException()
        {
            Action action = () => new Category(-1, "Electronic");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid ID Value");
        }

        [Fact(DisplayName = "Create Category With Name too short parameter")]
        public void CreateCategory_WithNameTooShortParameter_ResultException()
        {
            Action action = () => new Category(1, "E");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, too short. minimum 3 characters!");
        }

        [Fact(DisplayName = "Create Category With Name Null Parameter")]
        public void CreateCategory_WithNameNullParameter_ResultException()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, name is required!");
        }

        [Fact(DisplayName = "Create Category With Name Missing Parameter")]
        public void CreateCategory_WithNameMissingParameter_ResultException()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, name is required!");
        }
        #endregion
    }
}
