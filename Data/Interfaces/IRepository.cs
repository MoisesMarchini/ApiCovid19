using Domain.Models;

namespace Data.Interfaces
{
    public interface IRepository
    {
        public Task<Summary> GetSummary();
    }
}