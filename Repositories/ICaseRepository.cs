using casman_WEBAPI.Models;


namespace casman_WEBAPI.Repositories
{
    public interface ICaseRepository
    {
   Task CreateNewCaseAsync(CreateCaseDto dto);
        Task<List<IndemnifierDto>> GetIndemnifiersAsync();
    }
}
