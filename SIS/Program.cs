using SIS.Model;
using SIS.Repository;
using SIS.Service;
using SIS.Main;

namespace SIS;

class Program
{
    static void Main(string[] args)
    {

        StudentInformationSystem system = new StudentInformationSystem();


        bool running = true;
        while (running)
        {
            running = system.Run();



        }


    }

 }

