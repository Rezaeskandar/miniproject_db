

namespace MiniProject
{
    public class Program
    {
        static void Main(string[] args)
        {

            List<PersonModel> personList = PostgresDataAcces.currunt_person();
            { 

                foreach (PersonModel person in personList)
                {
                    Console.WriteLine($"name: {person.person_name}");
                }
            }

            Console.WriteLine("Enter your name.");
            string personName = Console.ReadLine();
            PostgresDataAcces.personRegisteration(personName);

            Console.WriteLine("perss enter to register project name.");
            Console.ReadKey();
            Console.WriteLine("Enter your porject name.");
            string projectName = Console.ReadLine();
            PostgresDataAcces.projectRegisteration(projectName);


            Console.WriteLine("perss enter to register project name.");
            Console.ReadKey();
            Console.WriteLine("Enter your prson ID ");
            int person_id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your porject ID.");
            int project_id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your hours.");
          
            int hours =int.Parse( Console.ReadLine());
            PostgresDataAcces.hoursRegisteration(person_id, project_id, hours);

           
        }
    }
}