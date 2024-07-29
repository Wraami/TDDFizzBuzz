using System.Reflection;
using TDDFizzBuzz.Interfaces;
using TDDFizzBuzz.Parsers;

public class FizzBuzz
{ 
    private readonly List<IBaseHelper> _parsers;

    public FizzBuzz()
    {
        _parsers = GetParsers();
    }

    public static void Main(string[] args)
    {
        FizzBuzz fizzBuzz = new FizzBuzz();
 
        fizzBuzz.GetUserInput();

    }

    private List<IBaseHelper> GetParsers()
    {
        var parserType = typeof(IBaseHelper);
        var types = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => parserType.IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface)
            .ToList();

        return types.Select(t => (IBaseHelper)Activator.CreateInstance(t)).ToList();
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
            Console.WriteLine(GetOutput(i));
        }
    }

    public string GetOutput(int number)
    {
        foreach (var parser in _parsers)
        {
            var result = parser.ParseUserInput(number);

            if(result != number.ToString())
            {
                return result;
            }
        }
        return number.ToString();
    }
}