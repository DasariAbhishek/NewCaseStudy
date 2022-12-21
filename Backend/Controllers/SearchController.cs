
using backend.Repositories;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("api/SearchCandidate")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchServices _repo;

        public SearchController(ISearchServices repo)
        {
            _repo = repo;
        }

        #region "Search Candidate"
        [HttpGet("{skill}")]
        //[Route("Search")]
        public IActionResult SearchResult(string skill)
        {
             List<CandidateSkills> users = _repo.SearchResultbySkills(skill);
             if (users.Count > 0)
             {
                 return Ok(users);
             }
             return NotFound(new { msg = "No Candidate found with this Skill" });
        }
        #endregion

        #region 'Search user by name or mail'
        [HttpGet("Search/{input}")]
        //[Route("Search")]
        public IActionResult SearchUsers(string input)
        {
            List<User> users = _repo.GetUsers(input);
            if (users.Count > 0)
            {
                return Ok(users);
            }
            return NotFound(new { msg = "No Candidate found" });
        }
        #endregion

        [HttpGet("Skills")]
        public IActionResult GetSkills()
        {
            List<Skills> skills = _repo.GetAllSkills();
            if(skills.Count>0)
            {
                return Ok(skills);
            }
            return NotFound(new { msg = "No skills found" });
        }

        #region "GetCnadidatebyId"
        [HttpGet]
        [Route("GetCandidate")]
        public IActionResult GetCandidate(int id)
        {
            List<CandidateSkills> candidate = _repo.GetCandidateSkills(id);

            if(candidate == null)
            {
                return NotFound(new { msg = "Candidate not found for this Search" });
            }
            return Ok(candidate);
        }
        #endregion

        #region "GetAllCandidate"
        [HttpGet]
        [Route("GetAllCandidate")]
        public IActionResult GetAllCandidate()
        {
            List<CandidateSkills> candidate = _repo.GetAllCandidateSkills();

            if (candidate == null)
            {
                return NotFound(new { msg = "There are no candidates" });
            }
            return Ok(candidate);
        }
        #endregion

        /*[HttpGet]
        [Route("Search")]
        public async Task<ActionResult<IEnumerable<CandidateSkills>>> SearchResultbySkill(string dto)
        {
            try
            {
                var user = await _repo.SearchResultbySkills(dto);
                if (user != null)
                {
                    return Ok(user);
                }
                return NotFound();
            }
            catch(Exception e)
            {
                throw;
            }
            
        }*/
    }
}
