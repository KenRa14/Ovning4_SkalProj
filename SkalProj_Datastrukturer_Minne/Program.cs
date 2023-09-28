using System;
using System.Text;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            /*
             1. Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess
                grundläggande funktion

                Stacken innehåller en metods lokala variabler och fungerar som en stack collection. 
                Det vill säga att när en metod används en block som innehåller lokala variabler skapas och 
                när inom den metoden en annan metoden används en annan block skapas. När sista metoden 
                "return" tas dess block bort ur stacken.

                Heapen innehåller reference types. Det finns inget ordning för att komma åt objekt. 
                Objekt rensas av en tredje komponent som kallas för Garbage collector som håller koll
                på objekt för att veta när de slutar användas.

             2. Vad är Value Types respektive Reference Types och vad skiljer dem åt?

                vet inte.

             3. Följande metoder (se bild nedan) genererar olika svar. Den första returnerar 3, den
                andra returnerar 4, varför?                ReturnValue(): y varible själv ändras. För ett ögonblick x och y håller samma value,                               men när y = 4; händer det som ändras är variablen y.                ReturnValue2(): objektets fält ändras. För ett ögonblick x och y håller olika objekt,                                men när de blir samma reference genom x = y; och när y.MyValue = 4; händer                                det som händras är objektets fält och varibler x och y håller fortfarande                                 samma reference till objektet.             *Rekursion och Iteration (Extra om tid finns)
             
                Utgå ifrån era nyvunna kunskaper om iteration, rekursion och minneshantering. Vilken av
                ovanstående funktioner är mest minnesvänlig och varför?                Kanske iteration om det inte skapas nya reference types om och om igen.
             */

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n5. Examine recursion"
                    + "\n6. Examine Iteration"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '5':
                        ExamineRecursive();
                        break;
                    case '6':
                        ExamineIteration();
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             2. När ökar listans kapacitet? (Alltså den underliggande arrayens storlek)

                Om 4 är default värdet ökar det när en femte försöks lägga till.

             3. Med hur mycket ökar kapaciteten?
                
                kapaciteten blir dubbelt så mycket.

             4. Varför ökar inte listans kapacitet i samma takt som element läggs till?

                Items läggs till en i taget medan kapaciteten blir dubbelt.

             5. Minskar kapaciteten när element tas bort ur listan?

                Nej.

             6. När är det då fördelaktigt att använda en egendefinierad array istället för en lista?

                kanske när mängden items är känd på förhand och är fastsälld.
             */

            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            List<string> theList = new List<string>();
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Please enter an input that starts with +, - or * to add, remove or exit to main menu."
                    + "\nExample:"
                    + "\n+Adam (Adam has been added)."
                    + "\n-Adam (Adam has been removed)."
                    + "\n* (exits to main menu)"
                    + "\n");

                Console.WriteLine($"Count: {theList.Count}" 
                    + $"\nCapacity: {theList.Capacity}" 
                    + "\n");

                string input = Console.ReadLine()!;
                char nav = ' ';
                string value = "";

                if (!string.IsNullOrEmpty(input))
                {
                    input = input.Trim();
                    nav = input[0];
                    value = input[1..];
                }

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        break;
                    case '-':
                        theList.Remove(value);
                        break;
                    case '*':
                        exit = true;
                        break;
                }
            }
            Console.Clear();

        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            Queue<string> theQueue = new();
            bool exit = false;
            while (!exit)
            {
                //to cause pleasant to the eye blinking
                Console.Clear();

                Console.Write("Please enter an input that starts with +, - or * to add, remove or exit to main menu."
                    + "\nExample:"
                    + "\n+Adam (Adam gets in line)."
                    + "\n- (Adam leaves the line)."
                    + "\n* (exits to main menu)"
                    + "\n"
                    + "\nInput: ");

                //writes queue to end of console to see behavior
                if (theQueue.Count>0)
                {
                    Console.WriteLine("\n\nQueue: ");
                    foreach (var item in theQueue)
                    {
                        Console.WriteLine($"  {item}");
                    }
                }
                
                //sets cursor after "Input: "
                Console.SetCursorPosition(7, 6);

                string input = Console.ReadLine()!;
                char nav = ' ';
                string value = "";

                if (!string.IsNullOrEmpty(input))
                {
                    input = input.Trim();
                    nav = input[0];
                    value = input[1..];
                }

                switch (nav)
                {
                    case '+':
                        theQueue.Enqueue(value);
                        break;
                    case '-':
                        if (theQueue.Count > 0)
                            theQueue.Dequeue();
                        break;
                    case '*':
                        exit = true;
                        break;
                }
            }
            Console.Clear();

        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             1. Simulera ännu en gång ICA-kön på papper. Denna gång med en stack. Varför är det
                inte så smart att använda en stack i det här fallet?
                
                Eftersom någons varor kanshe hade börjat skanna, men någon annan kom och vad händer nu?
             */

            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            Stack<char> theStack = new();
            bool exit = false;
            while (!exit)
            {
                Console.Clear();

                Console.Write("Please enter any text (preferably longer than 1 character)"
                    + "\n"
                    + "\nInput: ");

                string input = Console.ReadLine()!;

                if (!string.IsNullOrEmpty(input))
                {

                    string output = "";

                    //Pushing plus writing to console to see behaviour
                    Console.WriteLine("\nPushing... ");
                    foreach (var inputChar in input)
                    {

                        theStack.Push(inputChar);

                        Console.SetCursorPosition(0, 5);
                        Thread.Sleep(300);
                        foreach (var stackChar in theStack)
                        {
                            Console.Write(stackChar);
                        }
                    }

                    Console.WriteLine("\n\npoping... ");


                    //poping plus writing to console to see behaviour
                    while (theStack.Count > 0)
                    {
                        Console.SetCursorPosition(0, 8);
                        foreach (var stackChar in theStack)
                        {
                            Console.Write(stackChar);
                        }

                        output += theStack.Pop();
                        Thread.Sleep(300);

                        //replacing stackChars previously written to console with white spaces
                        Console.SetCursorPosition(0, 8);
                        Console.Write(new StringBuilder((theStack.Count + 1) * 3).Insert(0, " ", theStack.Count + 1));

                    }

                    Console.WriteLine($"\nReversed input: {output}");
                }

                Console.WriteLine("\nTo exit to main menu press ESC. Anything else to continue.");

                ConsoleKeyInfo cki = Console.ReadKey(true);

                if (cki.Key == ConsoleKey.Escape)
                {
                    exit = true;
                }

            }
            Console.Clear();
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            Dictionary<char, char> parenthesisMapping = new Dictionary<char, char>() {
                { ')', '(' },
                {'}', '{' },
                {']' , '[' }
            };

            bool exit = false;
            while (!exit)
            {
                Console.Clear();

                Console.Write("Please enter any text with at least a pair of the next types of parenthesis (), {}, []"
                    + "\n"
                    + "\nInput: ");

                string input = Console.ReadLine()!;
                if (!string.IsNullOrEmpty(input))
                {
                    bool success = true;
                    Stack<char> theStack = new();
                    foreach (var c in input)
                    {
                        //checking opening paretesis
                        if (parenthesisMapping.ContainsValue(c))
                        {
                            theStack.Push(c);
                        }
                        //checking closing paretesis
                        else if (parenthesisMapping.ContainsKey(c))
                        {
                            if (theStack.TryPeek(out char parenthesis))
                            {
                                if (parenthesisMapping.GetValueOrDefault(c) == parenthesis)
                                {
                                    theStack.Pop();
                                }
                                else
                                {
                                    success = false;
                                    Console.WriteLine("Wrong format. Wrong closing parenthesis.");
                                    break;
                                }
                            }
                            else
                            {
                                success = false;
                                Console.WriteLine("Wrong format. More closing parenthesis than opening parenthesis.");
                                break;
                            }
                        }
                    }

                    if (success)
                    {
                        if (theStack.Count > 0)
                        {
                            Console.WriteLine("Wrong format. More opening parenthesis than closing parenthesis.");
                        }
                        else
                        {
                            Console.WriteLine("Correct format.");
                        }
                    }
                }

                Console.WriteLine("\nTo exit to main menu press ESC. Anything else to continue.");

                ConsoleKeyInfo cki = Console.ReadKey(true);

                if (cki.Key == ConsoleKey.Escape)
                {
                    exit = true;
                }

            }
            Console.Clear();
        }

        static void ExamineRecursive()
        {

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Examine Recursion"
                    + "\nPlease navigate through the menu by inputting the number \n(1, 2, 3, 0) of your choice"
                    + "\n1. Recursive Odd"
                    + "\n2. Recursive Even"
                    + "\n3. Recursive Fibonacci"
                    + "\n0. Exit to main menu");

                string input = Console.ReadLine()!;
                char nav = ' ';

                if (!string.IsNullOrEmpty(input))
                {
                    input = input.Trim();
                    nav = input[0];
                }

                int num;
                switch (nav)
                {
                    case '1':
                        Console.WriteLine("Recursive Odd");
                        num = GetInt("number", out input, true);
                        if (!string.IsNullOrEmpty(input))
                        {
                            if (num > 0)
                                Console.WriteLine($"output: {RecursiveOdd(num)}");
                            else
                                Console.WriteLine($"output: Error");
                            Stop();
                        }
                        break;
                    case '2':
                        Console.WriteLine("Recursive Even");
                        num = GetInt("number", out input, true);
                        if (!string.IsNullOrEmpty(input))
                        {
                            if (num > 0)
                                Console.WriteLine($"output: {RecursiveEven(num)}");
                            else
                                Console.WriteLine($"output: Error");
                            Stop();
                        }
                        break;
                    case '3':
                        Console.WriteLine("Recursive Fibonacci");
                        num = GetInt("number", out input, true);
                        if (!string.IsNullOrEmpty(input))
                        {
                            if (num > 0)
                                Console.WriteLine($"output: {RecursiveFibonacci(num)}");
                            else
                                Console.WriteLine($"output: Error");
                            Stop();
                        }
                        break;
                    case '0':
                        exit = true;
                        break;
                }
                
            }
            Console.Clear();

        }

        static void ExamineIteration()
        {

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Examine Recursion"
                    + "\nPlease navigate through the menu by inputting the number \n(1, 2, 3, 0) of your choice"
                    + "\n1. Iterative Odd"
                    + "\n2. Iterative Even"
                    + "\n3. Iterative Fibonacci"
                    + "\n0. Exit to main menu");

                string input = Console.ReadLine()!;
                char nav = ' ';

                if (!string.IsNullOrEmpty(input))
                {
                    input = input.Trim();
                    nav = input[0];
                }

                int num;
                switch (nav)
                {
                    case '1':
                        Console.WriteLine("Iterative Odd");
                        num = GetInt("number", out input, true);
                        if (!string.IsNullOrEmpty(input))
                        {
                            if (num > 0)
                                Console.WriteLine($"output: {IterativeOdd(num)}");
                            else
                                Console.WriteLine($"output: Error");
                            Stop();
                        }
                        break;
                    case '2':
                        Console.WriteLine("Iterative Even");
                        num = GetInt("number", out input, true);
                        if (!string.IsNullOrEmpty(input))
                        {
                            if (num > 0)
                                Console.WriteLine($"output: {IterativeEven(num)}");
                            else
                                Console.WriteLine($"output: Error");
                            Stop();
                        }
                        break;
                    case '3':
                        Console.WriteLine("Iterative Fibonacci");
                        num = GetInt("number", out input, true);
                        if (!string.IsNullOrEmpty(input))
                        {
                            if (num > 0)
                                Console.WriteLine($"output: {IterativeFibonacci(num)}");
                            else
                                Console.WriteLine($"output: Error");
                            Stop();
                        }
                        break;
                    case '0':
                        exit = true;
                        break;
                }

            }
            Console.Clear();

        }

        static void Stop()
        {
            Console.WriteLine("\nPress a key to continue...");
            Console.ReadKey(true);
        }

        static int GetInt(string name, out string input, bool stopIfEmpty)
        {
            bool error = false;
            int number = 0;
            input = "";
            do
            {
                if (error)
                {
                    Console.WriteLine($"Error: '{input}' is not a valid number.\n");
                }
                Console.Write($"Enter {name}: ");

                input = Console.ReadLine()!;
                if (string.IsNullOrEmpty(input))
                {
                    if (stopIfEmpty)
                    {
                        break;
                    }
                    else
                    {
                        error = true;
                        continue;
                    }
                }

                error = !int.TryParse(input.Trim(), out number);

            } while (error);

            return number;
        }

        static int RecursiveOdd(int n)
        {
            ThrowArgumentOutOfRangeException(n);

            if (n == 1)
            {
                return 1;
            }
            return RecursiveOdd(n - 1) + 2;
        }

        static int RecursiveEven(int n)
        {
            ThrowArgumentOutOfRangeException(n);

            if (n == 1)
            {
                return 0;
            }
            return RecursiveEven(n - 1) + 2;
        }

        static int RecursiveFibonacci(int n)
        {
            ThrowArgumentOutOfRangeException(n);

            if (n == 1)
                return 0;
            else if(n == 2) 
                return 1;

            return RecursiveFibonacci(n - 1) + RecursiveFibonacci(n - 2);
        }

        private static void ThrowArgumentOutOfRangeException(int n)
        {
            if (n < 1)
                throw new ArgumentOutOfRangeException($"Argument can't be less than 1");
        }

        static int IterativeOdd(int n)
        {
            ThrowArgumentOutOfRangeException(n);

            int result = 1;

            for (int i = 1; i < n; i++)
            {
                result += 2;
            }

            return result;
        }

        static int IterativeEven(int n)
        {
            ThrowArgumentOutOfRangeException(n);

            int result = 0;

            for (int i = 1; i < n; i++)
            {
                result += 2;
            }

            return result;
        }

        static int IterativeFibonacci(int n)
        {
            ThrowArgumentOutOfRangeException(n);

            if (n == 1)
                return 0;

            int result = 1,
                prevResult = 0;

            for (int i = 2; i < n; i++)
            {
                int tempResult = result;
                result += prevResult;
                prevResult = tempResult;
            }

            return result;
        }
    }
}

