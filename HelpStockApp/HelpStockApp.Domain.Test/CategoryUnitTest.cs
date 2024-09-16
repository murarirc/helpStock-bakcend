using HelpStockApp.Domain.Entities;
using FluentAssertions;
using Xunit;
using HelpStockApp.Domain.Validation;
using Newtonsoft.Json.Linq;

namespace HelpStockApp.Domain.Test
{
    
    public class CategoryUnitTest
    {
        #region Testes Positivos da Categoria

        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Eletronics");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        #endregion

        #region Testes Negativos da Categoria (Creature of Darkness, Evil of Moria! You Shall Not Pass!!)

        [Fact(DisplayName = "Create Category With Invalid Id")]
        public void CreateCategory_WithInvalidParametersId_ResultException()
        {
            Action action = () => new Category(-1, "Eletronics");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id value.");
        }

        #endregion

        #region Exercícios

        [Fact(DisplayName = "Create Category With Short Name")]
        public void CreateCategory_WithShortNameParameter_ResultException()
        {
            Action action = () => new Category(1, "E");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, too short. minimum 3 characters!");
        }



        [Fact(DisplayName = "Create Category With Null Name")]
        public void CreateCategory_WithNullNameParameter_ResultException()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, name is required!");
        }



        [Fact(DisplayName = "Create Category With Name Missing")]
        public void CreateCategory_WithNameMissingParameter_ResultException()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, name is required!");
        }


        /*
                [Fact(DisplayName = "Create Category With Id Character")]
                public void CreateCategory_WithIdCharacterParameter_ResultException()
                {
                    Action action = () => new Category( , "Electronics");
                    action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id, Must be number.");
                }
        */


        #endregion

        #region último ex.

        [Fact(DisplayName = "Create Category With Category Name Alone")]
        public void CreateCategory_WithCategoryNameAloneParameter_ResultException()
        {
            Action action = () => new Category("Electronics");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        #endregion

        /*
         * Create category with name short parameter +++
         * Create category with name null parameter +++
         * Create category with name missing parameter +++
         * Create category with id character parameter +++
         * Create category with category name alone parameter +++
         */
    }
}
