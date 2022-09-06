using AutoMapper;
using FilmReviewApp.DTO;
using FilmReviewApp.Models;

namespace FilmReviewApp.Helper
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Film, FilmDTO>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Country, CountryDTO>();
            CreateMap<Actor, ActorDTO>();
            CreateMap<Review, ReviewDTO>();
            CreateMap<Reviewer, ReviewerDTO>();
        }
    }
}
