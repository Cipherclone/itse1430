// movie definition
string title = "";
string description = "";
int runLength = 0; // in minutes
int releaseYear = 1900;
string rating = "";
bool isClassic = false;
AddMovie();

bool ReadBoolean( string message)
{
    Console.Write(message);

    // looking for y/n
    ConsoleKeyInfo key = Console.ReadKey();

    if (key.Key == ConsoleKey.Y)
        return true;
    else if (key.Key == ConsoleKey.N)
        return false;
    
    //TODO error
    return false;
}


string ReadString(string message, bool required)
{
    Console.WriteLine(message);

    while (true)
    {

        string value = Console.ReadLine();


        // check the boolean

        // TODO value empty and required
        if (value != "" || !required)
            return value;

        Console.WriteLine("Value is required");

    };
}

int ReadInt32(string message, int mininmumValue, int maximumValue)
{
    Console.Write(message);

    do
    {
        string value = Console.ReadLine();

        if (Int32.TryParse(value, out int result))
        {
            if (result >= mininmumValue && result <= maximumValue)
            return result;

        }

        Console.WriteLine("Value must be between " + mininmumValue + " and " + maximumValue);
        //TODO loop

        //breaks exit loop
        //continue iterates

    } while (true);


    
    
}

void AddMovie ()
{
    title = ReadString("Enter a title: ", true);
    description = ReadString("Enter an optional desctription: ", false);
    runLength = ReadInt32("Enter a run length (in minutes): ", 0, 300);
    releaseYear = ReadInt32("Enter a release year: ", 1900, 2100);
    rating = ReadString("Enter a MPAA rating: ", true);
    isClassic = ReadBoolean("Is this a classic? ");
}
