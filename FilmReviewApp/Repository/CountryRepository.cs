using FilmActorApp.Database;
using FilmReviewApp.Interfaces;
using FilmReviewApp.Models;

namespace FilmReviewApp.Repository
{
    public class CountryRepository : ICountry
    {
        private readonly DataContext _context;
        public CountryRepository(DataContext context)
        {
            _context=context;
        }
        public bool CountryExists(int id)
        {
            return _context.Countries.Any(c=>c.Id == id);
        }

        public bool CreateCountry(Country country)
        {
            _context.Countries.Add(country);
            return Save();
        }

        public ICollection<Actor> GetActorsByCountry(int countryId)
        {
            return _context.Actors.Where(c=>c.Country.Id == countryId).ToList();
        }

        public ICollection<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }

        public Country GetCountry(int id)
        {
            return _context.Countries.Where(c=>c.Id== id).FirstOrDefault();
        }

        public Country GetCountryByActor(int actorId)
        {
            return _context.Actors.Where(a=>a.Id== actorId).Select(a=>a.Country).FirstOrDefault();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }

        public bool UpdateCountry(Country country)
        {
            _context.Countries.Update(country);
            return Save();
        }
    }
}
