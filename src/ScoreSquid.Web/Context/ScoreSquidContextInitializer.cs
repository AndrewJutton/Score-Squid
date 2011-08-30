using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityFramework;
using System.Data.Entity;
using ScoreSquid.Web.Domain;

namespace ScoreSquid.Web.Context
{
    public class ScoreSquidContextInitializer : DropCreateDatabaseIfModelChanges<ScoreSquidContext>
    {
        protected override void Seed(ScoreSquidContext context)
        {
            var division = new Division { Name = "Championship" };

            var brighton = new Team { Name = "Brighton", Division = division };
            var watford = new Team { Name = "Watford", Division = division };

            var fixture1 = new Fixture { Date = DateTime.Today, HomeTeam = brighton, AwayTeam = watford };

            context.Fixtures.Add(fixture1);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}