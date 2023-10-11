using Core.Dtos.ParfumePiece;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.Product
{
    public class EditProductParfumeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string ImgPath { get; set; }
        public bool Active { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public List<EditParfumePieceDTO> ParfumePieces { get; set; }
    }
}
