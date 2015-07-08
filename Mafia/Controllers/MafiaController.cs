using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MafiaData;
using MafiaRepository.Interfaces;
using MafiaRepository;


namespace Mafia.Controllers
{
    [AllowCrossSiteJson]
    public class MafiaController : ApiController
    {
        public MafiaRepository.MafiaRepository MafiaRepo;

        public MafiaController(global::MafiaRepository.MafiaRepository mafRepository)
        {
            MafiaRepo = mafRepository;
        }

        // GET: api/Mafia
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Mafia/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Mafia
        public void Post(MafiaRole role)
        {
            if (MafiaRepo.IsIdUsed(role.Id))
            {
                MafiaRepo.DeleteRole(role.Id);
            }
            MafiaRepo.AddRole(role);
        }

        // PUT: api/Mafia/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mafia/5
        public void Delete(int id)
        {
            MafiaRepo.DeleteRole(id);
        }
    }
}
