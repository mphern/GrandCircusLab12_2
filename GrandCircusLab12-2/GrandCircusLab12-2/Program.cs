using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;

namespace GrandCircusLab12_2
{
    class Program
    {
        static void Main()
        {
            Console.Write("Welcome to the Student Directory App!\n");
            List<Student> studentList = new List<Student>();
            List<string> mainMenu = new List<string>() { "1. Add Student", "2. Add Archived Student",
                                                         "3. List Students by Name" , "4. List Students by Final Score",
                                                         "5. Remove Student from Directory", "6. Quit"};
            //Adding a student and archived to list so Program already has students in list
            studentList.Add(ArchivedStudent.CreateStudent("Sarah", "Hern", "123 State St.", "Education", 2500.00, 99.9));
            studentList.Add(Student.CreateStudent("Michael", "Hern", "123 Main St.", "Mathematics", 3, 4000.00));
            while (true)
            {
                DisplayMenu(mainMenu);
                int choice = Validator.ValidateIntMinMax("\nWhat would you like to do? ", 1, mainMenu.Count);
                if (choice == 1)
                {
                    studentList.Add(Student.CreateStudent());
                }
                else if (choice == 2)
                {
                    studentList.Add(ArchivedStudent.CreateStudent());
                }
                else if(choice == 3)
                {
                    if(studentList.Count == 0)
                    {
                        Console.WriteLine("\nThere are currently no students in the directory.");
                        continue;
                    }

                    DisplayHeader();
                    List<Student> sortedList = SortByName(studentList);
                    DisplayList(sortedList);
                }

                else if(choice == 4)
                {
                    DisplayHeader();
                    SortByFinalScore(studentList);
                }

                else if(choice == 5)
                {
                    DisplayHeader();
                    DisplayList(studentList);
                    int studentNum = Validator.ValidateIntMinMax("\nEnter student # of student you would like to remove: ", 1, studentList.Count);
                    RemoveStudent(ref studentList, studentNum);
                }

                else
                { break; }

            }

            Console.WriteLine("\nGood Bye!");
            Console.ReadKey();
        }

        static public void DisplayMenu(List<string> menu)
        {
            Console.Write("\n");
            foreach(string str in menu)
            {
                Console.WriteLine(str);
            }
        }

        static public List<Student> SortByName(List<Student> students)
        {
            List<Student> SortedList = students.OrderBy(x => x.Name).ToList();
            return SortedList;
        }

        static public void SortByFinalScore(List<Student> students)
        {
            List<ArchivedStudent> archivedStudents = new List<ArchivedStudent>();
            List<Student> _archivedStudents = new List<Student>();
            List<Student> activeStudents = new List<Student>();
            List<Student> sortedList = new List<Student>();
            foreach(Student student in students)
            {
                if(student is ArchivedStudent)
                {
                    archivedStudents.Add((ArchivedStudent) student);
                }
                else
                {
                    activeStudents.Add(student);
                }
            }
            archivedStudents.Sort();
            foreach(ArchivedStudent student in archivedStudents)
            {
                sortedList.Add(student);
            }
            activeStudents = SortByName(activeStudents);
            foreach (Student student in activeStudents)
            {
                sortedList.Add(student);
            }

            DisplayList(sortedList);
        }

        static public void DisplayList(List<Student> students)
        {
            int count = 0;
            foreach(Student student in students)
            {
                count++;
                Console.Write("\n");
                Console.Write(string.Format("{0,-5}", count));
                Console.WriteLine(student.ToString());
            }
        }

        static public void RemoveStudent(ref List<Student> students, int index)
        {
            string name = students[index - 1].Name;
            students.RemoveAt(index - 1);
            Console.WriteLine("\n" + name + " has been removed from the directory");
        }

        static public void DisplayHeader()
        {
            Console.WriteLine("\n");
            Console.WriteLine(string.Format("{0,-5}", "#") + string.Format("{0,-20}", "Name") + string.Format("{0,-20}", "Address") +
                  string.Format("{0,-20}", "Program") + string.Format("{0,-20}", "Year") +
                  string.Format("{0,-20}", "Tuition") + string.Format("{0,-20}", "Final Score"));
            Console.WriteLine("===================================================================" +
                  "==================================================");
        }
        
    }
}
