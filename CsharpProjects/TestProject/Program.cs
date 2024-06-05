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

    public static void FlipACoin()
    {
        Random random = new Random();
        int result = random.Next(0, 2);
        Console.WriteLine(result == 0 ? "heads" : "tails");
    }

    public class User
    {
        public string Permission { get; set; }
        public int Level { get; set; }

        public User(string permission, int level)
        {
            Permission = permission;
            Level = level;
        }
    }

    public static void GetAccess(User user)
    {
        if (user.Permission == "Admin" && user.Level > 55)
        {
            Console.WriteLine("Welcome, Super Admin user.");
        }
        else if (user.Permission == "Admin" && user.Level <= 55)
        {
            Console.WriteLine("Welcome, Admin user.");
        }
        else if (user.Permission == "Manager" && user.Level >= 20)
        {
            Console.WriteLine("Contact an Admin for access.");
        }
        else if (user.Permission == "Manager" && user.Level < 20)
        {
            Console.WriteLine("You do not have sufficient privileges.");
        }
        else if (user.Permission != "Manager" || user.Permission != "Admin")
        {
            Console.WriteLine("You do not have sufficient privileges.");
        }
    }

    public static string[] GetTitle(int level)
    {
        Random random = new Random();
        string[] employees = { "John Smith", "John Doe", "Hello World" };

        int index = random.Next(employees.Length);
        string employee = employees[index];

        string title = string.Empty;

        switch (level)
        {
            case 10:
                title = "Senior Associate";
                break;

            case 9:
            case 8:
            case 7:
                title = "Manager";
                break;

            case 6:
                title = "Senior Manager";
                break;

            default:
                title = "Associate";
                break;
        }

        return new string[] { employee, title };
    }

    public static string[] IfElseIfIntoSwitch()
    {
        // SKU = Stock Keeping Unit. 
        // SKU value format: <product #>-<2-letter color code>-<size code>
        string sku = "01-MN-L";

        string[] product = sku.Split('-');

        string type = string.Empty;
        string color = string.Empty;
        string size = string.Empty;

        switch (product[0])
        {
            case "01":
                type = "Sweat shirt";
                break;
            case "02":
                type = "T-Shirt";
                break;
            case "03":
                type = "Sweat pants";
                break;
            default:
                type = "Other";
                break;
        }

        switch (product[1])
        {
            case "BL":
                color = "Black";
                break;
            case "MN":
                color = "Maroon";
                break;
            default:
                color = "White";
                break;
        }

        switch (product[2])
        {
            case "S":
                size = "Small";
                break;
            case "M":
                size = "Medium";
                break;
            case "L":
                size = "Large";
                break;
            default:
                size = "One Size Fits All";
                break;
        }

        return new string[] { sku, type, color, size };
    }

    public static void FizzBuzz()
    {
        string output = string.Empty;

        for (int i = 1; i < 101; i++)
        {
            bool isDivisibleBy3 = i % 3 == 0;
            bool isDivisibleBy5 = i % 5 == 0;

            if (isDivisibleBy3 && isDivisibleBy5)
            {
                output = $"{i} - FizzBuzz";
            }
            else if (isDivisibleBy5)
            {
                output = $"{i} - Buzz";
            }
            else if (isDivisibleBy3)
            {
                output = $"{i} - Fizz";
            }
            else
            {
                output = $"{i}";
            }

            Console.WriteLine(output);
        }
    }

    public static void DoWhile()
    {
        Random random = new Random();
        int number = 0;

        do
        {
            number = random.Next(0, 11);
            Console.WriteLine(number);
        } while (number != 7);
    }

    public static void While()
    {
        Random random = new Random();
        int number = 0;

        while (number != 9)
        {
            Console.WriteLine(number);
            number = random.Next(0, 11);
        }
        Console.WriteLine($"Last number: {number}");
    }

    public static void WhileContinue()
    {
        Random random = new Random();
        int current = 0;

        do
        {
            current = random.Next(1, 11);

            if (current >= 8)
            {
                continue;
            }

            Console.WriteLine(current);
        } while (current != 7);
    }

    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; set; }

        public Player(string name, int health)
        {
            Name = name;
            Health = health;
        }
    }

    public static void RolePlayingGame()
    {
        Player hero = new Player("Hero", 20);
        Player monster = new Player("Monster", 20);
        int attack;

        do
        {
            attack = new Random().Next(1, 11);
            monster.Health -= attack;
            Console.WriteLine($"{hero.Name} has attacked {monster.Name} by {attack}: {monster.Name}'s health is {(monster.Health <= 0 ? 0 : monster.Health)}");

            if (monster.Health <= 0 || hero.Health <= 0)
            {
                break;
            }

            attack = new Random().Next(1, 11);
            hero.Health -= attack;
            Console.WriteLine($"{monster.Name} has attacked {hero.Name} by {attack}: {hero.Name}'s health is {(hero.Health <= 0 ? 0 : hero.Health)}");

        } while (hero.Health > 0 && monster.Health > 0);
        Console.WriteLine(hero.Health > monster.Health ? $"{hero.Name} wins!" : $"{monster.Name} wins!");
    }

    public static void Main()
    {
        //GetNumberOfTimesALetterAppearsInText("The quick brown fox jumps over the lazy dog.", 'o');
        //GetNumberOfTimesALetterAppearsInText("Hello World", 'l');
        //GetTheScopeOfAVariable();
        //ReadibilityIsKing();
        //ProblematicCode();
        //FlipACoin();

        //Console.WriteLine($"User permission\t\tUser level\t\tMessage\n");
        //for (int i = 0; i < 10; i++)
        //{
        //    Random permission = new Random();
        //    string permissionString = (permission.Next(0, 3) == 0 ? "Admin" : permission.Next(0, 3) == 1 ? "Manager" : "Other");

        //    Random level = new Random();

        //    User user = new User(permissionString, level.Next(0, 101));
        //    Console.Write($"{user.Permission}\t\t\t{user.Level}\t\t\t");
        //    GetAccess(user);
        //}

        //Console.WriteLine($"Employee name\t\tUser title\n");
        //for (int i = 0; i < 10; i++)
        //{
        //    Random level = new Random();
        //    string[] result = GetTitle(level.Next(0, 11));
        //    Console.WriteLine($"{result[0]}\t\t{result[1]}");
        //}

        //Console.WriteLine(string.Join(", ", IfElseIfIntoSwitch()));
        //FizzBuzz();
        //DoWhile();
        //While();
        //WhileContinue();
        RolePlayingGame();
    }
}
