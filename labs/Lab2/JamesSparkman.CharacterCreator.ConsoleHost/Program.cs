/*
ITSE 1430 
Fall 2022
James Sparkman
*/

using JamesSparkman.CharacterCreator;
DisplayInformation();

Character character = null;
bool done = false;

do
{
    MenuOption input = DisplayMenu();
    
    switch (input)
    {
        case MenuOption.CreateCharacter:
        {
            var theCharacter = AddCharacter();
            character = theCharacter.Clone();
            break;
        }
        case MenuOption.EditCharacter:
        {
            var theCharacter = EditCharacter(character);
            character = theCharacter.Clone();
            break;
        }
        case MenuOption.DeleteCharacter:
        {
            var theCharacter = DeleteCharacter(character);
            if (theCharacter)
            {
                character = null;
            }
            break;
        }
        case MenuOption.ViewCharacter: ViewCharacter(character); break;
        case MenuOption.Quit: done = ReadBoolean("Are you sure you wish to quit? (Y/N)"); break;
    }
} while (!done);

void DisplayInformation()
{
    Console.WriteLine("James Sparkman");
    Console.WriteLine("ITSE 1430");
    Console.WriteLine("October 15th, 2022");
}

MenuOption DisplayMenu()
{
    Console.WriteLine();
    Console.WriteLine("MAIN MENU");
    Console.WriteLine("C)reate New Character");
    Console.WriteLine("V)iew Character");
    Console.WriteLine("E)dit Character");
    Console.WriteLine("D)elete Character");
    Console.WriteLine("Q)uit");
    Console.WriteLine();

    do
    {
        ConsoleKeyInfo key = Console.ReadKey(true);
        switch (key.Key)
        {
            case ConsoleKey.Q: return MenuOption.Quit;
            case ConsoleKey.C: return MenuOption.CreateCharacter;
            case ConsoleKey.V: return MenuOption.ViewCharacter;
            case ConsoleKey.E: return MenuOption.EditCharacter;
            case ConsoleKey.D: return MenuOption.DeleteCharacter;
        }
    } while (true);
}

bool ReadBoolean(string message)
{
    Console.WriteLine(message);
    do
    {
        ConsoleKeyInfo key = Console.ReadKey(true);
        if (key.Key == ConsoleKey.Y)
            return true;
        else if (key.Key == ConsoleKey.N)
            return false;
    } while (true);
}

int ReadInt32(string message)
{
    int minimumValue = 1;
    int maximumValue = 100;
    Console.WriteLine(message);
    bool done = false;
    do
    {
        string value = Console.ReadLine();

        if (Int32.TryParse(value, out var result))
        {
            if (result >= minimumValue && result <= maximumValue)
            {
                if (ReadBoolean("Is " + result + " the correct value? (Y/N)"))
                {
                    done = true;
                    return result;
                }
            }      
        };
    } while (!done);
    
    return -1;
}

string ReadString(string message, bool required)
{
    Console.WriteLine(message);

    while (true)
    {
        string value = Console.ReadLine();

        if (value != "" || !required)
            return value;

        Console.WriteLine("Value is required");
    };
}

string GetProfession ()
{
    string option = "";

    Console.WriteLine("Please choose a Profession:");
    Console.WriteLine("F) Fighter");
    Console.WriteLine("H) Hunter");
    Console.WriteLine("P) Priest");
    Console.WriteLine("R) Rouge");
    Console.WriteLine("W) Wizard");

    bool done = false;

    do
    {
        ConsoleKeyInfo key = Console.ReadKey(true);

        switch (key.Key)
        {
            case ConsoleKey.F: option = "Fighter"; done = true; break;
            case ConsoleKey.H: option = "Hunter"; done = true; break;
            case ConsoleKey.P: option = "Priest"; done = true; break;
            case ConsoleKey.R: option = "Rouge"; done = true; break;
            case ConsoleKey.W: option = "Wizard"; done = true; break;
        }
    } while (!done);

    return option;
}

string GetRace()
{
    string option = "";
    
    Console.WriteLine("Please choose a Race:");
    Console.WriteLine("D) Dwarf");
    Console.WriteLine("E) Elf");
    Console.WriteLine("G) Gnome");
    Console.WriteLine("H) Half Elf");
    Console.WriteLine("T) Human");

    bool done = false;

    do
    {
        ConsoleKeyInfo key = Console.ReadKey(true);

        switch (key.Key)
        {
            case ConsoleKey.D: option = "Dwarf"; done = true; break;
            case ConsoleKey.E: option = "Elf"; done = true; break;
            case ConsoleKey.G: option = "Gnome"; done = true; break;
            case ConsoleKey.H: option = "Half Elf"; done = true; break;
            case ConsoleKey.T: option = "Human"; done = true; break;
        }
    } while (!done);

    return option;
}

