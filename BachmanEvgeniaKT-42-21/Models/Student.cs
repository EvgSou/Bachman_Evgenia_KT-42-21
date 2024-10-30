﻿using BachmanEvgeniaKT_42_21.Models;
using System.ComponentModel.DataAnnotations;

// using System.Collections.Generic;


namespace BachmanEvgeniaKT_42_21.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public int GroupId { get; set; }

        public Group Group { get; set; }
        
        
        
        
        
        
        
        // Для промежуточной таблицы
        // public List<Subject> Subjects { get; set; }
    }
}


