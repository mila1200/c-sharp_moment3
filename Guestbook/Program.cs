using static System.Console;
using System.Collections;

namespace GuestbookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GuestbookInput.guestbookInputs = Storage.LoadInputFromJson("myGuestbookInputs.json");
            //boolean för att kunna loopa applikationen
            bool appRunning = true;

            //while-loop för att loopa appen vid felaktig input
            while (appRunning)
            {
                try
                {
                    Menu menu = new Menu("1. Skriv i gästboken", "2. Ta bort inlägg", "3. Avsluta");
                    WriteLine("Välkommen till Mikaels gästbok!\n");
                    WriteLine(menu.option1);
                    WriteLine($"{menu.option2}\n");
                    WriteLine($"{menu.option3}\n");
                    WriteLine($"Befintliga inlägg:");

                    foreach (var entry in GuestbookInput.guestbookInputs)
                    {
                        WriteLine($"[{entry.InputId}] {entry.Name} - {entry.UserInput}");
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

                        //lägger till namn och inlägg till listan medan appen körs
                        GuestbookInput.AddInput(name, userInput);
                        //lägger till input till den sparade filen
                        Storage.SaveInputToJson(GuestbookInput.guestbookInputs, "myGuestbookInputs.json");

                        WriteLine("Inlägget är sparat. Tryck på valfri tangent för att återgå till huvudmenyn.");
                        ReadKey();
                    }
                    else if (input == "2")
                    {
                        Clear();

                        WriteLine("Befintliga inlägg:");

                        foreach (var entry in GuestbookInput.guestbookInputs)
                        {
                            WriteLine($"[{entry.InputId}] {entry.Name} - {entry.UserInput}");
                        }

                        WriteLine("\nVänligen ange vilket inlägg du vill ta bort (numrerat till vänster om inlägget):");

                        string? deleteInput = ReadLine();

                        if (string.IsNullOrWhiteSpace(deleteInput))
                        {
                            throw new ArgumentNullException("Du måste ange ett korrekt nummer på inlägget du vill ta bort (se till vänster om inlägget).");
                        }

                        //försöker omvandla input från string till int. Om det lyckas läggs nya värdet i inputIdToDelete, annars felhantering.
                        if (int.TryParse(deleteInput, out int inputIdToDelete))
                        {
                            GuestbookInput.RemoveAt(inputIdToDelete - 1);

                            //sparar ner nya listan till json
                            Storage.SaveInputToJson(GuestbookInput.guestbookInputs, "myGuestbookInputs.json");

                            WriteLine($"Inlägg nummer {inputIdToDelete} är borttaget. Tryck på valfri tangent för att återgå till huvudmenyn.");
                            ReadKey();
                        }
                        else
                        {
                            WriteLine("Du måste ange ett korrekt nummer på inlägget du vill ta bort (se till vänster om inlägget).");
                        }
                    }
                    else if (input == "3")
                    {
                        Clear();
                        WriteLine("Programmet avslutas.");
                        appRunning = false;

                    }
                }
                catch (ArgumentNullException ex)
                {
                    WriteLine($"Det uppstod ett fel. Felet beror på: {ex.Message}");
                }
            }
        }
    }
}