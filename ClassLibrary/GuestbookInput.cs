namespace GuestbookApp {

public class GuestbookInput
{
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
}
}
