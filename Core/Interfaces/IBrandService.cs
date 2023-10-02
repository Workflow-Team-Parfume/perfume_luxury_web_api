using Core.Dtos.Brand;
using Core.Dtos.Parfume;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandDTO>> Get();
        Task<BrandDTO?> GetById(int id);
        Task Create(CreateBrandDTO brandDTO);
        Task Edit(BrandDTO brandDTO);
        Task Delete(int id);
    }
}
