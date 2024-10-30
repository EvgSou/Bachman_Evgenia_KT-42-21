using System.ComponentModel.DataAnnotations;
//  using System.Collections.Generic;

namespace BachmanEvgeniaKT_42_21.Models
{
    public class Group
    {

        public int GroupId { get; set; }


        public string GroupName { get; set; }

        public List<Subject>? Subject { get; set; }



        // public List<Student> Students { get; set; }

        // public List<Student> Students { get; set; }


        // Для промежуточной таблицы
        // public List<GroupSubject> GroupSubjects { get; set; }
    }
}
