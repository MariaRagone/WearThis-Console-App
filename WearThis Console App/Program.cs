using WearThis_Console_App;
using System.Numerics;
using System.Reflection;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
using System;

//TO DO: 
//add database
//add photos
//Save the user perferences: such as work atire (business, casual, dressy, or business casual)
//formatting the printing for the GetOutfit()
//create some fashion rules
//create some questions for the GetOutfit() like:
//"What is the weather outside? Cold/Hot" then only give outfits that work for that weather, 
//"Do you need a casual, business casual, dressy, or business ? or What is the occasion? Hang out, Work, Party, 
string dressCode = "";


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

//tests
//-----------------------------------------------------------------
Console.WriteLine($"TopsList Count: {TopsList.Count}");
Console.WriteLine($"BottomsList Count: {BottomsList.Count}");
Console.WriteLine($"Business Tops Count: {TopsList.Count(x => x.Category == "business")}");
Console.WriteLine($"Business Bottoms Count: {BottomsList.Count(x => x.Category == "business")}");
Console.WriteLine($"!TopsList.Any(x => x.Category == \"business\"): {!TopsList.Any(x => x.Category == "business")}");
Console.WriteLine($"!BottomsList.Any(x => x.Category == \"business\"): {!BottomsList.Any(x => x.Category == "business")}");


//---------------------------------------------------------
Console.WriteLine("Welcome to Wear This! I will help you decide what to wear today using the clothing you already own.");
Console.WriteLine(AskUserTheirDressCode());
//loop the program
bool runProgram = true;
while (runProgram)
{
DisplayMenu(dressCode);
    int menuChoice = -1;
    //displaying the menue (view closet or add clothing)
    while (menuChoice < 1 || menuChoice > 4)
    {
        while (int.TryParse(Console.ReadLine(), out menuChoice) == false)
        {
            {
                Console.WriteLine("Invalid response. Try again");//error message 
            }
        }
        continue;
    }
    if (menuChoice == 1) //display the closet
    {
        Console.WriteLine("Tops:");
        DisplayTops(TopsList);
        Console.WriteLine("Bottoms:");
        DisplayBottoms(BottomsList);
        continue;
        //so far this only shows the TopsList from above and not any items that were added from user inputs when running the program
    }
    else if (menuChoice == 2) //add clothing
    {
        addClothing();
        continue;
    }
    else if (menuChoice == 3)
    {
        Console.WriteLine($"Your work dress code is: {dressCode}");
        getOutfit(dressCode, TopsList, BottomsList);
        continue;
    }
    else if (menuChoice == 4) //quit
    {
        Console.WriteLine("Bye!");
        runProgram = false;
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
    //Console.WriteLine($"{fakeTopList.Count + 1}. Add Top"); 
    //Console.WriteLine($"{fakeTopList.Count + 2}. Quit");

}
static void DisplayBottoms(List<Bottom> fakeBottomList)
{
    Console.WriteLine($"{"Color",20} {"Has Pattern",20} {"Category",20} {"Fit",20} {"Length",20} {"Type",20}");

    for (int i = 0; i < fakeBottomList.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {fakeBottomList[i]}");
    }
}
static void DisplayMenu(string dressCode)
{
    Console.WriteLine("Choose an option:");
    Console.WriteLine($"1. View Closet");
    Console.WriteLine($"2. Add Clothing");
    Console.WriteLine($"3. Get Outfit");
    Console.WriteLine($"4. Quit");
}
static List<Top> addTop(List<Top> originalList)
{
    Console.WriteLine("What color is it?");
    //pretent these are all validated
    string color = Console.ReadLine();
    Console.WriteLine("Does it have a pattern? true/false?");
    bool patterns = bool.Parse(Console.ReadLine());
    //string pattern = .ToLower().Trim();
    //if (pattern == "y")
    //{
    //    patterns = true;
    //}
    //else
    //{
    //    patterns = false;
    //}
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
    Top newTop = new Top(color, patterns, category, sleeveLength, fit, length, type);
    originalList.Add(newTop);
    Console.WriteLine();
    Console.WriteLine("You just added the top to your closet!");
    Console.WriteLine();
    DisplayTops(originalList);
    return originalList;
}
static string AskUserTheirDressCode()
{
    Console.WriteLine("What is the dressCode at work? Business, Business Casual, Casual, or Dressy?");
    string dressCode = Console.ReadLine().ToLower().Trim();
    if (dressCode == "business" || dressCode == "b" || dressCode == "bus" || dressCode == "biz")
    {
        dressCode = "business";
        return dressCode; 
    }
    else if (dressCode == "business casual" || dressCode == "bc")
    {
        dressCode = "business casual";
        return dressCode;
    }
    else if (dressCode == "casual" || dressCode == "c" || dressCode == "cas")
    {
        dressCode = "casual";
        return dressCode;
    }
    else if (dressCode == "dressy" || dressCode == "d" || dressCode == "dressy" || dressCode == "dress")
    {
        dressCode = "dressy";
        return dressCode;
    }
    else
    {
        return "there is no dress code";
    }
}
void addClothing()
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
        addTop(TopsList);
    }
}

