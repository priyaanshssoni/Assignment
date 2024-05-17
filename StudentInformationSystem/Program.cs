

namespace StudentInformationSystem;

class Program
{
    static void Main(string[] args)
    {
        StudentRepositoryService stud1 = new StudentRepositoryService();
        stud1.AddStudent();
        Console.ReadLine();
    }
}

