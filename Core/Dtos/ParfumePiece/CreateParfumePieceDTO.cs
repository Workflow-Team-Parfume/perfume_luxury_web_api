using Core.Dtos.Amount;
using Core.Dtos.Parfume;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.ParfumePiece
{
    public class CreateParfumePieceDTO
    {
        public int? InStock { get; set; }

        public decimal Price { get; set; }

        public int AmountId { get; set; }
    }
}
