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
    
    public partial class MiniLeague
    {
        public MiniLeague()
        {
            this.Players = new HashSet<Player>();
            this.MiniLeagueFixtures = new HashSet<MiniLeagueFixture>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pin { get; set; }
        public Nullable<int> Chairman_Id { get; set; }
    
        public virtual Player Player { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<MiniLeagueFixture> MiniLeagueFixtures { get; set; }
    }
}
