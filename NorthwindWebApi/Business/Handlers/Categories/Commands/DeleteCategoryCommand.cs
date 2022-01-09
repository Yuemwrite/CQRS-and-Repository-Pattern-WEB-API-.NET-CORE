using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.Categories.Commands
{
    public class DeleteCategoryCommand : IRequest<IResponse>
    {
        public int CategoryId { get; set; }

        public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, IResponse>
        {
            private readonly ICategoryRepository _categoryRepository;

            public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
            {
                _categoryRepository = categoryRepository;
            }
            public async Task<IResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
            {
                var deletedCategory = await _categoryRepository.GetAsync(_=>_.CategoryId == request.CategoryId);

                _categoryRepository.Delete(deletedCategory);
                await _categoryRepository.SaveChangesAsync();

                return new Response<Category>(deletedCategory);
            }
        }

    }
}
