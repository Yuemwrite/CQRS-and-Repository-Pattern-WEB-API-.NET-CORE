using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.Categories.Queries
{
    public class GetCategoriesQuery : IRequest<IResponse>
    {
        public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IResponse>
        {
            private readonly ICategoryRepository _categoryRepository;

            public GetCategoriesQueryHandler(ICategoryRepository categoryRepository)
            {
                _categoryRepository = categoryRepository;
            }
            public async Task<IResponse> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
            {
                var categories = await _categoryRepository.GetListAsync();
                return new Response<IEnumerable<Category>>(categories);
            }
        }
    }
}
