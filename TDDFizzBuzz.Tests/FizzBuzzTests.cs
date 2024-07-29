using TDDFizzBuzz.Parsers;

namespace TDDFizzBuzz.Tests
{
    public class FizzBuzzTests
    {

        private readonly FizzParser _fizzparser;

        public FizzBuzzTests()
        {
            _fizzparser = new FizzParser();
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
    }
}