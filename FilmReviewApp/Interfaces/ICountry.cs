using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmReviewApp.Models;

namespace FilmReviewApp.Interfaces
{
    public interface ICountry
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int id);
        Country GetCountryByActor(int id);
        ICollection<Actor> GetActorsByCountry(int id);
        bool CountryExists(int id);
        bool CreateCountry(Country country);
        bool UpdateCountry(Country country);
        bool DeleteCountry(Country country);
        bool Save();
    }
}
