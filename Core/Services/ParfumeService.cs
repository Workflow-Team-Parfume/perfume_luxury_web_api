using AutoMapper;
using Core.Dtos.Parfume;
using Core.Dtos.ParfumePiece;
using Core.Dtos.Perfume;
using Core.Dtos.Product;
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
    public class ParfumeService : IParfumeService
    {
        private readonly IRepository<ProductEntity> productRepository;
        private readonly IRepository<ParfumePiece> parfumePieceRepository;
        private readonly IRepository<Parfume> parfumeRepository;
        private readonly IMapper mapper;
        public ParfumeService(IRepository<ProductEntity> productRepository, IMapper mapper, IRepository<ParfumePiece> parfumePieceRepository, IRepository<Parfume> parfumeRepository)
        {
            this.productRepository = productRepository;
            this.parfumePieceRepository = parfumePieceRepository;
            this.parfumeRepository = parfumeRepository;
            this.mapper = mapper;
        }
        public async Task Create(CreateProductParfumeDTO createProductParfumeDTO)
        {
            ProductEntity productEntity = mapper.Map<ProductEntity>(createProductParfumeDTO);

            await productRepository.Insert(productEntity);
            await productRepository.Save();

            Parfume parfume = new Parfume()
            {
                ProductId = productEntity.Id
            };

            await parfumeRepository.Insert(parfume);
            await parfumeRepository.Save();

            foreach (var item in createProductParfumeDTO.ParfumePieces)
            {
                ParfumePiece parfumePiece = mapper.Map<ParfumePiece>(item);

                parfumePiece.ParfumeId = parfume.Id;

                await parfumePieceRepository.Insert(parfumePiece);
                await parfumePieceRepository.Save();
            }
        }

        public async Task Delete(int id)
        {
            if (await parfumeRepository.GetById(id) == null)
                return;

            await parfumeRepository.Delete(id);
            await parfumeRepository.Save();
        }

        public async Task Edit(EditProductParfumeDTO editProductDTO)
        {
            await productRepository.Update(mapper.Map<ProductEntity>(editProductDTO));
            await productRepository.Save();
        }

        public async Task<IEnumerable<ParfumeDTO>> Get()
        {
            var result = await parfumeRepository.GetListBySpec(new Parfumes.GetAll());

            return mapper.Map<IEnumerable<ParfumeDTO>>(result);
        }

        public async Task<ParfumeDTO?> GetById(int id)
        {
            Parfume? parfume = await parfumeRepository.GetItemBySpec(new Parfumes.GetById(id));

            if (parfume == null)
                throw new Exception();

            return mapper.Map<ParfumeDTO>(parfume);
        }
    }
}
