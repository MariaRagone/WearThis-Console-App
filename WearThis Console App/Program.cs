//Creating file
using WearThis_Console_App;

string filePath = "../../../LibraryDatabase.txt";
if (File.Exists(filePath) == false)
{
    StreamWriter tempWriter = new StreamWriter(filePath);
    tempWriter.WriteLine("Red|false|Casual");
    tempWriter.Close();
}
StreamReader reader = new StreamReader(filePath);
List<Top> searchResults = new List<Top>();
List<Top> tops = new List<Top>();
List<Outfit> wearThis = new List<Outfit>();
List<Outfit> wearing = new List<Outfit>();
static void GetOutfit(Top top, Bottom bottom)

{
    Console.WriteLine($"Your outfit is {top.color} {top.type} with {bottom.color} {bottom.type}");
    Outfit TopPart = new Top();
    Outfit bottomPart = new Bottom();
}
