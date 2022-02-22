using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Persistence
{
    public class GloboTicketDbContext : DbContext
    {
        public GloboTicketDbContext(DbContextOptions<GloboTicketDbContext> options) : base(options)
        {
        }
        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
