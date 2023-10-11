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
        private readonly IRepository<ProductEntity> productRepository;
        private readonly IMapper mapper;
        public ProductService(IRepository<ProductEntity> productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task Create(CreateProductDTO createProductDTO)
        {
            await productRepository.Insert(mapper.Map<ProductEntity>(createProductDTO));
            await productRepository.Save();
        }

        public async Task Delete(int id)
        {
            if (await productRepository.GetById(id) == null)
                return;

            await productRepository.Delete(id);
            await productRepository.Save();
        }

        public async Task Edit(EditProductDTO editProductDTO)
        {
            await productRepository.Update(mapper.Map<ProductEntity>(editProductDTO));
            await productRepository.Save();
        }

        public async Task<IEnumerable<ProductDTO>> Get()
        {
            var result = await productRepository.GetListBySpec(new Products.GetAll());

            return mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task<ProductDTO?> GetById(int id)
        {
            ProductEntity? productDTO = await productRepository.GetItemBySpec(new Products.GetById(id));

            if (productDTO == null)
                throw new Exception();

            return mapper.Map<ProductDTO>(productDTO);
        }
    }
}
