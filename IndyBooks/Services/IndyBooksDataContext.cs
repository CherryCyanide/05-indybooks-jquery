using IndyBooks.Models;
using Microsoft.EntityFrameworkCore;

namespace IndyBooks.Services;

    public class IndyBooksDataContext:DbContext
    {
        public IndyBooksDataContext(DbContextOptions<IndyBooksDataContext> options) : base(options)
        {}

        //Define DbSets for Collections representing DB tables
        public DbSet<Book> Books { get; set; }
        public DbSet<Writer> Writers { get; set; }

        // Used to fine tune certain aspects of the Data model
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //This code makes sure each Book always includes its Writer information
            modelBuilder.Entity<Book>()
                .Navigation(b=>b.Author)
                .AutoInclude();
            //This code cause ALL books by that Author to be deleted if the Writer is deleted
            // NOTE: Other DeleteBehavior is to not allow the deletion, or set the books author to null
            modelBuilder.Entity<Book>()
                .HasOne(b=>b.Author)
                .WithMany(a=>a.Books)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }

