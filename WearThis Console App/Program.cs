//Creating file
using WearThis_Console_App;

string filePath = "../../../LibraryDatabase.txt";
if (File.Exists(filePath) == false)
{
    StreamWriter tempWriter = new StreamWriter(filePath);
    tempWriter.WriteLine("Where the Sidewalk Ends|Shel Silverstein|true");
    tempWriter.Close();
}
StreamReader reader = new StreamReader(filePath);
//List<Book> searchResults = new List<Book>();
//List<Book> books = new List<Book>();
//List<Book> checkedOut = new List<Book>();
//List<Book> currentlyCheckedOut = new List<Book>();
static void GetOutfit(Top top, Bottom bottom)

{
    Console.WriteLine($"Your outfit is {top.color} {top.type} with {bottom.color} {bottom.type}");
    Outfit TopPart = new Top();
    Outfit bottomPart = new Bottom();
}
