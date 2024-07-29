<h1 align="center">FizzBuzz - TDD</h3>
<a id="top"></a>

<div align="center">
  <img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRRRqcFSRvWJAFKFjRirZo4UOh3jQIe5UFEoA&s" alt="FizzBuzz">
</div>
<br>

<p align="center"><span>TDD approach to fizzbuzz using XUnit</span></p>
<br>
<div align="center">

<br>
<br>

## About

This was a challenge for a timed TDD implementation of the classic children's group word game, Fizzbuzz.

The key challenge here was to use both reflection and solid principles, which typically isn't common for such a simple problem.

(This documentation isn't part of the timed implementation)

## Implementation

I began by creating an interface for a base helper because, for our fizzbuzz implementation, we're primarily focused on just have the return logic for the string / number and the divisor that we're concerned about in each different divisor rule.

Here's how I applied each of the SOLID principles.

S - Single Responsibility Principle  - Each part of our FizzBuzz class has a clear role. User interaction, results display, and input validation are handled in different methods to keep everything organized.

We also have an individual parser class for each aspect of the fizzbuzz game rules, using the single responsibility of parsing and returning the specific string from the divisor.

O - Open/Closed Principle (OCP) - We can extend functionality by adding new parser classes without modifying our existing ones.

The use of reflection allows the FizzBuzz class to discover and instantiate parser classes dynamically.

This allows us to add new parsers without changing the existing FizzBuzz code.

L - Liskov Substitution Principle - Each parser class implements the interface, any IBaseHelper implementation can be used interchangeably in our FizzBuzz class.

I - Interface Segregation Principle - The 'IBaseHelper' Interface provides a simple contract for parsing logic, and doesn't force clients to implement unnecessary properties or methods.

D - Dependency Inversion Principle - The FizzBuzz class depends on the high IBaseHelper abstraction rather than the parser implementations, same with the parsers.


## Key Implementations to Change

### Main Application:

Implementing an abstract base helper class here too would help avoid duplicate logic, especially for our repeated parsing.

```
public abstract class BaseHelper
{
public abstract int Divisor {get; }
public abstract string ResultString {get; }

public virtual string ParseUserInput(int input)
{
if (input % Divisor == 0)
{
return ResultString;
}

return input.ToString();
}
}
```

So in each parser implementation we could just override each and call it like follows:

```
public class FizzParser : BaseHelper 
{
public override int Divisor => 5;
public override string ResultString => "FizzBuzz";`
}
```

We'd then just remove our interface check and check for abstract classes in our reflection implementation in FizzBuzz instead. 

Also, the benefit of adding a conditional check to not allow a user to enter a higher range for the end value than the start range value would prevent any user experience problems.

### Tests: 
Call the centralized FizzBuzz.GetOutput instead of utilizing each parser individually when testing the implementation, simple mistake but currently it tests the same fundamental logic, just adding redundancy.

### Misc:
Fixing formatting, double line spacing, lack of spaces before conditionals et cetera, and implementing PR based code reviews for each feature would be beneficial to add better verification against the workflow file.