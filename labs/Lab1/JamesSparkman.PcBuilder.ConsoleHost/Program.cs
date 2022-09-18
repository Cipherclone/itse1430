/*
ITSE 1430
Fall 2022
James Sparkman
*/
using System.Collections.Generic; 
DisplayInformation();
bool done = false;
int cartPrice = 0;

string processorName = "";
string memoryName = "";
string primaryStorageName = "";
string secondaryStorageName = "";
string graphicsCardName = "";
string OSname = "";


int processorPrice = 0;
int memoryPrice = 0;
int primaryStoragePrice = 0;
int secondaryStoragePrice = 0;
int graphicsCardPrice = 0;
int OSprice = 0;

// current story = 7
do
{
    MenuOption input = DisplayMenu();
    Console.WriteLine();

    switch (input)
    {
        case MenuOption.StartOrder: StartOrder(); break;
        case MenuOption.ViewOrder: PrintCart(); break;
        case MenuOption.Clear: ClearOrder(); break;
        case MenuOption.Edit: EditOrder(); break;

        case MenuOption.Quit: done = GetBool("Are you sure you wish to quit? (Y/N)"); break;
    }
} while (!done);


// functions!

void DisplayInformation()
{
    Console.WriteLine("James Sparkman");
    Console.WriteLine("ITSE 1430");
    Console.WriteLine("Fall 2022"); // TODO add date before submission
}

MenuOption DisplayMenu()
{
    cartPrice = processorPrice + memoryPrice + primaryStoragePrice + secondaryStoragePrice + graphicsCardPrice + OSprice;
    Console.WriteLine();
    Console.WriteLine("Your cart has a price of: $" + cartPrice);
    //TODO add more options later on
    Console.WriteLine("S)tart New Order");
    Console.WriteLine("V)iew Order");
    Console.WriteLine("C)lear Order");
    Console.WriteLine("E)dit Order");
    Console.WriteLine("Q)uit");


    do
    {
        ConsoleKeyInfo key = Console.ReadKey(true);
        switch(key.Key)
        {
            case ConsoleKey.S: return MenuOption.StartOrder;
            case ConsoleKey.Q: return MenuOption.Quit;
            case ConsoleKey.V: return MenuOption.ViewOrder;
            case ConsoleKey.C: return MenuOption.Clear;
            case ConsoleKey.E: return MenuOption.Edit;
        }
    } while (true);

}

void StartOrder ()
{
    cartPrice = 0;
    DisplayProcessors();
    DisplayMemory();

}

void PrintCart ()
{

    if (cartPrice != 0)
    {

        Console.WriteLine("Processor:" + "".PadLeft(10,' ') + processorName + " $" + processorPrice);
        Console.WriteLine("Memory:" + "".PadLeft(13,' ') +  memoryName + "$".PadLeft(13, ' ') + memoryPrice);
        Console.WriteLine("Primary Storage:   " + primaryStorageName + "$" + primaryStoragePrice);
        Console.WriteLine("Secondary Storage: " + secondaryStorageName + "$" + secondaryStoragePrice);
        Console.WriteLine("Graphics Card:     " + graphicsCardName + "$" + graphicsCardPrice);
        Console.WriteLine("Operating System:  " + OSname + "$" + OSprice);
        //Console.WriteLine("");
        Console.WriteLine("".PadLeft(30,'-'));
        Console.WriteLine("Total: " + cartPrice);
    } else
    {
        Console.WriteLine("There is no cart to print!");
    }
}

void ClearOrder()
{
    if (GetBool("Are you sure you want to clear your cart? (Y/N)"))
    {
        processorName = memoryName = primaryStorageName = secondaryStorageName = graphicsCardName = OSname = "";
        processorPrice = memoryPrice = primaryStoragePrice = secondaryStoragePrice = graphicsCardPrice = OSprice = 0;
    }
}

