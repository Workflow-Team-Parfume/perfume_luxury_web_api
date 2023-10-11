using Core.Dtos.Parfume;
using Core.Dtos.ParfumePiece;
using Core.Dtos.Perfume;
using Core.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IParfumeService
    {
        Task<IEnumerable<ParfumeDTO>> Get();
        Task<ParfumeDTO?> GetById(int id);
        Task Create(CreateProductParfumeDTO createProductParfumeDTO);
        Task Edit(EditProductParfumeDTO editProductDTO);
        Task Delete(int id);
    }
}
