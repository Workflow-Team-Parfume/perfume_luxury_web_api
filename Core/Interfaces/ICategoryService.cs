using Core.Dtos.Amount;
using Core.Dtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> Get();
        Task<CategoryDTO?> GetById(int id);
        Task Create(CreateCategoryDTO categoryDTO);
        Task Edit(CategoryDTO categoryDTO);
        Task Delete(int id);
    }
}
