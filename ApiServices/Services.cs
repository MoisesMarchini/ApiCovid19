using ApiServices.Interfaces;
using Data.Interfaces;
using Domain.ViewModel;
using Domain.Models;

namespace ApiServices
{
    public class Services : IServices
    {
        private readonly IRepository _repository;
        public Services(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ResultCountry>> GetTop10()
        {
            var summary = await _repository.GetSummary();
            var top10Countries = summary.Countries
                        .OrderByDescending(c => c.TotalConfirmed - c.TotalRecovered)
                        .Take(10)
                        .ToList();

            var resultTop10 = new List<ResultCountry>();
            for (int i = 0; i < 10; i++)
            {
                var country = top10Countries[i];
                var resultSingleCountry = new ResultCountry();
                resultSingleCountry.CountryName = country.Country;
                resultSingleCountry.Position = i + 1;
                resultSingleCountry.NumberCases = country.TotalConfirmed - country.TotalRecovered;
                resultTop10.Add(resultSingleCountry);
            }

            return resultTop10;
        }
    }
}