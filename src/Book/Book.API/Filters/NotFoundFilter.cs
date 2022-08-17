using Book.API.Data;
using Book.API.Data.UnitOfWorks;
using Book.API.Models.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace Book.API.Filters
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T : IEntity
    {
        private readonly IUnitOfWork _unitOfWork;
        public NotFoundFilter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValue = context.ActionArguments.Values.FirstOrDefault();

            if(idValue ==null)
            {
                await next.Invoke();
                return;
            }
            var id = (int)idValue;
            var repository = _unitOfWork.GetRepository<T>();
            var anyEntity = await repository.Where(x => x.Id==id).Where(x => !x.IsDelete).SingleOrDefaultAsync();

            if(anyEntity!=null)
            {
                await next.Invoke();
                return;
            }

            context.Result = new NotFoundObjectResult(Response<NoContent>.Fail($"{typeof(T).Name} {id} Not Found",404));
        }
    }
}
