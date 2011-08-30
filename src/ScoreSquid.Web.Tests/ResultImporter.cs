using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScoreSquid.Web.Domain;
using ScoreSquid.Web.Context;
using ScoreSquid.Web.Repositories;

namespace ScoreSquid.Web.Tests
{
    [TestClass]
    public class ResultImporter
    {
        ITeamRepository teamRepository;
        IFixtureRepository fixtureRepository;

        [TestInitialize]
        public void Setup()
        {
            IScoreSquidContext context = new ScoreSquidContext();
            teamRepository = new TeamRepository(context);
            fixtureRepository = new FixtureRepository(context);
        }
       
        [TestMethod]
        public void TestResultImporter_ShouldImportResultsFromFile()
        {
            string[] csvlines = File.ReadAllLines(@"C:\Projects\ScoreSquid\csv\E2.csv");

            var results = (from csvline in csvlines.Skip(1)
                        let data = csvline.Split(',')
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


            foreach (var result in results)
            {
                var homeTeam = CreateTeam(result.HomeTeam);
                var awayTeam = CreateTeam(result.AwayTeam);

                var matchResult = new Result
                {
                    FullTimeResult = result.FullTimeResult,
                    HalfTimeResult = result.HalfTimeResult,
                    HomeTeam = new Stats
                    {
                        Corners = result.HomeCorners.TryIntParse(),
                        FoulsCommitted = result.HomeFouls.TryIntParse(),
                        FullTimeTeamGoals = result.HomeTeamFullTimeTeamGoals.TryIntParse(),
                        HalfTimeTeamGoals = result.HomeTeamHalfTimeTeamGoals.TryIntParse(),
                        RedCards = result.HomeRedCards.TryIntParse(),   
                        ShotsOnTarget = result.HomeShotsOnTarget.TryIntParse(),
                        TotalShots = result.HomeTotalShots.TryIntParse(),
                        YellowCards = result.HomeYellowCards.TryIntParse()
                    },
                    AwayTeam = new Stats
                    {
                        Corners = result.AwayCorners.TryIntParse(),
                        FoulsCommitted = result.AwayFouls.TryIntParse(),
                        FullTimeTeamGoals = result.AwayTeamFullTimeTeamGoals.TryIntParse(),
                        HalfTimeTeamGoals = result.AwayTeamHalfTimeTeamGoals.TryIntParse(),
                        RedCards = result.AwayRedCards.TryIntParse(),   
                        ShotsOnTarget = result.AwayShotsOnTarget.TryIntParse(),
                        TotalShots = result.AwayTotalShots.TryIntParse(),
                        YellowCards = result.AwayYellowCards.TryIntParse()
                    }
                };

                var fixture = fixtureRepository.LoadFixtureBy(result.HomeTeam, result.AwayTeam);

                if (fixture == null)
                {
                    fixture = new Fixture();
                    fixture.HomeTeam = homeTeam;
                    fixture.AwayTeam = awayTeam;
                    fixture.Date = result.Date.TryDateParse();
                    fixture.Result = matchResult;
                }

                fixtureRepository.SaveFixtureWithResult(fixture);
            }

            Assert.IsTrue(results.Count > 0);
        }

        private Team CreateTeam(string teamName)
        {
            var team = teamRepository.LoadTeamByName(teamName);
            if (team == null)
            {
                teamRepository.SaveNewTeam(teamName);
                team = teamRepository.LoadTeamByName(teamName);
            }
            return team;
        }
    }

    public static class TypeExtensions
    {
        public static int TryIntParse(this string value)
        {
            var tryValue = 0;
            int.TryParse(value, out tryValue);
            return tryValue;
        }

        public static DateTime TryDateParse(this string value)
        {
            DateTime tryValue = DateTime.Today;
            DateTime.TryParse(value, out tryValue);
            return tryValue;
        }
    }
}
