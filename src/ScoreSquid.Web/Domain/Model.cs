using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;

namespace ScoreSquid.Web.Domain
{
    public class Entity
    {
        public int Id { get; set; }
    }

    public class Season : Entity
    {
        public int StartYear { get; set; }
        public int EndYear { get; set; }
    }

    public class Division : Entity
    {
        public string Name { get; set; }
    }

    public class Team : Entity
    {
        public string Name { get; set; }
        public Division Division { get; set; }
    }

    public class Fixture : Entity
    {
        public DateTime Date { get; set; }
        public virtual Team HomeTeam { get; set; }
        public virtual Team AwayTeam { get; set; }
        public Result Result { get; set; }
    }

    public class Result : Entity
    {
        public string FullTimeResult { get; set; }
        public string HalfTimeResult { get; set; }
        public virtual Stats HomeTeam { get; set; }
        public virtual Stats AwayTeam { get; set; }
    }

    [ComplexType]
    public class Stats
    {
        public int FullTimeTeamGoals { get; set; }
        public int HalfTimeTeamGoals { get; set; }
        public int TotalShots { get; set; }
        public int ShotsOnTarget { get; set; }
        public int ShotsHitPost { get; set; }
        public int Corners { get; set; }
        public int FoulsCommitted { get; set; }
        public int Offsides { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
    }

    public class MiniLeague : Entity
    {
        public string Name { get; set; }
        public string Pin { get; set; }
        public List<Player> Players { get; set; }
        public Player Chairman { get; set; }
    }

    public class Player : Entity
    {
        [Required(ErrorMessage = "Required field"), Email, StringLength(60, ErrorMessage = "Max 60 chars")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Required field")]
        [StringLength(20, ErrorMessage = "Max 20 chars")]
        public string Password { get; set; }
        [Required]
        [EqualTo("Password")]
        [NotMapped]
        public string PasswordConfirm { get; set; }
        [Required(ErrorMessage = "Required field"), StringLength(40, ErrorMessage = "Max 40 chars")]
        public string Forename { get; set; }
        [Required(ErrorMessage = "Required field"), StringLength(40, ErrorMessage = "Max 40 chars")]
        public string Surname { get; set; }
        public Score Score { get; set; }
    }

    public class Score : Entity
    {
        public int WeekScore { get; set; }
        public int MonthScore { get; set; }
        public int TotalScore { get; set; }
    }
}