using AutoMapper;
using Core.Dtos.Parfume;
using Core.Dtos.Perfume;
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
    public class PerfumesService : IPerfumeService
    {
        private readonly IRepository<Parfume> perfumeService;
        private readonly IMapper mapper;
        public PerfumesService(IRepository<Parfume> perfumeService, IMapper mapper)
        {
            this.perfumeService = perfumeService;
            this.mapper = mapper;
        }

        public async Task Create(CreatePerfumeDTO perfumeDto)
        {
            await perfumeService.Insert(mapper.Map<Parfume>(perfumeDto));
            await perfumeService.Save();
        }

        public async Task Delete(int id)
        {
            if (await perfumeService.GetById(id) == null)
                return;

            await perfumeService.Delete(id);
            await perfumeService.Save();
        }

        public async Task Edit(EditPerfumeDTO perfume)
        {
            await perfumeService.Update(mapper.Map<Parfume>(perfume));
            await perfumeService.Save();
        }

        public async Task<IEnumerable<PerfumeDTO>> Get()
        {
            var result = await perfumeService.GetListBySpec(new Perfumes.GetAll());

            return mapper.Map<IEnumerable<PerfumeDTO>>(result);
        }

        public async Task<PerfumeDTO?> GetById(int id)
        {
            Parfume? perfume = await perfumeService.GetItemBySpec(new Perfumes.GetById(id));

            if (perfume == null)
                throw new Exception();

            return mapper.Map<PerfumeDTO>(perfume);
        }
    }
}
