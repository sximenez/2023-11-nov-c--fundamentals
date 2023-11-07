# C# Fundamentals

Source: [Microsoft](https://learn.microsoft.com/en-gb/training/)

## Table of contents

- [C# Fundamentals](#c-fundamentals)
  - [Table of contents](#table-of-contents)
  - [Introduction](#introduction)
  - [Challenge 1](#challenge-1)
  - [Variables](#variables)
    - [Data types](#data-types)
    - [Implicitly typed local variables](#implicitly-typed-local-variables)
    - [Challenge 2](#challenge-2)
    - [Character escape sequences](#character-escape-sequences)
    - [String interpolation](#string-interpolation)
    - [Challenge 3](#challenge-3)
    - [Type casting](#type-casting)
  - [Glossary](#glossary)
  - [| syntax | rules for writing code |](#-syntax--rules-for-writing-code-)
  - [Variables](#variables-1)
    - [Primitive types: numeric](#primitive-types-numeric)
    - [Type casting](#type-casting-1)
    - [Primitive types: strings](#primitive-types-strings)
    - [Constants](#constants)

## Introduction

C# is a case-sensitive language.

`console` is different from `Console`.

Interpreting error messages is key:

```c#
console.WriteLine("i like ice cream");
```
```terminal
(1,1): error CS0103: The name 'console' does not exist in the current context
```

```mermaid
graph LR

1[Higher-level language] ---|Compilation| 2[Lower-level language]
```

```mermaid
graph LR

1[C#] ---|Compiler| 2[Microsoft Intermediate Language, MSIL]
```

| Term | Definition | Example |
| --- | --- | --- |
| literal string | data is output literally | `"hello world"` |
| class | a class is an object, having methods live within it | `Console` |
| method | each method has one job; they live within classes | `WriteLine()` |

## Challenge 1

```c#
Console.WriteLine("This is the first line.");
Console.Write("This is the second line.");
```
```terminal
This is the first line.
This is the second line.
```

## Variables

### Data types

Data typing is a key characteristic of C#: designers believed it can lead to avoiding common bugs.

| Data type | Use case | Example |
| --- | --- | --- |
| string | presentation or text manipulation | `string myString = "Hello";` |
| char | presentation or text manipulation | `char myChar = 'A';` |
| int | calculation | `int myInt = 10;` |
| float | calculation (6-9 digits) | `float mySmallNumber = 3.14f;` |
| double | calculation (15-17 digits; default in C#, no literal suffix needed) | `double myMediumNumber = 3.14;` |
| decimal | calculation (28-29 digits) | `decimal myLargeNumber = 3.14m;` |
| bool | evaluation | `bool myBool = true;` |

### Implicitly typed local variables

Use the `var` keyword: it tells the compiler that data type is implied.

```c#
var message = "hello world";
```

You can use `var` when the data type is not known.

However, it's best practice to always type your variables.

`/!\` C# always attributes a data type to a variable, even if implicit.

### Challenge 2

```c#
string userName = "Bob";
int messageNumber = 3;
float temperature = 34.4f;

Console.Write("Hello, ");
Console.Write(userName);
Console.Write("! You have ");
Console.Write(messageNumber);
Console.Write(" messages in your inbox. The temperature is ");
Console.Write(temperature);
Console.Write(" celsius.");
```

```terminal
Hello, Bob! You have 3 messages in your inbox. The temperature is 34.4 celsius.
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

### Challenge 3

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

## Glossary

| Term | Definition | Example |
| --- | --- | --- |
| compiler | *converts your code from a human higher-level language (C#) into an executable format that the computer can understand.* |  |
| precompilation | process before the main compilation process to help with performance | red squiggly lines underlining the code that will produce an error |
| programming language | *A programming language's job is to allow a human to express their intent [to a computer] in a human-readable and understandable way.* |
| syntax | rules for writing code |
---

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