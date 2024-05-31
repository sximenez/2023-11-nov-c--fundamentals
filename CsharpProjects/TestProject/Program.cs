public class Program
{
    public static string Reverse(string input)
    {
        return input;
    }

    public static void Main()
    {
        /*
        The purpose of this code is
        to reverse a string and 
        count the number of times 
        a particular character appears. 
        */

        string str = "The quick brown fox jumps over the lazy dog.";

        char[] charMessage = str.ToCharArray();
        Array.Reverse(charMessage);

        int x = 0;
        foreach (char i in charMessage)
        {
            if (i == 'o')
            {
                x++;
            }
        }

        string new_message = new String(charMessage);

        Console.WriteLine(new_message);
        Console.WriteLine($"'o' appears {x} times.");
    }
}
