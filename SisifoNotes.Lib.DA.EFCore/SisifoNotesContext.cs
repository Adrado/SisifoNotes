using Microsoft.EntityFrameworkCore;
using SisifoNotes.Lib.Core;
using SisifoNotes.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SisifoNotes.Lib.DA.EFCore
{
    public class SisifoNotesContext :DbContext
    {
        public SisifoNotesContext(DbContextOptions<SisifoNotesContext> options)
            : base (options)
        {  }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<List> Lists { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Text>  Texts { get; set; }
    }
}
