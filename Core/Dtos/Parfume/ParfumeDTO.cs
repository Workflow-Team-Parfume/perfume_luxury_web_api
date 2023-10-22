using Core.Dtos.ParfumePiece;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.Parfume
{
    public class ParfumeDTO
    {
        public int Id { get; set; }
        public ProductDTO Product { get; set; }
        public List<ParfumePieceDTO> ParfumePieces { get; set; }
    }
}
