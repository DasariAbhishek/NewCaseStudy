using Backend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Backend.Models
{
    public partial class CandidateSkills
    {
        [Key]
        public int SkillSetId { get; set; }
        public int? UserId { get; set; }
        public int? SkillId { get; set; }
        public int? Rating { get; set; }

        //public int? DocumentId { get; set; }

        //public virtual Documents Document { get; set; }
        public Skills Skill { get; set; }
        public User User { get; set; }
    }
}
