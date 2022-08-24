
using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.DataAccess
{
    public class UniversityDBContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;

        public UniversityDBContext(DbContextOptions<UniversityDBContext> options, ILoggerFactory loggerFactory) : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        //TODO: Add DbSets (Tables of our Data base)
        public DbSet<User>? Users { get; set; }
        public DbSet<Course>? Course { get; set; }
        public DbSet<Chapter>? Chapters { get; set; }
        public DbSet<Category>? Category { get; set; }
        public DbSet<Student>? Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var logger = _loggerFactory.CreateLogger<UniversityDBContext>();
            /*These options are for doing a full log but there is problem : 
            if you do query select of 1000 rows, you will get a log of all and worst perfomance 
            */
            // optionsBuilder.LogTo(d => logger.Log(LogLevel.Information, d, new[]{
            //     DbLoggerCategory.Database.Name
            // }));
            // optionsBuilder.EnableSensitiveDataLogging();

            /*These options are for doing a filter out of information level where 
            the table save the information with errors detail and sensitive data, 
            this full option has fast perfomance
            */
            optionsBuilder.LogTo(d => logger.Log(LogLevel.Information, d, new[] { DbLoggerCategory.Database.Name }), LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }
    }
}