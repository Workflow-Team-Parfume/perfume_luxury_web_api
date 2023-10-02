using AutoMapper;
using Core.Dtos.Amount;
using Core.Dtos.Brand;
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
    public class AmountService : IAmountService
    {
        private readonly IRepository<Amount> amountRepository;
        private readonly IMapper mapper;

        public AmountService(IRepository<Amount> amountRepository, IMapper mapper)
        {
            this.amountRepository = amountRepository;
            this.mapper = mapper;
        }

        public async Task Create(CreateAmountDTO amountDTO)
        {
            await amountRepository.Insert(mapper.Map<Amount>(amountDTO));
            await amountRepository.Save();
        }

        public async Task Delete(int id)
        {
            if (await amountRepository.GetById(id) == null)
                return;

            await amountRepository.Delete(id);
            await amountRepository.Save();
        }

        public async Task Edit(AmountDTO amountDTO)
        {
            await amountRepository.Update(mapper.Map<Amount>(amountDTO));
            await amountRepository.Save();
        }

        public async Task<IEnumerable<AmountDTO>> Get()
        {
            return mapper.Map<IEnumerable<AmountDTO>>(await amountRepository.GetAll());
        }

        public async Task<AmountDTO?> GetById(int id)
        {
            Amount? amount = await amountRepository.GetItemBySpec(new Amounts.GetById(id));

            if (amount == null)
                throw new Exception();

            return mapper.Map<AmountDTO>(amount);
        }
    }
}
