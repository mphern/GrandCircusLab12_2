using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandCircusLab12_2
{
    class Student : Person
    {

        public Student() : base()
        {
        }

        public string Program { get; set; }
        public int Year { get; set; }
        public double Tuition { get; set; } 

        public override string ToString()
        {
            return string.Format("{0,-20}", Name) + string.Format("{0,-20}", Address) +
                string.Format("{0,-20}", Program) + string.Format("{0,-20}", Year)+
                string.Format("{0,-20}", Tuition);
        }

        

        public void EditProgram(string program) { Program = program; }

        public void EditYear(int year) { Year = year; }

        public void EditTuition(double tuition) { Tuition = tuition; }
        
        public static Student CreateStudent()
        {
            Student student = new Student();
            Console.Write("\nWhat is the student's first name? ");
            string firstName = Console.ReadLine().Trim();
            Console.Write("What is the student's last name? ");
            string lastName = Console.ReadLine().Trim();
            student.Name = lastName + ", " + firstName;
            Console.Write("What is the student's address? ");
            student.Address = Console.ReadLine().Trim();
            Console.Write("What is the student's program? ");
            student.Program = Console.ReadLine().Trim();
            student.Year = Validator.ValidateIntMin("What is the student's year? ", 1);
            student.Tuition = Validator.ValidateDoubleMin("What is the student's tuition? ", 0);
            Console.WriteLine("\n" + firstName + " has been added!");
            return student;
        }
        //Created this overload simply to add students at beginning so list isn't empty.  Won't be used anywhere else in the code. 
        public static Student CreateStudent(string firstName, string lastName, string address, string program, int year, double tuition)
        {
            Student student = new Student
            {
                Name = lastName + ", " + firstName,
                Address = address,
                Program = program,
                Year = year,
                Tuition = tuition
            };
            return student;
        }

    }
}