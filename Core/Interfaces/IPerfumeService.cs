using Core.Dtos.Parfume;
using Core.Dtos.Perfume;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPerfumeService
    {
        Task<IEnumerable<PerfumeDTO>> Get();
        Task<PerfumeDTO?> GetById(int id);
        Task Create(CreatePerfumeDTO createPerfumeDTO);
        Task Edit(EditPerfumeDTO perfumeDTO);
        Task Delete(int id);
    }
}
