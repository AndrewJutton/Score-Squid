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
    
    public partial class Player
    {
        public Player()
        {
            this.MiniLeagues = new HashSet<MiniLeague>();
        }
    
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public Nullable<int> Score_Id { get; set; }
        public Nullable<int> MiniLeague_Id { get; set; }
    
        public virtual ICollection<MiniLeague> MiniLeagues { get; set; }
        public virtual MiniLeague MiniLeague { get; set; }
        public virtual Score Score { get; set; }
    }
}