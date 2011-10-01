using System;
using System.Collections.Generic;
using ScoreSquid.Web.Models;

namespace ScoreSquid.Web.Repositories
{
    public interface ITeamRepository
    {
        Team LoadTeamByName(string teamName);

        void SaveNewTeam(string teamName, Division division);

        bool TeamExists(string teamName);

        Division LoadDivisionByIdentifier(string divisionIdentifier);

        List<Team> GetAll();

        Team LoadById(int id);
    }
}
