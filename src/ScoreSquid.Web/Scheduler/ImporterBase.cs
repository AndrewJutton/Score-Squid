using ScoreSquid.Web.Models;
using ScoreSquid.Web.Repositories;
using ScoreSquid.Web.Repositories.Commands;

namespace ScoreSquid.Web.Scheduler
{
    public abstract class ImporterBase
    {
        private readonly ITeamRepository teamRepository;
        private readonly IFixtureRepository fixtureRepository;

        protected ImporterBase() : this(new TeamRepository(new Commands()), new FixtureRepository(new Commands()))
        {
            
        }

        protected ImporterBase(ITeamRepository teamRepository, IFixtureRepository fixtureRepository)
        {
            this.teamRepository = teamRepository;
            this.fixtureRepository = fixtureRepository;
        }

        protected ITeamRepository TeamRepository
        {
            get { return teamRepository; }
        }

        protected IFixtureRepository FixtureRepository
        {
            get { return fixtureRepository; }
        }

        protected Division GetCreateDivison(string divisionName, string divisionIdentifier)
        {
            var division = TeamRepository.LoadDivisionByIdentifier(divisionIdentifier) ??
                           new Division {Name = divisionName,DivisionIdentifier = divisionIdentifier};

            return division;
        }

        protected Team CreateTeam(string teamName, Division division, ITeamRepository teamRepository)
        {
            var team = teamRepository.LoadTeamByName(teamName);
            if (team == null)
            {
                teamRepository.SaveNewTeam(teamName, division);
                team = teamRepository.LoadTeamByName(teamName);
            }
            return team;
        }
    }
}