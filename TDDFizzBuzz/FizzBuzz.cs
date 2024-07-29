public class FizzBuzz
{
    public static void Main(string[] args)
    {
        FizzBuzz fizzBuzz = new FizzBuzz();

        int input = 0;

        fizzBuzz.GetOutput(input);
    }

    public string GetOutput(int number)
    {
        return number.ToString();
    }
}