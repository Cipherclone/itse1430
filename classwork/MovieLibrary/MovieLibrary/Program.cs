// movie definition
using MovieLibrary;

//Movie movie = new Movie();


DisplayInformation();
var done = false;
Movie movie = null;

MovieDatabase database = new MovieDatabase();
do 
{
    // type inferencing = compiler figures out type based upon context
    //MenuOption input = DisplayMenu();

    var input = DisplayMenu();
    Console.WriteLine();

    switch(input)
    {
        case MenuOption.Add:
        {
            var theMovie = AddMovie();
            movie = theMovie.Clone(); 
            
            break; 
        }
        case MenuOption.Edit: EditMovie(); break;
        case MenuOption.View: ViewMovie(movie); break;
        case MenuOption.Delete: DeleteMovie(); break;
        case MenuOption.Quit: done = true; break;
    };
    
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
    //Console.WriteLine("--------------");
    Console.WriteLine("".PadLeft(10, '-'));
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

    } while (true);

}

bool ReadBoolean(string message)
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

        if (Int32.TryParse(value, out var result))
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

Movie AddMovie()
{
    Movie movie = new Movie("Title");

    //movie.title = ReadString("Enter a title: , true);
    movie.Title = ReadString("Enter a title: ", true);
    
    movie.Description = ReadString("Enter an optional desctription: ", false);
    movie.RunLength = ReadInt32("Enter a run length (in minutes): ", 0, 300);
    if (movie.ReleaseYear >= Movie.YearColorWasIntroduced)
        Console.WriteLine("Wow that is an old movie");
    movie.ReleaseYear = ReadInt32("Enter a release year: ", 1900, 2100);
    movie.Rating = ReadString("Enter a MPAA rating: ", true);
    movie.IsClassic = ReadBoolean("Is this a classic? ");

    
    return movie;
}

Movie GetSelectedMovie()
{
    return movie;
}

void EditMovie()
{ }

void DeleteMovie()
{
    var selectedMovie = GetSelectedMovie();


    if (selectedMovie == null) // no movie
        return;

    // not confirmed
    if (!ReadBoolean($"Are you sure you want to delete the movie '{selectedMovie.Title}' (Y/N)? "))
        return;

    //TODO Delete Movie
    selectedMovie = null;

}

void ViewMovie( Movie movie)
{
    if (movie == null)
    {
        Console.WriteLine("No movies available");
        return;
    }

    
    /*String Formatting
    //Option 1 - concatination
    //Console.WriteLine("Length: " + runLength + " mins");

    //Option 2 - String.Format
    //Console.WriteLine(String.Format("Length: {0:000  } mins", runlength)   );

    //Option 3 - String interpolation
    //Console.WriteLine($"Length: {runLength} mins");

    ToString
    */
    
    //Console.WriteLine(releaseYear);

    Console.WriteLine($"{movie.Title} ({movie.ReleaseYear})");
    Console.WriteLine($"Length: {movie.RunLength} mins");
    //Console.WriteLine("MPAA Rating: " + rating);
    Console.WriteLine($"Rated {movie.Rating}");
    //Console.WriteLine($"This {(isClassic ? "Is" : "Is Not")} a Classic");
    Console.WriteLine($"Is Classic: {(movie.IsClassic ? "Yes" : "No")}");
    Console.WriteLine(movie.Description);

    var blackAndWhite = movie.IsBlackAndWhite;

}