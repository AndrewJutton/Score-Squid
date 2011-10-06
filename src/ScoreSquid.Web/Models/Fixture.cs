
//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace ScoreSquid.Web.Models
{

using System;
using System.Collections.Generic;

public partial class Fixture
{

    public Fixture()
    {

        this.MiniLeagueFixtures = new HashSet<MiniLeagueFixtures>();

    }


    public int Id { get; set; }

    public System.DateTime Date { get; set; }

    public int HomeTeamId { get; set; }

    public int AwayTeamId { get; set; }



    public virtual Team HomeTeam { get; set; }

    public virtual Team AwayTeam { get; set; }

    public virtual Result Result { get; set; }

    public virtual ICollection<MiniLeagueFixtures> MiniLeagueFixtures { get; set; }

}

}
