using AutoMapper;
using Movie.API.Data.Repositories.Actors;
using Movie.API.Data.Repositories.Films;
using Movie.API.Models.Base;
using Movie.API.Models.Entities;
using Movie.API.Models.Request.Actors;
using Movie.API.Models.Response.Actors;
using Movie.API.Models.Response.Films;

namespace Movie.API.Services.Actors
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;
        private readonly IFilmRepository _filmRepository;
        private readonly IMapper _mapper;
        public ActorService(IActorRepository actorRepository, IFilmRepository filmRepository, IMapper mapper)
        {
            _actorRepository = actorRepository;
            _filmRepository = filmRepository;
            _mapper = mapper;
        }
        public async Task<Response<ResponseGetActor>> GetByIdAsync(string id)
        {
            var actor = await _actorRepository.GetAsync(id);

            var responseGetActor = _mapper.Map<ResponseGetActor>(actor);

            return Response<ResponseGetActor>.Success(200,responseGetActor);
        }
        public async Task<Response<IEnumerable<ResponseGetActor>>> GetAllAsync()
        {
            var actors = await _actorRepository.GetAllAsync();

            var responseGetActors = _mapper.Map<IEnumerable<ResponseGetActor>>(actors);

            return Response<IEnumerable<ResponseGetActor>>.Success(200,responseGetActors);
        }
        public async Task<Response<ResponseGetActorWithFilms>> GetActorWithFilms(string id)
        {
            var actor = await _actorRepository.GetAsync(id);

            var responseGetActorWithFilms = _mapper.Map<ResponseGetActorWithFilms>(actor);

            var films = new List<ResponseGetFilm>();

            if(actor.FilmsId!=null)
            {
                foreach (var item in actor.FilmsId)
                {
                    films.Add(_mapper.Map<ResponseGetFilm>(await _filmRepository.GetAsync(item)));
                }
            }
            responseGetActorWithFilms.Films = films;

            return Response<ResponseGetActorWithFilms>.Success(200, responseGetActorWithFilms);
        }
        public async Task<Response<ResponseCreateActor>> CreateAsync(RequestActor requestActor)
        {
            var actor = _mapper.Map<Actor>(requestActor);

            await _actorRepository.CreateAsync(actor);

            var responseCreateActor = _mapper.Map<ResponseCreateActor>(actor);

            return Response<ResponseCreateActor>.Success(200, responseCreateActor);
        }
        public async Task<Response<ResponseActor>> UpdateAsync(string id, RequestActor requestActor)
        {
            var actor = await _actorRepository.GetAsync(id);

            actor.FirstName = requestActor.FirstName;
            actor.LastName = requestActor.LastName;
            actor.BirthDayDate = requestActor.BirthDayDate;

            await _actorRepository.UpdateAsync(id,actor);

            var responseActor = _mapper.Map<ResponseActor>(actor);

            return Response<ResponseActor>.Success(200, responseActor);
        }
        public async Task<Response<ResponseActor>> RemoveAsync(string id)
        {
            var actor = await _actorRepository.GetAsync(id);

            await _actorRepository.DeleteAsync(id);

            var responseActor = _mapper.Map<ResponseActor>(actor);

            return Response<ResponseActor>.Success(200, responseActor);
        } 
    }
}
