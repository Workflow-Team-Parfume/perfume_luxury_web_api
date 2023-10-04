using AutoMapper;
using Core.Dtos.Parfume;
using Core.Dtos.Perfume;
using Core.Interfaces;
using Core.Specifications;
using Core.Entities;

namespace Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<ProductEntity> perfumeService;
        private readonly IMapper mapper;
        public ProductService(IRepository<ProductEntity> perfumeService, IMapper mapper)
        {
            this.perfumeService = perfumeService;
            this.mapper = mapper;
        }

        public async Task Create(CreateProductDTO perfumeDto)
        {
            await perfumeService.Insert(mapper.Map<ProductEntity>(perfumeDto));
            await perfumeService.Save();
        }

        public async Task Delete(int id)
        {
            if (await perfumeService.GetById(id) == null)
                return;

            await perfumeService.Delete(id);
            await perfumeService.Save();
        }

        public async Task Edit(EditProductDTO perfume)
        {
            await perfumeService.Update(mapper.Map<ProductEntity>(perfume));
            await perfumeService.Save();
        }

        public async Task<IEnumerable<ProductDTO>> Get()
        {
            var result = await perfumeService.GetListBySpec(new Perfumes.GetAll());

            return mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task<ProductDTO?> GetById(int id)
        {
            ProductEntity? perfume = await perfumeService.GetItemBySpec(new Perfumes.GetById(id));

            if (perfume == null)
                throw new Exception();

            return mapper.Map<ProductDTO>(perfume);
        }
    }
}