Character AddCharacter()
{
    Character character = new Character("Name");

    character.Name = ReadString("Enter a name for this character:", true);
    Console.WriteLine();
    character.Profession = GetProfession();
    Console.WriteLine();
    character.Race = GetRace();
    Console.WriteLine();
    character.Biography = ReadString("Enter the character's biography:", false);
    Console.WriteLine();
    character.Strength = ReadInt32("Enter the character's Strength attribute: (1-100)");
    Console.WriteLine();
    character.Intelligence = ReadInt32("Enter the character's Intelligence attribute: (1-100)");
    Console.WriteLine();
    character.Agility = ReadInt32("Enter the character's Agility attribute: (1-100)");
    Console.WriteLine();
    character.Constitution = ReadInt32("Enter the character's Constitution attribute (1-100)");
    Console.WriteLine();
    character.Charisma = ReadInt32("Enter the character's Charisma: attribute: (1-100)");

    return character;
}

Character EditCharacter(Character character)
{

    if (character == null)
    {
        return AddCharacter();
    } else
    {
        Console.WriteLine("Choose an attribute to edit");
        Console.WriteLine("a) Name: " + character.Name);
        Console.WriteLine("b) Profession: " + character.Profession);
        Console.WriteLine("c) Race: " + character.Race);
        Console.WriteLine("d) Biography: " + character.Biography);
        Console.WriteLine("e) Strength: " + character.Strength);
        Console.WriteLine("f) Intelligence: " + character.Intelligence);
        Console.WriteLine("g) Agility: " + character.Agility);
        Console.WriteLine("h) Constitution: " + character.Constitution);
        Console.WriteLine("i) Charisma: " + character.Charisma);

        bool done = false;

        do
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            switch(key.Key)
            {
                case ConsoleKey.A: character.Name = ReadString("Enter a name for this character:", true); done = true; break;
                case ConsoleKey.B: character.Profession = GetProfession(); done = true; break;
                case ConsoleKey.C: character.Race = GetRace(); done = true; break;
                case ConsoleKey.D: character.Biography = ReadString("Enter the character's biography:", false); done = true; break;
                case ConsoleKey.E: character.Strength = ReadInt32("Enter the character's Strength attribute: (1-100)"); done = true; break;
                case ConsoleKey.F: character.Intelligence = ReadInt32("Enter the character's Intelligence attribute: (1-100)"); done = true; break;
                case ConsoleKey.G: character.Agility = ReadInt32("Enter the character's Agility attribute: (1-100)"); done = true; break;
                case ConsoleKey.H: character.Constitution = ReadInt32("Enter the character's Constitution attribute (1-100)"); done = true; break;
                case ConsoleKey.I: character.Charisma = ReadInt32("Enter the character's Charisma: attribute: (1-100)"); done = true; break;
            }
        } while (!done);
    }

    return character;
}

bool DeleteCharacter(Character character)
{
    if (character == null)
    {
        Console.WriteLine("There is no character to delete!");
        return false;
    } else if (ReadBoolean($"Are you sure you want to delete {character.Name} ? (Y/N)"))
    {
        return true;
    } else
    {
        return false;
    }
}

void ViewCharacter(Character character)
{
    if (character == null)
    {
        Console.WriteLine("No character available");
        return;
    }

    Console.WriteLine($"{character.Name} ({character.Race}) is a {character.Profession}");
    
    Console.WriteLine();
    Console.WriteLine("Biography: " + character.Biography);
    Console.WriteLine();
    
    Console.WriteLine("" + "".PadLeft(41, '_'));
    Console.WriteLine("|Str\t|Int\t|Agl\t|Con\t|Chr\t|");
    Console.WriteLine("|" + "".PadLeft(39,'-') + "|");
    Console.WriteLine($"|{character.Strength}\t|{character.Intelligence}\t|{character.Agility}\t|{character.Constitution}\t|{character.Charisma}\t|");
    Console.WriteLine("|" + "".PadLeft(39, '_') + "|");
}