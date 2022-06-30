int numberOfSides = 0;     // user input for # of sides 
bool validDice = false;   //making sure i have good dice, starting this out FALSE!!! 
bool continuePlaying = true;
int num1 = 0;
int num2 = 0;

Console.WriteLine("Welcome to the Dice Roller!");

while (!validDice)
{    //make sure no strings can get past the first prompt.
    try
    {
        Console.WriteLine("Please enter the number of sides on your dice; it must be a positive number! ");
        numberOfSides = int.Parse(Console.ReadLine());

        // now make sure it's positive
        if (numberOfSides <= 0)
        {
            throw new Exception("This is not positive, these dice do not exist.");
        }
        else
        {
            //valid number of sides, we can exit the loop. 
            validDice = true;
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

//number of sides is now valid, moving along. 

while (continuePlaying) // starts here after they choose to roll again 
{
    Console.WriteLine("Press any key to roll your dice.");
    Console.ReadKey();
    Console.WriteLine();

    // get my numbers 
    num1 = RandomNumber(numberOfSides);
    num2 = RandomNumber(numberOfSides);

    if (numberOfSides == 6) // 6 sided dice being used 
    {
        Console.WriteLine($"You rolled a {num1} and a {num2}.");
        Console.WriteLine(SixSidedDice(num1, num2));
        Console.WriteLine();
    }
    else // any other type of dice 
    {
        UsersDiceChoice(num1, num2);
        Console.WriteLine();
    }

    while (true)
    {
        Console.WriteLine("Roll again? (y/n)");
        string playAgain = Console.ReadLine().ToLower().Trim();

        if (playAgain == "y")
        {
            break;
        }
        else if (playAgain == "n")
        {
            Console.WriteLine("Thanks for playing!");
            continuePlaying = false;
            break;
        }
        else
        {
            Console.WriteLine("Please make a valid selection");
            continue;
        }
    }
}
    
static int RandomNumber(int n)
{
    int x = new Random().Next(1, n);
    return x;
}

static void UsersDiceChoice(int num1, int num2) //any other dice size but 6 
{
    int sum = num1 + num2;
    Console.WriteLine($"You rolled a {num1} and a {num2}.");
    Console.WriteLine($"Total: {sum}");

    //extra mini wins, can be taken out
    if (num1 == num2)
    {
        Console.WriteLine("Winner winner! Matching dice!");
    }
    if (num1 == num2-1)
    {
        Console.WriteLine("Adjacent numbers!");
    }
    if (num1 == num2+1)
    {
        Console.WriteLine("Adjacent numbers!");
    }
}

static string SixSidedDice(int num1, int num2)
{
    int sum = num1 + num2;
    string message;

    if (sum == 7 || sum == 11)
    {
        message = $"Total: {sum} - You Win!";
        return message;
    }
    else if (sum == 2)  //snake eyes, but 2 HAS to be 1 and 1 on 6-side dice 
    {
        message = $"Total: {sum}\nSnake Eyes!\nCraps!";
        return message;
    }
    else if (sum == 3) // ace deuce, but 3 HAS to be 2 and 1 on 6-side die 
    {
        message = $"Total: {sum}\nAce Deuce!\nCraps!";
        return message;
    }
    else if (sum == 12) // 6s are only option 
    {
        message = $"Total: {sum}\nBox Cars!\nCraps!";
        return message;
    }
    else
    {
        return "";
    }
}