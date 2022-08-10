using AutoMapper;
using Movie.API.Data.Repositories.Actors;
using Movie.API.Data.Repositories.Categories;
using Movie.API.Data.Repositories.Films;
using Movie.API.Exceptions;
using Movie.API.Models.Base;
using Movie.API.Models.Entities;
using Movie.API.Models.Request.Films;
using Movie.API.Models.Response.Actors;
using Movie.API.Models.Response.Films;

namespace Movie.API.Services.Films
{
    public class FilmService : IFilmService
    {
        private readonly IActorRepository _actorRepository;
        private readonly IFilmRepository _filmRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public FilmService(IFilmRepository filmRepository, IActorRepository actorRepository, IMapper mapper, ICategoryRepository categoryRepository)
        {
            _filmRepository = filmRepository;
            _actorRepository = actorRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            
        }
        public async Task<Response<ResponseGetFilm>> GetByIdAsync(string id)
        {
            var film = await _filmRepository.GetAsync(id);

            var responseGetFilm = _mapper.Map<ResponseGetFilm>(film);

            if(responseGetFilm == null)
            {
                throw new NotFoundException("Film not found");
            }

            return Response<ResponseGetFilm>.Success(200, responseGetFilm);
        }
        public async Task<Response<IEnumerable<ResponseGetFilm>>> GetAllAsync()
        {
            var films = await _filmRepository.GetAllAsync();

            var responseGetFilms = _mapper.Map<IEnumerable<ResponseGetFilm>>(films);

            return Response<IEnumerable<ResponseGetFilm>>.Success(200, responseGetFilms);
        }
        public async Task<Response<ResponseGetFilmWithActors>> GetFilmWithActors(string id)
        {
            var film = await _filmRepository.GetAsync(id);

            var responseGetFilmWithActors = _mapper.Map<ResponseGetFilmWithActors>(film);

            var actors = new List<ResponseGetActor>();

            if (film.ActorsId != null)
            {
                foreach (var item in film.ActorsId)
                {
                    actors.Add(_mapper.Map<ResponseGetActor>(await _actorRepository.GetAsync(item)));
                }
            }
            responseGetFilmWithActors.Actors = actors;

            return Response<ResponseGetFilmWithActors>.Success(200, responseGetFilmWithActors);
        }
        public async Task<Response<ResponseCreateFilm>> CreateAsync(RequestFilm requestFilm)
        {
            var film = _mapper.Map<Film>(requestFilm);

            await _filmRepository.CreateAsync(film);

            if(film.ActorsId != null)
            {
                foreach (var actorId in film.ActorsId)
                {
                    await _actorRepository.AddFilmAsync(actorId, film.Id);
                }
            }

            await _categoryRepository.AddFilmAsync(film.CategoryId, film.Id);

            var responseCreateFilm = _mapper.Map<ResponseCreateFilm>(film);

            return Response<ResponseCreateFilm>.Success(200, responseCreateFilm);
        }
        public async Task<Response<ResponseFilm>> UpdateAsync(string id, RequestFilm requestFilm)
        {
            var film = _mapper.Map<Film>(requestFilm);

            film.Id = id;

            await _filmRepository.UpdateAsync(id, film);

            var responseFilm = _mapper.Map<ResponseFilm>(film);

            return Response<ResponseFilm>.Success(200, responseFilm);
        }
        public async Task<Response<ResponseFilm>> RemoveAsync(string id)
        {
            var film = await _filmRepository.GetAsync(id);

            foreach (var item in film.ActorsId)
            {
                await _actorRepository.RemoveFilmAsync(item, film.Id);
            }

            await _categoryRepository.RemoveFilmAsync(film.CategoryId, film.Id);

            await _filmRepository.DeleteAsync(id);

            var responseFilm = _mapper.Map<ResponseFilm>(film);

            return Response<ResponseFilm>.Success(200, responseFilm);
        }
    }
}
