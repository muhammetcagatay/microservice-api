using AutoMapper;
using Movie.API.Models.Entities;
using Movie.API.Models.Request.Actors;
using Movie.API.Models.Response.Actors;

namespace Movie.API.Mapping
{
    public class ActorMapping : Profile
    {
        public ActorMapping()
        {
            CreateMap<Actor, ResponseActor>().ReverseMap();
            CreateMap<Actor, ResponseCreateActor>().ReverseMap();
            CreateMap<Actor, ResponseGetActor>().ReverseMap();
            CreateMap<Actor, ResponseGetActorWithFilms>().ReverseMap();
            CreateMap<Actor, RequestActor>().ReverseMap();
        }
    }
}
