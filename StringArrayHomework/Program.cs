
using System.Diagnostics;
using System.Drawing;

string[,] questions = new string[10, 4];
int Points = 0;

void fillQUestions()
{
    questions[0, 0] = "Azerbaycanin paytaxti haradi?";
    questions[0, 1] = "Baki";
    questions[0, 2] = "Gence";
    questions[0, 3] = "Saumqayit";

    questions[1, 0] = "Amerikanin paytaxti haradi?";
    questions[1, 1] = "Vashington";
    questions[1, 2] = "Teksas";
    questions[1, 3] = "Florida";

    questions[2, 0] = "Hindistanin paytaxti haradi?";
    questions[2, 1] = "Dele";
    questions[2, 2] = "Dehli";
    questions[2, 3] = "Parij";

    questions[3, 0] = "Yaponyanin paytaxti haradi?";
    questions[3, 1] = "Tokyo";
    questions[3, 2] = "Akihabara";
    questions[3, 3] = "Shanqay";

    questions[4, 0] = "Rusiyanin paytaxti haradi?";
    questions[4, 1] = "Moskow";
    questions[4, 2] = "Novosibirsk";
    questions[4, 3] = "Saint Peterburg";

    questions[5, 0] = "Ingilterenin paytaxti haradi?";
    questions[5, 1] = "London";
    questions[5, 2] = "Manchester";
    questions[5, 3] = "CHelsea";

    questions[6, 0] = "Turkiyenin paytaxti haradi?";
    questions[6, 1] = "Istanbul";
    questions[6, 2] = "Ankara";
    questions[6, 3] = "Izmir";

    questions[7, 0] = "Ukrainanin paytaxti haradi?";
    questions[7, 1] = "Odesa";
    questions[7, 2] = "Lvov";
    questions[7, 3] = "Kiev";

    questions[8, 0] = "Norvechin paytaxti haradi?";
    questions[8, 1] = "Oslo";
    questions[8, 2] = "Arendal";
    questions[8, 3] = "Drammen";

    questions[9, 0] = "Almaniyanin paytaxti haradi?";
    questions[9, 1] = "Berlin";
    questions[9, 2] = "Munhen";
    questions[9, 3] = "Luksenburg";

}
void randomizeQuestions()
{

    Random random = new Random();
    for (int i = 0; i < questions.GetLength(0); i++)
    {
        int ranNum = random.Next(0, 9);

        string temp = questions[i, 0];
        string temp1 = questions[i, 1];
        string temp2 = questions[i, 2];
        string temp3 = questions[i, 3];
        questions[i, 0] = questions[ranNum, 0];
        questions[i, 1] = questions[ranNum, 1];
        questions[i, 2] = questions[ranNum, 2];
        questions[i, 3] = questions[ranNum, 3];
        questions[ranNum, 0] = temp;
        questions[ranNum, 1] = temp1;
        questions[ranNum, 2] = temp2;
        questions[ranNum, 3] = temp3;

    }
    for (int i = 0; i < questions.GetLength(0); i++)
    {
        for (int k = 3; k > 1; k--)
        {

            int ranNum = random.Next(1, 3);
            string temp = questions[i, k];
            questions[i, k] = questions[i, ranNum];
            questions[i, ranNum] = temp;
        }
    }
}
void showcolorizedQuestions(int qIndex1, string color)
{
    ConsoleColor originalForegroundColor = Console.ForegroundColor;
    switch (color)
    {
        case "red":
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(questions[qIndex1, 0]);
            Console.WriteLine($"1:{questions[qIndex1, 1]}");
            Console.WriteLine($"2:{questions[qIndex1, 2]}");
            Console.WriteLine($"3:{questions[qIndex1, 3]}");
            Console.ForegroundColor = originalForegroundColor;
            break;
        case "green":
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(questions[qIndex1, 0]);
            Console.WriteLine($"1:{questions[qIndex1, 1]}");
            Console.WriteLine($"2:{questions[qIndex1, 2]}");
            Console.WriteLine($"3:{questions[qIndex1, 3]}");
            Console.ForegroundColor = originalForegroundColor;
            break;


    }
}
bool isTrue(string answer)
{
    string[] trueanswers = new string[10] { "Baki", "Vashington", "Dele", "Tokyo", "Moskow", "London", "Ankara", "Kiev", "Oslo", "Berlin" };
    for (int i = 0; i < 10; i++)
    {
        if (answer == trueanswers[i]) { return true; }
    }
    return false;
}
void examStart()
{
    fillQUestions();
    randomizeQuestions();
    for (int i = 0; i < questions.GetLength(0); i++)
    {
        Console.Clear();
        for (int k = 0; k < 4; k++)
        {
            if (k > 0) Console.WriteLine($"{k}:{questions[i, k]}");
            else Console.WriteLine(questions[i, k]);
        }
        int Choice = Convert.ToInt32(Console.ReadKey().Key) - 48;
        Console.WriteLine(questions[i, Choice]);
        isTrue(questions[i, Choice]);
        if (isTrue(questions[i, Choice]))
        {
            Points += 10;
            Console.Clear();
            showcolorizedQuestions(i, "green");
            Thread.Sleep(1000);
        }
        else
        {
            if (Points - 10 < 0)
            {
                Points = 0;
            }
            else Points -= 10;
            Console.Clear();
            showcolorizedQuestions(i, "red");
            Thread.Sleep(1000);
        }
        Console.WriteLine("\n");
    }
    Console.Clear();
    Console.WriteLine($"Your points is {Points}");
}
examStart();