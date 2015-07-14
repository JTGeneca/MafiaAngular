using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MafiaData;

namespace GameData
{
    public class Game
    {
        public int Id { get; set; }
        public MafiaRole[] Roles { get; set; }
        public MafiaRole[] Alive { get; set; }
        public MafiaRole[] Dead { get; set; }
        public string[] Players { get; set; }
        public int Formals { get; set; }
        public int[] FormalArray { get; set; }
        public int[] Votes { get; set; }
        public NightResults[] Results { get; set; }

        
        public Game(int id, MafiaRole[] roles, MafiaRole[] alive, MafiaRole[] dead, string[] player, int formals, int[] formalArray, int[] votes, NightResults[] results)
        {
            this.Id = id;
            this.Roles = roles;
            this.Alive = alive;
            this.Dead = dead;
            this.Players = player;
            this.Formals = formals;
            this.FormalArray = formalArray;
            this.Votes = votes;
            this.Results = results;
        }
    }

    public class NightResults
    {
        public int Mafia { get; set; }
        public int Doctor { get; set; }
        public int PlayerIdx { get; set; }
        public int SerialKiller {get; set; }

        public NightResults()
        {
            this.Mafia = 0;
            this.Doctor = 0;
            this.SerialKiller = 0;
            this.PlayerIdx = 0;
        }
    }
}
