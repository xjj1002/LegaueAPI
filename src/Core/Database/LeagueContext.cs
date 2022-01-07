namespace Core.Database
{

    using Microsoft.EntityFrameworkCore;
    using Core.Database.Models;
    public class LeagueContext: DbContext
    {
        public LeagueContext(DbContextOptions<LeagueContext> options) : base(options)
        {
            
        }


        //need shit for database
    }
}