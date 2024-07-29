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
        int startRange = GetValidNumberForRange("Enter the starting number of your range: ");
        int endRange = GetValidNumberForRange("Enter the end number of your range: ");

        Console.WriteLine("FizzBuzz results: ");
        for (int i = startRange; i <= endRange; i++)
        {
            Console.WriteLine(GetOutput(i));
        }
    }

    private int GetValidNumberForRange(string prompt)
    {
        int number;
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out number))
            {
                return number;
            }
            Console.WriteLine("Invalid input. Please enter a valid number!");
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