using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScoreSquid.Web.Models;
using ScoreSquid.Web.Context;
using ScoreSquid.Web.Repositories;
using ScoreSquid.Web.Repositories.Commands;

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
            Commands commands = new Commands();
            teamRepository = new TeamRepository(commands);
            fixtureRepository = new FixtureRepository(commands);
        }
       
        [TestMethod]
        public void TestResultImporter_ShouldImportResultsFromFile()
        {
            string[] csvlines = File.ReadAllLines(@"C:\Projects\ScoreSquid\csv\E2.csv");

            Division division = new Division
            {
                Name = "Championship"
            };

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
                var homeTeam = CreateTeam(result.HomeTeam, division);
                var awayTeam = CreateTeam(result.AwayTeam, division);

                var matchResult = new Result
                {
                    FullTimeResult = result.FullTimeResult,
                    HalfTimeResult = result.HalfTimeResult,
                    HomeTeam_Corners = result.HomeCorners.TryIntParse(),
                    HomeTeam_FoulsCommitted = result.HomeFouls.TryIntParse(),
                    HomeTeam_FullTimeTeamGoals = result.HomeTeamFullTimeTeamGoals.TryIntParse(),
                    HomeTeam_HalfTimeTeamGoals = result.HomeTeamHalfTimeTeamGoals.TryIntParse(),
                    HomeTeam_RedCards = result.HomeRedCards.TryIntParse(),
                    HomeTeam_ShotsOnTarget = result.HomeShotsOnTarget.TryIntParse(),
                    HomeTeam_TotalShots = result.HomeTotalShots.TryIntParse(),
                    HomeTeam_YellowCards = result.HomeYellowCards.TryIntParse(),
                    AwayTeam_Corners = result.AwayCorners.TryIntParse(),
                    AwayTeam_FoulsCommitted = result.AwayFouls.TryIntParse(),
                    AwayTeam_FullTimeTeamGoals = result.AwayTeamFullTimeTeamGoals.TryIntParse(),
                    AwayTeam_HalfTimeTeamGoals = result.AwayTeamHalfTimeTeamGoals.TryIntParse(),
                    AwayTeam_RedCards = result.AwayRedCards.TryIntParse(),   
                    AwayTeam_ShotsOnTarget = result.AwayShotsOnTarget.TryIntParse(),
                    AwayTeam_TotalShots = result.AwayTotalShots.TryIntParse(),
                    AwayTeam_YellowCards = result.AwayYellowCards.TryIntParse()
                };

                var fixture = fixtureRepository.GetByHomeTeamNameAndAwayTeamName(result.HomeTeam, result.AwayTeam);

                if (fixture == null)
                {
                    fixture = new Fixture();
                    fixture.HomeTeam = homeTeam;
                    fixture.AwayTeam = awayTeam;
                    fixture.Date = result.Date.TryDateParse();
                    fixture.Result = matchResult;
                }

                fixtureRepository.Save(fixture);
            }

             Assert.IsTrue(results.Count > 0);
        }

        private Team CreateTeam(string teamName, Division division)
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
