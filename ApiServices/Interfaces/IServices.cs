using Domain.ViewModel;

namespace ApiServices.Interfaces
{
    public interface IServices
    {
        public Task<List<ResultCountry>> GetTop10();
    }
}