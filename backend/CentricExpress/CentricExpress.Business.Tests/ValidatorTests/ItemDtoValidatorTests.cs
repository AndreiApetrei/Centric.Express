using System;
using System.Linq;
using System.Text;

using CentricExpress.Business.DTOs;
using CentricExpress.Business.Validators;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CentricExpress.Business.Tests.ValidatorTests
{
    [TestClass]
    public class ItemDtoValidatorTests
    {
        private ItemDtoValidator sut;

        [TestInitialize]
        public void Initialize()
        {
            sut = new ItemDtoValidator();
        }

        [TestMethod]
        public void Given_OtherPropsAreValid_When_DescriptionHas15Chars_Then_ShouldReturnValid()
        {
            //arrange
            var itemDto = new ItemDto
                          {
                              Description = "somedescription",
                              Price = 10, Currency = "EUR"
                          };

            //act
            var result = sut.Validate(itemDto);

            //assert
            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void Given_OtherPropsAreValid_When_DescriptionIs3008Chars_Then_ShouldReturnLengthError()
        {
            //arrange
            var expectedMessage = "Description's length must be between 10 and 3000";

            var _10charsDescription = "somedescription ";
            var longDescription = new StringBuilder(_10charsDescription);
            while (longDescription.Length <= 3000)
            {
                longDescription.Append(_10charsDescription);
            }

            var itemDto = new ItemDto
                          {
                              Description = longDescription.ToString(),
                              Price = 10
                          };

            //act
            var result = sut.Validate(itemDto);

            //assert
            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.Any(vf => vf.ErrorMessage.Equals(expectedMessage, StringComparison.InvariantCultureIgnoreCase)));
        }

        [TestMethod]
        public void Given_OtherPropsAreValid_When_DescriptionIsLessThanTenChars_Then_ShouldReturnLengthError()
        {
            //arrange
            var expectedMessage = "Description's length must be between 10 and 3000";
            var itemDto = new ItemDto
                          {
                              Description = "somedesc",
                              Price = 10
                          };

            //act
            var result = sut.Validate(itemDto);

            //assert
            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.Any(vf => vf.ErrorMessage.Equals(expectedMessage, StringComparison.InvariantCultureIgnoreCase)));
        }

        [TestMethod]
        public void Given_OtherPropsAreValid_When_PriceIsMinusOne_Then_ShouldReturnGreaterThanError()
        {
            //arrange
            var itemDto = new ItemDto
                          {
                              Description = "somedescription",
                              Price = -1
                          };

            //act
            var result = sut.Validate(itemDto);

            //assert
            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.Any(vf => vf.PropertyName == nameof(ItemDto.Price)));
        }

        [TestMethod]
        public void Given_OtherPropsAreValid_When_PriceIsTen_Then_ShouldReturnValid()
        {
            //arrange
            var itemDto = new ItemDto
                          {
                              Description = "somedescription",
                              Price = 10, Currency = "EUR"
                          };

            //act
            var result = sut.Validate(itemDto);

            //assert
            Assert.IsTrue(result.IsValid);
        }
    }
}