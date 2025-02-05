using Shouldly;
using UserService.Api.Controllers.ViewModel;
using UserService.Api.Validators;

namespace UserService.Tests
{
    public class CreateUserValidatorTests
    {

        private readonly CreateUserValidator _validator;

        public CreateUserValidatorTests()
        {
            _validator = new CreateUserValidator();
        }

        [Fact]
        public void Should_Return_False_When_FirstName_Is_Empty()
        {
            var model = new CreateUserViewModel() { FirstName = "", LastName = "Chkeir", Email = "Mohamad@gmail.com", PhoneNumber = "01234567891" };
            var result = _validator.Validate(model);
            result.IsValid.ShouldBeFalse();
        }

        [Fact]
        public void Should_Return_False_When_FirstName_Less_than_Five_Character()
        {
            var model = new CreateUserViewModel() { FirstName = "ali", LastName = "Chkeir", Email = "Mhmd@gmail.com", PhoneNumber = "01234567891" };
            var result = _validator.Validate(model);
            result.IsValid.ShouldBeFalse();
        }
        [Fact]
        public void Should_Return_False_When_FirstName_Greater_Than_Fifty()
        {
            var model = new CreateUserViewModel() { FirstName = "aliddddddddeefrddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd", LastName = "Chkeir", Email = "Mhmd@gmail.com", PhoneNumber = "01234567891" };
            var result = _validator.Validate(model);
            result.IsValid.ShouldBeFalse(); 
        }
        [Fact]
        public void Should_Return_True_When_FirstName_Is_Between_five_And_fifty_Charachters()
        {
            var model = new CreateUserViewModel() { FirstName = "Mohamad", LastName = "Chkeir", Email = "Mohamad@gmail.com", PhoneNumber = "01234567891" };
            var result = _validator.Validate(model);
            result.IsValid.ShouldBeTrue();
        }
        [Fact]
        public void Should_Return_False_When_FirstName_Contains_Special_Characters_Or_Space()
        {
            var model = new CreateUserViewModel() { FirstName = "Mohac mad", LastName = "Chkeir", Email = "Mohamad@gmail.com", PhoneNumber = "01234567891" };
            var result = _validator.Validate(model);
            result.IsValid.ShouldBeFalse();
        }
        [Fact]
        public void Should_Return_False_When_LastName_Is_Empty()
        {
            var model = new CreateUserViewModel() { FirstName = "", LastName = "Chkeir", Email = "Mohamad@gmail.com", PhoneNumber = "01234567891" };
            var result = _validator.Validate(model);
            result.IsValid.ShouldBeFalse();
        }

        [Fact]
        public void Should_Return_False_When_LastName_Less_than_Five_Character()
        {
            var model = new CreateUserViewModel() { FirstName = "ali", LastName = "Chkeir", Email = "Mhmd@gmail.com", PhoneNumber = "01234567891" };
            var result = _validator.Validate(model);
            result.IsValid.ShouldBeFalse();
        }
        [Fact]
        public void Should_Return_False_When_LastName_Greater_Than_Fifty()
        {
            var model = new CreateUserViewModel() { FirstName = "aliddddddddeefrddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd", LastName = "Chkeir", Email = "Mhmd@gmail.com", PhoneNumber = "01234567891" };
            var result = _validator.Validate(model);
            result.IsValid.ShouldBeFalse();
        }
        [Fact]
        public void Should_Return_True_When_LastName_Is_Between_five_And_fifty_Charachters()
        {
            var model = new CreateUserViewModel() { FirstName = "Mohamad", LastName = "Chkeir", Email = "Mohamad@gmail.com", PhoneNumber = "01234567891" };
            var result = _validator.Validate(model);
            result.IsValid.ShouldBeTrue();
        }
        [Fact]
        public void Should_Return_False_When_LastName_Contains_Special_Characters_Or_Space()
        {
            var model = new CreateUserViewModel() { FirstName = "Mohac mad", LastName = "Chkeir", Email = "Mohamad@gmail.com", PhoneNumber = "01234567891" };
            var result = _validator.Validate(model);
            result.IsValid.ShouldBeFalse();
        }
        [Fact]
        public void Should_Return_False_When_Email_Is_With_Invalid_Format()
        {
            var model = new CreateUserViewModel() { FirstName = "Mohacmad", LastName = "Chkeir", Email = "Mohamad", PhoneNumber = "01234567891" };
            var result = _validator.Validate(model);
            result.IsValid.ShouldBeFalse();
        }
        [Fact]
        public void Should_Return_True_When_Email_Is_With_Valid_Format()
        {
            var model = new CreateUserViewModel() { FirstName = "Mohacmad", LastName = "Chkeir", Email = "Mohamad@gmail.com", PhoneNumber = "01234567891" };
            var result = _validator.Validate(model);
            result.IsValid.ShouldBeTrue();
        }
        [Fact]
        public void Should_Return_False_When_PhoneNumber_Is_Less_Than_Eleven_Characters()
        {
             var model = new CreateUserViewModel() { FirstName = "Mohacmad", LastName = "Chkeir", Email = "Mohamad@gmail.com", PhoneNumber = "017891" };
             var result = _validator.Validate(model);
            result.IsValid.ShouldBeFalse();
        }
        [Fact]
        public void Should_Return_False_When_PhoneNumber_Is_Greater_Than_Eleven_Characters()
        {
            var model = new CreateUserViewModel() { FirstName = "Mohacmad", LastName = "Chkeir", Email = "Mohamad@gmail.com", PhoneNumber = "017123324424891" };
            var result = _validator.Validate(model);
            result.IsValid.ShouldBeFalse();
        }

        [Fact]
        public void Should_Return_True_When_PhoneNumber_Is_Equal_To_Eleven_Characters()
        {
            var model = new CreateUserViewModel() { FirstName = "Mohacmad", LastName = "Chkeir", Email = "Mohamad@gmail.com", PhoneNumber = "01234567891" };
            var result = _validator.Validate(model);
            result.IsValid.ShouldBeTrue();
        }
    }
}