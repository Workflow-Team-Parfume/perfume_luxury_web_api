using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Rating
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public UserEntity User { get; set; }
        public Care? Care { get; set; }
        public int? CareId { get; set; }
        public Parfume? Parfume { get; set; }
        public int? ParfumeId { get; set; }
        public decimal Rate{ get; set; }
    }
}
