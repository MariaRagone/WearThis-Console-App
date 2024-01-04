using WearThis_Console_App;
using System.Numerics;
using System.Reflection;
using System.Drawing;
using System.ComponentModel.DataAnnotations;

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
//welcome user
Console.WriteLine("Welcome to Wear This! I will help you decide what to wear today using the clothing you already own.");
//loop the program
bool runProgram = true;
while (runProgram)
{
    int menuChoice = -1;
    //displaying the menue (view closet or add clothing)
    while (menuChoice <= -1 || menuChoice >= 3)
    {
        DisplayMenu();
        while (int.TryParse(Console.ReadLine(), out menuChoice) == false)
        {
            {
                Console.WriteLine("Invalid response. Try again");//error message 
            }
        }
    }
    if (menuChoice == 1) //display the closet
    {
        Console.WriteLine("Tops:");
        DisplayTops(TopsList);
        Console.WriteLine("Bottoms:");
        DisplayBottoms(BottomsList);
    }
    else if (menuChoice == 2) //add clothing
    {
        Console.WriteLine("What type of clothing would you like to add? 1. Top, 2. Bottom");
    }
    else if (menuChoice == 3) //quit
    {
        Console.WriteLine("Bye!");
        runProgram = false;
        break;
    }
}

//runProgram = Validator.GetContinue("Do you want to...?");

//METHODS
static void DisplayTops(List<Top> fakeTopList)
{
    Console.WriteLine($"{"Color",20} {"Has Pattern",20} {"Category",20} {"Sleeve Length",20} {"Fit",20} {"Length",20} {"Type",20}");

    for (int i = 0; i < fakeTopList.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {fakeTopList[i]}");
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
    Console.WriteLine($"{fakeBottomList.Count + 1}. Add Bottom");
    Console.WriteLine($"{fakeBottomList.Count + 2}. Quit");

}
static void DisplayMenu()
{
    Console.WriteLine("Choose an option:");
    Console.WriteLine($"1. View Closet");
    Console.WriteLine($"2. Add Clothing");
    Console.WriteLine($"3. Quit");
}

static Top addTop()
{
    Console.WriteLine("What color is it?");
    //pretent these are all validated
    string color = Console.ReadLine();
    Console.WriteLine("Does it have a pattern?");
    bool pattern = bool.Parse(Console.ReadLine());
    Console.WriteLine("Is it casual, dressy, business casual, or business?");
    string category = Console.ReadLine();
    Console.WriteLine("What is the sleeve length: strapless, tank, cap, short, 3/4, long");
    string sleeveLength = Console.ReadLine();
    Console.WriteLine("Is it fitted or loose?");
    string fit = Console.ReadLine();
    Console.WriteLine("Is it short,medium, or long");
    string length = Console.ReadLine();
    Console.WriteLine("Is it a blouse, cardigan, collared, sweater, tank, or t-shirt");
    string type = Console.ReadLine();

    return new Top(color, pattern, category, sleeveLength, fit, length, type);
}
static void addClothing()
{
    Console.WriteLine("What type of clothing would you like to add? 1. Top, 2. Bottom");
    int clothingChoice = -1;
    //displaying the menue (view closet or add clothing)
    while (clothingChoice <= -1 || clothingChoice >= 2)
    {
        while (int.TryParse(Console.ReadLine(), out clothingChoice) == false)
        {
            {
                Console.WriteLine("Invalid response. Try again");//error message 
            }
        }
    }
    if (clothingChoice == 1)
    {
        addTop();
    }
}
