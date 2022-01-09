using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.Categories.Commands
{
    
    public class UpdateCategoryCommand : IRequest<IResponse>
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, IResponse>
        {
            private readonly ICategoryRepository _categoryRepository;

            public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
            {
                _categoryRepository = categoryRepository;
            }
            public async Task<IResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
            {
                Category updateCategory = _categoryRepository.Get(_=>_.CategoryId == request.CategoryId);

                updateCategory.CategoryName = request.CategoryName;
                updateCategory.Description = request.Description;

                _categoryRepository.Update(updateCategory);
                await _categoryRepository.SaveChangesAsync();

                return new Response<Category>(updateCategory);
            }
        }
    }
}
