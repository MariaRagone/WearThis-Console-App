using WearThis_Console_App;
using System.Numerics;
using System.Reflection;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
using System;

//TO DO: 
//add database
//add photos
//Save the user perferences: such as work atire (business, casual, dressy, orbusiness casual)
//formatting the printing for the GetOutfit()
//create some fashion rules
//create some questions for the GetOutfit() like:
//"What is the weather outside? Cold/Hot" then only give outfits that work for that weather, 
//"Do you need a casual,business casual, dressy, or business ? or What is the occasion? Hang out, work, party, 

List<Top> TopsList = new List<Top>()
{
    new Top("red", true, "dressy", "cap", "fitted", "short", "blouse"),
    new Top("red", true, "business", "cap", "loose", "medium", "blouse"),
    new Top("white", false, "business casual", "cap", "loose", "long", "blouse"),
    new Top("pink", true, "casual", "cap", "fitted", "long", "t-shirt"),
    new Top("dark green", true, "casual", "strapless", "loose", "long", "tank"),
    new Top("yellow", false, "business", "strapless", "loose", "long", "blouse"),
    new Top("orange", true, "dressy", "short", "loose", "long", "blouse"),
    new Top("Blue", false, "business casual", "cap", "fitted", "short", "cardigan"),
    new Top("green", true, "business", "tank", "loose", "long", "blouse"),
    new Top("red", true, "dressy", "cap", "loose", "long", "collared"),
    new Top("teal", false, "business casual", "long", "loose", "medium", "blouse"),
    new Top("black", false, "casual", "3/4", "fitted", "long", "sweater"),
    new Top("Brown", true, "dressy", "short", "loose", "long", "blouse"),
    new Top("salmon", false, "casual", "short", "loose", "long", "t-shirt"),
        new Top("Blue", false, "party", "cap", "fitted", "short", "cardigan"),
    new Top("green", true, "party", "tank", "loose", "long", "blouse"),
    new Top("red", true, "party", "cap", "loose", "long", "collared"),
    new Top("teal", false, "party", "long", "loose", "medium", "blouse"),

};

List<Bottom> BottomsList = new List<Bottom>()
{
    new Bottom("red", true, "dressy", "skinny", "long", "dress"),
    new Bottom("red", true, "business", "shift", "long", "dress"),
    new Bottom("white", false, "business casual", "boot cut", "long", "jeans"),
    new Bottom("pink", true, "casual", "a-line ", "short", "skirt"),
    new Bottom("dark green", true, "casual", "a-line", "mini", "skirt"),
    new Bottom("yellow", false, "business casual", "skinny", "medium", "jeans"),
    new Bottom("orange", true, "dressy", "straight", "long", "jeans"),
    new Bottom("Blue", false, "business casual", "straight", "short", "skirt"),
    new Bottom("green", true, "business", "skinny", "mini", "jeans"),
    new Bottom("red", true, "dressy", "Boot", "ankle", "Pants"),
    new Bottom("teal", false, "business casual", "straight", "medium", "shorts"),
    new Bottom("black", false, "casual",  "shift", "long", "dress"),
    new Bottom("Brown", true, "dressy", "loose", "short",  "dress"),
    new Bottom("salmon", false, "casual", "skinny", "ankle", "jeans"),
        new Bottom("red", true, "party", "skinny", "long", "Pants"),
    new Bottom("red", true, "party", "shift", "long", "dress"),
    new Bottom("white", false, "party", "boot cut", "long", "jeans"),
    new Bottom("pink", true, "party", "a-line ", "short", "skirt"),
    new Bottom("dark green", true, "party", "a-line", "mini", "skirt"),

};

//tests
//-----------------------------------------------------------------
//Console.WriteLine($"TopsList Count: {TopsList.Count}");
//Console.WriteLine($"BottomsList Count: {BottomsList.Count}");
//Console.WriteLine($"business Tops Count: {TopsList.Count(x => x.Category == "business")}");
//Console.WriteLine($"business Bottoms Count: {BottomsList.Count(x => x.Category == "business")}");
//Console.WriteLine($"!TopsList.Any(x => x.Category == \"business\"): {!TopsList.Any(x => x.Category == "business")}");
//Console.WriteLine($"!BottomsList.Any(x => x.Category == \"business\"): {!BottomsList.Any(x => x.Category == "business")}");

