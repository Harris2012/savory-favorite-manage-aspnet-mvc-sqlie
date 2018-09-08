using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SavoryFavorite.Vo;

namespace SavoryFavorite.Controllers.Request
{
    public class CategoryUpdateRequest
    {

        public int? Id { get; set; }

        public int? CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }
    }
}