void EditOrder()
{
    if (cartPrice == 0)
    {
        Console.WriteLine("There is no cart to edit!");
    } else
    {
        Console.WriteLine("a) " + processorName);
        Console.WriteLine("b) " + memoryName);
        Console.WriteLine("c) " + primaryStorageName);
        Console.WriteLine("d) " + secondaryStorageName);
        Console.WriteLine("e) " + graphicsCardName);
        Console.WriteLine("f) " + OSname);

        CharOptions choice = GetOption("Please choose an item to edit", 6);

        switch (choice)
        {
            case CharOptions.a: DisplayProcessors(); break;
            case CharOptions.b: DisplayMemory(); break;
            //case CharOptions.c:
            //case CharOptions.d:
            //case CharOptions.e:
            //case CharOptions.f:

        }
    }

}

bool GetBool (string message)
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

CharOptions GetOption (string message, int options)
{
    Console.WriteLine(message);
    CharOptions currentOption = CharOptions.z;
    bool finished = false;
    do
    {
        ConsoleKeyInfo key = Console.ReadKey(true);
        
        switch (key.Key)
        {
            case ConsoleKey.A: currentOption = CharOptions.a; break;
            case ConsoleKey.B: currentOption = CharOptions.b; break;
            case ConsoleKey.C: currentOption = CharOptions.c; break;
            case ConsoleKey.D: currentOption = CharOptions.d; break;
            case ConsoleKey.E: currentOption = CharOptions.e; break;
            case ConsoleKey.F: currentOption = CharOptions.f; break;
            case ConsoleKey.G: currentOption = CharOptions.g; break;
        }

        if ((int)currentOption <= options)
            finished = true;
       
    } while (!finished);

    Console.WriteLine();
    return currentOption;
} 

void DisplayProcessors ()
{
    Console.WriteLine("a) AMD Ryzen 9 5900X - $1410");
    Console.WriteLine("b) AMD Ryzen 7 5700X - $1270");
    Console.WriteLine("c) AMD Ryzen 5 5600X - $1200");
    Console.WriteLine("d) Intel i9-12900K   - $1590");
    Console.WriteLine("e) Intel i7-12700K   - $1400");
    Console.WriteLine("f) Intel i5-12600K   - $1280");

    CharOptions choice = GetOption("Please choose a Processor", 6);
    
    switch (choice)
    {
        case CharOptions.a: processorName = "AMD Ryzen 9 5900X"; processorPrice = 1410; break;
        case CharOptions.b: processorName = "AMD Ryzen 7 5700X"; processorPrice = 1270; break;
        case CharOptions.c: processorName = "AMD Ryzen 7 5600X"; processorPrice = 1200; break;
        case CharOptions.d: processorName = "Intel i9-12900K  "; processorPrice = 1590; break;
        case CharOptions.e: processorName = "Intel i7-12700K  "; processorPrice = 1400; break;
        case CharOptions.f: processorName = "Intel i5-12600K  "; processorPrice = 1280; break;

    }
    
}

void DisplayMemory()
{
    Console.WriteLine("a) 8 GB   - $30");
    Console.WriteLine("b) 16 GB  - $40");
    Console.WriteLine("c) 32 GB  - $90");
    Console.WriteLine("d) 64 GB  - $410");
    Console.WriteLine("e) 128 GB - $600");

    CharOptions choice = GetOption("Please choose the memory", 5);

    switch (choice)
    {
        case CharOptions.a: memoryName = "8 GB  "; memoryPrice = 30; break;
        case CharOptions.b: memoryName = "16 GB "; memoryPrice = 40; break;
        case CharOptions.c: memoryName = "32 GB "; memoryPrice = 90; break;
        case CharOptions.d: memoryName = "64 GB "; memoryPrice = 410; break;
        case CharOptions.e: memoryName = "128 GB"; memoryPrice = 600; break;
    }

}

void DisplayPrimaryStorage()
{
    Console.WriteLine("a) SSD 256 GB - $90");
    Console.WriteLine("b) SSD 512 GB - $100");
    Console.WriteLine("c) SSD 1 TB   - $125");
    Console.WriteLine("d) SSD 2 TB   - $230");
}