//---------------------------------------------------------

//welcome user
Console.WriteLine("Welcome to Wear This! I will help you decide what to wear today using the clothing you already own.");
Console.WriteLine("First let's set up your user profile!");
Console.WriteLine("What is your name?");
string userName = Console.ReadLine();

string dressCode = AskUserTheirdressCode(); //ask the user their work dress code
string occasion = "";
bool runProgram = true;
while (runProgram) //loop the program
{
    DisplayMenu(dressCode); //displays the menu
    int menuChoice = -1;
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
    if (menuChoice == 1) //view closet
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
    else if (menuChoice == 3) //get outfit
    {
        Console.WriteLine($"Your work dress code is: {dressCode}");
        occasion = AskUserForOutfitOccasion(dressCode);

        if (occasion == "work")
        {
            getworkOutfit(dressCode, TopsList, BottomsList); //get an outfit for work
        }
        else
        {
            Console.WriteLine($"the occasion is {occasion}");
            //this only gets a work outfit... 
            getOutfit(occasion, TopsList, BottomsList); //get an outfit based on the occasion selected
        }
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
static string AskUserTheirdressCode()
{
    bool repeatdressCodeQuestion = true;
    while (repeatdressCodeQuestion)
    {
        Console.WriteLine("What is the dressCode at work? business,business casual, casual, or dressy?");
        string dressCode = Console.ReadLine().ToLower().Trim();
        if (dressCode == "business" || dressCode == "b" || dressCode == "bus" || dressCode == "biz")
        {
            repeatdressCodeQuestion = false;

            dressCode = "business";
            return dressCode;
        }
        else if (dressCode == "business casual" || dressCode == "bc")
        {
            repeatdressCodeQuestion = false;

            dressCode = "business casual";
            return dressCode;
        }
        else if (dressCode == "casual" || dressCode == "c" || dressCode == "cas")
        {
            repeatdressCodeQuestion = false;

            dressCode = "casual";
            return dressCode;
        }
        else if (dressCode == "dressy" || dressCode == "d" || dressCode == "dressy" || dressCode == "dress")
        {
            repeatdressCodeQuestion = false;

            dressCode = "dressy";
            return dressCode;
        }
        else
        {
            repeatdressCodeQuestion = true;
            return "Please choose from business,business casual, casual, or dressy";
        }
    }
    return "";

}
static string AskUserForOutfitOccasion(string dressCode)
{
    bool repeatOccasionQuestion = true;
    while (repeatOccasionQuestion)
    {

        Console.WriteLine("What is the occasion? work, Hang Out, party, or formal?");
        string occasion = Console.ReadLine().Trim().ToLower();
        if (occasion == "work" || occasion == "w")
        {
            repeatOccasionQuestion = false;
            return dressCode;
        }
        else if (occasion == "hang out" || occasion == "hangout" || occasion == "casual" || occasion == "c" || occasion == "h" || occasion == "ho")
        {
            occasion = "casual";
            repeatOccasionQuestion = false;

            return occasion;
        }
        else if (occasion == "party" || occasion == "p")
        {
            occasion = "party";
            repeatOccasionQuestion = false;

            return occasion;
        }
        else if (occasion == "formal" || occasion == "f" || occasion == "dressy" || occasion == "d")
        {
            occasion = "dressy";
            repeatOccasionQuestion = false;

            return occasion;
        }
        else
        {
            Console.WriteLine("Please choose from work, casual, or formal");
            repeatOccasionQuestion = true;
        }
    }
    return string.Empty;
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
} //this method does  not perminantly add clothing

static void getworkOutfit(string dressCode, List<Top> TopsList, List<Bottom> BottomsList)
{
    //declare new variables for a new top and a new bottom for the outfit. 
    Top topForOutfit = null;
    Bottom bottomForOutfit = null;
    Random random = new Random();

    //tell the user there are no tops or bottoms available at all
    if (TopsList.Count == 0)
    {
        Console.WriteLine($"You don't have any tops in your closet. Please add some!");
        return;
    }
    else if (BottomsList.Count == 0)
    {
        Console.WriteLine($"You don't have any bottoms in your closet. Please add some!");
        return;
    }
    //filter tops and bottoms by the specified dress code
    var filteredTopsBydressCode = TopsList.Where(x => x.Category == dressCode).ToList();
    var filteredBottomsBydressCode = BottomsList.Where(x => x.Category == dressCode).ToList();

    //tell the user there are no tops or bottoms available in their work dress code
    if (filteredTopsBydressCode.Count == 0)
    {
        Console.WriteLine($"No tops available for your {dressCode} work dress code. Add some {dressCode} tops!");
        return;
    }
    else if (filteredBottomsBydressCode.Count == 0)
    {
        Console.WriteLine($"No bottoms available for your {dressCode} work dress code. Add some {dressCode} bottoms!");
        return;
    }

    Top randomT = filteredTopsBydressCode[random.Next(filteredTopsBydressCode.Count)];
    Bottom randomB = filteredBottomsBydressCode[random.Next(filteredBottomsBydressCode.Count)];

    //convert the hasPattern true/false to Patterned/Plain for better clarity for the user
    //string hasPatternT = randomT.HasPattern ? "Patterned" : "Plain"; 
    //string hasPatternB = randomB.HasPattern ? "Patterned" : "Plain";

    topForOutfit = new Top(randomT.Color, randomT.HasPattern, randomT.Category, randomT.SleeveLength, randomT.Fit, randomT.Length, randomT.Type);
    bottomForOutfit = new Bottom(randomB.Color, randomB.HasPattern, randomB.Category, randomB.Fit, randomB.Length, randomB.Type);
    Console.WriteLine($"You should Wear This:");

    Console.WriteLine($"Top: -{topForOutfit.Category}- {topForOutfit.Color}, {topForOutfit.Fit} fit, {topForOutfit.Length} {topForOutfit.Type} with {topForOutfit.SleeveLength} sleeves \n" +
        $"Bottom: -{bottomForOutfit.Category}- {bottomForOutfit.Color}, {bottomForOutfit.Fit}, {bottomForOutfit.Length} length {bottomForOutfit.Type}");
    Console.WriteLine("You are going to look fabulous!");
    Console.WriteLine();
}

static void getOutfit(string occasion, List<Top> TopsList, List<Bottom> BottomsList)
{
    //declare new variables for a new top and a new bottom for the outfit. 
    Top topForOutfit = null;
    Bottom bottomForOutfit = null;
    Random random = new Random();

    //tell the user there are no tops or bottoms available at all
    if (TopsList.Count == 0)
    {
        Console.WriteLine($"You don't have any tops in your closet. Please add some!");
        return;
    }
    else if (BottomsList.Count == 0)
    {
        Console.WriteLine($"You don't have any bottoms in your closet. Please add some!");
        return;
    }
    //filter tops and bottoms by the specified occasion
    var filteredTopsByOccasion = TopsList.Where(x => x.Category == occasion).ToList();
    var filteredBottomsByOccasion = BottomsList.Where(x => x.Category == occasion).ToList();
    //tell the user there are no tops or bottoms available in their occasion
    if (filteredTopsByOccasion.Count == 0)
    {
        Console.WriteLine($"No tops available for your {occasion} occasion. Add some {occasion} tops!");
        return;
    }
    else if (filteredBottomsByOccasion.Count == 0)
    {
        Console.WriteLine($"No bottoms available for your {occasion} occasion. Add some {occasion} bottoms!");
        return;
    }

    Top randomT = filteredTopsByOccasion[random.Next(filteredTopsByOccasion.Count)];
    Bottom randomB = filteredBottomsByOccasion[random.Next(filteredBottomsByOccasion.Count)];

    //convert the hasPattern true/false to Patterned/Plain for better clarity for the user
    //string hasPatternT = randomT.HasPattern ? "Patterned" : "Plain"; 
    //string hasPatternB = randomB.HasPattern ? "Patterned" : "Plain";

    if (randomB.Type == "dress") //if the bottom is a dress then do not assign a top
    {
        bottomForOutfit = new Bottom(randomB.Color, randomB.HasPattern, randomB.Category, randomB.Fit, randomB.Length, randomB.Type);
        Console.WriteLine($"You should Wear This:");
        Console.WriteLine($"-{bottomForOutfit.Category}- {bottomForOutfit.Color}, {bottomForOutfit.Fit}, {bottomForOutfit.Length} length {bottomForOutfit.Type}");
    }
    else //if the bottom is not a dress then assign a top and a bottom
    {
        //assigns the random top and the random bottom
        topForOutfit = new Top(randomT.Color, randomT.HasPattern, randomT.Category, randomT.SleeveLength, randomT.Fit, randomT.Length, randomT.Type);
        bottomForOutfit = new Bottom(randomB.Color, randomB.HasPattern, randomB.Category, randomB.Fit, randomB.Length, randomB.Type);

        if (randomT.Color != "white" && randomT.Color != "black") //if the top is any color in the rainbow (not including white or black)
        {
            //then pair the colored top with a black, white, or blue jeans bottom
            string[] allowedBottomColors = { "white", "black", "blue" };
            randomB = filteredBottomsByOccasion.Where(b => allowedBottomColors.Contains(b.Color)).FirstOrDefault();
            if (randomB != null)
            {
                // Keep rolling for a random bottom until it's white, black or blue jeans
                randomB = filteredBottomsByOccasion[random.Next(filteredBottomsByOccasion.Count)];

                Console.WriteLine("No suitable bottom found for the given top color");
                return;
            }
       

            //if the top is any color (other than black or white) then do not put it with a color other than (black or white)
            //i.e. if it is a red top then the bottoms should be black or white
            //if it it a yellow top then the bottoms should be black or white
            //if it is a black or white top, then the bottoms can be any color


            //
            ////then reroll if the bottom is any color but white, black or blue jeans
            //do
            //{
            //    Console.WriteLine("top isn't black or white");
            //    // Keep rolling for a random bottom until it's white, black or blue jeans
            //    randomB = filteredBottomsByOccasion[random.Next(filteredBottomsByOccasion.Count)];
            //    break; 
            //}
            //while (randomB.Color == "white" && randomB.Color == "black" && randomB.Type == "jeans");
            //if (randomB.Type == "jeans") //the program is not getting into this part
            //{
            //    //keep rolling for a random bottom that is jeans until they are blue
            //    do
            //    {
            //        Console.WriteLine("bottom is jeans");

            //        // Keep rolling for a random bottom until it's white, black or blue jeans
            //        randomB = filteredBottomsByOccasion[random.Next(filteredBottomsByOccasion.Count)];
            //        break;
            //    }
            //    while (randomB.Color != "blue" && randomB.Color != "dark blue" && randomB.Color != "teal");

        }
        else if (randomB.Type == "jeans")
        { }

    }

    Console.WriteLine("skipped the do/while");

    Console.WriteLine($"You should Wear This:");
    Console.WriteLine($"Top: -{topForOutfit.Category}- {topForOutfit.Color}, {topForOutfit.Fit} fit, {topForOutfit.Length} {topForOutfit.Type} with {topForOutfit.SleeveLength} sleeves \n" +
                    $"Bottom: -{bottomForOutfit.Category}- {bottomForOutfit.Color}, {bottomForOutfit.Fit}, {bottomForOutfit.Length} length {bottomForOutfit.Type}");

}




//tell the user how she'll look!
if (occasion == "party")
{
    Console.WriteLine("Get ready to shine – your outfit is party perfection.");
}
else if (occasion == "dressy")
{
    Console.WriteLine("dressed to impress! You'll turn heads for sure.");
}
else if (occasion == "casual")
{
    Console.WriteLine("Perfectly laid-back and stylish. You'll be comfortable and fashionable.");
}
else
{
    Console.WriteLine("Confident and stylish – you'll conquer the workday.");
}
Console.WriteLine();
