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

    //uses reflection to get everything assigned to our helper.
    private List<IBaseHelper> GetParsers()
    {
        var parserType = typeof(IBaseHelper);
        var types = Assembly.GetExecutingAssembly().GetTypes()
            //include only those that implement IBaseHelper and arent abstract or interfaces
            .Where(t => parserType.IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface)
            .Select(x => Activator.CreateInstance(x))
            // cast the created instances to IBaseHelper
            .Cast<IBaseHelper>()
            //orders the list of our ibasehelper instances appropriately so fizzbuzz is priority 
            .OrderByDescending(p => p.divisor)
            .ToList();

        return types;
    }


    public void GetUserInput()
    {
        int startRange;
        int endRange;

        while (true)
        {
            Console.Write("Enter the starting number of your number range: ");
            if(int.TryParse(Console.ReadLine(), out startRange))
            {
                break;
            }

            Console.WriteLine("Invalid input. Enter a valid start range");
        }

        while (true)
        {
            Console.Write("Enter the end number: ");
            if (int.TryParse(Console.ReadLine(), out endRange))
            {
                break;
            }

            Console.WriteLine("Invalid input. Enter a valid number");
        }

        Console.WriteLine("Fizzbuzz results: ");

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