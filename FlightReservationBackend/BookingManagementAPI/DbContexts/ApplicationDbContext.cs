using BookingManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagementAPI.DbContexts
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<BookingDetails> BookingDetails { get; set; }

        public DbSet<BookingPassengerReln> PassengerDetails { get; set; }

        public DbSet<BookingSeatNoReln> BookingSeatNumberRelation { get; set; }
    }
}
