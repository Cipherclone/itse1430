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
    DisplayPrimaryStorage();
    DisplaySecondaryStorage();
    DisplayGraphicsCard();
    DisplayOperatingSystem();

}

void PrintCart ()
{

    if (cartPrice != 0)
    {

        Console.WriteLine("Processor:" + "".PadLeft(10,' ') + processorName + " $" + processorPrice);
        Console.WriteLine("Memory:" + "".PadLeft(13,' ') +  memoryName + "$".PadLeft(13, ' ') + memoryPrice);
        Console.WriteLine("Primary Storage:    " + primaryStorageName + "$".PadLeft(9,' ') + primaryStoragePrice);
        Console.WriteLine("Secondary Storage:  " + secondaryStorageName + "$".PadLeft(8, ' ') + secondaryStoragePrice);
        Console.WriteLine("Graphics Card:      " + graphicsCardName + " $" + graphicsCardPrice);
        Console.WriteLine("Operating System:   " + OSname + "  $" + OSprice);
        //Console.WriteLine("");
        Console.WriteLine("".PadLeft(42,'-'));
        Console.WriteLine("Total: $" + cartPrice);
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
            case CharOptions.c: DisplayPrimaryStorage(); break;
            case CharOptions.d: DisplaySecondaryStorage(); break;
            case CharOptions.e: DisplayGraphicsCard(); break;
            case CharOptions.f: DisplayOperatingSystem(); break;

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

    var choice = GetOption("Please choose a Processor", 6);
    
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

    var choice = GetOption("Please choose the Memory", 5);

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

    var choice = GetOption("Please choose the Primary Storage", 4);

    switch (choice)
    {
        case CharOptions.a: primaryStorageName = "SSD 256 GB"; primaryStoragePrice = 90; break;
        case CharOptions.b: primaryStorageName = "SSD 512 GB"; primaryStoragePrice = 100; break;
        case CharOptions.c: primaryStorageName = "SSD 1 TB  "; primaryStoragePrice = 125; break;
        case CharOptions.d: primaryStorageName = "SSD 2 TB  "; primaryStoragePrice = 230; break;
    }
}

void DisplaySecondaryStorage()
{
    Console.WriteLine("a) None       - $0");
    Console.WriteLine("b) HDD 1 TB   - $40");
    Console.WriteLine("c) HDD 2 TB   - $50");
    Console.WriteLine("d) HDD 4 TB   - $70");
    Console.WriteLine("e) SSD 512 GB - $100");
    Console.WriteLine("f) SSD 1 TB   - $125");
    Console.WriteLine("g) SSD 2 TB   - $230");

    var choice = GetOption("Please choose the Secondary Storage", 7);

    switch (choice)
    {
        case CharOptions.a: secondaryStorageName = "None       "; secondaryStoragePrice = 0; break;
        case CharOptions.b: secondaryStorageName = "HDD 1 TB   "; secondaryStoragePrice = 40; break;
        case CharOptions.c: secondaryStorageName = "HDD 2 TB   "; secondaryStoragePrice = 50; break;
        case CharOptions.d: secondaryStorageName = "HDD 4 TB   "; secondaryStoragePrice = 70; break;
        case CharOptions.e: secondaryStorageName = "SSD 512 GB "; secondaryStoragePrice = 100; break;
        case CharOptions.f: secondaryStorageName = "SSD 1 TB   "; secondaryStoragePrice = 125; break;
        case CharOptions.g: secondaryStorageName = "SSD 2 TB   "; secondaryStoragePrice = 230; break;
    }
}

void DisplayGraphicsCard()
{
    Console.WriteLine("a) None             - $0");
    Console.WriteLine("b) GeForce RTX 3070 - $580");
    Console.WriteLine("c) GeForce RTX 2070 - $400");
    Console.WriteLine("d) Radeon RX 6600   - $300");
    Console.WriteLine("e) Radeon RX 5600   - $325");

    var choice = GetOption("Please choose a Graphics Card", 5);

    switch (choice)
    {
        case CharOptions.a: graphicsCardName = "None             "; graphicsCardPrice = 0; break;
        case CharOptions.b: graphicsCardName = "GeForce RTX 3070 "; graphicsCardPrice = 580; break;
        case CharOptions.c: graphicsCardName = "GeForce RTX 2070 "; graphicsCardPrice = 400; break;
        case CharOptions.d: graphicsCardName = "Radeon RX 6600   "; graphicsCardPrice = 300; break;
        case CharOptions.e: graphicsCardName = "Radeon RX 5600   "; graphicsCardPrice = 325; break;
    }
}

void DisplayOperatingSystem()
{
    Console.WriteLine("a) Windows 11 Home - $140");
    Console.WriteLine("b) Windows 11 Pro  - $160");
    Console.WriteLine("c) Windows 10 Home - $150");
    Console.WriteLine("d) Windows 10 Pro  - $170");
    Console.WriteLine("e) Linux (Fedora)  - $20");
    Console.WriteLine("f) Linux (Red Hat) - $60");

    var choice = GetOption("Please choose an Operating System",6);

    switch (choice)
    {
        case CharOptions.a: OSname = "Windows 11 Home "; OSprice = 140; break;
        case CharOptions.b: OSname = "Windows 11 Pro  "; OSprice = 160; break;
        case CharOptions.c: OSname = "Windows 10 Home "; OSprice = 150; break;
        case CharOptions.d: OSname = "Windows 10 Pro  "; OSprice = 170; break;
        case CharOptions.e: OSname = "Linux (Fedora)  "; OSprice = 20; break;
        case CharOptions.f: OSname = "Linux (Red Hat) "; OSprice = 60; break;
    }
}
