using AutoMapper;
using Core.Dtos.Brand;
using Core.Dtos.Parfume;
using Core.Interfaces;
using Core.Specifications;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class BrandService : IBrandService
    {
        private readonly IRepository<Brand> brandRepository;
        private readonly IMapper mapper;

        public BrandService(IRepository<Brand> brandRepository, IMapper mapper)
        {
            this.brandRepository = brandRepository;
            this.mapper = mapper;
        }

        public async Task Create(CreateBrandDTO brandDTO)
        {
            await brandRepository.Insert(mapper.Map<Brand>(brandDTO));
            await brandRepository.Save();
        }

        public async Task Delete(int id)
        {
            if (await brandRepository.GetById(id) == null)
                return;

            await brandRepository.Delete(id);
            await brandRepository.Save();
        }

        public async Task Edit(BrandDTO brandDTO)
        {
            await brandRepository.Update(mapper.Map<Brand>(brandDTO));
            await brandRepository.Save();
        }

        public async Task<IEnumerable<BrandDTO>> Get()
        {
            return mapper.Map<IEnumerable<BrandDTO>>(await brandRepository.GetAll());
        }

        public async Task<BrandDTO?> GetById(int id)
        {
            Brand? brand = await brandRepository.GetItemBySpec(new Brands.GetById(id));

            if (brand == null)
                throw new Exception();

            return mapper.Map<BrandDTO>(brand);
        }
    }
}
