int hours;

Console.WriteLine("Hours: ");
string value = Console.ReadLine();

hours = Int32.Parse(value);

Console.WriteLine("Pay Rate: ");
value = Console.ReadLine();

double payRate = Double.Parse(value);

Console.WriteLine("Your pay is " + (hours * payRate));


// stringsss
string emptyString = "";
string emptyString2 = String.Empty;
// never leave null
bool isEmptyString = String.IsNullOrEmpty(emptyString); // how to look

// literal
string someString = "Hello \"World";

// verbatum
string someString2 = @"C:\windows\system32";


//concatination

string fullName = "Bob" + " " + "Smith";
// strings are immutable!

string names = String.Join(", ", "Bob", "Sue", "Jan");
// outputs Bob, Sue, Jan
// .length gives character lenghs
// .ToUpper makes all upper
/* same with lower
 * trim removes a empty spaces around content (.Trim() .TrimStart() .TrimEnd())
 * .StartsWith(string)
 * .EndsWith(string)
 * 
 * stringcomparison is usefull
 * 
 * 
 * 
 * 
 */ 

bool areEqual = fullName == someString;     

string input = Console.ReadLine();

if (String.Compare(input, "A", StringComparison.OrdinalIgnoreCase) == 0) // >0 means left > right and <0 is left <vright
    Console.WriteLine("A");


if (String.Equals(input, "A", StringComparison.OrdinalIgnoreCase))
    Console.WriteLine("A");