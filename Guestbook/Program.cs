using static System.Console;

namespace GuestbookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //boolean för att kunna loopa applikationen
            bool validInput = false;

            //while-loop för att loopa appen vid felaktig input
            while (!validInput)
            {
                try
                {
                    Menu menu = new Menu("1. Skriv i gästboken", "2. Ta bort inlägg", "3. Avsluta");
                    WriteLine("Välkommen till Mikaels gästbok!\n");
                    WriteLine(menu.option1);
                    WriteLine($"{menu.option2}\n");
                    WriteLine($"{menu.option3}\n");
                    WriteLine("Vänligen välj ett alternativ (1-3):");

                    int index = 1;
                    foreach (var entry in GuestbookInput.guestbookInputs)
                    {
                        WriteLine($"{index} {entry.Name} - {entry.UserInput}\n");
                        index++;
                    }

                    string? input = ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        throw new ArgumentNullException();
                    }

                    if (input == "1")
                    {
                        Clear();
                        WriteLine("Vänligen ange ditt namn:");
                        string? name = ReadLine();

                        if (string.IsNullOrWhiteSpace(name))
                        {
                            throw new ArgumentNullException("Du måste ange ett namn.");
                        }

                        WriteLine("Vänligen skriv ditt meddelande:");
                        string? userInput = ReadLine();

                        if (string.IsNullOrWhiteSpace(userInput))
                        {
                            throw new ArgumentNullException("Du måste ange ett meddelande.");
                        }

                        //lägger till namn och inlägg till listan
                        GuestbookInput.AddInput(name, userInput);

                    }
                    else if (input == "2")
                    {

                    }
                    //avslutar while-loop vid korrekt input
                    validInput = true;
                }
                catch (ArgumentNullException ex)
                {
                    WriteLine($"Det uppstod ett fel. Felet beror på: {ex.Message}");
                }
            }
        }
    }
}