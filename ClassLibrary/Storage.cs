//för att JsonConvert ska fungera
using Newtonsoft.Json;

namespace GuestbookApp
{
    public static class Storage
    {
        //sparar posterna till en fil, myGuestbookInputs är filnamnet.
        public static void SaveInputToJson(List<GuestbookInput> guestbookInputs, string myGuestbookInputs)
        {
            string json = JsonConvert.SerializeObject(guestbookInputs);
            File.WriteAllText(myGuestbookInputs, json);
        }
    }
}