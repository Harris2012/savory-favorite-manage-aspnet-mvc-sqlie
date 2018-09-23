using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SavoryFavoriteManage.Vo;

namespace SavoryFavoriteManage.Controllers.Request
{
    public class FavoriteUpdateRequest
    {

        public int Id { get; set; }

        public string Host { get; set; }

        public string Title { get; set; }

        public int? CategoryId { get; set; }
    }
}
