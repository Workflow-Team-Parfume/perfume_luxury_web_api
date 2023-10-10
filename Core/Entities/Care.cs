﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Care
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }
        public ICollection<CarePiece> CarePieces { get; set; }

    }
}
