
using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Repositories
{
    public class SearchServices : ISearchServices
    {
        private readonly CGDbContext _context;
        private readonly ILogger<User> _log;

        public SearchServices(CGDbContext context, ILogger<User> log)
        {
            _context = context;
            _log = log;
        }

        public List<CandidateSkills> SearchResultbySkills(string skill)
        {
            
            try
            {
                //skillname = _context.skills.FirstOrDefault(s => s.SkillName == dto.SkillName).SkillName;
                //List<CandidateSkills> users = _context.candidateSkills.Include(u => u.User).Include(s => s.Skill).Select(c => c.UserId).Where(u => u.Skill.SkillName == dto.SkillName).ToList();
                //List<User> users = _context.User.Where(u => u.CandidateSkills. == dto.SkillName).ToList();


                List<CandidateSkills> users = _context.candidateSkills.Include(u => u.User).Include(s => s.Skill).Include(r => r.User.Roles).Where(u => u.Skill.SkillName.Contains(skill)).ToList();
                return users;
            }
            catch
            {
                return null;
            }

        }

        #region 'SearchbyName or mail'
        public List<User> GetUsers(string input)
        {
            try
            {
                List<User> users = _context.User.Include(r => r.Roles).Where(u => (u.FirstName +" "+ u.LastName).Contains(input)  || u.CorpMail.Contains(input)).ToList();
                return users;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        public List<Skills> GetAllSkills()
        {
            try
            {
                List<Skills> skills = _context.skills.ToList();
                return skills;
            }
            catch
            {
                return null;
            }
        }
        //public List<>
        #region 'GetCandidateSkills'
        public List<CandidateSkills> GetCandidateSkills(int id)
        {
            try
            {
                return _context.candidateSkills.Include(s => s.Skill).Include(u => u.User).Where(c => c.UserId == id).ToList();
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region 'GetAllCandidateSkills'
        public List<CandidateSkills> GetAllCandidateSkills()
        {
            try
            {
                return _context.candidateSkills.Include(s => s.Skill).Include(u => u.User).ToList();
            }
            catch
            {
                return null;
            }
        }
        #endregion

        /*public async Task<IEnumerable<CandidateSkills>> SearchResultbySkill(string dto)
        {
            IQueryable<CandidateSkills> query = _context.candidateSkills;

            if (!string.IsNullOrEmpty(dto))
            {
                query = (IQueryable<CandidateSkills>)query.Where(u => u.Skill.SkillName.Contains(dto)).ToList();
            }
            return await query.ToListAsync();
        }*/
    }
}
