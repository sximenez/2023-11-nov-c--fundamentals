public class Program
{
    private class Student
    {
        public string Name { get; set; }
        public int[] Grades { get; set; }
        public decimal Result { get; set; }
        public string LetterGrade { get; set; }
        public List<(string, int, int)> GradesReference { get; private set; }

        public Student(string name, int[] grades)
        {
            Name = name;
            Grades = grades;
            Result = 0;
            LetterGrade = string.Empty;
            GradesReference = new List<(string, int, int)>()
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
        }
    }

    public static void Main(string[] args)
    {
        List<Student> students = new List<Student>
        {
            new Student("Sophia", new int[] { 90, 86, 87, 98, 100, 94, 90 }),
            new Student("Andrew", new int[] { 92, 89, 81, 96, 90, 89 }),
            new Student("Emma", new int[] { 90, 85, 87, 98, 68, 89, 89, 89 }),
            new Student("Logan", new int[] { 90, 95, 87, 88, 96, 96 }),
            new Student("Becky", new int[] { 92, 91, 90, 91, 92, 92, 92 }),
            new Student("Chris", new int[] { 84, 86, 88, 90, 92, 94, 96, 98 }),
            new Student("Eric", new int[] { 80, 90, 100, 80, 90, 100, 80, 90 }),
            new Student("Gregor", new int[] { 91, 91, 91, 91, 91, 91, 91 })
    };

        Console.WriteLine("Student\t\tGrade\n");

        int counter = 0;
        foreach (var student in students)
        {
            foreach (int grade in student.Grades)
            {
                if (counter < 5)
                {
                    student.Result += grade;
                    counter++;
                }
                else
                {
                    student.Result += grade / 10;
                    counter++;
                }
            }


            student.Result /= 5;
            decimal roundedResult = Math.Round(student.Result, 0);

            foreach (var entry in student.GradesReference)
            {
                if (roundedResult >= entry.Item2 && roundedResult <= entry.Item3)
                {
                    student.LetterGrade = entry.Item1;
                    break;
                }
            }

            Console.WriteLine($"{student.Name}:\t\t{student.Result}\t{student.LetterGrade}");
            counter = 0;
        }

        Console.WriteLine();
        Console.WriteLine("Press the Enter key to continue");
        Console.ReadLine();
    }
}