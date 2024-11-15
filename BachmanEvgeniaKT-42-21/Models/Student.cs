using BachmanEvgeniaKT_42_21.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

// using System.Collections.Generic;


namespace BachmanEvgeniaKT_42_21.Models
{
    public class Student
    {
        [JsonIgnore]
        public int StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public int GroupId { get; set; }

        [JsonIgnore]

        public Group? Group { get; set; }


        //
        public bool DeletionStatus { get; set; } //= false;




        // Для промежуточной таблицы
        // public List<Subject> Subjects { get; set; }
    }
}


