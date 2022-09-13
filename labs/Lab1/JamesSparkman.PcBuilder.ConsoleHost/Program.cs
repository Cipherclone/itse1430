// See https://aka.ms/new-console-template for more information
DisplayInformation();
bool done = false;
int cartPrice = 0;
do
{
    MenuOption input = DisplayMenu(cartPrice);
    Console.WriteLine();

    switch (input)
    {




        case MenuOption.Quit: done = GetBool("Are you sure you wish to quit? (Y/N)"); break;
    }
} while (!done);


// functions!

void DisplayInformation()
{
    Console.WriteLine("James Sparkman");
    Console.WriteLine("ITSE 1430");
    Console.WriteLine(""); // TODO add date before submission
}

MenuOption DisplayMenu(int cartPrice)
{
    Console.WriteLine();
    Console.WriteLine("Your cart has a price of: $" + cartPrice);
    //TODO add more options later on
    Console.WriteLine("Q)uit");


    do
    {
        ConsoleKeyInfo key = Console.ReadKey(true);
        switch(key.Key)
        {
            case ConsoleKey.Q: return MenuOption.Quit;



        }
    } while (true);

}


bool GetBool(string message)
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