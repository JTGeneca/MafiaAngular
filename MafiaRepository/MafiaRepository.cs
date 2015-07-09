using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using System.Security.Policy;
using MafiaData;
using MafiaRepository.Interfaces;
using GameData;

namespace MafiaRepository
{
    public class MafiaRepository
    {
        private readonly IRepository _repo;

        public MafiaRepository(IRepository mafRepository)
        {
            _repo = mafRepository;
        }
        public void AddGame(Game game)
        {
            _repo.Add<Game>(game);
        }

        public void DeleteGame(int id)
        {
            _repo.Delete<Game>((g) => g.Id == id);
        }
        public Game[] GetAllGames()
        {
            return _repo.All<Game>().ToArray();
        }
        public bool IsIdUsed(int id)
        {
            var role = _repo.SingleOrDefault<Game>((g) => g.Id == id);
            return role != null;
        }

        //public void AddRole(MafiaRole role)
        //{
        //    _repo.Add(role);
        //}

        //public bool IsIdUsed(int id)
        //{
        //    var role = _repo.SingleOrDefault<MafiaRole>((m) => m.Id == id);
        //    return role != null;
        //}

        //public void DeleteRole(int id)
        //{
        //    _repo.Delete<MafiaRole>((m)=> m.Id == id);
        //}

        //public MafiaRole[] GetAllRoles()
        //{
        //    return _repo.All<MafiaRole>().ToArray();
        //} 
    }
}
