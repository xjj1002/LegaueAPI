namespace API.Controllers
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Collections;
    using Core.Database;
    using Core.Database.Models;
    using Core.Services;



    [ApiController]
    [Route("[controller]")]
    public class AccountController
    {
        public ILogger<AccountController> Logger {get;}

        public LeagueContext LeagueContext;

        public RiotApiService RiotApiService;

        public AccountController(ILogger<AccountController> logger, LeagueContext leagueContext, RiotApiService riotApiService)
        {
            Logger = logger;
            LeagueContext = leagueContext;
            RiotApiService = riotApiService;
        }

        [HttpGet("{username}")]
        public async Task<riotAccount> getSummonerinfo(string username)
        {
            Logger.LogInformation("Getting summoner information by summoner name...");
            return await RiotApiService.getSummonerInfo(username);

        }

        [HttpGet("{puuid}/{count}")]
        public async Task<List<string>> getMatchHistory(string puuid, int count)
        {
            Logger.LogInformation("Getting summoner information by summoner name...");
            return await RiotApiService.getMatchHistory(puuid, count);

        }

    }
}