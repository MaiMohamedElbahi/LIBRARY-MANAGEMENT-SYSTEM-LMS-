using System.Data.Common;
using LIBRARY_MANAGEMENT_SYSTEM__LMS_.Models;
using Microsoft.EntityFrameworkCore;


namespace LIBRARY_MANAGEMENT_SYSTEM__LMS_.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<BorrowRecord> BorrowRecords { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Member> Members { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasMany(e => e.Books).WithOne(e => e.Category).HasForeignKey(e => e.CategoryId);
            modelBuilder.Entity<Member>().HasMany(e => e.BorrowRecords).WithOne(e => e.Member).HasForeignKey(e => e.MemberId);
            modelBuilder.Entity<Book>().HasMany(e => e.BorrowRecords).WithOne(e => e.Book).HasForeignKey(e => e.BookId);

            modelBuilder.Entity<Category>().HasIndex(e => e.Name).IsUnique();
            modelBuilder.Entity<Member>().HasIndex(e => e.Email).IsUnique();
            modelBuilder.Entity<BorrowRecord>().Property(e => e.BorrowDate).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Book>().Property(e => e.Price).HasPrecision(10, 2);

            modelBuilder.Entity<Category>().HasKey(e => e .CategoryId);
            modelBuilder.Entity<Member>().HasKey(e => e.MemberId);
            modelBuilder.Entity<BorrowRecord>().HasKey(e => e.BorrowRecordId);
            modelBuilder.Entity<Book>().HasKey(e => e.BookId);

            // Categories
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    Name = "Programming"
                },
                new Category
                {
                    CategoryId = 2,
                    Name = "Science Fiction"
                },
                new Category
                {
                    CategoryId = 3,
                    Name = "History"
                },
                new Category
                {
                    CategoryId = 4,
                    Name = "Self Development"
                }
            );

            // Books
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookId = 1,
                    Title = "Clean Code",
                    Author = "Robert Martin",
                    PublishedYear = 2008,
                    Price = 45.99m,
                    AvailableCopies = 5,
                    CategoryId = 1
                },
                new Book
                {
                    BookId = 2,
                    Title = "The Pragmatic Programmer",
                    Author = "David Thomas",
                    PublishedYear = 1999,
                    Price = 39.99m,
                    AvailableCopies = 3,
                    CategoryId = 1
                },
                new Book
                {
                    BookId = 3,
                    Title = "1984",
                    Author = "George Orwell",
                    PublishedYear = 1949,
                    Price = 25.50m,
                    AvailableCopies = 7,
                    CategoryId = 2
                },
                new Book
                {
                    BookId = 4,
                    Title = "Atomic Habits",
                    Author = "James Clear",
                    PublishedYear = 2018,
                    Price = 30.00m,
                    AvailableCopies = 10,
                    CategoryId = 4
                }
            );

            // Members
            modelBuilder.Entity<Member>().HasData(
                new Member
                {
                    MemberId = 1,
                    FullName = "Ahmed Hassan",
                    Email = "ahmed@example.com",
                    PhoneNumber = "01012345678"
                },
                new Member
                {
                    MemberId = 2,
                    FullName = "Sara Mohamed",
                    Email = "sara@example.com",
                    PhoneNumber = "01123456789"
                },
                new Member
                {
                    MemberId = 3,
                    FullName = "Omar Ali",
                    Email = "omar@example.com",
                    PhoneNumber = null
                }
            );

            // Borrow Records
            modelBuilder.Entity<BorrowRecord>().HasData(
                new BorrowRecord
                {
                    BorrowRecordId = 1,
                    BorrowDate = new DateTime(2026, 9, 1),
                    ReturnDate = new DateTime(2026, 9, 10),
                    BookId = 1,
                    MemberId = 1
                },
                new BorrowRecord
                {
                    BorrowRecordId = 2,
                    BorrowDate = new DateTime(2026, 9, 5),
                    ReturnDate = null,
                    BookId = 2,
                    MemberId = 2
                },
                new BorrowRecord
                {
                    BorrowRecordId = 3,
                    BorrowDate = new DateTime(2026, 9, 12),
                    ReturnDate = new DateTime(2026, 9, 20),
                    BookId = 3,
                    MemberId = 1
                },
                new BorrowRecord
                {
                    BorrowRecordId = 4,
                    BorrowDate = new DateTime(2026, 9, 15),
                    ReturnDate = null,
                    BookId = 4,
                    MemberId = 3
                }
            );
        }
    }
}
