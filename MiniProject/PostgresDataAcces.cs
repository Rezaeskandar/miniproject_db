using Dapper;
using Npgsql;
using System.Configuration;
using System.Data;

namespace MiniProject
{
    public class PostgresDataAcces
    {
        //register person name 
        public static void personRegisteration(string person_name)
        {
           
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                string sql = "insert into resk_person (person_name) values (@person_name)";
                cnn.Execute(sql, new { person_name });
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("New peroson name successfully registered!.");
                Console.ResetColor();
            }
        }

        //register Project name 
        public static void projectRegisteration(string project_name)
        {

            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                string sql = "insert into resk_project (project_name) values (@project_name)";
                cnn.Execute(sql, new { project_name });
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("New project name successfully registered!.");
                Console.ResetColor();
            }
        }

        //register hours
        public static void hoursRegisteration(int submenuSelectedIndexProject, int submenuSelectedIndex, int hours)
        {

            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                string sql = "insert into resk_project_person (project_id,person_id, hours) values (@submenuSelectedIndexProject ,@submenuSelectedIndex , @hours)";
                cnn.Execute(sql, new { submenuSelectedIndexProject, submenuSelectedIndex ,hours });
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Hours successfully registered!.");
                Console.ResetColor();
            }
        }


        

        public static void UpdateHoursRegistration(int submenuSelectedIndexProject, int submenuSelectedIndex, int newHour)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                string sql = "UPDATE resk_project_person SET hours = @newHour WHERE project_id = @submenuSelectedIndexProject AND person_id = @submenuSelectedIndex";
                cnn.Execute(sql, new { newHour, submenuSelectedIndexProject, submenuSelectedIndex });
               
            }
        }

        //read hours

        public static List<ProjectPerson> readHours()
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ProjectPerson>("SELECT * FROM resk_project_person", new DynamicParameters());

                return output.ToList();
            }
        }


        //read peson name 
        public static List<PersonModel> currunt_person()
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<PersonModel>("SELECT * FROM resk_person", new DynamicParameters());

                return output.ToList();

            }

        }

        //read project name 
        public static List<ProjectsModel> currunt_project()
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ProjectsModel>("SELECT * FROM resk_project", new DynamicParameters());

                return output.ToList();

            }

        }

        //read project person
        public static List<ProjectPerson> currunt_project_person()
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ProjectPerson>("SELECT * FROM resk_project_person", new DynamicParameters());

                return output.ToList();

            }

        }
        public static string LoadConnectionString(string id = "person_project")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
