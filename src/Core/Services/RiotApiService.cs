namespace Core.Services
{

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Configuration;


    using System.Threading.Tasks;

    using System.Collections.Generic;
    using System.Linq;
    using System;

    using Microsoft.EntityFrameworkCore;
    using Core.Database;
    using Core.Database.Models;


    //using for Furl Http request wrapper
    //linke to FLurl github https://github.com/tmenier/Flurl
    using Flurl;
    using Flurl.Http;
    using Microsoft.Extensions.Options;
    using Core.Options;

    public class RiotApiService
    {
        

        public ILogger<RiotApiService> Logger { get; }
        public string RiotApiKey { get; }
        public string baseUrl = "https://na1.api.riotgames.com/lol";

        public string baseUrlmatches = "https://americas.api.riotgames.com/lol";
        public LeagueContext LeagueContext { get; }


        public RiotApiService(IOptions<RiotOptions> options, LeagueContext leagueContext, ILogger<RiotApiService> logger)
        {
            RiotApiKey = options.Value.Riotkey; 
            LeagueContext = leagueContext;
            Logger = logger;
        }

        public async Task<riotAccount> getSummonerInfo(string username)
        {
            Logger.LogInformation("Getting summoner information by summoner name...");
            Logger.LogInformation("API KEY PLEASE...."+RiotApiKey);
            var result = await baseUrl
                .AppendPathSegment("/summoner/v4/summoners/by-name")
                .AppendPathSegment(username)
                .WithHeader("X-Riot-Token",RiotApiKey)
                .GetJsonAsync<Database.Models.riotAccount>();
            return result;
            
        }

        public async Task<List<string>> getMatchHistory(string puuid, int count)
        {
            Logger.LogInformation("Getting summoner information by summoner name...");
            Logger.LogInformation("API KEY PLEASE...."+RiotApiKey);

            var matchIds = await baseUrlmatches
                .AppendPathSegments("match/v5/matches/by-puuid",puuid,"ids")
                .SetQueryParams(new 
                {
                    count
                })
                .WithHeader("X-Riot-Token",RiotApiKey)
                .GetJsonAsync<List<string>>();
            return matchIds;

            


            
        }


    }
}