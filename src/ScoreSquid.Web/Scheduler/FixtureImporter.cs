using System.Linq;
using ScoreSquid.Web.Models;
using ScoreSquid.Web.Repositories;

namespace ScoreSquid.Web.Scheduler
{
    public class FixtureImporter : ImporterBase
    {
        public FixtureImporter()
        {
        }

        public FixtureImporter(ITeamRepository teamRepository, IFixtureRepository fixtureRepository) : base(teamRepository, fixtureRepository)
        {
        }

        public void Import(string[] fixtureRows, string divisionName, string divisionIdentifier)
        {
            var division = GetCreateDivison(divisionName, divisionIdentifier);

            var fixtures = (from csvline in fixtureRows.Skip(1)
                           let data = csvline.Split(',')
                           where data.Length > 0
                           select new
                           {
                               Date = data[1],
                               HomeTeam = data[2],
                               AwayTeam = data[3],
                               HomeTeamFullTimeTeamGoals = data[4],
                               AwayTeamFullTimeTeamGoals = data[5],
                               FullTimeResult = data[6],
                               HomeTeamHalfTimeTeamGoals = data[7],
                               AwayTeamHalfTimeTeamGoals = data[8],
                               HalfTimeResult = data[9],
                               HomeTotalShots = data[11],
                               AwayTotalShots = data[12],
                               HomeShotsOnTarget = data[13],
                               AwayShotsOnTarget = data[14],
                               HomeFouls = data[15],
                               AwayFouls = data[16],
                               HomeCorners = data[17],
                               AwayCorners = data[18],
                               HomeYellowCards = data[19],
                               AwayYellowCards = data[20],
                               HomeRedCards = data[21],
                               AwayRedCards = data[22]
                           }).ToList();
            foreach (var fix in fixtures)
            {
                var homeTeam = CreateTeam(fix.HomeTeam, division, TeamRepository);
                var awayTeam = CreateTeam(fix.AwayTeam, division, TeamRepository);


                var fixture = FixtureRepository.GetByHomeTeamNameAndAwayTeamName(fix.HomeTeam, fix.AwayTeam);

                if (fixture == null)
                {
                    fixture = new Fixture();
                    fixture.HomeTeam = homeTeam;
                    fixture.AwayTeam = awayTeam;
                    fixture.Date = fix.Date.TryDateParse();
                }

                FixtureRepository.Save(fixture);   
            }
        }
    }
}