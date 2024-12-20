﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
//  using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text.Json.Serialization;

namespace BachmanEvgeniaKT_42_21.Models
{
    public class Group
    {

        public int GroupId { get; set; }


        public string GroupName { get; set; }

        [JsonIgnore]

        public List<Subject>? Subject { get; set; }

        public bool IsValidGroupName()
        {
            //return Regex.Match(GroupName, @"\w*-\d*-\d{2}$").Success;
            return Regex.Match(GroupName, @"^[А-ЯA-Zа-яa-z]*-\d*-\d{2}$").Success;
        }

        // public List<Student> Students { get; set; }

        // public List<Student> Students { get; set; }


        // Для промежуточной таблицы
        // public List<GroupSubject> GroupSubjects { get; set; }
    }
}
