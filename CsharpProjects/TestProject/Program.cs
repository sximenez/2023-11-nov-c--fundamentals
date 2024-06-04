public class Program
{
    public static void GetNumberOfTimesALetterAppearsInText(string input, char lookUpLetter)
    {
        /*
        The purpose of this code is
        to count the number of times 
        a particular character appears. 
        */

        int letterCount = 0;
        foreach (char letter in input)
        {
            if (letter == lookUpLetter)
            {
                letterCount++;
            }
        }

        Console.WriteLine(input);
        Console.WriteLine($"'{lookUpLetter}' appears {letterCount} times.");
    }

    public static void GetTheScopeOfAVariable()
    {
        /*
        To be able to respond to both true and false execution paths,
        the compiler needs variable value to be initialized.
        Otherwise, it will not be able to respond when flag is false.
        */

        bool flag = true;
        int value = 0;

        while (flag)
        {
            Console.WriteLine($"Inside the code block: {value}");
            flag = false;
            value = 10;
        }

        Console.WriteLine($"Outside the code block: {value}");
    }

    public static void ReadibilityIsKing()
    {
        bool flag = true;
        if (flag)
        {
            Console.WriteLine(flag);
        }

        if (flag)
            Console.WriteLine(flag);

        if (flag) Console.WriteLine(flag);

        string name = "steve";

        if (name == "bob")
        {
            Console.WriteLine("Found Bob");
        }
        else if (name == "steve")
        {
            Console.WriteLine("Found Steve");
        }
        else
        {
            Console.WriteLine("Found Chuck");
        }

        if (name == "bob")
            Console.WriteLine("Found Bob");
        else if (name == "steve")
            Console.WriteLine("Found Steve");
        else
            Console.WriteLine("Found Chuck");

        if (name == "bob") Console.WriteLine("Found Bob");
        else if (name == "steve") Console.WriteLine("Found Steve");
        else Console.WriteLine("Found Chuck");
    }

    public static void ProblematicCode()
    {
        bool found = false;
        int total = 0;
        int[] numbers = { 4, 8, 15, 16, 23, 42 };

        foreach (int number in numbers)
        {
            total += number;

            if (number == 42)
            {
                found = true;
            }
        }

        if (found)
        {
            Console.WriteLine("Set contains 42");
        }

        Console.WriteLine($"Total: {total}");
    }

    public static void Main()
    {
        //GetNumberOfTimesALetterAppearsInText("The quick brown fox jumps over the lazy dog.", 'o');
        //GetNumberOfTimesALetterAppearsInText("Hello World", 'l');
        //GetTheScopeOfAVariable();
        //ReadibilityIsKing();
        ProblematicCode();
    }
}
