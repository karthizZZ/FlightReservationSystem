using InventoryManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementAPI.DbContexts
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Airline> Airline { get; set; }

        public DbSet<Airport> Airport { get; set; }

        public DbSet<AirlineSchedule> AirlineSchedule { get; set; }

        public DbSet<AirlineScheduleDayReln> AirlineScheduleDayReln { get; set; }

        public DbSet<AirlineSeatCostReln> AirlineSeatCostReln { get; set; }

        public DbSet<AirlineSearch> AirlineSearchDetails { get; set; }
    }
}
