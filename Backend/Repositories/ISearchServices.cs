using Backend.Models;
using System.Collections.Generic;

namespace backend.Repositories
{
    public interface ISearchServices
    {
        List<CandidateSkills> GetAllCandidateSkills();

        List<User> GetUsers(string input);

        List<CandidateSkills> GetCandidateSkills(int id);

        List<CandidateSkills> SearchResultbySkills(string skill);

        List<Skills> GetAllSkills();
    }
}