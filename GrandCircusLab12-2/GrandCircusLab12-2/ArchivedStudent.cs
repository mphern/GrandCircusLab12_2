using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandCircusLab12_2
{
    class ArchivedStudent : Student, IComparable<ArchivedStudent>
    {

        public ArchivedStudent() : base()
        {
        }

        public string Graduated { get; private set; } = "Graduated";
        public double FinalScore { get; set; }

        public override string ToString()
        {
            return string.Format("{0,-20}", Name) + string.Format("{0,-20}", Address) +
                string.Format("{0,-20}", Program) + string.Format("{0,-20}", Graduated) +
                string.Format("{0,-20}", Tuition) + string.Format("{0, -20}", FinalScore);
        }

        public int CompareTo(ArchivedStudent student)
        {
            if(FinalScore == student.FinalScore)
            {
                return Name.CompareTo(student.Name);
            }

            return student.FinalScore.CompareTo(FinalScore);
        }

        public static new ArchivedStudent CreateStudent()
        {
            ArchivedStudent student = new ArchivedStudent();
            Console.Write("\nWhat is the student's first name? ");
            string firstName = Console.ReadLine().Trim();
            Console.Write("What is the student's last name? ");
            string lastName = Console.ReadLine().Trim();
            student.Name = lastName + ", " + firstName;
            Console.Write("What is the student's address? ");
            student.Address = Console.ReadLine().Trim();
            Console.Write("What is the student's program? ");
            student.Program = Console.ReadLine().Trim();
            student.Tuition = Validator.ValidateDoubleMin("What is the student's tuition? ", 0);
            student.FinalScore = Validator.ValidateDoubleMinMax("What was the student's Final Score? ", 0, 100);
            Console.WriteLine("\n" + firstName + " has been added!");
            return student;
        }

        //Created this overload simply to add students at beginning so list isn't empty.  Won't be used anywhere else in the code.
        public static ArchivedStudent CreateStudent(string firstName, string lastName, string address, string program, double tuition, double finalScore)
        {
            ArchivedStudent student = new ArchivedStudent
            {
                Name = lastName + ", " + firstName,
                Address = address,
                Program = program,
                Tuition = tuition,
                FinalScore = finalScore
            };
            return student;
        }

    }
}
