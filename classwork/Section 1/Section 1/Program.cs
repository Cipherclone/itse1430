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