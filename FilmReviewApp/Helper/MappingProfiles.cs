using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmReviewApp.DTO;
using FilmReviewApp.Models;

namespace FilmReviewApp.Helper
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles(){
            CreateMap<Film, FilmDTO>();
        }
    }
}
