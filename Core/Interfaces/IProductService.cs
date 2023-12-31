﻿using Core.Dtos.Parfume;
using Core.Dtos.Perfume;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> Get();
        Task<ProductDTO?> GetById(int id);
        Task Create(CreateProductDTO createProductDTO);
        Task Edit(EditProductDTO editProductDTO);
        Task Delete(int id);
    }
}
