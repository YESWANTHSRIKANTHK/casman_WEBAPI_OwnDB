    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Concurrent;

    namespace casman_WEBAPI.Models
    {
        public class CaseDbContext : DbContext
        {
        public CaseDbContext(DbContextOptions<CaseDbContext> options) : base(options) { }
        public DbSet<IndemnifierDto> Indemnifiers { get; set; }
    }
    }
    