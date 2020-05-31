﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FlightControlWeb.Models;
using Microsoft.Extensions.Caching.Memory;

namespace FlightControlWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServersController : ControllerBase
    {
        //private readonly ServersMamager service = new ServersMamager();
        private IMemoryCache cache;
        private IServerManager service;

        public ServersController(IMemoryCache c)
        {
            cache = c;
            service = new ServersMamager(cache);
        }

        //GET: /api/servers
        [HttpGet]
        public IEnumerable<Server> GetAllServers()
        {
            return service.GetAllServers();
        }

        //POST: /api/servers
        [HttpPost]
        public Server AddServer([FromBody] Server s)
        {
            service.AddServer(s);
            return s;
        }

        //DELETE: /api/servers/{id}
        [HttpDelete("{id}")]
        public ActionResult<Server> RemoveServer(string id)
        {
            Server found = service.RemoveServer(id);
            if (found == null)
            {
                return NotFound();
            } else
            {
                return found;
            }
        }
    }
}