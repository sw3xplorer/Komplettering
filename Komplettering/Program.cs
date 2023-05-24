List<float> results = new(); //listor är dynamiska och kan expandera. Arrays kan inte.
//Vi dill kunna öka listan om det så behövs. 
string confirm;
bool valid = false;
bool exit = false;

Console.WriteLine("Welcome to an ordinary calculator!");
Console.WriteLine("\nPress enter:");
Console.ReadLine();
Console.Clear();

while(!exit)
{
    confirm = "";
    results.Add(Calculate());
    Console.WriteLine("\nDo you wish to see your history?");
    confirm = Console.ReadLine().ToLower();

    if (ValidConfirm(confirm, valid) && confirm == "yes" || confirm == "y")
    {
        foreach (float result in results)
        {
            Console.WriteLine(result);
        }
    }
    else
    {
        while(!ValidConfirm(confirm, valid))
        {
            Console.WriteLine("\nWrite a valid answer (yes/no/y/n)");
            confirm = Console.ReadLine().ToLower();
            if(ValidConfirm(confirm, valid) && confirm == "yes" || confirm == "y")
            {
                foreach (float result in results)
                {
                    Console.WriteLine(result);
                }
            }
        }
    }

    confirm = "";

    Console.WriteLine("\nDo you wish to exit?");
    confirm = Console.ReadLine().ToLower();
    
    if(ValidConfirm(confirm, valid) && confirm == "yes" || confirm == "y")
    {
        break;
    }
    else
    {
        while(!ValidConfirm(confirm, valid))
        {
            Console.WriteLine("\nWrite a valid answer (yes/no/y/n)");
            confirm = Console.ReadLine().ToLower();
            if(ValidConfirm(confirm, valid) && confirm == "yes" || confirm == "y")
            {
                exit = true;
            }
        }
    }
}

float Calculate()
{
    Console.WriteLine("\nPlease write your problem:");
    float result = 0;
    string problem = Console.ReadLine();
    var dataTable = new System.Data.DataTable();
    try
    {
        result = float.Parse(dataTable.Compute(problem, "").ToString());
        Console.WriteLine(dataTable.Compute(problem, ""));
    }
    catch { Console.WriteLine("INVALID OPERATION"); }

    return result;
}

static bool ValidConfirm(string confirm, bool valid)
{
    if (confirm == "yes" || confirm == "y" || confirm == "no" || confirm == "n")
    {
        valid = true;
    }
    else
    {
        valid = false;
    }

    return valid;
}
