using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScoreSquid.Web.Context;
using ScoreSquid.Web.Models;

namespace ScoreSquid.Web.Repositories
{
    public interface IDivisionRepository
    {
    }

    public class DivisionRepository
    {
        private IDivisonCommands commands;

        public DivisionRepository(IDivisonCommands commands)
        {
            this.commands = commands;
        }

        public List<Division> GetAll()
        {
            using (var context = new ScoreSquidContext())
            {
                return commands.GetAllDivisions(context);
            }
        }

        public Division GetByIdentifier(string leagueIdentifier)
        {
            using (var context = new ScoreSquidContext())
            {
                return commands.GetDivisionByIdentifier(context, leagueIdentifier);
            }
        }

        public void Save(Division division)
        {
            using (var context = new ScoreSquidContext())
            {
                commands.SaveDivison(context, division);
            }
        }
    }

    public interface IDivisonCommands
    {
        List<Division> GetAllDivisions(ScoreSquidContext context);
        Division GetDivisionByIdentifier(ScoreSquidContext context, string leagueIdentifier);
        void SaveDivison(ScoreSquidContext context, Division division);
    }
}