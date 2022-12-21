using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Backend.Models
{
    public partial class Skills
    {
        /*public Skills()
        {
            CandidateSkills = new HashSet<CandidateSkills>();
        }*/
        [Key]
        public int SkillId { get; set; }
        public string SkillName { get; set; }

        //public ICollection<CandidateSkills> CandidateSkills { get; set; }
    }
}
