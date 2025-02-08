using Shouldly;
using UserService.Api.Validators;
using UserService.Api.ViewModels;

namespace UserService.Tests
{
    public class CreateUserValidatorTests
    {
        private readonly CreateUserValidator _validator = new();

        [Theory]
        [InlineData("Y",false)]//1 character
        [InlineData("YY",false)]//2 characters
        [InlineData("YYYY",true)]// 4 characters
        [InlineData("yxmbwlzpnfvjcdkrsohgueatqixdsbhjymekqupoltwfgodvc",true)]// 49 characters
        [InlineData("YXJTVBhDKLNzqRmCpwMGZsfyQAtWCEodkVgPXlFHuIObDmaYJR",true)]// 50 characters
        [InlineData("vwxzjbnlcfqgodmtkpyhuesarivdxsbhjyekqumplcwtfogvdkir", false)]//51 characters
        [InlineData("YY YY",false)]// Contain spaces
        [InlineData("YY$YY",false)]// Contain special character
        public void Should_ReturnCorrectValidation_When_GivenName(string name,bool expected)
        {
            //Act
            var userModelTest = CreateUserViewModelData();
            userModelTest.FirstName = name;
            userModelTest.LastName = name;
            
            var result=_validator.Validate(userModelTest);
            result.IsValid.ShouldBe(expected);
        }

        [Theory]
        [InlineData("5",false)]//1 number
        [InlineData("555",false)]// 3 numbers
        [InlineData("55555",false)]//5 numbers
        [InlineData("123456789",false)]//9 numbers
        [InlineData("01234567890",true)]//11 numbers
        [InlineData("1234567890123456789",false)]//19 numbers
        public void Should_ReturnCorrectValidation_WhenGivePhoneNumber(string phoneNumber,bool expected)
        {
            var userModelTest= CreateUserViewModelData();
            userModelTest.PhoneNumber = phoneNumber;

            var result=_validator.Validate(userModelTest);  
            result.IsValid.ShouldBe(expected);
        }

        [Theory]
        [InlineData("example@gmail.com", true)]  // Valid email
        [InlineData("test.email@example.com", true)]  // Valid email with dot
        [InlineData("test_email@example.com", true)]  // Valid email with underscore
        [InlineData("email@domain.co", true)]  // Valid email with a different domain extension
        [InlineData("user123@sub.domain.com", true)]  // Valid email with subdomain
        [InlineData("invalid-email.com", false)]  // Missing "@"
        [InlineData("invalid@domain", false)]  // Missing domain extension
        [InlineData("@missingusername.com", false)]  // Missing username before "@"
        [InlineData("user@.com", false)]  // Invalid domain (starting with a dot)
        public void Should_ReturnCorrectValidation_When_GivenEmail(string email,bool expected)
        {
            var userModelTest = CreateUserViewModelData();
            userModelTest.Email = email;

            var result = _validator.Validate(userModelTest);
            result.IsValid.ShouldBe(expected);
        }
        private static CreateUserViewModel CreateUserViewModelData()
        {
            return new CreateUserViewModel
            {
                FirstName = "testFirstName",
                LastName = "testLastName",
                Email = "example@gmail.com",
                PhoneNumber = "00000000000"
            };

        }

    }
}