static void getOutfit(string dressCode, List<Top> TopsList, List<Bottom> BottomsList)
{
    Top topForOutfit = null;
    Bottom bottomForOutfit = null;
    Random random = new Random();

    if (TopsList.Count == 0 || BottomsList.Count == 0)
    {
        Console.WriteLine("No tops available.");
        return;
    }
    if (dressCode == "business")
    {
        //Get a random top that is business
        Top randomT = TopsList.Where(x => x.Category == "business").ElementAt(random.Next(TopsList.Count)); 
        string hasPatternT = randomT.HasPattern ? "Yes" : "No";
        topForOutfit = new Top(randomT.Color, randomT.HasPattern, randomT.Category, randomT.SleeveLength, randomT.Fit, randomT.Length, randomT.Type);

        Bottom randomB = BottomsList.Where(x => x.Category == "business").ElementAt(random.Next(BottomsList.Count));
        string hasPatternB = randomB.HasPattern ? "Yes" : "No";
        bottomForOutfit = new Bottom(randomB.Color, randomB.HasPattern, randomB.Category, randomB.Fit, randomB.Length, randomB.Type);

    }
    else if (dressCode == "business casual")
    {
        //Get a random top that is business casual
        Top randomT = TopsList.Where(x => x.Category == "business casual").ElementAt(random.Next(TopsList.Count));
        string hasPatternT = randomT.HasPattern ? "Yes" : "No";
        topForOutfit = new Top(randomT.Color, randomT.HasPattern, randomT.Category, randomT.SleeveLength, randomT.Fit, randomT.Length, randomT.Type);
       
        //Get a random bottom that is business casual
        Bottom randomB = BottomsList.Where(x => x.Category == "business casual").ElementAt(random.Next(BottomsList.Count));
        string hasPatternB = randomB.HasPattern ? "Yes" : "No";
        bottomForOutfit = new Bottom(randomB.Color, randomB.HasPattern, randomB.Category, randomB.Fit, randomB.Length, randomB.Type);

    }
    else if (dressCode == "casual")
    {
        //Get a random top that is  casual
        Top randomT = TopsList.Where(x => x.Category == "casual").ElementAt(random.Next(TopsList.Count));
        string hasPatternT = randomT.HasPattern ? "Yes" : "No";
        topForOutfit = new Top(randomT.Color, randomT.HasPattern, randomT.Category, randomT.SleeveLength, randomT.Fit, randomT.Length, randomT.Type);

        //Get a random bottom that is casual
        Bottom randomB = BottomsList.Where(x => x.Category == "casual").ElementAt(random.Next(BottomsList.Count));
        string hasPatternB = randomB.HasPattern ? "Yes" : "No";
        bottomForOutfit = new Bottom(randomB.Color, randomB.HasPattern, randomB.Category, randomB.Fit, randomB.Length, randomB.Type);

    }
    else if (dressCode == "dressy")
    {
        //Get a random top that is dressy
        Top randomT = TopsList.Where(x => x.Category == "dressy").ElementAt(random.Next(TopsList.Count));
        string hasPatternT = randomT.HasPattern ? "Yes" : "No";
        topForOutfit = new Top(randomT.Color, randomT.HasPattern, randomT.Category, randomT.SleeveLength, randomT.Fit, randomT.Length, randomT.Type);

        //Get a random bottom that is dressy
        Bottom randomB = BottomsList.Where(x => x.Category == "dressy").ElementAt(random.Next(BottomsList.Count));
        string hasPatternB = randomB.HasPattern ? "Yes" : "No";
        bottomForOutfit = new Bottom(randomB.Color, randomB.HasPattern, randomB.Category, randomB.Fit, randomB.Length, randomB.Type);
    }
    //else
    //{
    //    Console.WriteLine($"There are no tops that match your job's {dressCode} dress code.");
    //}
        Console.WriteLine($"You should Wear This top: {topForOutfit} with this bottom: {bottomForOutfit}");
}



