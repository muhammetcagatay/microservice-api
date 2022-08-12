using AutoMapper;
using Book.API.Data;
using Book.API.Data.UnitOfWorks;
using Book.API.Models.Entities;
using Book.API.Models.Request.Books;
using Book.API.Models.Response.Books;
using Microsoft.EntityFrameworkCore;

namespace Book.API.Services.BookEntities
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork<BookEntity> _unitOfWork;
        private readonly IMapper _mapper;
        public BookService(IMapper mapper, IUnitOfWork<BookEntity> unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Response<BookResponse>> GetByIdAsync(int id)
        {
            var bookRepository = _unitOfWork.GetRepository();

            var book = await bookRepository.Where(x => x.Id == id).Where(x => !x.IsDelete).SingleAsync();

            var bookResponse = _mapper.Map<BookResponse>(book);

            return Response<BookResponse>.Success(200, bookResponse);
        }
        public async Task<Response<IEnumerable<BookResponse>>> GetAllAsync()
        {
            var bookRepository = _unitOfWork.GetRepository();

            var books = await bookRepository.Where(x => !x.IsDelete).ToListAsync();

            var booksResponse = _mapper.Map<IEnumerable<BookResponse>>(books);

            return Response<IEnumerable<BookResponse>>.Success(200, booksResponse);
        }       
        public async Task<Response<int>> CreateAsync(BookRequest request)
        {
            var book = _mapper.Map<BookEntity>(request);

            await _unitOfWork.AddAsync(book);
            await _unitOfWork.SaveChangesAsync();

            return Response<int>.Success(200, book.Id);
        }
        public async Task<Response<NoContent>> UpdateAsync(int id, BookRequest request)
        {
            var bookRepository = _unitOfWork.GetRepository();

            var book = await bookRepository.Where(x => x.Id == id).Where(x => !x.IsDelete).SingleAsync();

            book.Title = request.Title;
            book.Description = request.Description;
            book.PrintLenght = request.PrintLenght;
            book.CategoryId = request.CategoryId;
            book.AuthorId = request.AuthorId;

            _unitOfWork.Update(book);
            await _unitOfWork.SaveChangesAsync();

            return Response<NoContent>.Success(200);
        }
        public async Task<Response<NoContent>> DeleteAsync(int id)
        {
            var bookRepository = _unitOfWork.GetRepository();

            var book = await bookRepository.Where(x => x.Id == id).Where(x => !x.IsDelete).SingleAsync();

            book.IsDelete = true;

            _unitOfWork.Update(book);
            await _unitOfWork.SaveChangesAsync();

            return Response<NoContent>.Success(200);
        }
    }
}
