//för att JsonConvert ska fungera, Newtonsoft rekommenderas av boken.
using Newtonsoft.Json;

namespace GuestbookApp
{
    public static class Storage
    {
        //sparar posterna till en fil, myGuestbookInputs är filnamnet.
        public static void SaveInputToJson(List<GuestbookInput> guestbookInputs, string myGuestbookInputs)
        {
            string json = JsonConvert.SerializeObject(guestbookInputs);
            //skapar ny fil och sparar ner texten, skriver över om den redan finns.
            File.WriteAllText(myGuestbookInputs, json);
        }


        //returnerar listan med inlägg
        public static List<GuestbookInput> LoadInputFromJson(string myGuestbookInputs)
        {
            //för att undvika felmeddelande när filen inte finns
            if(File.Exists(myGuestbookInputs))
            {
            //öppnar och läser filen
            string json = File.ReadAllText(myGuestbookInputs);
            //omvandlar Json-listan, om det misslyckas returneras en lista oavsett.
            return JsonConvert.DeserializeObject<List<GuestbookInput>>(json) ?? new List<GuestbookInput>();
            }
            //om filen itne finns returneras en lista oavsett
            else {
                return new List<GuestbookInput>();
            }
        }   
        
    }
}