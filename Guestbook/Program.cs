//för att slippa skriva Console.
using static System.Console;

namespace GuestbookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //laddar in listan från json-filen
            GuestbookInput.guestbookInputs = Storage.LoadInputFromJson("myGuestbookInputs.json");

            //boolean för att kunna loopa applikationen
            bool appRunning = true;

            //while-loop för att loopa appen så den inte stängs
            while (appRunning)
            {
                try
                {
                    //huvudmeny från meny-klassen
                    Menu menu = new Menu("1. Skriv i gästboken", "2. Ta bort inlägg", "3. Avsluta");
                    WriteLine("Välkommen till Mikaels gästbok!\n");
                    WriteLine(menu.option1);
                    WriteLine($"{menu.option2}\n");
                    WriteLine($"{menu.option3}\n");
                    WriteLine($"Befintliga inlägg:");

                    //loop som skriver ut id, namn och input för varje inlägg
                    foreach (var entry in GuestbookInput.guestbookInputs)
                    {
                        WriteLine($"[{entry.InputId}] {entry.Name} - {entry.UserInput}");
                    }

                    //kontrollerar input och lagrar i variabeln input
                    string? input = ReadLine();

                    //kontrollerar så input ej är tom, felhantering om så är fallet.
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        throw new ArgumentNullException();
                    }
                    
                    //if-sats om input är 1, rensar skärmen, uppmaning om namn och meddelande samt felhantering vid fel input.
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
                        //går tillbaka till huvudmenyn när tangenttryckning reggas
                        ReadKey();
                    }

                    //om input är 2, rensar skärmen, visar befintliga inlägg, uppmaning om att ta bort inlägg baserat på inputid.
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

                        //felhantering om ingen input
                        if (string.IsNullOrWhiteSpace(deleteInput))
                        {
                            throw new ArgumentNullException("Du måste ange ett korrekt nummer på inlägget du vill ta bort (se till vänster om inlägget).");
                        }

                        //försöker omvandla input från string till int. Om det lyckas läggs nya värdet i inputIdToDelete.
                        if (int.TryParse(deleteInput, out int inputIdToDelete))
                        {
                            //if-sats för att kontrollera om inputid finns eller om siffran är för hög
                            if (inputIdToDelete <= GuestbookInput.guestbookInputs.Count)
                            {
                                //tar bort input baserat på id
                                GuestbookInput.RemoveAt(inputIdToDelete - 1);

                            //sparar ner nya listan till json
                            Storage.SaveInputToJson(GuestbookInput.guestbookInputs, "myGuestbookInputs.json");

                            WriteLine($"Inlägg nummer {inputIdToDelete} är borttaget. Tryck på valfri tangent för att återgå till huvudmenyn.");
                            //valfri tangent för att återgå till huvudmenyn
                            ReadKey();
                            }
                            //felhantering om inputid inte finns
                            else
                            {
                                WriteLine("Du måste ange ett korrekt nummer på inlägget du vill ta bort (se till vänster om inlägget).");
                                WriteLine("Tryck på valfri tangent för att återgå till huvudmenyn.");
                                ReadKey();
                            }
                        }
                    }
                    //input 3 avbryter appen, rensar skärmen för bättre läsbarhet, avlutar loopen för att avsluta appen.
                    else if (input == "3")
                    {
                        Clear();
                        WriteLine("Programmet avslutas.");
                        appRunning = false;
                    }
                    //felhantering huvudmenyn
                    else
                    {
                        WriteLine("Ogiltigt val, välj 1, 2 eller 3.");
                    }
                }
                //catch för null eller tom sträng
                catch (ArgumentNullException ex)
                {
                    WriteLine($"Det uppstod ett fel. Felet beror på: {ex.Message}");
                }
                //catch för andra typer av fel med felmeddelande.
                catch (Exception ex)
                {
                    WriteLine($"Ett fel inträffade: {ex.Message}");
                }
            }
        }
    }
}