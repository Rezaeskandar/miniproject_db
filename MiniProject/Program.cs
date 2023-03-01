

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MiniProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            static void seeuser() { 
                List<PersonModel> personList = PostgresDataAcces.currunt_person();
                {

                    foreach (PersonModel person in personList)
                    {
                        Console.WriteLine($"name: {person.person_name}");
                    }
                }
            }


          //create prson
          
            static void create_person()
            {
                Console.WriteLine("Enter your name.");
                string personName = Console.ReadLine();
                PostgresDataAcces.personRegisteration(personName);

                //red person name from properties
                List<PersonModel> personList = PostgresDataAcces.currunt_person();
                {

                    foreach (PersonModel person in personList)
                    {

                        Console.WriteLine($"PersonID: {person.id}   name: {person.person_name}");


                    }
                }
            }

            // create project
            static void create_project()
            {
                Console.WriteLine("Enter your porject name.");
                string projectName = Console.ReadLine();
                PostgresDataAcces.projectRegisteration(projectName);


                //red project name from properties
                List<ProjectsModel> projectList = PostgresDataAcces.currunt_project();
                {

                    foreach (ProjectsModel projects in projectList)
                    {

                        Console.WriteLine($"ProjectID: {projects.id}   Project: {projects.project_name} ");


                    }
                }
            }
            static void regester_prs_and_prj() 
            {


                //List<PersonModel> personList = PostgresDataAcces.currunt_person();
                //{
                   
                //    int selectedIndex = 0;
                    
                //    //foreach (PersonModel person in personList)
                //    //{

                //    //    Console.WriteLine($"PersonID: {person.id}   name: {person.person_name}");

                     
                //    //}





                //    while (true)
                //    {

                //        //PersonModel[] personStrings = new PersonModel[personList.Count];
                //        // Clear the console and display the menu
                //        Console.Clear();
                //        Console.WriteLine(" \n\n                  ==============   Chose a person   =============\n");
                //        for (int i = 0; i < personList.Count; i++)
                //        {
                           
                //            if (i == selectedIndex)
                //            {
                                
                //                Console.ForegroundColor = ConsoleColor.Green;
                //                Console.WriteLine($"|  { personList[i].person_name}");
                //                Console.ResetColor();
                //            }
                //            else
                //            {
                //                Console.WriteLine("  " + personList[i].person_name);
                //            }
                //        }

                //        // Wait for a key press and handle arrow keys
                //        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                //        switch (keyInfo.Key)
                //        {
                //            case ConsoleKey.UpArrow:
                //                selectedIndex = (selectedIndex + personList.Count - 1) % personList.Count;
                //                break;
                //            case ConsoleKey.DownArrow:
                //                selectedIndex = (selectedIndex + 1) % personList.Count;
                //                break;
                //            case ConsoleKey.Enter:
                //                RunSelectedOption(selectedIndex);
                //                Console.WriteLine("\nPress Enter go to main menu.");
                //                Console.ReadKey();
                //                break;

                //        }
                        
                //    }

                    Console.WriteLine("Enter your porject ID.");
                    int project_id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter your prson ID ");
                    int person_id = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter your hours.");
                    int hours = int.Parse(Console.ReadLine());

                    PostgresDataAcces.hoursRegisteration(project_id, person_id, hours);

                    // Define the first menu options

                    //static void RunSelectedOption(int selectedIndex)
                    //{

                    //    switch (selectedIndex)
                    //    {
                    //        default:
                    //            List<PersonModel> personList = PostgresDataAcces.currunt_person();
                    //            {
                    //                foreach (PersonModel person in personList)
                    //                {

                    //                    Console.WriteLine($"PersonID: {person.id}   name: {person.person_name}");


                    //                }
                    //            }
                    //            break;
                    //    }


                    //}


                //}


            }

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
            List<string> mainMenuOptions = new List<string>() { "Create Person ", "Create Project ", "Registeration", "Exit" };

            // Define the submenu options
            List<PersonModel> submenuOptions = PostgresDataAcces.currunt_person();
            List<ProjectsModel> submenuOptionsProject = PostgresDataAcces.currunt_project();

            // Display the main menu and execute the selected option
            while (true)
            {
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
                        int submenuSelectedIndex = DisplayMenuAndGetSelection(submenuOptions);
                        if (submenuSelectedIndex == submenuOptions.Count - 1)
                        {
                             break;
                            
                        }
                        
                        ExecuteSubmenuOption(submenuSelectedIndex);
                        
                    }
                }
                else
                {
                    ExecuteMainMenuOption(selectedIndex);
                }
            }



            //string[] personStrings = personList.Select(p => p.person_name);

            //  int chosenPersonIndex = generalMenu(personStrings);
            //  persontList[chosenPersonIndex].id;
            //  static int generalMenu(string[] choices)
            //  {
            //      for (int i = 0; i < choices.Length; i++)
            //      {
            //          Console.WriteLine(choices[i]);
            //      }
            //  }      }
            //    // hela din menyfunktionalitet
            //    return 1
            //}

            //static void  menuChose() {
            //    string[] menu = { "Create Person ", "Create Project ", "Registeration", "See your Cources", "Exit" };
            //for (int i = 0; i < menu.Length; i++)
            //{
            //        Console.WriteLine(menu[i]); 

            //}
            //}

            //Mainmenu:



            //int selectedIndex = 0;
            //string[] options = { "Create Person ", "Create Project ", "Registeration", "Exit" };


            //while (true)
            //{

            //    // Clear the console and display the menu
            //    Console.Clear();
            //    Console.WriteLine(" \n\n                  ==============   Welcome to the system   =============\n");
            //    for (int i = 0; i < options.Length; i++)
            //    {
            //        if (i == selectedIndex)
            //        {
            //            Console.ForegroundColor = ConsoleColor.Green;
            //            Console.WriteLine("| " + options[i]);
            //            Console.ResetColor();
            //        }
            //        else
            //        {
            //            Console.WriteLine("  " + options[i]);
            //        }
            //    }

            //    // Wait for a key press and handle arrow keys
            //    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            //    switch (keyInfo.Key)
            //    {
            //        case ConsoleKey.UpArrow:
            //            selectedIndex = (selectedIndex + options.Length - 1) % options.Length;
            //            break;
            //        case ConsoleKey.DownArrow:
            //            selectedIndex = (selectedIndex + 1) % options.Length;
            //            break;
            //        case ConsoleKey.Enter:
            //            RunSelectedOption(selectedIndex);
            //            Console.WriteLine("\nPress Enter go to main menu.");
            //            Console.ReadKey();
            //            goto Mainmenu;

            //    }
            //}

            //// Define the first menu options

            //static void RunSelectedOption(int selectedIndex) 
            // {

            //        switch (selectedIndex)
            //        {
            //            case 0:
            //            // Call method for option 1
            //            create_person();

            //                break; 


            //            case 1:
            //            create_project();

            //            break;
            //            case 2:

            //            regester_prs_and_prj();
            //            break;
            //        case 3:
            //            Console.WriteLine("\nYou are wellcome back.");
            //            Environment.Exit(0);

            //            break;
            //        }


            //}
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

        static int DisplayMenuAndGetSelection(List<PersonModel> menuOptions)
        {
            // Set the initial selected index
            int selectedIndex = 0;

            // Loop until the user selects an option
            while (true)
            {
                // Clear the console and display the menu options
                Console.Clear();
                for (int i = 0; i < menuOptions.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor= ConsoleColor.Green;
                        Console.WriteLine("|  " + menuOptions[i].person_name);
                        
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("  " + menuOptions[i].person_name);
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
       public static void ExecuteMainMenuOption(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("Enter your name.");
                    string personName = Console.ReadLine();
                    PostgresDataAcces.personRegisteration(personName);

                    //red person name from properties
                    List<PersonModel> personList = PostgresDataAcces.currunt_person();
                    {

                        foreach (PersonModel person in personList)
                        {

                            Console.WriteLine($"PersonID: {person.id}   name: {person.person_name}");


                        }
                    }

                    break;


                case 1:
                    // Call method for option 1
                    Console.WriteLine("Enter your porject name.");
                    string projectName = Console.ReadLine();
                    PostgresDataAcces.projectRegisteration(projectName);


                    //red project name from properties
                    List<ProjectsModel> projectList = PostgresDataAcces.currunt_project();
                    {

                        foreach (ProjectsModel projects in projectList)
                        {

                            Console.WriteLine($"ProjectID: {projects.id}   Project: {projects.project_name} ");


                        }
                    }

                    break;
                case 2:


                   
                    break;
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void ExecuteSubmenuOption(int selectedIndex)
        {
            switch (selectedIndex)
            {
                default:


                    Console.WriteLine("Enter your porject ID.");
                    int project_id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter your prson ID ");
                    int person_id = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter your hours.");
                    int hours = int.Parse(Console.ReadLine());

                    PostgresDataAcces.hoursRegisteration(project_id, person_id, hours); 
                    break;
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

    }
}