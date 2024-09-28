
using System;

namespace p4cs
{
    class Assignment
    {
        public static void Main()
        {
            string? userChoice;


            do
            {
                // Menu 
                Console.WriteLine("\nChoose one of the following options:");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("a) Trinary Converter. \nb) School Roster. \nc) ISBN Verifier. \nq) End the program. \n");
                // Conveting the users input to lowercase so it does not error handle incorrectly
                userChoice = Console.ReadLine().ToLower();


                // Switches between options 
                switch (userChoice)
                {
                    case "q": // Ends program

                        Console.WriteLine("\nProgram ended.");

                        break;
                    case "a":  // Trinary converter
                        
                        // Jumps to trinary converter method
                        TrinaryConverter();

                        break;
                    case "b": // School roster

                        // Jumps to school roster method
                        SchoolRoster();

                        break;
                    case "c": // ISBN verifier

                        // Jumps to ISBN checker method
                        ISBNCheck();

                        break;
                    default:

                        // Error handling for if the user enters the wrong values or too many
                        if (userChoice != null && userChoice.Length != 1 && userChoice.Length != 0)
                        {
                            Console.WriteLine("\nEnter a single character.");
                        }
                        else
                        {
                            Console.WriteLine("\nEnter only the values 'a', 'b', 'c' or 'q'");

                        }
                        break;
                }


            }
            while (userChoice != "q");

        }

        // Trinary Converter
        public static void TrinaryConverter()
        {
            Console.Clear();
            Console.WriteLine("\nEnter a number to convert:");
            string? userNumber = Console.ReadLine();

            // If the number is null assigning it a values which causes it to print an error message
            if (string.IsNullOrEmpty(userNumber))
            {
                userNumber = "7";
            } 

            // Offsets the counter
            int counter = (userNumber.Length - 1);
            double result = 0;

            // Goes through each number the user entered
            foreach (char x in userNumber)
            {
                switch(x)
                {
                    // If the number is 0, 1 or 2 it converts it to a integer and multiplies it to 3 to the power of the counter
                    case '0': case '1': case '2':
                        result += ((int)(x - '0') * Math.Pow(3, counter));

                        // Reduces the counter by 1
                        counter--;
                        break;
                    // Error handling if the user enters a number that isnt a valid trinary number
                    default:
                        Console.WriteLine("\nNot valid trinary.");
                        return;
                }
            }
            Console.WriteLine("\nThe decimal equivelant is: " + result);
        }

        // Creating a class to store the names and forms of students entered
        class Student
        {
            public string Name;
            public int Form;

            // Method that allows students to be assigned to class easier
            public Student(string name, int form)
            {
                Name = name;
                Form = form;
            }
        }

        // Helper method for school roster
        static void FormOutput(int x, List<Student> list)
        {
            // Checks each student in the list to see if the form matches the form user inputs
            foreach(Student student in list)
            {
                 if(student.Form == x)
                {
                    Console.WriteLine("Form: " + student.Form + " | " + student.Name);
                }
            }
        }

        // School Roster
        public static void SchoolRoster()
        {
            List<Student> students = new();
            string userChoice;

            do
            {
                // Menu
                Console.Clear();
                Console.WriteLine("\nSchool Roster");
                Console.WriteLine("-------------");
                Console.WriteLine("a) Add a student to form. \nb) List all students in a form. \nc) List all students in the school. \nq) Quit.");
                userChoice = Console.ReadLine().ToLower();

                switch (userChoice)
                {
                    case "a": // Add student to form

                        Console.WriteLine("\nPlease enter the name of student.");
                        string? studentName = Console.ReadLine();

                        Console.WriteLine("\nWhat form are they in?");

                        // Error handling: Checks that the student name isnt null and changes form from string to int
                        if(!string.IsNullOrEmpty(studentName) && int.TryParse(Console.ReadLine(), out int studentForm))
                        {
                            // Assigns the student and form to the class
                            students.Add(new Student(studentName, studentForm));
                        }
                        else
                        {
                            // Error message
                            Console.WriteLine("\nPlease enter a valid value.");
                        }
                        break;
                    case "b": // List all students in a form

                        Console.WriteLine("\nWhich form would you like to list out?");

                        // Error handling: Converts string to int, if string isnt a number prints an error message
                        if(int.TryParse(Console.ReadLine(), out int formList))
                        {
                            // Jumps to form output method 
                            FormOutput(formList, students);

                        }
                        else
                        {
                            // Error message
                            Console.WriteLine("\nStudent form cannot be empty or string.");
                        }

                        Console.ReadKey();
                        break;
                    case "c": // List all students in school

                        List<int> forms = new();

                        foreach (Student x in students)
                        {
                            if (!(forms.Contains(x.Form))) forms.Add(x.Form);
                        }

                        // Sorts the form numbers in ascending order 
                        forms.Sort();
                        
                        // Goes through each form number added and prints the student + their form number
                        foreach (int x in forms)
                        {
                            FormOutput(x, students);
                        }
                        Console.ReadKey();
                        break;
                    case "q": // Quit

                        Console.WriteLine("\nLeaving school roster.");

                        break;
                    default:

                        // Error handling for if the user enters the wrong values or too many
                        if (userChoice != null && userChoice.Length != 1 && userChoice.Length != 0)
                        {
                            Console.WriteLine("\nEnter a single character.");
                        }
                        else
                        {
                            Console.WriteLine("\nEnter only the values 'a', 'b', 'c' or 'q'");

                        }
                        break;
                       
                }

            } while (userChoice != "q");
            
        }

        // ISBN verifier
        public static void ISBNCheck()
        {
            int counter = 10;
            int result = 0;

            Console.Clear();
            Console.WriteLine("\nPlease enter your ISBN-10 number to validate:");
            string? ISBNNum = Console.ReadLine();
            
            // Seperates each character and converts it to uppercase if 'x' 
            foreach(char x in ISBNNum.ToUpper())
            {
                switch (x)
                {
                    case '0': case '1': case '2': case '3': case '4': case '5': case '6': case '7':case '8':case '9': 
                       
                        // Converts number from string to int then times it by counter, then adds result to 'result' variable.
                        result += (int)(x - '0') * counter;

                        // Decreases counter
                        counter --;

                        break;
                    case '-': // Ignores the dashes seperating numbers without printing error message
                        break;
                    case 'X':

                        // Checking to make sure 'x' is the last character
                        if (counter == 1)
                        {
                            // Multiples 10 by the counter and adds it to result variable.
                            result += 10 * counter;

                            // Decreases counter
                            counter--;
                        }

                        break;
                    default: // Error message if user enters any digits that arent between 0 to 9 or character 'x'
                        
                        Console.WriteLine("\nISBN-10 numbers can only have digits 0-9 or characters 'X'.");

                        return; // Goes back to menu and skips next pieces of code 
                }
            }

            // Checks if the ISBN number is valid by doing mod 11
            if (result % 11 == 0) 
            {
                Console.WriteLine("\n" + ISBNNum + " is a valid ISBN-10 number.");
            }
            else
            {
                Console.WriteLine("\n" + ISBNNum + " is not a valid ISBN-10 number.");
            }

        }

    }
}