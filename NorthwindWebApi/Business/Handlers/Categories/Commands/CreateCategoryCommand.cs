using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.Categories.Commands;

public class CreateCategoryCommand : IRequest<IResponse>
{
    public string CategoryName { get; set; }
    public string Description { get; set; }

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, IResponse>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category addedCategory = new Category();
            addedCategory.CategoryName = request.CategoryName;
            addedCategory.Description = request.Description;

            _categoryRepository.Add(addedCategory);
            await _categoryRepository.SaveChangesAsync();

            return new Response<Category>(addedCategory);
        }
    }
}
