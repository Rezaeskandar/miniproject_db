

namespace MiniProject
{
    public class ProjectPerson
    {
        public int id { get; set; }
        public int project_id { get; set; }
        public int person_id { get; set; }
        public string hours { get; set; }
        List<ProjectsModel> projects { get; set; }
        List<PersonModel> personModels { get; set; }
      
    }
}