﻿using System.ComponentModel.DataAnnotations;

namespace BachmanEvgeniaKT_42_21.Models
{
    public class GroupSubject
    {
        public int GroupId { get; set; }
        public Group? Group { get; set; }

        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }
    }
}
