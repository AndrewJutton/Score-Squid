using System;
using ScoreSquid.Web.Domain;

namespace ScoreSquid.Web.Repositories
{
    public interface ITeamRepository
    {
        Team LoadTeamByName(string teamName);
        void SaveNewTeam(string teamName);
        bool TeamExists(string teamName);
    }
}
