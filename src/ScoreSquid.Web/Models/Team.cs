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
    
    public partial class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DivisionId { get; set; }
    
        public virtual Division Division { get; set; }
        public virtual Player Player { get; set; }
    }
}
