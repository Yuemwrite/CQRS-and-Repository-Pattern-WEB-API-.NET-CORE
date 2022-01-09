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
    public class GetCategoryQuery : IRequest<IResponse>
    {
        public int CategoryId { get; set; }

        public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, IResponse>
        {
            private readonly ICategoryRepository _categoryRepository;

            public GetCategoryQueryHandler(ICategoryRepository categoryRepository)
            {
                _categoryRepository = categoryRepository;
            }
            public async Task<IResponse> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
            {
                var currentCategory = await _categoryRepository.GetAsync(_=>_.CategoryId == request.CategoryId);

                return new Response<Category>(currentCategory);

            }
        }

    }
}
