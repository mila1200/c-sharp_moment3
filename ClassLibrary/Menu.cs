namespace GuestbookApp {
    /*klass med konstruktor. Min tanke var att återanvända Menu på flera ställen för att skapa anpassade menyer beroende på användarens val.
    Det var dock inget som behövdes.*/
public class Menu
{
    public string option1 = "";
    public string option2 = "";
    public string option3 = "";

    //konstruktor som tilldelas olika värden.
    public Menu(string opt1, string opt2, string opt3)
    {
        option1 = opt1;
        option2 = opt2;
        option3 = opt3;
    }
}
}