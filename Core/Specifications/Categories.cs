using Ardalis.Specification;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public static class Categories
    {
        public class GetById : Specification<Category>
        {
            public GetById(int id)
            {
                Query
                    .Where(x => x.Id == id);
            }
        }
    }
}
