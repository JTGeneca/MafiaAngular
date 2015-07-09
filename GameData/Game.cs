using System;
using System.Collections.Generic;
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

        public Game(int id, MafiaRole[] roles, MafiaRole[] alive, MafiaRole[] dead)
        {
            this.Id = id;
            this.Roles = roles;
            this.Alive = alive;
            this.Dead = dead;
        }
    }
}
