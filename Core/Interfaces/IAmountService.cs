using Core.Dtos.Amount;
using Core.Dtos.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IAmountService
    {
        Task<IEnumerable<AmountDTO>> Get();
        Task<AmountDTO?> GetById(int id);
        Task Create(CreateAmountDTO amountDTO);
        Task Edit(AmountDTO amountDTO);
        Task Delete(int id);
    }
}
