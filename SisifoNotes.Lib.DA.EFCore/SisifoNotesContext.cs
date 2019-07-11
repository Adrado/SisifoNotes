using Microsoft.EntityFrameworkCore;
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

        public DbSet<Client> Clients { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}
