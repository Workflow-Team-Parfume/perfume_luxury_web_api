using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.ParfumePiece
{
    public class EditParfumePieceDTO
    {
        public int Id { get; set; }
        public int? InStock { get; set; }
        public decimal Price { get; set; }
        public int AmountId { get; set; }
    }
}
