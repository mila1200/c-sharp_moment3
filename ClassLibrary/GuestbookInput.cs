namespace GuestbookApp {

public class GuestbookInput
{
    //för att kunna hålla koll på inläggen i listan med inputId. Börjar på 1.
    public static int nextInputId = 1;

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

    public static List<GuestbookInput> guestbookInputs = new List<GuestbookInput>();

    //lägger till ett inlägg till listan
    public static void AddInput(string name, string userInput)
    {
        GuestbookInput nameandinput = new GuestbookInput(name, userInput);
        guestbookInputs.Add(nameandinput);
    }

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
