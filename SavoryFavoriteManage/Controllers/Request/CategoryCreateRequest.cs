using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SavoryFavoriteManage.Vo;

namespace SavoryFavoriteManage.Controllers.Request
{
    public class CategoryCreateRequest
    {

        public int? CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

    }
}
