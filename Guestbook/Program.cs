using static System.Console;

namespace GuestbookApp
{

class Program
{

    static void Main(string[] args)
    {
        Menu menu = new Menu("1. Skriv i gästboken", "2. Ta bort inlägg", "3. Avsluta");
        WriteLine("Välkommen till Mikaels gästbok!\n");
        WriteLine(menu.option1);
        WriteLine($"{menu.option2}\n");
        WriteLine($"{menu.option3}\n");
        WriteLine("Vänligen välj ett alternativ (1-3):");

        string input = ReadLine();

        if (input == "1")
        {
            Clear();
            WriteLine("Vänligen ange ditt namn:");
            string name = ReadLine();

            WriteLine("Vänligen skriv ditt meddelande:");
            string userInput = ReadLine();
            
            //lägger till namn och inlägg till listan
            GuestbookInput.AddInput(name, userInput);
        }
        
    }
}
}