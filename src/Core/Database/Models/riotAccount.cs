
using Newtonsoft.Json;

namespace Core.Database.Models
{
    public class riotAccount
    {
         public string id {get; set;}
         public string accountId {get; set;}
         public string puuid {get; set;}
         public string name {get; set;}
         public int profileIconId {get; set;}
         public int summonerLevel {get; set;}
    }
}