using Ardalis.Specification;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Core.Specifications
{
    public static class Amounts
    {
        public class GetById : Specification<Amount>
        {
            public GetById(int id)
            {
                Query
                    .Where(x => x.Id == id);
            }
        }
    }
}
