// movie definition
string title = "";
string description = "";
int runLength = 0; // in minutes
int releaseYear = 1900;
string rating = "";
bool isClassic = false;


DisplayInformation();
bool done = false;
do 
{
    
    MenuOption input = DisplayMenu();
    Console.WriteLine();

    switch(input)
    {
        case MenuOption.Add: AddMovie(); break;
        case MenuOption.Edit: EditMovie(); break;
        case MenuOption.View: ViewMovie(); break;
        case MenuOption.Delete: DeleteMovie(); break;
        case MenuOption.Quit: done = true; break;
    };
    //if (input == 'A')
    //    AddMovie();
    //else if (input == 'E')
    //    EditMovie();
    //else if (input == 'V')
    //    ViewMovie();
    //else if (input == 'D')
    //    DeleteMovie();
    //else if (input == 'Q')
    //    break;
} while (!done);

// Functions

void DisplayInformation()
{
    Console.WriteLine("Movie Library");
    Console.WriteLine("ITSE 1430 James Sparkman");
    Console.WriteLine("Fall 2022"); 
}

MenuOption DisplayMenu()
{
    Console.WriteLine();
    Console.WriteLine("A)dd Movie");
    Console.WriteLine("E)dit Movie");
    Console.WriteLine("V)iew Movie");
    Console.WriteLine("D)elete Movie");
    Console.WriteLine("Q)uit");

    
    do
    {
        ConsoleKeyInfo key = Console.ReadKey(true);
        switch(key.Key)
        {
            case ConsoleKey.A: return MenuOption.Add;
            case ConsoleKey.E: return MenuOption.Edit;
            case ConsoleKey.V: return MenuOption.View;
            case ConsoleKey.D: return MenuOption.Delete;
            case ConsoleKey.Q: return MenuOption.Quit;
        };
        
        /* if (key.Key == ConsoleKey.A)
            return 'A';
        else if (key.Key == ConsoleKey.E)
            return 'E';    
        else if (key.Key == ConsoleKey.V)
            return 'V';
        else if (key.Key == ConsoleKey.D)
            return 'D';
        else if (key.Key == ConsoleKey.Q)
            return 'Q';
        */
    } while (true);

}

bool ReadBoolean( string message)
{
    Console.Write(message);

    // looking for y/n

    do 
    { 
        ConsoleKeyInfo key = Console.ReadKey();

        if (key.Key == ConsoleKey.Y)
            return true;
        else if (key.Key == ConsoleKey.N)
            return false;

    } while (true);

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

void EditMovie()
{ }

void DeleteMovie()
{
    if (title == "") // no movie
        return;

    // not confirmed
    if (!ReadBoolean("Are you sure you want to delete the movie (Y/N)? "))
        return;

    //TODO Delete Movie
    title = "";

}

void ViewMovie()
{
    if (title == "")
    {
        Console.WriteLine("No movies available");
        return;
    }

    Console.WriteLine(title);
    Console.WriteLine(releaseYear);
    Console.WriteLine("Length: " + runLength + " mins");
    Console.WriteLine("MPAA Rating: " + rating);
    Console.WriteLine("Classic: " + isClassic);
    Console.WriteLine(description);

}