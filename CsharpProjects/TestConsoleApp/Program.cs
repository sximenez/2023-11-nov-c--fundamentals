using System.Reflection;
using System.Xml.Xsl;

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

    public static void IntegerInput()
    {
        string? input;
        bool validEntry = false; // Exit condition.

        Console.WriteLine("Enter an integer value between 5 and 10:");

        do
        {
            input = Console.ReadLine();

            if (int.TryParse(input, out int output))
            {
                if (output >= 5 && output <= 10)
                {
                    validEntry = true;
                    Console.WriteLine($"Your input value ({output}) has been accepted.");
                }
                else
                {
                    Console.WriteLine($"You entered {output}. Please enter a number between 5 and 10:");
                }
            }
            else
            {
                Console.WriteLine("Sorry, you entered an invalid number, please try again:");
            }
        } while (!validEntry);
    }

    public static void StringInput()
    {
        string? input;
        bool validEntry = false; // Exit condition.

        string[] roles = ["Administrator", "Manager", "User"];
        string validRole = string.Empty;

        do
        {
            Console.WriteLine("Enter your role name (Administrator, Manager, or User):");
            input = Console.ReadLine();

            foreach (string role in roles)
            {
                if (!string.IsNullOrEmpty(input) && input.Equals(role, StringComparison.OrdinalIgnoreCase))
                {
                    validRole = role;
                    break;
                }
            }

            if (!string.IsNullOrEmpty(validRole))
            {
                validEntry = true;
                Console.WriteLine($"Your input value({validRole}) has been accepted.");
            }
            else
            {
                Console.WriteLine($"The role name that you entered, \"{input}\" is not valid.");
            }

        } while (!validEntry);
    }

    public static void StringArray()
    {
        string[] myStrings = ["I like pizza. I like roast chicken. I like salad", "I like all three of the menu choices"];
        int periodLocation = -1;

        for (int i = 0; i < myStrings.Length; i++)
        {
            do
            {
                periodLocation = myStrings[i].Contains('.') ? myStrings[i].IndexOf('.') : periodLocation;

                if (periodLocation > 0)
                {
                    string tempString = myStrings[i][..periodLocation];
                    Console.WriteLine(tempString);
                    myStrings[i] = myStrings[i].Remove(0, tempString.Length + 1).Trim();
                    periodLocation = -1;
                }
                else
                {
                    Console.WriteLine(myStrings[i]);
                    break;
                }
            } while (periodLocation < 0);
        }
    }

    private List<Animal> ourAnimals = new List<Animal>();
    private HashSet<string> acceptedSpecies = new HashSet<string>() { "cat", "dog" };
    private int idCounter = 1;

    public class Animal
    {
        public int Id { get; }
        public string Species { get; set; }
        public string Nickname { get; set; }
        public int? Age { get; set; }
        public string? Characteristics { get; set; }
        public string? Personality { get; set; }

        public Animal(int id, string species, string? age, string? characteristics, string? personality, string nickname)
        {
            Id = id;
            Species = species;
            Age = (!string.IsNullOrEmpty(age)) ? int.Parse(age) : 0;
            Characteristics = characteristics;
            Personality = personality;
            Nickname = nickname;
        }
    }

    public static void ShowCommands()
    {
        Dictionary<string, string> commands = new Dictionary<string, string>
        {
            { "all" , "List all current animals." },
            { "cats" , "List current cats." },
            { "dogs" , "List current dogs." },
            { "add" , "Add a new animal." },
            { "edit" , "Edit an animal." },
            { "search" , "Search an animal by keyword." },
            { "commands", "Show commands." },
            { "quit" , "Exit the program." }
        };

        Console.WriteLine("\nCOMMANDS");

        foreach (KeyValuePair<string, string> command in commands)
        {
            Console.WriteLine($"{command.Key,-20}{command.Value}");
        }
    }

    public bool ListAnimals(string? searchSpecies = null, string? searchOtherData = null, int? searchId = null)
    {
        PropertyInfo[] properties = typeof(Animal).GetProperties();
        List<Animal> targets = new List<Animal>();

        if (!string.IsNullOrEmpty(searchSpecies))
        {
            targets = ourAnimals.Where(e => e.Species == searchSpecies).ToList();
        }
        else if (!string.IsNullOrEmpty(searchOtherData))
        {
            bool IsValid(string? str)
            {
                return !string.IsNullOrEmpty(str) && str.Contains(searchOtherData, StringComparison.OrdinalIgnoreCase);
            }

            targets = ourAnimals.Where(e => IsValid(e.Characteristics) || IsValid(e.Personality)).ToList();

            if (targets.Count > 0)
            {
                Console.Write($"\n============================ SEARCH RESULTS: {targets.Count} ============================\n");
            }
        }
        else if (searchId != null)
        {
            targets = ourAnimals.Where(e => e.Id == searchId).ToList();
        }
        else
        {
            targets = ourAnimals;
        }

        if (searchOtherData is null && targets.Count > 1)
        {
            Console.Write($"\n============================ ALL {(!string.IsNullOrEmpty(searchSpecies) ? (searchSpecies + "s").ToUpper() : "ANIMALS")} ============================\n");
        }

        foreach (Animal animal in targets)
        {
            Console.Write("\n");
            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine($"{property.Name,-20}{property.GetValue(animal)}");
            }
        }

        return targets.Count > 0;
    }

    public void AddNewAnimal()
    {
        Console.Write("\n");

        string? species;
        do
        {
            Console.Write($"{string.Join(" or ", acceptedSpecies)[..1].ToUpper()}{string.Join(" or ", acceptedSpecies)[1..]}\t");
            species = Console.ReadLine();
        } while (string.IsNullOrEmpty(species) || !acceptedSpecies.Contains(species.ToLower()));

        string? nickname;
        do
        {
            Console.Write("Nickname?\t");
            nickname = Console.ReadLine();

        } while (string.IsNullOrEmpty(nickname) || nickname.Length < 2);

        nickname = $"{nickname[..1].ToUpper()}{nickname[1..]}";

        string? age;
        bool isValid = false;
        do
        {
            Console.Write($"Age? (Press 'Enter' to complete later).\t");
            age = Console.ReadLine();

            if (!string.IsNullOrEmpty(age))
            {
                if (int.TryParse(age, out int output) && output < 20)
                {
                    isValid = true;
                }
            }
            else
            {
                isValid = true;
            }

        } while (!isValid);

        string? characteristics;

        Console.Write("Characteristics? (This can be completed later).\t");
        characteristics = Console.ReadLine();

        string? personality;

        Console.Write("Personality? (This can be completed later).\t");
        personality = Console.ReadLine();

        try
        {
            Animal newAnimal = new Animal(idCounter++, species.ToLower(), age, characteristics, personality, nickname);
            ourAnimals.Add(newAnimal);
            Console.WriteLine($"\n{nickname} has been successfully added to the database.\n");

            Console.Write($"\n============================ NEW ENTRY ============================\n");
            ListAnimals(searchId: newAnimal.Id);
        }
        catch
        {
            throw new Exception("An error occurred, please try again.");
        }
    }

    public void EditAnimal()
    {
        ListAnimals();

        string? input;
        do
        {
            Console.Write("\nWhich animal would you like to edit (id)?\t");
            input = Console.ReadLine();

            bool isValid = int.TryParse(input, out int output);
            if (!isValid)
            {
                input = null;
                continue;
            }

            Animal? target = ourAnimals.Select(e => e).Where(e => e.Id == output).FirstOrDefault();

            if (target is null)
            {
                input = null;
                continue;
            }

            Console.Write($"\n============================ EDIT START ============================\n");
            ListAnimals(searchId: target?.Id);

            bool propertyExists = false;
            PropertyInfo[] properties = typeof(Animal).GetProperties();
            PropertyInfo? selection = null;

            do
            {
                Console.Write("\nWhich property?\t");
                input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input))
                {
                    if (input.Equals("id", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("You cannot change this property.");
                    }
                    else if (input.Equals("age", StringComparison.OrdinalIgnoreCase))
                    {
                        if (!int.TryParse(input, out int age))
                        {
                            Console.WriteLine("Please enter a number.");
                        }
                    }
                    else
                    {
                        foreach (PropertyInfo property in properties)
                        {
                            if (property.Name.Equals(input, StringComparison.OrdinalIgnoreCase))
                            {
                                selection = property;
                                propertyExists = true;
                                break;
                            }
                        }
                    }
                }
            }
            while (string.IsNullOrEmpty(input) || !propertyExists);

            var newData = string.Empty;

            do
            {
                if (selection?.Name == "Species")
                {
                    do
                    {
                        Console.Write($"\nYou can only select between: {string.Join(", ", acceptedSpecies)} \t");
                        newData = Console.ReadLine();
                    } while (string.IsNullOrEmpty(newData) || !acceptedSpecies.Contains(newData.ToLower()));
                }
                else
                {
                    Console.Write("\nEnter new information:\t");
                    newData = Console.ReadLine();
                }

                if (!string.IsNullOrEmpty(newData))
                {
                    if (selection?.PropertyType == typeof(int?))
                    {
                        selection?.SetValue(target, int.Parse(newData));
                    }
                    else
                    {
                        selection?.SetValue(target, $"{newData[..1].ToUpper()}{newData[1..]}");
                    }
                }
            }
            while (string.IsNullOrEmpty(input));

            Console.Write($"\n============================ EDIT END ============================\n");
            ListAnimals(searchId: target?.Id);
        }
        while (string.IsNullOrEmpty(input));
    }

    public void SearchAnimal()
    {
        Console.Write("\nPlease enter a keyword:\t");
        string? input;
        bool IsFound;

        do
        {
            input = Console.ReadLine();
            IsFound = ListAnimals(searchOtherData: input);

            if (!IsFound)
            {
                Console.Write("\nThe keyword entered was not found. Try again:\t");
            }
        }
        while (string.IsNullOrEmpty(input) || !IsFound);

    }

    public void ContosoPets()
    {
        string? input;

        ourAnimals = new List<Animal>
        {
            new Animal(idCounter++, "dog", "4", "Golden retriever, long golden fur, enjoys swimming", "Friendly, devoted, intelligent", "Buddy"),
            new Animal(idCounter++, "dog", "2", "Beagle, tricolor coat, excellent sense of smell", "Curious, loving, determined", "Hunter"),
            new Animal(idCounter++, "cat", "3", "Siamese, cream coat with dark brown points, blue almond - shaped eyes", "Vocal, social, intelligent", "Mocha"),
            new Animal(idCounter++, "cat", "1", "Maine Coon, large size, tufted ears, bushy tail", "Gentle, playful, friendly", "Leo"),
        };

        ShowCommands();

        do
        {
            Console.WriteLine("\nEnter desired command:");
            input = Console.ReadLine();

            switch (input)
            {
                case "all": ListAnimals(); break;
                case "dogs": ListAnimals("dog"); break;
                case "cats": ListAnimals("cat"); break;
                case "add": AddNewAnimal(); break;
                case "edit": EditAnimal(); break;
                case "search": SearchAnimal(); break;
                case "commands": ShowCommands(); break;
                case "clear": Console.Clear(); break;
                case "quit": Environment.Exit(0); break;
                default: Console.WriteLine("\nSorry, this command is not available. Please try again."); break;
            }

        } while (!string.IsNullOrEmpty(input));
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
        //RolePlayingGame();
        //IntegerInput();
        //StringInput();
        //StringArray();
        var instance = new Program();
        instance.ContosoPets();
    }
}
