// movie definition
string title = "";
string description = "";
int runLength = 0; // in minutes
int releaseYear = 1900;
string rating = "";
bool isClassic = false;


title = ReadString("Enter a title: ");

description = ReadString("Enter an optional desctription: ");
runLength = ReadInt32("Enter a run length (in minutes): ");

releaseYear = ReadInt32("Enter a release year: ");
rating = ReadString("Enter a MPAA rating: ");
Console.WriteLine("Is this a classic? ");

string ReadString(string message)
{
    Console.WriteLine(message);

    string value = Console.ReadLine();

    return value;
    
}

int ReadInt32(string message)
{
    Console.Write(message);
    string value = Console.ReadLine();

    if (Int32.TryParse(value, out int result))
        return result;
    else
        return -1;
    
}
