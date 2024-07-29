using TDDFizzBuzz.Parsers;

namespace TDDFizzBuzz.Tests
{
    public class FizzBuzzTests
    {

        private readonly FizzParser _fizzparser;
        private readonly BuzzParser _buzzparser;
        private readonly FizzBuzzParser _fizzbuzzparser;

        public FizzBuzzTests()
        {
            _fizzparser = new FizzParser();
            _buzzparser = new BuzzParser();
            _fizzbuzzparser = new FizzBuzzParser();
        }

        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(9)]
        public void FizzParser_ShouldReturnFizz_WhenDivisibleByThree(int input)
        {
            //Arrange

            //Act
            string result = _fizzparser.ParseUserInput(input);

            //Assert
            Assert.Equal("Fizz", result);
        }


        [Theory]
        [InlineData(1)]
        [InlineData(4)]
        [InlineData(44)]
        [InlineData(71)]
        public void FizzParser_ShouldReturnFizz_WhenNotDivisibleByThree(int input)
        {
            // Arrange
         
            // Act
            string result = _fizzparser.ParseUserInput(input);
            
            // Assert
            Assert.NotEqual("Fizz", result);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        public void BuzzParser_ShouldReturnBuzz_WhenDivisibleByFive(int input)
        {

            //Act
            string result = _buzzparser.ParseUserInput(input);

            //Assert
            Assert.Equal("Buzz", result);

        }

        [Theory]
        [InlineData(14)]
        [InlineData(17)]
        [InlineData(87)]
        [InlineData(407)]
        public void BuzzParser_ShouldNotReturnBuzz_WhenNotDivisibleByFive(int input)
        {
            // Arrange
            // Act
            string result = _buzzparser.ParseUserInput(input);
            // Assert
            Assert.NotEqual("Buzz", result);
        }

        [Theory]
        [InlineData(15)]
        [InlineData(75)]
        [InlineData(90)]
        public void FizzBuzzParser_ShouldReturnFizzBuzz_WhenDivisibleByThreeAndFive(int input)
        {
            // Arrange

            // Act
            string result = _fizzbuzzparser.ParseUserInput(input);
            // Assert
            Assert.Equal("FizzBuzz", result);
        }
    }
}