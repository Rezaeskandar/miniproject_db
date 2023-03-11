## MINI PROJECT
> *Welcome to my simple Time/Project registeration application! This application is a simple project in C#. It is done using postgres some database. It is a simple project made using console application. This means, no graphics component are added but you olny use keyboerd arrows to navigating in menus. The main target user of this project are the C# beginners who want to read and save data from postgresSQL and make an easy connectiostring . This simpele project is especially those who are interested in lerning work with clases by maping data from database to class object and then work with that.*
## The codebase is structured:

### ```Create or read persons throw this class:```
```sh
 public class PersonModel
    {
        public int id { get; set; }
        public string person_name { get; set; }
    }
```

### ```Create or read Project throw this class:```
```sh
  public class ProjectsModel
    {
        public int id { get; set; }
        public string project_name { get; set; }
    }
    
```

### ```Uptating and inserting hours for every project:```
```sh

          public class ProjectPerson
    {
        public int id { get; set; }
        public int project_id { get; set; }
        public int person_id { get; set; }
        public string hours { get; set; }
       
       
      
    }
```
## Features:

- Create new pesron and project
- insert how meny hours your worked in a project
- Uppdate your hours if you inseted by mistake 

## Tech stack:
- C# .NET Core 6 
- Using Visual Stadio 
- PostgresSQL

## Getting Started
To get started with the project, you will need to clone the repository to your local machine. Once the repository is cloned, you can navigate to the project directory and run the project using your preferred visual stadio environment.


## Reflection
- In building this bank system project was not much deficaul becouse i already did a bank application group project and knew what and how exaclay should i make it.
- This code structure is used to create a simple registration of project to a spesific person, where User can register his/her name and a project to that, and then register how many hours have work on that project. This application has laso update option that let user to rewrite hours to a project if it was wrong registreation by accident.



Why this way of creating a bank system using User and Account classes is a good ?
___

1- Object-oriented design: Using classes to read and manuplating data in database and classes makes it easy to understand the different components of the system and how they relate to each other.

2- Reusability: The PostgresDataAcces classes  make all onrops to database and that can be reused where the data needs to reads or writes to.

3- The use of properties with public getters and setters makes it easy to access the properties of the objects. It also makes it easy to add or remove properties in the future without affecting the rest of the system.

5-The structure uses basic concepts of Object-oriented programming, which makes it easy to implement and understand the code.


____

Summary:
___
this approach of using PostgresSQL databse to create a simple Project Registraton system is a good choice because it allows for a clear and organized system that is easy to understand, implement, and maintain. Tt allows for the implementation of Object oriented programming concepts and security which is essential for a production ready system.

Is thier any other ways to do this ?
___

For sure thier are meny better ways do implement this project thas looks better and more profecinall. But as much i know today this way worked for this small project well. It maby whould be better or speed more the project by using Entety Framwork but i can not so much abouwt that now.
## UML
<img src ="https://user-images.githubusercontent.com/113901667/224511927-8644c141-58f7-478a-a7ab-cf9ca9a74751.png" width="1200" height="500">



## Here is an overview from the console
<img src="https://user-images.githubusercontent.com/113901667/212492142-17ee36fd-1fdf-478c-be35-0a1619f98329.png" width="1200" height="500">

## First App I did witch was not acceptable.
