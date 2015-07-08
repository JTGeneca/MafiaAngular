using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using MafiaData;
using MafiaRepository.Interfaces;

namespace MafiaRepository
{
    public class MafiaRepository
    {
        private readonly IRepository _repo;

        public MafiaRepository(IRepository mafRepository)
        {
            _repo = mafRepository;
        }

        public void AddRole(MafiaRole role)
        {
            _repo.Add(role);
        }

        public bool IsIdUsed(int id)
        {
            var role = _repo.SingleOrDefault<MafiaRole>((m) => m.Id == id);
            if (role != null)
            {
                return true;
            }
            return false;
        }

        public void DeleteRole(int id)
        {
            _repo.Delete<MafiaRole>((m)=> m.Id == id);
        }

        public MafiaRole[] GetAllRoles()
        {
            return _repo.All<MafiaRole>().ToArray();
        } 
    }
}
