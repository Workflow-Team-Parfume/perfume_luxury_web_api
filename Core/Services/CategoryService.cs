using AutoMapper;
using Core.Dtos.Category;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> categoryRepository;
        private readonly IMapper mapper;

        public CategoryService(IRepository<Category> categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task Create(CreateCategoryDTO categoryDTO)
        {
            await categoryRepository.Insert(mapper.Map<Category>(categoryDTO));
            await categoryRepository.Save();
        }

        public async Task Delete(int id)
        {
            if (await categoryRepository.GetById(id) == null)
                return;

            await categoryRepository.Delete(id);
            await categoryRepository.Save();

        }

        public async Task Edit(CategoryDTO categoryDTO)
        {
            await categoryRepository.Update(mapper.Map<Category>(categoryDTO));
            await categoryRepository.Save();
        }

        public async Task<IEnumerable<CategoryDTO>> Get()
        {
            return mapper.Map<IEnumerable<CategoryDTO>>(await categoryRepository.GetAll());
        }

        public async Task<CategoryDTO?> GetById(int id)
        {
            Category? category = await categoryRepository.GetItemBySpec(new Categories.GetById(id));

            if (category == null)
                throw new Exception();

            return mapper.Map<CategoryDTO>(category);
        }
    }
}
