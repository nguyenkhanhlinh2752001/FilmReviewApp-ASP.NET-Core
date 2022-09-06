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
            CreateMap<FilmDTO, Film>();

            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();

            CreateMap<Country, CountryDTO>();
            CreateMap<CountryDTO, Country>();

            CreateMap<Actor, ActorDTO>();
            CreateMap<ActorDTO, Actor>();

            CreateMap<Review, ReviewDTO>();
            CreateMap<ReviewDTO, Review>();

            CreateMap<Reviewer, ReviewerDTO>();
            CreateMap<ReviewerDTO, Reviewer>();
        }
    }
}
