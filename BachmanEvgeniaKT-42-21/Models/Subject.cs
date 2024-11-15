using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json.Serialization;


namespace BachmanEvgeniaKT_42_21.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int GroupId { get; set; }
        [JsonIgnore]
        public Group? Group { get; set; }


        // public List<Student> Students { get; set; }

        // public List<GroupSubject> GroupSubjects { get; set; }


        // Для промежуточной таблицы
        // public List<GroupSubject> GroupSubjects { get; set; }
    }
}
