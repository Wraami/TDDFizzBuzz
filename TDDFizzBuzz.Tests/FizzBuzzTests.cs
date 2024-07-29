namespace TDDFizzBuzz.Tests
{
    public class FizzBuzzTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void get_output_should_return_fizz(int input)
        {
            //Arrange
            var fizzBuzz = new FizzBuzz();

            //Act
           string result = fizzBuzz.GetOutput(input);

            //Assert
            Assert.Equal("Fizz", result);
        }
    }
}