using WearThis_Console_App;
using System.Numerics;
using System.Reflection;
using System.Drawing;

List<Top> TopsList = new List<Top>()
{
    new Top("Red", true, "Dressy", "Cap", "Fitted", "Short", "Blouse"),
    new Top("Red", true, "Business", "Cap", "Loose", "Medium", "Blouse"),
    new Top("White", false, "Business Casual", "Cap", "Loose", "Long", "Blouse"),
    new Top("Pink", true, "Casual", "Cap", "Fitted", "Long", "T-Shirt"),
    new Top("Dark Green", true, "Casual", "Strapless", "Loose", "Long", "Tank"),
    new Top("Yellow", false, "Business", "Strapless", "Loose", "Long", "Blouse"),
    new Top("Orange", true, "Dressy", "Short", "Loose", "Long", "Blouse"),
    new Top("Blue", false, "Business Casual", "Cap", "Fitted", "Short", "Cardigan"),
    new Top("Green", true, "Business", "Tank", "Loose", "Long", "Blouse"),
    new Top("Red", true, "Dressy", "Cap", "Loose", "Long", "Collared"),
    new Top("Teal", false, "Business Casual", "Long", "Loose", "Medium", "Blouse"),
    new Top("Black", false, "Casual", "3/4", "Fitted", "Long", "Sweater"),
    new Top("Brown", true, "Dressy", "Short", "Loose", "Long", "Blouse"),
    new Top("Salmon", false, "Casual", "Short", "Loose", "Long", "T-Shirt"),
};

List<Bottom> BottomsList = new List<Bottom>()
{
    new Bottom("Red", true, "Dressy", "Skinny", "Long", "Pants"),
    new Bottom("Red", true, "Business", "Shift", "Loose", "Dress"),
    new Bottom("White", false, "Business Casual", "Boot Cut", "Long", "Jeans"),
    new Bottom("Pink", true, "Casual", "Boot Cut", "A-Line", "Skirt"),
    new Bottom("Dark Green", true, "Casual", "A-Line", "Mini", "Skirt"),
    new Bottom("Yellow", false, "Business", "Skinny", "Medium", "Jeans"),
    new Bottom("Orange", true, "Dressy", "Straight", "Long", "Jeans"),
    new Bottom("Blue", false, "Business Casual", "Straight", "Short", "Skirt"),
    new Bottom("Green", true, "Business", "Skinny", "Mini", "Jeans"),
    new Bottom("Red", true, "Dressy", "Boot", "Ankle", "Pants"),
    new Bottom("Teal", false, "Business Casual", "Straight", "Medium", "Shorts"),
    new Bottom("Black", false, "Casual", "Shift", "Long", "Dress"),
    new Bottom("Brown", true, "Dressy", "Short", "Loose", "Shorts"),
    new Bottom("Salmon", false, "Casual", "Skinny", "Ankle", "Jeans"),
};

//RUN THE PROGRAM
Console.WriteLine("Welcome to Wear This! I will help you decide what to wear today using the clothin you already own.");
Console.WriteLine("Make a selection.");
Console.WriteLine("What type of clothing would you like to add?");

Console.WriteLine("1. View Closet, 2. Add Clothing");
int clothingChoice = 0;
while(int.TryParse(Console.ReadLine(), out clothingChoice) ==false || clothingChoice <1 || clothingChoice >2)
{
    { Console.WriteLine("Invalid response. Try again"); } //error message
    if (clothingChoice == 1) //display the closet
    {
        Console.WriteLine("Tops:");
        DisplayTops(TopsList);
        Console.WriteLine("Bottoms:");
        DisplayBottoms(BottomsList);
    }
}
DisplayTops(TopsList);

bool runProgram = true;
while (runProgram)
{
    DisplayTops(TopsList);

}

static void DisplayTops(List<Top>fakeTopList)
{
    Console.WriteLine($"{"Color",20} {"Has Pattern",20} {"Category",20} {"Sleeve Length",20} {"Fit",20} {"Length",20} {"Type",20}");

    for (int i = 0; i<fakeTopList.Count; i++)
    {
        Console.WriteLine($"{i+1}. {fakeTopList[i]}");
    }
    Console.WriteLine($"{fakeTopList.Count + 1}. Add Top");
    Console.WriteLine($"{fakeTopList.Count + 2}. Quit");

}
static void DisplayBottoms(List<Bottom> fakeBottomList)
{
    Console.WriteLine($"{"Color",20} {"Has Pattern",20} {"Category",20} {"Sleeve Length",20} {"Fit",20} {"Length",20} {"Type",20}");

    for (int i = 0; i < fakeBottomList.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {fakeBottomList[i]}");
    }
    Console.WriteLine($"{fakeBottomList.Count + 1}. Add Top");
    Console.WriteLine($"{fakeBottomList.Count + 2}. Quit");

}