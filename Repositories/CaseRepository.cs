using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using casman_WEBAPI.Models;

namespace casman_WEBAPI.Repositories
{
    public class CaseRepository : ICaseRepository
    {
        private readonly CaseDbContext _context;

        public CaseRepository(CaseDbContext context)
        {
            _context = context;
        }
       
        public async Task CreateNewCaseAsync(CreateCaseDto dto)
        {
            var parameters = new[]
            {
                new SqlParameter("@prac_num", DBNull.Value),
                new SqlParameter("@prac_role", dto.Role ?? "1"),
                new SqlParameter("@prac_last_name", dto.Surname),
                new SqlParameter("@prac_first_name",
                    string.IsNullOrWhiteSpace(dto.FirstName) ? (object)DBNull.Value : dto.FirstName),
                new SqlParameter("@prac_init",
                    string.IsNullOrWhiteSpace(dto.Initials) ? (object)DBNull.Value : dto.Initials),
                new SqlParameter("@prac_sex",
                    string.IsNullOrWhiteSpace(dto.Sex) ? (object)DBNull.Value : dto.Sex),
                new SqlParameter("@userid", string.IsNullOrWhiteSpace(dto.UserId) ? "vignesh." : dto.UserId)
            };

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC dbo.ADM_SP_CREATENEWCASE_PRI @prac_num, @prac_role, @prac_last_name, " +
                "@prac_first_name, @prac_init, @prac_sex, @userid",
                parameters
            );
        }

        // ✅ Get indemnifiers using EF Core ORM style
        public async Task<List<IndemnifierDto>> GetIndemnifiersAsync()
        {
            var tablenameParam = new SqlParameter("@TABLENAME", "t_def_org");
            var valueParam = new SqlParameter("@VALUE", DBNull.Value);

            return await _context.Set<IndemnifierDto>()
                .FromSqlRaw("EXEC dbo.CMS_SP_MASTER_RTR @TABLENAME, @VALUE", tablenameParam, valueParam)
                .ToListAsync();
        }
    }
}
