﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using GameData;
using MafiaData;
using MafiaRepository.Interfaces;
using MafiaRepository;


namespace Mafia.Controllers
{
    //[EnableCors(origins: "http://mywebclient.azurewebsites.net", headers: "*", methods: "*")]
    public class MafiaController : ApiController
    {
        public MafiaRepository.MafiaRepository MafiaRepo;

        public MafiaController(MafiaRepository.MafiaRepository mafRepository)
        {
            MafiaRepo = mafRepository;
        }

        public void Options()
        {
            
        }
        // GET: api/Mafia
        public Game[] Get()
        {
            return MafiaRepo.GetAllGames();
        }

        // GET: api/Mafia/5
        public Game Get(int id)
        {
            return MafiaRepo.GetGame(id);
        }

        // POST: api/Mafia
        public void Post(Game game)
        {
            if (MafiaRepo.IsIdUsed(game.Id))
            {
                MafiaRepo.DeleteGame(game.Id);
            }
            MafiaRepo.AddGame(game);
        }

        // PUT: api/Mafia/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mafia/5
        public void Delete(int id)
        {
            MafiaRepo.DeleteGame(id);
        }
    }
}
