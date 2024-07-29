using TDDFizzBuzz.Parsers;

public class FizzBuzz
{
    private FizzParser _fizzParser;

    public FizzBuzz()
    {
        _fizzParser = new FizzParser();
    }

    public static void Main(string[] args)
    {
        FizzBuzz fizzBuzz = new FizzBuzz();
 
        fizzBuzz.GetUserInput();

    }

    public void GetUserInput()
    {
        int startRange;
        int endRange;

        while (true)
        {
            Console.Write("Enter the starting number: ");
            if(int.TryParse(Console.ReadLine(), out startRange))
            {
                break;
            }

            Console.WriteLine("Invalid input. Enter a valid start range");
        }

        while (true)
        {
            Console.Write("Enter the starting number: ");
            if (int.TryParse(Console.ReadLine(), out endRange))
            {
                break;
            }

            Console.WriteLine("Invalid input. Enter a valid number");
        }

        for(int i = startRange; i <= endRange; i++)
        {
            Console.WriteLine(_fizzParser.ParseUserInput(i));
        }
    }
}