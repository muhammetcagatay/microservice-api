using AutoMapper;
using Book.API.Data;
using Book.API.Data.UnitOfWorks;
using Book.API.Models.Entities;
using Book.API.Models.Request.Authors;
using Book.API.Models.Response.Authors;
using Microsoft.EntityFrameworkCore;

namespace Book.API.Services.Authors
{
    public class AuthorService : IAuthorService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOWork;
        public AuthorService(IUnitOfWork unitOWork, IMapper mapper)
        {
            _unitOWork = unitOWork;
            _mapper = mapper;
        }
        public async Task<Response<AuthorResponse>> GetByIdAsync(int id)
        {
            var authorRepository = _unitOWork.GetRepository<Author>();
            var bookRepository = _unitOWork.GetRepository<BookEntity>();

            var author = await authorRepository.Where(x => x.Id == id).Where(x => !x.IsDelete).FirstOrDefaultAsync();

            var authorResponse = _mapper.Map<AuthorResponse>(author);

            return Response<AuthorResponse>.Success(200, authorResponse);
        }
        public async Task<Response<IEnumerable<Author>>> GetAllAsync()
        {
            var authorRepository = _unitOWork.GetRepository<Author>();

            var authors = await authorRepository.Where(x=> !x.IsDelete).ToListAsync();

            return Response<IEnumerable<Author>>.Success(200, authors);
        }
        public async Task<Response<AuthorWithBooksResponse>> GetAuthorWithBooksAsync(int id)
        {
            var authorRepository = _unitOWork.GetRepository<Author>();

            var author = await authorRepository
                .Include(x=>x.Books)
                .Where(x => x.Id == id)
                .Where(x => !x.IsDelete)
                .FirstOrDefaultAsync();

            var authorWithBooksResponse = _mapper.Map<AuthorWithBooksResponse>(author);

            return Response<AuthorWithBooksResponse>.Success(200, authorWithBooksResponse);
        }
        public async Task<Response<int>> CreateAsync(AuthorRequest request)
        {
            var author = _mapper.Map<Author>(request);
            await _unitOWork.AddAsync(author);
            await _unitOWork.SaveChangesAsync();
            return Response<int>.Success(200,author.Id);
        }
        public async Task<Response<NoContent>> UpdateAsync(int id, AuthorRequest request)
        {
            var authorRepository = _unitOWork.GetRepository<Author>();

            var author = await authorRepository.Where(x => x.Id == id).Where(x => !x.IsDelete).FirstOrDefaultAsync();

            author.FirstName = request.FirstName;
            author.LastName = request.LastName;

            _unitOWork.Update(author);
            await _unitOWork.SaveChangesAsync();

            return Response<NoContent>.Success(200);

        }
        public async Task<Response<NoContent>> DeleteAsync(int id)
        {
            var authorRepository = _unitOWork.GetRepository<Author>();

            var author = await authorRepository.Where(x => x.Id == id).Where(x => !x.IsDelete).FirstOrDefaultAsync();

            author.IsDelete = true;

            _unitOWork.Update(author);
            await _unitOWork.SaveChangesAsync();

            return Response<NoContent>.Success(200);
        }
    }
}
