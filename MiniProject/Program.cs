

using Microsoft.VisualBasic;
using Npgsql.Replication.PgOutput.Messages;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MiniProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
        
            

            // See your project name

            static void project_name()
            {
                List<ProjectsModel> projectList = PostgresDataAcces.currunt_project();
                {
                    Console.WriteLine("Enter your project ID.");
                    int chech_p_id = int.Parse(Console.ReadLine());
                    
                    foreach (ProjectsModel projects in projectList)
                    {
                        if (chech_p_id == projects.id)
                        {
                            Console.WriteLine($"ProjectID: {projects.id}   ProjectName: {projects.project_name} ");
                        }
                      


                    }

                }
               
                
            }

            //list everything 
            static void project_pers()
            {
                //red project  person  from properties
                List<ProjectPerson> projectPersonList = PostgresDataAcces.currunt_project_person();
                {

                    foreach (ProjectPerson projectPeson in projectPersonList)
                    {

                        Console.WriteLine($"\nID: {projectPeson.id}   PersonID: {projectPeson.person_id}   ProjectID: {projectPeson.project_id}   Hours:  {projectPeson.hours}\n \n");


                    }

                }
            }
          
            // Define the main menu options
            List<string> mainMenuOptions = new List<string>() { "Create Person ", "Create Project ", "Registeration","Update", "Exit" };

            // Define the submenu options
            List<PersonModel> submenuOptions = PostgresDataAcces.currunt_person();

            //added a back oppetion object 
            PersonModel backOption = new PersonModel()
            {
                id = -1, // Use a negative ID to identify the "Back" option
                person_name = "\nBack"
            };
            submenuOptions.Add(backOption);

            List<ProjectsModel> submenuOptionsProject = PostgresDataAcces.currunt_project();
            //added a back oppetion object 
            ProjectsModel backOptionProject = new ProjectsModel()
            {
                id = -1, // Use a negative ID to identify the "Back" option
                project_name = "\nBack"
            };
            submenuOptionsProject.Add(backOptionProject);

            // Display the main menu and execute the selected option
          
            while (true)
            {
                int submenuSelectedIndexProject;
                int submenuSelectedIndex;
                int selectedIndex = DisplayMenuAndGetSelection( mainMenuOptions);
                if (selectedIndex == mainMenuOptions.Count - 1)
                {
                    break;
                }
                else if (selectedIndex == 2)
                {
                    // Display the submenu and execute the selected option
                    while (true)
                    {
                         submenuSelectedIndex = DisplaySubMenuAndGetSelection(submenuOptions);
                        if (submenuSelectedIndex == submenuOptions.Count - 1)
                        {
                             break;
                            
                        }
                        

                       // chose project name

                        while (true)
                        {
                             submenuSelectedIndexProject = DisplaySubMenuAndGetSelectionProject(submenuOptionsProject);
                           
                            if (submenuSelectedIndexProject == submenuOptionsProject.Count - 1)
                            {
                               
                                break;

                            }

                            Console.WriteLine("Enter your hours.");
                            int hours = int.Parse(Console.ReadLine());

                            PostgresDataAcces.hoursRegisteration(submenuSelectedIndexProject+1, submenuSelectedIndex+1, hours);
                            ExecuteSubmenuOption(submenuSelectedIndexProject);

                        }

                        ExecuteSubmenuOption(submenuSelectedIndex);
                       
                    }
                }
                //Uppdate
                
                else if (selectedIndex == 3)
                {
                   //update hours
                   


                        submenuSelectedIndexProject = UpdateName(submenuOptions);
                       
                        submenuSelectedIndex = UpdateProject(submenuOptionsProject);
                    Console.WriteLine("Enter your Updated Hour");
                    int newHour = int.Parse(Console.ReadLine());
                  
                        PostgresDataAcces.UpdateHoursRegistration(submenuSelectedIndexProject + 1, submenuSelectedIndex + 1, newHour);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Hours successfully updated!");
                        Console.ResetColor();
                        Console.ReadKey();
                    

                }

                else
                {
                    ExecuteMainMenuOption(selectedIndex);
                }
            }


        }

        //create prson
        public static void create_person()
        {
            Console.WriteLine("Enter your name.");
            string personName = Console.ReadLine();
            PostgresDataAcces.personRegisteration(personName);

            //red person name from properties
            List<PersonModel> personList = PostgresDataAcces.currunt_person();
            {

                foreach (PersonModel person in personList)
                {

                    Console.WriteLine($"Name: {person.person_name}");


                }
            }
        }


        // create project
       public static void create_project()
        {
            Console.WriteLine("Enter your porject name.");
            string projectName = Console.ReadLine();
            PostgresDataAcces.projectRegisteration(projectName);


            //red project name from properties
            List<ProjectsModel> projectList = PostgresDataAcces.currunt_project();
            {

                foreach (ProjectsModel projects in projectList)
                {

                    Console.WriteLine($"ProjectName: {projects.project_name} ");


                }
            }
        }
        //out main

        static int DisplayMenuAndGetSelection(List<string> menuOptions)
        {
            // Set the initial selected index
            int selectedIndex = 0;

            // Loop until the user selects an option
            while (true)
            {
                // Clear the console and display the menu options
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n              ================= Wellcome system =================\n");
                Console.ResetColor();
                for (int i = 0; i < menuOptions.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("| " + menuOptions[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("  " + menuOptions[i]);
                    }
                }

                // Read the user's key input and handle arrow keys
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = (selectedIndex - 1 + menuOptions.Count) % menuOptions.Count;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedIndex = (selectedIndex + 1) % menuOptions.Count;
                        break;
                    case ConsoleKey.Enter:
                        return selectedIndex;
                }
            }
        }


       
       public static void ExecuteMainMenuOption(int selectedIndex )
        {
            switch (selectedIndex)
            {
                case 0:
                    create_person();
                    break;


                case 1:
                    create_project();

                    break;
                case 2:
                    //Console.WriteLine("What is your updated hours ? ");
                    // int hours = int.Parse (Console.ReadLine());
                    //PostgresDataAcces.uppdateHoursRegisteration(submenuSelectedIndexProject, submenuSelectedIndex, hours);


                    break;
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


        //sub menu 
        static int DisplaySubMenuAndGetSelection(List<PersonModel> submenuOptions )
        {
           
            // Set the initial selected index
            int selectedIndex = 0;

            // Loop until the user selects an option
            while (true)
            {
                // Clear the console and display the menu options
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n              ================= Chose you name =================\n");
                Console.ResetColor();
                for (int i = 0; i < submenuOptions.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("|  " + submenuOptions[i].person_name);

                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("  " + submenuOptions[i].person_name);
                    }

                }
                // Read the user's key input and handle arrow keys
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = (selectedIndex - 1 + submenuOptions.Count) % submenuOptions.Count;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedIndex = (selectedIndex + 1) % submenuOptions.Count;
                        break;
                    case ConsoleKey.Enter:
                        return selectedIndex;
                }

            }


        }

       

        //display subMenu project

        static int DisplaySubMenuAndGetSelectionProject(List<ProjectsModel> submenuOptionsProject)
        {
            // Set the initial selected index
            int selectedIndex = 0;

            // Loop until the user selects an option
            while (true)
            {
                // Clear the console and display the menu options
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n              ================= Chose your project =================\n");
                Console.ResetColor();
                for (int i = 0; i < submenuOptionsProject.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("|  " + submenuOptionsProject[i].project_name);

                        Console.ResetColor();
                        
                    }
                    else
                    {
                        Console.WriteLine("  " + submenuOptionsProject[i].project_name);
                        
                    }

                }

               
                // Read the user's key input and handle arrow keys
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = (selectedIndex - 1 + submenuOptionsProject.Count) % submenuOptionsProject.Count;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedIndex = (selectedIndex + 1) % submenuOptionsProject.Count;
                        break;
                    case ConsoleKey.Enter:
                        return selectedIndex;
                }

            }


        }

        //update
        static int UpdateName(List<PersonModel> submenuOptions)
        {
            // Set the initial selected index
            int selectedIndex = 0;

            // Loop until the user selects an option
            while (true)
            {
                

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n              ================= Select your Name =================\n");
                Console.ResetColor();
                for (int i = 0; i < submenuOptions.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("|  " + submenuOptions[i].person_name);

                        Console.ResetColor();

                    }
                    else
                    {
                        Console.WriteLine("  " + submenuOptions[i].person_name);

                    }

                }


                // Read the user's key input and handle arrow keys
                ConsoleKeyInfo keyInfo2 = Console.ReadKey(true);
                switch (keyInfo2.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = (selectedIndex - 1 + submenuOptions.Count) % submenuOptions.Count;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedIndex = (selectedIndex + 1) % submenuOptions.Count;
                        break;
                    case ConsoleKey.Enter:
                        return selectedIndex;
                }

            }


        }
        static int UpdateProject(List<ProjectsModel> submenuOptionsProject)
        {
            int selectedIndex = 0;
            while (true)
            {
                
                // Clear the console and display the menu options
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n              ================= Select your project =================\n");
                Console.ResetColor();
                for (int i = 0; i < submenuOptionsProject.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("|  " + submenuOptionsProject[i].project_name);

                        Console.ResetColor();

                    }
                    else
                    {
                        Console.WriteLine("  " + submenuOptionsProject[i].project_name);

                    }

                }


                // Read the user's key input and handle arrow keys
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = (selectedIndex - 1 + submenuOptionsProject.Count) % submenuOptionsProject.Count;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedIndex = (selectedIndex + 1) % submenuOptionsProject.Count;
                        break;
                    case ConsoleKey.Enter:
                        return selectedIndex;
                }
            }

        }
            static void ExecuteSubmenuOption(int selectedIndex)
        {
            switch (selectedIndex)
            {

                default:


                    //Console.WriteLine("Enter your porject ID.");
                    //int project_id = int.Parse(Console.ReadLine());
                    //Console.WriteLine("Enter your prson ID ");
                    //int person_id = int.Parse(Console.ReadLine());

                    //Console.WriteLine("Enter your hours.");
                    //int hours = int.Parse(Console.ReadLine());

                    //PostgresDataAcces.hoursRegisteration(project_id, person_id, hours);

                    //Console.ForegroundColor = ConsoleColor.Red;
                    //Console.WriteLine("The Project is not yours.");
                    //Console.ResetColor();

                    break;
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

    }
}