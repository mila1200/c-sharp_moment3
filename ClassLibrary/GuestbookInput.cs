namespace GuestbookApp {

//klass för att ha koll på inläggen
public class GuestbookInput
{
    //för att hålla koll på vilket id nästa inlägg ska få. Static för att hela den ska tillhöra hela klassen.
    public static int nextInputId = 1;

    //detta och nästkommande två delar lagrar id, namn och inlägg. Properties för att få eller sätta värden.
    private int inputId;
    public int InputId
    {
        get { return inputId; }
        set { inputId = value; }
    }


    private string name ="";
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private string userInput = "";

    public string UserInput
    {
        get { return userInput; }
        set { userInput = value; }
    }

    //modell för vad ett inlägg ska innehålla
    public GuestbookInput(string name, string userInput)
    {
        //kollar befintligt InputId och adderar sedan 1.
        InputId = nextInputId++;
        Name = name;
        UserInput = userInput;
    }

    //lista för att lagra nya inlägg
    public static List<GuestbookInput> guestbookInputs = new List<GuestbookInput>();

    //lägger till ett inlägg till listan med angivet namn och användarinlägg.
    public static void AddInput(string name, string userInput)
    {
        GuestbookInput nameandinput = new GuestbookInput(name, userInput);
        guestbookInputs.Add(nameandinput);
    }

    //tar bort inlägg baserat på inputid.
    public static void RemoveAt(int index)
    {
        if (index >= 0 && index < guestbookInputs.Count)
        {
            guestbookInputs.RemoveAt(index);
        }

        //loopar igenom inläggen efter radering för att uppdatera id.
        for (int i = 0; i < guestbookInputs.Count; i++)
        {
            guestbookInputs[i].InputId = i + 1;
        }

        //uppdatera nextInputId till nästa lediga id
        nextInputId = guestbookInputs.Count + 1;
    }
}
}
