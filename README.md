# Foundational C# certification

Source: [Microsoft Learn](https://learn.microsoft.com/en-gb/training/)

Resource: [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/api/system)

## Table of contents

<!--TOC-->
  - [## First C# c](#-first-c-c)
    - [don't like errors](#dont-like-errors)
<!--/TOC-->

## First C# code

### Introduction

C# is a case-sensitive language.

`console` is different from `Console`.

Interpreting error messages is key:

```c#
console.WriteLine("hello world");
```
```terminal
(1,1): error CS0103: The name 'console' does not exist in the current context
```

C# is a compiled language.

Computers can't understand it directly.

As a result, a compiler translates its syntax at build time into Intermediate Language (IL).

This Intermediate Language is then translated at run time into machine code.

Compilers don't like errors and act as a safeguard.

If the code contains errors, compilation fails.

```mermaid
graph LR

1["Higher-level language (human)"] ---|Compilation| 2["Intermediate language"]
2 ---|Runtime| 3["Lower-level language (machine)"]
```

```mermaid
graph LR

1[C#] ---|Compiler| 2[Microsoft Intermediate Language, MSIL] --- |Runtime| Binary
```

| Term | Definition | Example |
| --- | --- | --- |
| class | A class is an object, having methods live within it. | `Console` |
| accessor | Methods living within objects can be accessed this way. | `.` |
| method | Each method has one job; they are invoked using parenthesis. | `WriteLine()` |
| literal string | Data is output literally. | `"hello world"` |

#### Challenge 1: Printing on console

```c#
Console.WriteLine("This is the first line.");
Console.Write("This is the second line.");
Console.Write("This is the third line.");
```
```terminal
This is the first line.
This is the second line.This is the third line.
```

### Variables

#### Data types

C# is a strongly-typed language.

Designers believed strict type declaration helped to avoid common bugs.

| Data type | Use case | Example |
| --- | --- | --- |
| string | Presentation or text manipulation. | `string myString = "Hello";` |
| char | Presentation or text manipulation. | `char myChar = 'A';` |
| int | Calculation. | `int myInt = 10;` |
| float | Calculation (6-9 digits). | `float mySmallNumber = 3.14f;` |
| double | Calculation (15-17 digits; default in C#, no literal suffix needed). | `double myMediumNumber = 3.14;` |
| decimal | Calculation (28-29 digits). | `decimal myLargeNumber = 3.14m;` |
| bool | Evaluation. | `bool myBool = true;` |

Variables types are checked at compile time.

Operations on a variable need to be compatible with its type.

#### Implicitly typed variables

The `var` keyword tells the compiler that data type is implied.

```c#
var message = "hello world";
```

You can use `var` when the data type is not known.

However, it's best practice to always type your variables explicitly.

`/!\` C# always attributes a data type to a variable, even if implicit.

#### Challenge 2: Typed variables

```c#
string userName = "Bob";
int messageNumber = 3;
float temperature = 34.4f;

Console.WriteLine($"Hello, {userName}!");
Console.Write($"You have {messageNumber} messages in your inbox. The temperature is {temperature} celsius.");
```

```terminal
Hello, Bob!
You have 3 messages in your inbox. The temperature is 34.4 celsius.
```

### Character escape sequences

| Sequence | Description |
| --- | --- |
| `\n` | new line |
| `\t` | tab |
| `\"` | escape double-quotes |
| `\\` | escape back slashes |
| `@` | output verbatim (as is); keep whitespaces |

### String interpolation

```c#
string one = "hello";
string two = "world";
Console.Write($"{one} {two}");
```

```terminal
hello world
```

```c#
string projectName = "helloWorld";
Console.Write($@"C:\Output\{projectName}\Data");
```

```terminal
C:\Output\helloWorld\Data
```

#### Challenge 3: String interpolation

```c#
string englishMessage = "View English output:";
string projectName = "ACME";
string englishProjectLocation = $@"c:\Exercise\{projectName}\data.txt";

Console.WriteLine($"{englishMessage}\n\t{englishProjectLocation}\n");

string russianMessage = "\u041f\u043e\u0441\u043c\u043e\u0442\u0440\u0435\u0442\u044c \u0440\u0443\u0441\u0441\u043a\u0438\u0439 \u0432\u044b\u0432\u043e\u0434";
string russianProjectLocation = $@"c:\Exercise\{projectName}\ru-RU\data.txt";

Console.WriteLine($"{russianMessage}\n\t{russianProjectLocation}\n");
```

```terminal
View English output:
	c:\Exercise\ACME\data.txt

Посмотреть русский вывод
	c:\Exercise\ACME\ru-RU\data.txt
```

### Type casting

Make a variable **pretend** to be a different type (within a sort of computed calculation):

```c#
int a = 10;
int b = 4;
double c = a / (double) b;
```

#### Challenge 4: Operations

```c#
int fahrenheit = 94;
float celsius = (fahrenheit - 32) * (5/9f);
Console.Write($"The temperature is {Math.Round(celsius, 1)} Celsius.");
```

```terminal
The temperature is 34.4 Celsius.
```

## Project 1 : Average calculator

### Console application

A `console` application is the simplest form of a C# program.

It takes input and displays output at the console only.

```c#
public class AverageCalculator
{   
    // Properties.
    public float? Average { get; private set; }
    public string? LetterGrade { get; }

    // Constructor.
    public AverageCalculator(int[] grades) 
    { 
        Average = (float) grades.Sum() / grades.Length;

        if (Average >= 97 && Average <= 100)
        {
            LetterGrade = "A+";
        }
        else if (Average >= 93 && Average <= 96)
        {
            LetterGrade = "A";
        }
        else if (Average >= 90 && Average <= 92)
        {
            LetterGrade = "A-";
        }
        else if (Average >= 87 && Average <= 89)
        {
            LetterGrade = "B+";
        }
        else if (Average >= 83 && Average <= 86)
        {
            LetterGrade = "B";
        }
    }

    // Execution.
    public static void Main(string[] args)
    {
        // Grades to convert.
        List<(string, int[])> grades = new List<(string, int[])>()
        {
            ("Sophia", new int[] { 93, 87, 98, 95, 100 }),
            ("Nicolas", new int[] { 80, 83, 82, 88, 85 }),
            ("Zahirah", new int[] { 84, 96, 73, 85, 79 }),
            ("Jeong", new int[] { 90, 92, 98, 100, 97 })
        };

        Console.WriteLine($"Student\t\tAverage\t\tGrade\n");

        foreach (var grade in grades)
        {
            var result = new AverageCalculator(grade.Item2);
            Console.WriteLine($"{grade.Item1}\t\t{result.Average}\t\t{result.LetterGrade}");
        }
    }
}
```

```terminal
Student         Average         Grade

Sophia          94,6            A
Nicolas         83,6            B
Zahirah         83,4            B
Jeong           95,4            A
```

## Project 2 : GPA calculator

```c#
public class GpaCalculator
{   
    // Properties.
    public float? Gpa { get; private set; }

    // Constructor.
    public GpaCalculator(List<(string, Course)> input)
    {
        var credits = input.Select(e => e.Item2.Credit).ToArray();
        var grades = input.Select(e => e.Item2.Grade).ToArray();

        int[] results = new int[credits.Length];

        for (int i = 0; i < results.Length; i++)
        {
            results[i] = credits[i] * grades[i];
        }

        Gpa = results.Sum() / (float) credits.Sum();
    }

    // Support class.
    public class Course
    {
        public int Credit { get; private set; }
        public int Grade { get; private set; }

        public Course(int credit, int grade)
        {
            Credit = credit;
            Grade = grade;
        }
    }

    // Execution.
    public static void Main(string[] args)
    {
        // Grades to convert.
        List<(string, Course)> finalGrades = new List<(string, Course)>
        {
            ("English 101", new Course(4, 3)),
            ("Algebra 101", new Course(3, 3)),
            ("Biology 101", new Course(3, 4)),
            ("Computer Science 101", new Course(3, 4)),
            ("Pyschology 101", new Course(4, 3))
        };

        float? result = new GpaCalculator(finalGrades).Gpa;
        Console.WriteLine($"{result:F2}");
    }
}
```

```terminal
3,35
```

## Simple console applications

An `IDE` (integrated development environment) is the developer's work toolkit.

It supports the development process or `lifecycle` at the coding level: 

```mermaid
graph LR

subgraph Implementation
direction LR
0[Test writing] --- 1[Code writing]
end

Maintenance --> Implementation
Implementation --> Versioning
Versioning --> Maintenance
```

Some IDEs support certain languages by default and others via extensions.

### Runtime

To run C# programs in an IDE, the .NET `runtime` is required.

A runtime is a layer between a program and the operating system of the computer.

It serves pre-built services, like a library, relieving the program from lower-level machine tasks like memory management, input/output (I/O) operations, etc.

The program can then focus its resources on higher-level logic.

A parallel can be drawn with APIs, which also serve pre-built code to programs, in this case routines or modules unrelated to execution.

```mermaid
graph LR

Program -->|Runtime| 1[Operating system]
Program -->|API| Library

```

### .NET

`.NET` is a Microsoft general-purpose framework.

```mermaid
graph LR

Create -->|Compile| Build
Build -->|Just-in-time| Run

```

### Create a console application (higher-level)

```terminal
dotnet new console -o ./CsharpProjects/TestProject

// dotnet: driver
// new console: command
// -o ./CsharpProjects/TestProject: arguments (-o stands for output)
```

This command creates two files: `.csproj` and `.cs`.

```xml
// .csproj: project config file.

<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>
```

```csharp
// .cs: code file (entry point of the application).

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
```

### Build a console application (intermediate level)

```terminal
dotnet build
```

Building is the process of compiling the project.

It creates a `bin` folder containing config and execution files the computer can process.

```json
// .deps.json: project build lock file.
// Tracks dependencies and their versions for build consistency.

{
  "runtimeTarget": {
    "name": ".NETCoreApp,Version=v8.0",
    "signature": ""
  },
  "compilationOptions": {},
  "targets": {
    ".NETCoreApp,Version=v8.0": {
      "TestProject/1.0.0": {
        "runtime": {
          "TestProject.dll": {}
        }
      }
    }
  },
  "libraries": {
    "TestProject/1.0.0": {
      "type": "project",
      "serviceable": false,
      "sha512": ""
    }
  }
}
```

``` terminal
// .exe: compiled output of the application in Intermediate Language (IL).
// It can be run by the OS.

"MZ   ÿÿ ¸ @ ð º ´	Í!¸LÍ!This program cannot be run in DOS mode.$ Nv’é
üº
üº
üº
üºüº–ø»üº–ÿ»üº–ù»\üºooºüºAoý»üº
ýºÃüºc–õ» üºc–þ»üºRich
üº PE d† he ð "" & j Ð    @        `Á      ,   € ´ @ ¼ p  0Ó T Õ ( ðÑ @ €  .text œi  j  `.rdata æ• € – n @ @.data P 
...
```

```terminal
// .dll: library for the application in Intermediate Language (IL). 
// Contains reference classes and methods.
// Linked to the .exe, it can't be run by the OS.

MZ   ÿÿ ¸ @ € º ´	Í!¸LÍ!This program cannot be run in DOS mode.$ PE L -W¶ à " 
0   Z' @ @    €   `…      ' O @ ¸ `  ô% T   H .text `   `.rsrc ¸ @  
 @ @.reloc  `   @ B <' H   h Œ    2r p(
...
 <Main>$ 
 <Module> 
 System.Console 
 System.Runtime 
 WriteLine 
 ...
 TestProject H e l l o , W o r l d ! ²VóSzÒéNˆæØdÈö—'      °?_Õ
...                   
```

```terminal
// .pdb: Program Database file, essential for debugging the application.

BSJB         PDB v1.0       |   D   #Pdb    À   €   #~  @     #Strings    D     #US H  P   #GUID   ˜  Ä(  #Blob   f,{Ú:ÊI½Ÿü²kdKFÄûÕ  G  	                                          §       „                l  w  Ç  Ù  ) ; x Š  4(                    «('  «'  ƒ'  Å          Ð)ˆ¸B‡‹w…—¬øbQ?ÆÓS ÀO£¡VÌ‘ 8MŸì%«š5jìþµÐŒƒJ–ÚFb„»KØGM~n	\L®ÚËºjt
 C:Userssteven.jimenezsourcerepos2023-11-nov-csharp-fundamentalsCsharpProjectsTestProject
Program.cs
\
 &FUa À§ßl7662¥àN„%e¬’I9šË~(V
–Ê?¤ùobjDebugnet8.0TestProject.GlobalUsings.g.cs\
 &FU€˜€œ€¢€© óñ4éè%ãç&€õ‹ò½¢ÞQ?a œVô‹›a*¼..NETCoreApp,Version=v8.0.AssemblyAttributes.cs\
 &FU€˜€œ€¢€ú ÷¥Ùxœ†6%á9ÿ™á:P80ö¸Zˆö™ßƒ¬v´žTestProject.AssemblyInfo.cs\
```

```json
// .runtimeconfig.json: project runtime config file.
// Specifies the version of the .NET runtime to be used during execution.

{
  "runtimeOptions": {
    "tfm": "net8.0",
    "framework": {
      "name": "Microsoft.NETCore.App",
      "version": "8.0.0"
    },
    "configProperties": {
      "System.Runtime.Serialization.EnableUnsafeBinaryFormatterSerialization": false
    }
  }
}
```

### Run a console application (lower level)

```terminal
dotnet run

// This command builds and runs the application.
```

```
Hello C#!
```

### .NET Class Library

Following the computer science principle of `modularity`, C# offers libraries of functionality.

These are prewritten collections of code.

Collections are organized in classes, which contain invokable methods.

```csharp
System.Console.WriteLine("Hello World");

// System: namespace.
// Console: class.
// WriteLine(): method.
```

In C#, data types are actually classes made available via the .NET library, with built-in methods.

### Methods

#### Stateful vs stateless

`state` is "the collection of all values stored in memory at a specific moment in time".

Stateless or `static` methods are independent of values stored in memory.

Stateful or `instance` methods are dependent on values stored in memory.

Stateful methods use fields (variables) to track state.

```csharp
Random dice = new Random(); // Stateful method.
int roll = dice.Next(1, 7);
Console.WriteLine(roll); // Stateless method.
```

Classes can contain both stateless and stateful methods.

However, invoking stateful methods requires object `instantiation`.

#### Object instantiation

```csharp
Random dice = new Random();

// new: creates a new instance of the Random class.
```

Instantiation is related to memory (statefulness).

The `new` keyword stores the object in memory at a large enough address.

Whenever a stateful method is invoked without object instantiation, compilation fails:

```csharp
int result = Random.Next();
```

```terminal
(1,14): error CS0120: An object reference is required for the non-static field, method, or property 'Random.Next()'
```

#### Void vs non-void

`void` methods end "quietly".

Non-void methods return a value that can be stored in a variable.

```csharp
int roll = dice.Next(1, 7); // Return value stored in roll.
```

```csharp
public static string Reverse(string input) // Parameters.
{
    return new string(input.ToCharArray().Reverse().ToArray());
}

public static void Main(string[] args)
{
    string result = Reverse("Hello World"); // Arguments.
    Console.WriteLine(result);
}
```

```terminal
dlroW olleH
```

#### Signature vs overloaded

The `signature` of a method is the number and data types of the parameters it accepts as input.

A same method can be `overloaded` to hold several signatures (implementations).

This provides more granular control:

```csharp
Random dice = new Random();
Console.WriteLine(dice.Next()); // 662_251_688; a value up to 2_147_483_647.
Console.WriteLine(dice.Next(101)); // 66; a value up to 100.
Console.WriteLine(dice.Next(4, 11)); // 6; a value between 4 and 10.
```

#### Challenge 5: Method call

```csharp
public static void Main(string[] args)
{
    int firstValue = 500;
    int secondValue = 600;
    int largerValue = Math.Max(firstValue, secondValue);

    Console.WriteLine(largerValue);
}
```

### Decision logic

#### Code branching

```csharp
if (condition)
{
    // Code executed by runtime.
}

if (condition || condition && condition) // Compound condition.
{
    // Code executed by runtime.
}
```

```csharp
if (condition)
{
    if (condition || condition && condition) // Nested compound condition.
    {
        // Code executed by runtime.
    }
}
```

```csharp
if (condition)
{
    // Code.
}
else if (condition) // Improved branching options.
{
    // Code.
}
else if (condition)
{
    // Code.
}
else
{
    // Code.
}
```

#### Challenge 6: if-else block

```csharp
public static void Main(string[] args)
{
    Random random = new Random();
    int daysUntilExpiration = random.Next(12);
    int discountPercentage = 0;

    if (daysUntilExpiration == 0)
    {
        Console.WriteLine("Your subscription has expired.");
    }
    else if (daysUntilExpiration == 1)
    {
        Console.WriteLine("Your subscription expires within a day!");
        discountPercentage = 20;
    }
    else if (daysUntilExpiration <= 5)
    {
        Console.WriteLine($"Your subscription expires in {daysUntilExpiration} days.");
        discountPercentage = 10;
    }
    else if (daysUntilExpiration <= 10)
    {
        Console.WriteLine("Your subscription will expire soon. Renew now!");
    }

    if (discountPercentage > 0)
    {
        Console.WriteLine($"Renew now and save {discountPercentage}%!");
    }
}
```

### Arrays

A single variable that can hold many related values.

It uses a zero-based index to access elements.

```csharp
string[] array = new string[3]; // New array declaration (address in memory).

array[0] = "hello"; // Value assignment.
array[1] = "world";
array[2] = "hello";

Console.WriteLine($"First: {array[0]}"); // Value retrieval.

array[0] = "haha"; // Value reassignment.

string[] array = { "hello", "world", "hello" }; // Assignment at declaration.

array.Length; // 3
```

#### Iteration using foreach

```csharp
int[] inventory = { 200, 450, 700, 175, 250 };
int sum = 0;
foreach (int entry in inventory)
{
    sum += entry;
}
Console.Write(sum); // 1775
```

```csharp
int[] inventory = { 200, 450, 700, 175, 250 };
int sum = 0;
int bin = 0;
foreach (int entry in inventory)
{
    sum += entry;
    bin++;
    Console.WriteLine($"Bin {bin} = {entry} items (Running total: {sum})");
}
Console.WriteLine($"We have {sum} items in inventory.");
```

```terminal
Bin 1 = 200 items (Running total: 200)
Bin 2 = 450 items (Running total: 650)
Bin 3 = 700 items (Running total: 1350)
Bin 4 = 175 items (Running total: 1525)
Bin 5 = 250 items (Running total: 1775)
We have 1775 items in inventory.
```

#### Challenge 7: foreach  loop

```csharp
string[] array = { "B123", "C234", "A345", "C15", "B177", "G3003", "C235", "B179" };
foreach (string entry in array)
{
    if (entry.StartsWith("B"))
    {
        Console.WriteLine(entry);
    }
}
```

### Naming conventions

[C# conventions reference](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/identifier-names)

```csharp
string myString // camelCase; no need to include the data type in the name (strMyString).
bool processComplete // Descriptive (kind of data the variable will hold).
int orderAmount // Avoid contractions like int ordAmt.
```

### Commenting

Three main uses: adding notes, temporarily removing code for testing purposes, and identifying tasks ("TODO").

```csharp
// Typical comment.

// int myNumber = 0;

// Comment three or more lines.

/*
string firstName = "Bob";
int widgetsPurchased = 7;
Console.WriteLine($"{firstName} purchased {widgetsPurchased} widgets.");
*/
```

Commenting should be reserved for high-level concepts, not operational descriptions of a code snippet.

```csharp
// Example of low-quality comments.
// Difficult to read.

Random random = new Random();
string[] orderIDs = new string[5];
// Loop through each blank orderID
for (int i = 0; i < orderIDs.Length; i++)
{
    // Get a random value that equates to ASCII letters A through E
    int prefixValue = random.Next(65, 70);
    // Convert the random value into a char, then a string
    string prefix = Convert.ToChar(prefixValue).ToString();
    // Create a random number, pad with zeroes
    string suffix = random.Next(1, 1000).ToString("000");
    // Combine the prefix and suffix together, then assign to current OrderID
    orderIDs[i] = prefix + suffix;
}
// Print out each orderID
foreach (var orderID in orderIDs)
{
    Console.WriteLine(orderID);
}
```

```csharp
// Example of high-level comment.

/*
  The following code creates five random OrderIDs
  to test the fraud detection process. OrderIDs 
  consist of a letter from A to E, and a three
  digit number. Ex. A123.
*/

Random random = new Random();
string[] orderIDs = new string[5];

for (int i = 0; i < orderIDs.Length; i++)
{
    int prefixValue = random.Next(65, 70);
    string prefix = Convert.ToChar(prefixValue).ToString();
    string suffix = random.Next(1, 1000).ToString("000");

    orderIDs[i] = prefix + suffix;
}

foreach (var orderID in orderIDs)
{
    Console.WriteLine(orderID);
}
```

Comments are subjective; the most important thing is to write clear and easy to read code.

Never trust comments as they could be outdated.

### Whitespacing

Also subjective; the most important thing is code clarity.

Finding a style and sticking to it.

```csharp
// Whitespace example.

Random dice = new Random(); // Space after a class declaration.

int roll1 = dice.Next(1, 7); // Variable grouping.
int roll2 = dice.Next(1, 7);
int roll3 = dice.Next(1, 7);

int total = roll1 + roll2 + roll3; // Different variable.
Console.WriteLine($"Dice roll: {roll1} + {roll2} + {roll3} = {total}");

if ((roll1 == roll2) || (roll2 == roll3) || (roll1 == roll3)) // if-else block.
{
    if ((roll1 == roll2) && (roll2 == roll3)) 
    {
        Console.WriteLine("You rolled triples!  +6 bonus to total!");
        total += 6; 
    } 
    else 
    {
        Console.WriteLine("You rolled doubles!  +2 bonus to total!");
        total += 2;
    }
}
```

#### Challenge 8: Code readability

```csharp
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

public static void Main()
{
    GetNumberOfTimesALetterAppearsInText("The quick brown fox jumps over the lazy dog.", 'o');
    GetNumberOfTimesALetterAppearsInText("Hello World", 'l');
}
```

```terminal
The quick brown fox jumps over the lazy dog.
'o' appears 4 times.
Hello World
'l' appears 3 times.
```

## Project 3: Student grade calculator

```csharp
public class Program
{
    private class Student
    {
        public string Name { get; set; }
        public int[] Grades { get; set; }
        public decimal ExamResult { get; set; }
        public decimal OverallResult { get; set; }
        public decimal ExtraCredit { get; set; }
        public string LetterGrade { get; set; }

        public Student(string name, int[] grades)
        {
            Name = name;
            Grades = grades;
            ExamResult = 0;
            OverallResult = 0;
            LetterGrade = string.Empty;
        }
    }

    public static string GetLetterGrade(decimal roundedResult)
    {
        string output = string.Empty;
        List<(string, int, int)> gradesReference = new List<(string, int, int)>()
        {
            ("A",93,96),
            ("A-",90,92),
            ("A+",97,100),
            ("B",83,86),
            ("B-",80,82),
            ("B+",87,89),
            ("C",73,76),
            ("C-",70,72),
            ("C+",77,79),
            ("D",63,66),
            ("D-",60,62),
            ("D+",67,69),
            ("F",0,59)
        };

        foreach (var entry in gradesReference)
        {
            if (roundedResult >= entry.Item2 && roundedResult <= entry.Item3)
            {
                output = entry.Item1;
            }
        }

        return output;
    }

    public static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student("Sophia", new int[] { 90, 86, 87, 98, 100, 94, 90 }),
            new Student("Andrew", new int[] { 92, 89, 81, 96, 90, 89 }),
            new Student("Emma", new int[] { 90, 85, 87, 98, 68, 89, 89, 89 }),
            new Student("Logan", new int[] { 90, 95, 87, 88, 96, 96 })
        };

        Console.WriteLine("Student\t\tExam Score\tOverall\tGrade\tExtra Credit\n");

        int exams = 5;

        foreach (Student student in students)
        {
            int assignments = 0;
            int credits = 0;

            foreach (int grade in student.Grades)
            {
                assignments++;

                if (assignments <= exams)
                {
                    student.ExamResult += grade;
                }
                else
                {
                    student.ExtraCredit += grade;
                    credits++;
                }
            }
            
            student.ExamResult /= exams;
            decimal delta = (student.ExtraCredit / 10) / exams;
            
            student.OverallResult = student.ExamResult + delta;
            student.ExtraCredit /= credits;

            decimal roundedResult = Math.Round(student.OverallResult, 0);
            student.LetterGrade = GetLetterGrade(roundedResult);

            Console.WriteLine($"{student.Name}:\t\t{student.ExamResult:f1}\t\t{student.OverallResult:f2}\t{student.LetterGrade}\t{student.ExtraCredit} ({delta:f2}pts)");
        }

        Console.WriteLine();
        Console.WriteLine("Press the Enter key to continue");
        Console.ReadLine();
    }
}
```

```terminal
Student         Exam Score      Overall Grade   Extra Credit

Sophia:         92,2            95,88   A       92 (3,68pts)
Andrew:         89,6            91,38   A-      89 (1,78pts)
Emma:           85,6            90,94   A-      89 (5,34pts)
Logan:          91,2            93,12   A       96 (1,92pts)

Press the Enter key to continue
```

## Console application logic

### Variable scope

"Portion of an application where a variable is accessible".

A `code block` holds statements defining an execution path, usually within curly brackets `{}`.

A variable within the code block is only accessible there.

```csharp
bool flag = true;
if (flag)
{
    int value = 10;
    Console.WriteLine($"Inside the code block: {value}");
}
```

```terminal
Inside the code block: 10
```

```csharp
bool flag = true;
if (flag)
{
    int value = 10;
}
Console.WriteLine($"Inside the code block: {value}");
```

```terminal
Program.cs(7,46): error CS0103: The name 'value' does not exist in the current context
```

```csharp
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
```

```terminal
Inside the code block: 0
Outside the code block: 10
```

### Less is more

Apply this approach only when it improves readibility; readibility is king.

Curly brackets `{}` can serve as a visual cue.

```csharp
bool flag = true;
if (flag)
{
    Console.WriteLine(flag);
}

if (flag)
    Console.WriteLine(flag);
        
if (flag) Console.WriteLine(flag);
```

```csharp
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
```

### Challenge 9: Problematic code

```csharp
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
```

```terminal
Set contains 42
Total: 108
```

### Booleans

True or false decision logic (pathways the code takes in a program).

#### Expression vs statement

"An `expression` is any combination of values (literal or variable), operators and methods that return a single value".

"A `statement` is a complete instruction in C#, composed of one or more expressions".

```csharp
if (input == "hello")

// if: statement.
// (input == "hello"): expression.
```

#### Evaluation operators

| Operator | Description |
| --- | --- |
| `>` | greater than |
| `<` | less than |
| `>=` | greater than or equal to |
| `<=` | less than or equal to |
| `==` | equal to |
| `!=` | not equal to |

Some built-in classes like `String` contain methods evaluating booleans: `Contains()`, `StartsWith()`, `EndsWith()`.

### Inequality operator vs logical negation

```csharp
x != y // Operands are not equal.
!(x == y) // Expression is not true.
```

### Conditional (ternary) operator

"[R]eturn a value that's based on a binary condition".

```csharp
<evaluate this condition> ? <if condition is true, return this value> : <if condition is false, return this value>
```

```csharp
int saleAmount = 1001;
int discount = saleAmount > 1000 ? 100 : 50;
Console.WriteLine($"Discount: {discount}");
```

```csharp
int saleAmount = 1001;
// int discount = saleAmount > 1000 ? 100 : 50;

Console.WriteLine($"Discount: {(saleAmount > 1000 ? 100 : 50)}"); // Inline.
```

#### Challenge 10: Ternary

```csharp
Random random = new Random();
int result = random.Next(0, 2);
Console.WriteLine(result == 0 ? "heads" : "tails");
```

### Challenge 11: Decision logic

```csharp
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

public static void Main()
{
    Console.WriteLine($"User permission\t\tUser level\t\tMessage\n");
    for (int i = 0; i < 10; i++)
    {
        Random permission = new Random();
        string permissionString = (permission.Next(0, 3) == 0 ? "Admin" : permission.Next(0, 3) == 1 ? "Manager" : "Other");

        Random level = new Random();

        User user = new User(permissionString, level.Next(0, 101));
        Console.Write($"{user.Permission}\t\t\t{user.Level}\t\t\t");
        GetAccess(user);
    }
}
```

```terminal
User permission         User level              Message

Admin                   90                      Welcome, Super Admin user.
Other                   97                      You do not have sufficient privileges.
Admin                   53                      Welcome, Admin user.
Other                   58                      You do not have sufficient privileges.
Admin                   98                      Welcome, Super Admin user.
Manager                 51                      Contact an Admin for access.
Manager                 1                       You do not have sufficient privileges.
Other                   60                      You do not have sufficient privileges.
Other                   10                      You do not have sufficient privileges.
Manager                 51                      Contact an Admin for access.
```

### Switch

An alternative to `if-else` branching logic.

A value (switch expression) is evaluated against a list of possible outcomes (case patterns), from top to bottom.

Case patterns are boolean expressions.

A switch is best suited for simple evaluation against simple cases (two lines of code at most).

```csharp

```

# Exercism

## Basics

C# is a statically-typed language:

```c#
int explicitVar = 10; // Explicitly typed
var implicitVar = 10; // Implicitly typed
```

And an object-oriented language where functions are defined in classes.

Classes need to be instantiated using `new`:

```C#
class Calculator
{
    // ...
}

var calculator = new Calculator();
```

Classes group methods, whose parameters and return values need to be explicitly typed.

`public` allows a method to be called by code in other files.

```c#
class Calculator
{
    public int Add(int x, int y)
    {
        return x + y;
    }
}
```

Comments can be single line `//` or multiline `/* */`.

## Booleans

Type `bool`.

Operators `!` (NOT), `&&` (AND), and `||` (OR).

## Strings

### Substring

```c#
public static string Message(string logLine)
    {
        int first = logLine.IndexOf(":") + ":".Length;
        int last = logLine.Length;
        return logLine.Substring(first, last - first).Trim();
    }
```

```terminal
LogLine.Message("[ERROR]: Invalid operation")
// => "Invalid operation"
```

### Regex

```c#
public static string LogLevel(string logLine)
    {
        Regex rx = new Regex("\\[(.*)\\]");
        MatchCollection matches = rx.Matches(logLine);
        return matches[0].Groups[1].Value.ToLower();
    }
```

```terminal
// "[ERROR]: Disk full"
error
```

## Numbers

Digit separator:

```c#
int largeInt = 1_000_000;
// => 1000000

double largeDouble = 9_876_543.21;
// => 9876543.21
```

## Extended methods

```c#
// TODO: define the 'SubstringAfter()' extension method on the `string` type
    public static string SubstringAfter(this string str, string input) {
        return str.Split(input)[1];
    }
    // TODO: define the 'SubstringBetween()' extension method on the `string` type
    
    public static string SubstringBetween(this string str, string input1, string input2) {
        return str.Split(input1)[1].Split(input2)[0];
    }
    
    // TODO: define the 'Message()' extension method on the `string` type
    public static string Message(this string str) {
        return str.SubstringAfter("]:").Trim();
    }
    // TODO: define the 'LogLevel()' extension method on the `string` type
    public static string LogLevel(this string str) {
        return str.SubstringBetween("[", "]");
    }
```

```c#
public static class Bob
{
    // Check if string is uppercase
    private static bool IsUpperCase(this string statement) =>
        statement.Any(char.IsLetter) &&
        statement.All(e => !char.IsLetter(e) || char.IsUpper(e));

    // Check if string ends with ?
    private static bool IsQuestion(this string statement) => statement.Trim().EndsWith("?");
    
    public static string Response(string statement)
    {
        if (statement.IsQuestion() && statement.IsUpperCase()) {
            return "Calm down, I know what I'm doing!";
        }
    
        if (statement.IsQuestion()) {
            return "Sure.";
        }
    
        if (statement.IsUpperCase()) {
            return "Whoa, chill out!";
        }
    
        if (string.IsNullOrWhiteSpace(statement)) {
            return "Fine. Be that way!";
        }
            
        return "Whatever.";
    }
}
```

## Tuples

```c#
string boast = "All you need to know";
bool success = !string.IsNullOrWhiteSpace(boast);
(bool, int, string) triple = (success, 42, boast);
```

```c#
// Change tuple field names

// Name items in declaration
(bool success, string message) results = (true, "well done!");
bool mySuccess = results.success;
string myMessage = results.message;

// Name items in creating expression
var results2 = (success: true, message: "well done!");
bool mySuccess2 = results2.success;
string myMessage2 = results2.message;
```

```c#
public static class PhoneNumber
{
    private static string IsSplit(this string phoneNumber, int index) {
        return phoneNumber.Split("-")[index];
    }
    
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        return ((phoneNumber.IsSplit(0) == "212"), phoneNumber.IsSplit(1) == "555", phoneNumber.IsSplit(2));
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo) => phoneNumberInfo.IsFake;
}
```

### Dictionary

```c#
public static class ScrabbleScore
{
    public static int Score(string input)
        {
            List<(string, int)> tuples = new()
            {
                ("aeioulnrst", 1),
                ("dg", 2),
                ("bcmp", 3),
                ("fhvwy", 4),
                ("k", 5),
                ("jx", 8),
                ("qz", 10)
            };

            Dictionary<char, int> dictionary = new();

            foreach (var tuple in tuples)
            {
                foreach (char c in tuple.Item1)
                {
                    dictionary[c] = tuple.Item2;
                }
            }

            int count = 0;

            char[] charArray = input.ToLower().ToArray();

            foreach (char c in charArray)
            {
                count += dictionary[c];
            }
        
        return count;
    }
}
```

## Nullability

```c#
public static string Print(int? id, string name, string? department)
    {
        
        if (!id.HasValue && string.IsNullOrEmpty(department)) {
            return $"{name} - OWNER";
        }
        
        if (!id.HasValue) {
            return $"{name} - {department.ToUpper()}"; 
        }

        if (string.IsNullOrEmpty(department)) {
            return $"[{id}] - {name} - OWNER";
        }
        
        return $"[{id}] - {name} - {department.ToUpper()}";
    }
```

## While

```c#
int x = 23;

while (x > 10)
{
    // Execute logic if x > 10
    x = x - 2;
}
```

### Do While
```c#
int x = 23;

// Execute at least once, then loop
do
{
    // Execute logic if x > 10
    x = x - 2;
} while (x > 10)
```

## Class

Primary C# object-oriented construct.

Combination of fields (data) and methods (behaviors): members.

Access to members (fields and methods) is restricted using access modifiers: 

| Access modifier | Description |
| --- | --- |
| public | No restrictions. |
| private | Access only by code in same class. |

```c#
Class Car
{

    // This is accessible by anyone.
    // Public fields use PascalCase (you can use camelCase).
    public int carWeight;

    // This is only accessible by code in the class.
    // Private fields use _camelCase.
    private string _carColor;

}

// Create an object of the Car class
var oneCar = new Car();
```

```c#
class CarImporter
{
    private int _carsImported;

    // Use void to calculate without a return statement.
    public void ImportCars(int numberOfCars)
    {
        _carsImported = _carsImported + numberOfCars;
    }
}
```

### Encapsulation

```c#
private int _distance;

public int Distance
{
    get
    {
        return _distance;
    }
    set
    {
        _distance = value;
    }
}
```

Encapsulation is a fundamental concept in object-oriented programming: **it allows to expose fields safely**.

You hide the internal state of an object and control how that state is modified.

In this case, the _distance field is private, which means it can't be accessed directly from outside the class. 

Instead, you provide a public property Distance that allows external code to get and set the value of _distance.

C# allows to simplify this set up by hidding private variables with this syntax:

```c#
// This private variable is now hidden.
// private int _distance;

public int Distance
{
    get;
    set;
}

// In a constructor, you can set it like this:
public RemoteControlCar(int distance, int batteryDrain)
{
    Distance = distance;
}

// The hidden private variable can be initialized like this:
public int Distance { get; set; } = 100;

// Properties can be restricted like this:
public int Distance { get; private set; } = 100;
```

## Collections

Collections are data structures holding zero or more elements.

Arrays are collections with a fixed type and given lenght.

They use indexes to retrieve information.

```c#
// Three equivalent ways to declare and initialize an array (size is 3)
int[] threeIntsV1 = new int[] { 4, 9, 7 };
int[] threeIntsV2 = new[] { 4, 9, 7 };
int[] threeIntsV3 = { 4, 9, 7 };
```

### For and foreach loop

```c#
for (int i = 0; i < 5; i++)
{
    System.Console.Write(i);
}

// => 01234
// You can define the initializer (i) and the iterator (i++, i--).

char[] vowels = new [] { 'a', 'e', 'i', 'o', 'u' };

foreach (char vowel in vowels)
{
    // Output the vowel
    System.Console.Write(vowel);
}

// => aeiou
// You can't define the initializer as it loops through each element.
```

### Lists

## Inheritance

|Term|Description|
|------|-----------|
|public| Can be accessed by outside code. |
|private| Cannot be accessed by outside code.|
|static| Can be invoked without creating an instance of the class.|
|virtual| Can be overriden in a subclass.|
|abstract class| Abstract (to implement) and non-abstract (implemented) method catalog.|
|interface| Completely abstract method catalog.|

```c#
// Inherits from the 'object' class
abstract class Vehicle
{
    // Can be overridden
    public virtual void Drive()
    {
    }

    // Must be overridden
    protected abstract int Speed();
}

class Car : Vehicle
{
    public override void Drive()
    {
        // Override virtual method

        // Call parent implementation
        base.Drive();
    }

    protected override int Speed()
    {
        // Implement abstract method
    }
}
```

Parent classes are always called first.

The protected keyword means parent methods can only be called by direct children.

```c#
abstract class Vehicle
{
    protected Vehicle(int wheels)
    {
        Console.WriteLine("Called first");
    }
}

class Car : Vehicle
{
    public Car() : base(4)
    {
        Console.WriteLine("Called second");
    }
}
```

### Polymorphism

```c#
// Classes derived from the same parent (Vehicle), will often implement the same base methods (GetDescription) differently.
// So, a same parent input can have different outputs (many forms).

abstract class Vehicle
{
   public abstract string GetDescription();
}

class Car : Vehicle
{
   public Car()
   {
   }

   public override string GetDescription()
   {
      return "Runabout";
   }
}

class Rig : Vehicle
{
   public Rig()
   {
   }

   public override string GetDescription()
   {
      return "Big Rig";
   }
}

Vehicle v1 = new Car();
Vehicle v2 = new Rig();

v1.GetDescription();
// => Runabout
v2.GetDescription();
// => Big Rig
```

## Collections

```c#
public static class Strain
{
    // Method Keep() can be used as an extension with keyword this: numbers.Keep().
    // It takes in a function as an argument: number.Keep(e => e > 2).
    // IEnumerable is an interface allowing to iterate over the input collection.
    // <T> means any type is considered.
    // predicate is a test run of the input function.
    
    // So, for each item of any type in the collection, if the result of the input function is true, then, include the item in the output collection.

    public static IEnumerable<T> Keep<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        foreach (T item in collection) {
            if (predicate(item)) {
                yield return item;
            }
        }
    }

    public static IEnumerable<T> Discard<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        foreach (T item in collection) {
            if (!predicate(item)) {
                yield return item;
            }
        }
    }
}
```

# Software craft

## Intro

Le software craft, c'est un ensemble d'attitudes, de réflexes pragmatiques.

C'est redéfinir ce qu'est un "bon" logiciel :

- Un logiciel qui marche, c'est le strict minimum : *le vrai enjeu du développement logiciel est de rester évolutif dans la durée, ajouter et modifier facilement des fonctionnalités existantes.*
- Un logiciel n'est jamais fini, à moins qu'il soit en fin de vie : le code doit donc être le plus plastique possible.
- Le code est plus lu qu'écrit : il faut donc privilégier une écriture simple.
- Les problèmes complexes ne peuvent tenir *en une seule tête* : il est important de poser des questions.

*Les compétences en software craft deviennent désirables voire requises en développement logiciel.*

## Historique

```mermaid
graph TB

0[Cycle développement en V] --> A[Pratiques inefficaces] --> 1[Méthodes agile]
1[Méthodes agile] -->|Production de code| Scrum
1[Méthodes agile] -->|Ingénierie de code| 2[XP, Extreme Programming]
Scrum --> 3[Agile hangover]
3[Agile hangover] --> Craft
2[XP, Extreme Programming] --> Craft

style A stroke:red;
style 3 stroke:red;

```

### V-model

Modèle de développement logiciel traditionnel devenu rigide vers la fin des années 1990.

Critiques principales :

- Cycle trop linéaire manquant des itérations.
- Ce qui le rend rigide face à des besoins de moins en moins précis.
- Les tests sont effectués trop tard dans le cycle.
- Ce qui fait que revenir en arrière devient compliqué.

```mermaid
graph LR

subgraph Définition
0[Analyse des besoins] --> 1[Design système] --> 2[Découpage]
end
Définition--> 3[Développement]
3[Développement] --> Intégration

subgraph Intégration
4[Tests unitaires] --> Déploiement --> Validation
end
```

### Méthode agile

Modèle en réaction à la rigidité du V-model, découpant le développement en sprints par feature.

Avantages :

- Feedback plus régulier, permettant d'ajuster.
- Livraison de features opérationnelles petit à petit.
- La livraison par feature permet d'identifier des problèmes en cours de développement et non à la fin.

```mermaid
graph TB

0[Product Owner] -->|Lists all features| Backlog
Backlog --> 1[Sprint planning]
1[Sprint planning] --> A[Sprint 1]

subgraph A[Sprint 1]

2[Daily stand-up] --> Review
Review --> Améliorations
end

3[Sprint N...]
A[Sprint 1] --> 3[Sprint N...]
```

### Scrum

*Scrum is one framework of the Agile philosophy.*

Dans Scrum, un Scrum master sert d'intermédiaire entre le PO et les développeurs.

Il assure également le bon déroulement des processus et des sprints.

Des outils spécifiques sont également mis en place : product backlog, sprint backlog, burndown charts (work to do vs time), etc.

### XP (Extreme programming)

XP est également une implémentation d'Agile, focalisée sur la qualité du code produit.

On y ajoute du pair programming, du test-driven development (TDD), de l'intégration continue (CI), des pratiques de refactorisation, etc.

### Agile hangover

L'arivée des méthodes Agile a permis de surmonter le problème de rigidité posé par les méthodes de développement traditionnelles (V-model). 

Scrum est devenu populaire et les équipes ont gagné en efficacité de production de code.

Cependant, cela a créé un autre problème : en l'absence de bonnes pratiques d'ingénierie de code, le code produit est devenu difficile à entretenir.

Robert C. Martin (uncle Bob) a relancé la mouvance XP pour rappeler l'importance des pratiques de code.

Le Craft est apparu comme une boîte à outils de techniques encourageant la production de code propre.

### Craft

```mermaid
graph LR

Craft --> TDD
TDD --> BDD
Craft --> 0[Clean Code]
Craft --> DDD
Craft --> 1[Legacy remediation]
Craft --> SOLID

```

## Test-driven development (TDD)

- Ecrire des tests avant ou en parallèle du code de production :
    - Fixer l'objectif du besoin.
    - Définir les comportements attendus.
    - Ecrire le moins de code possible pour satisfaire ces comportements attendus.

- Trois règles :
    1. Ecrire un test qui échoue avant tout écriture de code.
    2. Ne pas écrire plus de tests que nécessaire.
    3. N'écrire que le code suffisant à passer les tests.

- Chaque itération se décline en trois étapes : rouge (échec) -> green (succès) -> refacto

```mermaid
graph LR

Echec --> Succès --> Refacto
Refacto --> Echec

style Echec stroke:red
style Succès stroke:lightgreen
```

### Nommage

should/when

```terminal
Method_should_do_this_when_this
```

given/when/then
```terminal
Given_x_when_I_do_x_then_x_happens
```

```c#
Namespaces, classes, methods: PascalCase;
Public variables: camelCase;
Private variables: m_camelCase;
Test methods: MethodTested_Scenario_ExpectedOutcome
```

### Arrange Act Assert

Préparer Agir Vérifier

- Commencer par la vérification (assert).
- Puis écrire l'action (act).
- Puis initialiser les variables à tester (arrange).

### Exemple FizzBuzz

```terminal
Voir le TDD comme l'écriture d'un kata.
```

- Objectif :
    - Ecrire un programme qui permette, de 1 à 100, afficher :

```terminal
"Fizz" si multiple de 3,
"Buzz" si multiple de 5,
"FizzBuzz", si multiple de 3 et 5,
le nombre lui-même autrement.
```

- Exemples :
    - Aller du plus simple au plus complexe :

```terminal
Si n = 1, "1",
Si n = 3, "Fizz",
Si n = 5, "Buzz",
Si n = 15, "FizzBuzz".
```

```c#
namespace FizzBuzz
{
    public class Program
    {
        public static void Test()
        {
            Console.WriteLine("hello");
        }

        public static void Main()
        {
            Test();
        }
    }
}
```

```terminal
Right-click > Créer des tests unitaires
```

```c#
namespace FizzBuzzTests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void TestTest()
        {
            Assert.Fail();
        }
    }
}
```

### Red phase

```c#
namespace FizzBuzz
{
    public class Program
    {
        public string Print(int number)
        {
            throw new NotImplementedException();
        }

        public static void Main()
        {

        }
    }
}
```

```c#
namespace FizzBuzzTests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Should_return_same_number_when_not_multiple_of_three_or_five()
        {
            Program fizzBuzz = new();
            int number = 1;
            string value = fizzBuzz.Print(number);
            Assert.AreEqual("1", value);
        }
    }
}
```

```terminal
La méthode de test FizzBuzzTests.ProgramTests.Should_return_same_number_when_not_multiple_of_three_or_five a levé une exception : 
System.NotImplementedException: The method or operation is not implemented.
```

### Green phase

```c#
namespace FizzBuzz
{
    public class Program
    {
        public string Print(int number)
        {
            return number.ToString();
        }

        public static void Main()
        {

        }
    }
}
```

### Final code

```c#
public class Program
    {
        private bool IsMultipleOf(int number, int divider)
        {
            return number % divider == 0;
        }
        
        public string Print(int number)
        {

            string fizzBuzzValue = null;
            
            if (IsMultipleOf(number, 3))
            {
                fizzBuzzValue += "Fizz";
            }
            
            if (IsMultipleOf(number, 5))
            {
                fizzBuzzValue += "Buzz";
            }

            if (fizzBuzzValue != null)
            {
                return fizzBuzzValue;
            }
            
            return number.ToString();
        }

        public static void Main()
        {
            Program test = new Program();
            Random random = new Random();
            int number = random.Next(1, 101);
            string result = test.Print(number);
            Console.WriteLine($"{number} {result}");
        }
    }
```

```c#
[TestClass]
    public class ProgramTests
    {
        private Program fizzBuzz;
        private int number;
        private string value;
        
        [TestInitialize]
        public void TestArrange()
        {
            fizzBuzz = new Program();
        }
        
        [TestMethod]
        public void Should_return_same_number_when_not_multiple_of_three_or_five()
        {
            // Arrange
            number = 1;
            
            // Act
            value = fizzBuzz.Print(number);
            
            // Assert
            Assert.AreEqual("1", value);
        }

        [TestMethod]
        public void Should_return_fizz_when_multiple_of_three()
        {
            number = 3;
            value = fizzBuzz.Print(number);
            Assert.AreEqual("Fizz", value);
        }

        [TestMethod]
        public void Should_return_buzz_when_multiple_of_five()
        {
            number = 5;
            value = fizzBuzz.Print(number);
            Assert.AreEqual("Buzz", value);
        }

        [TestMethod]
        public void Should_return_fizzbuzz_when_multiple_of_three_and_five()
        {
            number = 15;
            value = fizzBuzz.Print(number);
            Assert.AreEqual("FizzBuzz", value);
        }
    }
```

[Troubleshooting](https://learn.microsoft.com/en-us/visualstudio/test/unit-test-basics?view=vs-2022)

# General knowledge

## Extract, Transform, Load (ETL)

Common approach in data handling and database management:

```mermaid
graph LR
subgraph Extract
direction LR
0[Connect to source DB] --> 1[Retrieve data]
end

subgraph Transform
direction LR
2[Apply formatting]
end

subgraph Load
direction LR
3[Connect to target DB] --> 4[Store data]
4[Store data]
end

Extract --> Transform --> Load
```

```mermaid
graph LR
subgraph Extractor
direction LR

subgraph Extract
direction LR
0[Source connector] --> Retriever
end

subgraph Transform
direction LR
Formatter
end

subgraph Load
direction LR
1[Destination connector] --> Writer
end

end

Extract --> Transform --> Load
```

## Git

| Command | Description |
| --- | --- |
| Add | New code or feature. |
| Update | Changes to existing. |
| Fix | Bug correction. |
| Remove | Deletion. |
| Refactor | Changes not affecting functionality. |
| Document | Comments or documentation. |
| Merge | Code combination. |
| Revert | Undo changes. |

## 32-bit (x86), 64-bit (x64) 

In a nutshell, 16 (1978) -> 32 (1985) -> 64-bit (2003).

32-bit `int`: range from -2,147,483,648 to 2,147,483,647.

64-bit `int`: range from -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807.

> The transition to 64-bit computing was indeed significant for handling complex data. The 64-bit architecture provides a larger address space, which means it can access more memory and handle larger data sets more efficiently. This is particularly beneficial for applications that require high-performance computing or are data-intensive, such as databases, scientific simulations, and video encoding. However, for many everyday applications, the difference between 32-bit and 64-bit might not be noticeable.

## Data and data accessing

| Term | Acronym | Description | Extension |
| --- | --- | --- | --- |
| Access | | MS-provided relational DB manager like mySQL for small, end-user oriented projects. | .mdb |
| OLEDB | Object Linking and Embedding Database | MS API for accessing data. | |

### OLEDB

```mermaid
---
title: Flow of data
---
graph TB
0[Visual Studio] -->|OleDbConnection| 1[OLEDB Provider]

subgraph 1[OLEDB Provider]
direction TB
4[SQL Server] --> SQLOLEDB
Access --> 6["Microsoft.Jet.OLEDB.4.0 (.mdb)"]
Access --> 7["Microsoft.ACE.OLEDB.12.0 (.accdb)"]
5["Excel/CSV"] --> 6["Microsoft.Jet.OLEDB.4.0 (.mdb)"]
5["Excel/CSV"] --> 7["Microsoft.ACE.OLEDB.12.0 (.accdb)"]
Oracle --> OracleOLEDB.Oracle
end

1 --> 2[OLEDB API]

2 --> 3[(DB)]
```

```mermaid
graph TB
OleDbConnection -->|"Provider=X;Data Source=Y"| 2["Connection.Open()"]

2 --> 3[OleDbCommand] -->|SQL queries| 4[(DB)]
```

## Exception handling

```c#
public static void Main()
{
    int[] arr = { 1, 2, 3, 4, 5 };
    Console.WriteLine(arr[5]); // Error here <- You get an error message.

    // Unhandled exception
    // System.IndexOutOfRangeException : 'Index was outside the bounds of the array.'
}
```

```c#
public static void Main()
{
    int[] arr = { 1, 2, 3, 4, 5 };
    Console.WriteLine(arr[5]); // Error <- The program will terminate here since no error handler.
    Console.WriteLine(arr[4]); // 5 <- This line will not be reached.
}
```

```c#
public static void Main()
{
    int[] arr = { 1, 2, 3, 4, 5 };

    try
    {
        // Potentially error-prone code.
        Console.WriteLine(arr[5]);
    }

    catch (Exception ex)
    {
        // Error handler.
        Console.WriteLine(ex.ToString());

        // System.IndexOutOfRangeException: Index was outside the bounds of the array.
        // at ConsoleApp1.Program.Main() in C:\Users\steven.jimenez\source\repos\ConsoleApp1\Program.cs:line 11

    }

    Console.WriteLine(arr[4]); // 5 <- This line will now be reached.
}
```

```c#
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());

    // System.IndexOutOfRangeException: Index was outside the bounds of the array.
    // at ConsoleApp1.Program.Main() in C:\Users\steven.jimenez\source\repos\ConsoleApp1\Program.cs:line 11

    Console.WriteLine(ex.GetType());

    // System.IndexOutOfRangeException

    Console.WriteLine(ex.Message);

    // Index was outside the bounds of the array.

    Console.WriteLine(ex.StackTrace);

    // at ConsoleApp1.Program.Main() in C:\Users\steven.jimenez\source\repos\ConsoleApp1\Program.cs:line 11
}
```

```c#
public static void Main()
{
    int[] arr = { 1, 2, 3, 4, 5 };

    try
    {
        // Potentially error-prone code.
        Console.WriteLine(arr[5]);
    }

    catch (Exception ex)
    {
        // Error handler.
        Console.WriteLine(ex.ToString());

    }
    finally
    {
        Console.WriteLine("Code always executed."); // This line will always be reached.
        // Usually used to close or clean up resources used in the try block
        // (files, connections, etc.).
    }

    Console.WriteLine(arr[4]); // This line will also be reached.
}
```

```c#
private static void CheckAge(int age)
{
    if (age < 18)
    {
        Console.WriteLine("Access denied"); // This way of signaling an error can't keep track of its trace.
        // For better debugging, declare an error condition.
    }
    else
    {
        Console.WriteLine("Adult.");
    }
}
        
public static void Main()
{
    CheckAge(15);
}
```

```c#
private static void CheckAge(int age)
{
    if (age < 18)
    {
        throw new Exception("Access denied"); // This will terminate the program, since there is no catch block.
    }
    else
    {
        Console.WriteLine("Adult.");
    }
}
        
public static void Main()
{
    CheckAge(15);
}
```

```c#
private static void CheckAge(int age)
{
    try
    {

        if (age < 18)
        {
            throw new Exception("Access denied.");
        }
        else
        {
            Console.WriteLine("Adult.");
        }

    }

    catch (Exception ex)
    {
        Console.WriteLine(ex.Message); // This will catch the error and log it (keeping a trace).
    }
}
        
public static void Main()
{
    CheckAge(15); // Access denied.
    CheckAge(21); // Adult. <- This line will now be reached.
}
```

### Understanding stack tracing

```c#
private static void MethodA()
{
    MethodB();
}
private static void MethodB()
{
    throw new Exception("Error here.");
}

public static void Main()
{
    try
    {
        MethodA();
    }
            
    catch (Exception ex)
    {
        Console.WriteLine(ex.StackTrace);
        // at ConsoleApp1.Program.MethodB() in C:\Users\steven.jimenez\source\repos\ConsoleApp1\Program.cs:line 11
        // at ConsoleApp1.Program.MethodA() in C:\Users\steven.jimenez\source\repos\ConsoleApp1\Program.cs:line 7
        // at ConsoleApp1.Program.Main() in C:\Users\steven.jimenez\source\repos\ConsoleApp1\Program.cs:line 18
    }
}
```

```c#

private static void MethodA()
{
    MethodB();
}
private static void MethodB()
{
    throw new Exception("Error here.");
}
private static void MethodC()
{
    Console.WriteLine("You reached me!");
}

public static void Main()
{
    try
    {
        MethodA();
    }

    catch (Exception ex)
    {
        Console.WriteLine(ex.Message); // Error here.
    }

    MethodC(); // You reached me!
}
```

### Three error handling strategies

```c#
// Catch and log.

try {
    // Your main program logic here
}
catch (Exception exception) {
    // Log the error details
    logError(exception.message, exception.stackTrace);
}
```

```c#
// Catch, recover and continue.

try {
    // Your main program logic here
}
catch (Exception exception) {
    // Attempt to recover from the error
    if (canRecover(exception)) {
        recover();
    } else {
        // If recovery is not possible, re-throw the exception
        throw;
    }
}
```

```c#
// Catch and wrap.

try {
    // Your main program logic here
}
catch (Exception exception) {
    // Throw a new, more specific or custom exception
    throw new DatabaseConnectionException("Connection error", exception);
}
```

```c#
// Logging method set up example.

void logError(string message, string stackTrace) {
    using (StreamWriter writer = new StreamWriter("log.txt", true)) {
        writer.WriteLine(DateTime.Now);
        writer.WriteLine(message);
        writer.WriteLine(stackTrace);
    }
}
```

## Multi-threading

A thread is like an instance of a computer processor.

Historically, computers ran programs using a single instance.

Applications were single-threaded: instructions had to queue and were run sequentially.

With time, multi-threads were introduced: multiple instances of the processor could now be created to run instructions concurrently.

This improved performance, but added complexity, especially in scenarios where data is shared between instructions.

``` mermaid
graph TB

subgraph multi-thread
direction TB

subgraph thread1
direction TB
4[instruction1] --> 5[instruction2]
end

subgraph thread2
direction TB
6[instruction3] --> 7[instruction4]
end
end

subgraph single-thread
direction TB
0[instruction1] --> 1[instruction2]
1 --> 2[instruction3]
2 --> 3[instruction4]
end
```

### Task

Within this context, Task is a multi-threading handler used mainly for I/O (input/output) operations:

- reading from the keyboard or a file
- writing to the screen or a file
- sending and receiving network packets

It creates a new thread were a given action is set to run asynchronously.

The action can be awaited if needed to ensure synchronicity.

```c#
public Task Dispose()
{
    Task.Run(() => File.Delete(FilePath));
}
```

### Parallel

## Namespaces

In C#, like in other languages, `namespaces` are containers that group similar classes, interfaces, functions and other code.

```mermaid
graph TB
Namespaces --> System --> 0[Fundamental classes]
Namespaces --> System.Collections.Generic --> 1[Advanced arrays]
1[Advanced arrays] --> List
1[Advanced arrays] --> Dictionary
1[Advanced arrays] --> HashSet --> A[When converting an array to a HashSet, duplicates are automatically removed]
1[Advanced arrays] --> Queue
1[Advanced arrays] --> Stack
Namespaces --> System.Linq --> 2[Library with useful methods]
Namespaces --> System.IO
Namespaces --> System.Net
Namespaces --> System.Threading

style A stroke:yellow
```

## Glossary

<!--| Term | Definition | Example |
| --- | --- | --- |
| compiler | *converts your code from a human higher-level language (C#) into an executable format that the computer can understand.* | x |
| precompilation | process before the main compilation process to help with performance | red squiggly lines underlining the code that will produce an error |
| programming language | *A programming language's job is to allow a human to express their intent [to a computer] in a human-readable and understandable way.* |
| syntax | rules for writing code | X |
----->

## Variables

| Category | Type | Example |
| --- | --- | --- |
| Value | int | `int myInt = 10;` |
| Value | float | `float myFloat = 3.14f;` |
| Value | bool | `bool myBool = true;` |
| Value | char | `char myChar = 'A';` |
| Reference | string | `string myString = "Hello";` |
| Reference | array | `int[] myArray = new int[5];` |
| Reference | class | `MyClass myObject = new MyClass();` |

Using specific types can help optimize CPU memory allocation when running a program.

### Primitive types: numeric

```c#
int count = 10;

// 6-9 digits; uses the "f" literal
float length = 1876.79f;

// 15-17 digits; default in C#
double width = 1876.79797657;

// 28-29 digits; uses the "m" literal
decimal cost = 300.5m; 
```

Decimal types are more memory-intensive.

### Type casting

Make a variable **pretend** to be a different type (within a sort of computed calculation):

```c#
int a = 10;
int b = 4;
double c = a / (double) b;
```

### Primitive types: strings

```c#
string favoriteCity = "Buenos Aires";
int numberOfTrips = 5;

string story = "I've traveled to " + favoriteCity + " " + numberOfTrips + " times!"; // -> "I've traveled to Buenos Aires 5 times!"
```

### Constants

*It's recommended to use constants whenever possible*: they allow programs to go faster (not check for alternative values):

```c#
const int numberOfWeekdays = 7;
```