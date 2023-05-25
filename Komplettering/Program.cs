List<float> results = new(); //listor är dynamiska och kan expandera. Arrays kan inte.
//Vi vill kunna öka listan om det så behövs pga mer objekt som blir adderade.

// Vi skapar några variablar som kommer att behövas för logik i programmet
string confirm;
bool valid = false;
bool exit = false;

Console.WriteLine("Welcome to an ordinary calculator!"); //Informera användaren om vad det är för programm
Console.WriteLine("\nPress enter:"); //Instruktioner om procedur
Console.ReadLine(); // Väntar för input från användaren
Console.Clear(); //Rensar all text i consolen

// En loop som körs så länge exit är falskt. Det är i den här loopen som hela programmmet körs.
//Programmet är i en loop för att användaren ska kunna köra den om och om utan att behöva start programmet om hela tiden
while(!exit) 
{
    confirm = ""; //Ställer in confirm till blankt så att den inte påverkar funtkioner
    results.Add(Calculate()); //Vi lägger resultatet från funktionen Calculate in till listan results. 
    // funktionen Calculate körs.

    //Vi frågar om användaren vill se sin historik av resultat.
    Console.WriteLine("\nDo you wish to see your history?");

    //Definera confirm utifrån vad användaren skriver.
    //ToLower() är för att koden ska bortse från små och stora bokstäver. Det kan göra skillnad i hur koden svarar
    // om en enda bokstav är stor eller liten
    confirm = Console.ReadLine().ToLower();

    // Funktionen ValidConfirm körs och i den stoppas variablarna confirm och valid. 
    //If satsen jämför om funktionen returnerar ett värde som är sant och om confirm innehåller yes eller y
    if (ValidConfirm(confirm, valid) && confirm == "yes" || confirm == "y")
    {
        // Eftersom confirm blev yes/y, så kommer alla objekt i listan results att skrivas ut med en
        // foreach loop.
        foreach (float result in results)
        {
            Console.WriteLine(result); //skriver objektet result från listan results.
        }
    }

    else // om ValidConfirm är inte true och confirm är yes/y så körs den här
    {
        //Den kontrollerar om Validconfirm är false, alltså om man skrev något annat än yes/y/no/n.
        //Om det är falskt körs den här loopen
        while(!ValidConfirm(confirm, valid))
        {
            //Ber användaren att skriva in giltiga svar
            Console.WriteLine("\nWrite a valid answer (yes/no/y/n)");
            confirm = Console.ReadLine().ToLower(); //omdefinerar confirm till user input

            //Om användaren fattade instruktionerna och skrev yes/y så kommer nu alla resultat i results
            // att skrivas ut
            if(ValidConfirm(confirm, valid) && confirm == "yes" || confirm == "y")
            {

                //Referera till kommentarerna på rad 35 och 38
                foreach (float result in results)
                {
                    Console.WriteLine(result);
                }
            }
        }
    }

    confirm = ""; //Ställer om confirm till blank för att inte krångla logiken

    Console.WriteLine("\nDo you wish to exit?"); //fråga användaren om de vill avsluta programmet
    confirm = Console.ReadLine().ToLower(); //Definera confirm till user input
    
    // Referera till kommentaren på rad  30
    if(ValidConfirm(confirm, valid) && confirm == "yes" || confirm == "y")
    {
        break; //Om användaren svarade med yes/y så bryter man ut ur while loopen och avslutar programmet. 
    }
    else
    {
        // Referera till kommentarerna på rad 42-45
        while(!ValidConfirm(confirm, valid))
        {
            Console.WriteLine("\nWrite a valid answer (yes/no/y/n)");
            confirm = Console.ReadLine().ToLower();
            if(ValidConfirm(confirm, valid) && confirm == "yes" || confirm == "y")
            {
                exit = true; //Om confirm är yes/y, avsluta programmet.
            }
        }
    }
}

//Själva "miniräknaren"
float Calculate()
{
    Console.WriteLine("\nPlease write your problem:"); //Presentera instruktion
    float result = 0; //sksapa float variabel
    string problem = Console.ReadLine(); //matematiska problemet som använderen skriver in

    //Datatable är vad som det heter. En datatabell med olika former av data.
    //Vi skapar en sådan typ av variabel som baserar sig på den här datatabellen
    var dataTable = new System.Data.DataTable();

    // Vi testar om lösningen kan sparas i variabeln "result" som en int. Vi säger åt dataTable att 
    //beräkna variabeln problem utan någon filter (alltså ""). Efter den beräknas så görs den om till en string innan
    //slutligen till en float.
    try
    {
        result = float.Parse(dataTable.Compute(problem, "").ToString());
        Console.WriteLine(dataTable.Compute(problem, ""));
        //Om operationen lyckas: skriv ut resultaten
    }
    catch { Console.WriteLine("INVALID OPERATION"); }
    //annars så säger den det här.

    return result; //returnera variabeln result från funktionen
}

//En funktion som kontrollerar om ditt svar yes/no är giltigt. Alltså om du har svarat y/n eller något annat
static bool ValidConfirm(string confirm, bool valid) //stoppar in stringen confirm (user svar till y/n) och variabeln valid
{
    //Om du svarar rätt så blir din svar valid och programmet fortsätter som vanligt
    if (confirm == "yes" || confirm == "y" || confirm == "no" || confirm == "n")
    {
        valid = true;
    }
    else //annars så blir din invalid och du måste svara om på y/n frågor
    {
        valid = false;
    }

    return valid; //returnera variabeln valid
}
