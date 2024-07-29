using TDDFizzBuzz.Parsers;

namespace TDDFizzBuzz.Tests
{
    public class FizzBuzzTests
    {

        private readonly FizzParser _fizzparser;
        private readonly BuzzParser _buzzparser;

        public FizzBuzzTests()
        {
            _fizzparser = new FizzParser();
            _buzzparser = new BuzzParser();
        }

        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(9)]
        public void get_output_should_return_fizz(int input)
        {
            //Arrange

            //Act
            string result = _fizzparser.ParseUserInput(input);

            //Assert
            Assert.Equal("Fizz", result);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        public void get_output_should_return_buzz(int input)
        {

            //Act
            string result = _buzzparser.ParseUserInput(input);

            //Assert
            Assert.Equal("Buzz", result);

        }
    }
}