using Core.Dtos.Amount;
using Core.Dtos.Parfume;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.ParfumePiece
{
    public class ParfumePieceDTO
    {
        public int Id { get; set; }

        public int? InStock { get; set; }

        public decimal Price { get; set; }

        public AmountDTO Amount { get; set; }

        public ParfumeDTO Parfume { get; set; }
    }
}
